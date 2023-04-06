using Fluxo_De_Caixa.Util;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Fluxo_De_Caixa.Extensoes
{
    public static class StringExtension
    {

        public static string FormatCnpjCPF(this string sender)
        {   //99.999.999/9999-99
            string response = sender.Trim();

            if (response.Length == 11 || response.Length == 14)
            {
                if (response.Length == 14)
                {
                    response = response.Insert(12, "-");
                    response = response.Insert(8, "/");
                    response = response.Insert(5, ".");
                    response = response.Insert(2, ".");
                }
                else
                {
                    response = response.Insert(9, "-");
                    response = response.Insert(6, ".");
                    response = response.Insert(3, ".");
                }
            }

            return response;
        }

        public static string LimpaCnpjCpf(this string sender)
        {
            string response = sender;

            response = Regex.Replace(response, "[\\.\\/\\-\\ ]", "");

            return response;
        }

        public static double DoubleParseUSA(this string sender)
        {

            double response = 0.0;

            var culture = new System.Globalization.CultureInfo("en-US");

            try
            {

                response = Convert.ToDouble(sender, culture);

            }
            catch (Exception e)
            {

                response = 0.0;

            }


            return response;
        }

        public static double DoubleParse(this string sender)
        {

            double response = 0.0;

            var culture = new System.Globalization.CultureInfo("pt-BR");

            try
            {

                response = Convert.ToDouble(sender, culture);

            }
            catch (Exception e)
            {

                response = 0.0;

            }


            return response;
        }

        public static string DoubleParseDb(this double sender)
        {

            string response = "0.0";

            var culture = new System.Globalization.CultureInfo("en-US");

            try
            {

                response = Convert.ToString(sender, culture);

            }
            catch (Exception e)
            {

                response = "0.0";

            }


            return response;
        }

        public static int IntParse(this string sender)
        {

            int response = 0;

            try
            {

                response = Convert.ToInt32(sender);

            }
            catch (Exception e)
            {

                response = 0;

            }


            return response;
        }

        public static bool IsCnpjCpf(this string documento)
        {

            bool retorno = false;

            if (documento.Trim().Length == 11)
            {

                retorno = IsCpf(documento.Trim());

            }
            else
            {
                retorno = IsCnpj(documento.Trim());

            }

            return retorno;
        }

        public static String MMAA(this string sender)
        {

            String retorno = "";
            String mes = "";



            switch (sender.Substring(0, 2))
            {
                case "01":
                    mes = "Jan";
                    break;
                case "02":
                    mes = "Fev";
                    break;
                case "03":
                    mes = "Mar";
                    break;
                case "04":
                    mes = "Abr";
                    break;
                case "05":
                    mes = "Mai";
                    break;
                case "06":
                    mes = "Jun";
                    break;
                case "07":
                    mes = "Jul";
                    break;
                case "08":
                    mes = "Ago";
                    break;
                case "09":
                    mes = "Set";
                    break;
                case "10":
                    mes = "Out";
                    break;
                case "11":
                    mes = "Nov";
                    break;
                case "12":
                    mes = "Dez";
                    break;
                default:
                    mes = "";
                    break;
            }

            retorno = mes + "/" + sender.Substring(sender.Length - 2, 2); ;

            return retorno;
        }

        private static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();
            return cnpj.EndsWith(digito);
        }

        private static bool IsCpf(string cpf)
        {

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);

        }

        public static string SmartBreak(this string sender, int part)
        {

            int index = -1;

            string response = sender;

            if (response.Trim().Length <= 60)
            {
                index = -1;

            }
            else
            {
                index = response.Substring(0, 60).LastIndexOf(' ');
            }


            if (part == 1)
            {
                if (index == -1)
                {
                    response = response.Trim();
                }
                else
                {
                    response = response.Substring(0, index);
                }

                return response;
            }
            else
            {
                response = sender;

                if (index == -1) return "";

                int Comprimento = response.Length - (index + 1);

                return response.Substring(index + 1, Comprimento).Trim();

            }


        }

        public static string DateToDb(this String sender)
        {

            string response = "";

            response = sender.Substring(06, 04) + "-" + sender.Substring(03, 02) + "-" + sender.Substring(0, 02);

            return response;
        }

    
        public static string WithMaxLength(this string value, int maxLength)
        {
            return value?.Substring(0, Math.Min(value.Length, maxLength));
        }

        public static string CopyRigth(this string value)
        {
            string retorno = value;

            int pos = value.IndexOf('-');

            if (pos > -1)
            {
                value = value.Substring(pos + 1).Trim();
            }
            return value;
        }

        public static string CopyLeft(this string value)
        {
            string retorno = value;

            int pos = value.IndexOf('-');

            if (pos > -1)
            {
                if (pos >   1)
                {
                    value = value.Substring(0, pos - 1).Trim();
                }
             }

            return value;
        }
        public static string StrZeroRigth(this string value, int tam)
        {
            string retorno = value;

            string zeros = String.Concat(Enumerable.Repeat("0", tam));

            value = zeros + value.Trim();

            value = value.Substring((value.Length - tam));
                
            return value;
        }

        public static int HasLetter(this string value)
        {
            int retorno = -1;
            
            for(int x = 0; x < value.Length; x++)
            {
                if (Char.IsLetter(value[x])){
                    retorno = x;
                    break;
                }
            }

            return retorno;
        }

   
        public static string TirarControle(this string value)
        {
            string retorno = "";

            for (int x = 0; x < value.Length; x++)
            {
                if (Char.IsControl(value[x]))
                {
                    continue;
                }

                retorno += value.Substring(x, 1);
            }

            return retorno;
        }

        public static DateTime? DateOrNull(this string value)
        {

            DateTime? retorno = null;

            if (value.Trim() == "")
            {
                return retorno;
            }

            try
            {

                retorno = Convert.ToDateTime(value).Date;

            } catch(Exception ex)
            {
                retorno = null;
            }

            return retorno;

        }

        public static string AspasSimples(this string value)
        {

            string retorno = "''";

            if (value.Trim() == "")
            {
                return retorno;
            }

            retorno = "'"+value.Trim()+"'";

            return retorno;

        }

       
    }

}
