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

                string rutaEjemplosProcesados = ConfigurationManager.AppSettings["RutaEjemplosProcesados"];
                txtRutaProcesados.Text = rutaEjemplosProcesados;
                if (!Directory.Exists(rutaEjemplosProcesados))
                {
                    Directory.CreateDirectory(rutaEjemplosProcesados);
                }  

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
                                {
                                    chk_LogHora.Checked = true;
                                }
                                else
                                {
                                    chk_LogHora.Checked = false;
                                }
                            }
                            else if (clave == "RutaEjemplos")
                            {
                                txt_RutaEjemplos.Text = valor;
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
                config.AppSettings.Settings["RutaEjemplosProcesados"].Value = txtRutaProcesados.Text;
                config.AppSettings.Settings["RutaCertificado"].Value = txtRutaCertificado.Text;
                config.AppSettings.Settings["ClaveCertificado"].Value = txtClaveCertificado.Text;
                config.Save(ConfigurationSaveMode.Modified);
                MessageBox.Show("Actualizacion Exitosa!");
                LeerConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.ToString());
            }
            DialogResult result;
            result = MessageBox.Show("Los cambios se harán notables al reiniciar el programa. ¿Desea reiniciarlo ahora?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Restart();            //CargaParametros();
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
            FolderBrowserDialog dlCarpeta = new FolderBrowserDialog();
            dlCarpeta.RootFolder = System.Environment.SpecialFolder.Desktop;
            dlCarpeta.ShowNewFolderButton = false;
            dlCarpeta.Description = "Selecciona la carpeta";
            string rutaDestino = "";
            //(int Codigo, string Mensaje, string Documento) resp2;
            if (dlCarpeta.ShowDialog() == DialogResult.OK)
            {
                txtRutaCertificado.Text = dlCarpeta.SelectedPath + @"\";
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
    }
}
