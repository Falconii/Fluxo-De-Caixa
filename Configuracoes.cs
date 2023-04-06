// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
using System.Collections.Generic;

public class Conexo
{
    public string combo_text { get; set; }
    public string app_text { get; set; }
    public StringConection string_conection { get; set; }
}

public class Configuracoes
{
    public Padrao padrao { get; set; }
    public List<Conexo> conexoes { get; set; }
}

public class Padrao
{
    public string banco { get; set; }
}

public class AppConfig
{
    public Configuracoes configuracoes { get; set; }

    public string Serializar()
    {
        string retorno = "";
        retorno =  "{\n";
        retorno += "\t\"configuracoes\": {\n";
        retorno += "\t\t\"padrao\": {\n";
        retorno += $"\t\t\t\"banco\":\"{configuracoes.padrao.banco}\"\n";
        retorno += "\t},\n";
        retorno += "\t\"conexoes\": [\n";
        foreach (Conexo con in configuracoes.conexoes)
        {
            retorno += getConexoes(con);
        }
        retorno += "\t\t]\n";
        retorno += "\t}\n";
        retorno += "}\n";

        return retorno;
    }
    private string getConexoes(Conexo con)
    {
        string retorno = "";
        retorno +=  "\t\t\t{\n";
        retorno += $"\t\t\t\t\"combo_text\": \"{con.combo_text}\",\n";
        retorno += $"\t\t\t\t\"app_text\": \"{con.app_text}\",\n";
        retorno +=  "\t\t\t\t\"string_conection\":\n";
        retorno +=  "\t\t\t\t{\n";
        retorno += $"\t\t\t\t\t\"Server\": \"{con.string_conection.Server}\",\n";
        retorno += $"\t\t\t\t\t\"Port\": \"{con.string_conection.Port}\",\n";
        retorno += $"\t\t\t\t\t\"UserId\": \"{con.string_conection.UserId}\",\n";
        retorno += $"\t\t\t\t\t\"Password\": \"{con.string_conection.Password}\",\n";
        retorno += $"\t\t\t\t\t\"Database\": \"{con.string_conection.Database}\",\n";
        retorno += $"\t\t\t\t\t\"CommandTimeout\": \"{con.string_conection.CommandTimeout}\",\n";
        retorno += "\t\t\t\t}\n";
        retorno += "\t\t\t},\n";


        return retorno;
    }
}

public class StringConection
{
    public string Server { get; set; }
    public string Port { get; set; }
    public string UserId { get; set; }
    public string Password { get; set; }
    public string Database { get; set; }
    public string CommandTimeout { get; set; }
}

