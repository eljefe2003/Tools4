﻿
namespace Tools
{
    partial class FrmDescargas
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
            this.lbl_Log = new System.Windows.Forms.Label();
            this.rtb_Log = new System.Windows.Forms.RichTextBox();
            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.ProgressBar = new MetroFramework.Controls.MetroProgressBar();
            this.btnProcesar = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbAmbiente = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel52 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnQueryDescargas = new FontAwesome.Sharp.IconButton();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.tlpFiltros = new System.Windows.Forms.TableLayoutPanel();
            this.txtRuc = new MetroFramework.Controls.MetroTextBox();
            this.cmbTipo = new MetroFramework.Controls.MetroComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chckDemo = new AltoControls.SlideButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtClave = new MetroFramework.Controls.MetroTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsuario = new MetroFramework.Controls.MetroTextBox();
            this.rtbDaily = new System.Windows.Forms.RichTextBox();
            this.tlpGeneral.SuspendLayout();
            this.tlpLog.SuspendLayout();
            this.tlpForm.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbAmbiente.SuspendLayout();
            this.tableLayoutPanel52.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.tlpFiltros.SuspendLayout();
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
            this.tlpGeneral.Size = new System.Drawing.Size(878, 505);
            this.tlpGeneral.TabIndex = 26;
            // 
            // tlpLog
            // 
            this.tlpLog.BackColor = System.Drawing.Color.Transparent;
            this.tlpLog.ColumnCount = 1;
            this.tlpLog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLog.Controls.Add(this.lbl_Log, 0, 0);
            this.tlpLog.Controls.Add(this.rtb_Log, 0, 1);
            this.tlpLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLog.Location = new System.Drawing.Point(540, 2);
            this.tlpLog.Margin = new System.Windows.Forms.Padding(2);
            this.tlpLog.Name = "tlpLog";
            this.tlpLog.RowCount = 2;
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.732484F));
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.26752F));
            this.tlpLog.Size = new System.Drawing.Size(336, 501);
            this.tlpLog.TabIndex = 23;
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
            this.lbl_Log.Size = new System.Drawing.Size(330, 28);
            this.lbl_Log.TabIndex = 3;
            this.lbl_Log.Text = "Log";
            this.lbl_Log.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtb_Log
            // 
            this.rtb_Log.BackColor = System.Drawing.SystemColors.Window;
            this.rtb_Log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Log.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_Log.ForeColor = System.Drawing.Color.White;
            this.rtb_Log.Location = new System.Drawing.Point(3, 31);
            this.rtb_Log.Name = "rtb_Log";
            this.rtb_Log.Size = new System.Drawing.Size(330, 467);
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
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.98196F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.018036F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpForm.Size = new System.Drawing.Size(532, 499);
            this.tlpForm.TabIndex = 24;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProgressBar.Location = new System.Drawing.Point(2, 489);
            this.ProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(528, 8);
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
            this.btnProcesar.Location = new System.Drawing.Point(3, 446);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(526, 38);
            this.btnProcesar.TabIndex = 26;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gbAmbiente, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.gbFiltros, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rtbDaily, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.46224F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.90847F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.85812F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(526, 437);
            this.tableLayoutPanel1.TabIndex = 25;
            // 
            // gbAmbiente
            // 
            this.gbAmbiente.Controls.Add(this.tableLayoutPanel52);
            this.gbAmbiente.Font = new System.Drawing.Font("Calibri", 9.5F, System.Drawing.FontStyle.Bold);
            this.gbAmbiente.Location = new System.Drawing.Point(3, 240);
            this.gbAmbiente.Name = "gbAmbiente";
            this.gbAmbiente.Size = new System.Drawing.Size(520, 80);
            this.gbAmbiente.TabIndex = 5;
            this.gbAmbiente.TabStop = false;
            this.gbAmbiente.Text = "Formato";
            // 
            // tableLayoutPanel52
            // 
            this.tableLayoutPanel52.ColumnCount = 2;
            this.tableLayoutPanel52.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.37823F));
            this.tableLayoutPanel52.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.169054F));
            this.tableLayoutPanel52.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel52.Controls.Add(this.btnQueryDescargas, 1, 0);
            this.tableLayoutPanel52.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel52.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel52.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel52.Name = "tableLayoutPanel52";
            this.tableLayoutPanel52.RowCount = 1;
            this.tableLayoutPanel52.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel52.Size = new System.Drawing.Size(514, 58);
            this.tableLayoutPanel52.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 8.5F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(52, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(358, 42);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tipo-Serie-Correlativo\r\n* Presionando el boton de la derecha, podras copiar el Qu" +
    "ery necesario.\r\n* Se pueden repetir hasta 9999 Items";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnQueryDescargas
            // 
            this.btnQueryDescargas.BackColor = System.Drawing.Color.White;
            this.btnQueryDescargas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQueryDescargas.FlatAppearance.BorderSize = 0;
            this.btnQueryDescargas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQueryDescargas.IconChar = FontAwesome.Sharp.IconChar.Copy;
            this.btnQueryDescargas.IconColor = System.Drawing.Color.Black;
            this.btnQueryDescargas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQueryDescargas.IconSize = 40;
            this.btnQueryDescargas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnQueryDescargas.Location = new System.Drawing.Point(464, 2);
            this.btnQueryDescargas.Margin = new System.Windows.Forms.Padding(2);
            this.btnQueryDescargas.Name = "btnQueryDescargas";
            this.btnQueryDescargas.Size = new System.Drawing.Size(48, 54);
            this.btnQueryDescargas.TabIndex = 6;
            this.btnQueryDescargas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQueryDescargas.UseVisualStyleBackColor = false;
            this.btnQueryDescargas.Click += new System.EventHandler(this.btnQueryDescargas_Click);
            // 
            // gbFiltros
            // 
            this.gbFiltros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbFiltros.Controls.Add(this.tlpFiltros);
            this.gbFiltros.Font = new System.Drawing.Font("Calibri", 9.5F, System.Drawing.FontStyle.Bold);
            this.gbFiltros.Location = new System.Drawing.Point(51, 3);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(423, 230);
            this.gbFiltros.TabIndex = 3;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
            // 
            // tlpFiltros
            // 
            this.tlpFiltros.ColumnCount = 2;
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.75853F));
            this.tlpFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.24147F));
            this.tlpFiltros.Controls.Add(this.txtRuc, 1, 3);
            this.tlpFiltros.Controls.Add(this.cmbTipo, 1, 0);
            this.tlpFiltros.Controls.Add(this.label1, 0, 0);
            this.tlpFiltros.Controls.Add(this.label4, 0, 1);
            this.tlpFiltros.Controls.Add(this.chckDemo, 1, 1);
            this.tlpFiltros.Controls.Add(this.label3, 0, 3);
            this.tlpFiltros.Controls.Add(this.label5, 0, 5);
            this.tlpFiltros.Controls.Add(this.txtClave, 1, 5);
            this.tlpFiltros.Controls.Add(this.label2, 0, 4);
            this.tlpFiltros.Controls.Add(this.txtUsuario, 1, 4);
            this.tlpFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFiltros.Location = new System.Drawing.Point(3, 19);
            this.tlpFiltros.Name = "tlpFiltros";
            this.tlpFiltros.RowCount = 6;
            this.tlpFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpFiltros.Size = new System.Drawing.Size(417, 208);
            this.tlpFiltros.TabIndex = 29;
            // 
            // txtRuc
            // 
            // 
            // 
            // 
            this.txtRuc.CustomButton.Image = null;
            this.txtRuc.CustomButton.Location = new System.Drawing.Point(253, 2);
            this.txtRuc.CustomButton.Name = "";
            this.txtRuc.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtRuc.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtRuc.CustomButton.TabIndex = 1;
            this.txtRuc.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtRuc.CustomButton.UseSelectable = true;
            this.txtRuc.CustomButton.Visible = false;
            this.txtRuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRuc.Lines = new string[0];
            this.txtRuc.Location = new System.Drawing.Point(135, 105);
            this.txtRuc.MaxLength = 32767;
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.PasswordChar = '\0';
            this.txtRuc.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRuc.SelectedText = "";
            this.txtRuc.SelectionLength = 0;
            this.txtRuc.SelectionStart = 0;
            this.txtRuc.ShortcutsEnabled = true;
            this.txtRuc.Size = new System.Drawing.Size(279, 28);
            this.txtRuc.TabIndex = 31;
            this.txtRuc.UseSelectable = true;
            this.txtRuc.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtRuc.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // cmbTipo
            // 
            this.cmbTipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.ItemHeight = 23;
            this.cmbTipo.Items.AddRange(new object[] {
            "Todos",
            "PDF",
            "XML",
            "CDR"});
            this.cmbTipo.Location = new System.Drawing.Point(135, 3);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(279, 29);
            this.cmbTipo.TabIndex = 1;
            this.cmbTipo.UseSelectable = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 34);
            this.label1.TabIndex = 28;
            this.label1.Text = "Tipo Doc:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 34);
            this.label4.TabIndex = 32;
            this.label4.Text = "Demo:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chckDemo
            // 
            this.chckDemo.BorderColor = System.Drawing.Color.LightGray;
            this.chckDemo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chckDemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chckDemo.IsOn = false;
            this.chckDemo.Location = new System.Drawing.Point(135, 37);
            this.chckDemo.Name = "chckDemo";
            this.chckDemo.Size = new System.Drawing.Size(52, 28);
            this.chckDemo.TabIndex = 35;
            this.chckDemo.Text = "slideButton1";
            this.chckDemo.TextEnabled = false;
            this.chckDemo.SliderValueChanged += new AltoControls.SlideButton.SliderChangedEventHandler(this.chckDemo_SliderValueChanged);
            this.chckDemo.Click += new System.EventHandler(this.slideButton1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 34);
            this.label3.TabIndex = 25;
            this.label3.Text = "Ruc:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 38);
            this.label5.TabIndex = 6;
            this.label5.Text = "Clave:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtClave
            // 
            // 
            // 
            // 
            this.txtClave.CustomButton.Image = null;
            this.txtClave.CustomButton.Location = new System.Drawing.Point(249, 2);
            this.txtClave.CustomButton.Name = "";
            this.txtClave.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtClave.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtClave.CustomButton.TabIndex = 1;
            this.txtClave.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtClave.CustomButton.UseSelectable = true;
            this.txtClave.CustomButton.Visible = false;
            this.txtClave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtClave.Lines = new string[0];
            this.txtClave.Location = new System.Drawing.Point(135, 173);
            this.txtClave.MaxLength = 32767;
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '\0';
            this.txtClave.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtClave.SelectedText = "";
            this.txtClave.SelectionLength = 0;
            this.txtClave.SelectionStart = 0;
            this.txtClave.ShortcutsEnabled = true;
            this.txtClave.Size = new System.Drawing.Size(279, 32);
            this.txtClave.TabIndex = 29;
            this.txtClave.UseSelectable = true;
            this.txtClave.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtClave.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 34);
            this.label2.TabIndex = 4;
            this.label2.Text = "Usuario:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUsuario
            // 
            // 
            // 
            // 
            this.txtUsuario.CustomButton.Image = null;
            this.txtUsuario.CustomButton.Location = new System.Drawing.Point(253, 2);
            this.txtUsuario.CustomButton.Name = "";
            this.txtUsuario.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtUsuario.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUsuario.CustomButton.TabIndex = 1;
            this.txtUsuario.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUsuario.CustomButton.UseSelectable = true;
            this.txtUsuario.CustomButton.Visible = false;
            this.txtUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsuario.Lines = new string[0];
            this.txtUsuario.Location = new System.Drawing.Point(135, 139);
            this.txtUsuario.MaxLength = 32767;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.PasswordChar = '\0';
            this.txtUsuario.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUsuario.SelectedText = "";
            this.txtUsuario.SelectionLength = 0;
            this.txtUsuario.SelectionStart = 0;
            this.txtUsuario.ShortcutsEnabled = true;
            this.txtUsuario.Size = new System.Drawing.Size(279, 28);
            this.txtUsuario.TabIndex = 30;
            this.txtUsuario.UseSelectable = true;
            this.txtUsuario.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUsuario.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // rtbDaily
            // 
            this.rtbDaily.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDaily.Location = new System.Drawing.Point(3, 326);
            this.rtbDaily.Name = "rtbDaily";
            this.rtbDaily.Size = new System.Drawing.Size(520, 108);
            this.rtbDaily.TabIndex = 4;
            this.rtbDaily.Text = "";
            // 
            // FrmDescargas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 505);
            this.Controls.Add(this.tlpGeneral);
            this.Name = "FrmDescargas";
            this.Text = "Tool - Descargas";
            this.Load += new System.EventHandler(this.FrmDescargas_Load);
            this.tlpGeneral.ResumeLayout(false);
            this.tlpLog.ResumeLayout(false);
            this.tlpLog.PerformLayout();
            this.tlpForm.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbAmbiente.ResumeLayout(false);
            this.tableLayoutPanel52.ResumeLayout(false);
            this.tableLayoutPanel52.PerformLayout();
            this.gbFiltros.ResumeLayout(false);
            this.tlpFiltros.ResumeLayout(false);
            this.tlpFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpGeneral;
        private System.Windows.Forms.TableLayoutPanel tlpLog;
        private System.Windows.Forms.Label lbl_Log;
        public System.Windows.Forms.RichTextBox rtb_Log;
        private System.Windows.Forms.TableLayoutPanel tlpForm;
        private MetroFramework.Controls.MetroProgressBar ProgressBar;
        private FontAwesome.Sharp.IconButton btnProcesar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.TableLayoutPanel tlpFiltros;
        private System.Windows.Forms.Label label4;
        private MetroFramework.Controls.MetroTextBox txtRuc;
        private MetroFramework.Controls.MetroComboBox cmbTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private MetroFramework.Controls.MetroTextBox txtClave;
        private MetroFramework.Controls.MetroTextBox txtUsuario;
        private System.Windows.Forms.RichTextBox rtbDaily;
        private AltoControls.SlideButton chckDemo;
        private System.Windows.Forms.GroupBox gbAmbiente;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel52;
        private System.Windows.Forms.Label label6;
        private FontAwesome.Sharp.IconButton btnQueryDescargas;
    }
}