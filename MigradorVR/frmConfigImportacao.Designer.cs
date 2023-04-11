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
            this.label2 = new System.Windows.Forms.Label();
            this.cboSistema = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboEntrada = new System.Windows.Forms.ComboBox();
            this.pnlConfigOptions = new System.Windows.Forms.Panel();
            this.cfgFornUsaNumero = new System.Windows.Forms.CheckBox();
            this.cfgCliUsaNumero = new System.Windows.Forms.CheckBox();
            this.cfgProdSubPadrao = new System.Windows.Forms.CheckBox();
            this.cfgProdBalanca = new System.Windows.Forms.CheckBox();
            this.cfgAjustaCfop = new System.Windows.Forms.CheckBox();
            this.cfgFornShowInat = new System.Windows.Forms.CheckBox();
            this.cfgCliShowInat = new System.Windows.Forms.CheckBox();
            this.cfgProdShowInat = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cfgAjustaCofins = new System.Windows.Forms.CheckBox();
            this.cfgAjustaPis = new System.Windows.Forms.CheckBox();
            this.cfgCalcMargem = new System.Windows.Forms.CheckBox();
            this.cfgFornZeroEsquerda = new System.Windows.Forms.CheckBox();
            this.cfgCliZeroEsquerda = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cfgzProdZerosEsquerda = new System.Windows.Forms.CheckBox();
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
            this.cfgImpQtd.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cfgImpQtd.ForeColor = System.Drawing.Color.White;
            this.cfgImpQtd.Location = new System.Drawing.Point(10, 35);
            this.cfgImpQtd.Name = "cfgImpQtd";
            this.cfgImpQtd.Size = new System.Drawing.Size(174, 29);
            this.cfgImpQtd.TabIndex = 24;
            this.cfgImpQtd.Text = "importar quantidade";
            this.cfgImpQtd.UseVisualStyleBackColor = true;
            this.cfgImpQtd.CheckStateChanged += new System.EventHandler(this.cfgImpQtd_Change);
            // 
            // btSaveConfig
            // 
            this.btSaveConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(80)))), ((int)(((byte)(110)))));
            this.btSaveConfig.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(110)))), ((int)(((byte)(155)))));
            this.btSaveConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSaveConfig.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSaveConfig.ForeColor = System.Drawing.Color.White;
            this.btSaveConfig.Location = new System.Drawing.Point(292, 557);
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
            this.btnCancelCLose.Location = new System.Drawing.Point(0, 557);
            this.btnCancelCLose.Name = "btnCancelCLose";
            this.btnCancelCLose.Size = new System.Drawing.Size(150, 40);
            this.btnCancelCLose.TabIndex = 26;
            this.btnCancelCLose.Text = "Cancelar";
            this.btnCancelCLose.UseVisualStyleBackColor = false;
            this.btnCancelCLose.Click += new System.EventHandler(this.btnCancelCLose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(277, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 28);
            this.label2.TabIndex = 30;
            this.label2.Text = "Sistema";
            // 
            // cboSistema
            // 
            this.cboSistema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSistema.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSistema.FormattingEnabled = true;
            this.cboSistema.ItemHeight = 23;
            this.cboSistema.Items.AddRange(new object[] {
            "LeCheff",
            "LeStore"});
            this.cboSistema.Location = new System.Drawing.Point(241, 76);
            this.cboSistema.Name = "cboSistema";
            this.cboSistema.Size = new System.Drawing.Size(150, 31);
            this.cboSistema.TabIndex = 29;
            this.cboSistema.SelectedValueChanged += new System.EventHandler(this.cboSistema_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(57, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 28);
            this.label1.TabIndex = 28;
            this.label1.Text = "Entrada de dados";
            // 
            // cboEntrada
            // 
            this.cboEntrada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntrada.Enabled = false;
            this.cboEntrada.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEntrada.FormattingEnabled = true;
            this.cboEntrada.ItemHeight = 23;
            this.cboEntrada.Items.AddRange(new object[] {
            "Excel",
            "Etrade(VrSystem)"});
            this.cboEntrada.Location = new System.Drawing.Point(58, 76);
            this.cboEntrada.Name = "cboEntrada";
            this.cboEntrada.Size = new System.Drawing.Size(150, 31);
            this.cboEntrada.TabIndex = 27;
            this.cboEntrada.SelectedValueChanged += new System.EventHandler(this.cboEntrada_SelectedValueChanged);
            // 
            // pnlConfigOptions
            // 
            this.pnlConfigOptions.Controls.Add(this.cfgFornUsaNumero);
            this.pnlConfigOptions.Controls.Add(this.cfgCliUsaNumero);
            this.pnlConfigOptions.Controls.Add(this.cfgProdSubPadrao);
            this.pnlConfigOptions.Controls.Add(this.cfgProdBalanca);
            this.pnlConfigOptions.Controls.Add(this.cfgAjustaCfop);
            this.pnlConfigOptions.Controls.Add(this.cfgFornShowInat);
            this.pnlConfigOptions.Controls.Add(this.cfgCliShowInat);
            this.pnlConfigOptions.Controls.Add(this.cfgProdShowInat);
            this.pnlConfigOptions.Controls.Add(this.panel2);
            this.pnlConfigOptions.Controls.Add(this.panel1);
            this.pnlConfigOptions.Controls.Add(this.cfgAjustaCofins);
            this.pnlConfigOptions.Controls.Add(this.cfgAjustaPis);
            this.pnlConfigOptions.Controls.Add(this.cfgCalcMargem);
            this.pnlConfigOptions.Controls.Add(this.cfgFornZeroEsquerda);
            this.pnlConfigOptions.Controls.Add(this.cfgCliZeroEsquerda);
            this.pnlConfigOptions.Controls.Add(this.label5);
            this.pnlConfigOptions.Controls.Add(this.label4);
            this.pnlConfigOptions.Controls.Add(this.label3);
            this.pnlConfigOptions.Controls.Add(this.cfgzProdZerosEsquerda);
            this.pnlConfigOptions.Controls.Add(this.cfgImpQtd);
            this.pnlConfigOptions.Location = new System.Drawing.Point(0, 131);
            this.pnlConfigOptions.Name = "pnlConfigOptions";
            this.pnlConfigOptions.Size = new System.Drawing.Size(450, 469);
            this.pnlConfigOptions.TabIndex = 31;
            // 
            // cfgFornUsaNumero
            // 
            this.cfgFornUsaNumero.AutoSize = true;
            this.cfgFornUsaNumero.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cfgFornUsaNumero.ForeColor = System.Drawing.Color.White;
            this.cfgFornUsaNumero.Location = new System.Drawing.Point(10, 320);
            this.cfgFornUsaNumero.Name = "cfgFornUsaNumero";
            this.cfgFornUsaNumero.Size = new System.Drawing.Size(169, 29);
            this.cfgFornUsaNumero.TabIndex = 46;
            this.cfgFornUsaNumero.Text = "Usa campo número";
            this.cfgFornUsaNumero.UseVisualStyleBackColor = true;
            this.cfgFornUsaNumero.CheckStateChanged += new System.EventHandler(this.cfgFornUsaNumero_CheckStateChanged);
            // 
            // cfgCliUsaNumero
            // 
            this.cfgCliUsaNumero.AutoSize = true;
            this.cfgCliUsaNumero.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cfgCliUsaNumero.ForeColor = System.Drawing.Color.White;
            this.cfgCliUsaNumero.Location = new System.Drawing.Point(10, 208);
            this.cfgCliUsaNumero.Name = "cfgCliUsaNumero";
            this.cfgCliUsaNumero.Size = new System.Drawing.Size(169, 29);
            this.cfgCliUsaNumero.TabIndex = 45;
            this.cfgCliUsaNumero.Text = "Usa campo número";
            this.cfgCliUsaNumero.UseVisualStyleBackColor = true;
            this.cfgCliUsaNumero.CheckStateChanged += new System.EventHandler(this.cfgCliUsaNumero_CheckStateChanged);
            // 
            // cfgProdSubPadrao
            // 
            this.cfgProdSubPadrao.AutoSize = true;
            this.cfgProdSubPadrao.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cfgProdSubPadrao.ForeColor = System.Drawing.Color.White;
            this.cfgProdSubPadrao.Location = new System.Drawing.Point(10, 115);
            this.cfgProdSubPadrao.Name = "cfgProdSubPadrao";
            this.cfgProdSubPadrao.Size = new System.Drawing.Size(177, 29);
            this.cfgProdSubPadrao.TabIndex = 44;
            this.cfgProdSubPadrao.Text = "Subcategoria Padrão";
            this.cfgProdSubPadrao.UseVisualStyleBackColor = true;
            this.cfgProdSubPadrao.CheckStateChanged += new System.EventHandler(this.cfgProdSubPadrao_CheckStateChanged);
            // 
            // cfgProdBalanca
            // 
            this.cfgProdBalanca.AutoSize = true;
            this.cfgProdBalanca.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cfgProdBalanca.ForeColor = System.Drawing.Color.White;
            this.cfgProdBalanca.Location = new System.Drawing.Point(224, 95);
            this.cfgProdBalanca.Name = "cfgProdBalanca";
            this.cfgProdBalanca.Size = new System.Drawing.Size(117, 29);
            this.cfgProdBalanca.TabIndex = 43;
            this.cfgProdBalanca.Text = "Usa balança";
            this.cfgProdBalanca.UseVisualStyleBackColor = true;
            this.cfgProdBalanca.CheckStateChanged += new System.EventHandler(this.cfgProdBalanca_CheckStateChanged);
            // 
            // cfgAjustaCfop
            // 
            this.cfgAjustaCfop.AutoSize = true;
            this.cfgAjustaCfop.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cfgAjustaCfop.ForeColor = System.Drawing.Color.White;
            this.cfgAjustaCfop.Location = new System.Drawing.Point(224, 75);
            this.cfgAjustaCfop.Name = "cfgAjustaCfop";
            this.cfgAjustaCfop.Size = new System.Drawing.Size(198, 29);
            this.cfgAjustaCfop.TabIndex = 42;
            this.cfgAjustaCfop.Text = "Ajustar CFOP por CSOSN";
            this.cfgAjustaCfop.UseVisualStyleBackColor = true;
            this.cfgAjustaCfop.CheckStateChanged += new System.EventHandler(this.cfgAjustaCfop_CheckStateChanged);
            // 
            // cfgFornShowInat
            // 
            this.cfgFornShowInat.AutoSize = true;
            this.cfgFornShowInat.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cfgFornShowInat.ForeColor = System.Drawing.Color.White;
            this.cfgFornShowInat.Location = new System.Drawing.Point(250, 300);
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
            this.cfgCliShowInat.Location = new System.Drawing.Point(250, 188);
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
            this.cfgProdShowInat.Location = new System.Drawing.Point(10, 95);
            this.cfgProdShowInat.Name = "cfgProdShowInat";
            this.cfgProdShowInat.Size = new System.Drawing.Size(140, 29);
            this.cfgProdShowInat.TabIndex = 39;
            this.cfgProdShowInat.Text = "Mostrar Inativos";
            this.cfgProdShowInat.UseVisualStyleBackColor = true;
            this.cfgProdShowInat.CheckStateChanged += new System.EventHandler(this.cfgProdShowInat_CheckStateChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 262);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 1);
            this.panel2.TabIndex = 38;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 152);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 1);
            this.panel1.TabIndex = 37;
            // 
            // cfgAjustaCofins
            // 
            this.cfgAjustaCofins.AutoSize = true;
            this.cfgAjustaCofins.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cfgAjustaCofins.ForeColor = System.Drawing.Color.White;
            this.cfgAjustaCofins.Location = new System.Drawing.Point(10, 75);
            this.cfgAjustaCofins.Name = "cfgAjustaCofins";
            this.cfgAjustaCofins.Size = new System.Drawing.Size(211, 29);
            this.cfgAjustaCofins.TabIndex = 36;
            this.cfgAjustaCofins.Text = "Ajustar COFINS por CSOSN";
            this.cfgAjustaCofins.UseVisualStyleBackColor = true;
            this.cfgAjustaCofins.CheckStateChanged += new System.EventHandler(this.cfgAjustaCofins_CheckStateChanged);
            // 
            // cfgAjustaPis
            // 
            this.cfgAjustaPis.AutoSize = true;
            this.cfgAjustaPis.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cfgAjustaPis.ForeColor = System.Drawing.Color.White;
            this.cfgAjustaPis.Location = new System.Drawing.Point(224, 55);
            this.cfgAjustaPis.Name = "cfgAjustaPis";
            this.cfgAjustaPis.Size = new System.Drawing.Size(180, 29);
            this.cfgAjustaPis.TabIndex = 35;
            this.cfgAjustaPis.Text = "Ajustar PIS por CSOSN";
            this.cfgAjustaPis.UseVisualStyleBackColor = true;
            this.cfgAjustaPis.CheckStateChanged += new System.EventHandler(this.cfgAjustaPis_CheckStateChanged);
            // 
            // cfgCalcMargem
            // 
            this.cfgCalcMargem.AutoSize = true;
            this.cfgCalcMargem.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cfgCalcMargem.ForeColor = System.Drawing.Color.White;
            this.cfgCalcMargem.Location = new System.Drawing.Point(10, 55);
            this.cfgCalcMargem.Name = "cfgCalcMargem";
            this.cfgCalcMargem.Size = new System.Drawing.Size(151, 29);
            this.cfgCalcMargem.TabIndex = 34;
            this.cfgCalcMargem.Text = "Calcular Margem";
            this.cfgCalcMargem.UseVisualStyleBackColor = true;
            this.cfgCalcMargem.CheckStateChanged += new System.EventHandler(this.cfgCalcMargem_CheckStateChanged);
            // 
            // cfgFornZeroEsquerda
            // 
            this.cfgFornZeroEsquerda.AutoSize = true;
            this.cfgFornZeroEsquerda.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cfgFornZeroEsquerda.ForeColor = System.Drawing.Color.White;
            this.cfgFornZeroEsquerda.Location = new System.Drawing.Point(10, 300);
            this.cfgFornZeroEsquerda.Name = "cfgFornZeroEsquerda";
            this.cfgFornZeroEsquerda.Size = new System.Drawing.Size(217, 29);
            this.cfgFornZeroEsquerda.TabIndex = 33;
            this.cfgFornZeroEsquerda.Text = "Remover zeros a esquerda";
            this.cfgFornZeroEsquerda.UseVisualStyleBackColor = true;
            this.cfgFornZeroEsquerda.CheckStateChanged += new System.EventHandler(this.cfgFornZeroEsquerda_CheckStateChanged);
            // 
            // cfgCliZeroEsquerda
            // 
            this.cfgCliZeroEsquerda.AutoSize = true;
            this.cfgCliZeroEsquerda.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cfgCliZeroEsquerda.ForeColor = System.Drawing.Color.White;
            this.cfgCliZeroEsquerda.Location = new System.Drawing.Point(10, 188);
            this.cfgCliZeroEsquerda.Name = "cfgCliZeroEsquerda";
            this.cfgCliZeroEsquerda.Size = new System.Drawing.Size(217, 29);
            this.cfgCliZeroEsquerda.TabIndex = 32;
            this.cfgCliZeroEsquerda.Text = "Remover zeros a esquerda";
            this.cfgCliZeroEsquerda.UseVisualStyleBackColor = true;
            this.cfgCliZeroEsquerda.CheckStateChanged += new System.EventHandler(this.cfgCliZeroEsquerda_CheckStateChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(153, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 28);
            this.label5.TabIndex = 31;
            this.label5.Text = "Fornecedores";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(172, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 28);
            this.label4.TabIndex = 30;
            this.label4.Text = "Clientes";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(164, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 28);
            this.label3.TabIndex = 29;
            this.label3.Text = "Produtos";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cfgzProdZerosEsquerda
            // 
            this.cfgzProdZerosEsquerda.AutoSize = true;
            this.cfgzProdZerosEsquerda.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cfgzProdZerosEsquerda.ForeColor = System.Drawing.Color.White;
            this.cfgzProdZerosEsquerda.Location = new System.Drawing.Point(224, 35);
            this.cfgzProdZerosEsquerda.Name = "cfgzProdZerosEsquerda";
            this.cfgzProdZerosEsquerda.Size = new System.Drawing.Size(217, 29);
            this.cfgzProdZerosEsquerda.TabIndex = 25;
            this.cfgzProdZerosEsquerda.Text = "Remover zeros a esquerda";
            this.cfgzProdZerosEsquerda.UseVisualStyleBackColor = true;
            this.cfgzProdZerosEsquerda.CheckStateChanged += new System.EventHandler(this.cfgzProdZerosEsquerda_CheckStateChanged);
            // 
            // frmConfigImportacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(444, 599);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboSistema);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSistema;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboEntrada;
        private System.Windows.Forms.Panel pnlConfigOptions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cfgzProdZerosEsquerda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cfgCliZeroEsquerda;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cfgFornZeroEsquerda;
        private System.Windows.Forms.CheckBox cfgCalcMargem;
        private System.Windows.Forms.CheckBox cfgAjustaCofins;
        private System.Windows.Forms.CheckBox cfgAjustaPis;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox cfgProdShowInat;
        private System.Windows.Forms.CheckBox cfgFornShowInat;
        private System.Windows.Forms.CheckBox cfgCliShowInat;
        private System.Windows.Forms.CheckBox cfgAjustaCfop;
        private System.Windows.Forms.CheckBox cfgProdBalanca;
        private System.Windows.Forms.CheckBox cfgProdSubPadrao;
        private System.Windows.Forms.CheckBox cfgCliUsaNumero;
        private System.Windows.Forms.CheckBox cfgFornUsaNumero;
    }
}