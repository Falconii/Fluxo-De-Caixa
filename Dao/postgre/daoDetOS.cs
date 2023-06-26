using Fluxo_De_Caixa.Extensoes;
using Fluxo_De_Caixa.Models;
using Fluxo_De_Caixa.Util;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fluxo_De_Caixa.Dao.postgre
{
    class daoDetOS
    {

        public DetOS Insert(DetOS obj)
        {

            String StringInsert = $" INSERT INTO OS_DET " +
                                 "(ID_EMPRESA,ID_OS,ITEM,QTD,DESCRICAO,VALOR,USER_INSERT,USER_UPDATE ) " +
                                $" VALUES({obj.Id_Empresa},{obj.Id_Os},{obj.Item},{obj.Qtd.DoubleParseDb()},'{obj.Descricao}',{obj.Valor.DoubleParseDb()},{obj.User_Insert},{obj.User_Update})  RETURNING ITEM ";

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

                            obj.Item = Convert.ToInt32(objDataReader["ITEM"]);

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

        public void Update(DetOS obj)
        {

            String StringUpdate =   $" UPDATE  OSCAB SET " +
                                    $"QTD          =  {obj.Qtd.DoubleParseDb()}, " +
                                    $"DESCRICAO    =  '{obj.Descricao}', " +
                                    $"VALOR        =  {obj.Valor.DoubleParseDb()}, " +
                                    $"USER_INSERT  =  {obj.User_Insert}, " +
                                    $"USER_UPDATE  =  {obj.User_Update} " +
                                    $"WHERE ID_EMPRESA = {obj.Id_Empresa} AND ID_OS = {obj.Id_Os}  AND ITEM = {obj.Item}";

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

        public void Delete(DetOS obj)
        {

            String StringDelete = $" DELETE FROM  OS_DET  WHERE ID_EMPRESA = {obj.Id_Empresa} AND ID_OS = {obj.Id_Os}  AND ITEM = {obj.Item}";

            DataBase.RunCommand.CreateCommand(StringDelete);

        }

        public void DeleteByOS(int id_empresa,int id_os)
        {

            String StringDelete = $" DELETE FROM  OS_DET  WHERE ID_EMPRESA = {id_empresa} AND ID_OS = {id_os} ";

            DataBase.RunCommand.CreateCommand(StringDelete);

        }

        public DetOS Seek(int id_empresa, int id_os, int item)
        {

            DetOS obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect =  "SELECT   DET.ID_EMPRESA		" +
                                "        ,DET.ID_OS             " +
                                "        ,DET.ITEM              " +
                                "        ,DET.QTD               " +
                                "        ,DET.DESCRICAO         " +
                                "        ,DET.VALOR             " +
                                "        ,DET.USER_INSERT       " +
                                "        ,DET.USER_UPDATE       " +
                                "FROM OS_DET DET                ";

            //Adiciona WHERE 
            strSelect += $"WHERE ID_EMPRESA = { id_empresa } AND ID_OS = { id_os }  AND ITEM = {item }";

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

                            obj = new DetOS();

                            obj = PopulaDetOS(objDataReader);


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


        private DetOS PopulaDetOS(NpgsqlDataReader objDataReader)
        {

            var obj = new DetOS();

            obj.Id_Empresa = Convert.ToInt32(objDataReader["Id_Empresa"]);
            obj.Id_Os = Convert.ToInt32(objDataReader["Id_Os"]);
            obj.Item = Convert.ToInt32(objDataReader["Item"]);
            obj.Qtd = Convert.ToDouble(objDataReader["Qtd"]);
            obj.Descricao = objDataReader["Descricao"].ToString();
            obj.Valor = Convert.ToDouble(objDataReader["Valor"]);
            obj.User_Insert = Convert.ToInt32(objDataReader["User_Insert"]);
            obj.User_Update = Convert.ToInt32(objDataReader["User_Update"]);

            return obj;
        }


        public List<DetOS> getAll(int Ordenacao, string Filtro)
        {

            DetOS obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            List<DetOS> lista = new List<DetOS>();

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

                                obj = new DetOS();

                                obj = PopulaDetOS(objDataReader);

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
             
            string strSelect =  " SELECT DET.ID_EMPRESA       " +
                                "        ,DET.ID_OS             " +
                                "        ,DET.ITEM              " +
                                "        ,DET.QTD               " +
                                "        ,DET.DESCRICAO         " +
                                "        ,DET.VALOR             " +
                                "        ,DET.USER_INSERT       " +
                                "        ,DET.USER_UPDATE       " +
                                " FROM OS_DET DET                ";

            //Adiciona WHERE 
            if (Filtro.Trim() != "")
            {


                switch (Ordenacao)
                {
                    case 0:
                        Where = $"WHERE DET.ID_EMPRESA = 1 AND _DET.ID_OS = {Filtro}";
                        break;
                }


            }

            //Adiciona ORDER BY


            switch (Ordenacao)
            {
                case 0:
                    OrderBy = $"ORDER BY DET.ID_OS,DET.ITEM";
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
                                " FROM FROM OS_DET DET                                  ";

            //Adiciona WHERE 
            if (Filtro.Trim() != "")
            {


                switch (Ordenacao)
                {
                    case 0:
                        Where = $"WHERE DET.ID_EMPRESA = 1 AND _DET.ID_OS = {Filtro}";
                        break;
                }


            }

            //Adiciona ORDER BY


            switch (Ordenacao)
            {
                case 0:
                    OrderBy = $"ORDER BY DET.ID_OS,DET.ITEM";
                    break;
            }


            strSelect += $" {Where} {OrderBy} ";

            return strSelect;

        }

    }
}
