using Fluxo_De_Caixa.Dao.postgre;
using Fluxo_De_Caixa.DataBase;
using Fluxo_De_Caixa.Extensoes;
using Fluxo_De_Caixa.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Fluxo_De_Caixa
{
    public partial class FormLogin : Form
    {

        public Usuario usuario = null;

        List<Usuario> lsUsuarios;

        AppConfig appConfig;


        public FormLogin()
        {
            InitializeComponent();
        }

        private void BtLogin_Click(object sender, EventArgs e)
        {
            String Usuario;
            String Senha;

            var dao = new daoUsuario();

            Usuario = (cbUsuarios.SelectedItem as Usuario).Razao;
            Senha = txtSenha.Text;

            if (Usuario.Trim() == "")
            {
                MessageBox.Show("Campo Usuário É Obrigatorio !!");

                return;

            }


            if (Senha.Trim() == "")
            {
                MessageBox.Show("Campo Senha É Obrigatorio !!");

                return;

            }


            var login = dao.Login(Usuario, Senha);

            if (login == null)
            {

                MessageBox.Show("Usuário Ou Senha Inválidos");

            } else
            {

                File.WriteAllText(@"conexoes.json", appConfig.Serializar());

                usuario = login;

                DialogResult = DialogResult.OK;

                Close();

            }

        }

        private void BtCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            cbBase.Items.Clear();
            StreamReader r = new StreamReader("conexoes.json");
            string jsonString = r.ReadToEnd();
            r.Close();
            appConfig = JsonConvert.DeserializeObject<AppConfig>(jsonString);
            

            foreach (Conexo obj in appConfig.configuracoes.conexoes)
            {
                cbBase.Items.Add(obj.combo_text);
            }
            cbBase.SelectedIndex = appConfig.configuracoes.padrao.banco.IntParse();
            status_inicio();
        }

        private void LoadUsuarios()
        {

            try
            {

                var dao = new daoUsuario();


                lsUsuarios = dao.getAll(2,"");


            }
            catch (Exception e)
            {

                lsUsuarios = new List<Usuario>();

            }


        }

        private void status_inicio()
        {
            cbBase.Enabled = true;
            cbUsuarios.Enabled = true;
            txtSenha.Enabled = true;
            btLogin.Enabled = true;
            
        }

        private void status_pegando_senha()
        {

            cbBase.Enabled = false;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                LoadUsuarios();

                if (lsUsuarios.Count == 0)
                {
                    var usuario = new Usuario();
                    usuario.Cnpj_Cpf = "00000000000000";
                    usuario.Razao = "ADM";
                    usuario.Senha = "123456";

                    try
                    {
                        var dao = new daoUsuario();

                        dao.Insert(usuario);

                        LoadUsuarios();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Problemas No Arquivo De Usuários!", "Atenção!");
                    }

                }

                if (lsUsuarios.Count == 0)
                {
                    MessageBox.Show("Aplicação Será Fechada!", "Atenção!");

                    Close();
                }

                cbUsuarios.DataSource = lsUsuarios;

                cbUsuarios.DisplayMember = "Razao";

            } finally
            {
                this.Cursor = Cursors.Arrow;
            }

            cbUsuarios.Enabled = true;
            txtSenha.Enabled   = true;
            btLogin.Enabled    = true;
            txtSenha.Focus();
        }

        private void cbBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            appConfig.configuracoes.padrao.banco = cbBase.SelectedIndex.ToString();
            RunCommand.SetarBanco(appConfig.configuracoes.conexoes[cbBase.SelectedIndex]);
            status_pegando_senha();
        }

        private void FormLogin_Activated(object sender, EventArgs e)
        {
            
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
