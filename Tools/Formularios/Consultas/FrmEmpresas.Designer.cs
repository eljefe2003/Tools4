namespace Tools
{
    partial class FrmEmpresas
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
            this.tlpGeneral = new System.Windows.Forms.TableLayoutPanel();
            this.tlpLog = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Log = new System.Windows.Forms.Label();
            this.btnBorrarLog = new FontAwesome.Sharp.IconButton();
            this.rtb_Log = new System.Windows.Forms.RichTextBox();
            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ProgressBar = new MetroFramework.Controls.MetroProgressBar();
            this.btnProcesar = new FontAwesome.Sharp.IconButton();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.txt_RazonS = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.txt_RucPse = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.dtgEmpresas = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.tableLayoutPanel27 = new System.Windows.Forms.TableLayoutPanel();
            this.rbCreacion = new System.Windows.Forms.RadioButton();
            this.rbEmision = new System.Windows.Forms.RadioButton();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel32 = new System.Windows.Forms.TableLayoutPanel();
            this.chckActivo = new System.Windows.Forms.CheckBox();
            this.chckAceptado = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tlpGeneral.SuspendLayout();
            this.tlpLog.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tlpForm.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.pnl1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEmpresas)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel27.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel32.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpGeneral
            // 
            this.tlpGeneral.BackColor = System.Drawing.Color.White;
            this.tlpGeneral.ColumnCount = 2;
            this.tlpGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.31512F));
            this.tlpGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.68488F));
            this.tlpGeneral.Controls.Add(this.tlpLog, 1, 0);
            this.tlpGeneral.Controls.Add(this.tlpForm, 0, 0);
            this.tlpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGeneral.Location = new System.Drawing.Point(0, 0);
            this.tlpGeneral.Name = "tlpGeneral";
            this.tlpGeneral.RowCount = 1;
            this.tlpGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpGeneral.Size = new System.Drawing.Size(878, 505);
            this.tlpGeneral.TabIndex = 25;
            // 
            // tlpLog
            // 
            this.tlpLog.BackColor = System.Drawing.Color.Transparent;
            this.tlpLog.ColumnCount = 1;
            this.tlpLog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLog.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tlpLog.Controls.Add(this.rtb_Log, 0, 1);
            this.tlpLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLog.Location = new System.Drawing.Point(540, 2);
            this.tlpLog.Margin = new System.Windows.Forms.Padding(2);
            this.tlpLog.Name = "tlpLog";
            this.tlpLog.RowCount = 2;
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.784431F));
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.21557F));
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLog.Size = new System.Drawing.Size(336, 501);
            this.tlpLog.TabIndex = 23;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.45454F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.54545F));
            this.tableLayoutPanel2.Controls.Add(this.lbl_Log, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnBorrarLog, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(330, 33);
            this.tableLayoutPanel2.TabIndex = 22;
            // 
            // lbl_Log
            // 
            this.lbl_Log.AutoSize = true;
            this.lbl_Log.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Log.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Log.ForeColor = System.Drawing.Color.White;
            this.lbl_Log.Location = new System.Drawing.Point(3, 0);
            this.lbl_Log.Name = "lbl_Log";
            this.lbl_Log.Size = new System.Drawing.Size(276, 33);
            this.lbl_Log.TabIndex = 3;
            this.lbl_Log.Text = "Log";
            this.lbl_Log.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBorrarLog
            // 
            this.btnBorrarLog.BackColor = System.Drawing.Color.Transparent;
            this.btnBorrarLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBorrarLog.FlatAppearance.BorderSize = 0;
            this.btnBorrarLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrarLog.IconChar = FontAwesome.Sharp.IconChar.Eraser;
            this.btnBorrarLog.IconColor = System.Drawing.Color.Black;
            this.btnBorrarLog.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBorrarLog.IconSize = 20;
            this.btnBorrarLog.Location = new System.Drawing.Point(285, 3);
            this.btnBorrarLog.Name = "btnBorrarLog";
            this.btnBorrarLog.Size = new System.Drawing.Size(42, 27);
            this.btnBorrarLog.TabIndex = 0;
            this.btnBorrarLog.UseVisualStyleBackColor = false;
            this.btnBorrarLog.Click += new System.EventHandler(this.btnBorrarLog_Click);
            // 
            // rtb_Log
            // 
            this.rtb_Log.BackColor = System.Drawing.SystemColors.Window;
            this.rtb_Log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Log.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_Log.ForeColor = System.Drawing.Color.White;
            this.rtb_Log.Location = new System.Drawing.Point(3, 42);
            this.rtb_Log.Name = "rtb_Log";
            this.rtb_Log.Size = new System.Drawing.Size(330, 456);
            this.rtb_Log.TabIndex = 4;
            this.rtb_Log.Text = "";
            // 
            // tlpForm
            // 
            this.tlpForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tlpForm.ColumnCount = 1;
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpForm.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tlpForm.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.tlpForm.Controls.Add(this.gbFiltros, 0, 0);
            this.tlpForm.Controls.Add(this.dtgEmpresas, 0, 1);
            this.tlpForm.Location = new System.Drawing.Point(31, 18);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.RowCount = 4;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.39437F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.22535F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.38028F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 188F));
            this.tlpForm.Size = new System.Drawing.Size(475, 468);
            this.tlpForm.TabIndex = 24;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ProgressBar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnProcesar, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 244);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.69014F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.30986F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(469, 31);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProgressBar.Location = new System.Drawing.Point(2, 27);
            this.ProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(465, 2);
            this.ProgressBar.TabIndex = 23;
            // 
            // btnProcesar
            // 
            this.btnProcesar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProcesar.FlatAppearance.BorderSize = 0;
            this.btnProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcesar.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.btnProcesar.ForeColor = System.Drawing.Color.White;
            this.btnProcesar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnProcesar.IconColor = System.Drawing.Color.Black;
            this.btnProcesar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProcesar.Location = new System.Drawing.Point(3, 3);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(463, 19);
            this.btnProcesar.TabIndex = 22;
            this.btnProcesar.Text = "Buscar datos básicos";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.pnl1);
            this.gbFiltros.Enabled = false;
            this.gbFiltros.Font = new System.Drawing.Font("Calibri", 9.5F, System.Drawing.FontStyle.Bold);
            this.gbFiltros.Location = new System.Drawing.Point(3, 3);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(469, 84);
            this.gbFiltros.TabIndex = 4;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
            // 
            // pnl1
            // 
            this.pnl1.Controls.Add(this.tableLayoutPanel4);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl1.Location = new System.Drawing.Point(3, 19);
            this.pnl1.Margin = new System.Windows.Forms.Padding(2);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(463, 62);
            this.pnl1.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.84431F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.15569F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.txt_RazonS, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label36, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.txt_RucPse, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label40, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.41322F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.58678F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(463, 62);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // txt_RazonS
            // 
            this.txt_RazonS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txt_RazonS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_RazonS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_RazonS.Location = new System.Drawing.Point(126, 34);
            this.txt_RazonS.MaxLength = 11;
            this.txt_RazonS.Name = "txt_RazonS";
            this.txt_RazonS.Size = new System.Drawing.Size(313, 23);
            this.txt_RazonS.TabIndex = 21;
            this.txt_RazonS.TextChanged += new System.EventHandler(this.txt_RazonS_TextChanged);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label36.Location = new System.Drawing.Point(3, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(117, 31);
            this.label36.TabIndex = 0;
            this.label36.Text = "Ruc:";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_RucPse
            // 
            this.txt_RucPse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txt_RucPse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_RucPse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_RucPse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_RucPse.Location = new System.Drawing.Point(126, 3);
            this.txt_RucPse.MaxLength = 11;
            this.txt_RucPse.Name = "txt_RucPse";
            this.txt_RucPse.Size = new System.Drawing.Size(313, 23);
            this.txt_RucPse.TabIndex = 5;
            this.txt_RucPse.TextChanged += new System.EventHandler(this.txt_RucPse_TextChanged);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label40.Location = new System.Drawing.Point(3, 31);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(117, 31);
            this.label40.TabIndex = 19;
            this.label40.Text = "Razón S.:";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtgEmpresas
            // 
            this.dtgEmpresas.AllowUserToOrderColumns = true;
            this.dtgEmpresas.AllowUserToResizeColumns = false;
            this.dtgEmpresas.AllowUserToResizeRows = false;
            this.dtgEmpresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEmpresas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgEmpresas.Location = new System.Drawing.Point(3, 93);
            this.dtgEmpresas.MultiSelect = false;
            this.dtgEmpresas.Name = "dtgEmpresas";
            this.dtgEmpresas.ReadOnly = true;
            this.dtgEmpresas.RowHeadersVisible = false;
            this.dtgEmpresas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEmpresas.Size = new System.Drawing.Size(469, 145);
            this.dtgEmpresas.TabIndex = 6;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.iconButton1, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(76, 281);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.7734F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.2266F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(323, 184);
            this.tableLayoutPanel3.TabIndex = 25;
            // 
            // iconButton1
            // 
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.iconButton1.ForeColor = System.Drawing.Color.White;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(3, 153);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(317, 28);
            this.iconButton1.TabIndex = 22;
            this.iconButton1.Text = "Buscar consumo de folios";
            this.iconButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel9);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9.5F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 144);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros consumo folios";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label37.Location = new System.Drawing.Point(3, 30);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(80, 30);
            this.label37.TabIndex = 2;
            this.label37.Text = "Desde:";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label38.Location = new System.Drawing.Point(3, 60);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(80, 30);
            this.label38.TabIndex = 4;
            this.label38.Text = "Hasta:";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label39.Location = new System.Drawing.Point(3, 90);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(80, 32);
            this.label39.TabIndex = 17;
            this.label39.Text = "Tipo fecha:";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel27
            // 
            this.tableLayoutPanel27.ColumnCount = 2;
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel27.Controls.Add(this.rbCreacion, 1, 0);
            this.tableLayoutPanel27.Controls.Add(this.rbEmision, 0, 0);
            this.tableLayoutPanel27.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel27.Location = new System.Drawing.Point(89, 93);
            this.tableLayoutPanel27.Name = "tableLayoutPanel27";
            this.tableLayoutPanel27.RowCount = 1;
            this.tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel27.Size = new System.Drawing.Size(219, 26);
            this.tableLayoutPanel27.TabIndex = 12;
            // 
            // rbCreacion
            // 
            this.rbCreacion.AutoSize = true;
            this.rbCreacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbCreacion.Enabled = false;
            this.rbCreacion.Location = new System.Drawing.Point(112, 3);
            this.rbCreacion.Name = "rbCreacion";
            this.rbCreacion.Size = new System.Drawing.Size(104, 20);
            this.rbCreacion.TabIndex = 11;
            this.rbCreacion.Text = "Creación";
            this.rbCreacion.UseVisualStyleBackColor = true;
            // 
            // rbEmision
            // 
            this.rbEmision.AutoSize = true;
            this.rbEmision.Checked = true;
            this.rbEmision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbEmision.Enabled = false;
            this.rbEmision.Location = new System.Drawing.Point(3, 3);
            this.rbEmision.Name = "rbEmision";
            this.rbEmision.Size = new System.Drawing.Size(103, 20);
            this.rbEmision.TabIndex = 10;
            this.rbEmision.TabStop = true;
            this.rbEmision.Text = "Emisión";
            this.rbEmision.UseVisualStyleBackColor = true;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDesde.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold);
            this.dtpDesde.Location = new System.Drawing.Point(89, 33);
            this.dtpDesde.MaxDate = new System.DateTime(2029, 12, 31, 0, 0, 0, 0);
            this.dtpDesde.MinDate = new System.DateTime(2015, 12, 1, 0, 0, 0, 0);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(219, 21);
            this.dtpDesde.TabIndex = 6;
            this.dtpDesde.Value = new System.DateTime(2021, 1, 1, 12, 56, 0, 0);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpHasta.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold);
            this.dtpHasta.Location = new System.Drawing.Point(89, 63);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(219, 21);
            this.dtpHasta.TabIndex = 7;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.84431F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.15569F));
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel27, 1, 3);
            this.tableLayoutPanel9.Controls.Add(this.label38, 0, 2);
            this.tableLayoutPanel9.Controls.Add(this.label39, 0, 3);
            this.tableLayoutPanel9.Controls.Add(this.label37, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.dtpHasta, 1, 2);
            this.tableLayoutPanel9.Controls.Add(this.dtpDesde, 1, 1);
            this.tableLayoutPanel9.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel32, 1, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 4;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(311, 122);
            this.tableLayoutPanel9.TabIndex = 0;
            // 
            // tableLayoutPanel32
            // 
            this.tableLayoutPanel32.ColumnCount = 2;
            this.tableLayoutPanel32.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel32.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel32.Controls.Add(this.chckAceptado, 1, 0);
            this.tableLayoutPanel32.Controls.Add(this.chckActivo, 0, 0);
            this.tableLayoutPanel32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel32.Location = new System.Drawing.Point(89, 3);
            this.tableLayoutPanel32.Name = "tableLayoutPanel32";
            this.tableLayoutPanel32.RowCount = 1;
            this.tableLayoutPanel32.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel32.Size = new System.Drawing.Size(219, 24);
            this.tableLayoutPanel32.TabIndex = 16;
            // 
            // chckActivo
            // 
            this.chckActivo.AutoSize = true;
            this.chckActivo.Checked = true;
            this.chckActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckActivo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chckActivo.Location = new System.Drawing.Point(3, 3);
            this.chckActivo.Name = "chckActivo";
            this.chckActivo.Size = new System.Drawing.Size(103, 18);
            this.chckActivo.TabIndex = 13;
            this.chckActivo.Text = "Activo";
            this.chckActivo.UseVisualStyleBackColor = true;
            // 
            // chckAceptado
            // 
            this.chckAceptado.AutoSize = true;
            this.chckAceptado.Checked = true;
            this.chckAceptado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckAceptado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chckAceptado.Location = new System.Drawing.Point(112, 3);
            this.chckAceptado.Name = "chckAceptado";
            this.chckAceptado.Size = new System.Drawing.Size(104, 18);
            this.chckAceptado.TabIndex = 15;
            this.chckAceptado.Text = "Aceptado";
            this.chckAceptado.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 30);
            this.label6.TabIndex = 22;
            this.label6.Text = "Tipo estado:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 505);
            this.Controls.Add(this.tlpGeneral);
            this.Name = "FrmEmpresas";
            this.Text = "Empresas";
            this.Load += new System.EventHandler(this.FrmEmpresas_Load);
            this.tlpGeneral.ResumeLayout(false);
            this.tlpLog.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tlpForm.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbFiltros.ResumeLayout(false);
            this.pnl1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEmpresas)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel27.ResumeLayout(false);
            this.tableLayoutPanel27.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tableLayoutPanel32.ResumeLayout(false);
            this.tableLayoutPanel32.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpGeneral;
        private System.Windows.Forms.TableLayoutPanel tlpLog;
        public System.Windows.Forms.RichTextBox rtb_Log;
        private System.Windows.Forms.TableLayoutPanel tlpForm;
        private FontAwesome.Sharp.IconButton btnProcesar;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroProgressBar ProgressBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox txt_RazonS;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox txt_RucPse;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.DataGridView dtgEmpresas;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lbl_Log;
        private FontAwesome.Sharp.IconButton btnBorrarLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel27;
        private System.Windows.Forms.RadioButton rbCreacion;
        private System.Windows.Forms.RadioButton rbEmision;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel32;
        private System.Windows.Forms.CheckBox chckAceptado;
        private System.Windows.Forms.CheckBox chckActivo;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}