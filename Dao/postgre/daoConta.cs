using Fluxo_De_Caixa.Models;
using Fluxo_De_Caixa.Util;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fluxo_De_Caixa.Dao.postgre
{
    class daoConta
    {

        public Conta Insert(Conta obj)
        {

            String StringInsert = $" INSERT INTO CONTAS " +
                                "(ID_EMPRESA, CODIGO, TIPO, DESCRICAO, USER_INSERT, USER_UPDATE) " +
                                " VALUES(" +
                                $" {obj.IdEmpresa}, '{obj.Codigo}','{obj.Tipo}','{obj.Descricao}',{obj.UserInsert},{obj.UserUpdate})  RETURNING CODIGO ";

            using (var objConexao = new NpgsqlConnection(DataBase.RunCommand.connectionString))
            {
                using (var objCommand = new NpgsqlCommand(StringInsert, objConexao))
                {
                    try
                    {
                        objConexao.Open();

                        var objDataReader = objCommand.ExecuteReader();

                        if (objDataReader.HasRows)
                        {

                            objDataReader.Read();

                            obj.Codigo = objDataReader["CODIGO"].ToString();

                        }

                    }
                    catch (Exception ex)
                    {
                        obj = null;

                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        objConexao.Close();
                    }
                }
            }


            return obj;


        }

        public void Update(Conta obj)
        {

            String StringUpdate = $" UPDATE  CONTAS SET " +
                 $"DESCRICAO    = '{obj.Descricao}', " +
                 $"TIPO  = '{obj.Tipo}', "+
                 $"USER_UPDATE = {obj.UserUpdate} " +
                 $"WHERE ID_EMPRESA = {obj.IdEmpresa} and CODIGO = '{obj.Codigo}' ";

            Console.WriteLine(StringUpdate);

            try
            {

                DataBase.RunCommand.CreateCommand(StringUpdate);

            }
            catch (ExceptionErroImportacao ex)
            {
                MessageBox.Show(ex.Message, "Atenção!");
            }

        }

        public void Delete(Conta obj)
        {

            String StringDelete = $" DELETE FROM  CONTAS  WHERE ID_EMPRESA = {obj.IdEmpresa} AND CODIGO = '{obj.Codigo}' ";

            DataBase.RunCommand.CreateCommand(StringDelete);

        }

        public Conta Seek(int id_empresa,string codigo)
        {

            Conta obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = $"SELECT * FROM CONTAS WHERE ID_EMPRESA = {id_empresa} and CODIGO = '{codigo}'";

            using (var objConexao = new NpgsqlConnection(strStringConexao))
            {
                using (var objCommand = new NpgsqlCommand(strSelect, objConexao))
                {
                    try
                    {
                        objConexao.Open();

                        var objDataReader = objCommand.ExecuteReader();

                        if (objDataReader.HasRows)
                        {

                            objDataReader.Read();

                            obj = new Conta();

                            obj = PopulaConta(objDataReader);


                        }

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        objConexao.Close();
                    }
                }
            }

            return obj;
        }

    
        private Conta PopulaConta(NpgsqlDataReader objDataReader)
        {

            var obj = new Conta();
            obj.IdEmpresa  = Convert.ToInt32(objDataReader["ID_EMPRESA"]);
            obj.Codigo     = objDataReader["CODIGO"].ToString();
            obj.Tipo       = objDataReader["TIPO"].ToString();
            obj.Descricao  = objDataReader["DESCRICAO"].ToString();
            obj.UserInsert = Convert.ToInt32(objDataReader["USER_INSERT"]);
            obj.UserUpdate = Convert.ToInt32(objDataReader["USER_UPDATE"]);

            return obj;
        }
    

        public List<Conta> getAll(int Ordenacao, string Filtro)
        {

            Conta obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            List<Conta> lista = new List<Conta>();

            string strSelect = SqlGrid(Ordenacao, Filtro);

            Console.WriteLine(strSelect);

            using (var objConexao = new NpgsqlConnection(strStringConexao))
            {
                using (var objCommand = new NpgsqlCommand(strSelect, objConexao))
                {
                    try
                    {
                        objConexao.Open();

                        var objDataReader = objCommand.ExecuteReader();

                        if (objDataReader.HasRows)
                        {

                            while (objDataReader.Read())
                            {

                                obj = new Conta();

                                obj = PopulaConta(objDataReader);

                                lista.Add(obj);

                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        objConexao.Close();
                    }
                }
            }

            return lista;
        }
            

        public string SqlGrid(int Ordenacao, string Filtro)
        {
            string Where = "";

            string OrderBy = "";

            string strSelect = " SELECT  " +
                                "   ID_EMPRESA" +
                                " , CODIGO " +
                                " , TIPO " +
                                " , DESCRICAO " +
                                " , USER_INSERT " +
                                " , USER_UPDATE" +
                                " FROM CONTAS ";

            //Adiciona WHERE 
            if (Filtro.Trim() != "")
            {


                switch (Ordenacao)
                {
                    case 0:
                        Where = $"WHERE CODIGO = '{Filtro}'";
                        break;
                    case 1:
                        Where = $"WHERE TIPO LIKE '%{Filtro.Trim()}%'";
                        break;
                    case 2:
                        Where = $"WHERE DESCRICAO LIKE '%{Filtro.Trim()}%'";
                        break;
                }


            }

            //Adiciona ORDER BY


            switch (Ordenacao)
            {
                case 0:
                    OrderBy = $"ORDER BY CODIGO";
                    break;
                case 1:
                    OrderBy = $"ORDER BY TIPO";
                    break;
                case 2:
                    OrderBy = $"ORDER BY DESCRICAO";
                    break;

            }

            strSelect += $" {Where} {OrderBy} ";

            return strSelect;

        }

        public string SqlGridBrowse(int Ordenacao, string Filtro)
        {
            string Where = "";

            string OrderBy = "";

            string strSelect = "SELECT  " +
                                "   CODIGO " +
                                " , TIPO " +
                                " , DESCRICAO " +
                                " FROM CONTAS ";




            //Adiciona WHERE 
            if (Filtro.Trim() != "")
            {


                switch (Ordenacao)
                {
                    case 0:
                        Where = $"WHERE CODIGO = '{Filtro}'";
                        break;
                    case 1:
                        Where = $"WHERE TIPO LIKE '%{Filtro.Trim()}%'";
                        break;
                    case 2:
                        Where = $"WHERE DESCRICAO LIKE '%{Filtro.Trim()}%'";
                        break;
                }


            }

            //Adiciona ORDER BY


            switch (Ordenacao)
            {
                case 0:
                    OrderBy = $"ORDER BY CODIGO";
                    break;
                case 1:
                    OrderBy = $"ORDER BY TIPO";
                    break;
                case 2:
                    OrderBy = $"ORDER BY DESCRICAO";
                    break;

            }

            strSelect += $" {Where} {OrderBy} ";

            return strSelect;

        }

    }
}
