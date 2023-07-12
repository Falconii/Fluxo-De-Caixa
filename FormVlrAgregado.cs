using Fluxo_De_Caixa.Dao.postgre;
using Fluxo_De_Caixa.Models;
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
    public partial class FormVlrAgregado : Form
    {
        public ToolStripMenuItem menu { get; internal set; }

        List<string> lsMeses = new List<string>();

        public FormVlrAgregado()
        {
            InitializeComponent();
        }

        private void FormVlrAgregado_Load(object sender, EventArgs e)
        {
            int idx = 0;

            DateTime Hoje = DateTime.Now;

            loadMeses();

            idx = lsMeses.IndexOf(Hoje.ToString("MM/yyyy"));

            cbMes.SelectedIndex = idx == -1 ? 0 : idx;
        }

        private void FormFluxo_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Enabled = true;
        }

        private void FormFluxo_Activated(object sender, EventArgs e)
        {
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void loadMeses()
        {
             
            daoDocumento dao = new daoDocumento();

            lsMeses.Clear();

            lsMeses = dao.MesesAtivos();

            lsMeses.ForEach(mes => { cbMes.Items.Add(mes); });

        }

        private void loadVlrAgregado()
        {
            daoCabOS dao = new daoCabOS();

            List<Lucro> lsLucro = dao.getLucro("2023","07");

            dbGridView.DataSource = lsLucro;

            ConfiguraDbDridView();


        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            loadVlrAgregado();
        }

        private void loadFluxo()
        {
     

        }

        private void ConfiguraDbDridView()
        {
            dbGridView.AutoResizeColumns();
            dbGridView.Columns[00].HeaderText = "DATA";
            dbGridView.Columns[00].Width = 80;
            dbGridView.Columns[00].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.Columns[01].HeaderText = "DOC.";
            dbGridView.Columns[01].Width = 50;
            dbGridView.Columns[01].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.Columns[02].HeaderText = "CLI/FOR";
            dbGridView.Columns[02].Width = 60;
            dbGridView.Columns[02].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridView.Columns[03].HeaderText = "RAZAO";
            dbGridView.Columns[03].Width = 400;
            dbGridView.Columns[03].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dbGridView.Columns[04].HeaderText = "ENTRADA";
            dbGridView.Columns[04].DefaultCellStyle.ForeColor = Color.Red;
            dbGridView.Columns[04].Width = 120;
            dbGridView.Columns[04].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridView.Columns[05].HeaderText = "AGREGADO";
            dbGridView.Columns[05].DefaultCellStyle.ForeColor = Color.Blue;
            dbGridView.Columns[05].Width = 120;
            dbGridView.Columns[05].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridView.Columns[16].HeaderText = "SAIDA";
            dbGridView.Columns[16].Width = 120;
            dbGridView.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dbGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.BorderStyle = BorderStyle.Fixed3D;
            dbGridView.EnableHeadersVisualStyles = false;

            dbGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(dbGridView_FormatarSaldo);

        }

        private void dbGridView_FormatarSaldo(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dbGridView.Columns[e.ColumnIndex].Name.ToUpper().Equals("SALDO"))
            {
                double value = 0;
                try
                {
                    value = Convert.ToDouble(dbGridView.Rows[e.RowIndex].Cells[10].Value.ToString());
                }
                catch
                {
                    value = 0;
                }

                if (value >= 0)
                {
                    e.CellStyle.ForeColor = Color.Blue;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Red;
                }

            }
        }

    }
}
