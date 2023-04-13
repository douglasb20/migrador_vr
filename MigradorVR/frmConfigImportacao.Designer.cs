namespace MigradorRP
{
    partial class frmConfigImportacao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigImportacao));
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.lblTopBar = new System.Windows.Forms.Label();
            this.cfgImpQtd = new System.Windows.Forms.CheckBox();
            this.btSaveConfig = new System.Windows.Forms.Button();
            this.btnCancelCLose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboEntrada = new System.Windows.Forms.ComboBox();
            this.pnlConfigOptions = new System.Windows.Forms.Panel();
            this.cfgProdBalanca = new System.Windows.Forms.CheckBox();
            this.cfgFornShowInat = new System.Windows.Forms.CheckBox();
            this.cfgCliShowInat = new System.Windows.Forms.CheckBox();
            this.cfgProdShowInat = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlConfigOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 20;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.Location = new System.Drawing.Point(418, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 22;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            // 
            // lblTopBar
            // 
            this.lblTopBar.BackColor = System.Drawing.Color.Transparent;
            this.lblTopBar.Font = new System.Drawing.Font("Poppins Medium", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopBar.ForeColor = System.Drawing.Color.White;
            this.lblTopBar.Location = new System.Drawing.Point(0, 2);
            this.lblTopBar.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblTopBar.Name = "lblTopBar";
            this.lblTopBar.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblTopBar.Size = new System.Drawing.Size(450, 30);
            this.lblTopBar.TabIndex = 23;
            this.lblTopBar.Text = "Configuraçao de importação";
            this.lblTopBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTopBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTopBar_MouseDown);
            this.lblTopBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTopBar_MouseMove);
            // 
            // cfgImpQtd
            // 
            this.cfgImpQtd.AutoSize = true;
            this.cfgImpQtd.BackColor = System.Drawing.Color.Transparent;
            this.cfgImpQtd.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cfgImpQtd.ForeColor = System.Drawing.Color.White;
            this.cfgImpQtd.Location = new System.Drawing.Point(98, 26);
            this.cfgImpQtd.Name = "cfgImpQtd";
            this.cfgImpQtd.Size = new System.Drawing.Size(174, 29);
            this.cfgImpQtd.TabIndex = 24;
            this.cfgImpQtd.Text = "importar quantidade";
            this.cfgImpQtd.UseVisualStyleBackColor = false;
            this.cfgImpQtd.CheckStateChanged += new System.EventHandler(this.cfgImpQtd_Change);
            // 
            // btSaveConfig
            // 
            this.btSaveConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(80)))), ((int)(((byte)(110)))));
            this.btSaveConfig.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(110)))), ((int)(((byte)(155)))));
            this.btSaveConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSaveConfig.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSaveConfig.ForeColor = System.Drawing.Color.White;
            this.btSaveConfig.Location = new System.Drawing.Point(206, 397);
            this.btSaveConfig.Name = "btSaveConfig";
            this.btSaveConfig.Size = new System.Drawing.Size(150, 40);
            this.btSaveConfig.TabIndex = 25;
            this.btSaveConfig.Text = "Salvar";
            this.btSaveConfig.UseVisualStyleBackColor = false;
            this.btSaveConfig.Click += new System.EventHandler(this.btSaveConfig_Click);
            // 
            // btnCancelCLose
            // 
            this.btnCancelCLose.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelCLose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancelCLose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.btnCancelCLose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancelCLose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelCLose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelCLose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancelCLose.Location = new System.Drawing.Point(0, 397);
            this.btnCancelCLose.Name = "btnCancelCLose";
            this.btnCancelCLose.Size = new System.Drawing.Size(150, 40);
            this.btnCancelCLose.TabIndex = 26;
            this.btnCancelCLose.Text = "Cancelar";
            this.btnCancelCLose.UseVisualStyleBackColor = false;
            this.btnCancelCLose.Click += new System.EventHandler(this.btnCancelCLose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(99, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 28);
            this.label1.TabIndex = 28;
            this.label1.Text = "Entrada de dados";
            // 
            // cboEntrada
            // 
            this.cboEntrada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntrada.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEntrada.FormattingEnabled = true;
            this.cboEntrada.ItemHeight = 23;
            this.cboEntrada.Items.AddRange(new object[] {
            "LeCheff",
            "LeStore"});
            this.cboEntrada.Location = new System.Drawing.Point(101, 78);
            this.cboEntrada.Name = "cboEntrada";
            this.cboEntrada.Size = new System.Drawing.Size(150, 31);
            this.cboEntrada.TabIndex = 27;
            this.cboEntrada.SelectedValueChanged += new System.EventHandler(this.cboEntrada_SelectedValueChanged);
            // 
            // pnlConfigOptions
            // 
            this.pnlConfigOptions.Controls.Add(this.cfgFornShowInat);
            this.pnlConfigOptions.Controls.Add(this.cfgCliShowInat);
            this.pnlConfigOptions.Controls.Add(this.cfgProdShowInat);
            this.pnlConfigOptions.Controls.Add(this.cfgProdBalanca);
            this.pnlConfigOptions.Controls.Add(this.cfgImpQtd);
            this.pnlConfigOptions.Controls.Add(this.panel1);
            this.pnlConfigOptions.Controls.Add(this.panel2);
            this.pnlConfigOptions.Controls.Add(this.label5);
            this.pnlConfigOptions.Controls.Add(this.label4);
            this.pnlConfigOptions.Controls.Add(this.label3);
            this.pnlConfigOptions.Location = new System.Drawing.Point(0, 130);
            this.pnlConfigOptions.Name = "pnlConfigOptions";
            this.pnlConfigOptions.Size = new System.Drawing.Size(360, 310);
            this.pnlConfigOptions.TabIndex = 31;
            // 
            // cfgProdBalanca
            // 
            this.cfgProdBalanca.AutoSize = true;
            this.cfgProdBalanca.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cfgProdBalanca.ForeColor = System.Drawing.Color.White;
            this.cfgProdBalanca.Location = new System.Drawing.Point(98, 46);
            this.cfgProdBalanca.Name = "cfgProdBalanca";
            this.cfgProdBalanca.Size = new System.Drawing.Size(117, 29);
            this.cfgProdBalanca.TabIndex = 43;
            this.cfgProdBalanca.Text = "Usa balança";
            this.cfgProdBalanca.UseVisualStyleBackColor = true;
            this.cfgProdBalanca.CheckStateChanged += new System.EventHandler(this.cfgProdBalanca_CheckStateChanged);
            // 
            // cfgFornShowInat
            // 
            this.cfgFornShowInat.AutoSize = true;
            this.cfgFornShowInat.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cfgFornShowInat.ForeColor = System.Drawing.Color.White;
            this.cfgFornShowInat.Location = new System.Drawing.Point(98, 206);
            this.cfgFornShowInat.Name = "cfgFornShowInat";
            this.cfgFornShowInat.Size = new System.Drawing.Size(140, 29);
            this.cfgFornShowInat.TabIndex = 41;
            this.cfgFornShowInat.Text = "Mostrar Inativos";
            this.cfgFornShowInat.UseVisualStyleBackColor = true;
            this.cfgFornShowInat.CheckStateChanged += new System.EventHandler(this.cfgFornShowInat_CheckStateChanged);
            // 
            // cfgCliShowInat
            // 
            this.cfgCliShowInat.AutoSize = true;
            this.cfgCliShowInat.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cfgCliShowInat.ForeColor = System.Drawing.Color.White;
            this.cfgCliShowInat.Location = new System.Drawing.Point(98, 135);
            this.cfgCliShowInat.Name = "cfgCliShowInat";
            this.cfgCliShowInat.Size = new System.Drawing.Size(140, 29);
            this.cfgCliShowInat.TabIndex = 40;
            this.cfgCliShowInat.Text = "Mostrar Inativos";
            this.cfgCliShowInat.UseVisualStyleBackColor = true;
            this.cfgCliShowInat.CheckStateChanged += new System.EventHandler(this.cfgCliShowInat_CheckStateChanged);
            // 
            // cfgProdShowInat
            // 
            this.cfgProdShowInat.AutoSize = true;
            this.cfgProdShowInat.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cfgProdShowInat.ForeColor = System.Drawing.Color.White;
            this.cfgProdShowInat.Location = new System.Drawing.Point(98, 66);
            this.cfgProdShowInat.Name = "cfgProdShowInat";
            this.cfgProdShowInat.Size = new System.Drawing.Size(140, 29);
            this.cfgProdShowInat.TabIndex = 39;
            this.cfgProdShowInat.Text = "Mostrar Inativos";
            this.cfgProdShowInat.UseVisualStyleBackColor = true;
            this.cfgProdShowInat.CheckStateChanged += new System.EventHandler(this.cfgProdShowInat_CheckStateChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(360, 28);
            this.label5.TabIndex = 31;
            this.label5.Text = "Fornecedores";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(357, 28);
            this.label4.TabIndex = 30;
            this.label4.Text = "Clientes";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(360, 28);
            this.label3.TabIndex = 29;
            this.label3.Text = "Produtos";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(360, 1);
            this.panel2.TabIndex = 44;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 170);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 1);
            this.panel1.TabIndex = 45;
            // 
            // frmConfigImportacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(358, 438);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboEntrada);
            this.Controls.Add(this.btnCancelCLose);
            this.Controls.Add(this.btSaveConfig);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTopBar);
            this.Controls.Add(this.pnlConfigOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfigImportacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmConfigImportacao_Load);
            this.pnlConfigOptions.ResumeLayout(false);
            this.pnlConfigOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnClose;
        private System.Windows.Forms.Label lblTopBar;
        private System.Windows.Forms.CheckBox cfgImpQtd;
        private System.Windows.Forms.Button btSaveConfig;
        private System.Windows.Forms.Button btnCancelCLose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboEntrada;
        private System.Windows.Forms.Panel pnlConfigOptions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cfgProdShowInat;
        private System.Windows.Forms.CheckBox cfgFornShowInat;
        private System.Windows.Forms.CheckBox cfgCliShowInat;
        private System.Windows.Forms.CheckBox cfgProdBalanca;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}