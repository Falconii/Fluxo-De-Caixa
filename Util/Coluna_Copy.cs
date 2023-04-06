using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxo_De_Caixa.Util
{
    public static class Coluna_Copy
    {
        public static string NumericLikeText(string field, string alias)
        {
            string _alias = alias.Trim() == "" ? "" : $"AS {alias}";
            string retorno = $"'=' || '\"' || {field.Replace("'", "\'").Replace('"', '\"')} || '\"'   {_alias}";

            return retorno;
        }

        public static string NumericFormat(string field, int inteiro, int decimais,string alias)
        {

            string _alias = alias.Trim() == "" ? "" : $"AS {alias}";
            string retorno = $"TO_CHAR({field}, '{string.Concat(Enumerable.Repeat("9", inteiro))}D{string.Concat(Enumerable.Repeat("0", decimais))}') {_alias}";

            return retorno;
        }

        
    }

}
