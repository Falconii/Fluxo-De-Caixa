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
using System.Globalization;
using System.Windows.Forms;

namespace Fluxo_De_Caixa
{
    public partial class formDocs : Form
    {
        Visoes visao = Visoes.Browser;

        Documento documento = new Documento();

        int Ordenacao = 0; //Id 

        int Id = 0;

        string proprietario = "Documento";

        List<Cliente> lsClientes = new List<Cliente>();
        List<Fornecedor> lsFornecedores = new List<Fornecedor>();

        public ToolStripMenuItem menu { get; internal set; }

        public formDocs()
        {
            InitializeComponent();
            tbDelete.ToolTipText = $"Click Aqui Para Excluir o {proprietario}";
            tbEditar.ToolTipText = $"Click Aqui Para Alterar O {proprietario}";
            tbIncluir.ToolTipText = $"Click Aqui Para Incluir Um {proprietario} Novo";
            cbPesquisar.SelectedIndex = Ordenacao;
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                loadClientes();
                loadFornecedores();
                SetartParametros();
                loadDocumentos();
                SetarVisoes();
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void SetartParametros()
        {
            tpCbCliFor.Items.Clear();
            lsClientes.ForEach(cliente =>
            {
                tpCbCliFor.Items.Add($"(C){cliente.Codigo.ToString("000000")}-{cliente.Razao}");
            });
            lsFornecedores.ForEach(fornecedor =>
            {
                tpCbCliFor.Items.Add($"(F){fornecedor.Codigo.ToString("000000")}-{fornecedor.Razao}");
            });
        }
        private void SetarProperties(bool value)
        {
            txtId.Enabled = false;
            cbTipo.Enabled = value;
            txtDocumento.Enabled = value;
            txtSerie.Enabled = value;
            txtParcela.Enabled = value;

            cbCliFor.Enabled = value;
            txtConta.Enabled = value;

            txtEmissao.Enabled = value;
            txtVencimento.Enabled = value;

            txtValor.Enabled = value;
            txtAbatimento.Enabled = value;
            txtJuros.Enabled = value;
            txtVlrPago.Enabled = value;
            txtSaldo.Enabled = value;

            txtObs.Enabled = value;

            txtSerie.CharacterCasing = CharacterCasing.Upper;
            txtParcela.CharacterCasing = CharacterCasing.Upper;
            txtObs.CharacterCasing = CharacterCasing.Upper;
            txtDocumento.MaxLength = 9;
            txtSerie.MaxLength = 3;
            txtParcela.MaxLength = 3;
            txtObs.MaxLength = 30;

        }

        private void loadDocumentos()
        {
            preencheDataGridView();

        }

        private void loadClientes()
        {
            daoCliente dao = new daoCliente();

            lsClientes = dao.getAll(1, "");

            if (lsClientes.Count == 0)
            {
                throw new Exception("Tabela De Clientes Vazia!");
            }

        }

        private void loadFornecedores()
        {
            daoFornecedor dao = new daoFornecedor();

            lsFornecedores = dao.getAll(1, "");

            if (lsClientes.Count == 0)
            {
                throw new Exception("Tabela De Fornecedores Vazia!");
            }

        }

        //Botoes da Barra
        private void TbBrowser_Click(object sender, EventArgs e)
        {
            switch (visao)
            {

                case Visoes.Browser:

                    visao = Visoes.Consulta;

                    daoDocumento dao = new daoDocumento();

                    documento = dao.Seek(1, Id);

                    if (documento == null)
                    {

                        documento = new Documento();

                        documento.Zerar();

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

            documento = new Documento();

            documento.Zerar();

            Atualiza();

            SetarVisoes();
        }

        private void TbDelete_Click(object sender, EventArgs e)
        {
            string msg = documento.Saldo == 0 ? "Documento Já Foi Baixado.\nDeseja A Exclusão Mesmo Assim ?": "Confirma A Exclusão ?";
            DialogResult resultado = MessageBox.Show(msg, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            switch (resultado)

            {


                case DialogResult.No:

                    break;

                case DialogResult.Yes:

                    daoDocumento dao = new daoDocumento();

                    dao.Delete(documento);

                    loadDocumentos();

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

                PopularDoc();
                              

                string Erros = Validacao();

                if (Erros != "")
                {

                    MessageBox.Show(Erros);

                    return;

                }

                daoDocumento dao = new daoDocumento();


                switch (visao)
                {

                    case Visoes.Nova:

                        documento.Doc = documento.Doc.Trim().PadLeft(9, '0');

                        documento.Saldo = (documento.Valor - documento.Abatimento + documento.Juros) - documento.VlrPago;

                        documento.UserInsert = UsuarioSistema.Usuario.Codigo;

                        Documento retorno = dao.Insert(documento);

                        if (retorno != null)
                        {

                            MessageBox.Show($"Documento Incluído No Código {retorno.Id}", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {

                            MessageBox.Show($"Falha Na Inclusão Do Documento!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);


                        }

                        visao = Visoes.Nova;

                        documento = new Documento();

                        Atualiza();

                        SetarVisoes();

                        break;

                    case Visoes.Edicao:

                        documento.Saldo = (documento.Valor - documento.Abatimento + documento.Juros) - documento.VlrPago;

                        documento.UserUpdate = UsuarioSistema.Usuario.Codigo;

                        dao.Update(documento);

                        MessageBox.Show($"Documento Alterado Com Sucesso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        visao = Visoes.Browser;

                        loadDocumentos();

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

            loadDocumentos();

            SetarVisoes();
        }
        private void CbPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ordenacao = cbPesquisar.SelectedIndex;

            edPesquisar.Text = "";

        }
        private void BtBuscar_Click(object sender, EventArgs e)
        {
            string Erros = "";

            if ( ( cbPesquisar.SelectedIndex == 1 ) || (cbPesquisar.SelectedIndex == 2))
            {
                Erros = ValidaParData();

                if (Erros.Length > 0)
                {
                    MessageBox.Show("Verifique A Data OK");

                    return;
                }
            }

            if ((cbPesquisar.SelectedIndex == 3) || (cbPesquisar.SelectedIndex == 4))
            {
                edPesquisar.Text = ".";
            }


            loadDocumentos();
        }


        //GridView

        private void DbGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            {
                try
                {

                    Id = Convert.ToInt32(((DataGridView)sender)[0, e.RowIndex].Value);

                }
                catch (Exception exc)
                {
                    Id = 0;
                }

            }
        }

        private void DbGridView_DoubleClick(object sender, EventArgs e)
        {

            tbBrowser.PerformClick();

        }

        private void ConfiguraDbDridView()
        {
            dbGridView.AutoResizeColumns();
            dbGridView.Columns[00].HeaderText = "ID";
            dbGridView.Columns[00].Width = 80;
            dbGridView.Columns[00].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.Columns[01].HeaderText = "TIPO";
            dbGridView.Columns[01].Width = 50;
            dbGridView.Columns[01].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.Columns[02].HeaderText = "DOC";
            dbGridView.Columns[02].Width = 100;
            dbGridView.Columns[02].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.Columns[03].HeaderText = "SERIE";
            dbGridView.Columns[03].Width = 50;
            dbGridView.Columns[03].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.Columns[04].HeaderText = "PARCELA";
            dbGridView.Columns[04].Width = 60;
            dbGridView.Columns[04].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.Columns[05].HeaderText = "CLI/FOR";
            dbGridView.Columns[05].Width = 80;
            dbGridView.Columns[05].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridView.Columns[06].HeaderText = "RAZAO";
            dbGridView.Columns[06].Width = 300;
            dbGridView.Columns[06].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dbGridView.Columns[07].HeaderText = "CONTA";
            dbGridView.Columns[07].Width = 100;
            dbGridView.Columns[07].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.Columns[08].HeaderText = "DESCRICAO";
            dbGridView.Columns[08].Width = 200;
            dbGridView.Columns[08].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dbGridView.Columns[09].HeaderText = "EMISSÃO";
            dbGridView.Columns[09].Width = 80;
            dbGridView.Columns[09].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.Columns[10].HeaderText = "VENCIMENTO";
            dbGridView.Columns[10].Width = 80;
            dbGridView.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridView.Columns[11].HeaderText = "VALOR";
            dbGridView.Columns[11].Width = 100;
            dbGridView.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridView.Columns[12].HeaderText = "ABATIMENTO";
            dbGridView.Columns[12].Width = 100;
            dbGridView.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridView.Columns[13].HeaderText = "JUROS";
            dbGridView.Columns[13].Width = 100;
            dbGridView.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridView.Columns[14].HeaderText = "VLR PAGO";
            dbGridView.Columns[14].Width = 100;
            dbGridView.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridView.Columns[15].HeaderText = "SALDO";
            dbGridView.Columns[15].Width = 100;
            dbGridView.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridView.Columns[16].HeaderText = "OBS";
            dbGridView.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dbGridView.Columns[16].Width = 200;

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

                daoDocumento dao = new daoDocumento();

                string strSelect = dao.SqlGridBrowse(Ordenacao, edPesquisar.Text.Trim(), tpCbCliFor.SelectedIndex >= 0 ? tpCbCliFor.SelectedItem.ToString() : "");

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


            if (!Validacoes.IsTamanho(documento.Doc, 1, 9))
            {
                Result += "Tamanho do Campo Documento Deve Ficar Entre 1 e 9 !\n";
            }

            if (!Validacoes.NoZero(documento.Clifor))
            {
                Result += "Tamanho do Campo Cliente/Fornecedor É Obrigatório !\n";
            }

            Result += ValidaDatas();

            if (!Validacoes.NoZero(documento.Valor))
            {
                Result += "Campo Valor É Obrigatório !\n";
            }

            if (documento.Abatimento < 0)
            {
                Result += "Campo Abatimento Não Poderá Ser Menor Que Zero !\n";
            }

            if (documento.Juros < 0)
            {
                Result += "Campo Juros Não Poderá Ser Menor Que Zero !\n";
            }


            if (!Validacoes.IsTamanho(documento.Obs, 0, 30))
            {
                Result += "Tamanho do Campo Observação Deve Ter No Máximo 30 !\n";
            }

            return Result;

        }

        private string ValoresOK()
        {
            string Result = "";


            if (documento.Valor < 0 )
            {
                Result += "Campo Valor É Obrigatório !\n";
            }

            if (documento.Abatimento < 0)
            {
                Result += "Campo Abatimento Não Poderá Ser Menor Que Zero !\n";
            }

            if (documento.Juros < 0)
            {
                Result += "Campo Juros Não Poderá Ser Menor Que Zero !\n";
            }



            return Result;

        }

        private void Atualiza()
        {

            int id = cbTipo.FindString(documento.Tipo);
            int idx = -1;
            if (documento.Tipo == "R")
            {
                idx = lsClientes.FindIndex(cl => cl.Codigo == documento.Clifor);
            }
            else
            {
                idx = lsFornecedores.FindIndex(fr => fr.Codigo == documento.Clifor);
            }
            txtId.Text = documento.Id.ToString();
            cbTipo.SelectedIndex = id;
            txtDocumento.Text = documento.Doc;
            txtSerie.Text = documento.Serie;
            txtParcela.Text = documento.Parcela;
            cbCliFor.SelectedIndex = idx;
            txtConta.Text = $"{documento._Cod_Conta}-{documento._Conta}";
            txtEmissao.Text = documento.Emissao?.ToString("dd/MM/yy");
            txtVencimento.Text = documento.Vencimento?.ToString("dd/MM/yy");
            txtValor.Text = string.Format("{0:0.00}", documento.Valor);
            txtAbatimento.Text = string.Format("{0:0.00}", documento.Abatimento);
            txtJuros.Text = string.Format("{0:0.00}", documento.Juros); 
            txtVlrPago.Text = string.Format("{0:0.00}", documento.VlrPago); 
            txtSaldo.Text = string.Format("{0:0.00}", documento.Saldo); 
            txtObs.Text = documento.Obs.Trim();
        }


        //Formulario

        private void PopularDoc()
        {
            documento.Tipo = cbTipo.SelectedItem.ToString().Substring(0, 1);
            if (cbCliFor.SelectedIndex < 0 )
            {
                cbCliFor.SelectedIndex = 0;
            }
            int cod = cbCliFor.SelectedItem.ToString().Substring(0, 6).IntParse();
            documento.Id = txtId.Text.IntParse();
            documento.Doc = txtDocumento.Text;
            documento.Serie = txtSerie.Text;
            documento.Parcela = txtParcela.Text;
            documento.Clifor = cod;
            documento.Emissao = Convert.ToDateTime(txtEmissao.Text).Date;
            documento.Vencimento = Convert.ToDateTime(txtVencimento.Text).Date;
            documento.Valor = txtValor.Text.DoubleParse(); ;
            documento.Abatimento = txtAbatimento.Text.DoubleParse();
            documento.Juros = txtJuros.Text.DoubleParse();
            documento.VlrPago = txtVlrPago.Text.DoubleParse();
            documento.Saldo = txtSaldo.Text.DoubleParse();
            documento.Obs = txtObs.Text;
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
                    tpCbCliFor.Visible = true;
                    tbBrowser.Visible = true;
                    tbIncluir.Visible = false;
                    tbEditar.Visible = false;
                    tbDelete.Visible = false;
                    tbOk.Visible = false;
                    tbCancelar.Visible = false;
                    tbBaixar.Visible = false;
                    lbPesquisar.Visible = true;
                    cbPesquisar.Visible = true;
                    edPesquisar.Visible = true;
                    btBuscar.Visible = true;
                    break;
                case Visoes.Consulta:
                    tpCbCliFor.Visible = false;
                    tbBrowser.Visible = true;
                    tbIncluir.Visible = true;
                    tbEditar.Visible = true;
                    tbDelete.Visible = true;
                    tbOk.Visible = false;
                    tbCancelar.Visible = false;
                    tbBaixar.Visible = true;
                    lbPesquisar.Visible = false;
                    cbPesquisar.Visible = false;
                    edPesquisar.Visible = false;
                    btBuscar.Visible = false;
                    SetarProperties(false);
                    break;

                case Visoes.Edicao:
                    tpCbCliFor.Visible = false;
                    tbBrowser.Visible = false;
                    tbIncluir.Visible = false;
                    tbEditar.Visible = false;
                    tbDelete.Visible = false;
                    tbOk.Visible = true;
                    tbCancelar.Visible = true;
                    tbBaixar.Visible = false;
                    lbPesquisar.Visible = false;
                    cbPesquisar.Visible = false;
                    edPesquisar.Visible = false;
                    btBuscar.Visible = false;
                    SetarProperties(true);
                    txtDocumento.Focus();
                    break;
                case Visoes.Nova:
                    tpCbCliFor.Visible = false;
                    tbBrowser.Visible = false;
                    tbIncluir.Visible = false;
                    tbEditar.Visible = false;
                    tbDelete.Visible = false;
                    tbOk.Visible = true;
                    tbCancelar.Visible = true;
                    tbBaixar.Visible = false;
                    lbPesquisar.Visible = false;
                    cbPesquisar.Visible = false;
                    edPesquisar.Visible = false;
                    btBuscar.Visible = false;
                    SetarProperties(true);
                    txtDocumento.Focus();
                    break;

            }
        }

        private void CbPesquisar_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Ordenacao = cbPesquisar.SelectedIndex;

            loadDocumentos();
        }



        private void FormUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Enabled = true;
        }

        private void FormUsuarios_Activated(object sender, EventArgs e)
        {
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void gbSenha_Enter(object sender, EventArgs e)
        {

        }

        private String ValidaDatas()
        {
            String cRetorno = "";

            bool dataValida;

            DateTime data;

            DateTime Emissao = DateTime.Now;

            DateTime Venc = DateTime.Now;

            dataValida = DateTime.TryParseExact(txtEmissao.Text, "dd/MM/yy", CultureInfo.InvariantCulture,
                                                     DateTimeStyles.None, out data);

            if (!dataValida)
            {
                cRetorno += "Data Emissão Inválida !! \n";
            }
            else
            {
                Emissao = data;
            }

            dataValida = DateTime.TryParseExact(txtVencimento.Text, "dd/MM/yy", CultureInfo.InvariantCulture,
                                                     DateTimeStyles.None, out data);


            if (!dataValida)
            {
                cRetorno += "Data Vencimento Inválida !! \n";
            }
            else
            {
                Venc = data;
            }

            if (cRetorno == "")
            {
                if (Venc.CompareTo(Emissao) < 0)
                {
                    cRetorno += "Data Venc. Deverá Ser Igual Ou Posterior A Data Emissão! \n";
                }
            }

            return cRetorno;
        }

        private String ValidaParData()
        {
            String cRetorno = "";

            bool dataValida;

            DateTime data;

            dataValida = DateTime.TryParseExact(edPesquisar.Text, "dd/MM/yy", CultureInfo.InvariantCulture,
                                                     DateTimeStyles.None, out data);

            if (!dataValida)
            {
                cRetorno += "Data Pesquisa Inválida !! \n";
            }

            return cRetorno;
        }

        private void IsDoubleEntry(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 44 && ((TextBox)sender).Text.IndexOf(",") != -1)
            {

                e.Handled = true;

                return;

            }

            if (!Char.IsDigit(ch) && ch != 8 && ch != 44)
            {

                e.Handled = true;
            }


        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

            cbCliFor.Items.Clear();

            if (cbTipo.SelectedItem.ToString().Substring(0, 1) == "R")
            {
                lsClientes.ForEach(cliente =>
                {
                    cbCliFor.Items.Add($"{cliente.Codigo.ToString("000000")}-{cliente.Razao}");
                });
            }
            else
            {
                lsFornecedores.ForEach(fornece =>
                {
                    cbCliFor.Items.Add($"{fornece.Codigo.ToString("000000")}-{fornece.Razao}");
                });
            }

            cbCliFor.SelectedIndex = 0;
        }

        private void cbCliFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCliFor.SelectedIndex < 0)
            {
                txtConta.Text = "";
            }
            else
            {
                if (cbTipo.SelectedItem.ToString().Substring(0, 1) == "R")
                {
                    Cliente cliente = lsClientes[cbCliFor.SelectedIndex];
                    txtConta.Text = $"{cliente.Conta}-{cliente._ContaDesc}";
                }
                else
                {
                    Fornecedor fornecedor = lsFornecedores[cbCliFor.SelectedIndex];
                    txtConta.Text = $"{fornecedor.Conta}-{fornecedor._ContaDesc}";
                }
            }
        }

        private void tbBaixar_Click(object sender, EventArgs e)
        {
            var form = new formBaixas(documento.IdEmpresa, documento.Id);

                       
            try
            {
                form.ShowDialog();

            }
            finally
            {
                form.Dispose();

                daoDocumento dao = new daoDocumento();

                documento = dao.Seek(1, Id);

                if (documento == null)
                {

                    documento = new Documento();

                    documento.Zerar();

                    visao = Visoes.Nova;

                }

                Atualiza();

                loadDocumentos();
            } 
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtValor_Leave(object sender, EventArgs e)
        {
            CalcularSaldo();
        }

        private void CalcularSaldo()
        {
            PopularDoc();

            string Erros = ValoresOK();

            if (Erros != "")
            {

                MessageBox.Show(Erros);

                return;

            }

            documento.Saldo = (documento.Valor - documento.Abatimento + documento.Juros) - documento.VlrPago;

            Atualiza();
        }
    }
}
