using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools
{
    public partial class FrmConfigOtros : Form
    {
        static public Color ColorBotones;
        static public Color ColorFondo;
        static public Color ColorTXT;
        static public Color ColorLetras;
        public FrmConfigOtros()
        {
            InitializeComponent();
        }

        private void InicializarColores()
        {
            //tlpForm.BackColor = ColorFondo;
            btnGuardar.BackColor = ColorBotones;
            tlpForm.ForeColor = ColorLetras;

            foreach (Control cComponente in tlpForm.Controls)
            {
                if (cComponente is TextBox)
                {
                    cComponente.BackColor = ColorTXT;
                }
            }
            foreach (Control cComponente in tlp1.Controls)
            {
                if (cComponente is TextBox)
                {
                    cComponente.BackColor = ColorTXT;
                }
            }
            foreach (Control cComponente in tlp2.Controls)
            {
                if (cComponente is TextBox)
                {
                    cComponente.BackColor = ColorTXT;
                }
            }
            foreach (Control cComponente in tlp3.Controls)
            {
                if (cComponente is TextBox)
                {
                    cComponente.BackColor = ColorTXT;
                }
            }
        }

        private void FrmConfigOtros_Load(object sender, EventArgs e)
        {
            InicializarColores();
            LeerConfig();
            leerConfigPersonal();

        }

        private void LeerConfig()
        {
            try
            {
                string rutaCert = ConfigurationManager.AppSettings["RutaCertificado"];
                string claveCert = ConfigurationManager.AppSettings["ClaveCertificado"];
                txtRutaCertificado.Text = rutaCert;
                txtClaveCertificado.Text = claveCert;   
            }
            catch (Exception e)
            {

            }
        }

        private void leerConfigPersonal()
        {
            try
            {
                string FileToRead = @"C:\ConfigTool\Config.txt";

                if (File.Exists(FileToRead))
                {
                    string[] lines = File.ReadAllLines(FileToRead);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (!lines[i].StartsWith("<") && !lines[i].Equals(""))
                        {
                            string lineaYa = lines[i];
                            string clave = lines[i].Split('=')[0];
                            string valor = lines[i].Split('=')[1];
                            if (clave == "Token")
                            {
                                txt_TokenConfig.Text = valor;
                            }
                            else if (clave == "LogHora")
                            {
                                if (valor == "SI")
                                    chckFechaHora.Checked = true;
                                else                               
                                    chckFechaHora.Checked = false;                               
                            }
                            else if (clave == "RutaEjemplos")
                            {
                                txt_RutaEjemplos.Text = valor;
                            }
                            else if (clave == "RutaProcesados")
                            {
                                txtRutaProcesados.Text = valor;
                                if (!Directory.Exists(valor))
                                {
                                    Directory.CreateDirectory(valor);
                                }
                            }
                            else if (clave == "RutaDrive")
                            {
                                txtRutaDrive.Text = valor;
                                //if (!Directory.Exists(valor))
                                //{
                                //    Directory.CreateDirectory(valor);
                                //}
                            }
                            else if (clave == "RutaZip")
                            {
                                txtRutaZip.Text = valor;
                                if (!Directory.Exists(valor))
                                {
                                    Directory.CreateDirectory(valor);
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor crea tu archivo de configuracion en: " + FileToRead);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["RutaCertificado"].Value = txtRutaCertificado.Text;
                config.AppSettings.Settings["ClaveCertificado"].Value = txtClaveCertificado.Text;
                config.Save(ConfigurationSaveMode.Modified);

                string line = null, comparacion = "";
                List<String> listLineas = new List<string>();
                string dataTxt = "";
                using (StreamReader file = new StreamReader(@"C:\ConfigTool\Config.txt"))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        string line2 = line.Split('=')[0];
                        if (line2.Equals("Token"))
                        {
                            line = "Token=" + txt_TokenConfig.Text;
                        }
                        else if (line2.Equals("LogHora"))
                        {
                            string valor;
                            if (chckFechaHora.Checked)
                                valor = "SI";
                            else
                                valor = "NO";
                            line = "LogHora=" + valor;
                        }
                        else if (line2.Equals("RutaEjemplos"))
                        {
                            line = "RutaEjemplos=" + txt_RutaEjemplos.Text;
                        }
                        else if (line2.Equals("RutaProcesados"))
                        {
                            line = "RutaProcesados=" + txtRutaProcesados.Text;
                        }
                        else if (line2.Equals("RutaDrive"))
                        {
                            line = "RutaDrive=" + txtRutaDrive.Text;
                        }
                        else if (line2.Equals("RutaZip"))
                        {
                            line = "RutaZip=" + txtRutaZip.Text;
                        }
                        listLineas.Add(line);
                    }
                    for (int t = 0; t < listLineas.ToArray().Length; t++)//Envio 1x1 de documentos ubicados en ruta TXTUbicacion
                    {
                        dataTxt += listLineas.ToArray()[t] + Environment.NewLine;
                    }
                }
                System.IO.File.WriteAllText(@"C:\ConfigTool\Config.txt", dataTxt);
                MessageBox.Show("Actualización Exitosa!");
                LeerConfig();
                leerConfigPersonal();
                DialogResult result;
                result = MessageBox.Show("Los cambios se harán notables al reiniciar el programa. ¿Desea reiniciarlo ahora?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    Application.Restart();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.ToString());
            }
                 

        }

        private void btnBuscarRutaProcesados_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlCarpeta = new FolderBrowserDialog();
            dlCarpeta.RootFolder = System.Environment.SpecialFolder.Desktop;
            dlCarpeta.ShowNewFolderButton = false;
            dlCarpeta.Description = "Selecciona la carpeta";
            string rutaDestino = "";
            //(int Codigo, string Mensaje, string Documento) resp2;
            if (dlCarpeta.ShowDialog() == DialogResult.OK)
            {
                txtRutaProcesados.Text = dlCarpeta.SelectedPath + @"\";
            }
        }

        private void btnRutaCertificado_Click(object sender, EventArgs e)
        {
            OpenFileDialog fichero = new OpenFileDialog();
            fichero.Multiselect = false;
            //fichero.Filter = "Text (*.txt)|*.TXT|XML (*.xml)|*.XML|ZIP (*.zip)|*.ZIP";
            fichero.Filter = "CERTIFICADO (*.pfx)|*.PFX";
            //open.Filter = "ZIP files (*.zip)|*.zip";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                txtClaveCertificado.Text = fichero.FileName;
            }
        }

        private void btnBuscarRutaEjemplos_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlCarpeta = new FolderBrowserDialog();
            dlCarpeta.RootFolder = System.Environment.SpecialFolder.Desktop;
            dlCarpeta.ShowNewFolderButton = false;
            dlCarpeta.Description = "Selecciona la carpeta";
            string rutaDestino = "";
            //(int Codigo, string Mensaje, string Documento) resp2;
            if (dlCarpeta.ShowDialog() == DialogResult.OK)
            {
                txt_RutaEjemplos.Text = dlCarpeta.SelectedPath + @"\";
            }
        }

        private void btnRutaZip_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlCarpeta = new FolderBrowserDialog();
            dlCarpeta.RootFolder = System.Environment.SpecialFolder.Desktop;
            dlCarpeta.ShowNewFolderButton = false;
            dlCarpeta.Description = "Selecciona la carpeta";
            string rutaDestino = "";
            //(int Codigo, string Mensaje, string Documento) resp2;
            if (dlCarpeta.ShowDialog() == DialogResult.OK)
            {
                txtRutaZip.Text = dlCarpeta.SelectedPath + @"\";
            }
        }

        private void btnRutaDrive_Click(object sender, EventArgs e)
        {
            OpenFileDialog fichero = new OpenFileDialog();
            fichero.Multiselect = false;
            //fichero.Filter = "Text (*.txt)|*.TXT|XML (*.xml)|*.XML|ZIP (*.zip)|*.ZIP";
            fichero.Filter = "EXE (*.exe)|*.EXE";
            //open.Filter = "ZIP files (*.zip)|*.zip";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                txtRutaDrive.Text = fichero.FileName;
            }
        }
    }
}
