using Fluxo_De_Caixa.Extensoes;
using Fluxo_De_Caixa.Models;
using Fluxo_De_Caixa.Util;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fluxo_De_Caixa.Dao.postgre
{
    class daoDocumento
    {
        public Documento Insert(Documento obj)
        {

            String StringInsert = $" INSERT INTO DOCUMENTOS " +
                                "(ID_EMPRESA, TIPO, DOC, SERIE, PARCELA, CLIFOR, RAZAO, EMISSAO, VENCIMENTO, VALOR, ABATIMENTO, JUROS, VLR_PAGO, SALDO, OBS, USER_INSERT, USER_UPDATE) " +
                                $" VALUES({obj.IdEmpresa}, '{obj.Tipo}','{obj.Doc}','{obj.Serie}','{obj.Parcela}',{obj.Clifor},'{obj.Razao}','{obj.Emissao?.ToString("yyyy-MM-dd")}','{obj.Vencimento?.ToString("yyyy-MM-dd")}',{obj.Valor.DoubleParseDb()},{obj.Abatimento.DoubleParseDb()},{obj.Juros.DoubleParseDb()},{obj.VlrPago.DoubleParseDb()},{obj.Saldo.DoubleParseDb()},'{obj.Obs}',{obj.UserInsert},{obj.UserUpdate})  RETURNING ID ";

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

        public void Update(Documento obj)
        {

            String StringUpdate = $" UPDATE  DOCUMENTOS SET " +
                        $"TIPO  	    ='{obj.Tipo}', " +
                        $"DOC  			='{obj.Doc}', " +
                        $"SERIE 		='{obj.Serie}', " +
                        $"PARCELA  		='{obj.Parcela}', " +
                        $"CLIFOR  		= {obj.Clifor} , " +
                        $"RAZAO  		='{obj.Razao}', " +
                        $"EMISSAO  		='{obj.Emissao?.ToString("yyyy-MM-dd")}', " +
                        $"VENCIMENTO    = '{obj.Vencimento?.ToString("yyyy-MM-dd")}', " +
                        $"VALOR  		= {obj.Valor.DoubleParseDb()} , " +
                        $"ABATIMENTO    = {obj.Abatimento.DoubleParseDb()} , " +
                        $"JUROS  		= {obj.Juros.DoubleParseDb()} , " +
                        $"VLR_PAGO 		= {obj.VlrPago.DoubleParseDb()} , " +
                        $"SALDO  		= {obj.Saldo.DoubleParseDb()} , " +
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

        public void Delete(Documento obj)
        {

            if (obj.Saldo == 0)
            {
                daoBaixa dao = new daoBaixa();

                dao.DeleteByDoc(obj.IdEmpresa, obj.Id);

            }

            String StringDelete = $" DELETE FROM  DOCUMENTOS  WHERE ID_EMPRESA = {obj.IdEmpresa} AND ID = {obj.Id} ";

            DataBase.RunCommand.CreateCommand(StringDelete);

        }

        public Documento Seek(int id_empresa, int id)
        {

            Documento obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = " SELECT 				" +
                              "      doc.id_empresa   " +
                              "   ,  doc.id           " +
                              "   ,  doc.tipo         " +
                              "   ,  doc.doc          " +
                              "   ,  doc.serie        " +
                              "   ,  doc.parcela      " +
                              "   ,  doc.clifor       " +
                              "   ,  case             " +
                              "         when doc.tipo = 'R'  then cli.razao " +
                              "         when doc.tipo = 'P'  then forne.razao " +
                              "      end  as  razao   " +
                              "   ,  doc.emissao      " +
                              "   ,  doc.vencimento   " +
                              "   ,  doc.valor        " +
                              "   ,  doc.abatimento   " +
                              "   ,  doc.juros        " +
                              "   ,  doc.vlr_pago     " +
                              "   ,  doc.saldo        " +
                              "   ,  doc.obs          " +
                              "   ,  doc.user_insert  " +
                              "   ,  doc.user_update  " +
                              "   ,  case " +
                               "         when doc.tipo = 'R' then ct_cli.codigo " +
                               "         when doc.tipo = 'P' then ct_for.codigo " +
                               "         else '' " +
                               "      end as _Cod_Conta " +
                               "   ,  case " +
                               "         when doc.tipo = 'R' then ct_cli.descricao " +
                               "         when doc.tipo = 'P' then ct_for.descricao " +
                               "         else '' " +
                               "      end as _Conta " +
                              " 	FROM documentos doc " +
                              "    LEFT JOIN clientes     cli   on cli.id_empresa = doc.id_empresa and cli.codigo = doc.clifor " +
                              "    LEFT JOIN fornecedores forne on forne.id_empresa = doc.id_empresa and forne.codigo = doc.clifor " +
                              "    LEFT  JOIN contas ct_cli on ct_cli.id_empresa = doc.id_empresa    and ct_cli.codigo = cli.conta  " +
                              "    LEFT  JOIN contas ct_for on ct_for.id_empresa = doc.id_empresa    and ct_for.codigo = forne.conta ";
            //Adiciona WHERE 
            strSelect += $"WHERE DOC.ID_EMPRESA = {id_empresa} and DOC.ID = {id}";

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

                            obj = new Documento();

                            obj = PopulaDocumento(objDataReader);


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

        public int ExisteByCliente(int id_empresa, int id)
        {
            int retorno = 0;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = " SELECT COALESCE(count(*), 0) AS TOTAL " +
                               " FROM DOCUMENTOS " +
                              $" WHERE ID_EMPRESA = {id_empresa} AND TIPO = 'R' AND CLIFOR = {id} ";


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

                                retorno  =  Convert.ToInt32(objDataReader["TOTAL"]);

                            }
                        }

                    }
                    catch (Exception _)
                    {
                        retorno = 0;
                    }
                    finally
                    {
                        objConexao.Close();
                    }
                }
            }


            return retorno;

        }

        public int ExisteByFornecedor(int id_empresa, int id)
        {
            int retorno = 0;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = " SELECT COALESCE(count(*), 0) AS TOTAL " +
                               " FROM DOCUMENTOS " +
                              $" WHERE ID_EMPRESA = {id_empresa} AND TIPO = 'P' AND CLIFOR = {id} ";


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

                                retorno = Convert.ToInt32(objDataReader["TOTAL"]);

                            }
                        }

                    }
                    catch (Exception _)
                    {
                        retorno = 0;
                    }
                    finally
                    {
                        objConexao.Close();
                    }
                }
            }


            return retorno;

        }

        private Documento PopulaDocumento(NpgsqlDataReader objDataReader)
        {

            var obj = new Documento();
            obj.IdEmpresa = Convert.ToInt32(objDataReader["ID_EMPRESA"]);
            obj.Id = Convert.ToInt32(objDataReader["ID"]);
            obj.Tipo = objDataReader["TIPO"].ToString();
            obj.Doc = objDataReader["DOC"].ToString();
            obj.Serie = objDataReader["SERIE"].ToString();
            obj.Parcela = objDataReader["PARCELA"].ToString();
            obj.Clifor = Convert.ToInt32(objDataReader["CLIFOR"]);
            obj.Razao = objDataReader["RAZAO"].ToString();
            try
            {
                obj.Emissao = Convert.ToDateTime(objDataReader["EMISSAO"]);
            }
            catch (Exception ex)
            {
                obj.Emissao = null;
            }
            try
            {
                obj.Vencimento = Convert.ToDateTime(objDataReader["VENCIMENTO"]);
            }
            catch (Exception ex)
            {
                obj.Vencimento = null;
            }
            obj.Valor = Convert.ToDouble(objDataReader["VALOR"]);
            obj.Abatimento = Convert.ToDouble(objDataReader["ABATIMENTO"]);
            obj.Juros = Convert.ToDouble(objDataReader["JUROS"]);
            obj.VlrPago = Convert.ToDouble(objDataReader["VLR_PAGO"]);
            obj.Saldo = Convert.ToDouble(objDataReader["SALDO"]);
            obj.Obs = objDataReader["OBS"].ToString();
            obj.UserInsert = Convert.ToInt32(objDataReader["USER_INSERT"]);
            obj.UserUpdate = Convert.ToInt32(objDataReader["USER_UPDATE"]);
            obj._Cod_Conta = objDataReader["_Cod_Conta"].ToString();
            obj._Conta = objDataReader["_Conta"].ToString();


            return obj;
        }

        public List<Documento> getAll(int Ordenacao, string Filtro)
        {

            Documento obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            List<Documento> lista = new List<Documento>();

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

                                obj = new Documento();

                                obj = PopulaDocumento(objDataReader);

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

            string strSelect = " SELECT 				" +
                                "      doc.id_empresa   " +
                                "   ,  doc.id           " +
                                "   ,  doc.tipo         " +
                                "   ,  doc.doc          " +
                                "   ,  doc.serie        " +
                                "   ,  doc.parcela      " +
                                "   ,  doc.clifor       " +
                                "   ,  case             " +
                                "         when doc.tipo = 'R' and doc.clifor != 999999 then cli.razao " +
                                "         when doc.tipo = 'P' and doc.clifor != 999999 then forne.razao " +
                                "      end  as  razao   " +
                                "   ,  doc.emissao      " +
                                "   ,  doc.vencimento   " +
                                "   ,  doc.valor        " +
                                "   ,  doc.abatimento   " +
                                "   ,  doc.juros        " +
                                "   ,  doc.vlr_pago     " +
                                "   ,  doc.saldo        " +
                                "   ,  doc.obs          " +
                                "   ,  doc.user_insert  " +
                                "   ,  doc.user_update  " +
                                "   ,  case " +
                                 "         when doc.tipo = 'R' then ct_cli.codigo " +
                                 "         when doc.tipo = 'P' then ct_for.codigo " +
                                 "         else '' " +
                                 "      end as _Cod_Conta " +
                                 "   ,  case " +
                                 "         when doc.tipo = 'R' then ct_cli.descricao " +
                                 "         when doc.tipo = 'P' then ct_for.descricao " +
                                 "         else '' " +
                                 "      end as _Conta " +
                                " 	FROM documentos doc " +
                                 " 	FROM documentos doc " +
                                 "LEFT  JOIN clientes     cli on cli.id_empresa = doc.id_empresa    and cli.codigo = doc.clifor " +
                                 "LEFT  JOIN fornecedores forne  on forne.id_empresa = doc.id_empresa    and forne.codigo = doc.clifor " +
                                 "LEFT  JOIN contas ct_cli on ct_cli.id_empresa = doc.id_empresa    and ct_cli.codigo = cli.conta  " +
                                 "LEFT  JOIN contas ct_for on ct_for.id_empresa = doc.id_empresa    and ct_for.codigo = forne.conta ";
            //Adiciona WHERE 
            if (Filtro.Trim() != "")
            {


                switch (Ordenacao)
                {
                    case 0:
                        Where = $"WHERE DOC.ID = {Filtro}";
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
                    OrderBy = $"ORDER BY DOC.ID";
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

        public string SqlGridBrowse(int Ordenacao, string Filtro, string Filtro_Clifor)
        {

            DateTime Hoje = DateTime.Now;

            string CliFor = "";

            string FiltroCliFor = "";

            if (Filtro_Clifor.Trim() != "")
            {
                CliFor = Filtro_Clifor.Substring(3, 6);

                FiltroCliFor = $" DOC.CLIFOR = {CliFor} ";

            }


            string Where = "";

            string OrderBy = "";

            string strSelect = " SELECT 				" +
                                 "      doc.id           " +
                                 "   ,  doc.tipo         " +
                                 "   ,  doc.doc          " +
                                 "   ,  doc.serie        " +
                                 "   ,  doc.parcela      " +
                                 "   ,  doc.clifor       " +
                                 "   ,  case             " +
                                 "         when doc.tipo = 'R' and doc.clifor != 999999 then cli.razao " +
                                 "         when doc.tipo = 'P' and doc.clifor != 999999 then forne.razao " +
                                 "         else                                              '' " +
                                 "      end  as  razao   " +
                                 "   ,  case " +
                                 "         when doc.tipo = 'R' then ct_cli.codigo " +
                                 "         when doc.tipo = 'P' then ct_for.codigo " +
                                 "         else '' " +
                                 "      end as _Cod_Conta " +
                                 "   ,  case " +
                                 "         when doc.tipo = 'R' then ct_cli.descricao " +
                                 "         when doc.tipo = 'P' then ct_for.descricao " +
                                 "         else '' " +
                                 "      end as _Conta " +
                                 "   ,  doc.emissao      " +
                                 "   ,  doc.vencimento   " +
                                 "   ,  doc.valor        " +
                                 "   ,  doc.abatimento   " +
                                 "   ,  doc.juros        " +
                                 "   ,  doc.vlr_pago     " +
                                 "   ,  doc.saldo        " +
                                 "   ,  doc.obs          " +
                                 " 	FROM documentos doc " +
                                 "LEFT  JOIN clientes     cli on cli.id_empresa = doc.id_empresa    and cli.codigo = doc.clifor " +
                                 "LEFT  JOIN fornecedores forne  on forne.id_empresa = doc.id_empresa    and forne.codigo = doc.clifor " +
                                 "LEFT  JOIN contas ct_cli on ct_cli.id_empresa = doc.id_empresa    and ct_cli.codigo = cli.conta  " +
                                 "LEFT  JOIN contas ct_for on ct_for.id_empresa = doc.id_empresa    and ct_for.codigo = forne.conta ";




            //Adiciona WHERE 
            if (Filtro.Trim() != "")
            {

                switch (Ordenacao)
                {
                    case 0:
                        Where = $" DOC.DOC        LIKE '%{Filtro.Trim()}%'";
                        break;
                    case 1:
                        Where = $" DOC.EMISSAO    = '{Filtro.Trim().DateToDb()}'";
                        break;
                    case 2:
                        Where = $" DOC.VENCIMENTO = '{Filtro.Trim().DateToDb()}'";
                        break;
                    case 3:
                        Where = $" ( TO_CHAR(DOC.VENCIMENTO, 'mm-YYYY') = '{Hoje.ToString("MM-yyyy")}' ) ";
                        break;
                    case 4:
                        Where = $" (  TO_CHAR(DOC.EMISSAO, 'mm-YYYY') = '{Hoje.ToString("MM-yyyy")}' ) ";
                        break;
                }


            }

            if (FiltroCliFor != "" || Where != "")
            {

                Where = $" WHERE {FiltroCliFor} { (((Where != "") && (FiltroCliFor != "")) ? "AND" : "")} {Where}";
            }

            //Adiciona ORDER BY

            switch (Ordenacao)
            {
                case 0:
                    OrderBy = $" ORDER BY DOC.DOC,DOC.SERIE,DOC.PARCELA ";
                    break;
                case 1:
                    OrderBy = $" ORDER BY DOC.EMISSAO,DOC.DOC,DOC.SERIE,DOC.PARCELA ";
                    break;
                case 2:
                    OrderBy = $" ORDER BY DOC.VENCIMENTO,DOC.DOC,DOC.SERIE,DOC.PARCELA ";
                    break;
                case 3:
                    OrderBy = $" ORDER BY DOC.VENCIMENTO,DOC.DOC,DOC.SERIE,DOC.PARCELA ";
                    break;
                case 4:
                    OrderBy = $" ORDER BY DOC.EMISSAO,DOC.DOC,DOC.SERIE,DOC.PARCELA ";
                    break;
            }

            strSelect += $" {Where} {OrderBy} ";

            return strSelect;

        }

        public List<string> MesesAtivos()
        {
            List<string> retorno = new List<string>();

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = " SELECT TO_CHAR(VENCIMENTO, 'mm/YYYY') AS MESES  FROM DOCUMENTOS  " +
                               " WHERE ID_EMPRESA = 1 GROUP BY ID_EMPRESA , TO_CHAR(VENCIMENTO, 'mm/YYYY') " +
                               " ORDER BY ID_EMPRESA, TO_CHAR(VENCIMENTO, 'mm/YYYY') ";

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

                                retorno.Add(objDataReader["MESES"].ToString());

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


            return retorno;
        }

        public List<Fluxo> GetFluxo(string mes)
        {
            List<Fluxo> retorno = new List<Fluxo>();

            double Saldo = 0;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = " SELECT                               " +
            "        DOC.VENCIMENTO AS DOC_VENCIMENT                  " +
            "      , DOC.DOC AS DOC_DOC                               " +
            "      , DOC.SERIE AS DOC_SERIE                           " +
            "      , DOC.PARCELA AS DOC_PARCELA                       " +
            "      , DOC.EMISSAO AS DOC_EMISSAO                       " +
            "      , DOC.CLIFOR AS DOC_CLIFOR                         " +
            "      , CASE                                             " +
            "         WHEN DOC.TIPO = 'R'  THEN CLI.RAZAO             " +
            "         WHEN DOC.TIPO = 'P'  THEN FORNE.RAZAO           " +
            "        END  AS DOC_RAZAO                                " +
            "      , CASE                                             " +
            "         WHEN DOC.TIPO = 'R' THEN CT_CLI.DESCRICAO       " +
            "         WHEN DOC.TIPO = 'P' THEN CT_FOR.DESCRICAO       " +
            "         ELSE ''                                         " +
            "        END AS _CONTA                                    " +
            "      , DOC.OBS AS DOC_OBS                               " +
            "      , CASE                                             " +
            "         WHEN DOC.TIPO = 'R'  THEN  0                    " +
            "         WHEN DOC.TIPO = 'P'  THEN (DOC.VALOR-DOC.ABATIMENTO)+DOC.JUROS   " +
            "       END  AS DEBITO                                    " +
            "     , CASE                                              " +
            "         WHEN DOC.TIPO = 'R'  THEN (DOC.VALOR-DOC.ABATIMENTO)+DOC.JUROS  " +
            "        WHEN DOC.TIPO = 'P'   THEN  0                     " +
            "        END AS  CREDITO                                  " +
            "       , 0 AS SALDO                                      " +
            "  FROM DOCUMENTOS DOC                                    " +
            "  LEFT JOIN CLIENTES     CLI ON CLI.ID_EMPRESA = DOC.ID_EMPRESA AND CLI.CODIGO = DOC.CLIFOR  " +
            "  LEFT JOIN FORNECEDORES FORNE ON FORNE.ID_EMPRESA = DOC.ID_EMPRESA AND FORNE.CODIGO = DOC.CLIFOR  " +
            "  LEFT JOIN CONTAS CT_CLI ON CT_CLI.ID_EMPRESA = DOC.ID_EMPRESA    AND CT_CLI.CODIGO = CLI.CONTA   " +
            "  LEFT JOIN CONTAS CT_FOR ON CT_FOR.ID_EMPRESA = DOC.ID_EMPRESA    AND CT_FOR.CODIGO = FORNE.CONTA " +
           $"  WHERE TO_CHAR(DOC.VENCIMENTO,'mm/YYYY') = '{mes}' "+
            "  ORDER BY DOC.VENCIMENTO,DOC.DOC,DOC.SERIE,DOC.PARCELA ";

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
                            var sld = new Fluxo();

                            sld.doc_razao = "SALDO INICIAL:";

                            sld.saldo = 0;

                            retorno.Add(sld);

                            Saldo = 0;

                            while (objDataReader.Read())
                            {
                                var obj = new Fluxo();

                                obj = PopulaFluxo(objDataReader);

                                Saldo = Saldo + (obj.credito - obj.debito);

                                obj.saldo = Saldo;

                                retorno.Add(obj);
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


            return retorno;
        }

        private Fluxo PopulaFluxo(NpgsqlDataReader objDataReader)
        {
            Fluxo obj = new Fluxo();

            try
            {
                obj.doc_venciment = Convert.ToDateTime(objDataReader["DOC_VENCIMENT"]);
            }
            catch (Exception ex)
            {
                obj.doc_venciment = null;
            }

            obj.doc_doc = objDataReader["DOC_DOC"].ToString();
            obj.doc_serie = objDataReader["DOC_SERIE"].ToString();
            obj.doc_parcela = objDataReader["DOC_PARCELA"].ToString();
            try
            {
                obj.doc_emissao = Convert.ToDateTime(objDataReader["DOC_VENCIMENT"]);
            }
            catch (Exception ex)
            {
                obj.doc_emissao = null;
            }

            obj.doc_clifor = Convert.ToInt32(objDataReader["DOC_CLIFOR"]);
            obj.doc_razao = objDataReader["doc_razao"].ToString();
            obj._conta = objDataReader["_CONTA"].ToString();
            obj.debito = Convert.ToDouble(objDataReader["DEBITO"]);
            obj.credito = Convert.ToDouble(objDataReader["CREDITO"]);
            obj.saldo = 0;


            return obj;
        }

        public List<RegPag> GetRegPag(Parametro_01 par)
        {
            List<RegPag> retorno = new List<RegPag>();

            DateTime Hoje = DateTime.Now;

            string Where = "";

            if (par.Tipo == "R")
            {
                if (Where != "") Where += " AND ";
                Where += " DOC.TIPO = 'R'";

            }
            else
            {
                if (Where != "") Where += " AND ";
                Where += " DOC.TIPO = 'P'";
            }

            Where += $" AND ( DOC.VENCIMENTO >= '{par.Inicial.ToString("yyyy-MM-dd")}' AND DOC.VENCIMENTO <= '{par.Final.ToString("yyyy-MM-dd")}' ) ";

            if (par.ClirFor != 0)
            {
                if (Where != "") Where += " AND ";
                Where += $" DOC.CLIFOR = {par.ClirFor} ";

            }

            if (par.Situacao > 0)
            {
                //Em aberto
                if (par.Situacao == 1)
                {
                    Where += " AND ( DOC.SALDO > 0 )";
                }
                //Em atraso
                if (par.Situacao == 2)
                {
                    Where += $" AND ( DOC.SALDO > 0 ) AND ( DOC.VENCIMENTO > '{Hoje.ToString("yyyy-MM-dd")}')";
                }
                //Encerrado
                if (par.Situacao == 3)
                {
                    Where += " AND ( DOC.SALDO = 0 )";
                }
            }


            Where = $"WHERE {Where}";

            double Total = 0;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = " SELECT                               " +
            "        DOC.VENCIMENTO AS DOC_VENCIMENT                  " +
            "      , DOC.DOC AS DOC_DOC                               " +
            "      , DOC.SERIE AS DOC_SERIE                           " +
            "      , DOC.PARCELA AS DOC_PARCELA                       " +
            "      , DOC.EMISSAO AS DOC_EMISSAO                       " +
            "      , DOC.CLIFOR AS DOC_CLIFOR                         " +
            "      , CASE                                             " +
            "         WHEN DOC.TIPO = 'R'  THEN CLI.RAZAO             " +
            "         WHEN DOC.TIPO = 'P'  THEN FORNE.RAZAO           " +
            "        END  AS DOC_RAZAO                                " +
            "      , CASE                                             " +
            "         WHEN DOC.TIPO = 'R' THEN CT_CLI.DESCRICAO       " +
            "         WHEN DOC.TIPO = 'P' THEN CT_FOR.DESCRICAO       " +
            "         ELSE ''                                         " +
            "        END AS _CONTA                                    " +
            "      , DOC.OBS AS DOC_OBS                               " +
            "      , DOC.VALOR       AS DOC_VALOR                     " +
            "      , DOC.ABATIMENTO  AS DOC_ABATIMENTO                " +
            "      , DOC.JUROS       AS DOC_JUROS                     " +
            "      , DOC.SALDO       AS DOC_SALDO                     " +
            "      , 0               AS TOTAL                         " +
            "  FROM DOCUMENTOS DOC                                    " +
            "  LEFT JOIN CLIENTES     CLI ON CLI.ID_EMPRESA = DOC.ID_EMPRESA AND CLI.CODIGO = DOC.CLIFOR  " +
            "  LEFT JOIN FORNECEDORES FORNE ON FORNE.ID_EMPRESA = DOC.ID_EMPRESA AND FORNE.CODIGO = DOC.CLIFOR  " +
            "  LEFT JOIN CONTAS CT_CLI ON CT_CLI.ID_EMPRESA = DOC.ID_EMPRESA    AND CT_CLI.CODIGO = CLI.CONTA   " +
            "  LEFT JOIN CONTAS CT_FOR ON CT_FOR.ID_EMPRESA = DOC.ID_EMPRESA    AND CT_FOR.CODIGO = FORNE.CONTA " +
            $" {Where} " +
            "  ORDER BY DOC.VENCIMENTO,DOC.DOC,DOC.SERIE,DOC.PARCELA ";

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
                            var sld = new RegPag();

                            sld.doc_razao = "SALDO INICIAL:";

                            sld.total = 0;

                            retorno.Add(sld);

                            Total = 0;

                            while (objDataReader.Read())
                            {
                                var obj = new RegPag();

                                obj = PopulaRegPag(objDataReader);

                                Total = Total + obj.doc_saldo;

                                obj.total = Total;

                                retorno.Add(obj);
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


            return retorno;
        }

        private RegPag PopulaRegPag(NpgsqlDataReader objDataReader)
        {
            RegPag obj = new RegPag();

            try
            {
                obj.doc_venciment = Convert.ToDateTime(objDataReader["DOC_VENCIMENT"]);
            }
            catch (Exception ex)
            {
                obj.doc_venciment = null;
            }

            obj.doc_doc = objDataReader["DOC_DOC"].ToString();
            obj.doc_serie = objDataReader["DOC_SERIE"].ToString();
            obj.doc_parcela = objDataReader["DOC_PARCELA"].ToString();
            try
            {
                obj.doc_emissao = Convert.ToDateTime(objDataReader["DOC_VENCIMENT"]);
            }
            catch (Exception ex)
            {
                obj.doc_emissao = null;
            }

            obj.doc_clifor = Convert.ToInt32(objDataReader["DOC_CLIFOR"]);
            obj.doc_razao = objDataReader["doc_razao"].ToString();
            obj._conta = objDataReader["_CONTA"].ToString();
            obj.doc_obs = objDataReader["DOC_OBS"].ToString();
            obj.doc_valor = Convert.ToDouble(objDataReader["DOC_VALOR"]);
            obj.doc_abatimento = Convert.ToDouble(objDataReader["DOC_ABATIMENTO"]);
            obj.doc_saldo = Convert.ToDouble(objDataReader["DOC_SALDO"]);
            obj.total = 0;


            return obj;
        }

    }
}
