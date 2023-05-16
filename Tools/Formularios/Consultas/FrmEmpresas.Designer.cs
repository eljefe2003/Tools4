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
            this.lbl_Log = new System.Windows.Forms.Label();
            this.rtb_Log = new System.Windows.Forms.RichTextBox();
            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ProgressBar = new MetroFramework.Controls.MetroProgressBar();
            this.btnProcesar = new FontAwesome.Sharp.IconButton();
            this.label40 = new System.Windows.Forms.Label();
            this.txt_RucPse = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.txt_RazonS = new System.Windows.Forms.TextBox();
            this.dtgEmpresas = new System.Windows.Forms.DataGridView();
            this.tlpGeneral.SuspendLayout();
            this.tlpLog.SuspendLayout();
            this.tlpForm.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.pnl1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.tlpGeneral.Size = new System.Drawing.Size(878, 505);
            this.tlpGeneral.TabIndex = 25;
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
            this.tlpForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tlpForm.ColumnCount = 1;
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpForm.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.tlpForm.Controls.Add(this.gbFiltros, 0, 0);
            this.tlpForm.Controls.Add(this.dtgEmpresas, 0, 1);
            this.tlpForm.Location = new System.Drawing.Point(31, 78);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.RowCount = 3;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.36103F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.17192F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.75358F));
            this.tlpForm.Size = new System.Drawing.Size(475, 349);
            this.tlpForm.TabIndex = 24;
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.pnl1);
            this.gbFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFiltros.Enabled = false;
            this.gbFiltros.Font = new System.Drawing.Font("Calibri", 9.5F, System.Drawing.FontStyle.Bold);
            this.gbFiltros.Location = new System.Drawing.Point(3, 3);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(469, 85);
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
            this.pnl1.Size = new System.Drawing.Size(463, 63);
            this.pnl1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ProgressBar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnProcesar, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 303);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.21429F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.78572F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(469, 43);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProgressBar.Location = new System.Drawing.Point(2, 33);
            this.ProgressBar.Margin = new System.Windows.Forms.Padding(2);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(465, 8);
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
            this.btnProcesar.Size = new System.Drawing.Size(463, 25);
            this.btnProcesar.TabIndex = 22;
            this.btnProcesar.Text = "Buscar";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label40.Location = new System.Drawing.Point(3, 31);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(122, 32);
            this.label40.TabIndex = 19;
            this.label40.Text = "Razón S.:";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_RucPse
            // 
            this.txt_RucPse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txt_RucPse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_RucPse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_RucPse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_RucPse.Location = new System.Drawing.Point(131, 3);
            this.txt_RucPse.MaxLength = 11;
            this.txt_RucPse.Name = "txt_RucPse";
            this.txt_RucPse.Size = new System.Drawing.Size(329, 23);
            this.txt_RucPse.TabIndex = 5;
            this.txt_RucPse.TextChanged += new System.EventHandler(this.txt_RucPse_TextChanged);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label36.Location = new System.Drawing.Point(3, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(122, 31);
            this.label36.TabIndex = 0;
            this.label36.Text = "Ruc:";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.tableLayoutPanel4.Size = new System.Drawing.Size(463, 63);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // txt_RazonS
            // 
            this.txt_RazonS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txt_RazonS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_RazonS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_RazonS.Location = new System.Drawing.Point(131, 34);
            this.txt_RazonS.MaxLength = 11;
            this.txt_RazonS.Name = "txt_RazonS";
            this.txt_RazonS.Size = new System.Drawing.Size(329, 23);
            this.txt_RazonS.TabIndex = 21;
            this.txt_RazonS.TextChanged += new System.EventHandler(this.txt_RazonS_TextChanged);
            // 
            // dtgEmpresas
            // 
            this.dtgEmpresas.AllowUserToOrderColumns = true;
            this.dtgEmpresas.AllowUserToResizeColumns = false;
            this.dtgEmpresas.AllowUserToResizeRows = false;
            this.dtgEmpresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEmpresas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgEmpresas.Location = new System.Drawing.Point(3, 94);
            this.dtgEmpresas.MultiSelect = false;
            this.dtgEmpresas.Name = "dtgEmpresas";
            this.dtgEmpresas.ReadOnly = true;
            this.dtgEmpresas.RowHeadersVisible = false;
            this.dtgEmpresas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEmpresas.Size = new System.Drawing.Size(469, 203);
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
            this.tlpLog.PerformLayout();
            this.tlpForm.ResumeLayout(false);
            this.gbFiltros.ResumeLayout(false);
            this.pnl1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEmpresas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpGeneral;
        private System.Windows.Forms.TableLayoutPanel tlpLog;
        private System.Windows.Forms.Label lbl_Log;
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
    }
}