using Fluxo_De_Caixa.Extensoes;
using Fluxo_De_Caixa.Models;
using Fluxo_De_Caixa.Util;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fluxo_De_Caixa.Dao.postgre
{
    class daoCabOS
    {

        public CabOS Insert(CabOS obj)
        {

            String StringInsert = $" INSERT INTO OS_CAB " +
                                "(ID_EMPRESA, ENTRADA, SAIDA, ID_CLIENTE, ID_CARRO, HORAS_SERVICO, KM, OBS, LUCRO, ID_COND_PGTO, MAO_OBRA, MAO_OBRA_VLR, PECAS_VLR, USER_INSERT, USER_UPDATE) " +
                                $" VALUES({obj.Id_Empresa},'{obj.Entrada.ToString("yyyy-MM-dd")}','{obj.Saida?.ToString("yyyy-MM-dd")}',{obj.Id_Cliente},'{obj.Id_Carro}','{obj.Horas_Servico}',{obj.Km},{obj.Lucro.DoubleParseDb()},'{obj.Obs}',{obj.Id_Cond_Pgto},'{obj.Mao_Obra}',{obj.Mao_Obra_Vlr.DoubleParseDb()},{obj.Pecas_Vlr.DoubleParseDb()},{obj.User_Insert},{obj.User_Update})  RETURNING ID ";

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

                            obj.Id = Convert.ToInt32(objDataReader["ID"]);

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

        public void Update(CabOS obj)
        {

            String StringUpdate = $" UPDATE  OSCAB SET " +
                        $"ENTRADA  	        =  '{obj.Entrada.ToString("yyyy-MM-dd")}', " +
                        $"SAIDA   	        =  '{obj.Saida?.ToString("yyyy-MM-dd")}', " +
                        $"ID_CLIENTE        =  {obj.Id_Cliente}, " +
                        $"ID_CARRO          =  '{obj.Id_Carro}', " +
                        $"HORAS_SERVICO     =  '{obj.Horas_Servico}', " +
                        $"KM                =  {obj.Km}, " +
                        $"OBS               =  {obj.Lucro.DoubleParseDb()}, " +
                        $"LUCRO             =  '{obj.Obs}', " +
                        $"ID_COND_PGTO      =  {obj.Id_Cond_Pgto}, " +
                        $"MAO_OBRA          =  '{obj.Mao_Obra}', " +
                        $"MAO_OBRA_VLR      =  {obj.Mao_Obra_Vlr.DoubleParseDb()}, " +
                        $"PECAS_VLR         =  {obj.Pecas_Vlr.DoubleParseDb()}, " +
                        $"USER_INSERT       =  {obj.User_Insert}, " +
                        $"USER_UPDATE       =  {obj.User_Update} ";

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

        public void Delete(CabOS obj)
        {

            String StringDelete = $" DELETE FROM  OSCAB  WHERE ID_EMPRESA = {obj.Id_Empresa} AND ID = {obj.Id} ";

            DataBase.RunCommand.CreateCommand(StringDelete);

        }
           

        public CabOS Seek(int id_empresa, int id)
        {

            CabOS obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect =  " SELECT  CAB.ID_EMPRESA		" +
                                "        ,CAB.ID                " +
                                "        ,CAB.ENTRADA           " +
                                "        ,CAB.SAIDA             " +
                                "        ,CAB.ID_CLIENTE        " +
                                "        ,CAB.ID_CARRO          " +
                                "        ,CAB.ID_COND           " +
                                "        ,CAB.HORAS_SERVICO     " +
                                "        ,CAB KM                " +
                                "        ,CAB.OBS               " +
                                "        ,CAB.LUCRO             " +
                                "        ,CAB.ID_COND_PGTO      " +
                                "        ,CAB.MAO_OBRA          " +
                                "        ,CAB.MAO_OBRA_VLR      " +
                                "        ,CAB.PECAS_VLR         " +
                                "        ,CAB.USER_INSERT       " +
                                "        ,CAB.USER_UPDATE       " +
                                "        ,CLI.CODIGO     AS CLI_CODIGO		" +
                                "        ,CLI.CNPJ_CPF   AS CLI_CNPJ_CPF    " +
                                "        ,CLI.TEL1       AS CLI_TEL1        " +
                                "        ,CLI.EMAIL      AS CLI_EMAIL       " +
                                "        ,CAR.PLACA      AS CAR_PLACA       " +
                                "        ,CAR.MARCA      AS CAR_MARCA       " +
                                "        ,CAR.COR        AS CAR_COR         " +
                                "        ,CAR.ANO        AS CAR_ANO         " +
                                "        ,COALESCE(COND.ID,0)  AS COND_ID   " +
                                "        ,COALESCE(COND.DESCRICAO,'') AS COND_DESCRICAO " +
                                "FROM OS_CAB CAB " +
                                "INNER JOIN CLIENTES  CLI  ON CLI.ID_EMPRESA  = CAB.ID_EMPRESA  AND CLI.CODIGO  = CAB.ID_CLIENTE  " +
                                "INNER JOIN OS_CAR    CAR  ON CAR.ID_EMPRESA  = CAB.ID_EMPRESA  AND CAR.PLACA   = CAB.ID_CARRO    " +
                                "LEFT  JOIN CONDICOES COND ON COND.ID_EMPRESA = CAB.ID_EMPRESA  AND COND.ID     = CAB.ID_COND     ";


            //Adiciona WHERE 
            strSelect += $"WHERE BAI.ID_EMPRESA = {id_empresa} and CAB.ID = {id}";

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

                            obj = new CabOS();

                            obj = PopulaCabOS(objDataReader);


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


        private CabOS PopulaCabOS(NpgsqlDataReader objDataReader)
        {

            var obj = new CabOS();


           obj.Id_Empresa = Convert.ToInt32(objDataReader["ID_EMPRESA"]);
            try
            {
                obj.Entrada = Convert.ToDateTime(objDataReader["Entrada"]);
            } catch(Exception _)
            {
                obj.Entrada = DateTime.Now;
            }
           
            try
            {
                obj.Saida = Convert.ToDateTime(objDataReader["Saida"]);
            }
            catch (Exception _)
            {
                obj.Saida = null;
            }
            
           obj.Id_Cliente = Convert.ToInt32(objDataReader["Id_Cliente"]);
           obj.Id_Carro = objDataReader["Id_Carro"].ToString();
           obj.Horas_Servico = objDataReader["Horas_Servico"].ToString();
           obj.Km = Convert.ToInt32(objDataReader["KM"]);
           obj.Lucro = Convert.ToDouble(objDataReader["LUCRO"]);
           obj.Obs = objDataReader["OBS"].ToString();
           obj.Id_Cond_Pgto = Convert.ToInt32(objDataReader["Id_Cond_Pgto"]);
           obj.Mao_Obra = objDataReader["Mao_Obra"].ToString();
           obj.Mao_Obra_Vlr = Convert.ToDouble(objDataReader["Mao_Obra_Vlr"]);
           obj.Pecas_Vlr = Convert.ToDouble(objDataReader["Pecas_Vlr"]);
           obj.User_Insert = Convert.ToInt32(objDataReader["User_Insert"]);
           obj.User_Update = Convert.ToInt32(objDataReader["User_Update"]);
           obj.Cli_Codigo = objDataReader["Cli_Codigo"].ToString();
           obj.Cli_Cnpj_Cpf = objDataReader["Cli_Cnpj_Cpf"].ToString();
           obj.Cli_Tel1 = objDataReader["Cli_Tel1"].ToString();
           obj.Cli_Email = objDataReader["Cli_Email"].ToString();
           obj.Car_Placa = objDataReader["Car_Placa"].ToString();
           obj.Car_Marca = objDataReader["Car_Marca"].ToString();
           obj.Car_Cor = objDataReader["Car_Cor"].ToString();
           obj.Car_Ano = objDataReader["Car_Ano"].ToString();
           obj.Cond_Id = Convert.ToInt32(objDataReader["Cond_Id"]);
           obj.Cond_Descricao = objDataReader["Cond_Descricao"].ToString();

            return obj;
        }

        private CabOS PopulaOSBrowse(NpgsqlDataReader objDataReader)
        {

            var obj = new CabOS();


            obj.Id_Empresa = Convert.ToInt32(objDataReader["ID_EMPRESA"]);
            try
            {
                obj.Entrada = Convert.ToDateTime(objDataReader["Entrada"]);
            }
            catch (Exception _)
            {
                obj.Entrada = DateTime.Now;
            }

            try
            {
                obj.Saida = Convert.ToDateTime(objDataReader["Saida"]);
            }
            catch (Exception _)
            {
                obj.Saida = null;
            }

            obj.Id_Cliente = Convert.ToInt32(objDataReader["Id_Cliente"]);
            obj.Id_Carro = objDataReader["Id_Carro"].ToString();
            obj.Horas_Servico = objDataReader["Horas_Servico"].ToString();
            obj.Km = Convert.ToInt32(objDataReader["KM"]);
            obj.Lucro = Convert.ToDouble(objDataReader["LUCRO"]);
            obj.Obs = objDataReader["OBS"].ToString();
            obj.Id_Cond_Pgto = Convert.ToInt32(objDataReader["Id_Cond_Pgto"]);
            obj.Mao_Obra = objDataReader["Mao_Obra"].ToString();
            obj.Mao_Obra_Vlr = Convert.ToDouble(objDataReader["Mao_Obra_Vlr"]);
            obj.Pecas_Vlr = Convert.ToDouble(objDataReader["Pecas_Vlr"]);
            obj.User_Insert = Convert.ToInt32(objDataReader["User_Insert"]);
            obj.User_Update = Convert.ToInt32(objDataReader["User_Update"]);
            obj.Cli_Codigo = objDataReader["Cli_Codigo"].ToString();
            obj.Cli_Cnpj_Cpf = objDataReader["Cli_Cnpj_Cpf"].ToString();
            obj.Cli_Tel1 = objDataReader["Cli_Tel1"].ToString();
            obj.Cli_Email = objDataReader["Cli_Email"].ToString();
            obj.Car_Placa = objDataReader["Car_Placa"].ToString();
            obj.Car_Marca = objDataReader["Car_Marca"].ToString();
            obj.Car_Cor = objDataReader["Car_Cor"].ToString();
            obj.Car_Ano = objDataReader["Car_Ano"].ToString();
            obj.Cond_Id = Convert.ToInt32(objDataReader["Cond_Id"]);
            obj.Cond_Descricao = objDataReader["Cond_Descricao"].ToString();

            return obj;
        }


        public List<CabOS> getAll(int Ordenacao, string Filtro)
        {

            CabOS obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            List<CabOS> lista = new List<CabOS>();

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

                                obj = new CabOS();

                                obj = PopulaOSBrowse(objDataReader);

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

            string strSelect = " SELECT 											     " +
                                     "       BAI.ID_EMPRESA                              " +
                                     "     , BAI.ID      		                         " +
                                     "     , BAI.ID_DOC                                  " +
                                     " 	   , BAI.EMISSAO  		                         " +
                                     " 	   , BAI.VALOR     	                             " +
                                     "     , BAI.USER_INSERT                             " +
                                     "     , BAI.USER_UPDATE                             " +
                                     "     , DOC.TIPO           AS DOC_TIPO              " +
                                     "     , DOC.DOC            AS DOC_DOC               " +
                                     "     , DOC.SERIE          AS DOC_SERIE             " +
                                     "     , DOC.PARCELA        AS DOC_PARCELA           " +
                                     "     , DOC.CLIFOR         AS DOC_CLIFOR            " +
                                     "     , CASE                                        " +
                                     "        WHEN DOC.TIPO = 'R'  THEN CLI.RAZAO        " +
                                     "        WHEN DOC.TIPO = 'P'  THEN FORNE.RAZAO      " +
                                     "     END  AS  DOC_RAZAO                            " +
                                     "     , DOC.EMISSAO        AS DOC_EMISSAO     		" +
                                     "     , DOC.VENCIMENTO     AS DOC_VENCIMENT   		" +
                                     "     , DOC.VALOR          AS DOC_VALOR       		" +
                                     "     , DOC.ABATIMENTO     AS DOC_ABATIMENT   		" +
                                     "     , DOC.JUROS          AS DOC_JUROS       		" +
                                     "     , DOC.VLR_PAGO       AS DOC_VLR_PAGO    		" +
                                     "     , DOC.SALDO          AS DOC_SALDO       		" +
                                     "     , DOC.OBS            AS DOC_OBS         		" +
                                     "     , CASE                                        " +
                                     "        WHEN DOC.TIPO = 'R' THEN CT_CLI.CODIGO     " +
                                     "        WHEN DOC.TIPO = 'P' THEN CT_FOR.CODIGO     " +
                                     "        ELSE ''                                    " +
                                     "     END AS _COD_CONTA                             " +
                                     "     ,CASE                                         " +
                                     "        WHEN DOC.TIPO = 'R' THEN CT_CLI.DESCRICAO  " +
                                     "        WHEN DOC.TIPO = 'P' THEN CT_FOR.DESCRICAO  " +
                                     "        ELSE ''                                    " +
                                     "     END AS _CONTA                                 " +
                                     " FROM OSCAB BAI                                   " +
                                     " INNER JOIN DOCUMENTOS DOC ON DOC.ID_EMPRESA = BAI.ID_EMPRESA AND DOC.ID = BAI.ID_DOC               " +
                                     " LEFT JOIN CLIENTES     CLI   ON CLI.ID_EMPRESA = DOC.ID_EMPRESA AND CLI.CODIGO = DOC.CLIFOR        " +
                                     " LEFT JOIN FORNECEDORES FORNE ON FORNE.ID_EMPRESA = DOC.ID_EMPRESA AND FORNE.CODIGO = DOC.CLIFOR    " +
                                     " LEFT JOIN CONTAS CT_CLI ON CT_CLI.ID_EMPRESA = DOC.ID_EMPRESA    AND CT_CLI.CODIGO = CLI.CONTA     " +
                                     " LEFT JOIN CONTAS CT_FOR ON CT_FOR.ID_EMPRESA = DOC.ID_EMPRESA    AND CT_FOR.CODIGO = FORNE.CONTA   ";

            //Adiciona WHERE 
            if (Filtro.Trim() != "")
            {


                switch (Ordenacao)
                {
                    case 0:
                        Where = $"WHERE DOC.DOC = '{Filtro}'";
                        break;
                    case 1:
                        Where = $"WHERE DOC.RAZAO LIKE '%{Filtro.Trim()}%'";
                        break;
                    case 2:
                        Where = $"WHERE DOC.TIPO = '{Filtro.Trim()}'";
                        break;
                }


            }

            //Adiciona ORDER BY


            switch (Ordenacao)
            {
                case 0:
                    OrderBy = $"ORDER BY DOC.DOC";
                    break;
                case 1:
                    OrderBy = $"ORDER BY DOC.RAZAO";
                    break;
                case 2:
                    OrderBy = $"ORDER BY DOC.TIPO";
                    break;

            }

            strSelect += $" {Where} {OrderBy} ";

            return strSelect;

        }

        public string SqlGridBrowse(int Ordenacao, string Filtro)
        {
            string Where = "";

            string OrderBy = "";

            string strSelect = " SELECT 											" +
                                "  	    BAI.ID      		                        " +
                                "     , BAI.ID_DOC                                  " +
                                " 	  , BAI.EMISSAO  		                        " +
                                " 	  , BAI.VALOR     	                            " +
                                "     , BAI.OBS                                     " +
                                " FROM OSCAB BAI                                   ";

            //Adiciona WHERE 
            if (Filtro.Trim() != "")
            {
                switch (Ordenacao)
                {
                    case 0:
                        Where = $"WHERE BAI.ID_EMPRESA = 1 AND BAI.ID = {Filtro}";
                        break;
                    case 1:
                        Where = $"WHERE BAI.ID_EMPRESA = 1 AND BAI.ID_DOC = {Filtro}";
                        break;
                }
            }

            //Adiciona ORDER BY


            switch (Ordenacao)
            {
                case 0:
                    OrderBy = $"ORDER BY BAI.ID_EMPRESA  ,  BAI.DOC ";
                    break;
                case 1:
                    OrderBy = $"ORDER BY BAI.ID_EMPRESA  ,  BAI.ID_DOC ";
                    break;

            }

            strSelect += $" {Where} {OrderBy} ";

            return strSelect;

        }

    }
}
