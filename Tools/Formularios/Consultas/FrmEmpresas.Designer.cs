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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.gbFiltroConsumo = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.label38 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.label37 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel27 = new System.Windows.Forms.TableLayoutPanel();
            this.rbCreacion = new System.Windows.Forms.RadioButton();
            this.rbEmision = new System.Windows.Forms.RadioButton();
            this.label39 = new System.Windows.Forms.Label();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.rb21 = new System.Windows.Forms.RadioButton();
            this.rb20 = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.chckAceptado = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chckActivo = new System.Windows.Forms.CheckBox();
            this.btnConsumoFolios = new FontAwesome.Sharp.IconButton();
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
            this.tlpGeneral.SuspendLayout();
            this.tlpLog.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tlpForm.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.gbFiltroConsumo.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.tableLayoutPanel27.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.pnl1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEmpresas)).BeginInit();
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
            this.tlpForm.Location = new System.Drawing.Point(8, 9);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.RowCount = 4;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.39437F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.41844F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.31206F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 185F));
            this.tlpForm.Size = new System.Drawing.Size(521, 486);
            this.tlpForm.TabIndex = 24;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.gbFiltroConsumo, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnConsumoFolios, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 303);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.44444F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.55556F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(515, 180);
            this.tableLayoutPanel3.TabIndex = 25;
            // 
            // gbFiltroConsumo
            // 
            this.gbFiltroConsumo.Controls.Add(this.tableLayoutPanel5);
            this.gbFiltroConsumo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFiltroConsumo.Font = new System.Drawing.Font("Calibri", 9.5F, System.Drawing.FontStyle.Bold);
            this.gbFiltroConsumo.Location = new System.Drawing.Point(3, 3);
            this.gbFiltroConsumo.Name = "gbFiltroConsumo";
            this.gbFiltroConsumo.Size = new System.Drawing.Size(509, 137);
            this.gbFiltroConsumo.TabIndex = 4;
            this.gbFiltroConsumo.TabStop = false;
            this.gbFiltroConsumo.Text = "Filtros consumo folios";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel7, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel11, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel9, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.90566F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.13208F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.01887F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(503, 115);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel8, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel10, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 43);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(497, 30);
            this.tableLayoutPanel7.TabIndex = 2;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.16461F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.83539F));
            this.tableLayoutPanel8.Controls.Add(this.label38, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.dtpHasta, 1, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(251, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(243, 24);
            this.tableLayoutPanel8.TabIndex = 0;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label38.Location = new System.Drawing.Point(3, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(43, 24);
            this.label38.TabIndex = 4;
            this.label38.Text = "Hasta:";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpHasta.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(52, 3);
            this.dtpHasta.MaxDate = new System.DateTime(2025, 12, 31, 0, 0, 0, 0);
            this.dtpHasta.MinDate = new System.DateTime(2015, 12, 1, 0, 0, 0, 0);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(188, 21);
            this.dtpHasta.TabIndex = 7;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.79339F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.20661F));
            this.tableLayoutPanel10.Controls.Add(this.label37, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.dtpDesde, 1, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(242, 24);
            this.tableLayoutPanel10.TabIndex = 1;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label37.Location = new System.Drawing.Point(3, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(54, 24);
            this.label37.TabIndex = 2;
            this.label37.Text = "Desde:";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDesde.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(63, 3);
            this.dtpDesde.MaxDate = new System.DateTime(2025, 12, 31, 0, 0, 0, 0);
            this.dtpDesde.MinDate = new System.DateTime(2015, 12, 1, 0, 0, 0, 0);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(176, 21);
            this.dtpDesde.TabIndex = 6;
            this.dtpDesde.Value = new System.DateTime(2023, 7, 13, 0, 0, 0, 0);
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 2;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.99195F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.00805F));
            this.tableLayoutPanel11.Controls.Add(this.tableLayoutPanel27, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.label39, 0, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(3, 79);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 1;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(497, 33);
            this.tableLayoutPanel11.TabIndex = 3;
            // 
            // tableLayoutPanel27
            // 
            this.tableLayoutPanel27.ColumnCount = 2;
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel27.Controls.Add(this.rbCreacion, 1, 0);
            this.tableLayoutPanel27.Controls.Add(this.rbEmision, 0, 0);
            this.tableLayoutPanel27.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel27.Location = new System.Drawing.Point(161, 3);
            this.tableLayoutPanel27.Name = "tableLayoutPanel27";
            this.tableLayoutPanel27.RowCount = 1;
            this.tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel27.Size = new System.Drawing.Size(333, 27);
            this.tableLayoutPanel27.TabIndex = 12;
            // 
            // rbCreacion
            // 
            this.rbCreacion.AutoSize = true;
            this.rbCreacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbCreacion.Location = new System.Drawing.Point(169, 3);
            this.rbCreacion.Name = "rbCreacion";
            this.rbCreacion.Size = new System.Drawing.Size(161, 21);
            this.rbCreacion.TabIndex = 11;
            this.rbCreacion.Text = "Creación";
            this.rbCreacion.UseVisualStyleBackColor = true;
            // 
            // rbEmision
            // 
            this.rbEmision.AutoSize = true;
            this.rbEmision.Checked = true;
            this.rbEmision.Location = new System.Drawing.Point(3, 3);
            this.rbEmision.Name = "rbEmision";
            this.rbEmision.Size = new System.Drawing.Size(67, 19);
            this.rbEmision.TabIndex = 10;
            this.rbEmision.TabStop = true;
            this.rbEmision.Text = "Emisión";
            this.rbEmision.UseVisualStyleBackColor = true;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label39.Location = new System.Drawing.Point(3, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(152, 33);
            this.label39.TabIndex = 17;
            this.label39.Text = "Tipo fecha:";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.95372F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.04628F));
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel12, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(497, 34);
            this.tableLayoutPanel9.TabIndex = 4;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 3;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.79339F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.34343F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.90909F));
            this.tableLayoutPanel12.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.rb21, 1, 0);
            this.tableLayoutPanel12.Controls.Add(this.rb20, 2, 0);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(295, 3);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 1;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(199, 28);
            this.tableLayoutPanel12.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 28);
            this.label1.TabIndex = 22;
            this.label1.Text = "PSE:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rb21
            // 
            this.rb21.AutoSize = true;
            this.rb21.Checked = true;
            this.rb21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rb21.Location = new System.Drawing.Point(52, 3);
            this.rb21.Name = "rb21";
            this.rb21.Size = new System.Drawing.Size(62, 22);
            this.rb21.TabIndex = 23;
            this.rb21.TabStop = true;
            this.rb21.Text = "2.1";
            this.rb21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb21.UseVisualStyleBackColor = true;
            // 
            // rb20
            // 
            this.rb20.AutoSize = true;
            this.rb20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rb20.Location = new System.Drawing.Point(120, 3);
            this.rb20.Name = "rb20";
            this.rb20.Size = new System.Drawing.Size(76, 22);
            this.rb20.TabIndex = 24;
            this.rb20.Text = "2.0";
            this.rb20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb20.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.35888F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.87457F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.76655F));
            this.tableLayoutPanel6.Controls.Add(this.chckAceptado, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.chckActivo, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(286, 28);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // chckAceptado
            // 
            this.chckAceptado.AutoSize = true;
            this.chckAceptado.Checked = true;
            this.chckAceptado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckAceptado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chckAceptado.Location = new System.Drawing.Point(171, 3);
            this.chckAceptado.Name = "chckAceptado";
            this.chckAceptado.Size = new System.Drawing.Size(112, 22);
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
            this.label6.Size = new System.Drawing.Size(83, 28);
            this.label6.TabIndex = 22;
            this.label6.Text = "Estado doc:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chckActivo
            // 
            this.chckActivo.AutoSize = true;
            this.chckActivo.Checked = true;
            this.chckActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckActivo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chckActivo.Location = new System.Drawing.Point(92, 3);
            this.chckActivo.Name = "chckActivo";
            this.chckActivo.Size = new System.Drawing.Size(73, 22);
            this.chckActivo.TabIndex = 13;
            this.chckActivo.Text = "Activo";
            this.chckActivo.UseVisualStyleBackColor = true;
            // 
            // btnConsumoFolios
            // 
            this.btnConsumoFolios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConsumoFolios.FlatAppearance.BorderSize = 0;
            this.btnConsumoFolios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsumoFolios.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.btnConsumoFolios.ForeColor = System.Drawing.Color.White;
            this.btnConsumoFolios.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnConsumoFolios.IconColor = System.Drawing.Color.Black;
            this.btnConsumoFolios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnConsumoFolios.Location = new System.Drawing.Point(3, 146);
            this.btnConsumoFolios.Name = "btnConsumoFolios";
            this.btnConsumoFolios.Size = new System.Drawing.Size(509, 31);
            this.btnConsumoFolios.TabIndex = 22;
            this.btnConsumoFolios.Text = "Buscar consumo de folios";
            this.btnConsumoFolios.UseVisualStyleBackColor = true;
            this.btnConsumoFolios.Click += new System.EventHandler(this.btnConsumoFolios_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ProgressBar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnProcesar, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 254);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.69014F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.30986F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(515, 43);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProgressBar.Location = new System.Drawing.Point(2, 37);
            this.ProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(511, 4);
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
            this.btnProcesar.Size = new System.Drawing.Size(509, 29);
            this.btnProcesar.TabIndex = 22;
            this.btnProcesar.Text = "Buscar datos básicos";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // gbFiltros
            // 
            this.gbFiltros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbFiltros.Controls.Add(this.pnl1);
            this.gbFiltros.Enabled = false;
            this.gbFiltros.Font = new System.Drawing.Font("Calibri", 9.5F, System.Drawing.FontStyle.Bold);
            this.gbFiltros.Location = new System.Drawing.Point(78, 6);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(365, 85);
            this.gbFiltros.TabIndex = 4;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtro inicial";
            // 
            // pnl1
            // 
            this.pnl1.Controls.Add(this.tableLayoutPanel4);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl1.Location = new System.Drawing.Point(3, 19);
            this.pnl1.Margin = new System.Windows.Forms.Padding(2);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(359, 63);
            this.pnl1.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.84431F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.15569F));
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
            this.tableLayoutPanel4.Size = new System.Drawing.Size(359, 63);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // txt_RazonS
            // 
            this.txt_RazonS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txt_RazonS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_RazonS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_RazonS.Location = new System.Drawing.Point(102, 34);
            this.txt_RazonS.MaxLength = 11;
            this.txt_RazonS.Name = "txt_RazonS";
            this.txt_RazonS.Size = new System.Drawing.Size(254, 23);
            this.txt_RazonS.TabIndex = 21;
            this.txt_RazonS.TextChanged += new System.EventHandler(this.txt_RazonS_TextChanged);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label36.Location = new System.Drawing.Point(3, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(93, 31);
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
            this.txt_RucPse.Location = new System.Drawing.Point(102, 3);
            this.txt_RucPse.MaxLength = 11;
            this.txt_RucPse.Name = "txt_RucPse";
            this.txt_RucPse.Size = new System.Drawing.Size(254, 23);
            this.txt_RucPse.TabIndex = 5;
            this.txt_RucPse.TextChanged += new System.EventHandler(this.txt_RucPse_TextChanged);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label40.Location = new System.Drawing.Point(3, 31);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(93, 32);
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
            this.dtgEmpresas.Location = new System.Drawing.Point(3, 100);
            this.dtgEmpresas.MultiSelect = false;
            this.dtgEmpresas.Name = "dtgEmpresas";
            this.dtgEmpresas.ReadOnly = true;
            this.dtgEmpresas.RowHeadersVisible = false;
            this.dtgEmpresas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEmpresas.Size = new System.Drawing.Size(515, 148);
            this.dtgEmpresas.TabIndex = 6;
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
            this.tableLayoutPanel3.ResumeLayout(false);
            this.gbFiltroConsumo.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.tableLayoutPanel27.ResumeLayout(false);
            this.tableLayoutPanel27.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbFiltros.ResumeLayout(false);
            this.pnl1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEmpresas)).EndInit();
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
        private System.Windows.Forms.GroupBox gbFiltroConsumo;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel27;
        private System.Windows.Forms.RadioButton rbCreacion;
        private System.Windows.Forms.RadioButton rbEmision;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chckAceptado;
        private System.Windows.Forms.CheckBox chckActivo;
        private FontAwesome.Sharp.IconButton btnConsumoFolios;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rb21;
        private System.Windows.Forms.RadioButton rb20;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
    }
}