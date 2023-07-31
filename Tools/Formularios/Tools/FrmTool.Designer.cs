
namespace Tools
{
    partial class FrmToolDaily
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
            this.ProgressBar = new MetroFramework.Controls.MetroProgressBar();
            this.btnProcesar = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblFormato = new System.Windows.Forms.Label();
            this.rtbDaily = new System.Windows.Forms.RichTextBox();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMantis = new MetroFramework.Controls.MetroTextBox();
            this.cmbMetodo = new MetroFramework.Controls.MetroComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRuc = new MetroFramework.Controls.MetroTextBox();
            this.txtToken = new MetroFramework.Controls.MetroTextBox();
            this.chckSpeech = new AltoControls.SlideButton();
            this.tlpDetalle = new System.Windows.Forms.TableLayoutPanel();
            this.txtDetalle = new MetroFramework.Controls.MetroTextBox();
            this.btnDetalle = new FontAwesome.Sharp.IconButton();
            this.tlpGeneral.SuspendLayout();
            this.tlpLog.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tlpForm.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tlpDetalle.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpGeneral
            // 
            this.tlpGeneral.BackColor = System.Drawing.Color.White;
            this.tlpGeneral.ColumnCount = 2;
            this.tlpGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGeneral.Controls.Add(this.tlpLog, 0, 0);
            this.tlpGeneral.Controls.Add(this.tlpForm, 0, 0);
            this.tlpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGeneral.Location = new System.Drawing.Point(0, 0);
            this.tlpGeneral.Name = "tlpGeneral";
            this.tlpGeneral.RowCount = 1;
            this.tlpGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGeneral.Size = new System.Drawing.Size(1158, 608);
            this.tlpGeneral.TabIndex = 25;
            // 
            // tlpLog
            // 
            this.tlpLog.BackColor = System.Drawing.Color.Transparent;
            this.tlpLog.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpLog.ColumnCount = 1;
            this.tlpLog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLog.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tlpLog.Controls.Add(this.rtb_Log, 0, 1);
            this.tlpLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLog.Location = new System.Drawing.Point(581, 2);
            this.tlpLog.Margin = new System.Windows.Forms.Padding(2);
            this.tlpLog.Name = "tlpLog";
            this.tlpLog.RowCount = 2;
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.13245F));
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.86755F));
            this.tlpLog.Size = new System.Drawing.Size(575, 604);
            this.tlpLog.TabIndex = 26;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.45454F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.54545F));
            this.tableLayoutPanel2.Controls.Add(this.lbl_Log, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnBorrarLog, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(567, 24);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // lbl_Log
            // 
            this.lbl_Log.AutoSize = true;
            this.lbl_Log.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Log.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Log.ForeColor = System.Drawing.Color.Black;
            this.lbl_Log.Location = new System.Drawing.Point(3, 0);
            this.lbl_Log.Name = "lbl_Log";
            this.lbl_Log.Size = new System.Drawing.Size(478, 24);
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
            this.btnBorrarLog.Location = new System.Drawing.Point(487, 3);
            this.btnBorrarLog.Name = "btnBorrarLog";
            this.btnBorrarLog.Size = new System.Drawing.Size(77, 18);
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
            this.rtb_Log.Location = new System.Drawing.Point(4, 35);
            this.rtb_Log.Name = "rtb_Log";
            this.rtb_Log.ReadOnly = true;
            this.rtb_Log.Size = new System.Drawing.Size(567, 565);
            this.rtb_Log.TabIndex = 4;
            this.rtb_Log.Text = "";
            // 
            // tlpForm
            // 
            this.tlpForm.ColumnCount = 1;
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpForm.Controls.Add(this.ProgressBar, 0, 2);
            this.tlpForm.Controls.Add(this.btnProcesar, 0, 1);
            this.tlpForm.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tlpForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpForm.Location = new System.Drawing.Point(3, 3);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.RowCount = 3;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.25423F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.745763F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpForm.Size = new System.Drawing.Size(573, 602);
            this.tlpForm.TabIndex = 24;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProgressBar.Location = new System.Drawing.Point(2, 592);
            this.ProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(569, 8);
            this.ProgressBar.TabIndex = 27;
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
            this.btnProcesar.Location = new System.Drawing.Point(3, 565);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(567, 22);
            this.btnProcesar.TabIndex = 26;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblFormato, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.rtbDaily, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.gbFiltros, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.46377F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.58696F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.94928F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(567, 556);
            this.tableLayoutPanel1.TabIndex = 25;
            // 
            // lblFormato
            // 
            this.lblFormato.AutoSize = true;
            this.lblFormato.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFormato.Font = new System.Drawing.Font("Calibri", 9F);
            this.lblFormato.Location = new System.Drawing.Point(3, 263);
            this.lblFormato.Name = "lblFormato";
            this.lblFormato.Size = new System.Drawing.Size(561, 75);
            this.lblFormato.TabIndex = 30;
            this.lblFormato.Text = "Formato: Tipo-documento|IssueDate (YYYY-MM-DD)\r\nEjemplo:\r\n01-F001-1234|2021-05-30" +
    "\r\n03-B001-1234|2022-01-01\r\n...";
            this.lblFormato.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtbDaily
            // 
            this.rtbDaily.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDaily.Location = new System.Drawing.Point(3, 341);
            this.rtbDaily.Name = "rtbDaily";
            this.rtbDaily.Size = new System.Drawing.Size(561, 212);
            this.rtbDaily.TabIndex = 4;
            this.rtbDaily.Text = "";
            // 
            // gbFiltros
            // 
            this.gbFiltros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbFiltros.Controls.Add(this.tableLayoutPanel4);
            this.gbFiltros.Font = new System.Drawing.Font("Calibri", 9.5F, System.Drawing.FontStyle.Bold);
            this.gbFiltros.Location = new System.Drawing.Point(58, 3);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(451, 256);
            this.gbFiltros.TabIndex = 3;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.75853F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.24147F));
            this.tableLayoutPanel4.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.txtMantis, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.cmbMetodo, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.txtRuc, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.txtToken, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.chckSpeech, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.tlpDetalle, 1, 5);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(445, 234);
            this.tableLayoutPanel4.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 39);
            this.label6.TabIndex = 34;
            this.label6.Text = "Mayor detalle:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 39);
            this.label4.TabIndex = 32;
            this.label4.Text = "Añadir Speech de correo al Log";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMantis
            // 
            // 
            // 
            // 
            this.txtMantis.CustomButton.Image = null;
            this.txtMantis.CustomButton.Location = new System.Drawing.Point(266, 1);
            this.txtMantis.CustomButton.Name = "";
            this.txtMantis.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.txtMantis.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMantis.CustomButton.TabIndex = 1;
            this.txtMantis.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMantis.CustomButton.UseSelectable = true;
            this.txtMantis.CustomButton.Visible = false;
            this.txtMantis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMantis.Lines = new string[0];
            this.txtMantis.Location = new System.Drawing.Point(144, 120);
            this.txtMantis.MaxLength = 32767;
            this.txtMantis.Name = "txtMantis";
            this.txtMantis.PasswordChar = '\0';
            this.txtMantis.PromptText = "Debe poseer 7 números";
            this.txtMantis.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMantis.SelectedText = "";
            this.txtMantis.SelectionLength = 0;
            this.txtMantis.SelectionStart = 0;
            this.txtMantis.ShortcutsEnabled = true;
            this.txtMantis.Size = new System.Drawing.Size(298, 33);
            this.txtMantis.TabIndex = 31;
            this.txtMantis.UseSelectable = true;
            this.txtMantis.WaterMark = "Debe poseer 7 números";
            this.txtMantis.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMantis.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // cmbMetodo
            // 
            this.cmbMetodo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbMetodo.FormattingEnabled = true;
            this.cmbMetodo.ItemHeight = 23;
            this.cmbMetodo.Items.AddRange(new object[] {
            "Desactivar",
            "BajasCancelado",
            "EliminarPDF",
            "OSE-Desactivar"});
            this.cmbMetodo.Location = new System.Drawing.Point(144, 3);
            this.cmbMetodo.Name = "cmbMetodo";
            this.cmbMetodo.Size = new System.Drawing.Size(298, 29);
            this.cmbMetodo.TabIndex = 1;
            this.cmbMetodo.UseSelectable = true;
            this.cmbMetodo.SelectedIndexChanged += new System.EventHandler(this.cmbMetodo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 39);
            this.label1.TabIndex = 28;
            this.label1.Text = "Método:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 39);
            this.label3.TabIndex = 25;
            this.label3.Text = "Ruc:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 39);
            this.label2.TabIndex = 4;
            this.label2.Text = "Token:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 39);
            this.label5.TabIndex = 6;
            this.label5.Text = "Mantis:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRuc
            // 
            // 
            // 
            // 
            this.txtRuc.CustomButton.Image = null;
            this.txtRuc.CustomButton.Location = new System.Drawing.Point(266, 1);
            this.txtRuc.CustomButton.Name = "";
            this.txtRuc.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.txtRuc.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtRuc.CustomButton.TabIndex = 1;
            this.txtRuc.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtRuc.CustomButton.UseSelectable = true;
            this.txtRuc.CustomButton.Visible = false;
            this.txtRuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRuc.Lines = new string[0];
            this.txtRuc.Location = new System.Drawing.Point(144, 42);
            this.txtRuc.MaxLength = 32767;
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.PasswordChar = '\0';
            this.txtRuc.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRuc.SelectedText = "";
            this.txtRuc.SelectionLength = 0;
            this.txtRuc.SelectionStart = 0;
            this.txtRuc.ShortcutsEnabled = true;
            this.txtRuc.Size = new System.Drawing.Size(298, 33);
            this.txtRuc.TabIndex = 29;
            this.txtRuc.UseSelectable = true;
            this.txtRuc.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtRuc.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtToken
            // 
            // 
            // 
            // 
            this.txtToken.CustomButton.Image = null;
            this.txtToken.CustomButton.Location = new System.Drawing.Point(266, 1);
            this.txtToken.CustomButton.Name = "";
            this.txtToken.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.txtToken.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtToken.CustomButton.TabIndex = 1;
            this.txtToken.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtToken.CustomButton.UseSelectable = true;
            this.txtToken.CustomButton.Visible = false;
            this.txtToken.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtToken.Lines = new string[0];
            this.txtToken.Location = new System.Drawing.Point(144, 81);
            this.txtToken.MaxLength = 32767;
            this.txtToken.Name = "txtToken";
            this.txtToken.PasswordChar = '*';
            this.txtToken.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtToken.SelectedText = "";
            this.txtToken.SelectionLength = 0;
            this.txtToken.SelectionStart = 0;
            this.txtToken.ShortcutsEnabled = true;
            this.txtToken.Size = new System.Drawing.Size(298, 33);
            this.txtToken.TabIndex = 30;
            this.txtToken.UseSelectable = true;
            this.txtToken.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtToken.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // chckSpeech
            // 
            this.chckSpeech.BorderColor = System.Drawing.Color.LightGray;
            this.chckSpeech.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chckSpeech.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chckSpeech.IsOn = true;
            this.chckSpeech.Location = new System.Drawing.Point(144, 159);
            this.chckSpeech.Name = "chckSpeech";
            this.chckSpeech.Size = new System.Drawing.Size(62, 33);
            this.chckSpeech.TabIndex = 33;
            this.chckSpeech.Text = "slideButton1";
            this.chckSpeech.TextEnabled = false;
            // 
            // tlpDetalle
            // 
            this.tlpDetalle.ColumnCount = 2;
            this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.34361F));
            this.tlpDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.65639F));
            this.tlpDetalle.Controls.Add(this.txtDetalle, 0, 0);
            this.tlpDetalle.Controls.Add(this.btnDetalle, 1, 0);
            this.tlpDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDetalle.Location = new System.Drawing.Point(144, 198);
            this.tlpDetalle.Name = "tlpDetalle";
            this.tlpDetalle.RowCount = 1;
            this.tlpDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDetalle.Size = new System.Drawing.Size(298, 33);
            this.tlpDetalle.TabIndex = 35;
            // 
            // txtDetalle
            // 
            // 
            // 
            // 
            this.txtDetalle.CustomButton.Image = null;
            this.txtDetalle.CustomButton.Location = new System.Drawing.Point(225, 1);
            this.txtDetalle.CustomButton.Name = "";
            this.txtDetalle.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtDetalle.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDetalle.CustomButton.TabIndex = 1;
            this.txtDetalle.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDetalle.CustomButton.UseSelectable = true;
            this.txtDetalle.CustomButton.Visible = false;
            this.txtDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetalle.Lines = new string[] {
        "https://docs.google.com/document/d/1cC7EsmXB5LCYqZr-XuwRqb7YrZErSwyeRq9KJSe4hdY/e" +
            "dit"};
            this.txtDetalle.Location = new System.Drawing.Point(3, 3);
            this.txtDetalle.MaxLength = 32767;
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.PasswordChar = '\0';
            this.txtDetalle.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDetalle.SelectedText = "";
            this.txtDetalle.SelectionLength = 0;
            this.txtDetalle.SelectionStart = 0;
            this.txtDetalle.ShortcutsEnabled = true;
            this.txtDetalle.Size = new System.Drawing.Size(251, 27);
            this.txtDetalle.TabIndex = 35;
            this.txtDetalle.Text = "https://docs.google.com/document/d/1cC7EsmXB5LCYqZr-XuwRqb7YrZErSwyeRq9KJSe4hdY/e" +
    "dit";
            this.txtDetalle.UseSelectable = true;
            this.txtDetalle.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDetalle.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnDetalle
            // 
            this.btnDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDetalle.FlatAppearance.BorderSize = 0;
            this.btnDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetalle.IconChar = FontAwesome.Sharp.IconChar.InternetExplorer;
            this.btnDetalle.IconColor = System.Drawing.Color.Black;
            this.btnDetalle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDetalle.IconSize = 20;
            this.btnDetalle.Location = new System.Drawing.Point(260, 3);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(35, 27);
            this.btnDetalle.TabIndex = 36;
            this.btnDetalle.UseVisualStyleBackColor = true;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // FrmToolDaily
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 608);
            this.Controls.Add(this.tlpGeneral);
            this.Name = "FrmToolDaily";
            this.Text = "Tool - DailyTask";
            this.Load += new System.EventHandler(this.FrmToolDaily_Load);
            this.tlpGeneral.ResumeLayout(false);
            this.tlpLog.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tlpForm.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.gbFiltros.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tlpDetalle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpGeneral;
        private System.Windows.Forms.TableLayoutPanel tlpForm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label4;
        private MetroFramework.Controls.MetroTextBox txtMantis;
        private MetroFramework.Controls.MetroComboBox cmbMetodo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private MetroFramework.Controls.MetroTextBox txtRuc;
        private MetroFramework.Controls.MetroTextBox txtToken;
        private AltoControls.SlideButton chckSpeech;
        private System.Windows.Forms.Label lblFormato;
        private System.Windows.Forms.RichTextBox rtbDaily;
        private FontAwesome.Sharp.IconButton btnProcesar;
        private MetroFramework.Controls.MetroProgressBar ProgressBar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tlpDetalle;
        private MetroFramework.Controls.MetroTextBox txtDetalle;
        private FontAwesome.Sharp.IconButton btnDetalle;
        private System.Windows.Forms.TableLayoutPanel tlpLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lbl_Log;
        private FontAwesome.Sharp.IconButton btnBorrarLog;
        public System.Windows.Forms.RichTextBox rtb_Log;
    }
}