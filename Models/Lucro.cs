using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxo_De_Caixa.Models
{
    public class Lucro
    {
        public string Tipo { get; set; }
        public string Data { get; set; }
        public string Doc { get; set; }
        public string Codigo { get; set; }
        public string Razao { get; set; }
        public string Entrada { get; set; }
        public string Agregado { get; set; }
        public string Saida { get; set; }

        public Lucro( string data, string doc, string codigo, string razao, string entrada, string agregado, string saida)
        {
            Data = data;
            Doc = doc;
            Codigo = codigo;
            Razao = razao;
            Entrada = entrada;
            Agregado = agregado;
            Saida = saida;
        }

        public Lucro()
        {
            Zerar();
        }

        private void Zerar()
        {            Data = "";
            Doc = "";
            Codigo = "";
            Razao = "";
            Entrada = "";
            Agregado = "";
            Saida = "";
        }
    }
}
