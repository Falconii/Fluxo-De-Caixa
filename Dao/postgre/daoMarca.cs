using Fluxo_De_Caixa.Extensoes;
using Fluxo_De_Caixa.Models;
using Fluxo_De_Caixa.Util;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fluxo_De_Caixa.Dao.postgre
{
    class daoMarca
    {
        /*
        public CarOS Insert(CarOS obj)
        {

            String StringInsert = $" INSERT INTO OS_CAR " +
                                "(ID_EMPRESA, PLACA, ID_MARCA, MODELO, COR, ANO, USER_INSERT, USER_UPDATE) " +
                                $" VALUES({obj.Id_Empresa},'{obj.Placa}',{obj.Id_Marca},'{obj.Modelo}', {obj.Cor}','{obj.Ano}',{obj.User_Insert},{obj.User_Update})  RETURNING * ";

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

                            obj.Placa = objDataReader["PLACA"].ToString();

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

        public void Update(CarOS obj)
        {

            String StringUpdate = $" UPDATE  OS_CAR " +
                        $"ID_EMPRESA 		= {obj.Id_Empresa} " +
                        $"PLACA 			= '{obj.Placa}', " +
                        $"ID_MARCA 			= '{obj.Id_Marca}', " +
                        $"MODELO 			= '{obj.Modelo}', " +
                        $"COR 				= '{obj.Cor}', " +
                        $"ANO 				= '{obj.Ano}', " +
                        $"USER_INSERT 		= {obj.User_Insert} " +
                        $"USER_UPDATE  		= {obj.User_Update} ";

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

        public void Delete(CarOS obj)
        {

            String StringDelete = $" DELETE FROM  OSCAB  WHERE ID_EMPRESA = {obj.Id_Empresa} AND PLACA = {obj.Placa} ";

            DataBase.RunCommand.CreateCommand(StringDelete);

        }
        
        public CarOS Seek(int id_empresa, string placa)
        {

            Marca obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect =  " SELECT   CAR.ID_EMPRESA " +
                                ",CAR.PLACA as PLANCA " +
                                ",CAR.ID_MARCA AS ID_MARCA " +
                                ",CAR.COR   AS COR " +
                                ",CAR.ANO   AS ANO " +
                                ",CAR.USER_INSERT  AS USER_INSERT " +
                                ",CAR.USER_UPDATE  AS USER_UPDATE " +
                                ",MARCA.DESCRICAO  AS Marca_Descricao " +
                                "FROM OS_CAR CAR " +
                                "INNER JOIN MARCAS MARCA ON MARCA.ID_EMPRESA = CAR.ID_EMPRESA AND MARCA.ID = CAR.ID_MARCA ";

            //Adiciona WHERE 
            strSelect += $"WHERE CAR.ID_EMPRESA = {id_empresa} and CAR.PLACA  = '{placa}'";

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

                            obj = new Marca();

                            obj = PopulaCarbOS(objDataReader);


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

        */
        private Marca PopulaMarca(NpgsqlDataReader objDataReader)
        {

            var obj = new Marca();

            obj.Id_Empresa = Convert.ToInt32(objDataReader["Id_Empresa"]);
            obj.Id = Convert.ToInt32(objDataReader["Id"]);
            obj.Descricao = objDataReader["Descricao"].ToString();
            obj.User_Insert = Convert.ToInt32(objDataReader["User_Insert"]);
            obj.User_Update = Convert.ToInt32(objDataReader["User_Update"]);

            return obj;
        }

        public List<Marca> getAll(int Ordenacao, string Filtro)
        {

            Marca obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            List<Marca> lista = new List<Marca>();

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

                                obj = new Marca();

                                obj = PopulaMarca(objDataReader);

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

            string strSelect = " SELECT MARCA.ID_EMPRESA,MARCA.ID,MARCA.DESCRICAO,MARCA.USER_INSERT,MARCA.USER_UPDATE FROM MARCAS MARCA ";

            //Adiciona WHERE 
            if (Filtro.Trim() != "")
            {
                switch (Ordenacao)
                {
                    case 0:
                        Where = $"WHERE MARCA.ID_EMPRESA = 1 AND MARCA.ID = {Filtro}";
                        break;
                    case 1:
                        Where = $"WHERE MARCA.ID_EMPRESA = 1 AND MARCA.DESCRICAO = '{Filtro}'";
                        break;
                }
            }

            //Adiciona ORDER BY


            switch (Ordenacao)
            {
                case 0:
                    OrderBy = $"ORDER BY MARCA.ID_EMPRESA  ,  MARCA.ID ";
                    break;
                case 1:
                    OrderBy = $"ORDER BY MARCA.ID_EMPRESA  ,  MARCA.MODELO ";
                    break;

            }

            strSelect += $" {Where} {OrderBy} ";

            return strSelect;

        }

        public string SqlGridBrowse(int Ordenacao, string Filtro)
        {
            string Where = "";

            string OrderBy = "";

            string strSelect = " SELECT MARCA.ID_EMPRESA,MARCA.ID,MARCA.DESCRICAO,MARCA.USER_INSERT,MARCA.USER_UPDATE FROM MARCAS MARCA ";

            //Adiciona WHERE 
            if (Filtro.Trim() != "")
            {
                switch (Ordenacao)
                {
                    case 0:
                        Where = $"WHERE MARCA.ID_EMPRESA = 1 AND MARCA.ID = {Filtro}";
                        break;
                    case 1:
                        Where = $"WHERE MARCA.ID_EMPRESA = 1 AND MARCA.DESCRICAO = '{Filtro}'";
                        break;
                }
            }

            //Adiciona ORDER BY


            switch (Ordenacao)
            {
                case 0:
                    OrderBy = $"ORDER BY MARCA.ID_EMPRESA  ,  MARCA.ID ";
                    break;
                case 1:
                    OrderBy = $"ORDER BY MARCA.ID_EMPRESA  ,  MARCA.MODELO ";
                    break;

            }

            strSelect += $" {Where} {OrderBy} ";

            return strSelect;

        }

    }
}
