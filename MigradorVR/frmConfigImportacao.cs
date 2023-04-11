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
        private string[] alterados= { };
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
            cfgzProdZerosEsquerda.Checked   = ConfigReader.GetConfigValue("Produtos","prod_remover_zeros_esquerda") == "true";
            cfgCalcMargem.Checked           = ConfigReader.GetConfigValue("Produtos", "calcular_margem") == "true";
            cfgAjustaPis.Checked            = ConfigReader.GetConfigValue("Produtos", "ajusta_pis_csosn") == "true";
            cfgAjustaCofins.Checked         = ConfigReader.GetConfigValue("Produtos", "ajusta_cofins_csosn") == "true";
            cfgAjustaCfop.Checked           = ConfigReader.GetConfigValue("Produtos", "ajusta_cfop_csosn") == "true";
            cfgProdShowInat.Checked         = ConfigReader.GetConfigValue("Produtos", "mostra_inativos") == "true";
            cfgProdBalanca.Checked          = ConfigReader.GetConfigValue("Produtos", "importa_balanca") == "true";
            cfgProdSubPadrao.Checked        = ConfigReader.GetConfigValue("Produtos", "subcategoria_padrao") == "true";

            cfgCliZeroEsquerda.Checked      = ConfigReader.GetConfigValue("Clientes", "cli_remover_zeros_esquerda") == "true";
            cfgCliShowInat.Checked          = ConfigReader.GetConfigValue("Clientes", "mostra_inativos") == "true";
            cfgCliUsaNumero.Checked         = ConfigReader.GetConfigValue("Clientes", "usa_campo_num") == "true";

            cfgFornZeroEsquerda.Checked     = ConfigReader.GetConfigValue("Fornecedores", "forn_remover_zeros_esquerda") == "true";
            cfgFornShowInat.Checked         = ConfigReader.GetConfigValue("Fornecedores", "mostra_inativos") == "true";
            cfgFornUsaNumero.Checked         = ConfigReader.GetConfigValue("Fornecedores", "usa_campo_num") == "true";

            if (ConfigReader.tipoImportacao == null)
            {
                cboEntrada.SelectedIndex= 0;
                cboSistema.SelectedIndex = 0;
            }
            else
            {
                cboEntrada.SelectedItem = ConfigReader.tipoImportacao.ToString();
                cboSistema.SelectedItem = ConfigReader.sistema.ToString();
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
                if(MessageBox.Show("Deseja alterar a configuração de " + string.Join( " e ", alterados) + "?", pai.titulo, MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
            }

            ConfigReader.SaveConfig();
            ConfigReader.sistema = cboSistema.SelectedItem.ToString();
            ConfigReader.tipoImportacao = cboEntrada.SelectedItem.ToString();

            pai.Reload();

            this.Dispose();
        }

        private void cboEntrada_SelectedValueChanged(object sender, EventArgs e)
        {
            if(ConfigReader.tipoImportacao != null)
            {
                string searchItem = "entrada de dados";
                if (ConfigReader.tipoImportacao != cboEntrada.SelectedItem.ToString())
                {
                    confirmaAlterarModo = true;

                    Array.Resize(ref alterados, alterados.Length + 1);
                    alterados[alterados.Length - 1] = searchItem;
                }
                else
                {
                    int index = Array.FindIndex(alterados, x => x.Contains(searchItem));
                    if (index != -1)
                    {
                        string[] newArr = new string[alterados.Length - 1];
                        Array.Copy(alterados, 0, newArr, 0, index);
                        Array.Copy(alterados, index + 1, newArr, index, alterados.Length - index - 1);
                        alterados = newArr;
                    }
                }
            }
        }

        private void cboSistema_SelectedValueChanged(object sender, EventArgs e)
        {

            if (ConfigReader.sistema != null)
            {
                string searchItem = "sistema";
                if (ConfigReader.sistema != cboSistema.SelectedItem.ToString())
                {
                    confirmaAlterarModo = true;
                    
                    Array.Resize(ref alterados, alterados.Length + 1);
                    alterados[alterados.Length - 1] = searchItem;
                }
                else
                {
                    int index = Array.FindIndex(alterados, x => x.Contains(searchItem));
                    if (index != -1)
                    {
                        string[] newArr = new string[alterados.Length - 1];
                        Array.Copy(alterados, 0, newArr, 0, index);
                        Array.Copy(alterados, index + 1, newArr, index, alterados.Length - index - 1);
                        alterados = newArr;
                    }
                }
            }

            if(alterados.Length == 0)
            {
                confirmaAlterarModo = false;
            }
        }

        private void changeConfig(CheckBox chk,string section,  string config)
        {
            ConfigReader.SetConfigValue(section, config, chk.Checked ? "true" : "false");
        }

        private void cfgzProdZerosEsquerda_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            changeConfig( chk, "Produtos", "prod_remover_zeros_esquerda");
        }

        private void cfgImpQtd_Change(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            changeConfig(chk, "Produtos", "importa_quantidade");
        }

        private void cfgCalcMargem_CheckStateChanged(object sender, EventArgs e)
        {
            
        }

        private void cfgCliZeroEsquerda_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            changeConfig(chk, "Clientes", "cli_remover_zeros_esquerda");
        }

        private void cfgFornZeroEsquerda_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            changeConfig(chk, "Fornecedores", "forn_remover_zeros_esquerda");
        }

        private void cfgAjustaPis_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            changeConfig(chk, "Produtos", "ajusta_pis_csosn");
        }

        private void cfgAjustaCofins_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            changeConfig(chk, "Produtos", "ajusta_cofins_csosn");
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

        private void cfgAjustaCfop_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            changeConfig(chk, "Produtos", "ajusta_cfop_csosn");
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

        private void cfgProdSubPadrao_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            changeConfig(chk, "Produtos", "subcategoria_padrao");
        }

        private void cfgCliUsaNumero_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            changeConfig(chk, "Clientes", "usa_campo_num");
        }

        private void cfgFornUsaNumero_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            changeConfig(chk, "Fornecedores", "usa_campo_num");
        }
    }
}
