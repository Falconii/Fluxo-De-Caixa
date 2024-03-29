﻿using Fluxo_De_Caixa.Dao.postgre;
using Fluxo_De_Caixa.DataBase;
using Fluxo_De_Caixa.Models;
using Fluxo_De_Caixa.Util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fluxo_De_Caixa
{
    public enum Visoes { Browser, Consulta, Nova, Edicao, Exclusao, Help };

    public partial class FormPrincipal : Form
    {

        public static List<Estado> estados = new List<Estado>()
        {
            new Estado("AC-Acre"),
            new Estado("AL-Alagoas"),
            new Estado("AP-Amapá"),
            new Estado("AM-Amazonas"),
            new Estado("BA-Bahia"),
            new Estado("CE-Ceará"),
            new Estado("DF-Distrito Federal"),
            new Estado("ES-Espírito Santo"),
            new Estado("GO-Goiás"),
            new Estado("MA-Maranhão"),
            new Estado("MT-Mato Grosso"),
            new Estado("MS-Mato Grosso do Sul"),
            new Estado("MG-Minas Gerais"),
            new Estado("PA-Pará"),
            new Estado("PB-Paraíba"),
            new Estado("PR-Paraná"),
            new Estado("PE-Pernambuco"),
            new Estado("PI-Piauí"),
            new Estado("RJ-Rio de Janeiro"),
            new Estado("RN-Rio Grande do Norte"),
            new Estado("RS-Rio Grande do Sul"),
            new Estado("RO-Rondônia"),
            new Estado("RR-Roraima"),
            new Estado("SC-Santa Catarina"),
            new Estado("SP-São Paulo"),
            new Estado("SE-Sergipe"),
            new Estado("TO-Tocantins"),
            new Estado("  -         "),

        };




        public static Usuario usuario = new Usuario();
        private formUsuarios usuarios;
        private formClientes clientes;
        private formFornecedores fornecedores;
        private formContas contas;
        private formDocs docs;
        private FormFluxo fluxo;
        private FormRecPag recPag;
        private FormCar formCar;
        private FormOS formOS;
        private FormVlrAgregado VlrAgregado;

        public FormPrincipal(Usuario user)
        {
            usuario = user;

            UsuarioSistema.Usuario = user;

            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            this.Text = $"{this.Text} Usuário: {usuario.Razao.Trim()}  {RunCommand.Banco}" ;
            ControleColunas.LoadColunas000();
        }

        private void FimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var form in MdiChildren)
            {

                form.Close();

            }
            this.Close();
        }

      

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usuarios = new formUsuarios();

            ((System.Windows.Forms.ToolStripMenuItem)sender).Enabled = false;

            usuarios.MdiParent = this;

            usuarios.menu = (ToolStripMenuItem)sender;

            usuarios.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clientes = new formClientes();

            ((System.Windows.Forms.ToolStripMenuItem)sender).Enabled = false;

            clientes.MdiParent = this;

            clientes.menu = (ToolStripMenuItem)sender;

            clientes.Show();
        }

        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fornecedores = new formFornecedores();

            ((System.Windows.Forms.ToolStripMenuItem)sender).Enabled = false;

            fornecedores.MdiParent = this;

            fornecedores.menu = (ToolStripMenuItem)sender;

            fornecedores.Show();
        }

        private void contasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contas = new formContas();

            ((System.Windows.Forms.ToolStripMenuItem)sender).Enabled = false;

            contas.MdiParent = this;

            contas.menu = (ToolStripMenuItem)sender;

            contas.Show();
        }

        private void documentosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                loadClientes();

                loadFornecedores();

                docs = new formDocs();

                ((System.Windows.Forms.ToolStripMenuItem)sender).Enabled = false;

                docs.MdiParent = this;

                docs.menu = (ToolStripMenuItem)sender;

                docs.Show();

            } catch(Exception ex)
            {
                MessageBox.Show($"Erro:{ex.Message}", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fluxo = new FormFluxo();

            ((System.Windows.Forms.ToolStripMenuItem)sender).Enabled = false;

            fluxo.MdiParent = this;

            fluxo.menu = (ToolStripMenuItem)sender;

            fluxo.Show();
        }

        private void pagarReceberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            recPag = new FormRecPag();

            ((System.Windows.Forms.ToolStripMenuItem)sender).Enabled = false;

            recPag.MdiParent = this;

            recPag.menu = (ToolStripMenuItem)sender;

            recPag.Show();
        }

        private void automoveisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formCar = new FormCar();

            ((System.Windows.Forms.ToolStripMenuItem)sender).Enabled = false;

            formCar.MdiParent = this;

            formCar.menu = (ToolStripMenuItem)sender;

            formCar.Show();
        }

        private void condPagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void loadClientes()
        {
            List<Cliente> lsClientes = new List<Cliente>();

            daoCliente dao = new daoCliente();

            lsClientes = dao.getAll(1, "");

            if (lsClientes.Count == 0)
            {
                throw new Exception("Tabela De Clientes Vazia!");
            }

        }

        private void loadFornecedores()
        {
            List<Fornecedor> lsFornecedores = new List<Fornecedor>();

            daoFornecedor dao = new daoFornecedor();

            lsFornecedores = dao.getAll(1, "");

            if (lsFornecedores.Count == 0)
            {
                throw new Exception("Tabela De Fornecedores Vazia!");
            }

        }

        private void lançamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formOS = new FormOS();

            ((System.Windows.Forms.ToolStripMenuItem)sender).Enabled = false;

            formOS.MdiParent = this;

            formOS.menu = (ToolStripMenuItem)sender;

            formOS.Show();
        }

        private void valorAgregadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VlrAgregado = new FormVlrAgregado();

            ((System.Windows.Forms.ToolStripMenuItem)sender).Enabled = false;

            VlrAgregado.MdiParent = this;

            VlrAgregado.menu = (ToolStripMenuItem)sender;

            VlrAgregado.Show();
        }
    }
}
