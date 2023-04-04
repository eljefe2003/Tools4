
namespace Tools
{
    partial class FrmConsultaSunat
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
            this.rtb_Log = new System.Windows.Forms.RichTextBox();
            this.lbl_Log = new System.Windows.Forms.Label();
            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.gbAmbiente = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel52 = new System.Windows.Forms.TableLayoutPanel();
            this.btnConsultaSunatOSE = new FontAwesome.Sharp.IconButton();
            this.label5 = new System.Windows.Forms.Label();
            this.btnConsultaSunatPSE = new FontAwesome.Sharp.IconButton();
            this.btnProcesar = new FontAwesome.Sharp.IconButton();
            this.ProgressBar = new MetroFramework.Controls.MetroProgressBar();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.rtb_consultas = new System.Windows.Forms.RichTextBox();
            this.tlpGeneral.SuspendLayout();
            this.tlpLog.SuspendLayout();
            this.tlpForm.SuspendLayout();
            this.gbAmbiente.SuspendLayout();
            this.tableLayoutPanel52.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpGeneral
            // 
            this.tlpGeneral.BackColor = System.Drawing.Color.White;
            this.tlpGeneral.ColumnCount = 2;
            this.tlpGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.58241F));
            this.tlpGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.41759F));
            this.tlpGeneral.Controls.Add(this.tlpLog, 1, 0);
            this.tlpGeneral.Controls.Add(this.tlpForm, 0, 0);
            this.tlpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGeneral.Location = new System.Drawing.Point(0, 0);
            this.tlpGeneral.Name = "tlpGeneral";
            this.tlpGeneral.RowCount = 1;
            this.tlpGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGeneral.Size = new System.Drawing.Size(878, 505);
            this.tlpGeneral.TabIndex = 25;
            // 
            // tlpLog
            // 
            this.tlpLog.BackColor = System.Drawing.Color.Transparent;
            this.tlpLog.ColumnCount = 1;
            this.tlpLog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLog.Controls.Add(this.rtb_Log, 0, 1);
            this.tlpLog.Controls.Add(this.lbl_Log, 0, 0);
            this.tlpLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLog.Location = new System.Drawing.Point(516, 2);
            this.tlpLog.Margin = new System.Windows.Forms.Padding(2);
            this.tlpLog.Name = "tlpLog";
            this.tlpLog.RowCount = 2;
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.732484F));
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.26752F));
            this.tlpLog.Size = new System.Drawing.Size(360, 501);
            this.tlpLog.TabIndex = 23;
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
            this.rtb_Log.Size = new System.Drawing.Size(354, 467);
            this.rtb_Log.TabIndex = 4;
            this.rtb_Log.Text = "";
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
            this.lbl_Log.Size = new System.Drawing.Size(354, 28);
            this.lbl_Log.TabIndex = 3;
            this.lbl_Log.Text = "Log";
            this.lbl_Log.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpForm
            // 
            this.tlpForm.ColumnCount = 1;
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpForm.Controls.Add(this.gbAmbiente, 0, 0);
            this.tlpForm.Controls.Add(this.btnProcesar, 0, 2);
            this.tlpForm.Controls.Add(this.ProgressBar, 0, 3);
            this.tlpForm.Controls.Add(this.gbFiltros, 0, 1);
            this.tlpForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpForm.Location = new System.Drawing.Point(3, 3);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.RowCount = 4;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.5122F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.48781F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tlpForm.Size = new System.Drawing.Size(508, 499);
            this.tlpForm.TabIndex = 24;
            // 
            // gbAmbiente
            // 
            this.gbAmbiente.Controls.Add(this.tableLayoutPanel52);
            this.gbAmbiente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAmbiente.Font = new System.Drawing.Font("Calibri", 9.5F, System.Drawing.FontStyle.Bold);
            this.gbAmbiente.Location = new System.Drawing.Point(3, 3);
            this.gbAmbiente.Name = "gbAmbiente";
            this.gbAmbiente.Size = new System.Drawing.Size(502, 80);
            this.gbAmbiente.TabIndex = 3;
            this.gbAmbiente.TabStop = false;
            this.gbAmbiente.Text = "Formato";
            // 
            // tableLayoutPanel52
            // 
            this.tableLayoutPanel52.ColumnCount = 3;
            this.tableLayoutPanel52.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.37823F));
            this.tableLayoutPanel52.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.169054F));
            this.tableLayoutPanel52.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.309456F));
            this.tableLayoutPanel52.Controls.Add(this.btnConsultaSunatOSE, 2, 0);
            this.tableLayoutPanel52.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel52.Controls.Add(this.btnConsultaSunatPSE, 1, 0);
            this.tableLayoutPanel52.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel52.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel52.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel52.Name = "tableLayoutPanel52";
            this.tableLayoutPanel52.RowCount = 1;
            this.tableLayoutPanel52.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel52.Size = new System.Drawing.Size(496, 58);
            this.tableLayoutPanel52.TabIndex = 6;
            // 
            // btnConsultaSunatOSE
            // 
            this.btnConsultaSunatOSE.BackColor = System.Drawing.Color.White;
            this.btnConsultaSunatOSE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConsultaSunatOSE.FlatAppearance.BorderSize = 0;
            this.btnConsultaSunatOSE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultaSunatOSE.IconChar = FontAwesome.Sharp.IconChar.Copy;
            this.btnConsultaSunatOSE.IconColor = System.Drawing.Color.Black;
            this.btnConsultaSunatOSE.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnConsultaSunatOSE.IconSize = 40;
            this.btnConsultaSunatOSE.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConsultaSunatOSE.Location = new System.Drawing.Point(456, 2);
            this.btnConsultaSunatOSE.Margin = new System.Windows.Forms.Padding(2);
            this.btnConsultaSunatOSE.Name = "btnConsultaSunatOSE";
            this.btnConsultaSunatOSE.Size = new System.Drawing.Size(38, 54);
            this.btnConsultaSunatOSE.TabIndex = 7;
            this.btnConsultaSunatOSE.Text = "OSE";
            this.btnConsultaSunatOSE.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConsultaSunatOSE.UseVisualStyleBackColor = false;
            this.btnConsultaSunatOSE.Click += new System.EventHandler(this.btnConsultaSunatOSE_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 8.5F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(401, 58);
            this.label5.TabIndex = 5;
            this.label5.Text = "Emisor|TipoDoc|Serie|Correlativo|TipoDocRecep|NumDocRecep|FechaEmision|Importe\r\n\r" +
    "\n* Presionando los btnes. de la derecha, podras copiar el Query necesario segun " +
    "corresponda.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnConsultaSunatPSE
            // 
            this.btnConsultaSunatPSE.BackColor = System.Drawing.Color.White;
            this.btnConsultaSunatPSE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConsultaSunatPSE.FlatAppearance.BorderSize = 0;
            this.btnConsultaSunatPSE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultaSunatPSE.IconChar = FontAwesome.Sharp.IconChar.Copy;
            this.btnConsultaSunatPSE.IconColor = System.Drawing.Color.Black;
            this.btnConsultaSunatPSE.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnConsultaSunatPSE.IconSize = 40;
            this.btnConsultaSunatPSE.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConsultaSunatPSE.Location = new System.Drawing.Point(411, 2);
            this.btnConsultaSunatPSE.Margin = new System.Windows.Forms.Padding(2);
            this.btnConsultaSunatPSE.Name = "btnConsultaSunatPSE";
            this.btnConsultaSunatPSE.Size = new System.Drawing.Size(41, 54);
            this.btnConsultaSunatPSE.TabIndex = 6;
            this.btnConsultaSunatPSE.Text = "PSE";
            this.btnConsultaSunatPSE.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConsultaSunatPSE.UseVisualStyleBackColor = false;
            this.btnConsultaSunatPSE.Click += new System.EventHandler(this.btnConsultaSunatPSE_Click);
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
            this.btnProcesar.Size = new System.Drawing.Size(502, 36);
            this.btnProcesar.TabIndex = 22;
            this.btnProcesar.Text = "Buscar";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProgressBar.Location = new System.Drawing.Point(2, 487);
            this.ProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(504, 10);
            this.ProgressBar.TabIndex = 5;
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.rtb_consultas);
            this.gbFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFiltros.Font = new System.Drawing.Font("Calibri", 9.5F, System.Drawing.FontStyle.Bold);
            this.gbFiltros.Location = new System.Drawing.Point(3, 89);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(502, 351);
            this.gbFiltros.TabIndex = 4;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Contenido (Se pueden repetir hasta 9.999 lineas)";
            // 
            // rtb_consultas
            // 
            this.rtb_consultas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_consultas.Location = new System.Drawing.Point(3, 19);
            this.rtb_consultas.Name = "rtb_consultas";
            this.rtb_consultas.Size = new System.Drawing.Size(496, 329);
            this.rtb_consultas.TabIndex = 5;
            this.rtb_consultas.Text = "";
            // 
            // FrmConsultaSunat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 505);
            this.Controls.Add(this.tlpGeneral);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmConsultaSunat";
            this.Text = "Consulta - Sunat";
            this.Load += new System.EventHandler(this.FrmConsultaSunat_Load);
            this.tlpGeneral.ResumeLayout(false);
            this.tlpLog.ResumeLayout(false);
            this.tlpLog.PerformLayout();
            this.tlpForm.ResumeLayout(false);
            this.gbAmbiente.ResumeLayout(false);
            this.tableLayoutPanel52.ResumeLayout(false);
            this.tableLayoutPanel52.PerformLayout();
            this.gbFiltros.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpGeneral;
        private System.Windows.Forms.TableLayoutPanel tlpLog;
        public System.Windows.Forms.RichTextBox rtb_Log;
        private System.Windows.Forms.Label lbl_Log;
        private System.Windows.Forms.TableLayoutPanel tlpForm;
        private System.Windows.Forms.GroupBox gbAmbiente;
        private FontAwesome.Sharp.IconButton btnProcesar;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel52;
        private FontAwesome.Sharp.IconButton btnConsultaSunatOSE;
        private System.Windows.Forms.Label label5;
        private FontAwesome.Sharp.IconButton btnConsultaSunatPSE;
        private System.Windows.Forms.RichTextBox rtb_consultas;
        private MetroFramework.Controls.MetroProgressBar ProgressBar;
    }
}