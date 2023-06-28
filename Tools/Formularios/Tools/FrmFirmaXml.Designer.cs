namespace Tools
{
    partial class FrmFirmaXml
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpLog = new System.Windows.Forms.TableLayoutPanel();
            this.rtbJson = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnGuardarLog = new FontAwesome.Sharp.IconButton();
            this.lbl_Log = new System.Windows.Forms.Label();
            this.btnCopiarLog = new FontAwesome.Sharp.IconButton();
            this.btnBorrarLog = new FontAwesome.Sharp.IconButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnBuscarJson2 = new FontAwesome.Sharp.IconButton();
            this.txtRutaJson = new System.Windows.Forms.TextBox();
            this.btnPlay = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel2.SuspendLayout();
            this.tlpLog.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tlpLog, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.3164F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.6836F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1195, 533);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // tlpLog
            // 
            this.tlpLog.BackColor = System.Drawing.Color.Transparent;
            this.tlpLog.ColumnCount = 1;
            this.tlpLog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLog.Controls.Add(this.rtbJson, 0, 1);
            this.tlpLog.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tlpLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLog.Location = new System.Drawing.Point(3, 62);
            this.tlpLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlpLog.Name = "tlpLog";
            this.tlpLog.RowCount = 2;
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.266666F));
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.73333F));
            this.tlpLog.Size = new System.Drawing.Size(1189, 469);
            this.tlpLog.TabIndex = 24;
            // 
            // rtbJson
            // 
            this.rtbJson.BackColor = System.Drawing.SystemColors.Window;
            this.rtbJson.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbJson.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbJson.ForeColor = System.Drawing.Color.White;
            this.rtbJson.Location = new System.Drawing.Point(4, 42);
            this.rtbJson.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtbJson.Name = "rtbJson";
            this.rtbJson.Size = new System.Drawing.Size(1181, 423);
            this.rtbJson.TabIndex = 4;
            this.rtbJson.Text = "";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.77878F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.740407F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.740407F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.62754F));
            this.tableLayoutPanel3.Controls.Add(this.btnGuardarLog, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbl_Log, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnCopiarLog, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnBorrarLog, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1181, 30);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // btnGuardarLog
            // 
            this.btnGuardarLog.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardarLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGuardarLog.FlatAppearance.BorderSize = 0;
            this.btnGuardarLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarLog.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnGuardarLog.IconColor = System.Drawing.Color.White;
            this.btnGuardarLog.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardarLog.IconSize = 20;
            this.btnGuardarLog.Location = new System.Drawing.Point(1018, 4);
            this.btnGuardarLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuardarLog.Name = "btnGuardarLog";
            this.btnGuardarLog.Size = new System.Drawing.Size(48, 22);
            this.btnGuardarLog.TabIndex = 4;
            this.btnGuardarLog.UseVisualStyleBackColor = false;
            // 
            // lbl_Log
            // 
            this.lbl_Log.AutoSize = true;
            this.lbl_Log.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Log.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Log.ForeColor = System.Drawing.Color.White;
            this.lbl_Log.Location = new System.Drawing.Point(4, 0);
            this.lbl_Log.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Log.Name = "lbl_Log";
            this.lbl_Log.Size = new System.Drawing.Size(1006, 30);
            this.lbl_Log.TabIndex = 3;
            this.lbl_Log.Text = "Log";
            this.lbl_Log.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCopiarLog
            // 
            this.btnCopiarLog.BackColor = System.Drawing.Color.Transparent;
            this.btnCopiarLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCopiarLog.FlatAppearance.BorderSize = 0;
            this.btnCopiarLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopiarLog.IconChar = FontAwesome.Sharp.IconChar.Copy;
            this.btnCopiarLog.IconColor = System.Drawing.Color.White;
            this.btnCopiarLog.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCopiarLog.IconSize = 20;
            this.btnCopiarLog.Location = new System.Drawing.Point(1074, 4);
            this.btnCopiarLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCopiarLog.Name = "btnCopiarLog";
            this.btnCopiarLog.Size = new System.Drawing.Size(48, 22);
            this.btnCopiarLog.TabIndex = 5;
            this.btnCopiarLog.UseVisualStyleBackColor = false;
            // 
            // btnBorrarLog
            // 
            this.btnBorrarLog.BackColor = System.Drawing.Color.Transparent;
            this.btnBorrarLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBorrarLog.FlatAppearance.BorderSize = 0;
            this.btnBorrarLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrarLog.IconChar = FontAwesome.Sharp.IconChar.Eraser;
            this.btnBorrarLog.IconColor = System.Drawing.Color.White;
            this.btnBorrarLog.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBorrarLog.IconSize = 20;
            this.btnBorrarLog.Location = new System.Drawing.Point(1130, 4);
            this.btnBorrarLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBorrarLog.Name = "btnBorrarLog";
            this.btnBorrarLog.Size = new System.Drawing.Size(47, 22);
            this.btnBorrarLog.TabIndex = 0;
            this.btnBorrarLog.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1187, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Archivo";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.95023F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.524887F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.524887F));
            this.tableLayoutPanel1.Controls.Add(this.btnBuscarJson2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtRutaJson, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPlay, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 19);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1179, 29);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnBuscarJson2
            // 
            this.btnBuscarJson2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBuscarJson2.FlatAppearance.BorderSize = 0;
            this.btnBuscarJson2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarJson2.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscarJson2.IconColor = System.Drawing.Color.White;
            this.btnBuscarJson2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscarJson2.IconSize = 17;
            this.btnBuscarJson2.Location = new System.Drawing.Point(1076, 4);
            this.btnBuscarJson2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuscarJson2.Name = "btnBuscarJson2";
            this.btnBuscarJson2.Size = new System.Drawing.Size(45, 21);
            this.btnBuscarJson2.TabIndex = 3;
            this.btnBuscarJson2.UseVisualStyleBackColor = true;
            // 
            // txtRutaJson
            // 
            this.txtRutaJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRutaJson.Location = new System.Drawing.Point(4, 4);
            this.txtRutaJson.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRutaJson.Name = "txtRutaJson";
            this.txtRutaJson.Size = new System.Drawing.Size(1064, 22);
            this.txtRutaJson.TabIndex = 1;
            // 
            // btnPlay
            // 
            this.btnPlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.IconChar = FontAwesome.Sharp.IconChar.Play;
            this.btnPlay.IconColor = System.Drawing.Color.White;
            this.btnPlay.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPlay.IconSize = 15;
            this.btnPlay.Location = new System.Drawing.Point(1129, 4);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(46, 21);
            this.btnPlay.TabIndex = 4;
            this.btnPlay.UseVisualStyleBackColor = true;
            // 
            // FrmFirmaXml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1195, 533);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmFirmaXml";
            this.Text = "Validar Firma XML";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tlpLog.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tlpLog;
        public System.Windows.Forms.RichTextBox rtbJson;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private FontAwesome.Sharp.IconButton btnGuardarLog;
        private System.Windows.Forms.Label lbl_Log;
        private FontAwesome.Sharp.IconButton btnCopiarLog;
        private FontAwesome.Sharp.IconButton btnBorrarLog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton btnBuscarJson2;
        private System.Windows.Forms.TextBox txtRutaJson;
        private FontAwesome.Sharp.IconButton btnPlay;
    }
}