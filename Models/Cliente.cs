using System;

namespace Fluxo_De_Caixa.Models
{
    public class Cliente
    {

        public int IdEmpresa { get; set; }
        public int Codigo { get; set; }
        public string Razao { get; set; }
        public string Cnpj_Cpf { get; set; }
        public string Fantasi { get; set; }
        public string Enderecof { get; set; }
        public string Nrof { get; set; }
        public string Bairrof { get; set; }
        public string Cidadef { get; set; }
        public string Uff { get; set; }
        public string Cepf { get; set; }
        public string Tel1 { get; set; }
        public string Email { get; set; }
        public string Conta { get; set; }
        public int UserInsert { get; set; }
        public int UserUpdate { get; set; }
        public string _ContaDesc { get; set; }

        public Cliente(int idEmpresa, int codigo, string razao, string cnpj_Cpf, string fantasi, string enderecof, string nrof, string bairrof, string cidadef, string uff, string cepf, string tel1, string email, string conta, int userInsert, int userUpdate, string contaDesc)
        {
            IdEmpresa = idEmpresa;
            Codigo = codigo;
            Razao = razao;
            Cnpj_Cpf = cnpj_Cpf;
            Fantasi = fantasi;
            Enderecof = enderecof;
            Nrof = nrof;
            Bairrof = bairrof;
            Cidadef = cidadef;
            Uff = uff;
            Cepf = cepf;
            Tel1 = tel1;
            Email = email;
            Conta = conta;
            UserInsert = userInsert;
            UserUpdate = userUpdate;
            _ContaDesc = contaDesc;
        }

        public Cliente()
        {
            Zerar();
        }


        public void Zerar()
        {
            IdEmpresa = 1;
            Codigo = 0;
            Razao = "";
            Cnpj_Cpf = "";
            Fantasi = "";
            Enderecof = "";
            Nrof = "";
            Bairrof = "";
            Cidadef = "";
            Uff = "SP";
            Cepf = "";
            Tel1 = "";
            Email = "";
            Conta = ""; 
            UserInsert = 0;
            UserUpdate = 0;
            _ContaDesc = "";
        }
    }
}
