using System;

namespace Fluxo_De_Caixa.Models
{
    public class Usuario
    {

        public int Codigo { get; set; }
        public string Cnpj_Cpf { get; set; }
        public string Razao { get; set; }
        public DateTime Cadastr { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int UserInsert { get; set; }
        public int UserUpdate { get; set; }

        public Usuario()
        {
            Zerar();
        }

        public Usuario(int codigo, string cnpj_Cpf, string razao, DateTime cadastr, string endereco, string bairro, string cidade, string uf, string cep, string tel1, string tel2, string email, string senha, int userInsert, int userUpdate)
        {
            Codigo = codigo;
            Cnpj_Cpf = cnpj_Cpf;
            Razao = razao;
            Cadastr = cadastr;
            Endereco = endereco;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
            Cep = cep;
            Tel1 = tel1;
            Tel2 = tel2;
            Email = email;
            Senha = senha;
            UserInsert = userInsert;
            UserUpdate = userUpdate;
        }

        public void Zerar()
        {
            Codigo = 0;
            Cnpj_Cpf = "";
            Razao = "";
            Cadastr = DateTime.Now.Date;
            Endereco = "";
            Bairro = "";
            Cidade = "";
            Uf = "SP";
            Cep = "";
            Tel1 = "";
            Tel2 = "";
            Email = "";
            Senha = "";
            UserInsert = 0;
            UserUpdate = 0;
    }
    }
}
