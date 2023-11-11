using MigradorRP.libs;
using MigradorRP.libs.DAOSPG;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MigradorRP
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            try
            {
                InitializeComponent();
                this.Paint += new PaintEventHandler(Element_Paint);
                tmrBorda.Tick += new EventHandler(DesignAndActions.timer1_Tick);

                lblTopBar.Text = titulo.ToString() + " | MigradorVR";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static Dictionary<string, string> config;

        public Button activeButton;
        public static string caminho                    = Path.GetDirectoryName(Application.ExecutablePath);
        public static string fileConfig                 = "config.conf";
        public static string pathConfig                 = Path.Combine( caminho , fileConfig);
        public string titulo                            = ConfigurationManager.AppSettings["appTitle"];
        public DataSet Tabelas                          = new DataSet();

        private void Element_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath forma = new GraphicsPath();
            forma.StartFigure();
       
            forma.AddArc(new Rectangle(0, 0, 20, 20), 180, 90);
            forma.AddLine(20, 0, this.Width - 20, 0);
            forma.AddArc(new Rectangle(this.Width - 20, 0, 20, 20), -90, 90);
            forma.AddLine(this.Width, 20, this.Width, this.Height - 20);
            forma.AddArc(new Rectangle(this.Width - 20, this.Height - 20, 20, 20), 0, 90);
            forma.AddLine(this.Width - 20, this.Height, 20, this.Height);
            forma.AddArc(new Rectangle(0, this.Height - 20, 20, 20), 90, 90);
            forma.CloseFigure();
            this.Region = new Region(forma);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigReader.LoadConfig(pathConfig);
                //ConnectionPG.Connect();

                ToolTip toolBtValidate = new ToolTip();
                toolBtValidate.SetToolTip(btnValidateFiles, "Validar planilhas");
                toolBtValidate.SetToolTip(btnCancelFiles, "Remover planilhas");
                toolBtValidate.SetToolTip(btnSetSystem, "Configurações do migrador");
                toolBtValidate.InitialDelay = 250;

                lblTabClient.MouseEnter += new EventHandler(DesignAndActions.lblMouseEnter);
                lblTabClient.MouseLeave += new EventHandler(DesignAndActions.lblMouseOut);

                lblTabProd.MouseEnter   += new EventHandler(DesignAndActions.lblMouseEnter);
                lblTabProd.MouseLeave   += new EventHandler(DesignAndActions.lblMouseOut);

                lblTabForn.MouseEnter   += new EventHandler(DesignAndActions.lblMouseEnter);
                lblTabForn.MouseLeave   += new EventHandler(DesignAndActions.lblMouseOut);

                btnCancelFiles.Enabled      = false;
                btnCancelFiles.IconColor    = Color.FromArgb(24, 24, 24);

                DesignAndActions.DesactiveTabs();
                pnlDadosImp.Hide();
                lblAviso.Hide();
                btnImport.Hide();

                this.Height = 250;

                frmConfigImportacao frmConfig = new frmConfigImportacao(this);
                frmConfig.canCloseApp = true;
                frmConfig.ShowDialog();
                this.Hide();

                tmrBorda.Interval = 1;
            }
            catch(Exception err) {
                MessageBox.Show(err.Message, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public void Reload(bool firstAction)
        {
            if (firstAction)
            {
                ConnectionPG.Connect();
            }
            else
            {
                ConnectionPG.ReConnect();
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblClose_MouseEnter(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.FromArgb(188, 75, 81);
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.Transparent;
        }

        private void lblTopBar_MouseMove(object sender, MouseEventArgs e)
        {
            Funcoes.moverForm(this);
        }

        private void btnCancelFiles_Click(object sender, EventArgs e)
        {
            try
            {

                btnValidateFiles.Enabled = true;
                btnValidateFiles.IconColor = Color.White;

                btnCancelFiles.Enabled = false;
                btnCancelFiles.IconColor = Color.FromArgb(24, 24, 24);

                chkFornecedores.Enabled= true;
                chkCliente.Enabled= true;
                chkProd.Enabled= true;

                dtGridProdutos.DataSource = null;
                dtGridClientes.DataSource = null;
                dtGridFornecedores.DataSource = null;
                pnlDadosImp.Hide();
                btnImport.Hide();
                lblAviso.Hide();

                this.Height = 250;

                DesignAndActions.DesactiveTabs();


            }
            catch(Exception error) {
                Funcoes.ErrorMessage(error.Message);
            }
        }

        public void AjeitaTela()
        {
            this.Height = 250;
            pnlDadosImp.Hide();
        }

        private async void btnValidateFiles_Click(object sender, EventArgs e)
        {
            try
            {
                Tabelas.Reset();
                await ValidaPlanilhas();
            }
            catch(Exception err)
            {
                lblAviso.Hide();
                Funcoes.ErrorMessage(err.Message);
            }
            
        }

        private void lblTabProd_Click(object sender, EventArgs e)
        {
            DesignAndActions.ActiveTab(sender as Label, tmrBorda, dtGridProdutos);
            lblRegistros.Text = $"Registros: {Tabelas.Tables["produtos"].Rows.Count}";
        }

        private void lblTabClient_Click(object sender, EventArgs e)
        {
            DesignAndActions.ActiveTab(sender as Label, tmrBorda, dtGridClientes);
            lblRegistros.Text = $"Registros: {Tabelas.Tables["clientes"].Rows.Count}";
        }

        private void lblTabForn_Click(object sender, EventArgs e)
        {
            DesignAndActions.ActiveTab(sender as Label, tmrBorda, dtGridFornecedores);
            lblRegistros.Text = $"Registros: {Tabelas.Tables["fornecedores"].Rows.Count}";
        }

        private void btnMin_MouseEnter(object sender, EventArgs e)
        {
            btnMin.BackColor = Color.FromArgb(54, 54, 54);
        }

        private void btnMin_MouseLeave(object sender, EventArgs e)
        {
            btnMin.BackColor = Color.Transparent;
        }

        private void btnSetSystem_Click(object sender, EventArgs e)
        {
            frmConfigImportacao frmConfig = new frmConfigImportacao(this);
            frmConfig.ShowInTaskbar = false;
            frmConfig.ShowDialog();
        }

        private void lblTopBar_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.SizeAll;
        }

        private async Task ValidaPlanilhas()
        {
            try
            {
                if (!chkCliente.Checked && !chkProd.Checked && !chkFornecedores.Checked)
                {
                    throw new Exception("Nenhuma opção de exportação foi selecionado");
                }

                btnValidateFiles.Enabled    = false;
                btnValidateFiles.IconColor  = Color.FromArgb(24, 24, 24);

                btnCancelFiles.Enabled      = true;
                btnCancelFiles.IconColor    = Color.White;

                chkCliente.Enabled      = false;
                chkProd.Enabled         = false;
                chkFornecedores.Enabled = false;

                bool carregaProd            = false;
                bool carregaClient          = false;
                bool carregaForn            = false;
                Label firstTab              = null;
                DataGridView gridLoad       = null;

                if ( chkProd.Checked )
                {
                    await CarregaTabelaProdutos();
                    carregaProd = true;
                    firstTab    = lblTabProd;
                    gridLoad    = dtGridProdutos;
                }

                if(chkCliente.Checked)
                {
                    await CarregaTabelaClientes();
                    carregaClient = true;
                    if(firstTab == null)
                    {
                        firstTab = lblTabClient;
                        gridLoad = dtGridClientes;
                    }
                }

                if (chkFornecedores.Checked)
                {
                    await CarregaTabelaFornecedores();
                    carregaForn = true;
                    if (firstTab == null)
                    {
                        firstTab = lblTabForn;
                        gridLoad = dtGridFornecedores;
                    }
                }

                OrganizaBotoesTab(carregaProd,carregaClient,carregaForn);
                lblRegistros.Text = $"Registros: {gridLoad.RowCount.ToString()}";

                lblAviso.Hide();
                this.Height = 700;
                pnlDadosImp.Show();

                DesignAndActions.ActiveTab(firstTab, tmrBorda, gridLoad, false);
                btnImport.Show();
            }
            catch(Exception err)
            {
                throw err;
            }
        }

        private async Task CarregaTabelaProdutos()
        {
            try
            {
                lblAviso.Show();
                lblAviso.Text = "Carregando Produtos, aguarde...";
                await Task.Run(() =>
                {
                    MateriaisPGDAO materiais = new MateriaisPGDAO();
                    DataTable produtos = materiais.ExportaProdutos();
                    produtos.TableName = "produtos";

                    Tabelas.Tables.Add(produtos);

                    dtGridProdutos.Invoke((MethodInvoker)delegate
                    {
                        dtGridProdutos.DataSource = Tabelas.Tables["produtos"];
                    });

                });

            }
            catch(OleDbException err)
            {
                throw err;
            }
            catch(Exception err)
            {
                throw err;
            }
        }
        
        private async Task CarregaTabelaClientes()
        {
            try
            {
                lblAviso.Show();
                lblAviso.Text = "Carregando Clientes, aguarde...";
                await Task.Run(() =>
                {
                    ClientesPGDAO clientes = new ClientesPGDAO();
                    DataTable clients = clientes.ExportaClientes();
                    clients.TableName = "clientes";
                    Tabelas.Tables.Add(clients);

                    dtGridProdutos.Invoke((MethodInvoker)delegate
                    {
                        dtGridClientes.DataSource = Tabelas.Tables["clientes"];
                    });

                });

            }
            catch (Exception err)
            {
                throw err;
            }
        }
        
        private async Task CarregaTabelaFornecedores()
        {
            try
            {
                lblAviso.Show();
                lblAviso.Text = "Carregando Fornecedores, aguarde...";
                await Task.Run(() =>
                {

                    FornecedorPGDAO fornecedor= new FornecedorPGDAO();
                    DataTable forns = fornecedor.ExportaFornecedores();
                    forns.TableName = "fornecedores";
                    Tabelas.Tables.Add(forns);

                    dtGridProdutos.Invoke((MethodInvoker)delegate
                    {
                        dtGridFornecedores.DataSource = Tabelas.Tables["fornecedores"];
                    });

                });

            }
            catch (Exception err)
            {
                throw err;
            }
        }

        private void OrganizaBotoesTab(bool prod, bool client, bool forn)
        {
            int leftOriginal = 10;
            lblTabProd.Hide();
            lblTabClient.Hide();
            lblTabForn.Hide();

            if(prod )
            {
                lblTabProd.Left= leftOriginal;
                lblTabProd.Show();
                leftOriginal += 165;
            }

            if(client)
            {
                lblTabClient.Left= leftOriginal;
                lblTabClient.Show();
                leftOriginal+= 165;
            }
            if(forn)
            {
                lblTabForn.Left= leftOriginal;
                lblTabForn.Show();
            }
        }

        private async void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dirOut.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                else
                {
                    ConfigReader.saidaPath = dirOut.SelectedPath;
                }

                if(Funcoes.ChamaAlerta("Deseja começar a fazer a exportação?", "question") == DialogResult.Yes)
                {
                    AjeitaTela();
                    lblAviso.Show();

                    if (chkProd.Checked)
                    {
                        lblAviso.Text = "Exportando Produtos, aguarde...";
                        await ExportaProdutos();
                    }
                    if(chkCliente.Checked && chkFornecedores.Checked)
                    {
                        DataTable dtMerged = new DataTable();
                        dtMerged = Tabelas.Tables["clientes"].Copy();
                        dtMerged.Merge(Tabelas.Tables["fornecedores"]);
                        await ExportaClientesFornecedores(dtMerged);
                    }
                    else
                    {
                        if (chkCliente.Checked)
                        {
                            lblAviso.Text = "Exportanto Clientes, aguarde...";
                            await ExportaClientes();
                        }

                        if (chkFornecedores.Checked)
                        {
                            lblAviso.Text = "Exportando Fornecedores, aguarde...";
                            await ExportaFornecedores();
                        }
                    }


                    lblAviso.Text = "Exportação realizada com sucesso.";
                    Process.Start("explorer.exe", ConfigReader.saidaPath);
                }

            }catch(NpgsqlException err)
            {
                Funcoes.ErrorMessage(err.Message);
            }
            catch(Exception err)
            {
                Funcoes.ErrorMessage(err.Message);
            }
        }

        private async Task ExportaProdutos()
        {
            try
            {
                await UteisImportacao.PreparaProdutos(Tabelas.Tables["produtos"].Rows);
            }catch(Exception err)
            {
                throw err; 
            }
        }

        private async Task ExportaClientes()
        {
            try
            {
                await UteisImportacao.PreparaClientesFornecedores(Tabelas.Tables["clientes"].Rows, "Clientes");
            }catch(Exception err)
            {
                throw err; 
            }
        }

        private async Task ExportaFornecedores()
        {
            try
            {
                await UteisImportacao.PreparaClientesFornecedores(Tabelas.Tables["fornecedores"].Rows, "Fornecedores");
            }catch(Exception err)
            {
                throw err; 
            }
        }
        
        private async Task ExportaClientesFornecedores(DataTable dtMerged)
        {
            try
            {
                await UteisImportacao.PreparaClientesFornecedores(dtMerged.Rows);
            }catch(Exception err)
            {
                throw err; 
            }
        }

    }
}
