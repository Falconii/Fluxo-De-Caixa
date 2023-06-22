using Fluxo_De_Caixa.Extensoes;
using Fluxo_De_Caixa.Models;
using Fluxo_De_Caixa.Util;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fluxo_De_Caixa.Dao.postgre
{
    class daoCarOS
    {

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

            CarOS obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect =  " SELECT   CAR.ID_EMPRESA " +
                                ",CAR.PLACA " +
                                ",CAR.MARCA " +
                                ",CAR.COR " +
                                ",CAR.ANO " +
                                ",CAR.USER_INSERT " +
                                ",CAR.USER_UPDATE " +
                                "FROM OS_CAR CAR ";

            //Adiciona WHERE 
            strSelect += $"WHERE DET.ID_EMPRESA = {id_empresa} and DET.PLACA  = '{placa}'";

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

                            obj = new CarOS();

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

        private CarOS PopulaCarbOS(NpgsqlDataReader objDataReader)
        {

            var obj = new CarOS();

            obj.Id_Empresa = Convert.ToInt32(objDataReader["Id_Empresa"]);
            obj.Placa = objDataReader["Placa"].ToString();
            obj.Id_Marca = Convert.ToInt32(objDataReader["Id_Marca"]);
            obj.Modelo   = objDataReader["Id_Marca"].ToString();
            obj.Cor = objDataReader["Cor"].ToString();
            obj.Ano = objDataReader["Ano"].ToString();
            obj.User_Insert = Convert.ToInt32(objDataReader["User_Insert"]);
            obj.User_Update = Convert.ToInt32(objDataReader["User_Update"]);
            obj.Marca_Descricao = objDataReader["Marca_Descricao"].ToString();

            return obj;
        }

        public List<CarOS> getAll(int Ordenacao, string Filtro)
        {

            CarOS obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            List<CarOS> lista = new List<CarOS>();

            string strSelect = SqlGridBrowse(Ordenacao, Filtro);

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

                                obj = new CarOS();

                                obj = PopulaCarbOS(objDataReader);

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

            string strSelect = " SELECT   CAR.ID_EMPRESA " +
                                ",CAR.PLACA " +
                                ",CAR.ID_MARCA " +
                                ",CAR.COR " +
                                ",CAR.ANO " +
                                ",CAR.USER_INSERT " +
                                ",CAR.USER_UPDATE " +
                                ",MARCA.DESCRICAO AS MARCA_DESCRICAO " +
                                "FROM OS_CAR DET " +
                                "INNER JOIN MARCAS MARCA ON MARCA.ID_EMPRESA = CAR.ID_EMPRESA AND MARCA.ID = CAR.ID_MARCA ";

            //Adiciona WHERE 
            if (Filtro.Trim() != "")
            {
                switch (Ordenacao)
                {
                    case 0:
                        Where = $"WHERE CAR.ID_EMPRESA = 1 AND CAR.PLACA = '{Filtro}'";
                        break;
                }
            }

            //Adiciona ORDER BY


            switch (Ordenacao)
            {
                case 0:
                    OrderBy = $"ORDER BY CAR.ID_EMPRESA  ,  CAR.PLACA ";
                    break;

            }

            strSelect += $" {Where} {OrderBy} ";

            return strSelect;

        }

        public string SqlGridBrowse(int Ordenacao, string Filtro)
        {
            string Where = "";

            string OrderBy = "";

            string strSelect = " SELECT   CAR.ID_EMPRESA " +
                               ",CAR.PLACA " +
                               ",MARCA.DESCRICAO AS MARCA_DESCRICAO " +
                               ",CAR.COR " +
                               ",CAR.ANO " +
                               ",CAR.USER_INSERT " +
                               ",CAR.USER_UPDATE " +
                               "FROM OS_CAR DET " +
                               "INNER JOIN MARCAS MARCA ON MARCA.ID_EMPRESA = CAR.ID_EMPRESA AND MARCA.ID = CAR.ID_MARCA ";

            //Adiciona WHERE 
            if (Filtro.Trim() != "")
            {
                switch (Ordenacao)
                {
                    case 0:
                        Where = $"WHERE CAR.ID_EMPRESA = 1 AND CAR.PLACA = '{Filtro}'";
                        break;
                }
            }

            //Adiciona ORDER BY


            switch (Ordenacao)
            {
                case 0:
                    OrderBy = $"ORDER BY CAR.ID_EMPRESA  ,  CAR.PLACA ";
                    break;

            }

            strSelect += $" {Where} {OrderBy} ";

            return strSelect;

        }

    }
}
