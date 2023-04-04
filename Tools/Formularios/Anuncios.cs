using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Tools.Clases_varias;

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
            CargaDtgUsuario();
            btnCerrar.DialogResult = DialogResult.OK;

        }

        public void CargaDtgUsuario()
        {
            dtgAnuncios.Columns.Clear();
            dt7 = new DataTable();
            dt7.Columns.Add("ID");
            dt7.Columns.Add("ASUNTO");
            dt7.Columns.Add("VERSION");
            dt7.Columns.Add("LEIDO", typeof(bool));
            var anunciosArray = conex.getAllAnuncios().ToArray();

            //string[] entries = Directory.GetFileSystemEntries(ConfigPerso.RutaEjemplos + cmbTipoDoc.Text + "\\", "*", SearchOption.TopDirectoryOnly);

            for (int i = 0; i < anunciosArray.Length; i++)
            {
                DataRow row7 = dt7.NewRow();
                row7["ID"] = anunciosArray[i].Id;
                row7["ASUNTO"] = anunciosArray[i].Asunto;
                row7["VERSION"] = anunciosArray[i].Version;
                if(anunciosArray[i].Leido == "1")
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
            var num = dtgAnuncios.Size.Width /11;
            dtgAnuncios.Columns[0].Width = num;
            dtgAnuncios.Columns[1].Width = num * 7;
            dtgAnuncios.Columns[2].Width = num;
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
                    string id = dtgAnuncios.Rows[row.Index].Cells[3].Value.ToString();
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


        private void btnCerrar_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgAnuncios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex + 1 < dtgAnuncios.RowCount)
            {
                string id = dtgAnuncios.Rows[e.RowIndex].Cells[0].Value.ToString();
                Anuncio anun = new Anuncio();
                anun = conex.getAnuncio(id);
                if (dtgAnuncios.Columns[e.ColumnIndex].Name == "LEIDO") // Eliminar
                {
                   
                    string leido = anun.Leido;
                    if (leido == "1")
                    {
                        anun.Leido = "0";
                    }
                    else
                    {
                        anun.Leido = "1";
                    }
                    conex.saveAnuncio(anun, false);
                    CargaDtgUsuario();
                }
            }               
        }

        private void btnMarcarTodosLeidos_Click(object sender, EventArgs e)
        {
            conex.saveAnuncioTodosLeidos();
            CargaDtgUsuario();
        }

        private void dtgAnuncios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex + 1 < dtgAnuncios.RowCount)
            {
                string id = dtgAnuncios.Rows[e.RowIndex].Cells[0].Value.ToString();
                Anuncio anun = new Anuncio();
                anun = conex.getAnuncio(id);
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
                    rtbAnuncios.Text = anun.Mensaje.Replace("**","" + Environment.NewLine);
                }
            }
        }
    }
}
