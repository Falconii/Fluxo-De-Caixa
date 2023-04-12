using Fluxo_De_Caixa.Extensoes;
using Fluxo_De_Caixa.Models;
using Fluxo_De_Caixa.Util;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fluxo_De_Caixa.Dao.postgre
{
    class daoBaixa
    {

        public Baixa Insert(Baixa obj)
        {

            String StringInsert = $" INSERT INTO BAIXAS " +
                                "(ID_EMPRESA, ID_DOC, EMISSAO, VALOR, OBS, USER_INSERT, USER_UPDATE) " +
                                $" VALUES({obj.IdEmpresa}, {obj.Id_Doc}, '{obj.Emissao?.ToString("yyyy-MM-dd")}','{obj.Obs}',{obj.UserInsert},{obj.UserUpdate})  RETURNING ID ";

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

        public void Update(Baixa obj)
        {

            String StringUpdate = $" UPDATE  BAIXAS SET " +
                        $"EMISSAO  		='{obj.Emissao?.ToString("yyyy-MM-dd")}', " +
                        $"VALOR  		= {obj.Valor.DoubleParseDb()} , " +
                        $"OBS  			='{obj.Obs}', " +
                        $"USER_UPDATE =	  {obj.UserUpdate}  " +
                        $"WHERE ID_EMPRESA = {obj.IdEmpresa} and ID = {obj.Id} ";

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

        public void Delete(Baixa obj)
        {

            String StringDelete = $" DELETE FROM  BAIXAS  WHERE ID_EMPRESA = {obj.IdEmpresa} AND ID = {obj.Id} ";

            DataBase.RunCommand.CreateCommand(StringDelete);

        }

        public Baixa Seek(int id_empresa, int id)
        {

            Baixa obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

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
                            "       END  AS  DOC_RAZAO                            " +
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
                            "       END AS _COD_CONTA                           " +
                            "     , CASE                                        " +
                            "        WHEN DOC.TIPO = 'R' THEN CT_CLI.DESCRICAO  " +
                            "        WHEN DOC.TIPO = 'P' THEN CT_FOR.DESCRICAO  " +
                            "        ELSE ''                                    " +
                            "       END AS _CONTA                               " +
                            " FROM BAIXAS BAI                                   " +
                            " INNER JOIN DOCUMENTOS DOC ON DOC.ID_EMPRESA = BAI.ID_EMPRESA AND DOC.ID = BAI.ID_DOC               " +
                            " LEFT JOIN CLIENTES     CLI   ON CLI.ID_EMPRESA = DOC.ID_EMPRESA AND CLI.CODIGO = DOC.CLIFOR        " +
                            " LEFT JOIN FORNECEDORES FORNE ON FORNE.ID_EMPRESA = DOC.ID_EMPRESA AND FORNE.CODIGO = DOC.CLIFOR    " +
                            " LEFT JOIN CONTAS CT_CLI ON CT_CLI.ID_EMPRESA = DOC.ID_EMPRESA    AND CT_CLI.CODIGO = CLI.CONTA     " +
                            " LEFT JOIN CONTAS CT_FOR ON CT_FOR.ID_EMPRESA = DOC.ID_EMPRESA    AND CT_FOR.CODIGO = FORNE.CONTA   ";
            //Adiciona WHERE 
            strSelect += $"WHERE BAI.ID_EMPRESA = {id_empresa} and BAI.ID = {id}";

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

                            obj = new Baixa();

                            obj = PopulaBaixa(objDataReader);


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


        private Baixa PopulaBaixa(NpgsqlDataReader objDataReader)
        {

            var obj = new Baixa();
            obj.IdEmpresa = Convert.ToInt32(objDataReader["ID_EMPRESA"]);
            obj.Id = Convert.ToInt32(objDataReader["ID"]);
            obj.Id_Doc = Convert.ToInt32(objDataReader["ID_DOC"]);
            try
            {
                obj.Emissao = Convert.ToDateTime(objDataReader["EMISSAO"]);
            }
            catch (Exception ex)
            {
                obj.Emissao = null;
            }
            obj.Valor = Convert.ToDouble(objDataReader["VALOR"]);
            obj.Doc_Tipo = objDataReader["DOC_TIPO"].ToString();
            obj.Doc_Doc = objDataReader["DOC_DOC"].ToString();
            obj.Doc_Serie = objDataReader["DOC_SERIE"].ToString();
            obj.Doc_Parcela = objDataReader["DOC_PARCELA"].ToString();
            obj.Doc_Clifor = Convert.ToInt32(objDataReader["DOC_CLIFOR"]);
            obj.Doc_Razao = objDataReader["DOC_RAZAO"].ToString();
            try
            {
                obj.Doc_Emissao = Convert.ToDateTime(objDataReader["DOC_EMISSAO"]);
            }
            catch (Exception ex)
            {
                obj.Doc_Emissao = null;
            }
            try
            {
                obj.Doc_Vencimento = Convert.ToDateTime(objDataReader["DOC_VENCIMENTO"]);
            }
            catch (Exception ex)
            {
                obj.Doc_Vencimento = null;
            }
            obj.Doc_Valor = Convert.ToDouble(objDataReader["DOC_VALOR"]);
            obj.Doc_Abatimento = Convert.ToDouble(objDataReader["DOC_ABATIMENTO"]);
            obj.Doc_Juros = Convert.ToDouble(objDataReader["DOC_JUROS"]);
            obj.Doc_VlrPago = Convert.ToDouble(objDataReader["DOC_VLR_PAGO"]);
            obj.Doc_Saldo = Convert.ToDouble(objDataReader["DOC_SALDO"]);
            obj.Doc_Obs = objDataReader["DOC_OBS"].ToString();
            obj.UserInsert = Convert.ToInt32(objDataReader["USER_INSERT"]);
            obj.UserUpdate = Convert.ToInt32(objDataReader["USER_UPDATE"]);
            obj.Doc_Conta = objDataReader["_Cod_Conta"].ToString();
            obj.Doc_Con_Desc = objDataReader["_Conta"].ToString();


            return obj;
        }


        public List<Baixa> getAll(int Ordenacao, string Filtro)
        {

            Baixa obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            List<Baixa> lista = new List<Baixa>();

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

                                obj = new Baixa();

                                obj = PopulaBaixa(objDataReader);

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
                                     " FROM BAIXAS BAI                                   " +
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
                                " FROM BAIXAS BAI                                   ";
 
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
