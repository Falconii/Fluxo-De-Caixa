using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxo_De_Caixa.Util
{
    public class ColunaExcel
    {
        public int Ano { get; set; }
        public int Mes { get; set; }
        public string Campo { get; set; }
        public int Indice { get; set; }

        private string[] _Meses = { "JANEIRO", "FEVEREIRO","MARÇO","ABRIL","MAIO","JUNHO","JULHO","AGOSTO","SETETEMBRO","OUTUBRO","NOVEMBRO","DEZEMBRO" };

        public string GetData(){

            var Retorno = _Meses[Mes-1]+"/"+Ano.ToString();

            return Retorno;


        }
     }
}
