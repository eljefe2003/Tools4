using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;
using System.Xml;

namespace Tools
{
    public partial class FrmJson : Form
    {
        public FrmJson(Color color1, Color color2, Color color3, Color color4)
        {
            InitializeComponent();
          
            btnBuscarJson2.BackColor = color1;
            btnPlay.BackColor = color1;
            lbl_Log.ForeColor = color1;
            btnBorrarLog.IconColor = color1;
            rtb_Log.ForeColor = color1;
            //rtb_Log.ReadOnly = true;
            gbArchivo.ForeColor = color1;

        }

        private void btnBuscarJson_Click(object sender, EventArgs e)
        {
            OpenFileDialog fichero = new OpenFileDialog();
            fichero.Multiselect = false;
            //fichero.Filter = "Text (*.txt)|*.TXT|XML (*.xml)|*.XML|ZIP (*.zip)|*.ZIP";
            fichero.Filter = "Text (*.txt)|*.TXT";
            string ContenidoJson = "";

            //open.Filter = "ZIP files (*.zip)|*.zip";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = fichero.FileName;
                string line = null;
                using (StreamReader file = new StreamReader(rutaArchivo))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        ContenidoJson = line;                       
                    }                  
                }
            }
            dynamic jsonObject = JsonConvert.DeserializeObject(ContenidoJson);

            // Serializar el objeto dinámico con formato indentado
            string formattedJson = JsonConvert.SerializeObject(jsonObject, Newtonsoft.Json.Formatting.Indented);

            // Imprimir el JSON formateado
            rtb_Log.Text = formattedJson;

        }

        private void btnBuscarJson2_Click(object sender, EventArgs e)
        {
            rtb_Log.Clear();
            OpenFileDialog fichero = new OpenFileDialog();
            fichero.Multiselect = false;
            //fichero.Filter = "Text (*.txt)|*.TXT|XML (*.xml)|*.XML|ZIP (*.zip)|*.ZIP";
            fichero.Filter = "Text (*.txt)|*.TXT";
            string ContenidoJson = "";

            //open.Filter = "ZIP files (*.zip)|*.zip";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                txtRutaJson.Text = fichero.FileName;                
            }          

        }

        private void btnCopiarLog_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(rtb_Log.Text, true);
            MessageBox.Show("Se ha copiado en el portapales el Log");
        }

        private void btnGuardarLog_Click(object sender, EventArgs e)
        {
            var ruta = AsignaRuta();
            System.IO.File.WriteAllText(ruta + "/JsonOrdenado.txt", rtb_Log.Text.Replace("\n", Environment.NewLine));
            MessageBox.Show("Exportacion Exitosa! revisa tu ruta: " + ruta + "/Log.txt");
        }
        private string AsignaRuta()
        {
            string ruta = "";
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                ruta = folder.SelectedPath;
            }
            return ruta;
        }

        private void FrmJson_Load(object sender, EventArgs e)
        {

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            string ContenidoJson = "";

            if (txtRutaJson.Text != "")
            {
                string rutaArchivo = txtRutaJson.Text;
                string line = null;

                using (StreamReader file = new StreamReader(rutaArchivo))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        ContenidoJson = line;
                    }
                }
            }
            else
            {
                ContenidoJson = rtb_Log.Text;
            }
          

            try
            {
                dynamic jsonObject = JsonConvert.DeserializeObject(ContenidoJson);
                // Serializar el objeto dinámico con formato indentado
                string formattedJson = JsonConvert.SerializeObject(jsonObject, Newtonsoft.Json.Formatting.Indented);
                // Imprimir el JSON formateado
                rtb_Log.Text = formattedJson;
            }
            catch
            {
                MessageBox.Show("Error, asegurate de seleccionar un Json válido!");
            }
        }

        private void btnBorrarLog_Click(object sender, EventArgs e)
        {
            rtb_Log.Clear();
        }

        private void btnBorrarLog_Click_1(object sender, EventArgs e)
        {
            rtb_Log.Clear();

        }
    }
}
