using System;

namespace Fluxo_De_Caixa.Models
{
    public class Cliente
    {

        public int IdEmpresa { get; set; }
        public int Codigo { get; set; }
        public string Razao { get; set; }
        public string Fantasi { get; set; }
        public string Tel1 { get; set; }
        public string Email { get; set; }
        public string Conta { get; set; }
        public int UserInsert { get; set; }
        public int UserUpdate { get; set; }
        public string _ContaDesc { get; set; }

        public Cliente(int idEmpresa, int codigo, string razao, string fantasi, string tel1, string email, string conta, int userInsert, int userUpdate, string _contaDesc)
        {
            IdEmpresa = idEmpresa;
            Codigo = codigo;
            Razao = razao;
            Fantasi = fantasi;
            Tel1 = tel1;
            Email = email;
            Conta = conta;
            UserInsert = userInsert;
            UserUpdate = userUpdate;
            _ContaDesc = _contaDesc;
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
            Fantasi = "";
            Tel1 = "";
            Email = "";
            Conta = ""; 
            UserInsert = 0;
            UserUpdate = 0;
            _ContaDesc = "";
        }
    }
}
