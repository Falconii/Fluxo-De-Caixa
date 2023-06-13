using Fluxo_De_Caixa.Util;
using Npgsql;
using System;

/*
 * Senha do TS : S1m10n4t0
 * Local
 * Usuario postgre
 * Senha S1m10n4t0SQL
 * Porta 5432
 * 
 * Servidor 192.168.0.251 
 * Usuario postgre
 * Senha   S1m10n4t0SQL  - S1m10n4t0ACD
 * Porta   49543
 *
 * Servidor 192.168.0.161 
 * Usuario postgre
 * Senha   S1m10n4t0SQL  - S1m10n4t0ACD
 * Porta   49777
 * 
 *
 * 
 * Usuario: Marcos
 * Senha: M4rc0n1PRJ
 * 
 */

namespace Fluxo_De_Caixa.DataBase
{
    public static class RunCommand
    {

        public static String Banco;
        public static String connectionString;

      
        public static void SetarBanco(Conexo config) {

            Banco = config.app_text;
            connectionString = $"Server='{config.string_conection.Server}';Port={config.string_conection.Port}; User Id = '{config.string_conection.UserId}'; Password='{config.string_conection.Password}' ; Database='{config.string_conection.Database}' ; CommandTimeout = {config.string_conection.CommandTimeout}  ";
          }

        public static void CreateCommand(string queryString)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand(queryString, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception e)
                {
                    throw new ExceptionErroImportacao("ERRO DO BANCO", "", "", "", 0, e.Message);
                }
            }
        }

    }
}
