
namespace Tools
{
    partial class FrmEjemplos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpGeneral = new System.Windows.Forms.TableLayoutPanel();
            this.tlpLog = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Log = new System.Windows.Forms.Label();
            this.btnBorrarLog = new FontAwesome.Sharp.IconButton();
            this.rtb_Log = new System.Windows.Forms.RichTextBox();
            this.tlpIzquierda = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel56 = new System.Windows.Forms.TableLayoutPanel();
            this.dtgEjemplos = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.gbAcciones = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnProbarTodos = new FontAwesome.Sharp.IconButton();
            this.pnlDescargas = new System.Windows.Forms.Panel();
            this.tlp_archivos = new System.Windows.Forms.TableLayoutPanel();
            this.chckTodo = new System.Windows.Forms.CheckBox();
            this.chckTxtEjemplos = new System.Windows.Forms.CheckBox();
            this.chckRequestEjemplos = new System.Windows.Forms.CheckBox();
            this.chckCdrEjemplos = new System.Windows.Forms.CheckBox();
            this.chckXmlEjemplos = new System.Windows.Forms.CheckBox();
            this.chckPdfEjemplos = new System.Windows.Forms.CheckBox();
            this.btnDescargaEjemplos = new FontAwesome.Sharp.IconButton();
            this.chckSpeech = new System.Windows.Forms.CheckBox();
            this.chckJsonEjemplos = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDescargas = new AltoControls.SlideButton();
            this.label1 = new System.Windows.Forms.Label();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel57 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chckDemo = new AltoControls.SlideButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTipoDoc = new MetroFramework.Controls.MetroComboBox();
            this.txtBusquedaEjemplo = new MetroFramework.Controls.MetroTextBox();
            this.tlpGeneral.SuspendLayout();
            this.tlpLog.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tlpIzquierda.SuspendLayout();
            this.tableLayoutPanel56.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEjemplos)).BeginInit();
            this.tableLayoutPanel14.SuspendLayout();
            this.gbAcciones.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlDescargas.SuspendLayout();
            this.tlp_archivos.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.tableLayoutPanel57.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpGeneral
            // 
            this.tlpGeneral.BackColor = System.Drawing.Color.White;
            this.tlpGeneral.ColumnCount = 2;
            this.tlpGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGeneral.Controls.Add(this.tlpLog, 0, 0);
            this.tlpGeneral.Controls.Add(this.tlpIzquierda, 0, 0);
            this.tlpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGeneral.Location = new System.Drawing.Point(0, 0);
            this.tlpGeneral.Margin = new System.Windows.Forms.Padding(4);
            this.tlpGeneral.Name = "tlpGeneral";
            this.tlpGeneral.RowCount = 1;
            this.tlpGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGeneral.Size = new System.Drawing.Size(1544, 748);
            this.tlpGeneral.TabIndex = 27;
            // 
            // tlpLog
            // 
            this.tlpLog.BackColor = System.Drawing.Color.Transparent;
            this.tlpLog.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpLog.ColumnCount = 1;
            this.tlpLog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLog.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tlpLog.Controls.Add(this.rtb_Log, 0, 1);
            this.tlpLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLog.Location = new System.Drawing.Point(775, 2);
            this.tlpLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlpLog.Name = "tlpLog";
            this.tlpLog.RowCount = 2;
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.13245F));
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.86755F));
            this.tlpLog.Size = new System.Drawing.Size(766, 744);
            this.tlpLog.TabIndex = 25;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.45454F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.54545F));
            this.tableLayoutPanel4.Controls.Add(this.lbl_Log, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnBorrarLog, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(756, 30);
            this.tableLayoutPanel4.TabIndex = 6;
            // 
            // lbl_Log
            // 
            this.lbl_Log.AutoSize = true;
            this.lbl_Log.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Log.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Log.ForeColor = System.Drawing.Color.Black;
            this.lbl_Log.Location = new System.Drawing.Point(4, 0);
            this.lbl_Log.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Log.Name = "lbl_Log";
            this.lbl_Log.Size = new System.Drawing.Size(638, 30);
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
            this.btnBorrarLog.IconSize = 25;
            this.btnBorrarLog.Location = new System.Drawing.Point(650, 4);
            this.btnBorrarLog.Margin = new System.Windows.Forms.Padding(4);
            this.btnBorrarLog.Name = "btnBorrarLog";
            this.btnBorrarLog.Size = new System.Drawing.Size(102, 22);
            this.btnBorrarLog.TabIndex = 0;
            this.btnBorrarLog.UseVisualStyleBackColor = false;
            this.btnBorrarLog.Click += new System.EventHandler(this.btnBorrarLog_Click_1);
            // 
            // rtb_Log
            // 
            this.rtb_Log.BackColor = System.Drawing.SystemColors.Window;
            this.rtb_Log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Log.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_Log.ForeColor = System.Drawing.Color.Black;
            this.rtb_Log.Location = new System.Drawing.Point(5, 44);
            this.rtb_Log.Margin = new System.Windows.Forms.Padding(4);
            this.rtb_Log.Name = "rtb_Log";
            this.rtb_Log.ReadOnly = true;
            this.rtb_Log.Size = new System.Drawing.Size(756, 695);
            this.rtb_Log.TabIndex = 4;
            this.rtb_Log.Text = "";
            // 
            // tlpIzquierda
            // 
            this.tlpIzquierda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tlpIzquierda.ColumnCount = 1;
            this.tlpIzquierda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpIzquierda.Controls.Add(this.tableLayoutPanel56, 0, 0);
            this.tlpIzquierda.Location = new System.Drawing.Point(4, 4);
            this.tlpIzquierda.Margin = new System.Windows.Forms.Padding(4);
            this.tlpIzquierda.Name = "tlpIzquierda";
            this.tlpIzquierda.RowCount = 1;
            this.tlpIzquierda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.23529F));
            this.tlpIzquierda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpIzquierda.Size = new System.Drawing.Size(764, 740);
            this.tlpIzquierda.TabIndex = 24;
            // 
            // tableLayoutPanel56
            // 
            this.tableLayoutPanel56.ColumnCount = 1;
            this.tableLayoutPanel56.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel56.Controls.Add(this.dtgEjemplos, 0, 1);
            this.tableLayoutPanel56.Controls.Add(this.tableLayoutPanel14, 0, 2);
            this.tableLayoutPanel56.Controls.Add(this.gbFiltros, 0, 0);
            this.tableLayoutPanel56.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel56.Location = new System.Drawing.Point(3, 2);
            this.tableLayoutPanel56.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel56.Name = "tableLayoutPanel56";
            this.tableLayoutPanel56.RowCount = 3;
            this.tableLayoutPanel56.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.32155F));
            this.tableLayoutPanel56.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.67844F));
            this.tableLayoutPanel56.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 386F));
            this.tableLayoutPanel56.Size = new System.Drawing.Size(758, 736);
            this.tableLayoutPanel56.TabIndex = 1;
            // 
            // dtgEjemplos
            // 
            this.dtgEjemplos.AllowUserToResizeColumns = false;
            this.dtgEjemplos.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgEjemplos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgEjemplos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgEjemplos.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgEjemplos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgEjemplos.Location = new System.Drawing.Point(3, 83);
            this.dtgEjemplos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtgEjemplos.MultiSelect = false;
            this.dtgEjemplos.Name = "dtgEjemplos";
            this.dtgEjemplos.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgEjemplos.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgEjemplos.RowHeadersVisible = false;
            this.dtgEjemplos.RowHeadersWidth = 51;
            this.dtgEjemplos.RowTemplate.Height = 24;
            this.dtgEjemplos.Size = new System.Drawing.Size(752, 264);
            this.dtgEjemplos.TabIndex = 5;
            this.dtgEjemplos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEjemplos_CellContentClick);
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 1;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.75862F));
            this.tableLayoutPanel14.Controls.Add(this.gbAcciones, 0, 0);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(3, 351);
            this.tableLayoutPanel14.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 1;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(752, 383);
            this.tableLayoutPanel14.TabIndex = 7;
            // 
            // gbAcciones
            // 
            this.gbAcciones.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbAcciones.Controls.Add(this.panel3);
            this.gbAcciones.Font = new System.Drawing.Font("Calibri", 9F);
            this.gbAcciones.Location = new System.Drawing.Point(4, 4);
            this.gbAcciones.Margin = new System.Windows.Forms.Padding(4);
            this.gbAcciones.Name = "gbAcciones";
            this.gbAcciones.Padding = new System.Windows.Forms.Padding(4);
            this.gbAcciones.Size = new System.Drawing.Size(744, 375);
            this.gbAcciones.TabIndex = 9;
            this.gbAcciones.TabStop = false;
            this.gbAcciones.Text = "Acciones";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.pnlDescargas);
            this.panel3.Controls.Add(this.tableLayoutPanel3);
            this.panel3.Location = new System.Drawing.Point(181, 16);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(373, 357);
            this.panel3.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnProbarTodos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 324);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(373, 34);
            this.panel1.TabIndex = 2;
            // 
            // btnProbarTodos
            // 
            this.btnProbarTodos.BackColor = System.Drawing.Color.Black;
            this.btnProbarTodos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProbarTodos.Enabled = false;
            this.btnProbarTodos.FlatAppearance.BorderSize = 0;
            this.btnProbarTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProbarTodos.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProbarTodos.ForeColor = System.Drawing.Color.White;
            this.btnProbarTodos.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnProbarTodos.IconColor = System.Drawing.Color.White;
            this.btnProbarTodos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProbarTodos.IconSize = 25;
            this.btnProbarTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProbarTodos.Location = new System.Drawing.Point(0, 0);
            this.btnProbarTodos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProbarTodos.Name = "btnProbarTodos";
            this.btnProbarTodos.Size = new System.Drawing.Size(373, 34);
            this.btnProbarTodos.TabIndex = 4;
            this.btnProbarTodos.Text = "Iniciar prueba masiva";
            this.btnProbarTodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProbarTodos.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnProbarTodos.UseVisualStyleBackColor = false;
            this.btnProbarTodos.Click += new System.EventHandler(this.btnProbarTodos_Click);
            // 
            // pnlDescargas
            // 
            this.pnlDescargas.Controls.Add(this.tlp_archivos);
            this.pnlDescargas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDescargas.Location = new System.Drawing.Point(0, 30);
            this.pnlDescargas.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDescargas.Name = "pnlDescargas";
            this.pnlDescargas.Size = new System.Drawing.Size(373, 294);
            this.pnlDescargas.TabIndex = 1;
            // 
            // tlp_archivos
            // 
            this.tlp_archivos.ColumnCount = 1;
            this.tlp_archivos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_archivos.Controls.Add(this.chckTodo, 0, 0);
            this.tlp_archivos.Controls.Add(this.chckTxtEjemplos, 0, 5);
            this.tlp_archivos.Controls.Add(this.chckRequestEjemplos, 0, 4);
            this.tlp_archivos.Controls.Add(this.chckCdrEjemplos, 0, 3);
            this.tlp_archivos.Controls.Add(this.chckXmlEjemplos, 0, 2);
            this.tlp_archivos.Controls.Add(this.chckPdfEjemplos, 0, 1);
            this.tlp_archivos.Controls.Add(this.btnDescargaEjemplos, 0, 8);
            this.tlp_archivos.Controls.Add(this.chckSpeech, 0, 7);
            this.tlp_archivos.Controls.Add(this.chckJsonEjemplos, 0, 6);
            this.tlp_archivos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_archivos.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlp_archivos.Location = new System.Drawing.Point(0, 0);
            this.tlp_archivos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlp_archivos.Name = "tlp_archivos";
            this.tlp_archivos.RowCount = 9;
            this.tlp_archivos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlp_archivos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlp_archivos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlp_archivos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlp_archivos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlp_archivos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlp_archivos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlp_archivos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlp_archivos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlp_archivos.Size = new System.Drawing.Size(373, 294);
            this.tlp_archivos.TabIndex = 6;
            // 
            // chckTodo
            // 
            this.chckTodo.AutoSize = true;
            this.chckTodo.Checked = true;
            this.chckTodo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckTodo.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckTodo.Location = new System.Drawing.Point(3, 2);
            this.chckTodo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chckTodo.Name = "chckTodo";
            this.chckTodo.Size = new System.Drawing.Size(70, 21);
            this.chckTodo.TabIndex = 8;
            this.chckTodo.Text = "TODOS";
            this.chckTodo.UseVisualStyleBackColor = true;
            this.chckTodo.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chckTxtEjemplos
            // 
            this.chckTxtEjemplos.AutoSize = true;
            this.chckTxtEjemplos.Checked = true;
            this.chckTxtEjemplos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckTxtEjemplos.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckTxtEjemplos.Location = new System.Drawing.Point(3, 162);
            this.chckTxtEjemplos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chckTxtEjemplos.Name = "chckTxtEjemplos";
            this.chckTxtEjemplos.Size = new System.Drawing.Size(51, 21);
            this.chckTxtEjemplos.TabIndex = 8;
            this.chckTxtEjemplos.Text = "TXT";
            this.chckTxtEjemplos.UseVisualStyleBackColor = true;
            // 
            // chckRequestEjemplos
            // 
            this.chckRequestEjemplos.AutoSize = true;
            this.chckRequestEjemplos.Checked = true;
            this.chckRequestEjemplos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckRequestEjemplos.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckRequestEjemplos.Location = new System.Drawing.Point(3, 130);
            this.chckRequestEjemplos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chckRequestEjemplos.Name = "chckRequestEjemplos";
            this.chckRequestEjemplos.Size = new System.Drawing.Size(83, 21);
            this.chckRequestEjemplos.TabIndex = 8;
            this.chckRequestEjemplos.Text = "REQUEST";
            this.chckRequestEjemplos.UseVisualStyleBackColor = true;
            // 
            // chckCdrEjemplos
            // 
            this.chckCdrEjemplos.AutoSize = true;
            this.chckCdrEjemplos.Checked = true;
            this.chckCdrEjemplos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckCdrEjemplos.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckCdrEjemplos.Location = new System.Drawing.Point(3, 98);
            this.chckCdrEjemplos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chckCdrEjemplos.Name = "chckCdrEjemplos";
            this.chckCdrEjemplos.Size = new System.Drawing.Size(54, 21);
            this.chckCdrEjemplos.TabIndex = 8;
            this.chckCdrEjemplos.Text = "CDR";
            this.chckCdrEjemplos.UseVisualStyleBackColor = true;
            // 
            // chckXmlEjemplos
            // 
            this.chckXmlEjemplos.AutoSize = true;
            this.chckXmlEjemplos.Checked = true;
            this.chckXmlEjemplos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckXmlEjemplos.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckXmlEjemplos.Location = new System.Drawing.Point(3, 66);
            this.chckXmlEjemplos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chckXmlEjemplos.Name = "chckXmlEjemplos";
            this.chckXmlEjemplos.Size = new System.Drawing.Size(55, 21);
            this.chckXmlEjemplos.TabIndex = 8;
            this.chckXmlEjemplos.Text = "XML";
            this.chckXmlEjemplos.UseVisualStyleBackColor = true;
            // 
            // chckPdfEjemplos
            // 
            this.chckPdfEjemplos.AutoSize = true;
            this.chckPdfEjemplos.Checked = true;
            this.chckPdfEjemplos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckPdfEjemplos.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckPdfEjemplos.Location = new System.Drawing.Point(3, 34);
            this.chckPdfEjemplos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chckPdfEjemplos.Name = "chckPdfEjemplos";
            this.chckPdfEjemplos.Size = new System.Drawing.Size(52, 21);
            this.chckPdfEjemplos.TabIndex = 7;
            this.chckPdfEjemplos.Text = "PDF";
            this.chckPdfEjemplos.UseVisualStyleBackColor = true;
            // 
            // btnDescargaEjemplos
            // 
            this.btnDescargaEjemplos.BackColor = System.Drawing.Color.Black;
            this.btnDescargaEjemplos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDescargaEjemplos.FlatAppearance.BorderSize = 0;
            this.btnDescargaEjemplos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescargaEjemplos.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescargaEjemplos.ForeColor = System.Drawing.Color.White;
            this.btnDescargaEjemplos.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnDescargaEjemplos.IconColor = System.Drawing.Color.White;
            this.btnDescargaEjemplos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDescargaEjemplos.IconSize = 25;
            this.btnDescargaEjemplos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDescargaEjemplos.Location = new System.Drawing.Point(0, 256);
            this.btnDescargaEjemplos.Margin = new System.Windows.Forms.Padding(0);
            this.btnDescargaEjemplos.Name = "btnDescargaEjemplos";
            this.btnDescargaEjemplos.Size = new System.Drawing.Size(373, 38);
            this.btnDescargaEjemplos.TabIndex = 2;
            this.btnDescargaEjemplos.Text = "Descargar archivos";
            this.btnDescargaEjemplos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDescargaEjemplos.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDescargaEjemplos.UseVisualStyleBackColor = false;
            this.btnDescargaEjemplos.Click += new System.EventHandler(this.btnDescargaEjemplos_Click);
            // 
            // chckSpeech
            // 
            this.chckSpeech.AutoSize = true;
            this.chckSpeech.Checked = true;
            this.chckSpeech.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckSpeech.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckSpeech.Location = new System.Drawing.Point(3, 226);
            this.chckSpeech.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chckSpeech.Name = "chckSpeech";
            this.chckSpeech.Size = new System.Drawing.Size(111, 21);
            this.chckSpeech.TabIndex = 9;
            this.chckSpeech.Text = "Speech Correo";
            this.chckSpeech.UseVisualStyleBackColor = true;
            // 
            // chckJsonEjemplos
            // 
            this.chckJsonEjemplos.AutoSize = true;
            this.chckJsonEjemplos.Checked = true;
            this.chckJsonEjemplos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckJsonEjemplos.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckJsonEjemplos.Location = new System.Drawing.Point(3, 194);
            this.chckJsonEjemplos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chckJsonEjemplos.Name = "chckJsonEjemplos";
            this.chckJsonEjemplos.Size = new System.Drawing.Size(58, 21);
            this.chckJsonEjemplos.TabIndex = 10;
            this.chckJsonEjemplos.Text = "JSON";
            this.chckJsonEjemplos.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.88889F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.11111F));
            this.tableLayoutPanel3.Controls.Add(this.btnDescargas, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(373, 30);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // btnDescargas
            // 
            this.btnDescargas.BorderColor = System.Drawing.Color.LightGray;
            this.btnDescargas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDescargas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDescargas.Enabled = false;
            this.btnDescargas.IsOn = false;
            this.btnDescargas.Location = new System.Drawing.Point(298, 4);
            this.btnDescargas.Margin = new System.Windows.Forms.Padding(4);
            this.btnDescargas.Name = "btnDescargas";
            this.btnDescargas.Size = new System.Drawing.Size(40, 22);
            this.btnDescargas.TabIndex = 0;
            this.btnDescargas.Text = "slideButton1";
            this.btnDescargas.TextEnabled = false;
            this.btnDescargas.SliderValueChanged += new AltoControls.SlideButton.SliderChangedEventHandler(this.btnDescargas_SliderValueChanged);
            this.btnDescargas.Click += new System.EventHandler(this.btnDescargas_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(114, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Descargas";
            // 
            // gbFiltros
            // 
            this.gbFiltros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbFiltros.Controls.Add(this.tableLayoutPanel57);
            this.gbFiltros.Font = new System.Drawing.Font("Calibri", 9F);
            this.gbFiltros.Location = new System.Drawing.Point(4, 7);
            this.gbFiltros.Margin = new System.Windows.Forms.Padding(4);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Padding = new System.Windows.Forms.Padding(4);
            this.gbFiltros.Size = new System.Drawing.Size(749, 66);
            this.gbFiltros.TabIndex = 8;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
            // 
            // tableLayoutPanel57
            // 
            this.tableLayoutPanel57.ColumnCount = 3;
            this.tableLayoutPanel57.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.2518F));
            this.tableLayoutPanel57.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.33094F));
            this.tableLayoutPanel57.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.23741F));
            this.tableLayoutPanel57.Controls.Add(this.tableLayoutPanel2, 2, 0);
            this.tableLayoutPanel57.Controls.Add(this.cmbTipoDoc, 0, 0);
            this.tableLayoutPanel57.Controls.Add(this.txtBusquedaEjemplo, 1, 0);
            this.tableLayoutPanel57.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel57.Location = new System.Drawing.Point(4, 23);
            this.tableLayoutPanel57.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel57.Name = "tableLayoutPanel57";
            this.tableLayoutPanel57.RowCount = 1;
            this.tableLayoutPanel57.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel57.Size = new System.Drawing.Size(741, 39);
            this.tableLayoutPanel57.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.31915F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.68085F));
            this.tableLayoutPanel2.Controls.Add(this.chckDemo, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(534, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(203, 31);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // chckDemo
            // 
            this.chckDemo.BorderColor = System.Drawing.Color.LightGray;
            this.chckDemo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chckDemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chckDemo.IsOn = true;
            this.chckDemo.Location = new System.Drawing.Point(116, 4);
            this.chckDemo.Margin = new System.Windows.Forms.Padding(4);
            this.chckDemo.Name = "chckDemo";
            this.chckDemo.Size = new System.Drawing.Size(42, 23);
            this.chckDemo.TabIndex = 0;
            this.chckDemo.Text = "slideButton1";
            this.chckDemo.TextEnabled = false;
            this.chckDemo.SliderValueChanged += new AltoControls.SlideButton.SliderChangedEventHandler(this.chckDemo_SliderValueChanged);
            this.chckDemo.Click += new System.EventHandler(this.chckDemo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F);
            this.label2.Location = new System.Drawing.Point(4, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Demo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTipoDoc
            // 
            this.cmbTipoDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTipoDoc.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cmbTipoDoc.FormattingEnabled = true;
            this.cmbTipoDoc.ItemHeight = 21;
            this.cmbTipoDoc.Location = new System.Drawing.Point(4, 4);
            this.cmbTipoDoc.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTipoDoc.Name = "cmbTipoDoc";
            this.cmbTipoDoc.Size = new System.Drawing.Size(253, 27);
            this.cmbTipoDoc.TabIndex = 3;
            this.cmbTipoDoc.UseSelectable = true;
            this.cmbTipoDoc.SelectedIndexChanged += new System.EventHandler(this.cmbTipoDoc_SelectedIndexChanged);
            // 
            // txtBusquedaEjemplo
            // 
            // 
            // 
            // 
            this.txtBusquedaEjemplo.CustomButton.Image = null;
            this.txtBusquedaEjemplo.CustomButton.Location = new System.Drawing.Point(229, 1);
            this.txtBusquedaEjemplo.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBusquedaEjemplo.CustomButton.Name = "";
            this.txtBusquedaEjemplo.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtBusquedaEjemplo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBusquedaEjemplo.CustomButton.TabIndex = 1;
            this.txtBusquedaEjemplo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBusquedaEjemplo.CustomButton.UseSelectable = true;
            this.txtBusquedaEjemplo.CustomButton.Visible = false;
            this.txtBusquedaEjemplo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBusquedaEjemplo.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtBusquedaEjemplo.Lines = new string[0];
            this.txtBusquedaEjemplo.Location = new System.Drawing.Point(264, 2);
            this.txtBusquedaEjemplo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBusquedaEjemplo.MaxLength = 32767;
            this.txtBusquedaEjemplo.Name = "txtBusquedaEjemplo";
            this.txtBusquedaEjemplo.PasswordChar = '\0';
            this.txtBusquedaEjemplo.PromptText = "Digite acá un texto para filtrar";
            this.txtBusquedaEjemplo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBusquedaEjemplo.SelectedText = "";
            this.txtBusquedaEjemplo.SelectionLength = 0;
            this.txtBusquedaEjemplo.SelectionStart = 0;
            this.txtBusquedaEjemplo.ShortcutsEnabled = true;
            this.txtBusquedaEjemplo.Size = new System.Drawing.Size(263, 35);
            this.txtBusquedaEjemplo.TabIndex = 2;
            this.txtBusquedaEjemplo.UseSelectable = true;
            this.txtBusquedaEjemplo.WaterMark = "Digite acá un texto para filtrar";
            this.txtBusquedaEjemplo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBusquedaEjemplo.WaterMarkFont = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusquedaEjemplo.TextChanged += new System.EventHandler(this.txtBusquedaEjemplo_TextChanged);
            // 
            // FrmEjemplos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1544, 748);
            this.Controls.Add(this.tlpGeneral);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmEjemplos";
            this.Text = "Tool - Ejemplos";
            this.Load += new System.EventHandler(this.FrmEjemplos_Load);
            this.tlpGeneral.ResumeLayout(false);
            this.tlpLog.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tlpIzquierda.ResumeLayout(false);
            this.tableLayoutPanel56.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEjemplos)).EndInit();
            this.tableLayoutPanel14.ResumeLayout(false);
            this.gbAcciones.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlDescargas.ResumeLayout(false);
            this.tlp_archivos.ResumeLayout(false);
            this.tlp_archivos.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.gbFiltros.ResumeLayout(false);
            this.tableLayoutPanel57.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpGeneral;
        private System.Windows.Forms.TableLayoutPanel tlpIzquierda;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel56;
        private System.Windows.Forms.DataGridView dtgEjemplos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.TableLayoutPanel tlp_archivos;
        private System.Windows.Forms.CheckBox chckTxtEjemplos;
        private System.Windows.Forms.CheckBox chckRequestEjemplos;
        private System.Windows.Forms.CheckBox chckCdrEjemplos;
        private System.Windows.Forms.CheckBox chckXmlEjemplos;
        private System.Windows.Forms.CheckBox chckPdfEjemplos;
        private FontAwesome.Sharp.IconButton btnDescargaEjemplos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel57;
        private MetroFramework.Controls.MetroTextBox txtBusquedaEjemplo;
        private System.Windows.Forms.CheckBox chckTodo;
        private MetroFramework.Controls.MetroComboBox cmbTipoDoc;
        private AltoControls.SlideButton btnDescargas;
        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconButton btnProbarTodos;
        private System.Windows.Forms.Panel pnlDescargas;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private AltoControls.SlideButton chckDemo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chckSpeech;
        private System.Windows.Forms.CheckBox chckJsonEjemplos;
        private System.Windows.Forms.TableLayoutPanel tlpLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lbl_Log;
        private FontAwesome.Sharp.IconButton btnBorrarLog;
        public System.Windows.Forms.RichTextBox rtb_Log;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.GroupBox gbAcciones;
    }
}