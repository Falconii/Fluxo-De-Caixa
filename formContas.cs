using Correios;
using Fluxo_De_Caixa;
using Fluxo_De_Caixa.Dao.postgre;
using Fluxo_De_Caixa.Extensoes;
using Fluxo_De_Caixa.Models;
using Fluxo_De_Caixa.Models.Validacoes;
using Fluxo_De_Caixa.Util;
using Npgsql;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Fluxo_De_Caixa
{
    public partial class formContas : Form
    {
        Visoes visao = Visoes.Browser;

        Conta conta = new Conta();

        int Ordenacao = 0; //CODIGO 

        string Codigo = "";

        string proprietario = "Conta";

        public ToolStripMenuItem menu { get; internal set; }

        public formContas()
        {
            InitializeComponent();
            tbDelete.ToolTipText = $"Click Aqui Para Excluir  A {proprietario}";
            tbEditar.ToolTipText = $"Click Aqui Para Alterar  A {proprietario}";
            tbIncluir.ToolTipText = $"Click Aqui Para Incluir Uma {proprietario} Nova";
            cbPesquisar.SelectedIndex = Ordenacao;
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {

            SetarVisoes();
        }

        private void SetarProperties(bool value)
        {
            switch (visao)
            {

                case Visoes.Nova:
                    txtCodigo.Enabled = true;
                    if (value) txtCodigo.Focus();
                    break;
                case Visoes.Edicao:
                    txtCodigo.Enabled = false;
                    break;
                default:
                    txtCodigo.Enabled = false;
                    break;
            }
            cbTipo.Enabled = value;
            txtDescricao.Enabled = value;
            txtDescricao.CharacterCasing = CharacterCasing.Upper;
            
        }

        private void loadConta()
        {

            preencheDataGridView();

        }


        //Botoes da Barra
        private void TbBrowser_Click(object sender, EventArgs e)
        {
            switch (visao)
            {

                case Visoes.Browser:

                    visao = Visoes.Consulta;

                    daoConta dao = new daoConta();

                    conta = dao.Seek(1, Codigo);

                    if (conta == null)
                    {

                        conta = new Conta();

                        conta.Zerar();

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

            conta = new Conta();

            conta.Zerar();

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

                    daoConta dao = new daoConta();

                    dao.Delete(conta);

                    loadConta();

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

                PopularConta();

                string Erros = Validacao();

                if (Erros != "")
                {

                    MessageBox.Show(Erros);

                    return;

                }

                daoConta dao = new daoConta();


                switch (visao)
                {

                    case Visoes.Nova:

                        conta.UserInsert = UsuarioSistema.Usuario.Codigo;

                        Conta retorno = dao.Insert(conta);

                        if (retorno != null)
                        {

                            MessageBox.Show($"Conta Incluído No Código {retorno.Codigo}", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {

                            MessageBox.Show($"Falha Na Inclusão Do Conta!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);


                        }

                        visao = Visoes.Browser;

                        loadConta();

                        SetarVisoes();

                        break;

                    case Visoes.Edicao:

                        conta.UserUpdate = UsuarioSistema.Usuario.Codigo;

                        dao.Update(conta);

                        MessageBox.Show($"Conta Alterado Com Sucesso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        visao = Visoes.Browser;

                        loadConta();

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

            loadConta();
        }

        private void BtBuscar_Click(object sender, EventArgs e)
        {
            loadConta();
        }


        //GridView

        private void DbGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            {
                try
                {

                    Codigo = ((DataGridView)sender)[0, e.RowIndex].Value.ToString();

                }
                catch (Exception exc)
                {
                    Codigo = "";
                }

            }
        }

        private void DbGridView_DoubleClick(object sender, EventArgs e)
        {

            visao = Visoes.Consulta;

            daoConta dao = new daoConta();

            conta = dao.Seek(conta.IdEmpresa, Codigo);

            if (conta == null)
            {

                conta = new Conta();

                conta.Zerar();

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
            dbGridView.Columns[01].HeaderText = "TIPO";
            dbGridView.Columns[01].Width = 300;
            dbGridView.Columns[00].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dbGridView.Columns[02].HeaderText = "DESCRICAO";
            dbGridView.Columns[02].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dbGridView.Columns[02].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dbGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dbGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.BorderStyle = BorderStyle.Fixed3D;
            dbGridView.EnableHeadersVisualStyles = false;
            dbGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(dbGridView_FormatarConta);

        }

        private void dbGridView_FormatarConta(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dbGridView.Columns[e.ColumnIndex].Name.Equals("codigo"))
            {
                string stringValue = e.Value as string;
                if (stringValue == null) return;
                if (stringValue.Length == 6)
                {
                    e.Value = stringValue.Substring(0, 3) + "." + stringValue.Substring(3, 3);
                }
                else
                {
                    e.Value = stringValue;
                }
            }
            if (dbGridView.Columns[e.ColumnIndex].Name.Equals("tipo"))
            {
                string stringValue = e.Value as string;
                if (stringValue == null) return;
                if (stringValue == "R")
                {
                    e.Value = "RECEBER";
                }
                else
                {
                    e.Value = "PAGAR";
                }
            }
        }

        public void preencheDataGridView()
        {
            //faz a conexão
            var conn = new NpgsqlConnection(Fluxo_De_Caixa.DataBase.RunCommand.connectionString);

            try //inicio do tratamento de exceções 
            {

                daoConta dao = new daoConta();

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

            if (!Validacoes.IsTamanho(conta.Codigo, 1, 6))
            {
                Result += "Campo Código É Obrigatorio!\n";
            }

            if (!Validacoes.IsTamanho(conta.Descricao, 1, 30))
            {
                Result += "Tamanho do Campo Razão Deve Ficar Entre 1 e 30 !\n";
            }


            return Result;

        }

        private void Atualiza()
        {

            txtCodigo.Text = conta.Codigo;
            cbTipo.SelectedIndex = conta.Tipo == "R" ? 0 : 1;
            txtDescricao.Text = conta.Descricao.Trim();

        }


        //Formulario

        private void PopularConta()
        {
            txtCodigo.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            conta.Codigo = txtCodigo.Text;
            txtCodigo.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            conta.Tipo = cbTipo.Text.Substring(0, 1);
            conta.Descricao = txtDescricao.Text;

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

            loadConta();
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
