using System;

namespace Fluxo_De_Caixa.Models
{
    public class CabOS
    {
        public int Id_Empresa { get; set; }
        public int Id { get; set; }
        public DateTime Entrada { get; set; }
        public Nullable<DateTime> Saida { get; set; }
        public int Id_Cliente { get; set; }
        public string Id_Carro { get; set; }
        public int Id_Cond { get; set; }
        public string Horas_Servico { get; set; }
        public int Km { get; set; }
        public string Obs { get; set; }
        public double Lucro { get; set; }
        public string Mao_Obra { get; set; }
        public double Mao_Obra_Vlr { get; set; }
        public double Pecas_Vlr { get; set; }
        public int User_Insert { get; set; }
        public int User_Update { get; set; }
        public string Cli_Codigo { get; set; }
        public string Cli_Razao { get; set; }
        public string Cli_Cnpj_Cpf { get; set; }
        public string Cli_Endereco { get; set; }
        public string Cli_Nro { get; set; }
        public string Cli_Bairro { get; set; }
        public string Cli_Cidade { get; set; }
        public string Cli_Uf { get; set; }
        public string Cli_Cep { get; set; }
        public string Cli_Tel1 { get; set; }
        public string Cli_Email { get; set; }
        public string Car_Placa { get; set; }
        public int Car_Id_Marca { get; set; }
        public string Car_Modelo { get; set; }
        public string Car_Cor { get; set; }
        public string Car_Ano { get; set; }
        public string Cond_Descricao { get; set; }
        public string Marca_Descricao { get; set; }

        public CabOS(int id_Empresa, int id, DateTime entrada, DateTime? saida, int id_Cliente, string id_Carro, int id_Cond, string horas_Servico, int km, string obs, double lucro, string mao_Obra, double mao_Obra_Vlr, double pecas_Vlr, int user_Insert, int user_Update, string cli_Codigo, string cli_Razao, string cli_Cnpj_Cpf, string cli_Endereco, string cli_Nro, string cli_Bairro, string cli_Cidade, string cli_Uf, string cli_Cep, string cli_Tel1, string cli_Email, string car_Placa, int car_Id_Marca, string car_Modelo, string car_Cor, string car_Ano, string cond_Descricao, string marca_Descricao)
        {
            Id_Empresa = id_Empresa;
            Id = id;
            Entrada = entrada;
            Saida = saida;
            Id_Cliente = id_Cliente;
            Id_Carro = id_Carro;
            Id_Cond = id_Cond;
            Horas_Servico = horas_Servico;
            Km = km;
            Obs = obs;
            Lucro = lucro;
            Mao_Obra = mao_Obra;
            Mao_Obra_Vlr = mao_Obra_Vlr;
            Pecas_Vlr = pecas_Vlr;
            User_Insert = user_Insert;
            User_Update = user_Update;
            Cli_Codigo = cli_Codigo;
            Cli_Razao = cli_Razao;
            Cli_Cnpj_Cpf = cli_Cnpj_Cpf;
            Cli_Endereco = cli_Endereco;
            Cli_Nro = cli_Nro;
            Cli_Bairro = cli_Bairro;
            Cli_Cidade = cli_Cidade;
            Cli_Uf = cli_Uf;
            Cli_Cep = cli_Cep;
            Cli_Tel1 = cli_Tel1;
            Cli_Email = cli_Email;
            Car_Placa = car_Placa;
            Car_Id_Marca = car_Id_Marca;
            Car_Modelo = car_Modelo;
            Car_Cor = car_Cor;
            Car_Ano = car_Ano;
            Cond_Descricao = cond_Descricao;
            Marca_Descricao = marca_Descricao;
        }

        public CabOS()
        {
            Zerar();
        }
          

        public void Zerar()
        {
            Id_Empresa = 1;
            Id = 0;
            Entrada = DateTime.Now;
            Saida = null;
            Id_Cliente = 0;
            Id_Carro = "";
            Id_Empresa = 0;
            Horas_Servico = "00:00";
            Km = 0;
            Obs = "";
            Lucro = 0;
            Mao_Obra = "";
            Mao_Obra_Vlr = 0;
            Pecas_Vlr = 0;
            User_Insert = 0;
            User_Update = 0;
            Cli_Codigo = "";
            Cli_Razao = "";
            Cli_Cnpj_Cpf = "";
            Cli_Endereco = "";
            Cli_Nro = "";
            Cli_Bairro = "";
            Cli_Cidade = "";
            Cli_Uf = "";
            Cli_Cep = "";
            Cli_Tel1 = "";
            Cli_Email = "";
            Car_Placa = "";
            Car_Id_Marca = 0;
            Car_Modelo = "";
            Car_Cor = "";
            Car_Ano = "";
            Cond_Descricao = "";
            Marca_Descricao = "";
        }
    }
}
