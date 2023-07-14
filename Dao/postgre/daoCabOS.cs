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
            string dt_saida = obj.Saida?.ToString("yyyy-MM-dd");

            if (dt_saida == null)
            {
                dt_saida = "NULL";
            }
            else
            {
                dt_saida = $"'{obj.Saida?.ToString("yyyy-MM-dd")}'";
            }

            String StringInsert = $" INSERT INTO OS_CAB " +
                                  "(ID_EMPRESA, ENTRADA, SAIDA, ID_CLIENTE, ID_CARRO, HORAS_SERVICO, KM, OBS, LUCRO,  MAO_OBRA, MAO_OBRA_VLR, PECAS_VLR, USER_INSERT, USER_UPDATE) " +
                                 $" VALUES({obj.Id_Empresa},'{obj.Entrada.ToString("yyyy-MM-dd")}',{dt_saida},{obj.Id_Cliente},'{obj.Id_Carro}','{obj.Horas_Servico}',{obj.Km},'{obj.Obs.NoAspasSimples()}',{obj.Lucro.DoubleParseDb()},'{obj.Mao_Obra}',{obj.Mao_Obra_Vlr.DoubleParseDb()},{obj.Pecas_Vlr.DoubleParseDb()},{obj.User_Insert},{obj.User_Update})  RETURNING ID ";

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
            string dt_saida = obj.Saida?.ToString("yyyy-MM-dd");

            if (dt_saida == null)
            {
                dt_saida = "NULL";
            }
            else
            {
                dt_saida = $"'{obj.Saida?.ToString("yyyy-MM-dd")}'";
            }
            String StringUpdate = $" UPDATE  OS_CAB SET " +
                        $"ENTRADA  	        =  '{obj.Entrada.ToString("yyyy-MM-dd")}', " +
                        $"SAIDA   	        =  {dt_saida}, " +
                        $"ID_CLIENTE        =  {obj.Id_Cliente}, " +
                        $"ID_CARRO          =  '{obj.Id_Carro}', " +
                        $"HORAS_SERVICO     =  '{obj.Horas_Servico}', " +
                        $"KM                =  {obj.Km}, " +
                        $"LUCRO             =  {obj.Lucro.DoubleParseDb()}, " +
                        $"OBS               =  '{obj.Obs.Trim().NoAspasSimples()}', " +
                        $"MAO_OBRA          =  '{obj.Mao_Obra.Trim().NoAspasSimples()}', " +                        $"MAO_OBRA_VLR      =  {obj.Mao_Obra_Vlr.DoubleParseDb()}, " +
                        $"PECAS_VLR         =  {obj.Pecas_Vlr.DoubleParseDb()}, " +
                        $"USER_INSERT       =  {obj.User_Insert}, " +
                        $"USER_UPDATE       =  {obj.User_Update} " +
                        $"WHERE ID_EMPRESA  = {obj.Id_Empresa} AND ID = {obj.Id} ";


            Console.WriteLine(StringUpdate);

            try
            {

                DataBase.RunCommand.CreateCommand(StringUpdate);

            }
            catch (ExceptionErroImportacao ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Delete(CabOS obj)
        {

            String StringDelete = $" DELETE FROM  OS_CAB  WHERE ID_EMPRESA = {obj.Id_Empresa} AND ID = {obj.Id} ";

            DataBase.RunCommand.CreateCommand(StringDelete);

        }

        public void DeleteFullOs(CabOS obj)
        {
            int Ct_det = 0;
            int Ct_cab = 0;
            daoDetOS dao = new daoDetOS();

            String StringDeleteCab = $" DELETE FROM  OS_CAB  WHERE ID_EMPRESA = {obj.Id_Empresa} AND ID = {obj.Id} RETURNING ID";
            try
            {
                try
                {
                    Ct_det = dao.DeleteByOS(obj.Id_Empresa, obj.Id);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                using (var objConexao = new NpgsqlConnection(DataBase.RunCommand.connectionString))
                {
                    using (var objCommand = new NpgsqlCommand(StringDeleteCab, objConexao))
                    {
                        try
                        {
                            objConexao.Open();

                            var objDataReader = objCommand.ExecuteReader();

                            if (objDataReader.HasRows)
                            {

                                objDataReader.Read();

                                Ct_cab++;

                            }

                        }
                        catch (Exception ex)
                        {

                            throw new Exception($"Falha Na Exclusão No Cabeçalho {ex.Message}");
                        }
                        finally
                        {
                            objConexao.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public CabOS SaveFullOs(CabOS cabec, List<DetOS> detalhe, string operacao)
        {

            int Ct_det = 0;

            double TotalPecas = 0;

            daoDetOS dao = new daoDetOS();

            try
            {
                detalhe.ForEach(det => TotalPecas += det.Valor);
                cabec.Pecas_Vlr = TotalPecas;
                cabec._Total_OS = cabec.Mao_Obra_Vlr + cabec.Pecas_Vlr;

                if (operacao == "I")
                {
                    try
                    {
                        cabec = Insert(cabec);
                        if (cabec == null)
                        {
                            throw new Exception("Falha No Cadastro Da OS");
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        Update(cabec);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                try
                {
                    Ct_det = dao.DeleteByOS(cabec.Id_Empresa, cabec.Id);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                try
                {
                    detalhe.ForEach(det => det.Id_Os = cabec.Id);
                    dao.InsertByOS(detalhe);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
               
          
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return cabec;
        }

        public CabOS Seek(int id_empresa, int id)
        {

            CabOS obj = null;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = "SELECT   CAB.ID_EMPRESA		" +
                                "        ,CAB.ID                " +
                                "        ,CAB.ENTRADA           " +
                                "        ,CAB.SAIDA             " +
                                "        ,CAB.ID_CLIENTE        " +
                                "        ,CAB.ID_CARRO          " +
                                "        ,CAB.HORAS_SERVICO     " +
                                "        ,CAB.KM                " +
                                "        ,CAB.OBS               " +
                                "        ,CAB.LUCRO             " +
                                "        ,CAB.MAO_OBRA          " +
                                "        ,CAB.MAO_OBRA_VLR      " +
                                "        ,CAB.PECAS_VLR         " +
                                "        ,CAB.USER_INSERT       " +
                                "        ,CAB.USER_UPDATE       " +
                                "        ,CLI.CODIGO     AS CLI_CODIGO		 " +
                                "        ,CLI.RAZAO      AS CLI_RAZAO		 " +
                                "        ,CLI.CNPJ_CPF   AS CLI_CNPJ_CPF     " +
                                "        ,CLI.ENDERECOF  AS CLI_ENDERECO     " +
                                "        ,CLI.NROF       AS CLI_NRO          " +
                                "        ,CLI.BAIRROF    AS CLI_BAIRRO       " +
                                "        ,CLI.CIDADEF    AS CLI_CIDADE       " +
                                "        ,CLI.UFF        AS CLI_UF           " +
                                "        ,CLI.CEPF       AS CLI_CEP          " +
                                "        ,CLI.TEL1       AS CLI_TEL1         " +
                                "        ,CLI.EMAIL      AS CLI_EMAIL        " +
                                "        ,LEFT(CAR.PLACA,3) || '-' || RIGHT(CAR.PLACA,4)     AS CAR_PLACA        " +
                                "        ,CAR.ID_MARCA   AS CAR_ID_MARCA     " +
                                "        ,CAR.MODELO     AS CAR_MODELO    " +
                                "        ,CAR.COR        AS CAR_COR          " +
                                "        , LEFT(CAR.ANO,4) || '-' || RIGHT(CAR.ANO,4)       AS CAR_ANO          " +
                                "        ,MARCA.DESCRICAO AS MARCA_DESCRICAO " +
                                "FROM OS_CAB CAB " +
                                "INNER JOIN CLIENTES  CLI   ON CLI.ID_EMPRESA  = CAB.ID_EMPRESA  AND CLI.CODIGO     = CAB.ID_CLIENTE    " +
                                "INNER JOIN OS_CAR    CAR   ON CAR.ID_EMPRESA  = CAB.ID_EMPRESA  AND CAR.PLACA      = CAB.ID_CARRO      " +
                                "INNER JOIN MARCAS    MARCA ON MARCA.ID_EMPRESA = CAR.ID_EMPRESA AND MARCA.ID       = CAR.ID_MARCA      ";

            //Adiciona WHERE 
            strSelect += $"WHERE CAB.ID_EMPRESA = {id_empresa} and CAB.ID = {id}";

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

        public int ContadorByPlaca(int id_empresa, string placa)
        {
            int retorno = 0;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = "SELECT   count(*) as TOTAL		" +
                                "FROM OS_CAB CAB ";
                                

            //Adiciona WHERE 
            strSelect += $"WHERE CAB.ID_EMPRESA = {id_empresa} and CAB.ID_CARRO = '{placa}'";

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

                            retorno = Convert.ToInt32(objDataReader["TOTAL"]);

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

        public int ContadorByCliente(int id_empresa, int id_cliente)
        {
            int retorno = 0;

            string strStringConexao = DataBase.RunCommand.connectionString;

            string strSelect = "SELECT   count(*) as TOTAL		" +
                                "FROM OS_CAB CAB ";

            //Adiciona WHERE 
            strSelect += $"WHERE CAB.ID_EMPRESA = {id_empresa} and CAB.ID_CLIENTE = '{id_cliente}'";

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

                            retorno = Convert.ToInt32(objDataReader["TOTAL"]);

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
        private CabOS PopulaCabOS(NpgsqlDataReader objDataReader)
        {

            var obj = new CabOS();


            obj.Id_Empresa = Convert.ToInt32(objDataReader["ID_EMPRESA"]);
            obj.Id = Convert.ToInt32(objDataReader["ID"]);
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
            obj.Mao_Obra = objDataReader["Mao_Obra"].ToString();
            obj.Mao_Obra_Vlr = Convert.ToDouble(objDataReader["Mao_Obra_Vlr"]);
            obj.Pecas_Vlr = Convert.ToDouble(objDataReader["Pecas_Vlr"]);
            obj.User_Insert = Convert.ToInt32(objDataReader["User_Insert"]);
            obj.User_Update = Convert.ToInt32(objDataReader["User_Update"]);
            obj.Cli_Codigo = objDataReader["Cli_Codigo"].ToString();
            obj.Cli_Razao = objDataReader["Cli_Razao"].ToString();
            obj.Cli_Cnpj_Cpf = objDataReader["Cli_Cnpj_Cpf"].ToString();
            obj.Cli_Endereco = objDataReader["Cli_Endereco"].ToString();
            obj.Cli_Nro = objDataReader["Cli_Nro"].ToString();
            obj.Cli_Bairro = objDataReader["Cli_Bairro"].ToString();
            obj.Cli_Cidade = objDataReader["Cli_Cidade"].ToString();
            obj.Cli_Uf = objDataReader["Cli_Uf"].ToString();
            obj.Cli_Cep = objDataReader["Cli_Cep"].ToString();
            obj.Cli_Tel1 = objDataReader["Cli_Tel1"].ToString();
            obj.Cli_Email = objDataReader["Cli_Email"].ToString();
            obj.Car_Placa = objDataReader["Car_Placa"].ToString();
            obj.Car_Id_Marca = Convert.ToInt32(objDataReader["CAR_ID_MARCA"]);
            obj.Car_Modelo = objDataReader["Car_Modelo"].ToString();
            obj.Car_Cor = objDataReader["Car_Cor"].ToString();
            obj.Car_Ano = objDataReader["Car_Ano"].ToString();
            obj.Marca_Descricao = objDataReader["Marca_Descricao"].ToString();
            obj._Total_OS = obj.Pecas_Vlr + obj.Mao_Obra_Vlr;

            return obj;
        }

        private CabOS PopulaOSBrowse(NpgsqlDataReader objDataReader)
        {

            var obj = new CabOS();


            obj.Id_Empresa = Convert.ToInt32(objDataReader["ID_EMPRESA"]);
            obj.Id = Convert.ToInt32(objDataReader["ID"]);
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
            obj.Mao_Obra = objDataReader["Mao_Obra"].ToString();
            obj.Mao_Obra_Vlr = Convert.ToDouble(objDataReader["Mao_Obra_Vlr"]);
            obj.Pecas_Vlr = Convert.ToDouble(objDataReader["Pecas_Vlr"]);
            obj.User_Insert = Convert.ToInt32(objDataReader["User_Insert"]);
            obj.User_Update = Convert.ToInt32(objDataReader["User_Update"]);
            obj.Cli_Codigo = objDataReader["Cli_Codigo"].ToString();
            obj.Cli_Razao = objDataReader["Cli_Razao"].ToString();
            obj.Cli_Cnpj_Cpf = objDataReader["Cli_Cnpj_Cpf"].ToString();
            obj.Cli_Tel1 = objDataReader["Cli_Tel1"].ToString();
            obj.Cli_Email = objDataReader["Cli_Email"].ToString();
            obj.Car_Placa = objDataReader["Car_Placa"].ToString();
            obj.Marca_Descricao = objDataReader["Marca_Descricao"].ToString();
            obj.Car_Cor = objDataReader["Car_Cor"].ToString();
            obj.Car_Ano = objDataReader["Car_Ano"].ToString();
            obj._Total_OS = obj.Pecas_Vlr + obj.Mao_Obra_Vlr;
            return obj;
        }

        private Lucro PopulaLucro(NpgsqlDataReader objDataReader)
        {

            var obj = new Lucro();

            obj.Data = Convert.ToDateTime(objDataReader["Data"]).ToString("dd/MM/yy");
            obj.Doc = objDataReader["Doc"].ToString();
            obj.Codigo = objDataReader["Codigo"].ToString();
            obj.Razao = objDataReader["Razao"].ToString();
            if (objDataReader["Tipo"].ToString() == "R")
            {
                obj.Entrada = objDataReader["VALOR"].ToString();
                obj.Agregado = objDataReader["LUCRO"].ToString();
                obj.Saida = "";
            } else
            {
                obj.Entrada = "";
                obj.Agregado = "";
                obj.Saida = objDataReader["VALOR"].ToString();
            }
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

                                obj = PopulaCabOS(objDataReader);

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

            string strSelect = "SELECT   CAB.ID_EMPRESA		" +
                               "        ,CAB.ID                " +
                               "        ,CAB.ENTRADA           " +
                               "        ,CAB.SAIDA             " +
                               "        ,CAB.ID_CLIENTE        " +
                               "        ,CAB.ID_CARRO          " +
                               "        ,CAB.HORAS_SERVICO     " +
                               "        ,CAB.KM                " +
                               "        ,CAB.OBS               " +
                               "        ,CAB.LUCRO             " +
                               "        ,CAB.MAO_OBRA          " +
                               "        ,CAB.MAO_OBRA_VLR      " +
                               "        ,CAB.PECAS_VLR         " +
                               "        ,CAB.USER_INSERT       " +
                               "        ,CAB.USER_UPDATE       " +
                               "        ,CLI.CODIGO     AS CLI_CODIGO		 " +
                               "        ,CLI.RAZAO      AS CLI_RAZAO		 " +
                               "        ,CLI.CNPJ_CPF   AS CLI_CNPJ_CPF     " +
                                "        ,CLI.ENDERECOF  AS CLI_ENDERECO     " +
                                "        ,CLI.NROF       AS CLI_NRO          " +
                                "        ,CLI.BAIRROF    AS CLI_BAIRRO       " +
                                "        ,CLI.CIDADEF    AS CLI_CIDADE       " +
                                "        ,CLI.UFF        AS CLI_UF           " +
                                "        ,CLI.CEPF       AS CLI_CEP          " +
                               "        ,CLI.TEL1       AS CLI_TEL1         " +
                               "        ,CLI.EMAIL      AS CLI_EMAIL        " +
                                "        ,LEFT(CAR.PLACA,3) || '-' || RIGHT(CAR.PLACA,4)     AS CAR_PLACA        " +
                                "        ,CAR.ID_MARCA   AS CAR_ID_MARCA     " +
                                "        ,CAR.MODELO     AS CAR_MODELO    " +
                                "        ,CAR.COR        AS CAR_COR          " +
                                "        , LEFT(CAR.ANO,4) || '-' || RIGHT(CAR.ANO,4)       AS CAR_ANO          " +
                                "        ,MARCA.DESCRICAO AS MARCA_DESCRICAO " +
                               "FROM OS_CAB CAB " +
                               "INNER JOIN CLIENTES  CLI   ON CLI.ID_EMPRESA  = CAB.ID_EMPRESA  AND CLI.CODIGO     = CAB.ID_CLIENTE    " +
                               "INNER JOIN OS_CAR    CAR   ON CAR.ID_EMPRESA  = CAB.ID_EMPRESA  AND CAR.PLACA      = CAB.ID_CARRO      " +
                               "INNER JOIN MARCAS    MARCA ON MARCA.ID_EMPRESA = CAR.ID_EMPRESA AND MARCA.ID       = CAR.ID_MARCA      ";
            //Adiciona WHERE 
            if (Filtro.Trim() != "")
            {


                switch (Ordenacao)
                {
                    case 0:
                        Where = $"WHERE CAB.ID = '{Filtro}'";
                        break;
                    case 1:
                        Where = $"WHERE CLI.RAZAO LIKE '%{Filtro.Trim()}%'";
                        break;
                    case 2:
                        Where = $"WHERE CLI.CNPJ_CPF  = '{Filtro.Trim()}'";
                        break;
                    case 3:
                        DateTime Pesquisa = Convert.ToDateTime(Filtro.Trim());
                        Where = $"WHERE CAB.ENTRADA   = '{Pesquisa.ToString("yyy-MM-dd")}'";
                        break;
                }


            }

            //Adiciona ORDER BY

            switch (Ordenacao)
            {
                case 0:
                    OrderBy = $"ORDER BY CAB.ID DESC";
                    break;
                case 1:
                    OrderBy = $"ORDER BY CLI.RAZAO";
                    break;
                case 2:
                    OrderBy = $"ORDER BY CLI.CNPJ_CPF";
                    break;
                case 3:
                    OrderBy = $"ORDER BY CAB.ENTRADA DESC ";
                    break;
            }

            strSelect += $" {Where} {OrderBy} ";

            return strSelect;

        }

        public string SqlGridBrowse(int Ordenacao, string Filtro)
        {
            string Where = "";

            string OrderBy = "";

            string strSelect = "SELECT 	" +
                    "         CAB.ID                        " +
                    "        ,CLI.CODIGO     AS CLI_CODIGO		 " +
                    "        ,CLI.RAZAO      AS CLI_RAZAO		 " +
                    "        ,CLI.TEL1       AS CLI_TEL1         " +
                    "        ,CAB.ENTRADA           " +
                    "        ,CAB.SAIDA             " +
                    "        ,CAB.HORAS_SERVICO     " +
                    "        ,CAB.KM                " +
                    "        ,CAB.OBS               " +
                    "        ,CAB.MAO_OBRA_VLR      " +
                    "        ,CAB.PECAS_VLR         " +
                    "        ,LEFT(CAR.PLACA,3) || '-' || RIGHT(CAR.PLACA,4)     AS CAR_PLACA        " +
                    "        ,MARCA.DESCRICAO AS MARCA_DESCRICAO " +
                    "        ,CAR.MODELO      AS CAR_MODELO       " +
                    "        ,CAR.COR         AS CAR_COR          " +
                     "       , LEFT(CAR.ANO,4) || '-' || RIGHT(CAR.ANO,4)       AS CAR_ANO          " +
                    "FROM OS_CAB CAB " +
                    "INNER JOIN CLIENTES  CLI   ON CLI.ID_EMPRESA  = CAB.ID_EMPRESA  AND CLI.CODIGO     = CAB.ID_CLIENTE    " +
                    "INNER JOIN OS_CAR    CAR   ON CAR.ID_EMPRESA  = CAB.ID_EMPRESA  AND CAR.PLACA      = CAB.ID_CARRO      " +
                    "INNER JOIN MARCAS    MARCA ON MARCA.ID_EMPRESA = CAR.ID_EMPRESA AND MARCA.ID       = CAR.ID_MARCA      ";
            //Adiciona WHERE 
            if (Filtro.Trim() != "")
            {


                switch (Ordenacao)
                {
                    case 0:
                        Where = $"WHERE CAB.ID = '{Filtro}'";
                        break;
                    case 1:
                        Where = $"WHERE CLI.RAZAO LIKE '%{Filtro.Trim()}%'";
                        break;
                    case 2:
                        Where = $"WHERE CLI.CNPJ_CPF  = '{Filtro.Trim()}'";
                        break;
                    case 3:
                        DateTime Pesquisa = Convert.ToDateTime(Filtro.Trim());
                        Where = $"WHERE CAB.ENTRADA   = '{Pesquisa.ToString("yyy-MM-dd")}'";
                        break;
                }


            }

            //Adiciona ORDER BY

            switch (Ordenacao)
            {
                case 0:
                    OrderBy = $"ORDER BY CAB.ID DESC";
                    break;
                case 1:
                    OrderBy = $"ORDER BY CLI.RAZAO";
                    break;
                case 2:
                    OrderBy = $"ORDER BY CLI.CNPJ_CPF";
                    break;
                case 3:
                    OrderBy = $"ORDER BY CAB.ENTRADA DESC ";
                    break;

            }

            strSelect += $" {Where} {OrderBy} ";

            return strSelect;

        }

        public List<Lucro> getLucro(string ano, string mes)
        {
            List<Lucro> lsLucro = new List<Lucro>();

            string chave = $"{mes}-{ano}";

            string strStringConexao = DataBase.RunCommand.connectionString;


            string strSelect =  " SELECT * FROM ( " +
                                " SELECT   'R' AS TIPO, CAB.SAIDA AS DATA , CAB.ID::text AS DOC, CAB.ID_CLIENTE AS CODIGO, CLI.RAZAO, (CAB.MAO_OBRA_VLR+CAB.PECAS_VLR) AS VALOR, CAB.LUCRO AS LUCRO  " +
                                " FROM     OS_CAB CAB " +
                                " INNER JOIN CLIENTES CLI ON CLI.ID_EMPRESA = CAB.ID_EMPRESA AND CLI.CODIGO = CAB.ID_CLIENTE  " +
                               $" WHERE    TO_CHAR(saida,'MM-yyyy') = '{chave}' UNION ALL " +
                                " SELECT   'P' AS TIPO, DOC.VENCIMENTO AS DATA , DOC.DOC AS DOC, DOC.CLIFOR AS CODIGO, FORNE.RAZAO, DOC.VALOR , 0 AS LUCRO " +
                                " FROM     DOCUMENTOS DOC " +
                                " INNER JOIN FORNECEDORES FORNE ON FORNE.ID_EMPRESA = DOC.ID_EMPRESA AND FORNE.CODIGO = DOC.CLIFOR  " +
                               $" WHERE    DOC.TIPO = 'P' AND TO_CHAR(VENCIMENTO,'MM-yyyy') = '{chave}' ) AS TABELA " +
                                " ORDER BY TABELA.TIPO DESC,TABELA.DATA,TABELA.DOC ";


            Console.WriteLine(strSelect);

            using (var objConexao = new NpgsqlConnection(strStringConexao))
            {
                double entrada = 0;
                double lucro = 0;
                double saida = 0;
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

                                Lucro obj = new Lucro();

                                obj = PopulaLucro(objDataReader);

                                try
                                {
                                    if (objDataReader["Tipo"].ToString() == "R")
                                    {
                                        entrada += Convert.ToDouble(objDataReader["VALOR"]);
                                        lucro   += Convert.ToDouble(objDataReader["LUCRO"]);
                                    }
                                    else
                                    {
                                        saida   += Convert.ToDouble(objDataReader["VALOR"]);
                                    }
                                } catch(Exception ex)
                                {
                                    MessageBox.Show("Erro No Cáculo Do Totais", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                lsLucro.Add(obj);

                            }
                        }

                        Lucro totais = new Lucro("","","","TOTAIS", string.Format("{0:0.00}",entrada), string.Format("{0:0.00}", lucro), string.Format("{0:0.00}", saida));
                        lsLucro.Add(totais);
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


            return lsLucro;
        }

    }
}
