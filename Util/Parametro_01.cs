using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxo_De_Caixa.Util
{
    public class Parametro_01
    {
        public int id_empresa { get; set; }
        public string Tipo { get; set; }
        public DateTime Inicial { get; set; }
        public DateTime Final { get; set; }
        public int ClirFor { get; set; }
        public int Situacao { get; set; }

        public Parametro_01(int id_empresa, string tipo, DateTime inicial, DateTime final, int clirFor, int situacao)
        {
            this.id_empresa = id_empresa;
            Tipo = tipo;
            Inicial = inicial;
            Final = final;
            ClirFor = clirFor;
            Situacao = situacao;
        }

        public Parametro_01()
        {
            Zerar();
        }

        private void Zerar()
        {
            id_empresa = 1;
            Tipo = "R";
            Inicial = DateTime.Now;
            Final = DateTime.Now;
            ClirFor = 0;
            Situacao = 0;
        }


        /*
   * 0-> todos
   * 1-> Em Aberto
   * 2-> Encerrado
*/

    }

}
