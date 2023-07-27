using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools
{
    public partial class FrmToolDaily : Form
    {
           
        public FrmToolDaily(Color color1, Color color2, Color color3, Color color4)
        {
            InitializeComponent();
            tlpForm.BackColor = Color.White;
            btnProcesar.BackColor = color1;
            btnDetalle.IconColor = color1;
            //tlpLog.BackColor = color1;
            //rtb_Log.BackColor = color1;
            gbFiltros.ForeColor = color1;
            lblFormato.ForeColor = color1;
            //rtb_Log.ForeColor = color2;
            //lbl_Log.ForeColor = color2;
            tlpDetalle.ForeColor = color1;
            txtDetalle.ForeColor = color1;
            rtbDaily.BackColor = color2;
        }

        private bool validaCampos()
        {
            int errores = 0;
            string Mensaje = "";
            if (txtRuc.Text.Length != 11)
            {
                errores++;
                Mensaje += "El ruc debe poseer 11 caracteres" + Environment.NewLine;
            }
            if (!Regex.IsMatch(txtRuc.Text, @"^[0-9]+$"))
            {
                errores++;
                Mensaje += "El ruc debe ser numérico." + Environment.NewLine;
            }

            if (txtToken.Text == "")
            {
                errores++;
                Mensaje += "¡Debes digitar tu Token!" + Environment.NewLine;
            }

            if (txtMantis.Text.Length != 7)
            {
                errores++;
                Mensaje += "El número de mantis debe comenzar con 00 y debe poseer 7 caracteres en total" + Environment.NewLine;
            }
            if (!Regex.IsMatch(txtMantis.Text, @"^[0-9]+$"))
            {
                errores++;
                Mensaje += "El valor del número mantis debe ser numérico." + Environment.NewLine;
            }

            if (rtbDaily.Text == "")
            {
                errores++;
                Mensaje += "¡Debes añadir al menos 1 registro a procesar!" + Environment.NewLine;
            }



            if (errores > 0)
            {
                MessageBox.Show(Mensaje, "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (validaCampos())
            {
                if (cmbMetodo.Text == "BajasCancelado")
                {
                    Bajas();
                }
                else if (cmbMetodo.Text == "Desactivar")
                {
                    Desactivar();
                }
                else if (cmbMetodo.Text == "EliminarPDF")
                {
                    EliminarPDF();
                }
                else if (cmbMetodo.Text == "OSE-Desactivar")
                {
                    DesactivarOSE();
                }
            }

        }

        private void SpeechBaja()
        {
            string Cabecera = "Speech para correo:" + Environment.NewLine + Environment.NewLine
                       + "Estimado cliente, luego de validar que el/los documento(s) esta(n) efectivamente anulado(S) ante SUNAT: " + Environment.NewLine;
            string Lineas = "";
            string Final = "Saludos." + Environment.NewLine + Environment.NewLine;

            for (int i = 0; i < rtbDaily.Lines.Count(); i++)
            {
                string baja = rtbDaily.Lines[i].Split('|')[1];
                string numeracion = rtbDaily.Lines[i].Split('|')[2];

                Lineas += "La baja: " +
                    baja + " fue actualizada como 'Aceptada' y su documento afectado " +
                    numeracion + " como 'Anulado'." + Environment.NewLine;
            }              
            rtb_Log.AppendText(Cabecera + Lineas + Final);
        }

        private void Speech(bool DesactivarPSE)
        {
            if (DesactivarPSE)
            {
                string Cabecera = "Speech para correo:" + Environment.NewLine + Environment.NewLine
                      + "Estimado cliente, se ha(n) desactivado y pueden procesar nuevamente el/los documento(s): " + Environment.NewLine;
                string Lineas = "";
                string Final = "Saludos." + Environment.NewLine + Environment.NewLine;

                for (int i = 0; i < rtbDaily.Lines.Count(); i++)
                {
                    string numeracion = rtbDaily.Lines[i].Split('|')[0];
                    Lineas += numeracion + Environment.NewLine;
                }
                rtb_Log.AppendText(Cabecera + Lineas + Final);
            }
            else
            {
                string Cabecera = "Speech para correo:" + Environment.NewLine + Environment.NewLine
                     + "Estimado cliente, se ha(n) desactivado y pueden proceder a enviarlo nuevamente a nuestra OSE, de preferencia con nuevo identificador.: " + Environment.NewLine;
                string Lineas = "";
                string Final = "Saludos." + Environment.NewLine + Environment.NewLine;

                for (int i = 0; i < rtbDaily.Lines.Count(); i++)
                {
                    string numeracion = rtbDaily.Lines[i].Split('|')[2];
                    Lineas += numeracion + Environment.NewLine;
                }
                rtb_Log.AppendText(Cabecera + Lineas + Final);
            }
        }

        private void Bajas()
        {
            rtb_Log.AppendText("___________________________________" + Environment.NewLine);
            Faby4.AppToolsClient ToolFaby = new Faby4.AppToolsClient();
            var recorrer = leerArchivoDaily();
            //MessageBox.Show("Espera mientras se procesa tu petición, esto puede demorar unos minutos!");
            for (int i = 0; i < recorrer.Length; i++)
            {
                try
                {
                    string[] campo;
                    campo = recorrer[i].Split('|');
                    string ruc = campo[0];
                    string numeracion = campo[1] + "|" + campo[2];
                    string metodo = cmbMetodo.Text;

                    var resp = ToolFaby.dailyTasks21(txtToken.Text, ruc, numeracion, "","Mantis-" + txtMantis.Text, metodo, null);
                    //MessageBox.Show(resp.errorMessage);
                    Log("¡Petición procesada con Éxito!", true, true);
                    Log(resp.errorMessage + " " + campo[1] + "|" + campo[2], true, true);                   
                }
                catch (Exception e)
                {
                    Log(e.Message, false, true);
                }
            }
            if (chckSpeech.IsOn)
            {
                SpeechBaja();
            }
            rtb_Log.AppendText("___________________________________" + Environment.NewLine);
            //MessageBox.Show("Peticion completada! Revisa el Log");
        }

        private void Desactivar()
        {
            rtb_Log.AppendText("___________________________________" + Environment.NewLine);
            Faby4.AppToolsClient ToolFaby = new Faby4.AppToolsClient();
            var recorrer = leerArchivoDaily();
            //MessageBox.Show("Espera mientras se procesa tu petición, esto puede demorar unos minutos!");
            for (int i = 0; i < recorrer.Length; i++)
            {
                try
                {
                    string[] campo;
                    campo = recorrer[i].Split('|');

                    string ruc = txtRuc.Text;
                    string numeracion = campo[0];
                    string fecha = campo[1];
                    string metodo = cmbMetodo.Text;

                    var resp = ToolFaby.dailyTasks21(txtToken.Text, ruc, ruc + "-" + numeracion, fecha, "Mantis-" + txtMantis.Text, metodo, null);
                    Log("¡Petición procesada con Éxito!", true, true);
                    //MessageBox.Show(resp.errorMessage);
                    Log(resp.errorCode + "|" + resp.errorMessage, true, true);                   
                }
                catch (Exception e)
                {
                    Log(e.Message, false, true);
                }
                if (chckSpeech.IsOn)
                {
                    Speech(true);
                }
            }
            rtb_Log.AppendText("___________________________________" + Environment.NewLine);
        }

        private void EliminarPDF()
        {
            rtb_Log.AppendText("___________________________________" + Environment.NewLine);
            Faby4.AppToolsClient appToolsClient = new Faby4.AppToolsClient();
            //ToolFaby2.AppToolsClient ToolFabt2 = new ToolFaby2.AppToolsClient();
            //Faby3.AppTools ToolFaby = new Faby3.AppTools();
            var recorrer = leerArchivoDaily();
            //MessageBox.Show("Espera mientras se procesa tu petición, esto puede demorar unos minutos!");
            for (int i = 0; i < recorrer.Length; i++)
            {
                try
                {
                    string[] campo;
                    campo = recorrer[i].Split('|');

                    string ruc = txtRuc.Text;
                    string numeracion = campo[0];
                    string fecha = campo[1];
                    string metodo = cmbMetodo.Text;

                    var resp = appToolsClient.dailyTasks21(txtToken.Text, ruc, ruc + "-" + numeracion, fecha, "Mantis-" + txtMantis.Text, metodo, null);
                    //MessageBox.Show(resp.errorMessage);
                    Log("¡Petición procesada con Éxito!", true, true);
                    Log(resp.errorCode + "|" + resp.errorMessage, true, true);
                    if (chckSpeech.IsOn)
                    {
                        //string speech = "Speech para correo:" + Environment.NewLine
                        //+ "--------------------------------------" + Environment.NewLine + Environment.NewLine
                        //+ "Estimado cliente, se ha desactivado el documento: " + numeracion.ToString() + ", pueden proceder a procesar dicho documento nuevamente." + Environment.NewLine
                        //+ "Saludos." + Environment.NewLine + Environment.NewLine
                        //+ "--------------------------------------";
                        //rtb_Log.AppendText(speech);
                    }
                }
                catch (Exception e)
                {
                    Log(e.Message, false, true);
                }

            }
            rtb_Log.AppendText("___________________________________" + Environment.NewLine);
        }

        private void DesactivarOSE()
        {
            rtb_Log.AppendText("___________________________________" + Environment.NewLine);
            Faby4.AppToolsClient ToolFaby = new Faby4.AppToolsClient();
            var recorrer = leerArchivoDaily();
            //MessageBox.Show("Espera mientras se procesa tu petición, esto puede demorar unos minutos!");
            for (int i = 0; i < recorrer.Length; i++)
            {
                try
                {
                    string[] campo;
                    campo = recorrer[i].Split('|');
                    string supplier = campo[0];
                    string tipo = campo[1];
                    string identificador = campo[2];
                    string metodo = cmbMetodo.Text;

                    var resp = ToolFaby.dailyTasksOSE(txtToken.Text, "Mantis-" + txtMantis.Text, metodo.Split('-')[1], txtRuc.Text, supplier, tipo, identificador);
                    //MessageBox.Show(resp.errorMessage);
                    Log("¡Petición procesada con Éxito!", true, true);
                    Log(resp.errorMessage + " " + campo[1] + "|" + campo[2], true, true);                   
                }
                catch (Exception e)
                {
                    Log(e.Message, false, true);
                }              
            }
            if (chckSpeech.IsOn)
            {
                Speech(false);
            }
            rtb_Log.AppendText("___________________________________" + Environment.NewLine);
        }

        private string[] leerArchivoDaily()
        {
            try
            {
                List<string> lectura;
                string[] arrayOfLectura;
                lectura = new List<string>();
                foreach (var linea in rtbDaily.Lines)
                {
                    lectura.Add(linea);
                    //Principal p = new Principal();
                    //p.setDataLblFormActual("amor");
                }
                arrayOfLectura = lectura.ToArray();
                return arrayOfLectura;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private void cmbMetodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMetodo.Text == "Desactivar")
            {
                string mensaje = "Formato: Tipo-documento|IssueDate (YYYY-MM-DD)" + Environment.NewLine 
                + "Ejemplo:" + Environment.NewLine + Environment.NewLine
                + "01-F001-1234|2021-05-30" + Environment.NewLine
                + "01-F001-1234|2021-05-30" + Environment.NewLine
                + "..." + Environment.NewLine;
                lblFormato.Text = mensaje;
            }
            else if (cmbMetodo.Text == "BajasCancelado")
            {
                string mensaje = "Formato: Ruc|RA|Tipo-Serie-Correlativo" + Environment.NewLine
              + "Ejemplo:" + Environment.NewLine + Environment.NewLine
              + "20000000000|RA-20220110-1|01-F001-1234" + Environment.NewLine
              + "20000000000|RA-20220110-2|01-F002-1234" + Environment.NewLine
              + "..." + Environment.NewLine;
                lblFormato.Text = mensaje;
            }
            else if (cmbMetodo.Text == "EliminarPDF")
            {
                string mensaje = "Formato: Tipo-documento|IssueDate (YYYY-MM-DD)" + Environment.NewLine
              + "Ejemplo:" + Environment.NewLine + Environment.NewLine
              + "01-F001-1234|2021-05-30" + Environment.NewLine
              + "01-F001-1234|2021-05-30" + Environment.NewLine
              + "..." + Environment.NewLine;
                lblFormato.Text = mensaje;
            }
            else if(cmbMetodo.Text == "OSE-Desactivar")
            {
                string mensaje = "Formato: SupplierRuc|TipoDocumento|Identificador" + Environment.NewLine
              + "Ejemplo:" + Environment.NewLine + Environment.NewLine
              + "20000000000|RA|RA-20220412-1" + Environment.NewLine
              + "20000000000|RC|RC-20220412-2" + Environment.NewLine
              + "..." + Environment.NewLine;
                lblFormato.Text = mensaje;
            }
        }

        public void Log(string msg, bool msj, bool fecha)
        {
            if (fecha)
            {
                if (msj)
                {
                    this.rtb_Log.SelectionStart = this.rtb_Log.Text.Length;
                    //rtb_Log.SelectionColor = Color.Black;
                    rtb_Log.AppendText("[" + DateTime.Now.Day.ToString("d2") + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Year + " " +
                    DateTime.Now.Hour.ToString("d2") + ":" + DateTime.Now.Minute.ToString("d2") + ":" + DateTime.Now.Second.ToString("d2") + "] " + msg + Environment.NewLine);
                }
                else
                {
                    this.rtb_Log.SelectionStart = this.rtb_Log.Text.Length;
                    rtb_Log.SelectionColor = Color.FromArgb(204, 0, 56);
                    //rtb_Log.SelectionColor = Color.Black;
                    rtb_Log.AppendText("[" + DateTime.Now.Day.ToString("d2") + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Year + " " +
                    DateTime.Now.Hour.ToString("d2") + ":" + DateTime.Now.Minute.ToString("d2") + ":" + DateTime.Now.Second.ToString("d2") + "] " + msg + Environment.NewLine);
                    //msj = true;
                }
                this.rtb_Log.ScrollToCaret();
            }
            else
            {
                if (msj)
                {
                    this.rtb_Log.SelectionStart = this.rtb_Log.Text.Length;
                    //rtb_Log.SelectionColor = Color.Black;
                    rtb_Log.AppendText(msg + Environment.NewLine);
                }
                else
                {
                    this.rtb_Log.SelectionStart = this.rtb_Log.Text.Length;
                    rtb_Log.SelectionColor = Color.FromArgb(204, 0, 56);
                    rtb_Log.AppendText(msg + Environment.NewLine);
                    //msj = true;
                }
                this.rtb_Log.ScrollToCaret();
            }

        }

        private void FrmToolDaily_Load(object sender, EventArgs e)
        {
            leerConfigPersonal();
            cmbMetodo.SelectedIndex = 0;
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
                                txtToken.Text = valor;
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

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Process.Start(txtDetalle.Text);
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
