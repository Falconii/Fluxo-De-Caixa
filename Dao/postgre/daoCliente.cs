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
                                "(ID_EMPRESA,RAZAO, CNPJ_CPF, FANTASI, ENDERECOF, NROF, BAIRROF, CIDADEF, UFF, CEPF, TEL1, EMAIL, CONTA, USER_INSERT, USER_UPDATE) " +
                                " VALUES(" +
                                $" {obj.IdEmpresa}, '{obj.Razao}','{obj.Cnpj_Cpf}','{obj.Fantasi}'," +
                                $" {obj.Enderecof}, '{obj.Nrof}','{obj.Bairrof}','{obj.Cidadef}','{obj.Bairrof}','{obj.Bairrof}'," +
                                $"'{obj.Tel1}','{obj.Email}','{obj.Conta}',{obj.UserInsert},{obj.UserUpdate})  RETURNING CODIGO ";

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
                 $"CNPJ_CPF = '{obj.Cnpj_Cpf}', " + 
                 $"FANTASI  = '{obj.Fantasi}', "+
                 $" ENDERECOF = '{obj.Enderecof}', " +
                 $"NROF = '{obj.Nrof}'," +
                 $"BAIRROF = '{obj.Bairrof}'," +
                 $"CIDADEF = '{obj.Cidadef}', " +
                 $"UFF = '{obj.Uff}'," +
                 $"CEPF = '{obj.Cepf}', " +
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
            daoDocumento dao = new daoDocumento();

            int nro = dao.ExisteByCliente(obj.IdEmpresa, obj.Codigo);

            if (nro > 0)
            {
                throw new Exception("Existem Documentos Para Este Cliente!\nNão Nosso Deletá-lo.");

            } else
            {

                String StringDelete = $" DELETE FROM  CLIENTES  WHERE ID_EMPRESA = {obj.IdEmpresa} AND CODIGO = {obj.Codigo} ";

                DataBase.RunCommand.CreateCommand(StringDelete);

            }

        }

        public Cliente Seek(int id_empresa,int codigo)
        {

            Cliente obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = "SELECT CLIENTES.*, CON.DESCRICAO AS CONTA_DESC FROM CLIENTES " +
                               "INNER JOIN CONTAS CON ON CON.ID_EMPRESA = CLIENTES.ID_EMPRESA AND CON.CODIGO = CLIENTES.CONTA " +
                              $"WHERE CLIENTES.ID_EMPRESA = {id_empresa} and CLIENTES.CODIGO = '{codigo}'";

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
            obj.Razao  = objDataReader["RAZAO"].ToString();
            obj.Cnpj_Cpf = objDataReader["CNPJ_CPF"].ToString();
            obj.Fantasi = objDataReader["FANTASI"].ToString();
            obj.Enderecof = objDataReader["ENDERECOF"].ToString();
            obj.Nrof = objDataReader["NROF"].ToString();
            obj.Bairrof = objDataReader["BAIRROF"].ToString();
            obj.Cidadef = objDataReader["CIDADEF"].ToString();
            obj.Uff = objDataReader["UFF"].ToString();
            obj.Cepf = objDataReader["CEPF"].ToString();;
            obj.Tel1 = objDataReader["TEL1"].ToString();
            obj.Email = objDataReader["EMAIL"].ToString();
            obj.Conta = objDataReader["CONTA"].ToString();
            obj._ContaDesc = objDataReader["CONTA_DESC"].ToString();

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
                                " CLIENTES.ID_EMPRESA" +
                                " , CLIENTES.CODIGO " +
                                " , CLIENTES.RAZAO " +
                                " , CLIENTES.FANTASI " +
                                " , CLIENTES.TEL1 " +
                                " , CLIENTES.EMAIL " +
                                " , CLIENTES.CONTA " +
                                " , CON.DESCRICAO CONTA_DESC " +
                                " FROM CLIENTES " +
                                " INNER JOIN CONTAS CON ON CON.ID_EMPRESA = CLIENTES.ID_EMPRESA AND CON.CODIGO = CLIENTES.CONTA ";

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
