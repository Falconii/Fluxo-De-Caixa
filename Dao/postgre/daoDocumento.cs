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
            obj._Conta      = objDataReader["_Conta"].ToString();


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
                                 "         else                                              '' "+ 
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
                                 "LEFT  JOIN clientes     cli on cli.id_empresa = doc.id_empresa    and cli.codigo = doc.clifor "+
                                 "LEFT  JOIN fornecedores forne  on forne.id_empresa = doc.id_empresa    and forne.codigo = doc.clifor "+
                                 "LEFT  JOIN contas ct_cli on ct_cli.id_empresa = doc.id_empresa    and ct_cli.codigo = cli.conta  " +
                                 "LEFT  JOIN contas ct_for on ct_for.id_empresa = doc.id_empresa    and ct_for.codigo = forne.conta ";




            //Adiciona WHERE 
            if (Filtro.Trim() != "")
            {

                switch (Ordenacao)
                {
                    case 0:
                        Where = $" DOC.DOC        = '{Filtro.Trim()}'";
                        break;
                    case 1:
                        Where = $" DOC.EMISSAO    = '{Filtro.Trim().DateToDb()}'";
                        break;
                    case 2:
                        Where = $" DOC.VENCIMENTO = '{Filtro.Trim().DateToDb()}'";
                        break;
                }
                             

            }

            if (FiltroCliFor != "" || Where != "")
            {
                string And = Where != "" ? "AND" : "";

                Where = $" WHERE {FiltroCliFor} {And} {Where}";
            }

            //Adiciona ORDER BY

            switch (Ordenacao)
            {
                case 0:
                    OrderBy = $" ORDER BY DOC.DOC";
                    break;
                case 1:
                    OrderBy = $" ORDER BY DOC.EMISSAO";
                    break;
                case 2:
                    OrderBy = $" ORDER BY DOC.VENCIMENTO";
                    break;
            }

            strSelect += $" {Where} {OrderBy} ";

            return strSelect;

        }

    }
}
