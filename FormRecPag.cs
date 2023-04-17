using Fluxo_De_Caixa.Dao.postgre;
using Fluxo_De_Caixa.Extensoes;
using Fluxo_De_Caixa.Models;
using Fluxo_De_Caixa.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Fluxo_De_Caixa
{
    public partial class FormRecPag : Form
    {
        private List<Cliente> lsClientes = new List<Cliente>();
        private List<Fornecedor> lsFornecedores = new List<Fornecedor>();
        private List<RegPag> lsRecPag = new List<RegPag>();
        public ToolStripMenuItem menu { get; internal set; }
        public FormRecPag()
        {
            InitializeComponent();
        }

        private void FormRecPag_Load(object sender, EventArgs e)
        {
            loadClientes();
            loadFornecedores();
            cbTipo.SelectedIndex = 0;
            cbSituacao.SelectedIndex = 0;
        }

        private void ConfiguraDbDridView()
        {
            dbGridView.AutoResizeColumns();
            dbGridView.Columns[00].HeaderText = "VENCIMENTO";
            dbGridView.Columns[00].Width = 80;
            dbGridView.Columns[00].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.Columns[01].HeaderText = "DOC.";
            dbGridView.Columns[01].Width = 50;
            dbGridView.Columns[01].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridView.Columns[02].HeaderText = "SERIE";
            dbGridView.Columns[02].Width = 100;
            dbGridView.Columns[02].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.Columns[03].HeaderText = "PARC.";
            dbGridView.Columns[03].Width = 50;
            dbGridView.Columns[03].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.Columns[04].HeaderText = "EMISSÃO";
            dbGridView.Columns[04].Width = 80;
            dbGridView.Columns[04].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.Columns[05].HeaderText = "CLI/FOR";
            dbGridView.Columns[05].Width = 60;
            dbGridView.Columns[05].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridView.Columns[06].HeaderText = "RAZAO";
            dbGridView.Columns[06].Width = 400;
            dbGridView.Columns[06].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dbGridView.Columns[07].HeaderText = "CONTA";
            dbGridView.Columns[07].Width = 120;
            dbGridView.Columns[07].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.Columns[08].HeaderText = "OBS";
            dbGridView.Columns[08].Width = 120;
            dbGridView.Columns[08].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.Columns[09].HeaderText = "VALOR";
            dbGridView.Columns[09].DefaultCellStyle.Format = "N2";
            dbGridView.Columns[09].Width = 120;
            dbGridView.Columns[09].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridView.Columns[10].HeaderText = "ABATIMENTO";
            dbGridView.Columns[10].DefaultCellStyle.Format = "N2";
            dbGridView.Columns[10].Width = 120;
            dbGridView.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridView.Columns[11].HeaderText = "JUROS";
            dbGridView.Columns[11].DefaultCellStyle.Format = "N2";
            dbGridView.Columns[11].Width = 120;
            dbGridView.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridView.Columns[12].HeaderText = "SALDO";
            dbGridView.Columns[12].DefaultCellStyle.Format = "N2";
            dbGridView.Columns[12].Width = 120;
            dbGridView.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridView.Columns[13].HeaderText = "TOTAL";
            dbGridView.Columns[13].DefaultCellStyle.Format = "N2";
            dbGridView.Columns[13].Width = 120;
            dbGridView.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dbGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.BorderStyle = BorderStyle.Fixed3D;
            dbGridView.EnableHeadersVisualStyles = false;
            dbGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(dbGridView_FormatarTotal);

        }

        private void dbGridView_FormatarTotal(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dbGridView.Columns[e.ColumnIndex].Name.Equals("total"))
            {
                if (cbTipo.SelectedIndex == 0)
                {
                    e.CellStyle.ForeColor = Color.Blue;
                } else
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void loadClientes()
        {
            Cliente cliente = new Cliente();

            cliente.Codigo = 0;
            
            cliente.Razao = "Todos Os Clientes";

            daoCliente dao = new daoCliente();

            lsClientes = dao.getAll(1, "");

            lsClientes.Insert(0,cliente);

        }

        private void loadFornecedores()
        {
            Fornecedor fornecedor = new Fornecedor();

            fornecedor.Codigo = 0;

            fornecedor.Razao = "Todos Os Fornecedores";

            daoFornecedor dao = new daoFornecedor();

            lsFornecedores = dao.getAll(1, "");

            lsFornecedores.Insert(0, fornecedor);

        }

        private void loadDocs()
        {
            Parametro_01 par = new Parametro_01();

            par.Tipo = cbTipo.SelectedItem.ToString().Substring(0, 1);

            par.ClirFor = cbCliFor.SelectedItem.ToString().Substring(0, 6).IntParse();

            par.Inicial = dtInicial.Value;

            par.Final = dtFinal.Value;

            par.Situacao = cbSituacao.SelectedIndex;

            daoDocumento dao = new daoDocumento();

            lsRecPag = dao.GetRegPag(par);

            dbGridView.DataSource = lsRecPag;

            ConfiguraDbDridView();
        }

        private void FormRecPag_Activated(object sender, EventArgs e)
        {
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void FormRecPag_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Enabled = true;
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

        private void btBuscar_Click(object sender, EventArgs e)
        {

            loadDocs();

        }

        private void cbSituacao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
