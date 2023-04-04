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
    public partial class FrmConfigBD : Form
    {
        static public Color ColorBotones;
        static public Color ColorFondo;
        static public Color ColorTXT;
        static public Color ColorLetras;

        public FrmConfigBD()
        {
            InitializeComponent();
        }

        private void InicializarColores()
        {
            //tlpForm.BackColor = ColorFondo;
            btnGuardar.BackColor = ColorBotones;
            gbOSE.ForeColor = ColorLetras;
            gbPSE20.ForeColor = ColorLetras;
            gbPSE21.ForeColor = ColorLetras;

            foreach (Control cComponente in tlpPSE21.Controls)
            {
                if (cComponente is TextBox)
                {
                    cComponente.BackColor = ColorTXT;
                }
            }
            foreach (Control cComponente in tlpPSE20.Controls)
            {
                if (cComponente is TextBox)
                {
                    cComponente.BackColor = ColorTXT;
                }
            }
            foreach (Control cComponente in tlpOSE.Controls)
            {
                if (cComponente is TextBox)
                {
                    cComponente.BackColor = ColorTXT;
                }
            }
        }

        private void FrmConfigBD_Load(object sender, EventArgs e)
        {
            InicializarColores();
            leerConfigPersonal();
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
                                //txt_TokenConfig.Text = valor;
                                //txt_Token.Text = valor;
                            }
                            else if (clave == "LogHora")
                            {
                                //if (valor == "SI")
                                //{
                                //    LogFechaHora = true;
                                //    chk_LogHora.Checked = true;
                                //}
                                //else
                                //{
                                //    LogFechaHora = false;
                                //    chk_LogHora.Checked = false;
                                //}
                            }
                            else if (clave == "RutaEjemplos")
                            {
                                //txt_RutaEjemplos.Text = valor;
                            }
                            else if (clave == "HostBdPse")
                            {
                                txt_HostDPSE.Text = valor;
                            }
                            else if (clave == "PuertoBdPse")
                            {
                                txt_PortDPSE.Text = valor;
                            }
                            else if (clave == "UsuarioBdPse")
                            {
                                txt_UserDPSE.Text = valor;
                            }
                            else if (clave == "ClaveBdPse")
                            {
                                txt_PassDPSE.Text = valor;
                            }
                            else if (clave == "HostBdPse20")
                            {
                                txt_HostPse20.Text = valor;
                            }
                            else if (clave == "PuertoBdPse20")
                            {
                                txt_PortPse20.Text = valor;
                            }
                            else if (clave == "UsuarioBdPse20")
                            {
                                txt_UserPse20.Text = valor;
                            }
                            else if (clave == "ClaveBdPse20")
                            {
                                txt_PassPse20.Text = valor;
                            }
                            else if (clave == "HostBdOse")
                            {
                                txt_HostBdOse.Text = valor;
                            }
                            else if (clave == "PuertoBdOse")
                            {
                                txt_PortBdOse.Text = valor;
                            }
                            else if (clave == "UsuarioBdOse")
                            {
                                txt_UserBdOse.Text = valor;
                            }
                            else if (clave == "ClaveBdOse")
                            {
                                txt_PassBdOse.Text = valor;
                            }
                            else if (clave == "Tema")
                            {
                                //cmbt.Text = valor;
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
                //Base de datos
                config.AppSettings.Settings["HostBdPse"].Value = txt_HostDPSE.Text;
                config.AppSettings.Settings["PuertoBdPse"].Value = txt_PortDPSE.Text;
                config.AppSettings.Settings["UsuarioBdPse"].Value = txt_UserDPSE.Text;
                config.AppSettings.Settings["ClaveBdPse"].Value = txt_PassDPSE.Text;

                config.AppSettings.Settings["HostBdPse20"].Value = txt_HostPse20.Text;
                config.AppSettings.Settings["PuertoBdPse20"].Value = txt_PortPse20.Text;
                config.AppSettings.Settings["UsuarioBdPse20"].Value = txt_UserPse20.Text;
                config.AppSettings.Settings["ClaveBdPse20"].Value = txt_PassPse20.Text;

                config.AppSettings.Settings["HostBdOse"].Value = txt_HostBdOse.Text;
                config.AppSettings.Settings["PuertoBdOse"].Value = txt_PortBdOse.Text;
                config.AppSettings.Settings["UsuarioBdOse"].Value = txt_UserBdOse.Text;
                config.AppSettings.Settings["ClaveBdOse"].Value = txt_PassBdOse.Text;
                //Base de datos

                config.Save(ConfigurationSaveMode.Modified);
                MessageBox.Show("Actualizacion Exitosa!");
                leerConfigPersonal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.ToString());
            }
            leerConfigPersonal();
            DialogResult result;
            result = MessageBox.Show("Los cambios se harán notables al reiniciar el programa. ¿Desea reiniciarlo ahora?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Restart();
        }
    }
}
