using Fluxo_De_Caixa.Dao.postgre;
using Fluxo_De_Caixa.Models;
using Fluxo_De_Caixa.Models.Validacoes;
using Fluxo_De_Caixa.Util;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fluxo_De_Caixa
{
    public partial class FormCar : Form
    {
        Visoes visao = Visoes.Browser;

        CarOS carOS = new CarOS();

        int Ordenacao = 0; //CODIGO 

        string Placa = "";

        string proprietario = "Automóvel";

        List<Marca> lsMarcas = new List<Marca>();

        public ToolStripMenuItem menu { get; internal set; }

        public FormCar()
        {
            InitializeComponent();
            tbDelete.ToolTipText = $"Click Aqui Para Excluir  A {proprietario}";
            tbEditar.ToolTipText = $"Click Aqui Para Alterar  A {proprietario}";
            tbIncluir.ToolTipText = $"Click Aqui Para Incluir Uma {proprietario} Nova";
            cbPesquisar.SelectedIndex = Ordenacao;
        }

        private void FormCar_Load(object sender, EventArgs e)
        {
            SetarVisoes();
            loadMarcas();
            loadCarOS();
        }

        private void SetarProperties(bool value)
        {
            switch (visao)
            {

                case Visoes.Nova:
                    txtPlaca.Enabled = true;
                    break;
                case Visoes.Edicao:
                    txtPlaca.Enabled = false;
                    break;
                default:
                    txtPlaca.Enabled = false;
                    break;
            }
            txtMarca.Enabled = value;
            txtModelo.Enabled = value;
            txtCor.Enabled = value;
            txtAno.Enabled = value;
            txtModelo.CharacterCasing = CharacterCasing.Upper;
            txtCor.CharacterCasing = CharacterCasing.Upper;
            txtMarca.MaxLength = 20;
            txtCor.MaxLength = 20;
            
        }

        private void loadMarcas()
        {
            daoMarca dao = new daoMarca();
            lsMarcas = dao.getAll(0, "");
            lsMarcas.ForEach(m => { txtMarca.Items.Add($"{m.Descricao}"); });
        }
        private void loadCarOS()
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

                    daoCarOS dao = new daoCarOS();

                    carOS = dao.Seek(1, Placa.Replace("-",""));

                    if (carOS == null)
                    {

                        carOS = new CarOS();

                        carOS.Zerar();

                        carOS.Marca_Descricao = lsMarcas[0].Descricao;

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

            carOS = new CarOS();

            carOS.Zerar();

            carOS.Marca_Descricao = lsMarcas[0].Descricao;

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

                    daoCarOS dao = new daoCarOS();

                    dao.Delete(carOS);

                    loadCarOS();

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

                PopularCarOS();

                string Erros = Validacao();

                if (Erros != "")
                {

                    MessageBox.Show(Erros);

                    return;

                }

                daoCarOS dao = new daoCarOS();


                switch (visao)
                {

                    case Visoes.Nova:

                        carOS.User_Insert = UsuarioSistema.Usuario.Codigo;

                        CarOS retorno = dao.Insert(carOS);

                        if (retorno != null)
                        {

                            MessageBox.Show("Automovel Incluido!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {

                            MessageBox.Show($"Falha Na Inclusão Do Automovel!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);


                        }

                        visao = Visoes.Browser;

                        loadCarOS();

                        SetarVisoes();

                        break;

                    case Visoes.Edicao:

                        carOS.User_Update = UsuarioSistema.Usuario.Codigo;

                        dao.Update(carOS);

                        MessageBox.Show($"Autom´vel  Alterado Com Sucesso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        visao = Visoes.Browser;

                        loadCarOS();

                        SetarVisoes();

                        break;

                }
            }
            catch (Exception exc)
            {

                MessageBox.Show("Falha No Procedimento\n" + exc.Message);

            }


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

            loadCarOS();
        }

        private void BtBuscar_Click(object sender, EventArgs e)
        {
            loadCarOS();
        }


        //GridView

        private void DbGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            {
                try
                {

                    Placa = ((DataGridView)sender)[0, e.RowIndex].Value.ToString();

                }
                catch (Exception exc)
                {
                    Placa = "";
                }

            }
        }

        private void DbGridView_DoubleClick(object sender, EventArgs e)
        {

            visao = Visoes.Consulta;

            daoCarOS dao = new daoCarOS();

            carOS = dao.Seek(carOS.Id_Empresa, Placa.Replace("-",""));

            if (carOS == null)
            {

                carOS = new CarOS();

                carOS.Zerar();

                carOS.Marca_Descricao = lsMarcas[0].Descricao;

                visao = Visoes.Nova;

            }

            Atualiza();

            SetarVisoes();

        }

        private void ConfiguraDbDridView()
        {
            dbGridView.AutoResizeColumns();
            dbGridView.Columns[00].HeaderText = "PLACA";
            dbGridView.Columns[00].Width = 100;
            dbGridView.Columns[00].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dbGridView.Columns[01].HeaderText = "MARCA";
            dbGridView.Columns[01].Width = 200;
            dbGridView.Columns[01].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dbGridView.Columns[02].HeaderText = "MODELO";
            dbGridView.Columns[02].Width = 200;
            dbGridView.Columns[02].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dbGridView.Columns[03].HeaderText = "COR";
            dbGridView.Columns[03].Width = 200;
            dbGridView.Columns[03].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dbGridView.Columns[04].HeaderText = "ANO";
            dbGridView.Columns[04].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dbGridView.Columns[04].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dbGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dbGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.BorderStyle = BorderStyle.Fixed3D;
            dbGridView.EnableHeadersVisualStyles = false;

        }

   
        public void preencheDataGridView()
        {
            //faz a conexão
            var conn = new NpgsqlConnection(Fluxo_De_Caixa.DataBase.RunCommand.connectionString);

            try //inicio do tratamento de exceções 
            {

                daoCarOS dao = new daoCarOS();

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

            if (!Validacoes.IsTamanho(carOS.Placa, 1, 8))
            {
                Result += "Campo Placa Inválido!\n";
            }

            if (!Validacoes.IsTamanho(carOS.Modelo, 1, 20))
            {
                Result += "Tamanho do Campo Marca Deve Ficar Entre 1 e 20 !\n";
            }

            if (!Validacoes.IsTamanho(carOS.Cor, 1, 20))
            {
                Result += "Tamanho do Campo Cor Deve Ficar Entre 1 e 20 !\n";
            }

            return Result;

        }

        private void Atualiza()
        {
            int index = lsMarcas.FindIndex(m => m.Id == carOS.Id_Marca);
            txtPlaca.Text = carOS.Placa;
            txtMarca.SelectedIndex = index;
            txtModelo.Text = carOS.Modelo;
            txtCor.Text = carOS.Cor.Trim();
            txtAno.Text = carOS.Ano;

        }


        //Formulario

        private void PopularCarOS()
        {

            var marca = lsMarcas.Find(m => m.Descricao == txtMarca.Text);
            int id = 0;
            if (marca != null)
            {
                id = marca.Id;
            }
            txtPlaca.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            carOS.Placa = txtPlaca.Text;
            txtPlaca.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            carOS.Id_Marca = id;
            carOS.Modelo = txtModelo.Text;
            carOS.Cor = txtCor.Text ;
            carOS.Ano = txtAno.Text;
           
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

            loadCarOS();
        }

        private void FormCar_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Enabled = true;
        }

        private void FormCar_Activated(object sender, EventArgs e)
        {
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

    
        private void btBuscar_Click_1(object sender, EventArgs e)
        {
            loadCarOS();
        }
    }
}
