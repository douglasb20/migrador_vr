namespace MigradorRP
{
    partial class frmMain
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblTopBar = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblTabForn = new System.Windows.Forms.Label();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.btnValidateFiles = new FontAwesome.Sharp.IconButton();
            this.tmrBorda = new System.Windows.Forms.Timer(this.components);
            this.pnlBorda = new System.Windows.Forms.Panel();
            this.btnCancelFiles = new FontAwesome.Sharp.IconButton();
            this.lblTabProd = new System.Windows.Forms.Label();
            this.lblTabClient = new System.Windows.Forms.Label();
            this.pnlDadosImp = new System.Windows.Forms.Panel();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.dtGridFornecedores = new System.Windows.Forms.DataGridView();
            this.dtGridClientes = new System.Windows.Forms.DataGridView();
            this.dtGridProdutos = new System.Windows.Forms.DataGridView();
            this.btnMin = new FontAwesome.Sharp.IconButton();
            this.btnSetSystem = new FontAwesome.Sharp.IconButton();
            this.lblAviso = new System.Windows.Forms.Label();
            this.btnImport = new FontAwesome.Sharp.IconButton();
            this.chkProd = new System.Windows.Forms.CheckBox();
            this.chkCliente = new System.Windows.Forms.CheckBox();
            this.chkFornecedores = new System.Windows.Forms.CheckBox();
            this.dirOut = new System.Windows.Forms.FolderBrowserDialog();
            this.cboFileMode = new System.Windows.Forms.ComboBox();
            this.pnlDadosImp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridFornecedores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTopBar
            // 
            this.lblTopBar.BackColor = System.Drawing.Color.Transparent;
            this.lblTopBar.Font = new System.Drawing.Font("Poppins Medium", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopBar.ForeColor = System.Drawing.Color.White;
            this.lblTopBar.Location = new System.Drawing.Point(0, 0);
            this.lblTopBar.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblTopBar.Name = "lblTopBar";
            this.lblTopBar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblTopBar.Size = new System.Drawing.Size(915, 40);
            this.lblTopBar.TabIndex = 0;
            this.lblTopBar.Text = "SISTEMA";
            this.lblTopBar.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblTopBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTopBar_MouseDown);
            this.lblTopBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTopBar_MouseMove);
            // 
            // lblClose
            // 
            this.lblClose.BackColor = System.Drawing.Color.Transparent;
            this.lblClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(945, 0);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(30, 30);
            this.lblClose.TabIndex = 1;
            this.lblClose.Text = "X";
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            this.lblClose.MouseEnter += new System.EventHandler(this.lblClose_MouseEnter);
            this.lblClose.MouseLeave += new System.EventHandler(this.lblClose_MouseLeave);
            // 
            // lblTabForn
            // 
            this.lblTabForn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTabForn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTabForn.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTabForn.ForeColor = System.Drawing.Color.White;
            this.lblTabForn.Location = new System.Drawing.Point(340, 10);
            this.lblTabForn.Name = "lblTabForn";
            this.lblTabForn.Size = new System.Drawing.Size(150, 30);
            this.lblTabForn.TabIndex = 8;
            this.lblTabForn.Text = "Fornecedores";
            this.lblTabForn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTabForn.Click += new System.EventHandler(this.lblTabForn_Click);
            // 
            // imgList
            // 
            this.imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgList.ImageSize = new System.Drawing.Size(16, 16);
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnValidateFiles
            // 
            this.btnValidateFiles.AccessibleDescription = "Validar planilhas";
            this.btnValidateFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(80)))), ((int)(((byte)(110)))));
            this.btnValidateFiles.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(110)))), ((int)(((byte)(155)))));
            this.btnValidateFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValidateFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnValidateFiles.ForeColor = System.Drawing.Color.White;
            this.btnValidateFiles.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnValidateFiles.IconColor = System.Drawing.Color.White;
            this.btnValidateFiles.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnValidateFiles.IconSize = 20;
            this.btnValidateFiles.Location = new System.Drawing.Point(358, 41);
            this.btnValidateFiles.Name = "btnValidateFiles";
            this.btnValidateFiles.Size = new System.Drawing.Size(40, 40);
            this.btnValidateFiles.TabIndex = 13;
            this.btnValidateFiles.UseVisualStyleBackColor = false;
            this.btnValidateFiles.Click += new System.EventHandler(this.btnValidateFiles_Click);
            // 
            // tmrBorda
            // 
            this.tmrBorda.Interval = 1;
            // 
            // pnlBorda
            // 
            this.pnlBorda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(247)))), ((int)(((byte)(160)))));
            this.pnlBorda.Location = new System.Drawing.Point(10, 40);
            this.pnlBorda.Name = "pnlBorda";
            this.pnlBorda.Size = new System.Drawing.Size(150, 3);
            this.pnlBorda.TabIndex = 16;
            // 
            // btnCancelFiles
            // 
            this.btnCancelFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(80)))), ((int)(((byte)(110)))));
            this.btnCancelFiles.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(110)))), ((int)(((byte)(155)))));
            this.btnCancelFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnCancelFiles.ForeColor = System.Drawing.Color.White;
            this.btnCancelFiles.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnCancelFiles.IconColor = System.Drawing.Color.White;
            this.btnCancelFiles.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelFiles.IconSize = 20;
            this.btnCancelFiles.Location = new System.Drawing.Point(404, 41);
            this.btnCancelFiles.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancelFiles.Name = "btnCancelFiles";
            this.btnCancelFiles.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.btnCancelFiles.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCancelFiles.Size = new System.Drawing.Size(40, 40);
            this.btnCancelFiles.TabIndex = 17;
            this.btnCancelFiles.UseVisualStyleBackColor = false;
            this.btnCancelFiles.Click += new System.EventHandler(this.btnCancelFiles_Click);
            // 
            // lblTabProd
            // 
            this.lblTabProd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTabProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTabProd.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTabProd.ForeColor = System.Drawing.Color.White;
            this.lblTabProd.Location = new System.Drawing.Point(10, 10);
            this.lblTabProd.Name = "lblTabProd";
            this.lblTabProd.Size = new System.Drawing.Size(150, 30);
            this.lblTabProd.TabIndex = 18;
            this.lblTabProd.Text = "Produtos";
            this.lblTabProd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTabProd.Click += new System.EventHandler(this.lblTabProd_Click);
            // 
            // lblTabClient
            // 
            this.lblTabClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTabClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTabClient.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTabClient.ForeColor = System.Drawing.Color.White;
            this.lblTabClient.Location = new System.Drawing.Point(175, 10);
            this.lblTabClient.Name = "lblTabClient";
            this.lblTabClient.Size = new System.Drawing.Size(150, 30);
            this.lblTabClient.TabIndex = 19;
            this.lblTabClient.Text = "Clientes";
            this.lblTabClient.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTabClient.Click += new System.EventHandler(this.lblTabClient_Click);
            // 
            // pnlDadosImp
            // 
            this.pnlDadosImp.Controls.Add(this.lblRegistros);
            this.pnlDadosImp.Controls.Add(this.dtGridFornecedores);
            this.pnlDadosImp.Controls.Add(this.dtGridClientes);
            this.pnlDadosImp.Controls.Add(this.dtGridProdutos);
            this.pnlDadosImp.Controls.Add(this.lblTabProd);
            this.pnlDadosImp.Controls.Add(this.lblTabClient);
            this.pnlDadosImp.Controls.Add(this.lblTabForn);
            this.pnlDadosImp.Controls.Add(this.pnlBorda);
            this.pnlDadosImp.Location = new System.Drawing.Point(0, 102);
            this.pnlDadosImp.Name = "pnlDadosImp";
            this.pnlDadosImp.Size = new System.Drawing.Size(975, 593);
            this.pnlDadosImp.TabIndex = 20;
            // 
            // lblRegistros
            // 
            this.lblRegistros.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.White;
            this.lblRegistros.Location = new System.Drawing.Point(777, 40);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblRegistros.Size = new System.Drawing.Size(198, 28);
            this.lblRegistros.TabIndex = 31;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtGridFornecedores
            // 
            this.dtGridFornecedores.AllowUserToAddRows = false;
            this.dtGridFornecedores.AllowUserToDeleteRows = false;
            this.dtGridFornecedores.AllowUserToResizeRows = false;
            this.dtGridFornecedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtGridFornecedores.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtGridFornecedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGridFornecedores.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtGridFornecedores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtGridFornecedores.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtGridFornecedores.Location = new System.Drawing.Point(554, 120);
            this.dtGridFornecedores.MultiSelect = false;
            this.dtGridFornecedores.Name = "dtGridFornecedores";
            this.dtGridFornecedores.ReadOnly = true;
            this.dtGridFornecedores.RowHeadersVisible = false;
            this.dtGridFornecedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGridFornecedores.ShowEditingIcon = false;
            this.dtGridFornecedores.ShowRowErrors = false;
            this.dtGridFornecedores.Size = new System.Drawing.Size(257, 136);
            this.dtGridFornecedores.TabIndex = 22;
            // 
            // dtGridClientes
            // 
            this.dtGridClientes.AllowUserToAddRows = false;
            this.dtGridClientes.AllowUserToDeleteRows = false;
            this.dtGridClientes.AllowUserToResizeRows = false;
            this.dtGridClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtGridClientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtGridClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGridClientes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtGridClientes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtGridClientes.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtGridClientes.Location = new System.Drawing.Point(279, 120);
            this.dtGridClientes.MultiSelect = false;
            this.dtGridClientes.Name = "dtGridClientes";
            this.dtGridClientes.ReadOnly = true;
            this.dtGridClientes.RowHeadersVisible = false;
            this.dtGridClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGridClientes.ShowEditingIcon = false;
            this.dtGridClientes.ShowRowErrors = false;
            this.dtGridClientes.Size = new System.Drawing.Size(257, 136);
            this.dtGridClientes.TabIndex = 21;
            // 
            // dtGridProdutos
            // 
            this.dtGridProdutos.AllowUserToAddRows = false;
            this.dtGridProdutos.AllowUserToDeleteRows = false;
            this.dtGridProdutos.AllowUserToResizeRows = false;
            this.dtGridProdutos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtGridProdutos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtGridProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGridProdutos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtGridProdutos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtGridProdutos.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtGridProdutos.Location = new System.Drawing.Point(0, 120);
            this.dtGridProdutos.MultiSelect = false;
            this.dtGridProdutos.Name = "dtGridProdutos";
            this.dtGridProdutos.ReadOnly = true;
            this.dtGridProdutos.RowHeadersVisible = false;
            this.dtGridProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGridProdutos.ShowEditingIcon = false;
            this.dtGridProdutos.ShowRowErrors = false;
            this.dtGridProdutos.Size = new System.Drawing.Size(257, 136);
            this.dtGridProdutos.TabIndex = 20;
            // 
            // btnMin
            // 
            this.btnMin.BackColor = System.Drawing.Color.Transparent;
            this.btnMin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnMin.ForeColor = System.Drawing.Color.White;
            this.btnMin.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.btnMin.IconColor = System.Drawing.Color.White;
            this.btnMin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMin.IconSize = 20;
            this.btnMin.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMin.Location = new System.Drawing.Point(915, 0);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(30, 30);
            this.btnMin.TabIndex = 21;
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Click += new System.EventHandler(this.lblMin_Click);
            this.btnMin.MouseEnter += new System.EventHandler(this.btnMin_MouseEnter);
            this.btnMin.MouseLeave += new System.EventHandler(this.btnMin_MouseLeave);
            // 
            // btnSetSystem
            // 
            this.btnSetSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSetSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetSystem.IconChar = FontAwesome.Sharp.IconChar.Gear;
            this.btnSetSystem.IconColor = System.Drawing.Color.Black;
            this.btnSetSystem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSetSystem.IconSize = 28;
            this.btnSetSystem.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnSetSystem.Location = new System.Drawing.Point(935, 50);
            this.btnSetSystem.Name = "btnSetSystem";
            this.btnSetSystem.Size = new System.Drawing.Size(40, 40);
            this.btnSetSystem.TabIndex = 22;
            this.btnSetSystem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSetSystem.UseVisualStyleBackColor = false;
            this.btnSetSystem.Click += new System.EventHandler(this.btnSetSystem_Click);
            // 
            // lblAviso
            // 
            this.lblAviso.Font = new System.Drawing.Font("Poppins", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAviso.ForeColor = System.Drawing.Color.White;
            this.lblAviso.Location = new System.Drawing.Point(0, 150);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(975, 39);
            this.lblAviso.TabIndex = 29;
            this.lblAviso.Text = "Aviso";
            this.lblAviso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(80)))), ((int)(((byte)(110)))));
            this.btnImport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(110)))), ((int)(((byte)(155)))));
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.IconChar = FontAwesome.Sharp.IconChar.FileImport;
            this.btnImport.IconColor = System.Drawing.Color.White;
            this.btnImport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImport.IconSize = 20;
            this.btnImport.Location = new System.Drawing.Point(795, 50);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(120, 40);
            this.btnImport.TabIndex = 30;
            this.btnImport.Text = "Exportar";
            this.btnImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // chkProd
            // 
            this.chkProd.AutoSize = true;
            this.chkProd.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkProd.ForeColor = System.Drawing.Color.White;
            this.chkProd.Location = new System.Drawing.Point(10, 50);
            this.chkProd.Name = "chkProd";
            this.chkProd.Size = new System.Drawing.Size(92, 29);
            this.chkProd.TabIndex = 31;
            this.chkProd.Text = "Produtos";
            this.chkProd.UseVisualStyleBackColor = true;
            // 
            // chkCliente
            // 
            this.chkCliente.AutoSize = true;
            this.chkCliente.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCliente.ForeColor = System.Drawing.Color.White;
            this.chkCliente.Location = new System.Drawing.Point(110, 50);
            this.chkCliente.Name = "chkCliente";
            this.chkCliente.Size = new System.Drawing.Size(87, 29);
            this.chkCliente.TabIndex = 32;
            this.chkCliente.Text = "Clientes";
            this.chkCliente.UseVisualStyleBackColor = true;
            // 
            // chkFornecedores
            // 
            this.chkFornecedores.AutoSize = true;
            this.chkFornecedores.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFornecedores.ForeColor = System.Drawing.Color.White;
            this.chkFornecedores.Location = new System.Drawing.Point(200, 50);
            this.chkFornecedores.Name = "chkFornecedores";
            this.chkFornecedores.Size = new System.Drawing.Size(127, 29);
            this.chkFornecedores.TabIndex = 33;
            this.chkFornecedores.Text = "Fornecedores";
            this.chkFornecedores.UseVisualStyleBackColor = true;
            // 
            // dirOut
            // 
            this.dirOut.Description = "Selecione onde as planilhas serão criadas";
            // 
            // cboFileMode
            // 
            this.cboFileMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFileMode.Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFileMode.FormattingEnabled = true;
            this.cboFileMode.ItemHeight = 23;
            this.cboFileMode.Location = new System.Drawing.Point(465, 48);
            this.cboFileMode.Name = "cboFileMode";
            this.cboFileMode.Size = new System.Drawing.Size(150, 31);
            this.cboFileMode.TabIndex = 34;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(29)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(975, 700);
            this.Controls.Add(this.cboFileMode);
            this.Controls.Add(this.chkFornecedores);
            this.Controls.Add(this.chkCliente);
            this.Controls.Add(this.chkProd);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.btnSetSystem);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.pnlDadosImp);
            this.Controls.Add(this.btnCancelFiles);
            this.Controls.Add(this.btnValidateFiles);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblTopBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automatec Sistemas | MigradorRP";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlDadosImp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridFornecedores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridProdutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTopBar;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.ImageList imgList;
        private FontAwesome.Sharp.IconButton btnValidateFiles;
        private System.Windows.Forms.Panel pnlBorda;
        private System.Windows.Forms.Panel pnlDadosImp;
        private System.Windows.Forms.Label lblTabForn;
        private System.Windows.Forms.Label lblTabProd;
        private System.Windows.Forms.Label lblTabClient;
        private System.Windows.Forms.Timer tmrBorda;
        private FontAwesome.Sharp.IconButton btnMin;
        private FontAwesome.Sharp.IconButton btnSetSystem;
        private System.Windows.Forms.DataGridView dtGridProdutos;
        private System.Windows.Forms.DataGridView dtGridFornecedores;
        private System.Windows.Forms.DataGridView dtGridClientes;
        private System.Windows.Forms.Label lblAviso;
        private FontAwesome.Sharp.IconButton btnImport;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.CheckBox chkProd;
        private System.Windows.Forms.CheckBox chkCliente;
        private System.Windows.Forms.CheckBox chkFornecedores;
        private System.Windows.Forms.FolderBrowserDialog dirOut;
        public FontAwesome.Sharp.IconButton btnCancelFiles;
        private System.Windows.Forms.ComboBox cboFileMode;
    }
}

