﻿namespace Tools
{
    partial class FrmEmision
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
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chckDemo = new AltoControls.SlideButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_TipoEmision = new System.Windows.Forms.ComboBox();
            this.chckEdicion = new System.Windows.Forms.CheckBox();
            this.chckRequestPre = new System.Windows.Forms.CheckBox();
            this.gb_Credenciales = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.btnProbarCredenciales = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel23 = new System.Windows.Forms.TableLayoutPanel();
            this.txt_UsuarioEmision = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel22 = new System.Windows.Forms.TableLayoutPanel();
            this.txt_RucEmision = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.txt_ClaveEmision = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.gb_Archivos = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.lst_archivo = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnProcesar = new FontAwesome.Sharp.IconButton();
            this.lblLeyenda = new System.Windows.Forms.Label();
            this.ts_ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.gb_PostAceptacion = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tlp_Descarga = new System.Windows.Forms.TableLayoutPanel();
            this.btnDescargar = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel51 = new System.Windows.Forms.TableLayoutPanel();
            this.chckXML = new System.Windows.Forms.CheckBox();
            this.chckPDF = new System.Windows.Forms.CheckBox();
            this.chckRequest = new System.Windows.Forms.CheckBox();
            this.chckCDR = new System.Windows.Forms.CheckBox();
            this.chckTXT = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel49 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel50 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDocEdicion = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.tlpLog = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Log = new System.Windows.Forms.Label();
            this.rtb_Log = new System.Windows.Forms.RichTextBox();
            this.tlpGeneral.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gb_Credenciales.SuspendLayout();
            this.tableLayoutPanel16.SuspendLayout();
            this.tableLayoutPanel23.SuspendLayout();
            this.tableLayoutPanel22.SuspendLayout();
            this.tableLayoutPanel17.SuspendLayout();
            this.gb_Archivos.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gb_PostAceptacion.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tlp_Descarga.SuspendLayout();
            this.tableLayoutPanel51.SuspendLayout();
            this.tableLayoutPanel49.SuspendLayout();
            this.tableLayoutPanel50.SuspendLayout();
            this.tlpLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpGeneral
            // 
            this.tlpGeneral.BackColor = System.Drawing.Color.White;
            this.tlpGeneral.ColumnCount = 2;
            this.tlpGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.31512F));
            this.tlpGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.68488F));
            this.tlpGeneral.Controls.Add(this.tableLayoutPanel15, 0, 0);
            this.tlpGeneral.Controls.Add(this.tlpLog, 1, 0);
            this.tlpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGeneral.Location = new System.Drawing.Point(0, 0);
            this.tlpGeneral.Name = "tlpGeneral";
            this.tlpGeneral.RowCount = 1;
            this.tlpGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGeneral.Size = new System.Drawing.Size(878, 505);
            this.tlpGeneral.TabIndex = 27;
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.ColumnCount = 1;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.Controls.Add(this.groupBox10, 0, 0);
            this.tableLayoutPanel15.Controls.Add(this.gb_Credenciales, 0, 1);
            this.tableLayoutPanel15.Controls.Add(this.gb_Archivos, 0, 2);
            this.tableLayoutPanel15.Controls.Add(this.gb_PostAceptacion, 0, 3);
            this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel15.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel15.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 4;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.67961F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.35599F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.07784F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.16367F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(534, 501);
            this.tableLayoutPanel15.TabIndex = 24;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.tableLayoutPanel9);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox10.Location = new System.Drawing.Point(2, 2);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox10.Size = new System.Drawing.Size(530, 49);
            this.groupBox10.TabIndex = 2;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Acciones Pre-Envío";
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 4;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.41706F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.19905F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.38389F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel2, 3, 0);
            this.tableLayoutPanel9.Controls.Add(this.cmb_TipoEmision, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.chckEdicion, 2, 0);
            this.tableLayoutPanel9.Controls.Add(this.chckRequestPre, 1, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(2, 15);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(526, 32);
            this.tableLayoutPanel9.TabIndex = 15;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.31915F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.68085F));
            this.tableLayoutPanel2.Controls.Add(this.chckDemo, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(404, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(119, 26);
            this.tableLayoutPanel2.TabIndex = 15;
            // 
            // chckDemo
            // 
            this.chckDemo.BorderColor = System.Drawing.Color.LightGray;
            this.chckDemo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chckDemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chckDemo.IsOn = true;
            this.chckDemo.Location = new System.Drawing.Point(68, 3);
            this.chckDemo.Name = "chckDemo";
            this.chckDemo.Size = new System.Drawing.Size(36, 20);
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
            this.label2.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Demo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmb_TipoEmision
            // 
            this.cmb_TipoEmision.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmb_TipoEmision.BackColor = System.Drawing.Color.White;
            this.cmb_TipoEmision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_TipoEmision.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_TipoEmision.ForeColor = System.Drawing.Color.Black;
            this.cmb_TipoEmision.FormattingEnabled = true;
            this.cmb_TipoEmision.Items.AddRange(new object[] {
            "PSE 2.1",
            "OSE",
            "SUNAT",
            "SUNAT (PARA FIRMAR)"});
            this.cmb_TipoEmision.Location = new System.Drawing.Point(2, 5);
            this.cmb_TipoEmision.Margin = new System.Windows.Forms.Padding(2);
            this.cmb_TipoEmision.Name = "cmb_TipoEmision";
            this.cmb_TipoEmision.Size = new System.Drawing.Size(166, 21);
            this.cmb_TipoEmision.TabIndex = 14;
            this.cmb_TipoEmision.SelectedIndexChanged += new System.EventHandler(this.cmb_TipoEmision_SelectedIndexChanged);
            // 
            // chckEdicion
            // 
            this.chckEdicion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chckEdicion.AutoSize = true;
            this.chckEdicion.Enabled = false;
            this.chckEdicion.Location = new System.Drawing.Point(285, 7);
            this.chckEdicion.Margin = new System.Windows.Forms.Padding(2);
            this.chckEdicion.Name = "chckEdicion";
            this.chckEdicion.Size = new System.Drawing.Size(114, 17);
            this.chckEdicion.TabIndex = 14;
            this.chckEdicion.Text = "Edición Automática";
            this.chckEdicion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chckEdicion.UseVisualStyleBackColor = true;
            // 
            // chckRequestPre
            // 
            this.chckRequestPre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chckRequestPre.AutoSize = true;
            this.chckRequestPre.Enabled = false;
            this.chckRequestPre.Location = new System.Drawing.Point(173, 7);
            this.chckRequestPre.Name = "chckRequestPre";
            this.chckRequestPre.Size = new System.Drawing.Size(107, 17);
            this.chckRequestPre.TabIndex = 13;
            this.chckRequestPre.Text = "Obtener Request";
            this.chckRequestPre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chckRequestPre.UseVisualStyleBackColor = true;
            // 
            // gb_Credenciales
            // 
            this.gb_Credenciales.Controls.Add(this.tableLayoutPanel16);
            this.gb_Credenciales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Credenciales.Enabled = false;
            this.gb_Credenciales.Location = new System.Drawing.Point(2, 55);
            this.gb_Credenciales.Margin = new System.Windows.Forms.Padding(2);
            this.gb_Credenciales.Name = "gb_Credenciales";
            this.gb_Credenciales.Padding = new System.Windows.Forms.Padding(2);
            this.gb_Credenciales.Size = new System.Drawing.Size(530, 47);
            this.gb_Credenciales.TabIndex = 3;
            this.gb_Credenciales.TabStop = false;
            this.gb_Credenciales.Text = "Credenciales";
            // 
            // tableLayoutPanel16
            // 
            this.tableLayoutPanel16.ColumnCount = 4;
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.42857F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.42857F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel16.Controls.Add(this.btnProbarCredenciales, 3, 0);
            this.tableLayoutPanel16.Controls.Add(this.tableLayoutPanel23, 1, 0);
            this.tableLayoutPanel16.Controls.Add(this.tableLayoutPanel22, 0, 0);
            this.tableLayoutPanel16.Controls.Add(this.tableLayoutPanel17, 2, 0);
            this.tableLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel16.Location = new System.Drawing.Point(2, 15);
            this.tableLayoutPanel16.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            this.tableLayoutPanel16.RowCount = 1;
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel16.Size = new System.Drawing.Size(526, 30);
            this.tableLayoutPanel16.TabIndex = 16;
            // 
            // btnProbarCredenciales
            // 
            this.btnProbarCredenciales.BackColor = System.Drawing.Color.White;
            this.btnProbarCredenciales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProbarCredenciales.FlatAppearance.BorderSize = 0;
            this.btnProbarCredenciales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProbarCredenciales.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProbarCredenciales.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.btnProbarCredenciales.IconColor = System.Drawing.Color.White;
            this.btnProbarCredenciales.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProbarCredenciales.IconSize = 20;
            this.btnProbarCredenciales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProbarCredenciales.Location = new System.Drawing.Point(395, 2);
            this.btnProbarCredenciales.Margin = new System.Windows.Forms.Padding(2);
            this.btnProbarCredenciales.Name = "btnProbarCredenciales";
            this.btnProbarCredenciales.Size = new System.Drawing.Size(129, 26);
            this.btnProbarCredenciales.TabIndex = 2;
            this.btnProbarCredenciales.Text = "ValidaAccesos";
            this.btnProbarCredenciales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProbarCredenciales.UseVisualStyleBackColor = false;
            this.btnProbarCredenciales.Click += new System.EventHandler(this.btnProbarCredenciales_Click);
            // 
            // tableLayoutPanel23
            // 
            this.tableLayoutPanel23.ColumnCount = 2;
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.57143F));
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.42857F));
            this.tableLayoutPanel23.Controls.Add(this.txt_UsuarioEmision, 1, 0);
            this.tableLayoutPanel23.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel23.Location = new System.Drawing.Point(120, 2);
            this.tableLayoutPanel23.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel23.Name = "tableLayoutPanel23";
            this.tableLayoutPanel23.RowCount = 1;
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel23.Size = new System.Drawing.Size(140, 26);
            this.tableLayoutPanel23.TabIndex = 2;
            // 
            // txt_UsuarioEmision
            // 
            this.txt_UsuarioEmision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_UsuarioEmision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_UsuarioEmision.Location = new System.Drawing.Point(55, 1);
            this.txt_UsuarioEmision.Margin = new System.Windows.Forms.Padding(1);
            this.txt_UsuarioEmision.Name = "txt_UsuarioEmision";
            this.txt_UsuarioEmision.Size = new System.Drawing.Size(84, 20);
            this.txt_UsuarioEmision.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "Usuario:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel22
            // 
            this.tableLayoutPanel22.ColumnCount = 2;
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel22.Controls.Add(this.txt_RucEmision, 1, 0);
            this.tableLayoutPanel22.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel22.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel22.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel22.Name = "tableLayoutPanel22";
            this.tableLayoutPanel22.RowCount = 1;
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel22.Size = new System.Drawing.Size(114, 26);
            this.tableLayoutPanel22.TabIndex = 1;
            // 
            // txt_RucEmision
            // 
            this.txt_RucEmision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_RucEmision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_RucEmision.Location = new System.Drawing.Point(39, 1);
            this.txt_RucEmision.Margin = new System.Windows.Forms.Padding(1);
            this.txt_RucEmision.Name = "txt_RucEmision";
            this.txt_RucEmision.Size = new System.Drawing.Size(74, 20);
            this.txt_RucEmision.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 26);
            this.label12.TabIndex = 7;
            this.label12.Text = "Ruc:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.ColumnCount = 2;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.64567F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.35433F));
            this.tableLayoutPanel17.Controls.Add(this.txt_ClaveEmision, 1, 0);
            this.tableLayoutPanel17.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel17.Location = new System.Drawing.Point(264, 2);
            this.tableLayoutPanel17.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            this.tableLayoutPanel17.RowCount = 1;
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel17.Size = new System.Drawing.Size(127, 26);
            this.tableLayoutPanel17.TabIndex = 0;
            // 
            // txt_ClaveEmision
            // 
            this.txt_ClaveEmision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ClaveEmision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_ClaveEmision.Location = new System.Drawing.Point(45, 1);
            this.txt_ClaveEmision.Margin = new System.Windows.Forms.Padding(1);
            this.txt_ClaveEmision.Name = "txt_ClaveEmision";
            this.txt_ClaveEmision.Size = new System.Drawing.Size(81, 20);
            this.txt_ClaveEmision.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 26);
            this.label11.TabIndex = 6;
            this.label11.Text = "Clave:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gb_Archivos
            // 
            this.gb_Archivos.Controls.Add(this.tableLayoutPanel10);
            this.gb_Archivos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Archivos.Enabled = false;
            this.gb_Archivos.Location = new System.Drawing.Point(2, 106);
            this.gb_Archivos.Margin = new System.Windows.Forms.Padding(2);
            this.gb_Archivos.Name = "gb_Archivos";
            this.gb_Archivos.Padding = new System.Windows.Forms.Padding(2);
            this.gb_Archivos.Size = new System.Drawing.Size(530, 301);
            this.gb_Archivos.TabIndex = 4;
            this.gb_Archivos.TabStop = false;
            this.gb_Archivos.Text = "Archivos";
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.801136F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.19886F));
            this.tableLayoutPanel10.Controls.Add(this.btnBuscar, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel11, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.ts_ProgressBar1, 1, 1);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(2, 15);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 2;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(526, 284);
            this.tableLayoutPanel10.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.White;
            this.btnBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscar.IconColor = System.Drawing.Color.Black;
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.Location = new System.Drawing.Point(1, 1);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(1);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(49, 262);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 1;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Controls.Add(this.lst_archivo, 0, 1);
            this.tableLayoutPanel11.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(52, 1);
            this.tableLayoutPanel11.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 2;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.30935F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.69065F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(473, 262);
            this.tableLayoutPanel11.TabIndex = 1;
            // 
            // lst_archivo
            // 
            this.lst_archivo.AllowDrop = true;
            this.lst_archivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lst_archivo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_archivo.FormattingEnabled = true;
            this.lst_archivo.Location = new System.Drawing.Point(1, 35);
            this.lst_archivo.Margin = new System.Windows.Forms.Padding(1);
            this.lst_archivo.Name = "lst_archivo";
            this.lst_archivo.Size = new System.Drawing.Size(471, 226);
            this.lst_archivo.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.41936F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.58064F));
            this.tableLayoutPanel1.Controls.Add(this.btnProcesar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblLeyenda, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(471, 32);
            this.tableLayoutPanel1.TabIndex = 2;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackColor = System.Drawing.Color.White;
            this.btnProcesar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProcesar.FlatAppearance.BorderSize = 0;
            this.btnProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcesar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcesar.IconChar = FontAwesome.Sharp.IconChar.Play;
            this.btnProcesar.IconColor = System.Drawing.Color.White;
            this.btnProcesar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProcesar.IconSize = 15;
            this.btnProcesar.Location = new System.Drawing.Point(390, 2);
            this.btnProcesar.Margin = new System.Windows.Forms.Padding(2);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(79, 28);
            this.btnProcesar.TabIndex = 8;
            this.btnProcesar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcesar.UseVisualStyleBackColor = false;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // lblLeyenda
            // 
            this.lblLeyenda.AutoSize = true;
            this.lblLeyenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLeyenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeyenda.Location = new System.Drawing.Point(3, 0);
            this.lblLeyenda.Name = "lblLeyenda";
            this.lblLeyenda.Size = new System.Drawing.Size(382, 32);
            this.lblLeyenda.TabIndex = 7;
            this.lblLeyenda.Text = "Para las bajas el contenido del TXT debe ser Tipo-Numeracion|Motivo + Salto de li" +
    "nea";
            this.lblLeyenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ts_ProgressBar1
            // 
            this.ts_ProgressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ts_ProgressBar1.Location = new System.Drawing.Point(54, 267);
            this.ts_ProgressBar1.Name = "ts_ProgressBar1";
            this.ts_ProgressBar1.Size = new System.Drawing.Size(469, 14);
            this.ts_ProgressBar1.TabIndex = 4;
            // 
            // gb_PostAceptacion
            // 
            this.gb_PostAceptacion.Controls.Add(this.tableLayoutPanel8);
            this.gb_PostAceptacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_PostAceptacion.Enabled = false;
            this.gb_PostAceptacion.Location = new System.Drawing.Point(2, 411);
            this.gb_PostAceptacion.Margin = new System.Windows.Forms.Padding(2);
            this.gb_PostAceptacion.Name = "gb_PostAceptacion";
            this.gb_PostAceptacion.Padding = new System.Windows.Forms.Padding(2);
            this.gb_PostAceptacion.Size = new System.Drawing.Size(530, 88);
            this.gb_PostAceptacion.TabIndex = 2;
            this.gb_PostAceptacion.TabStop = false;
            this.gb_PostAceptacion.Text = "Acciones Post-Aceptacion (Solo para envío de 1 Doc)";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.01839F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.98161F));
            this.tableLayoutPanel8.Controls.Add(this.tlp_Descarga, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel49, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(2, 15);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(526, 71);
            this.tableLayoutPanel8.TabIndex = 0;
            // 
            // tlp_Descarga
            // 
            this.tlp_Descarga.ColumnCount = 2;
            this.tlp_Descarga.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.10989F));
            this.tlp_Descarga.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.89011F));
            this.tlp_Descarga.Controls.Add(this.btnDescargar, 0, 0);
            this.tlp_Descarga.Controls.Add(this.tableLayoutPanel51, 1, 0);
            this.tlp_Descarga.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Descarga.Location = new System.Drawing.Point(217, 2);
            this.tlp_Descarga.Margin = new System.Windows.Forms.Padding(2);
            this.tlp_Descarga.Name = "tlp_Descarga";
            this.tlp_Descarga.RowCount = 1;
            this.tlp_Descarga.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Descarga.Size = new System.Drawing.Size(307, 67);
            this.tlp_Descarga.TabIndex = 15;
            // 
            // btnDescargar
            // 
            this.btnDescargar.BackColor = System.Drawing.Color.White;
            this.btnDescargar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDescargar.FlatAppearance.BorderSize = 0;
            this.btnDescargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescargar.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnDescargar.IconColor = System.Drawing.Color.White;
            this.btnDescargar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDescargar.Location = new System.Drawing.Point(2, 2);
            this.btnDescargar.Margin = new System.Windows.Forms.Padding(2);
            this.btnDescargar.Name = "btnDescargar";
            this.btnDescargar.Size = new System.Drawing.Size(119, 63);
            this.btnDescargar.TabIndex = 2;
            this.btnDescargar.UseVisualStyleBackColor = false;
            this.btnDescargar.Click += new System.EventHandler(this.btnDescargar_Click);
            // 
            // tableLayoutPanel51
            // 
            this.tableLayoutPanel51.ColumnCount = 2;
            this.tableLayoutPanel51.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel51.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel51.Controls.Add(this.chckXML, 0, 1);
            this.tableLayoutPanel51.Controls.Add(this.chckPDF, 0, 0);
            this.tableLayoutPanel51.Controls.Add(this.chckRequest, 1, 1);
            this.tableLayoutPanel51.Controls.Add(this.chckCDR, 0, 2);
            this.tableLayoutPanel51.Controls.Add(this.chckTXT, 1, 0);
            this.tableLayoutPanel51.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel51.Location = new System.Drawing.Point(125, 2);
            this.tableLayoutPanel51.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel51.Name = "tableLayoutPanel51";
            this.tableLayoutPanel51.RowCount = 3;
            this.tableLayoutPanel51.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel51.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel51.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel51.Size = new System.Drawing.Size(180, 63);
            this.tableLayoutPanel51.TabIndex = 18;
            // 
            // chckXML
            // 
            this.chckXML.AutoSize = true;
            this.chckXML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chckXML.Location = new System.Drawing.Point(3, 24);
            this.chckXML.Name = "chckXML";
            this.chckXML.Size = new System.Drawing.Size(80, 15);
            this.chckXML.TabIndex = 19;
            this.chckXML.Text = "XML";
            this.chckXML.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chckXML.UseVisualStyleBackColor = true;
            // 
            // chckPDF
            // 
            this.chckPDF.AutoSize = true;
            this.chckPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chckPDF.Location = new System.Drawing.Point(3, 3);
            this.chckPDF.Name = "chckPDF";
            this.chckPDF.Size = new System.Drawing.Size(80, 15);
            this.chckPDF.TabIndex = 19;
            this.chckPDF.Text = "PDF";
            this.chckPDF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chckPDF.UseVisualStyleBackColor = true;
            // 
            // chckRequest
            // 
            this.chckRequest.AutoSize = true;
            this.chckRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chckRequest.Location = new System.Drawing.Point(89, 24);
            this.chckRequest.Name = "chckRequest";
            this.chckRequest.Size = new System.Drawing.Size(88, 15);
            this.chckRequest.TabIndex = 20;
            this.chckRequest.Text = "REQUEST";
            this.chckRequest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chckRequest.UseVisualStyleBackColor = true;
            // 
            // chckCDR
            // 
            this.chckCDR.AutoSize = true;
            this.chckCDR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chckCDR.Location = new System.Drawing.Point(3, 45);
            this.chckCDR.Name = "chckCDR";
            this.chckCDR.Size = new System.Drawing.Size(80, 15);
            this.chckCDR.TabIndex = 14;
            this.chckCDR.Text = "CDR";
            this.chckCDR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chckCDR.UseVisualStyleBackColor = true;
            // 
            // chckTXT
            // 
            this.chckTXT.AutoSize = true;
            this.chckTXT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chckTXT.Location = new System.Drawing.Point(89, 3);
            this.chckTXT.Name = "chckTXT";
            this.chckTXT.Size = new System.Drawing.Size(88, 15);
            this.chckTXT.TabIndex = 21;
            this.chckTXT.Text = "TXT";
            this.chckTXT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chckTXT.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel49
            // 
            this.tableLayoutPanel49.ColumnCount = 1;
            this.tableLayoutPanel49.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.36283F));
            this.tableLayoutPanel49.Controls.Add(this.tableLayoutPanel50, 0, 0);
            this.tableLayoutPanel49.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel49.Enabled = false;
            this.tableLayoutPanel49.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel49.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel49.Name = "tableLayoutPanel49";
            this.tableLayoutPanel49.RowCount = 1;
            this.tableLayoutPanel49.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel49.Size = new System.Drawing.Size(211, 67);
            this.tableLayoutPanel49.TabIndex = 14;
            // 
            // tableLayoutPanel50
            // 
            this.tableLayoutPanel50.ColumnCount = 2;
            this.tableLayoutPanel50.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.40351F));
            this.tableLayoutPanel50.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.59649F));
            this.tableLayoutPanel50.Controls.Add(this.lblDocEdicion, 1, 0);
            this.tableLayoutPanel50.Controls.Add(this.label42, 0, 0);
            this.tableLayoutPanel50.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel50.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel50.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel50.Name = "tableLayoutPanel50";
            this.tableLayoutPanel50.RowCount = 1;
            this.tableLayoutPanel50.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel50.Size = new System.Drawing.Size(207, 63);
            this.tableLayoutPanel50.TabIndex = 1;
            // 
            // lblDocEdicion
            // 
            this.lblDocEdicion.AutoSize = true;
            this.lblDocEdicion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDocEdicion.Location = new System.Drawing.Point(87, 0);
            this.lblDocEdicion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDocEdicion.Name = "lblDocEdicion";
            this.lblDocEdicion.Size = new System.Drawing.Size(118, 63);
            this.lblDocEdicion.TabIndex = 2;
            this.lblDocEdicion.Text = "-";
            this.lblDocEdicion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label42.Location = new System.Drawing.Point(2, 0);
            this.label42.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(81, 63);
            this.label42.TabIndex = 0;
            this.label42.Text = "Doc. Procesado:";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // FrmEmision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 505);
            this.Controls.Add(this.tlpGeneral);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmEmision";
            this.Text = "Emisión";
            this.Load += new System.EventHandler(this.FrmEmision_Load);
            this.tlpGeneral.ResumeLayout(false);
            this.tableLayoutPanel15.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.gb_Credenciales.ResumeLayout(false);
            this.tableLayoutPanel16.ResumeLayout(false);
            this.tableLayoutPanel23.ResumeLayout(false);
            this.tableLayoutPanel23.PerformLayout();
            this.tableLayoutPanel22.ResumeLayout(false);
            this.tableLayoutPanel22.PerformLayout();
            this.tableLayoutPanel17.ResumeLayout(false);
            this.tableLayoutPanel17.PerformLayout();
            this.gb_Archivos.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.gb_PostAceptacion.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tlp_Descarga.ResumeLayout(false);
            this.tableLayoutPanel51.ResumeLayout(false);
            this.tableLayoutPanel51.PerformLayout();
            this.tableLayoutPanel49.ResumeLayout(false);
            this.tableLayoutPanel50.ResumeLayout(false);
            this.tableLayoutPanel50.PerformLayout();
            this.tlpLog.ResumeLayout(false);
            this.tlpLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpGeneral;
        private System.Windows.Forms.TableLayoutPanel tlpLog;
        private System.Windows.Forms.Label lbl_Log;
        public System.Windows.Forms.RichTextBox rtb_Log;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.Label lblLeyenda;
        private System.Windows.Forms.ListBox lst_archivo;
        private System.Windows.Forms.GroupBox gb_Credenciales;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel16;
        private FontAwesome.Sharp.IconButton btnProbarCredenciales;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel23;
        private System.Windows.Forms.TextBox txt_UsuarioEmision;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel22;
        private System.Windows.Forms.TextBox txt_RucEmision;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel17;
        private System.Windows.Forms.TextBox txt_ClaveEmision;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.ComboBox cmb_TipoEmision;
        private System.Windows.Forms.CheckBox chckEdicion;
        private System.Windows.Forms.CheckBox chckRequestPre;
        private System.Windows.Forms.GroupBox gb_PostAceptacion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TableLayoutPanel tlp_Descarga;
        private FontAwesome.Sharp.IconButton btnDescargar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel51;
        private System.Windows.Forms.CheckBox chckCDR;
        private System.Windows.Forms.CheckBox chckXML;
        private System.Windows.Forms.CheckBox chckPDF;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel49;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel50;
        private System.Windows.Forms.Label lblDocEdicion;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private AltoControls.SlideButton chckDemo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton btnProcesar;
        private System.Windows.Forms.CheckBox chckRequest;
        private System.Windows.Forms.GroupBox gb_Archivos;
        private System.Windows.Forms.ProgressBar ts_ProgressBar1;
        private System.Windows.Forms.CheckBox chckTXT;
    }
}