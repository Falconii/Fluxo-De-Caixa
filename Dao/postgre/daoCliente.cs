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
    class daoCliente
    {

        public Cliente Insert(Cliente obj)
        {

            String StringInsert = $" INSERT INTO CLIENTES " +
                                "(ID_EMPRESA,RAZAO, FANTASI, TEL1, EMAIL, CONTA, USER_INSERT, USER_UPDATE) " +
                                " VALUES(" +
                                $" {obj.IdEmpresa}, '{obj.Razao}','{obj.Fantasi}','{obj.Tel1}','{obj.Email}','{obj.Conta}',{obj.UserInsert},{obj.UserUpdate})  RETURNING CODIGO ";

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

                            obj.Codigo = Convert.ToInt32(objDataReader["CODIGO"]);

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

        public void Update(Cliente obj)
        {

            String StringUpdate = $" UPDATE  CLIENTES SET " +
                 $"RAZAO    = '{obj.Razao}', " +
                 $"FANTASI  = '{obj.Fantasi}', "+
                 $"TEL1     = '{obj.Tel1}', " +
                 $"EMAIL    = '{obj.Email}', " +
                 $"CONTA       = '{obj.Conta}' ," +
                 $"USER_UPDATE = {obj.UserUpdate} " +
                 $"WHERE ID_EMPRESA = {obj.IdEmpresa} and CODIGO = {obj.Codigo} ";

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

        public void Delete(Cliente obj)
        {

            String StringDelete = $" DELETE FROM  CLIENTES  WHERE ID_EMPRESA = {obj.IdEmpresa} AND CODIGO = {obj.Codigo} ";

            DataBase.RunCommand.CreateCommand(StringDelete);

        }

        public Cliente Seek(int id_empresa,int codigo)
        {

            Cliente obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = $"SELECT * FROM CLIENTES WHERE ID_EMPRESA = {id_empresa} and CODIGO = {codigo}";

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

                            obj = new Cliente();

                            obj = PopulaCliente(objDataReader);


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

    
        private Cliente PopulaCliente(NpgsqlDataReader objDataReader)
        {

            var obj = new Cliente();
            obj.IdEmpresa = Convert.ToInt32(objDataReader["ID_EMPRESA"]);
            obj.Codigo = Convert.ToInt32(objDataReader["CODIGO"]);
            obj.Razao = objDataReader["RAZAO"].ToString();
            obj.Fantasi = objDataReader["FANTASI"].ToString();
            obj.Tel1 = objDataReader["TEL1"].ToString();
            obj.Email = objDataReader["EMAIL"].ToString();
            obj.Conta = objDataReader["CONTA"].ToString();

            return obj;
        }
    

        public List<Cliente> getAll(int Ordenacao, string Filtro)
        {

            Cliente obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            List<Cliente> lista = new List<Cliente>();

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

                                obj = new Cliente();

                                obj = PopulaCliente(objDataReader);

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
                                " , RAZAO " +
                                " , FANTASI " +
                                " , TEL1 " +
                                " , EMAIL " +
                                " , CONTA " +
                                " FROM CLIENTES ";

            //Adiciona WHERE 
            if (Filtro.Trim() != "")
            {


                switch (Ordenacao)
                {
                    case 0:
                        Where = $"WHERE CODIGO = {Filtro}";
                        break;
                    case 1:
                        Where = $"WHERE RAZAO LIKE '%{Filtro.Trim()}%'";
                        break;
                    case 2:
                        Where = $"WHERE FANTASI LIKE '%{Filtro.Trim()}%'";
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
                    OrderBy = $"ORDER BY RAZAO";
                    break;
                case 2:
                    OrderBy = $"ORDER BY FANTASI";
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
                                "   CLIENTES.CODIGO CODIGO " +
                                " , CLIENTES.RAZAO  RAZAO  " +
                                " , CLIENTES.FANTASI FANTASIA " +
                                " , CLIENTES.TEL1 TEL1 " +
                                " , CLIENTES.EMAIL  EMAIL " +
                                " , CON.DESCRICAO CONTA "+
                                " FROM CLIENTES " +
                                " INNER JOIN CONTAS CON ON CLIENTES.ID_EMPRESA = CON.ID_EMPRESA AND CON.CODIGO = CLIENTES.CONTA ";




            //Adiciona WHERE 
            if (Filtro.Trim() != "")
            {


                switch (Ordenacao)
                {
                    case 0:
                        Where = $"WHERE CLIENTES.CODIGO = {Filtro}";
                        break;
                    case 1:
                        Where = $"WHERE CLIENTES.RAZAO LIKE '%{Filtro.Trim()}%'";
                        break;
                    case 2:
                        Where = $"WHERE CLIENTES.FANTASI LIKE '%{Filtro.Trim()}%'";
                        break;
                }


            }

            //Adiciona ORDER BY


            switch (Ordenacao)
            {
                case 0:
                    OrderBy = $"ORDER BY CLIENTES.CODIGO";
                    break;
                case 1:
                    OrderBy = $"ORDER BY CLIENTES.RAZAO";
                    break;
                case 2:
                    OrderBy = $"ORDER BY CLIENTES.FANTASI";
                    break;

            }

            strSelect += $" {Where} {OrderBy} ";

            return strSelect;

        }

    }
}
