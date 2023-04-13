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
    public partial class formBaixas : Form
    {
        Visoes visao = Visoes.Consulta;

        Documento documento = new Documento();

        int Ordenacao = 1; //Id_doc 

        int Id = 0;

        string proprietario = "Documento";

        int id_empresa = 1;

        int id_doc = 0;

        Baixa baixa = new Baixa();

        List<Baixa> lsBaixas = new List<Baixa>();
        
        int IdxRow = -1;

        public ToolStripMenuItem menu { get; internal set; }

        public formBaixas(int _id_empresa, int _id_doc)
        {
            InitializeComponent();
            id_empresa = _id_empresa;
            id_doc = _id_doc;
            loadDoc(id_empresa, id_doc);
            loadBaixas();
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            loadBaixas();
            SetarVisoes();
        }

        private void SetarProperties(bool value)
        {
            txtId.Enabled = false;
            cbTipo.Enabled = value;
            txtDocumento.Enabled = value;
            txtSerie.Enabled = value;
            txtParcela.Enabled = value;

            txtCliFor.Enabled = value;

            txtEmissao.Enabled = value;
            txtVencimento.Enabled = value;

            txtValor.Enabled = value;
            txtAbatimento.Enabled = value;
            txtJuros.Enabled = value;
            txtVlrPago.Enabled = value;
            txtSaldo.Enabled = value;

            txtSerie.CharacterCasing = CharacterCasing.Upper;
            txtParcela.CharacterCasing = CharacterCasing.Upper;
            txtDocumento.MaxLength = 9;
            txtSerie.MaxLength = 3;
            txtParcela.MaxLength = 3;

        }

        private void loadBaixas()
        {
            preencheDataGridView();

        }


        private void loadDoc(int id_empresa, int id)
        {
            daoDocumento dao = new daoDocumento();

            documento = dao.Seek(id_empresa, id_doc);

            Atualiza();

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

                daoBaixa dao = new daoBaixa();


                switch (visao)
                {

                    case Visoes.Nova:
                        /*
                        documento.UserInsert = UsuarioSistema.Usuario.Codigo;

                        Documento retorno = dao.Insert(documento);

                        if (retorno != null)
                        {

                            MessageBox.Show($"Documento Incluído No Código {retorno.Id}","Atenção!",MessageBoxButtons.OK,MessageBoxIcon.Information);

                        }
                        else
                        {

                            MessageBox.Show($"Falha Na Inclusão Do Documento!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);


                        }

                        visao = Visoes.Browser;

                        loadBaixas();

                        SetarVisoes();
                        */
                        break;

                    case Visoes.Edicao:
                        /*
                        documento.UserUpdate= UsuarioSistema.Usuario.Codigo;

                        dao.Update(documento);

                        MessageBox.Show($"Documento Alterado Com Sucesso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        visao = Visoes.Browser;

                        loadDocumentos();

                        SetarVisoes();
                        */
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
            Close();
        }
        private void CbPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void BtBuscar_Click(object sender, EventArgs e)
        {

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



        }

        private void ConfiguraDbDridView()
        {
            dbGridView.AutoResizeColumns();
            dbGridView.Columns[00].HeaderText = "ID";
            dbGridView.Columns[00].Width = 80;
            dbGridView.Columns[00].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.Columns[00].ReadOnly = true;
            dbGridView.Columns[01].HeaderText = "ID_DOC";
            dbGridView.Columns[01].Width = 50;
            dbGridView.Columns[01].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.Columns[01].ReadOnly = true;
            dbGridView.Columns[02].HeaderText = "EMISSÃO";
            dbGridView.Columns[02].Width = 100;
            dbGridView.Columns[02].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.Columns[03].HeaderText = "VALOR";
            dbGridView.Columns[03].Width = 150;
            dbGridView.Columns[03].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridView.Columns[04].HeaderText = "OBS";
            dbGridView.Columns[04].Width = 60;
            dbGridView.Columns[04].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dbGridView.Columns[04].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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

                daoBaixa dao = new daoBaixa();

                string strSelect = dao.SqlGridBrowse(Ordenacao, documento.Id.ToString());

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
                Result += "Tamanho do Campo Valor É Obrigatório !\n";
            }

            if (documento.Abatimento < 0)
            {
                Result += "Tamanho do Campo Abatimento Não Poderá Ser Menor Que Zero !\n";
            }

            if (documento.Juros < 0)
            {
                Result += "Tamanho do Campo Juros Não Poderá Ser Menor Que Zero !\n";
            }


            if (!Validacoes.IsTamanho(documento.Obs, 0, 30))
            {
                Result += "Tamanho do Campo Observação Deve Ter No Máximo 30 !\n";
            }

            return Result;

        }

        private void Atualiza()
        {

            int id = cbTipo.FindString(documento.Tipo);
            txtId.Text = documento.Id.ToString();
            cbTipo.SelectedIndex = id;
            txtDocumento.Text = documento.Doc;
            txtSerie.Text = documento.Serie;
            txtParcela.Text = documento.Parcela;
            txtCliFor.Text = documento.Razao;
            txtEmissao.Text = documento.Emissao?.ToString("dd/MM/yyyy");
            txtVencimento.Text = documento.Vencimento?.ToString("dd/MM/yyyy");
            txtValor.Text = documento.Valor.DoubleParseDb();
            txtAbatimento.Text = documento.Abatimento.DoubleParseDb();
            txtJuros.Text = documento.Juros.DoubleParseDb();
            txtVlrPago.Text = documento.VlrPago.DoubleParseDb();
            txtSaldo.Text = documento.Saldo.DoubleParseDb();
        }


        //Formulario

        private void PopularDoc()
        {
            /*
            int cod = cbCliFor.SelectedItem.ToString().Substring(0, 6).IntParse();
            documento.Id         = txtId.Text.IntParse();
            documento.Tipo       = cbTipo.SelectedItem.ToString().Substring(0, 1);
            documento.Doc        = txtDocumento.Text;
            documento.Serie      = txtSerie.Text;
            documento.Parcela    = txtParcela.Text;
            documento.Clifor     = cod;
            documento.Emissao    = Convert.ToDateTime(txtEmissao.Text).Date; 
            documento.Vencimento = Convert.ToDateTime(txtEmissao.Text).Date; 
            documento.Valor      = txtValor.Text.DoubleParse(); ;
            documento.Abatimento = txtAbatimento.Text.DoubleParse();
            documento.Juros      = txtJuros.Text.DoubleParse();
            documento.VlrPago    = txtVlrPago.Text.DoubleParse(); 
            documento.Saldo      = txtSaldo.Text.DoubleParse(); 
            */
        }

        private void SetarVisoes()
        {

            switch (visao)
            {

                case Visoes.Browser:
                    tabControl.Visible = true;
                    dbGridView.ReadOnly = false;
                    dbGridView.Visible = true;
                    SetarBotoes();
                    break;
                case Visoes.Consulta:
                    tabControl.Visible = true;
                    dbGridView.ReadOnly = false;
                    dbGridView.Visible = true;
                    tabControl.SelectedIndex = 0;
                    SetarBotoes();
                    break;
                case Visoes.Edicao:
                    tabControl.Visible = true;
                    dbGridView.ReadOnly = false;
                    dbGridView.Visible = true;
                    SetarBotoes();
                    break;
                case Visoes.Nova:
                    tabControl.Visible = true;
                    dbGridView.ReadOnly = false;
                    dbGridView.Visible = true;
                    SetarBotoes();
                    break;

            }

        }

        private void SetarBotoes()
        {

            switch (visao)
            {
                case Visoes.Consulta:
                    tbVoltar.Visible = true;
                    SetarProperties(false);
                    break;
                case Visoes.Edicao:
                    tbVoltar.Visible = true;
                    SetarProperties(true);
                    break;
            }
        }

        private void CbPesquisar_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }



        private void FormUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void FormUsuarios_Activated(object sender, EventArgs e)
        {

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

            dataValida = DateTime.TryParseExact(txtEmissao.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                                                     DateTimeStyles.None, out data);

            if (!dataValida)
            {
                cRetorno += "Data Emissão Inválida !! \n";
            }
            else
            {
                Emissao = data;
            }

            dataValida = DateTime.TryParseExact(txtVencimento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture,
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


        }

        private void cbCliFor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbBaixar_Click(object sender, EventArgs e)
        {



        }

        private void tbOK_Click_1(object sender, EventArgs e)
        {
            /*
            if (dbGridView.Rows[IdxRow].IsNewRow)
            {
                MessageBox.Show("Termine A Edição Antes De Gravar", "Atenção!");

                return;
            }
            */

            lsBaixas.Clear();

            try
            {
                Nullable<DateTime> emissao_baixa = null;
                Double valor_baixa = 0;
                string obs_baixa = "";
                Baixa bx = new Baixa();

                for (int idx = 0; idx < dbGridView.Rows.Count - 1; idx++)
                {
                    try
                    {
                        emissao_baixa = Convert.ToDateTime(dbGridView.Rows[idx].Cells[2].Value);
                    }
                    catch (Exception ex)
                    {
                        emissao_baixa = null;
                    }

                    if (emissao_baixa == null) continue;

                    valor_baixa = Convert.ToDouble(dbGridView.Rows[idx].Cells[3].Value);


                    obs_baixa = dbGridView.Rows[idx].Cells[4].Value.ToString();


                    bx = new Baixa();

                    bx.IdEmpresa = documento.IdEmpresa;
                    bx.Id = 0;
                    bx.Id_Doc = documento.Id;
                    bx.Emissao = emissao_baixa;
                    bx.Valor = valor_baixa;
                    bx.Obs = obs_baixa;
                    bx.UserInsert = UsuarioSistema.Usuario.Codigo;

                    lsBaixas.Add(bx);

                }

                daoBaixa dao = new daoBaixa();

                dao.DeleteByDoc(documento.IdEmpresa,documento.Id);

                lsBaixas.ForEach(obj => {

                    dao.Insert(obj);
                
                });

                MessageBox.Show("Baixas Atualizadas Com Sucesso!", "Atenção!");

                loadDoc(id_empresa, id_doc);

                loadBaixas();

                
                    
                
            }
            catch (Exception _)
            {
                MessageBox.Show("Deu Erro!!", "Atenção");
            }
        }

        private void dbGridView_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            IdxRow = e.RowIndex;
        }

        private void tbDelete_Click_1(object sender, EventArgs e)
        {

            if (dbGridView.Rows[IdxRow].IsNewRow) return;

            DialogResult resultado = MessageBox.Show($"Confirma A Exclusão ? {IdxRow}", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            switch (resultado)

            {


                case DialogResult.No:

                    break;

                case DialogResult.Yes:

                    if (!dbGridView.Rows[IdxRow].IsNewRow)
                    {
                        dbGridView.Rows.RemoveAt(IdxRow);
                    }

                    break;

                default:

                    break;

            }

        }

        private void txtValor_Leave(object sender, EventArgs e)
        {
           
        }

       
    }
}
