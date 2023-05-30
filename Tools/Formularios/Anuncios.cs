using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Tools.Clases_varias;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Tools
{
    public partial class Anuncios : Form
    {
        public Anuncios()
        {
            InitializeComponent();
            btnCerrar.DialogResult = DialogResult.OK;
        }
        Conexion2 conex = new Conexion2();
        DataTable dt7;
        public Anuncios(Color color1, Color color2, Color color3, Color color4)
        {
            InitializeComponent();
            tableLayoutPanel1.BackColor = Color.White;
            btnCerrar.BackColor = color1;
            btnMarcarTodosLeidos.BackColor = color1;
            //tlpLog.BackColor = color1;
            //rtb_Log.BackColor = color1;
            //gbAmbiente.ForeColor = color1;
            //gbFiltros.ForeColor = color1;
            rtbAnuncios.ForeColor = color1;
            //lbl_Log.ForeColor = color2;

        }

        private void Anuncios_Load(object sender, EventArgs e)
        {
            metroTabControl1.SelectTab(0);
            CargaDtgVersionPublica();
            CargaDtgVersion();
            btnCerrar.DialogResult = DialogResult.OK;
        }


        #region Publico
        public void CargaDtgVersionPublica()
        {
            dtgAnuncios.Columns.Clear();
            dt7 = new DataTable();
            dt7.Columns.Add("ASUNTO");
            dt7.Columns.Add("VERSION");
            dt7.Columns.Add("LEIDO", typeof(bool));
            var anunciosArray = conex.getAllVersion().ToArray();

            //string[] entries = Directory.GetFileSystemEntries(ConfigPerso.RutaEjemplos + cmbTipoDoc.Text + "\\", "*", SearchOption.TopDirectoryOnly);

            for (int i = 0; i < anunciosArray.Length; i++)
            {
                DataRow row7 = dt7.NewRow();
                row7["ASUNTO"] = anunciosArray[i].Asunto;
                row7["VERSION"] = anunciosArray[i].VersionNum;
                if (anunciosArray[i].Leido == 1)
                {
                    row7["LEIDO"] = true;
                }
                else
                {
                    row7["LEIDO"] = false;
                }
                dt7.Rows.Add(row7);
            }
            dtgAnuncios.DataSource = dt7;
            var num = dtgAnuncios.Size.Width / 11;
            dtgAnuncios.Columns[0].Width = num*8 ;
            dtgAnuncios.Columns[1].Width = num;
            dtgAnuncios.Columns[2].Width = num;
            //this.dtgEjemplos.Columns["NOMBRE"].Visible = false;

            //dtgEjemplos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgAnuncios.ReadOnly = true;

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font(dtgAnuncios.Font, System.Drawing.FontStyle.Bold);

            foreach (DataGridViewRow row in dtgAnuncios.Rows)
            {
                if (row.Index >= 0 && row.Index + 1 < dtgAnuncios.RowCount)
                {
                    string id = dtgAnuncios.Rows[row.Index].Cells[2].Value.ToString();
                    if (id != "True")
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                            cell.Style.ApplyStyle(style);
                    }
                }
            }
            //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            //dtgEjemplos.Columns.Add(btn);
            //btn.Text = "Enviar";
            //btn.Name = "ACCION";
            //btn.Width = 65;
            //btn.UseColumnTextForButtonValue = true;
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgAnuncios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex + 1 < dtgAnuncios.RowCount)
            {
                string vers = dtgAnuncios.Rows[e.RowIndex].Cells[1].Value.ToString();
                Version anun = new Version();
                anun = conex.getVersion(vers);
                if (dtgAnuncios.Columns[e.ColumnIndex].Name == "LEIDO") // Eliminar
                {
                    int leido = anun.Leido;
                    if (leido == 1)
                    {
                        anun.Leido = 0;
                    }
                    else
                    {
                        anun.Leido = 1;
                    }
                    conex.saveVersion(anun, false);
                    CargaDtgVersionPublica();
                }
            }
        }

        private void btnMarcarTodosLeidos_Click(object sender, EventArgs e)
        {
            conex.saveAnuncioTodosLeidos();
            CargaDtgVersionPublica();
        }

        private void dtgAnuncios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex + 1 < dtgAnuncios.RowCount)
            {
                string id = dtgAnuncios.Rows[e.RowIndex].Cells[1].Value.ToString();
                Version ver = new Version();
                ver = conex.getVersion(id);
                var list = conex.getAllComentarios(ver.Id);
                var arrayOfComentarios = list.ToArray();
                if (dtgAnuncios.Columns[e.ColumnIndex].Name == "LEIDO") // Eliminar
                {
                    //string leido = anun.Leido;
                    //if (leido == "1")
                    //{
                    //    anun.Leido = "0";
                    //}
                    //else
                    //{
                    //    anun.Leido = "1";
                    //}
                    //conex.saveAnuncio(anun, false);
                    //CargaDtgUsuario();
                }
                else
                {
                    string Comentarios = "---------------------------- " + id + "----------------------------" + Environment.NewLine + Environment.NewLine;
                    for (int i = 0; i < arrayOfComentarios.Length; i++)
                    {
                        Comentarios += "- " + arrayOfComentarios[i].Mensaje + " (" + arrayOfComentarios[i].Tipo + ")" + Environment.NewLine;
                    }
                    rtbAnuncios.Text = Comentarios;
                }
            }
        }
        #endregion

        #region Desarrollador

        private void btnAñadirVersion_Click(object sender, EventArgs e)
        {
            if (validaVersion())
            {
                try
                {
                    Version ver = new Version();
                    ver.VersionNum = txtVersion.Text;
                    ver.Asunto = txtAsunto.Text.ToUpper();
                    ver.Estado = 1;      
                    ver.Leido = 0;
                    Version existeVer = conex.getVersion(txtVersion.Text);
                    if (existeVer == null)
                        conex.saveVersion(ver, true);
                    else
                        ver.Id = existeVer.Id;
                        conex.saveVersion(ver, false);

                    System.Windows.MessageBox.Show("Versión procesada con éxito!");
                    CargaDtgVersion();
                }
                catch(Exception ex) 
                {
                    System.Windows.MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        bool validaVersion()
        {
            int cont = 0;

            if (txtVersion.Text == "")
                cont++;

            if (txtAsunto.Text == "")
                cont++;

            if (cont == 0)
                return true;
            else
                System.Windows.MessageBox.Show("Revisa los parametros asignados a la versión!");
                return false;
        }

        public void CargaDtgVersion()
        {
            cmbVersion.Items.Clear();
            dtgVersion.Columns.Clear();
            dt7 = new DataTable();
            dt7.Columns.Add("Id");
            dt7.Columns.Add("Versión");
            dt7.Columns.Add("Asunto");
            dt7.Columns.Add("Estado", typeof(bool));
            dt7.Columns.Add("Leido", typeof(bool));
            var anunciosArray = conex.getAllVersion().ToArray();
            for (int i = 0; i < anunciosArray.Length; i++)
            {
                DataRow row7 = dt7.NewRow();
                row7["Id"] = anunciosArray[i].Id;
                row7["Versión"] = anunciosArray[i].VersionNum;
                row7["Asunto"] = anunciosArray[i].Asunto;
                if (anunciosArray[i].Estado == 1)
                    row7["Estado"] = true;
                else
                    row7["Estado"] = false;

                if (anunciosArray[i].Leido == 1)
                    row7["Leido"] = true;
                else
                    row7["Leido"] = false;

                dt7.Rows.Add(row7);
                cmbVersion.Items.Add(anunciosArray[i].VersionNum);
            }
            dtgVersion.DataSource = dt7;
            var num = dtgVersion.Size.Width / 11;
            dtgVersion.Columns[0].Width = num;
            dtgVersion.Columns[1].Width = num;
            dtgVersion.Columns[2].Width = num * 6;
            dtgVersion.Columns[3].Width = num;
            dtgVersion.Columns[4].Width = num;
            //this.dtgEjemplos.Columns["NOMBRE"].Visible = false;
            dtgVersion.ReadOnly = true;

        }

        private void dtgVersion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex + 1 < dtgVersion.RowCount)
            {
                txtVersion.Text = dtgVersion.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtAsunto.Text = dtgVersion.Rows[e.RowIndex].Cells[2].Value.ToString();              
            }
        }

        private void dtgVersion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex + 1 < dtgVersion.RowCount)
            {
                string version = dtgVersion.Rows[e.RowIndex].Cells[1].Value.ToString();
                Version anun = new Version();
                anun = conex.getVersion(version);
                if (dtgVersion.Columns[e.ColumnIndex].Name == "Leido") // Eliminar
                {
                    int leido = anun.Leido;
                    if (leido == 1)
                    {
                        anun.Leido = 0;
                    }
                    else
                    {
                        anun.Leido = 1;
                    }
                    conex.saveVersion(anun, false);
                    CargaDtgVersion();
                }
                else if (dtgVersion.Columns[e.ColumnIndex].Name == "Estado") // Eliminar
                {
                    int leido = anun.Estado;
                    if (leido == 1)
                    {
                        anun.Estado = 0;
                    }
                    else
                    {
                        anun.Estado = 1;
                    }
                    conex.saveVersion(anun, false);
                    CargaDtgVersion();
                }
            }
        }

        private void btnAñadirComentario_Click(object sender, EventArgs e)
        {
            if (validaComentario())
            {
                try
                {
                    Comentario com = new Comentario();
                    Version existeVer = conex.getVersion(cmbVersion.Text);

                    com.Mensaje = rtbComentario.Text.ToUpper();
                    com.VersionClase = existeVer;
                    com.Tipo = cmbTipo.Text;
                    com.Status = 1;
                    conex.saveMensaje(com, true);

                    System.Windows.MessageBox.Show("Comentario procesado con éxito!");
                    //CargaDtgVersion();
                    Limpiar();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void Limpiar()
        {
            rtbComentario.Text = "";
            cmbTipo.Text = "";
        }

        bool validaComentario()
        {
            int cont = 0;

            if (cmbTipo.Text == "")
                cont++;

            if (rtbComentario.Text == "")
                cont++;

            if (cmbVersion.Text == "")
                cont++;

            if (cont == 0)
                return true;
            else
                System.Windows.MessageBox.Show("Revisa los parametros asignados a tu comentario!");
            return false;
        }

        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroTabControl1.SelectedIndex == 1)
                if (Environment.UserName != "guevarae")
                    metroTabControl1.SelectTab(0);
        }

        #endregion


    }
}
