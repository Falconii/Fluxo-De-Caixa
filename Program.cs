using System;
using System.Windows.Forms;

namespace Fluxo_De_Caixa
{
    static class Program
    {
       
        [STAThread]
        static void Main(string[] args)
        {


            /*
            if (args.Length == 0)
            {
                RunCommand.SetarBanco("SERVIDOR");
            } else
            {
                RunCommand.SetarBanco(args[0]);
            }
            */

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            FormLogin Login = null;

            Login = new FormLogin();

            if (Login.ShowDialog() == DialogResult.OK)
            {

                Application.Run(MDISingleton.MDIParentPrincipal(Login.usuario));

            }
           
        }
    }
}
