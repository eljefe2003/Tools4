using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Xml;

namespace Tools
{
    public partial class FrmFirmaXml : Form
    {       

        public FrmFirmaXml(Color color1, Color color2, Color color3, Color color4)
        {
            InitializeComponent();
            tlpLog.BackColor = color1;
            rtbJson.BackColor = color1;
            rtbJson.ForeColor = color2;
            lbl_Log.ForeColor = color2;
            btnBorrarLog.BackColor = color1;
            btnBuscarXml.BackColor = color1;
            btnGuardarLog.BackColor = color1;
            btnCopiarLog.BackColor = color1;
            btnPlay.BackColor = color1;

        }

        private void FrmFirmaXml_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscarXml_Click(object sender, EventArgs e)
        {
            rtbJson.Clear();
            OpenFileDialog fichero = new OpenFileDialog();
            fichero.Multiselect = false;
            //fichero.Filter = "Text (*.txt)|*.TXT|XML (*.xml)|*.XML|ZIP (*.zip)|*.ZIP";
            fichero.Filter = "Xml (*.xml)|*.XML";
            string ContenidoJson = "";

            //open.Filter = "ZIP files (*.zip)|*.zip";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                txtRutaXml.Text = fichero.FileName;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                // Ruta del archivo XML
                string filePath = txtRutaXml.Text;

                // Cargar el archivo XML
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);

                // Obtener el nodo "X509Certificate"
                //XmlNode x509CertNode = xmlDoc.SelectSingleNode("cbc:UBLVersionID");
                XmlNodeList nodoResponse2 = null;
                nodoResponse2 = xmlDoc.GetElementsByTagName("X509Certificate");

                if (nodoResponse2 != null)
                {
                    // Obtener el valor del nodo "X509Certificate"
                    string x509CertValue = nodoResponse2[0].InnerText;

                    // Crear un objeto X509Certificate2 a partir del valor
                    X509Certificate2 cert = new X509Certificate2(Convert.FromBase64String(x509CertValue));

                    // Obtener la fecha de inicio de vigencia de la firma digital
                    DateTime startDate = cert.NotBefore;

                    // Obtener la fecha de finalización de vigencia de la firma digital
                    DateTime endDate = cert.NotAfter;

                    //Console.WriteLine("Datos de vigencia de la firma digital:");
                    //Console.WriteLine("Fecha de inicio: " + startDate.ToString());
                    //Console.WriteLine("Fecha de finalización: " + endDate.ToString());

                    // Imprimir los datos del certificado
                    rtbJson.AppendText("Documento: " + Path.GetFileName(filePath) + Environment.NewLine);
                    rtbJson.AppendText("Datos varios firma: " + cert.SubjectName.Name.ToString() + Environment.NewLine);
                    rtbJson.AppendText("Firma válida desde: " + startDate.ToString() + Environment.NewLine);
                    rtbJson.AppendText("Firma válida hasta: " + endDate.ToString() + Environment.NewLine);
                    rtbJson.AppendText("Serial del cert. usado: " + cert.SerialNumber.ToString() + Environment.NewLine);

                }
                else
                {
                    MessageBox.Show("No se encontró el nodo X509Certificate en el archivo XML.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }
}
