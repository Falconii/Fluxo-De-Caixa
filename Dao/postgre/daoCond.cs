using Fluxo_De_Caixa.Extensoes;
using Fluxo_De_Caixa.Models;
using Fluxo_De_Caixa.Util;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fluxo_De_Caixa.Dao.postgre
{
    class daoCond   
    {

        public Cond Insert(Cond obj)
        {

            String StringInsert = $" INSERT INTO COND " +
                                "(ID_EMPRESA, ID, DESCRICAO, NRO_PARCELAS, INTER1, INTER2, USER_INSERT, USER_UPDATE) " +
                                $" VALUES({obj.Id_Empresa},{obj.Id},'{obj.Descricao}',{obj.Nro_Parcelas},'{obj.Inter1}','{obj.Inter2}',{obj.User_Insert},{obj.User_Update})  RETURNING * ";

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

                            obj.Id = Convert.ToInt32(objDataReader["ID"].ToString());

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

        public void Update(Cond obj)
        {

            String StringUpdate = $" UPDATE  COND " +
                         $"ID_EMPRESA      =  {obj.Id_Empresa} " +
                         $"ID              =  {obj.Id} " +
                         $"DESCRICAO       =  {obj.Descricao} " +
                         $"NRO_PARCELAS    =  {obj.Nro_Parcelas} " +
                         $"INTER1          =  {obj.Inter1} " +
                         $"INTER2          =  {obj.Inter2} " +
                         $"USER_INSERT     =  {obj.User_Insert} " +
                         $"USER_UPDATE     =  {obj.User_Update} ";

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

        public void Delete(Cond obj)
        {

            String StringDelete = $" DELETE FROM  COND  WHERE ID_EMPRESA = {obj.Id_Empresa} AND ID = {obj.Id} ";

            DataBase.RunCommand.CreateCommand(StringDelete);

        }
           
        public Cond Seek(int id_empresa, int id)
        {

            Cond obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect =  " SELECT   CAB.ID_EMPRESA		" +
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
                                "FROM OS_CAR CAB " +
                                "INNER JOIN CLIENTES  CLI  ON CLI.ID_EMPRESA  = CAB.ID_EMPRESA  AND CLI.CODIGO  = CAB.ID_CLIENTE  " +
                                "INNER JOIN OS_CAR    CAR  ON CAR.ID_EMPRESA  = CAB.ID_EMPRESA  AND CAR.PLACA   = CAB.ID_CARRO    " +
                                "LEFT  JOIN CONDICOES COND ON COND.ID_EMPRESA = CAB.ID_EMPRESA  AND COND.ID     = CAB.ID_COND     ";


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

                            obj = new Cond();

                            obj = PopulaCond(objDataReader);


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

        private Cond PopulaCond(NpgsqlDataReader objDataReader)
        {

            var obj = new Cond();

            obj.Id_Empresa = Convert.ToInt32(objDataReader["Id_Empresa"]);
            obj.Id = Convert.ToInt32(objDataReader["Id"]);
            obj.Descricao = objDataReader["Descricao"].ToString();
            obj.Nro_Parcelas = Convert.ToInt32(objDataReader["Id_Empresa"]);
            obj.Inter1 = objDataReader["Inter1"].ToString();
            obj.Inter2 = objDataReader["Inter2"].ToString();
            obj.User_Insert = Convert.ToInt32(objDataReader["User_Insert"]);
            obj.User_Update = Convert.ToInt32(objDataReader["User_Update"]);


            return obj;
        }

        public List<Cond> getAll(int Ordenacao, string Filtro)
        {

            Cond obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            List<Cond> lista = new List<Cond>();

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

                                obj = new Cond();

                                obj = PopulaCond(objDataReader);

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

            string strSelect = $"SELECT COND.ID_EMPRESA  " +
                               $"     , COND.PLACA " +
                               $"     , COND.MARCA " +
                               $"     , COND.COR " +
                               $"     , COND.ANO " +
                               $"     , COND.USER_INSERT " +
                               $"     , COND.USER_UPDATE " +
                               $"FROM CONDICOES COND ";

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

            string strSelect =  $"SELECT COND.ID_EMPRESA  " +
                                $"     , COND.PLACA " +
                                $"     , COND.MARCA " +
                                $"     , COND.COR " +
                                $"     , COND.ANO " +
                                $"     , COND.USER_INSERT " +
                                $"     , COND.USER_UPDATE " +
                                $"FROM CONDICOES COND ";
            //Adiciona WHERE 
            if (Filtro.Trim() != "")
            {
                switch (Ordenacao)
                {
                    case 0:
                        Where = $"WHERE COND.ID_EMPRESA = 1 AND COND.ID = {Filtro.Trim()}";
                        break;
                    case 1:
                        Where = $"WHERE COND.ID_EMPRESA = 1 AND TRIM(COND.DESCRICAO) = '{Filtro.Trim()}'";
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
