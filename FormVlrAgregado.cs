using Fluxo_De_Caixa.Dao.postgre;
using Fluxo_De_Caixa.Extensoes;
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

            string[] parametro = cbMes.Text.Split('/');

            List<Lucro> lsLucro = dao.getLucro(parametro[1], parametro[0]);

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
            dbGridView.Columns[01].Width = 90;
            dbGridView.Columns[01].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.Columns[02].HeaderText = "CODIGO";
            dbGridView.Columns[02].Width = 60;
            dbGridView.Columns[02].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridView.Columns[03].HeaderText = "RAZAO";
            dbGridView.Columns[03].Width = 400;
            dbGridView.Columns[03].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dbGridView.Columns[04].HeaderText = "ENTRADA";
            dbGridView.Columns[04].Width = 120;
            dbGridView.Columns[04].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridView.Columns[05].HeaderText = "AGREGADO";
            dbGridView.Columns[05].DefaultCellStyle.ForeColor = Color.Blue;
            dbGridView.Columns[05].Width = 120;
            dbGridView.Columns[05].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridView.Columns[06].HeaderText = "SAIDA";
            dbGridView.Columns[06].DefaultCellStyle.ForeColor = Color.Red;
            dbGridView.Columns[06].Width = 120;
            dbGridView.Columns[06].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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

        private void tbCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbExcel_Click(object sender, EventArgs e)
        {
            if ((dbGridView.Rows.Count == 1) && (dbGridView.Rows[0].Cells[0].Value.ToString().Trim() == ""))
            {
                MessageBox.Show("Nenhum Erro Registrado!", "ERRO");

                return;
            }

            tbExcel.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < ((dbGridView.Columns.Count + 1) <= 500 ? dbGridView.Columns.Count + 1 : 500); i++)
                {
                    xcelApp.Cells[1, i] = dbGridView.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dbGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dbGridView.Columns.Count; j++)
                    {
                        if (j >= 4)
                        {
                            if (dbGridView.Rows[i].Cells[j].Value.ToString().Trim() == "")
                            {
                                xcelApp.Cells[i + 2, j + 1] = dbGridView.Rows[i].Cells[j].Value.ToString();

                            } else
                            {
                                double valor = dbGridView.Rows[i].Cells[j].Value.ToString().DoubleParse();
                                xcelApp.Cells[i + 2, j + 1] = valor;
                            }
                            
                        }
                        else
                        {
                            if (dbGridView.Rows[i].Cells[j].Value.GetType().Name == "String")
                            {
                                xcelApp.Cells[i + 2, j + 1] = dbGridView.Rows[i].Cells[j].Value.ToString();
                            }
                            else if (dbGridView.Rows[i].Cells[j].Value.GetType().Name == "Double")
                            {
                                double valor = dbGridView.Rows[i].Cells[j].Value.ToString().DoubleParse();

                                xcelApp.Cells[i + 2, j + 1] = valor;
                            }
                            else if (dbGridView.Rows[i].Cells[j].Value.GetType().Name == "int32")
                            {
                                int valor = dbGridView.Rows[i].Cells[j].Value.ToString().IntParse();

                                xcelApp.Cells[i + 2, j + 1] = valor;
                            }
                            else
                            {
                                xcelApp.Cells[i + 2, j + 1] = dbGridView.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
                tbExcel.Enabled = true;
            }
            finally
            {
                tbExcel.Enabled = true;
                this.Cursor = Cursors.Arrow;
            }
        }
    }
}
