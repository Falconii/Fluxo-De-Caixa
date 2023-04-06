using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxo_De_Caixa.Models
{
    public class Estado
    {
        public string Uf { get; set; }

        public Estado(string uf)
        {
            Uf = uf;
        }
    }
}
