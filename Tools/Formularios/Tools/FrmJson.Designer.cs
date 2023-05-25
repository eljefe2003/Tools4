namespace Tools
{
    partial class FrmJson
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtRutaJson = new System.Windows.Forms.TextBox();
            this.btnBuscarJson2 = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tlpLog = new System.Windows.Forms.TableLayoutPanel();
            this.rtbJson = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Log = new System.Windows.Forms.Label();
            this.btnBorrarLog = new FontAwesome.Sharp.IconButton();
            this.btnGuardarLog = new FontAwesome.Sharp.IconButton();
            this.btnCopiarLog = new FontAwesome.Sharp.IconButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tlpLog.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.74015F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.259851F));
            this.tableLayoutPanel1.Controls.Add(this.btnBuscarJson2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtRutaJson, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 24);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // txtRutaJson
            // 
            this.txtRutaJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRutaJson.Location = new System.Drawing.Point(3, 3);
            this.txtRutaJson.Name = "txtRutaJson";
            this.txtRutaJson.Size = new System.Drawing.Size(840, 20);
            this.txtRutaJson.TabIndex = 1;
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
            this.btnBuscarJson2.Location = new System.Drawing.Point(849, 3);
            this.btnBuscarJson2.Name = "btnBuscarJson2";
            this.btnBuscarJson2.Size = new System.Drawing.Size(32, 18);
            this.btnBuscarJson2.TabIndex = 3;
            this.btnBuscarJson2.UseVisualStyleBackColor = true;
            this.btnBuscarJson2.Click += new System.EventHandler(this.btnBuscarJson2_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tlpLog, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.3164F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.6836F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(896, 433);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(890, 43);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Archivo";
            // 
            // tlpLog
            // 
            this.tlpLog.BackColor = System.Drawing.Color.Transparent;
            this.tlpLog.ColumnCount = 1;
            this.tlpLog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLog.Controls.Add(this.rtbJson, 0, 1);
            this.tlpLog.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tlpLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLog.Location = new System.Drawing.Point(2, 51);
            this.tlpLog.Margin = new System.Windows.Forms.Padding(2);
            this.tlpLog.Name = "tlpLog";
            this.tlpLog.RowCount = 2;
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.266666F));
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.73333F));
            this.tlpLog.Size = new System.Drawing.Size(892, 380);
            this.tlpLog.TabIndex = 24;
            // 
            // rtbJson
            // 
            this.rtbJson.BackColor = System.Drawing.SystemColors.Window;
            this.rtbJson.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbJson.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbJson.ForeColor = System.Drawing.Color.White;
            this.rtbJson.Location = new System.Drawing.Point(3, 34);
            this.rtbJson.Name = "rtbJson";
            this.rtbJson.Size = new System.Drawing.Size(886, 343);
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
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(886, 25);
            this.tableLayoutPanel3.TabIndex = 6;
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
            this.lbl_Log.Size = new System.Drawing.Size(754, 25);
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
            this.btnBorrarLog.IconColor = System.Drawing.Color.White;
            this.btnBorrarLog.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBorrarLog.IconSize = 20;
            this.btnBorrarLog.Location = new System.Drawing.Point(847, 3);
            this.btnBorrarLog.Name = "btnBorrarLog";
            this.btnBorrarLog.Size = new System.Drawing.Size(36, 19);
            this.btnBorrarLog.TabIndex = 0;
            this.btnBorrarLog.UseVisualStyleBackColor = false;
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
            this.btnGuardarLog.Location = new System.Drawing.Point(763, 3);
            this.btnGuardarLog.Name = "btnGuardarLog";
            this.btnGuardarLog.Size = new System.Drawing.Size(36, 19);
            this.btnGuardarLog.TabIndex = 4;
            this.btnGuardarLog.UseVisualStyleBackColor = false;
            this.btnGuardarLog.Click += new System.EventHandler(this.btnGuardarLog_Click);
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
            this.btnCopiarLog.Location = new System.Drawing.Point(805, 3);
            this.btnCopiarLog.Name = "btnCopiarLog";
            this.btnCopiarLog.Size = new System.Drawing.Size(36, 19);
            this.btnCopiarLog.TabIndex = 5;
            this.btnCopiarLog.UseVisualStyleBackColor = false;
            this.btnCopiarLog.Click += new System.EventHandler(this.btnCopiarLog_Click);
            // 
            // FrmJson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(896, 433);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "FrmJson";
            this.Text = "Json";
            this.Load += new System.EventHandler(this.FrmJson_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tlpLog.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtRutaJson;
        private FontAwesome.Sharp.IconButton btnBuscarJson2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tlpLog;
        public System.Windows.Forms.RichTextBox rtbJson;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lbl_Log;
        private FontAwesome.Sharp.IconButton btnBorrarLog;
        private FontAwesome.Sharp.IconButton btnGuardarLog;
        private FontAwesome.Sharp.IconButton btnCopiarLog;
    }
}