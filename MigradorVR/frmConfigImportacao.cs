using System;
using System.Drawing;
using System.Windows.Forms;

namespace MigradorRP
{
    public partial class frmConfigImportacao : Form
    {
        private frmMain pai = null;
        public bool canCloseApp = false;
        private bool confirmaAlterarModo = false;
        public frmConfigImportacao(frmMain pai = null)
        {
            InitializeComponent();
            this.pai = pai;
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(188, 75, 81);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.Transparent;
        }

        private void frmConfigImportacao_Load(object sender, EventArgs e)
        {
            if (canCloseApp)
            {
                this.Size = new Size(this.Size.Width, 200);
                pnlConfigOptions.Visible = false;
            }
            ConfigReader.ReloadConfig();

            cfgImpQtd.Checked               = ConfigReader.GetConfigValue("Produtos", "importa_quantidade") == "true";
            cfgProdShowInat.Checked         = ConfigReader.GetConfigValue("Produtos", "mostra_inativos") == "true";
            cfgProdBalanca.Checked          = ConfigReader.GetConfigValue("Produtos", "importa_balanca") == "true";

            cfgCliShowInat.Checked          = ConfigReader.GetConfigValue("Clientes", "mostra_inativos") == "true";

            cfgFornShowInat.Checked         = ConfigReader.GetConfigValue("Fornecedores", "mostra_inativos") == "true";

            if (ConfigReader.sistema == null)
            {
                cboEntrada.SelectedIndex= 0;
            }
            else
            {
                cboEntrada.SelectedItem = ConfigReader.sistema.ToString();
            }


            btnCancelCLose.Location = new Point(3, this.Size.Height - btnCancelCLose.Size.Height -5);
            btSaveConfig.Location   = new Point(this.Size.Width - btSaveConfig.Size.Width - 5, this.Size.Height - btSaveConfig.Size.Height -5);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseConfig();
        }


        public void CloseConfig()
        {
            if(canCloseApp)
            {
                Application.Exit();
                return;
            }

            ConfigReader.ReloadConfig();
            this.Dispose(true);
        }

        private void btnCancelCLose_Click(object sender, EventArgs e)
        {
            CloseConfig();
        }

        private void btSaveConfig_Click(object sender, EventArgs e)
        {
            if(confirmaAlterarModo)
            {
                if(MessageBox.Show("Deseja alterar a configuração da entrada de dados?", pai.titulo, MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
            }

            ConfigReader.SaveConfig();
            ConfigReader.sistema = cboEntrada.SelectedItem.ToString();

            pai.Reload();
            if(confirmaAlterarModo) pai.btnCancelFiles.PerformClick();

            this.Dispose();
        }

        private void cboEntrada_SelectedValueChanged(object sender, EventArgs e)
        {
            if(ConfigReader.sistema != null)
            {
                if (ConfigReader.sistema != cboEntrada.SelectedItem.ToString())
                {
                    confirmaAlterarModo = true;
                }
                else
                {
                    confirmaAlterarModo= false;
                }
            }
        }

        private void changeConfig(CheckBox chk,string section,  string config)
        {
            ConfigReader.SetConfigValue(section, config, chk.Checked ? "true" : "false");
        }

        private void cfgImpQtd_Change(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            changeConfig(chk, "Produtos", "importa_quantidade");
        }

        private void cfgProdShowInat_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            changeConfig(chk, "Produtos", "mostra_inativos");
        }

        private void cfgCliShowInat_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            changeConfig(chk, "Clientes", "mostra_inativos");
        }

        private void cfgFornShowInat_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            changeConfig(chk, "Fornecedores", "mostra_inativos");
        }

        private void lblTopBar_MouseMove(object sender, MouseEventArgs e)
        {
            Funcoes.moverForm(this);
        }

        private void lblTopBar_MouseDown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.SizeAll;
        }

        private void cfgProdBalanca_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            changeConfig(chk, "Produtos", "importa_balanca");
        }


    }
}
