using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Tools
{
    public partial class FrmDescargas : Form
    {
        string[] arrayOfLectura;
        DLL_Online.Metodos.TheFactoryHKA DLL = new DLL_Online.Metodos.TheFactoryHKA();
     
        public FrmDescargas(Color color1, Color color2, Color color3, Color color4)
        {
            InitializeComponent();
            tlpForm.BackColor = Color.White;
            btnProcesar.BackColor = color1;
            btnQueryDescargas.BackColor = color1;
            //tlpLog.BackColor = color1;
            //rtb_Log.BackColor = color1;
            gbFiltros.ForeColor = color1;
            gbAmbiente.ForeColor = color1;
            //lblFormato.ForeColor = color1;
            //rtb_Log.ForeColor = color2;
            //lbl_Log.ForeColor = color2;         
            rtbDaily.BackColor = color2;
            lbl_Log.ForeColor = color1;
            btnBorrarLog.IconColor = color1;
            rtb_Log.ForeColor = color1;
            rtb_Log.ReadOnly = true;
        }
       

        private void slideButton1_Click(object sender, EventArgs e)
        {
            //if (chckDemo.IsOn)
            //{
            //    chckPRD.IsOn = false;
            //    LeerConfig();
            //    cambiaAmbiente("Demo");
            //}
            //else
            //{
            //    chckDemo.IsOn = false;
            //    chckPRD.IsOn = true;
            //    LeerConfig();
            //    cambiaAmbiente("Prd");
            //}
        }

        private void cambiaAmbiente(string ambiente)
        {

            string result = "";
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                string path = ".\\DLL_Online.dll.xml";
                if (File.Exists(path))
                {
                    xmlDoc.Load(path);
                }
                XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlDoc.NameTable);
                XmlNode nodo = xmlDoc.SelectSingleNode("Service", nsManager);
                if (nodo != null)
                {
                    XmlNode nodo2 = nodo.SelectSingleNode("Ambiente", nsManager);
                    if (nodo2 != null)
                    {
                        if(ambiente == "Demo")
                        {
                            nodo2.Attributes[0].Value = "http://demoint.thefactoryhka.com.pe/Service.svc";
                        }
                        else
                        {
                            nodo2.Attributes[0].Value = "http://int.thefactoryhka.com.pe/Service.svc";

                        }                      
                        xmlDoc.Save(path);                      
                    }
                }
            }
            catch (Exception ex) { result = ex.ToString(); }
        }

        private void FrmDescargas_Load(object sender, EventArgs e)
        {
            cambiaAmbiente("Prd");
            cmbTipo.SelectedIndex = 0;
            LeerConfig();
        }

        private void LeerConfig()
        {
            try
            {
                string ruc, clave, usuario;
                if (chckDemo.IsOn)
                {
                    ruc = ConfigurationManager.AppSettings["Ruc"];
                    usuario = ConfigurationManager.AppSettings["Usuario"];
                    clave = ConfigurationManager.AppSettings["Clave"];
                }
                else
                {
                    ruc = ConfigurationManager.AppSettings["RucPRD"];
                    usuario = ConfigurationManager.AppSettings["UsuarioPRD"];
                    clave = ConfigurationManager.AppSettings["ClavePRD"];
                }

                txtRuc.Text = ruc;
                txtUsuario.Text = usuario;
                txtClave.Text = clave;

            }
            catch (Exception e)
            {

            }
        }

        private void chckPRD_Click(object sender, EventArgs e)
        {
            //if (chckPRD.IsOn)
            //{
            //    chckDemo.IsOn = false;
            //    LeerConfig();
            //}
            //else
            //{
            //    chckPRD.IsOn = false;
            //    chckDemo.IsOn = true;
            //    LeerConfig();
            //}
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (validaCampos())
            {
                Descargas();
            }
        }

        private string[] leerArchivoDescargas()
        {
            try
            {
                List<string> lectura;
                lectura = new List<string>();
                foreach (var linea in rtbDaily.Lines)
                {
                    lectura.Add(linea);
                }
                arrayOfLectura = lectura.ToArray();
                return arrayOfLectura;
            }
            catch (Exception e)
            {
                return null;
            }
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


        private void Descargas()
        {
            CheckForIllegalCrossThreadCalls = false;
            var recorrer = leerArchivoDescargas();
            ProgressBar.Maximum = recorrer.Length;
            ProgressBar.Value = 0;
            ProgressBar.Step = 1;
            string rutaAsignada = AsignaRuta() + "\\";
            Log(Environment.NewLine + rutaAsignada, true, false);

            Log("Ruta a descargar en caso de éxito: " + rutaAsignada, true, false);
            for (int i = 0; i < recorrer.Length; i++)
            {
                string linea = recorrer[i];
                ProgressBar.PerformStep();
                if(cmbTipo.Text == "Todos")
                {
                    Task.Factory.StartNew(() => DescargaPDF(linea, rutaAsignada));
                    Task.Factory.StartNew(() => DescargaXML(linea, rutaAsignada));
                    Task.Factory.StartNew(() => DescargaCDR(linea, rutaAsignada));
                    Task.Factory.StartNew(() => DescargaJson(linea, rutaAsignada));

                }
                else
                {
                    if (cmbTipo.Text == "PDF")
                    {
                        Task.Factory.StartNew(() => DescargaPDF(linea, rutaAsignada));
                    }
                    else if (cmbTipo.Text == "XML")
                    {
                        Task.Factory.StartNew(() => DescargaXML(linea, rutaAsignada));
                    }
                    else if (cmbTipo.Text == "CDR")
                    {
                        Task.Factory.StartNew(() => DescargaCDR(linea, rutaAsignada));
                    }
                    else if (cmbTipo.Text == "JSON")
                    {
                        Task.Factory.StartNew(() => DescargaJson(linea, rutaAsignada));
                    }
                }              
                
            }
            MessageBox.Show("Peticion completada! Revisa el Log");
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
                    //rtb_Log.SelectionColor = Color.FromArgb(204, 0, 56);
                    rtb_Log.SelectionColor = Color.Red;
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
                    //rtb_Log.SelectionColor = Color.FromArgb(204, 0, 56);
                    rtb_Log.SelectionColor = Color.Red;
                    rtb_Log.AppendText(msg + Environment.NewLine);
                    //msj = true;
                }
                this.rtb_Log.ScrollToCaret();
            }

        }

        private void DescargaPDF(string linea, string rutaAsignada)
        {
            try
            {               

                DLL_Online.Metodos.Facturacion DLL2 = new DLL_Online.Metodos.Facturacion();
                if (DLL2.ValidaAcceso(txtRuc.Text, txtUsuario.Text, txtClave.Text))
                {
                    DLL = new DLL_Online.Metodos.TheFactoryHKA();
                    var resp = DLL.DescargaArchivo(txtRuc.Text, txtUsuario.Text, txtClave.Text, txtRuc.Text + "-" + linea, "PDF");
                    string extension = "pdf";
                    string ruta = rutaAsignada + linea + "." + extension;
                    if (resp.ArhivoBase64 != null)
                    {
                        byte[] data = System.Convert.FromBase64String(resp.ArhivoBase64);
                        File.WriteAllBytes(ruta, data);
                        Log(linea + " Descargado exitosamente su PDF", true, false);
                        //rtb_Log.AppendText(linea + " Descargado exitosamente su PDF" + Environment.NewLine + Environment.NewLine);
                    }
                    else
                    {
                        Log(linea + " No se encuentra su PDF", false, false);
                        //rtb_Log.AppendText(linea + " No se encuentra su PDF" + Environment.NewLine + Environment.NewLine);
                    }
                }
                else
                {
                    Log("Credenciales Incorrectas", false, false);
                    //rtb_Log.AppendText("Credenciales Incorrectas: " + Environment.NewLine + Environment.NewLine);
                }
              
            }
            catch (Exception e)
            {
                rtb_Log.AppendText(e.Message + " " + linea);
            }
        }

        private void DescargaXML(string linea, string rutaAsignada)
        {
            try
            {
                DLL_Online.Metodos.Facturacion DLL2 = new DLL_Online.Metodos.Facturacion();
                if (DLL2.ValidaAcceso(txtRuc.Text, txtUsuario.Text, txtClave.Text))
                {
                    DLL = new DLL_Online.Metodos.TheFactoryHKA();
                    var resp = DLL.DescargaArchivo(txtRuc.Text, txtUsuario.Text, txtClave.Text, txtRuc.Text + "-" + linea, "XML");
                    string extension = "xml";
                    string ruta = rutaAsignada + linea + "." + extension;
                    if (resp.ArhivoBase64 != null)
                    {
                        byte[] data = System.Convert.FromBase64String(resp.ArhivoBase64);
                        File.WriteAllBytes(ruta, data);
                        Log(linea + " Descargado exitosamente su XML", true, false);
                        //rtb_Log.AppendText(linea + " Descargado exitosamente su XML" + Environment.NewLine + Environment.NewLine);
                    }
                    else
                    {
                        Log(linea + " No se encuentra su XML", false, false);
                        //rtb_Log.AppendText(linea + " No se encuentra su XML" + Environment.NewLine + Environment.NewLine);
                    }
                }
                else
                {
                    Log("Credenciales Incorrectas", false, false);
                }
            }
            catch (Exception e)
            {
                rtb_Log.AppendText(e.Message + " " + linea);
            }
        }

        private void DescargaJson(string linea, string rutaAsignada)
        {
            try
            {
                DLL_Online.Metodos.Facturacion DLL2 = new DLL_Online.Metodos.Facturacion();
                if (DLL2.ValidaAcceso(txtRuc.Text, txtUsuario.Text, txtClave.Text))
                {
                    DLL = new DLL_Online.Metodos.TheFactoryHKA();
                    var resp = DLL.DescargaArchivo(txtRuc.Text, txtUsuario.Text, txtClave.Text, txtRuc.Text + "-" + linea, "JSON");
                    string extension = "json";
                    string ruta = rutaAsignada + linea + "." + extension;
                    if (resp.ArhivoBase64 != null)
                    {
                        byte[] data = System.Convert.FromBase64String(resp.ArhivoBase64);
                        File.WriteAllBytes(ruta, data);
                        Log(linea + " Descargado exitosamente su JSON", true, false);
                    }
                    else
                    {
                        Log(linea + " No se encuentra su JSON", false, false);
                    }
                }
                else
                {
                    Log("Credenciales Incorrectas", false, false);
                }
            }
            catch (Exception e)
            {
                rtb_Log.AppendText(e.Message + " " + linea);
            }
        }

        private void DescargaCDR(string linea, string rutaAsignada)
        {
            try
            {
                DLL_Online.Metodos.Facturacion DLL2 = new DLL_Online.Metodos.Facturacion();
                if (DLL2.ValidaAcceso(txtRuc.Text, txtUsuario.Text, txtClave.Text))
                {
                    DLL = new DLL_Online.Metodos.TheFactoryHKA();
                    var resp = DLL.DescargaArchivo(txtRuc.Text, txtUsuario.Text, txtClave.Text, txtRuc.Text + "-" + linea, "CDR");
                    string extension = "zip";
                    string ruta = rutaAsignada + linea + "." + extension;
                    if (resp.ArhivoBase64 != null)
                    {
                        byte[] data = System.Convert.FromBase64String(resp.ArhivoBase64);
                        File.WriteAllBytes(ruta, data);
                        Log(linea + " Descargado exitosamente su CDR", true, false);
                    }
                    else
                    {
                        Log(linea + " No se encuentra su CDR", false, false);
                    }
                }
                else
                {
                    Log("Credenciales Incorrectas", false, false);
                }
            }
            catch (Exception e)
            {
                rtb_Log.AppendText(e.Message + " " + linea);
            }
        }

        private void DescargaTodos(string linea, string rutaAsignada)
        {

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

            if (txtUsuario.Text == "")
            {
                errores++;
                Mensaje += "¡Debes digitar tu Usuario!" + Environment.NewLine;
            }

            if (txtClave.Text == "")
            {
                errores++;
                Mensaje += "¡Debes digitar tu Clave!" + Environment.NewLine;
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

        private void chckDemo_SliderValueChanged(object sender, EventArgs e)
        {
            LeerConfig();
            if (chckDemo.IsOn)
            {
                cambiaAmbiente("Demo");
            }
            else
            {
                cambiaAmbiente("Prd");
            }


            //if (chckPRD.IsOn)
            //{
            //    chckDemo.IsOn = false;
            //    LeerConfig();
            //}
            //else
            //{
            //    Thread.Sleep(1000);
            //    chckPRD.IsOn = false;
            //    chckDemo.IsOn = true;
            //    LeerConfig();
            //}
        }

        private void chckPRD_SliderValueChanged(object sender, EventArgs e)
        {
            //if (chckPRD.IsOn)
            //{
            //    chckDemo.IsOn = false;
            //    LeerConfig();
            //}
            //else
            //{
            //    Thread.Sleep(1000);
            //    chckPRD.IsOn = false;
            //    chckDemo.IsOn = true;
            //    LeerConfig();
            //}
        }

        private void lblFormato_Click(object sender, EventArgs e)
        {

        }

        private void btnQueryDescargas_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT CONCAT('01-', numeracion)" + Environment.NewLine +
                "FROM peprodpse.invoices" + Environment.NewLine +
                "WHERE ruc = xxxxxxxxxx" + Environment.NewLine +
                "AND numeracion in ('F001-1234')" + Environment.NewLine +
                "AND activo = 1" + Environment.NewLine +
                "AND status = 0" + Environment.NewLine +
                "AND DATE_FORMAT(fechaHoraEmision, '%Y-%m-%d') BETWEEN '2020-06-01' AND '2020-06-01'";
                Clipboard.SetDataObject(Query, true);
                MessageBox.Show("Texto copiado al portapapeles de Windows.",
                    "Copiado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show("Error al copiar texto al portapapeles: " +
                    Environment.NewLine + err.Message, "Error al copiar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
