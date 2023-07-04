using Fluxo_De_Caixa.Dao.postgre;
using Fluxo_De_Caixa.Models;
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
    public partial class FormOS : Form
    {

        Visoes visao = Visoes.Browser;

        CabOS cabOS = new CabOS();

        int Ordenacao = 0; //CODIGO 

        string proprietario = "Ordem De Derviço";

        Documento documento = new Documento();

        int Id = 0;

        List<Cliente> lsClientes = new List<Cliente>();

        List<Marca> lsMarcas = new List<Marca>();

        CarOS Car = new CarOS();

        bool NewCar = false;

        public ToolStripMenuItem menu { get; internal set; }

        public FormOS()
        {
            InitializeComponent();
        }

        private void FormCond_Load(object sender, EventArgs e)
        {
            tabPrincipal.AutoScroll = true;
            loadClientes();
            loadMarcas();
            SetartParametros();
            loadOS();
            SetarVisoes();
        }

        private void FormCond_Activated(object sender, EventArgs e)
        {
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void FormCond_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Enabled = true;
        }



        //Botoes da Barra
        private void TbBrowser_Click(object sender, EventArgs e)
        {
            switch (visao)
            {

                case Visoes.Browser:

                    visao = Visoes.Consulta;

                    daoCabOS dao = new daoCabOS();

                    cabOS = dao.Seek(1, Id);

                    if (cabOS == null)
                    {

                        cabOS = new CabOS();

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

            cabOS = new CabOS();

            documento.Zerar();

            Atualiza();

            SetarVisoes();
        }
        private void TbDelete_Click(object sender, EventArgs e)
        {
            string msg = "Confirma A Exclusão ?";

            DialogResult resultado = MessageBox.Show(msg, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            switch (resultado)

            {

                case DialogResult.No:

                    break;

                case DialogResult.Yes:

                    daoCabOS dao = new daoCabOS();

                    dao.Delete(cabOS);

                    loadOS();

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

                PopularOS();


                string Erros = Validacao();

                if (Erros != "")
                {

                    MessageBox.Show(Erros);

                    return;

                }

                daoCabOS dao = new daoCabOS();


                switch (visao)
                {

                    case Visoes.Nova:


                        cabOS.User_Insert = UsuarioSistema.Usuario.Codigo;

                        CabOS retorno = dao.Insert(cabOS);

                        if (retorno != null)
                        {

                            MessageBox.Show($"O.S. Incluída No Código {retorno.Id}", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {

                            MessageBox.Show($"Falha Na Inclusão Da O.S.!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);


                        }

                        visao = Visoes.Nova;

                        documento = new Documento();

                        Atualiza();

                        SetarVisoes();

                        break;

                    case Visoes.Edicao:

                        cabOS.User_Update = UsuarioSistema.Usuario.Codigo;

                        dao.Update(cabOS);

                        MessageBox.Show($"O.S. Alterada Com Sucesso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        visao = Visoes.Browser;

                        loadOS();

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

            loadOS();

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

            if ((cbPesquisar.SelectedIndex == 1) || (cbPesquisar.SelectedIndex == 2))
            {
                Erros = "";// ValidaParData();

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


            loadOS();
        }
        private void loadClientes()
        {
            daoCliente dao = new daoCliente();

            lsClientes = dao.getAll(1, "");

            if (lsClientes.Count == 0)
            {
                throw new Exception("Tabela De Clientes Vazia!");
            }

            cbCliente.Items.Clear();
            lsClientes.ForEach(cliente =>
            {
                cbCliente.Items.Add($"(C){cliente.Codigo.ToString("000000")}-{cliente.Razao}");
            });


        }
        private void loadMarcas()
        {
            daoMarca dao = new daoMarca();
            lsMarcas = dao.getAll(0, "");
            lsMarcas.ForEach(m => { txtMarca.Items.Add($"{m.Descricao}"); });
        }
        private void SetartParametros()
        {
            tpCbCliFor.Items.Clear();
            lsClientes.ForEach(cliente =>
            {
                tpCbCliFor.Items.Add($"(C){cliente.Codigo.ToString("000000")}-{cliente.Razao}");
            });
        }
        private void SetarProperties(bool value)
        {
            txtId.Enabled = false;
            txtEntrada.Enabled = value;
            txtSaida.Enabled = value;
            txtVlrMaoDeMaoDeObraCabec.Enabled = value;
            txtVlrDasPecasCabec.Enabled = value;
            txtValorOSCabec.Enabled = value;
            SetarPropertiesCar(value);
            txtHorasServico.Enabled = value;
            txtKM.Enabled = value;
            txtObs.Enabled = value;
            txtMaoDeObra.Enabled = value;
            txtVlrMaoDeObra.Enabled = value;

            /*
            txtSerie.CharacterCasing = CharacterCasing.Upper;
            txtParcela.CharacterCasing = CharacterCasing.Upper;
            txtObs.CharacterCasing = CharacterCasing.Upper;
            txtDocumento.MaxLength = 9;
            txtSerie.MaxLength = 3;
            txtParcela.MaxLength = 3;
            txtObs.MaxLength = 30;
            */
        }

        private void SetarPropertiesCar(bool value)
        {  
            txtPlaca.Enabled = value;
            txtMarca.SelectedIndex = index;
            txtModelo.Text = cabOS.Car_Modelo;
            txtCor.Text = cabOS.Car_Cor;
            txtAno.Text = cabOS.Car_Ano;
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
                    lblNovo.Visible = false;
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
                    lblNovo.Visible = false;
                    SetarProperties(true);
                    txtEntrada.Focus();
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
                    lblNovo.Visible = false;
                    SetarProperties(true);
                    txtEntrada.Focus();
                    break;

            }
        }
        private void loadOS()
        {
            preencheDataGridView();

        }
        private string Validacao()
        {
            string Result = "";
            /*

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
            */
            return Result;

        }
        private void PopularOS()
        {
            /*
            documento.Tipo = cbTipo.SelectedItem.ToString().Substring(0, 1);
            if (cbCliFor.SelectedIndex < 0)
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
            */
        }
        private void Atualiza()
        {

            int idx = -1;

            idx = lsClientes.FindIndex(cl => cl.Codigo == cabOS.Id_Cliente);

            cbCliente.SelectedIndex = idx;
            txtId.Text = cabOS.Id.ToString();
            txtEntrada.Text = documento.Emissao?.ToString("dd/MM/yy");
            txtSaida.Text = documento.Vencimento?.ToString("dd/MM/yy");
            txtVlrMaoDeMaoDeObraCabec.Text = string.Format("{0:0.00}", cabOS.Mao_Obra_Vlr);
            txtVlrDasPecasCabec.Text = string.Format("{0:0.00}", cabOS.Pecas_Vlr);
            txtValorOSCabec.Text = string.Format("{0:0.00}", cabOS._Total_OS);
            AtualizaCar();
            txtHorasServico.Text = cabOS.Horas_Servico;
            txtKM.Text = string.Format("{0:0.00}", cabOS.Km);
            txtObs.Text = cabOS.Obs.Trim();
            txtMaoDeObra.Text = cabOS.Mao_Obra.Trim();
            txtVlrMaoDeObra.Text = string.Format("{0:0}", cabOS.Mao_Obra_Vlr);
        }

        private void AtualizaCar()
        {
            int index = lsMarcas.FindIndex(m => m.Id == cabOS.Car_Id_Marca);
            txtPlaca.Text = cabOS.Car_Placa;
            txtMarca.SelectedIndex = index;
            txtModelo.Text = cabOS.Car_Modelo;
            txtCor.Text = cabOS.Car_Cor;
            txtAno.Text = cabOS.Car_Ano;

        }
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
            dbGridView.Columns[00].HeaderText = "OS";
            dbGridView.Columns[00].Width = 80;
            dbGridView.Columns[00].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.Columns[01].HeaderText = "CÓD CLIENTE";
            dbGridView.Columns[01].Width = 50;
            dbGridView.Columns[01].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.Columns[02].HeaderText = "RAZÃO SOCIAL";
            dbGridView.Columns[02].Width = 300;
            dbGridView.Columns[02].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dbGridView.Columns[03].HeaderText = "TELEFONE";
            dbGridView.Columns[03].Width = 150;
            dbGridView.Columns[03].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.Columns[04].HeaderText = "ENTRADA";
            dbGridView.Columns[04].Width = 80;
            dbGridView.Columns[04].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.Columns[05].HeaderText = "SAÍDA";
            dbGridView.Columns[05].Width = 80;
            dbGridView.Columns[05].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridView.Columns[06].HeaderText = "HRS SERVIÇO";
            dbGridView.Columns[06].Width = 100;
            dbGridView.Columns[06].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridView.Columns[07].HeaderText = "KM";
            dbGridView.Columns[07].Width = 100;
            dbGridView.Columns[07].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.Columns[08].HeaderText = "OBS";
            dbGridView.Columns[08].Width = 200;
            dbGridView.Columns[08].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dbGridView.Columns[09].HeaderText = "VLR M.O.";
            dbGridView.Columns[09].Width = 80;
            dbGridView.Columns[09].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridView.Columns[10].HeaderText = "VLR PÇA";
            dbGridView.Columns[10].Width = 80;
            dbGridView.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dbGridView.Columns[11].HeaderText = "PLACA";
            dbGridView.Columns[11].Width = 100;
            dbGridView.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dbGridView.Columns[12].HeaderText = "MARCA";
            dbGridView.Columns[12].Width = 100;
            dbGridView.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dbGridView.Columns[13].HeaderText = "MODELO";
            dbGridView.Columns[13].Width = 100;
            dbGridView.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dbGridView.Columns[14].HeaderText = "COR";
            dbGridView.Columns[14].Width = 100;
            dbGridView.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dbGridView.Columns[15].HeaderText = "ANO";
            dbGridView.Columns[15].Width = 100;
            dbGridView.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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

                daoCabOS dao = new daoCabOS();

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
        private void ImprimirOS()
        {
            daoCabOS daoCab = new daoCabOS();
            List<string> produtos = new List<string>();
            produtos.Add("Amortecedor da suspensão");
            produtos.Add("Anel de pistão");
            produtos.Add("Bomba elétrica de combustível para motores do Ciclo Otto");
            produtos.Add("Bronzina");
            produtos.Add("Buzina ou equipamento similar");
            produtos.Add("Lâmpada para veículos automotivos");
            produtos.Add("Pino e anel de trava (retenção)");
            produtos.Add("Pistão de liga leve de alumínio");
            produtos.Add("Baterias");
            produtos.Add("Terminal de direção");
            produtos.Add("Barra de direção");
            produtos.Add("Barra de ligação");
            produtos.Add("Terminal axial para veículos rodoviários automotores (componente da direção)");
            produtos.Add("Materiais de atrito para freios (lonas e pastilhas)");
            produtos.Add("Rodas automotivas");
            produtos.Add("Vidro de segurança laminado de para-brisas");
            produtos.Add("Vidro de segurança temperado");
            produtos.Add("Fluído de freio");
            produtos.Add("Catalisador");
            //Inclusao
            CabOS cab = new CabOS();
            cab.Id_Empresa = 1;
            cab.Id = 0;
            cab.Id_Cliente = 14;
            cab.Id_Carro = "BEE4R22";
            cab.Id_Cond = 0;
            cab.Horas_Servico = "07:25";
            cab.Km = 100000;
            cab.Obs = "OSBSERVAO IMPORTANTE";
            cab.Lucro = 100;
            cab.Mao_Obra = "Sobre este item\n" +
                            "Organiza a montagem do seu quebra-cabeça\n " +
                            "Contém seis bandejas\n " +
                            "Armazena até duas mil peças\n " +
                            "Número de jogadores: 1 ou mais ";
            cab.Mao_Obra_Vlr = 200;
            cab.Pecas_Vlr = 300;
            cab.User_Insert = 1;
            cab.User_Update = 0;

            List<DetOS> detalhes = new List<DetOS>();
            for (int x = 0; x < 19; x++)
            {
                DetOS det = new DetOS();
                det.Id_Empresa = 1;
                det.Id_Os = cab.Id;
                det.Item = x + 1;
                det.Qtd = x * 2;
                det.Descricao = produtos[x];
                det.Valor = x * 2 + 1;
                det.User_Insert = 1;
                det.User_Update = 0;
                detalhes.Add(det);

            }
            //daoCab.SaveFullOs(cab, detalhes, "I");
            /*
               List<CabOS> os = new List<CabOS>();
               Console.WriteLine("Inicio....");
               os = daoCab.getAll(1, "");
               if (os.Count > 0)
               {
                   daoCab.DeleteFullOs(os[0]);
               }
               Console.WriteLine("Fim.....");
               */

            OsPDF osPDF = new OsPDF("", 7, 1);
            osPDF.ImprimirOS();

        }

        private void btSeekCar_Click(object sender, EventArgs e)
        {
            try
            {
                daoCarOS dao = new daoCarOS();
                Car = dao.Seek(cabOS.Id_Empresa, txtPlaca.Text.Replace("-", ""));
                if (Car == null)
                {
                    MessageBox.Show("Novo Carrro Será Cadastrado Com A O.S.", "Aviso",
              MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblNovo.Visible = true;
                    Car = new CarOS();
                    Car.Placa = txtPlaca.Text;
                }

                cabOS.Id_Carro = Car.Placa;
                cabOS.Car_Id_Marca = Car.Id_Marca;
                cabOS.Marca_Descricao = Car.Marca_Descricao;
                cabOS.Car_Modelo = Car.Modelo;
                cabOS.Car_Cor = Car.Cor;
                cabOS.Car_Ano = Car.Ano;
                lblNovo.Visible = false;

                AtualizaCar();
            }
            catch (Exception)
            {
                MessageBox.Show("Erro Na Pesquisa!", "Aviso",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
