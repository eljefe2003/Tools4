namespace Tools
{
    partial class FrmServicio
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
            this.slideButton1 = new AltoControls.SlideButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rbDesde1hora = new System.Windows.Forms.RadioButton();
            this.rbDesde2horas = new System.Windows.Forms.RadioButton();
            this.rbDesde6horas = new System.Windows.Forms.RadioButton();
            this.rbDesdeDia = new System.Windows.Forms.RadioButton();
            this.rbHastaDia = new System.Windows.Forms.RadioButton();
            this.rbHasta15min = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Regla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Error = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.rbFrec30min = new System.Windows.Forms.RadioButton();
            this.rbFrec20min = new System.Windows.Forms.RadioButton();
            this.rbFrec10min = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.btnActualizaParametros = new MetroFramework.Controls.MetroButton();
            this.btnForzarEjecucion = new MetroFramework.Controls.MetroButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // slideButton1
            // 
            this.slideButton1.BorderColor = System.Drawing.Color.LightGray;
            this.slideButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.slideButton1.IsOn = true;
            this.slideButton1.Location = new System.Drawing.Point(110, 47);
            this.slideButton1.Name = "slideButton1";
            this.slideButton1.Size = new System.Drawing.Size(40, 22);
            this.slideButton1.TabIndex = 0;
            this.slideButton1.Text = "slideButton1";
            this.slideButton1.TextEnabled = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Facturas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "Desde";
            // 
            // rbDesde1hora
            // 
            this.rbDesde1hora.AutoSize = true;
            this.rbDesde1hora.Checked = true;
            this.rbDesde1hora.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDesde1hora.Location = new System.Drawing.Point(3, 3);
            this.rbDesde1hora.Name = "rbDesde1hora";
            this.rbDesde1hora.Size = new System.Drawing.Size(92, 21);
            this.rbDesde1hora.TabIndex = 7;
            this.rbDesde1hora.TabStop = true;
            this.rbDesde1hora.Text = "1 hora atras";
            this.rbDesde1hora.UseVisualStyleBackColor = true;
            // 
            // rbDesde2horas
            // 
            this.rbDesde2horas.AutoSize = true;
            this.rbDesde2horas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDesde2horas.Location = new System.Drawing.Point(101, 3);
            this.rbDesde2horas.Name = "rbDesde2horas";
            this.rbDesde2horas.Size = new System.Drawing.Size(92, 21);
            this.rbDesde2horas.TabIndex = 8;
            this.rbDesde2horas.Text = "2 horas atras";
            this.rbDesde2horas.UseVisualStyleBackColor = true;
            // 
            // rbDesde6horas
            // 
            this.rbDesde6horas.AutoSize = true;
            this.rbDesde6horas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDesde6horas.Location = new System.Drawing.Point(199, 3);
            this.rbDesde6horas.Name = "rbDesde6horas";
            this.rbDesde6horas.Size = new System.Drawing.Size(92, 21);
            this.rbDesde6horas.TabIndex = 9;
            this.rbDesde6horas.Text = "6 horas atras";
            this.rbDesde6horas.UseVisualStyleBackColor = true;
            // 
            // rbDesdeDia
            // 
            this.rbDesdeDia.AutoSize = true;
            this.rbDesdeDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDesdeDia.Location = new System.Drawing.Point(297, 3);
            this.rbDesdeDia.Name = "rbDesdeDia";
            this.rbDesdeDia.Size = new System.Drawing.Size(82, 21);
            this.rbDesdeDia.TabIndex = 10;
            this.rbDesdeDia.Text = "24 horas";
            this.rbDesdeDia.UseVisualStyleBackColor = true;
            // 
            // rbHastaDia
            // 
            this.rbHastaDia.AutoSize = true;
            this.rbHastaDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHastaDia.Location = new System.Drawing.Point(157, 3);
            this.rbHastaDia.Name = "rbHastaDia";
            this.rbHastaDia.Size = new System.Drawing.Size(99, 21);
            this.rbHastaDia.TabIndex = 15;
            this.rbHastaDia.Text = "Hora actual";
            this.rbHastaDia.UseVisualStyleBackColor = true;
            // 
            // rbHasta15min
            // 
            this.rbHasta15min.AutoSize = true;
            this.rbHasta15min.Checked = true;
            this.rbHasta15min.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHasta15min.Location = new System.Drawing.Point(3, 3);
            this.rbHasta15min.Name = "rbHasta15min";
            this.rbHasta15min.Size = new System.Drawing.Size(105, 21);
            this.rbHasta15min.TabIndex = 12;
            this.rbHasta15min.TabStop = true;
            this.rbHasta15min.Text = "Hace 15 min";
            this.rbHasta15min.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 22);
            this.label5.TabIndex = 11;
            this.label5.Text = "Hasta";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Regla,
            this.Error,
            this.Desde,
            this.Hasta});
            this.dataGridView1.Location = new System.Drawing.Point(28, 241);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(607, 154);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Regla
            // 
            this.Regla.HeaderText = "Regla";
            this.Regla.Name = "Regla";
            // 
            // Error
            // 
            this.Error.HeaderText = "Error";
            this.Error.Name = "Error";
            // 
            // Desde
            // 
            this.Desde.HeaderText = "Desde";
            this.Desde.Name = "Desde";
            // 
            // Hasta
            // 
            this.Hasta.HeaderText = "Hasta";
            this.Hasta.Name = "Hasta";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(726, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(240, 22);
            this.label6.TabIndex = 17;
            this.label6.Text = "Ultima Hora ejecucion: 13:33";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(726, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(255, 22);
            this.label7.TabIndex = 18;
            this.label7.Text = "Proxima Hora ejecucion: 13:43";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(791, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 73);
            this.label8.TabIndex = 19;
            this.label8.Text = "55";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(800, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 22);
            this.label9.TabIndex = 20;
            this.label9.Text = "Status 95";
            // 
            // rbFrec30min
            // 
            this.rbFrec30min.AutoSize = true;
            this.rbFrec30min.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFrec30min.Location = new System.Drawing.Point(183, 3);
            this.rbFrec30min.Name = "rbFrec30min";
            this.rbFrec30min.Size = new System.Drawing.Size(68, 21);
            this.rbFrec30min.TabIndex = 24;
            this.rbFrec30min.Text = "30 min";
            this.rbFrec30min.UseVisualStyleBackColor = true;
            // 
            // rbFrec20min
            // 
            this.rbFrec20min.AutoSize = true;
            this.rbFrec20min.Checked = true;
            this.rbFrec20min.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFrec20min.Location = new System.Drawing.Point(93, 3);
            this.rbFrec20min.Name = "rbFrec20min";
            this.rbFrec20min.Size = new System.Drawing.Size(68, 21);
            this.rbFrec20min.TabIndex = 23;
            this.rbFrec20min.TabStop = true;
            this.rbFrec20min.Text = "20 min";
            this.rbFrec20min.UseVisualStyleBackColor = true;
            // 
            // rbFrec10min
            // 
            this.rbFrec10min.AutoSize = true;
            this.rbFrec10min.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFrec10min.Location = new System.Drawing.Point(3, 3);
            this.rbFrec10min.Name = "rbFrec10min";
            this.rbFrec10min.Size = new System.Drawing.Size(68, 21);
            this.rbFrec10min.TabIndex = 22;
            this.rbFrec10min.Text = "10 min";
            this.rbFrec10min.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(24, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 22);
            this.label10.TabIndex = 21;
            this.label10.Text = "Frecuencia";
            // 
            // btnActualizaParametros
            // 
            this.btnActualizaParametros.Location = new System.Drawing.Point(29, 205);
            this.btnActualizaParametros.Name = "btnActualizaParametros";
            this.btnActualizaParametros.Size = new System.Drawing.Size(606, 30);
            this.btnActualizaParametros.TabIndex = 25;
            this.btnActualizaParametros.Text = "Actualizar parametros";
            this.btnActualizaParametros.UseSelectable = true;
            this.btnActualizaParametros.Click += new System.EventHandler(this.btnActualizaParametros_Click);
            // 
            // btnForzarEjecucion
            // 
            this.btnForzarEjecucion.Location = new System.Drawing.Point(716, 189);
            this.btnForzarEjecucion.Name = "btnForzarEjecucion";
            this.btnForzarEjecucion.Size = new System.Drawing.Size(265, 26);
            this.btnForzarEjecucion.TabIndex = 26;
            this.btnForzarEjecucion.Text = "Forzar ejecucion";
            this.btnForzarEjecucion.UseSelectable = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.rbFrec10min, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbFrec20min, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.rbFrec30min, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(143, 75);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(270, 37);
            this.tableLayoutPanel1.TabIndex = 27;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.rbDesde1hora, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.rbDesde2horas, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.rbDesde6horas, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.rbDesdeDia, 3, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(142, 123);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(493, 29);
            this.tableLayoutPanel2.TabIndex = 28;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.rbHastaDia, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.rbHasta15min, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(142, 160);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(308, 36);
            this.tableLayoutPanel3.TabIndex = 29;
            // 
            // FrmServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 450);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnForzarEjecucion);
            this.Controls.Add(this.btnActualizaParametros);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.slideButton1);
            this.Name = "FrmServicio";
            this.Text = "Servicio";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AltoControls.SlideButton slideButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbDesde1hora;
        private System.Windows.Forms.RadioButton rbDesde2horas;
        private System.Windows.Forms.RadioButton rbDesde6horas;
        private System.Windows.Forms.RadioButton rbDesdeDia;
        private System.Windows.Forms.RadioButton rbHastaDia;
        private System.Windows.Forms.RadioButton rbHasta15min;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Regla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Error;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desde;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hasta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rbFrec30min;
        private System.Windows.Forms.RadioButton rbFrec20min;
        private System.Windows.Forms.RadioButton rbFrec10min;
        private System.Windows.Forms.Label label10;
        private MetroFramework.Controls.MetroButton btnActualizaParametros;
        private MetroFramework.Controls.MetroButton btnForzarEjecucion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}