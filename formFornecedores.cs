using Fluxo_De_Caixa.Dao.postgre;
using Fluxo_De_Caixa.Extensoes;
using Fluxo_De_Caixa.Models;
using Fluxo_De_Caixa.Models.Validacoes;
using Fluxo_De_Caixa.Util;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Fluxo_De_Caixa
{
    public partial class formFornecedores : Form
    {
        Visoes visao = Visoes.Browser;

        Fornecedor fornecedor = new Fornecedor();

        List<Conta> lsContas = new List<Conta>();

        int Ordenacao = 2; //Razao Social 

        int Codigo = 0;

        public ToolStripMenuItem menu { get; internal set; }

        public formFornecedores()
        {
            InitializeComponent();

            cbPesquisar.SelectedIndex = Ordenacao;
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            loadContas();
            SetarVisoes();
        }

        private void SetarProperties(bool value)
        {
            txtCodigo.Enabled = false;
            txtRazao.Enabled = value;
            txtFantasi.Enabled = value;
            txtTel1.Enabled    = value;
            txtEmail.Enabled   = value;
            cbConta.Enabled   = value;

            txtRazao.CharacterCasing = CharacterCasing.Upper;
            txtFantasi.CharacterCasing = CharacterCasing.Upper;
            txtRazao.MaxLength   = 40;
            txtFantasi.MaxLength = 40;
            txtEmail.MaxLength   = 100;
        }

        private void loadFornecedor()
        {

            preencheDataGridView();

        }

        private void loadContas()
        {
            daoConta dao = new daoConta();

            lsContas = dao.getAll(1, "");

            lsContas.ForEach(conta =>
            {
                if (conta.Tipo == "P" && conta.Codigo.Substring(3, 3) != "000")
                {
                    cbConta.Items.Add($"{conta.Codigo}-{conta.Descricao}");
                }
            });

        }

        //Botoes da Barra
        private void TbBrowser_Click(object sender, EventArgs e)
        {
            switch (visao)
            {

                case Visoes.Browser:

                    visao = Visoes.Consulta;

                    daoFornecedor dao = new daoFornecedor();

                    fornecedor = dao.Seek(1,Codigo);

                    if (fornecedor == null)
                    {

                        fornecedor = new Fornecedor();

                        fornecedor.Zerar();

                        visao = Visoes.Nova;

                    }

                    Atualiza();

                    break;

                default:

                    visao = Visoes.Browser;

                    break;

            }

            SetarVisoes();
        }

        private void TbEditar_Click(object sender, EventArgs e)
        {
            visao = Visoes.Edicao;

            SetarVisoes();
        }

        private void TbIncluir_Click(object sender, EventArgs e)
        {
            visao = Visoes.Nova;

            fornecedor = new Fornecedor();

            fornecedor.Zerar();

            Atualiza();

            SetarVisoes();
        }

        private void TbDelete_Click(object sender, EventArgs e)
        {

            DialogResult resultado = MessageBox.Show("Confirma A Exclusão ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            switch (resultado)

            {


                case DialogResult.No:

                    break;

                case DialogResult.Yes:

                    daoFornecedor dao = new daoFornecedor();

                    dao.Delete(fornecedor);

                    loadFornecedor();

                    break;

                default:

                    break;

            }

            visao = Visoes.Browser;

            SetarVisoes();
        }

        private void TbOk_Click(object sender, EventArgs e)
        {

            try
            {

                PopularCliente();

                string Erros = Validacao();

                if (Erros != "")
                {

                    MessageBox.Show(Erros);

                    return;

                }

                daoFornecedor dao = new daoFornecedor();


                switch (visao)
                {

                    case Visoes.Nova:

                        fornecedor.UserInsert = UsuarioSistema.Usuario.Codigo;

                        Fornecedor retorno = dao.Insert(fornecedor);

                        if (retorno != null)
                        {

                            MessageBox.Show($"USUÁRIO Incluído No Código {retorno.Codigo}","Atenção!",MessageBoxButtons.OK,MessageBoxIcon.Information);

                        }
                        else
                        {

                            MessageBox.Show($"Falha Na Inclusão Do USUÁRIO!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);


                        }

                        visao = Visoes.Browser;

                        loadFornecedor();

                        SetarVisoes();

                        break;

                    case Visoes.Edicao:

                        fornecedor.UserUpdate = UsuarioSistema.Usuario.Codigo;

                        dao.Update(fornecedor);

                        MessageBox.Show($"USUÁRIO Alterado Com Sucesso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        visao = Visoes.Browser;

                        loadFornecedor();

                        SetarVisoes();

                        break;

                }
            }
            catch (Exception exc)
            {

                MessageBox.Show("Falha No Procedimento\n" + exc.Message);

            }


        }

        private void CbPesquisar_Click(object sender, EventArgs e)
        {



        }

        private void TbCancelar_Click(object sender, EventArgs e)
        {
            visao = Visoes.Browser;

            SetarVisoes();
        }

        private void CbPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ordenacao = cbPesquisar.SelectedIndex;

            edPesquisar.Text = "";

            loadFornecedor();
        }

        private void BtBuscar_Click(object sender, EventArgs e)
        {
            loadFornecedor();
        }

        //GridView

        private void DbGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            {
                try
                {

                    Codigo = Convert.ToInt32(((DataGridView)sender)[0, e.RowIndex].Value);

                }
                catch (Exception exc)
                {
                    Codigo = 0;
                }

            }
        }

        private void DbGridView_DoubleClick(object sender, EventArgs e)
        {

            visao = Visoes.Consulta;

            daoFornecedor dao = new daoFornecedor();

            fornecedor = dao.Seek(fornecedor.IdEmpresa,Codigo);

            if (fornecedor == null)
            {

                fornecedor = new Fornecedor();

                fornecedor.Zerar();

                visao = Visoes.Nova;

            }

            Atualiza();

            SetarVisoes();

        }

        private void ConfiguraDbDridView()
        {
            dbGridView.AutoResizeColumns();
            dbGridView.Columns[00].HeaderText = "CÓDIGO";
            dbGridView.Columns[00].Width = 100;
            dbGridView.Columns[00].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridView.Columns[01].HeaderText = "RAZÃO SOCIAL";
            dbGridView.Columns[01].Width = 300;
            dbGridView.Columns[00].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dbGridView.Columns[02].HeaderText = "FANTASIA";
            dbGridView.Columns[02].Width = 300;
            dbGridView.Columns[00].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dbGridView.Columns[03].HeaderText = "TEL 01";
            dbGridView.Columns[03].Width = 100;
            dbGridView.Columns[00].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dbGridView.Columns[04].HeaderText = "EMAIL";
            dbGridView.Columns[04].Width = 350;
            dbGridView.Columns[00].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dbGridView.Columns[05].HeaderText = "CONTA";
            dbGridView.Columns[00].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.Columns[05].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dbGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dbGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.BorderStyle = BorderStyle.Fixed3D;
            dbGridView.EnableHeadersVisualStyles = false;

        }

        public void preencheDataGridView()
        {
            //faz a conexão
            var  conn = new NpgsqlConnection(Fluxo_De_Caixa.DataBase.RunCommand.connectionString);

            try //inicio do tratamento de exceções 
            {

                daoFornecedor dao = new daoFornecedor();

                string strSelect = dao.SqlGridBrowse(Ordenacao, edPesquisar.Text.Trim());

                conn.Open(); //abre conexão 
                var sql = new NpgsqlCommand(strSelect, conn); //comando SQL 

                //SqlDataAdapter é o adaptador que interliga classes que manipulam dados em C# e o banco de dados em si 
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql);

                // DataSet é um cache na memória dos dados recuperados de uma fonte de dados
                DataSet ds = new DataSet();

                // O método Fill faz o preenchimento do objeto DataTable, inserindo nele os dados que retornaram do SGBD 
                da.Fill(ds);


                // O DataGridView possui o complemento DataSource, e por ele podemos determinar a origem dos dados que irão compor suas linhas e colunas       
                dbGridView.DataSource = ds;

                dbGridView.DataMember = ds.Tables[0].TableName;
            }
            catch (Exception ex) //fim do tratamento de exceções 
            {
                MessageBox.Show("Erro ao obter os dados!\n\n" + ex + ".", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Error); //mostra exceção, se houver 
            }
            finally //Finaliza conexão, independentemente da ocorrência de exceção ou não 
            {
                conn.Close();
            }

            ConfiguraDbDridView();
        }

        private string Validacao()
        {
            string Result = "";


            if (!Validacoes.IsTamanho(fornecedor.Razao, 1, 40))
            {
                Result += "Tamanho do Campo Razão Deve Ficar Entre 1 e 40 !\n";
            }

            if (!Validacoes.IsTamanho(fornecedor.Fantasi, 0, 40))
            {
                Result += "Tamanho do Campo Razão Deve Ficar Entre 0 e 40 !\n";
            }

            if (!Validacoes.IsTamanho(fornecedor.Email, 0, 100))
            {
                Result += "Tamanho do Campo Razão Deve Ficar Entre 0 e 100 !\n";
            }

            return Result;

        }

        private void Atualiza()
        {
            int id = cbConta.FindString(cbConta.Text);
            txtCodigo.Text  = fornecedor.Codigo.IntNovo();
            txtRazao.Text   = fornecedor.Razao.Trim();
            txtFantasi.Text = fornecedor.Fantasi.Trim();
            txtTel1.Text    = fornecedor.Tel1;
            txtEmail.Text   = fornecedor.Email.Trim();
            cbConta.SelectedIndex = id;
        }


        //Formulario

        private void PopularCliente()
        {
            fornecedor.Codigo = txtCodigo.Text.IntParse();
            fornecedor.Razao = txtRazao.Text;
            fornecedor.Fantasi = txtFantasi.Text;
            fornecedor.Tel1 = txtTel1.Text;
            fornecedor.Email = txtEmail.Text;
            fornecedor.Conta = cbConta.SelectedItem.ToString().Substring(0, 6);
        }

  
        private void SetarVisoes()
        {

            switch (visao)
            {

                case Visoes.Browser:
                    tabControl.Visible = false;
                    dbGridView.ReadOnly = true;
                    dbGridView.Visible = true;
                    SetarBotoes();
                    break;
                case Visoes.Consulta:
                    tabControl.Visible = true;
                    dbGridView.ReadOnly = true;
                    dbGridView.Visible = false;
                    tabControl.SelectedIndex = 0;
                    SetarBotoes();
                    break;
                case Visoes.Edicao:
                    tabControl.Visible = true;
                    dbGridView.ReadOnly = true;
                    dbGridView.Visible = false;
                    SetarBotoes();
                    break;
                case Visoes.Nova:
                    tabControl.Visible = true;
                    dbGridView.ReadOnly = true;
                    dbGridView.Visible = false;
                    SetarBotoes();
                    break;

            }

        }

        private void SetarBotoes()
        {
           
            switch (visao)
            {
                case Visoes.Browser:
                    tbBrowser.Visible = true;
                    tbIncluir.Visible = false;
                    tbEditar.Visible = false;
                    tbDelete.Visible = false;
                    tbOk.Visible = false;
                    tbCancelar.Visible = false;
                    lbPesquisar.Visible = true;
                    cbPesquisar.Visible = true;
                    edPesquisar.Visible = true;
                    btBuscar.Visible = true;
                    break;
                case Visoes.Consulta:
                    tbBrowser.Visible = true;
                    tbIncluir.Visible = true;
                    tbEditar.Visible = true;
                    tbDelete.Visible = true;
                    tbOk.Visible = false;
                    tbCancelar.Visible = false;
                    lbPesquisar.Visible = false;
                    cbPesquisar.Visible = false;
                    edPesquisar.Visible = false;
                    btBuscar.Visible = false;
                    SetarProperties(false);
                    break;

                case Visoes.Edicao:
                    tbBrowser.Visible = false;
                    tbIncluir.Visible = false;
                    tbEditar.Visible = false;
                    tbDelete.Visible = false;
                    tbOk.Visible = true;
                    tbCancelar.Visible = true;
                    lbPesquisar.Visible = false;
                    cbPesquisar.Visible = false;
                    edPesquisar.Visible = false;
                    btBuscar.Visible = false;
                    SetarProperties(true);
                    break;
                case Visoes.Nova:
                    tbBrowser.Visible = false;
                    tbIncluir.Visible = false;
                    tbEditar.Visible = false;
                    tbDelete.Visible = false;
                    tbOk.Visible = true;
                    tbCancelar.Visible = true;
                    lbPesquisar.Visible = false;
                    cbPesquisar.Visible = false;
                    edPesquisar.Visible = false;
                    btBuscar.Visible = false;
                    SetarProperties(true);
                    break;

            }
        }

        private void CbPesquisar_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Ordenacao = cbPesquisar.SelectedIndex;

            loadFornecedor();
        }

   

        private void FormUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Enabled = true;
        }
        
        private void FormUsuarios_Activated(object sender, EventArgs e)
        {
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

    }
}
