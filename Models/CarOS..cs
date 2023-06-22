using System;

namespace Fluxo_De_Caixa.Models
{
    public class CarOS
    {

        public int Id_Empresa { get; set; }
        public string Placa { get; set; }
        public int Id_Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Ano { get; set; }
        public int User_Insert { get; set; }
        public int User_Update { get; set; }
        public string Marca_Descricao { get; set; }

        public CarOS(int id_Empresa, string placa, int id_Marca, string modelo, string cor, string ano, int user_Insert, int user_Update, string marca_Descricao)
        {
            Id_Empresa = id_Empresa;
            Placa = placa;
            Id_Marca = id_Marca;
            Modelo = modelo;
            Cor = cor;
            Ano = ano;
            User_Insert = user_Insert;
            User_Update = user_Update;
            Marca_Descricao = marca_Descricao;
        }

        public CarOS()
        {
            Zerar();
        }

        public void Zerar()
        {
            Id_Empresa = 1;
            Placa = "";
            Id_Marca = 0;
            Modelo = "";
            Cor = "";
            Ano = "";
            User_Insert = 0;
            User_Update = 0;
            Marca_Descricao = "";
        }
    }
}
