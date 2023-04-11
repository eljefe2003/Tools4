namespace Tools
{
    partial class Anuncios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rtbAnuncios = new System.Windows.Forms.RichTextBox();
            this.dtgAnuncios = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSeccion = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMarcarTodosLeidos = new FontAwesome.Sharp.IconButton();
            this.btnCerrar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAnuncios)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbAnuncios
            // 
            this.rtbAnuncios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbAnuncios.Location = new System.Drawing.Point(3, 123);
            this.rtbAnuncios.Name = "rtbAnuncios";
            this.rtbAnuncios.Size = new System.Drawing.Size(605, 132);
            this.rtbAnuncios.TabIndex = 0;
            this.rtbAnuncios.Text = "";
            // 
            // dtgAnuncios
            // 
            this.dtgAnuncios.AllowUserToResizeColumns = false;
            this.dtgAnuncios.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgAnuncios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgAnuncios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAnuncios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgAnuncios.Location = new System.Drawing.Point(2, 2);
            this.dtgAnuncios.Margin = new System.Windows.Forms.Padding(2);
            this.dtgAnuncios.MultiSelect = false;
            this.dtgAnuncios.Name = "dtgAnuncios";
            this.dtgAnuncios.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgAnuncios.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgAnuncios.RowHeadersVisible = false;
            this.dtgAnuncios.RowHeadersWidth = 51;
            this.dtgAnuncios.RowTemplate.Height = 24;
            this.dtgAnuncios.Size = new System.Drawing.Size(607, 116);
            this.dtgAnuncios.TabIndex = 6;
            this.dtgAnuncios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgAnuncios_CellClick);
            this.dtgAnuncios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgAnuncios_CellContentClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblSeccion, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.537572F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.03468F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.71676F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(620, 340);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // lblSeccion
            // 
            this.lblSeccion.AutoSize = true;
            this.lblSeccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSeccion.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeccion.Location = new System.Drawing.Point(3, 0);
            this.lblSeccion.Name = "lblSeccion";
            this.lblSeccion.Size = new System.Drawing.Size(614, 32);
            this.lblSeccion.TabIndex = 10;
            this.lblSeccion.Text = "Anuncios";
            this.lblSeccion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.rtbAnuncios, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.dtgAnuncios, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 35);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.76806F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.23194F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(611, 258);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.76768F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.23232F));
            this.tableLayoutPanel3.Controls.Add(this.btnMarcarTodosLeidos, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnCerrar, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 299);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(614, 38);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // btnMarcarTodosLeidos
            // 
            this.btnMarcarTodosLeidos.BackColor = System.Drawing.Color.Silver;
            this.btnMarcarTodosLeidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMarcarTodosLeidos.FlatAppearance.BorderSize = 0;
            this.btnMarcarTodosLeidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarcarTodosLeidos.ForeColor = System.Drawing.Color.White;
            this.btnMarcarTodosLeidos.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnMarcarTodosLeidos.IconColor = System.Drawing.Color.Black;
            this.btnMarcarTodosLeidos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMarcarTodosLeidos.Location = new System.Drawing.Point(3, 3);
            this.btnMarcarTodosLeidos.Name = "btnMarcarTodosLeidos";
            this.btnMarcarTodosLeidos.Size = new System.Drawing.Size(311, 32);
            this.btnMarcarTodosLeidos.TabIndex = 1;
            this.btnMarcarTodosLeidos.Text = "Marcar Todos como leidos";
            this.btnMarcarTodosLeidos.UseVisualStyleBackColor = false;
            this.btnMarcarTodosLeidos.Click += new System.EventHandler(this.btnMarcarTodosLeidos_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Silver;
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnCerrar.IconColor = System.Drawing.Color.Black;
            this.btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrar.Location = new System.Drawing.Point(320, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(291, 32);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "Cerrar Ventana";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click_1);
            // 
            // Anuncios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 340);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Anuncios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Anuncios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAnuncios)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbAnuncios;
        private System.Windows.Forms.DataGridView dtgAnuncios;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private FontAwesome.Sharp.IconButton btnMarcarTodosLeidos;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private System.Windows.Forms.Label lblSeccion;
    }
}