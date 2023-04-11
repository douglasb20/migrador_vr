using FontAwesome.Sharp;
using MigradorRP.libs;
using MigradorRP.libs.DAOSPG;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
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

                lblTopBar.Text = titulo.ToString() + " | MigradorRP";

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
                ConnectionPG.Connect();
                string textFilter = "Arquivos Excel | *.xls; *.xlsx";
                string titleDialog = "Selecione uma planilha para importar no sistema";

                ToolTip toolBtValidate = new ToolTip();
                toolBtValidate.SetToolTip(btnValidateFiles, "Validar planilhas");
                toolBtValidate.SetToolTip(btnCancelFiles, "Remover planilhas");
                toolBtValidate.SetToolTip(btnSetSystem, "Configurações do migrador");
                toolBtValidate.SetToolTip(BtnFileProd, "Escolha uma planilha de produtos");
                toolBtValidate.SetToolTip(btnFileClient, "Escolha uma planilha de clientes");
                toolBtValidate.SetToolTip(btnFileFornecedor, "Escolha uma planilha de fornecedores");
                toolBtValidate.InitialDelay = 250;

                lblTabClient.MouseEnter += new EventHandler(DesignAndActions.lblMouseEnter);
                lblTabClient.MouseLeave += new EventHandler(DesignAndActions.lblMouseOut);

                lblTabProd.MouseEnter   += new EventHandler(DesignAndActions.lblMouseEnter);
                lblTabProd.MouseLeave   += new EventHandler(DesignAndActions.lblMouseOut);

                lblTabForn.MouseEnter   += new EventHandler(DesignAndActions.lblMouseEnter);
                lblTabForn.MouseLeave   += new EventHandler(DesignAndActions.lblMouseOut);

                fileDialogProd.Filter       = textFilter;
                fileDialogProd.Title        = titleDialog;

                fileDialogClient.Filter     = textFilter;
                fileDialogClient.Title      = titleDialog;

                fileDialogForn.Filter       = textFilter;
                fileDialogForn.Title        = titleDialog;

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

        public void Reload()
        {
            ConnectionPG.ReConnect();
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

        private void BtnFileProd_Click(object sender, EventArgs e)
        {
            IconButton btn = (IconButton)sender;

            if (fileDialogProd.ShowDialog() == DialogResult.OK)
            {
                btn.Text = fileDialogProd.SafeFileName.Length > 15 ? fileDialogProd.SafeFileName.Substring(0,15) + "..." : fileDialogProd.SafeFileName;
                btn.IconChar = IconChar.FileCircleCheck;
            }
            else
            {
                btn.Text = "Produtos...";
                btn.IconChar = IconChar.FileArrowUp;
                fileDialogProd.FileName = "";
            }
            
        }

        private void btnFileClient_Click(object sender, EventArgs e)
        {
            IconButton btn = (IconButton)sender;

            if (fileDialogClient.ShowDialog() == DialogResult.OK)
            {
                btn.Text = fileDialogClient.SafeFileName.Length > 15 ? fileDialogClient.SafeFileName.Substring(0, 15) + "..." : fileDialogClient.SafeFileName;
                btn.IconChar = IconChar.FileCircleCheck;
            }
            else
            {
                btn.Text                    = "Clientes...";
                btn.IconChar                = IconChar.FileArrowUp;
                fileDialogClient.FileName   = "";
            }

        }

        private void btnFileFornecedor_Click(object sender, EventArgs e)
        {
            IconButton btn = (IconButton)sender;

            if (fileDialogForn.ShowDialog() == DialogResult.OK)
            {
                btn.Text = fileDialogForn.SafeFileName.Length > 15 ? fileDialogForn.SafeFileName.Substring(0, 15) + "..." : fileDialogForn.SafeFileName;
                btn.IconChar = IconChar.FileCircleCheck;
            }
            else
            {
                btn.Text = "Fornecedores...";
                btn.IconChar = IconChar.FileArrowUp;
                fileDialogForn.FileName = "";
            }

        }

        private void btnCancelFiles_Click(object sender, EventArgs e)
        {
            try
            {

                BtnFileProd.Enabled = true;
                BtnFileProd.Text = "Produtos";
                fileDialogProd.FileName = "";
                BtnFileProd.IconChar = IconChar.FileArrowUp;

                btnFileClient.Enabled = true;
                btnFileClient.Text = "Clientes";
                btnFileClient.IconChar = IconChar.FileArrowUp;
                fileDialogClient.FileName = "";

                btnFileFornecedor.Enabled = true;
                btnFileFornecedor.Text = "Fornecedores";
                btnFileFornecedor.IconChar = IconChar.FileArrowUp;
                fileDialogForn.FileName = "";

                btnValidateFiles.Enabled = true;
                btnValidateFiles.IconColor = Color.White;

                btnCancelFiles.Enabled = false;
                btnCancelFiles.IconColor = Color.FromArgb(24, 24, 24);

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
                if (fileDialogProd.FileName == "" && fileDialogClient.FileName == "" && fileDialogForn.FileName == "")
                {
                    throw new Exception("Nenhum arquivo foi selecionado");
                }

                btnValidateFiles.Enabled    = false;
                btnValidateFiles.IconColor  = Color.FromArgb(24, 24, 24);

                BtnFileProd.Enabled         = false;
                btnFileClient.Enabled       = false;
                btnFileFornecedor.Enabled   = false;

                btnCancelFiles.Enabled      = true;
                btnCancelFiles.IconColor    = Color.White;

                bool carregaProd            = false;
                bool carregaClient          = false;
                bool carregaForn            = false;
                Label firstTab              = null;
                DataGridView gridLoad       = null;

                if ( !string.IsNullOrEmpty( fileDialogProd.FileName ) )
                {
                    await CarregaTabelaProdutos();
                    carregaProd = true;
                    firstTab    = lblTabProd;
                    gridLoad    = dtGridProdutos;
                }

                if(!string.IsNullOrEmpty(fileDialogClient.FileName))
                {
                    await CarregaTabelaClientes();
                    carregaClient = true;
                    if(firstTab == null)
                    {
                        firstTab = lblTabClient;
                        gridLoad = dtGridClientes;
                    }
                }

                if (!string.IsNullOrEmpty(fileDialogForn.FileName))
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

                    string abrir = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{0}';Extended Properties='Excel 12.0 Xml;HDR=YES;ReadOnly=True';", fileDialogProd.FileName);

                    OleDbConnection con = new OleDbConnection(abrir);
                    con.Open();

                    DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    string planilha = dt.Rows[0]["TABLE_NAME"].ToString();


                    OleDbDataAdapter da = new OleDbDataAdapter($"SELECT * FROM [{planilha}] " + (ConfigReader.GetConfigValue("Produtos", "mostra_inativos") == "true" ? "" : "WHERE ativo=true ")  + ";", con);
                    da.Fill(Tabelas, "produtos");

                    dtGridProdutos.Invoke((MethodInvoker)delegate
                    {
                        dtGridProdutos.DataSource = Tabelas.Tables["produtos"];
                    });

                    con.Close();

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

                    string abrir = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{0}';Extended Properties='Excel 12.0 Xml;HDR=YES;ReadOnly=True';", fileDialogClient.FileName);

                    OleDbConnection con = new OleDbConnection(abrir);
                    con.Open();

                    DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    string planilha = dt.Rows[0]["TABLE_NAME"].ToString();

                    OleDbDataAdapter da = new OleDbDataAdapter($"SELECT * FROM [{planilha}] " + (ConfigReader.GetConfigValue("Clientes", "mostra_inativos") == "true" ? "" : "WHERE ativo=true ") + ";", con);
                    da.Fill(Tabelas, "clientes");

                    dtGridProdutos.Invoke((MethodInvoker)delegate
                    {
                        dtGridClientes.DataSource = Tabelas.Tables["clientes"];
                    });

                    con.Close();

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

                    string abrir = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{0}';Extended Properties='Excel 12.0 Xml;HDR=YES;ReadOnly=True';", fileDialogForn.FileName);

                    OleDbConnection con = new OleDbConnection(abrir);
                    con.Open();

                    DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    string planilha = dt.Rows[0]["TABLE_NAME"].ToString();


                    OleDbDataAdapter da = new OleDbDataAdapter($"SELECT * FROM [{planilha}] " + (ConfigReader.GetConfigValue("Fornecedores", "mostra_inativos") == "true" ? "" : "WHERE ativo=true ") + ";", con);
                    da.Fill(Tabelas, "fornecedores");

                    dtGridProdutos.Invoke((MethodInvoker)delegate
                    {
                        dtGridFornecedores.DataSource = Tabelas.Tables["fornecedores"];
                    });

                    con.Close();

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
                if(Funcoes.ChamaAlerta("Deseja começar a fazer a importação?", "question") == DialogResult.Yes)
                {
                    AjeitaTela();
                    lblAviso.Show();

                    if (!string.IsNullOrEmpty(fileDialogProd.FileName))
                    {
                        lblAviso.Text = "Importando Produtos, aguarde...";
                        await ImportaProdutos();
                    }
                    if (!string.IsNullOrEmpty(fileDialogClient.FileName))
                    {
                        lblAviso.Text = "Importando Clientes, aguarde...";
                        await ImportaClientes();
                    }
                    if (!string.IsNullOrEmpty(fileDialogForn.FileName))
                    {
                        lblAviso.Text = "Importando Fornecedores, aguarde...";
                        await ImportaFornecedores();
                    }

                    lblAviso.Text = "Importação realizada com sucesso.";
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

        private async Task ImportaProdutos()
        {
            try
            {
                await UteisImportacao.PreparaProdutos(Tabelas.Tables["produtos"].Rows);
            }catch(Exception err)
            {
                throw err; 
            }
        }

        private async Task ImportaClientes()
        {
            try
            {
                await UteisImportacao.PreparaClientes(Tabelas.Tables["clientes"].Rows);
            }catch(Exception err)
            {
                throw err; 
            }
        }
        private async Task ImportaFornecedores()
        {
            try
            {
                await UteisImportacao.PreparaFornecedores(Tabelas.Tables["fornecedores"].Rows);
            }catch(Exception err)
            {
                throw err; 
            }
        }
    }
}
