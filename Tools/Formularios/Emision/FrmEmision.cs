using DLL_Online.Metodos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using System.Xml;
using Tools.Clases_varias;

namespace Tools
{
    public partial class FrmEmision : Form
    {
        LeerConfig ConfigGlobal = new LeerConfig();
        LeerConfigPersonal ConfigPerso = new LeerConfigPersonal();
        DLL_Online.Metodos.Dae_DinersClub DllG2 = new Dae_DinersClub();

        DLL_Online.Metodos.Facturacion DLL = new DLL_Online.Metodos.Facturacion();
        DLL_Online.Metodos.Request request = new DLL_Online.Metodos.Request();
        SunatBeta.billServiceClient sunat = new SunatBeta.billServiceClient();
        OseBeta.billServiceClient ose = new OseBeta.billServiceClient();

        bool aceptadoEdicionGlobal = false;
        string tipoNota = "", AmbienteGlobal = "", RutaArchivoEnviarGlobal = "";
        CancellationTokenSource source = new CancellationTokenSource();
        CancellationToken token;

        public FrmEmision()
        {
            InitializeComponent();
        }

        public FrmEmision(Color color1, Color color2, Color color3, Color color4)
        {
            InitializeComponent();

            tlpLog.BackColor = color1;
            rtb_Log.BackColor = color1;
            rtb_Log.ForeColor = color2;
            lbl_Log.ForeColor = color2;
            btnProbarCredenciales.BackColor = color1;
            btnProcesar.BackColor = color1;
            btnDescargar.BackColor = color1;
            btnProbarCredenciales.ForeColor = Color.White;
            btnProcesar.ForeColor = Color.White;
            btnDescargar.ForeColor = Color.White;


            //tlpForm.BackColor = Color.White;
            //rtbDaily.BackColor = color2;
            //gbFiltros.ForeColor = color1;
            //lblFormato.ForeColor = color1;
            //rtb_Log.ForeColor = color2;
            //lbl_Log.ForeColor = color2;
            //tlpLog.BackColor = color1;
            //rtb_Log.BackColor = color1;
        }

        private void FrmEmision_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            CargarParametros();
        }

        private void chckDemo_Click(object sender, EventArgs e)
        {
            string result = "";
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                string path = ".\\DLL_Online.dll.xml";
                if (System.IO.File.Exists(path))
                {
                    xmlDoc.Load(path);
                }
                XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlDoc.NameTable);
                //nsManager.AddNamespace(prefix, uri);
                XmlNode nodo = xmlDoc.SelectSingleNode("Service", nsManager);
                if (nodo != null)
                {
                    XmlNode nodo2 = nodo.SelectSingleNode("Ambiente", nsManager);
                    if (nodo2 != null)
                    {
                        if (chckDemo.IsOn)
                        {
                            nodo2.Attributes[0].Value = "http://demoint.thefactoryhka.com.pe/Service.svc";
                        }
                        else
                        {
                            nodo2.Attributes[0].Value = "http://int.thefactoryhka.com.pe/Service.svc";
                        }
                        xmlDoc.Save(path);
                        LeerDll();
                    }
                }
            }
            catch (Exception ex) { result = ex.ToString(); }
            ConfigGlobal = new LeerConfig();
            CargarParametros();
        }

        private string LeerDll()
        {
            string Ambiente = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(".\\DLL_Online.dll.xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                String id = node.Attributes["service"].Value;
                if (id.IndexOf("demo") > 0)
                {
                    Ambiente = "DEMO";
                    chckDemo.IsOn = true;
                }
                else
                {
                    Ambiente = "PRD";
                    chckDemo.IsOn = false;
                }

            }
            return Ambiente;
        }

        private void CargarParametros()
        {
            if(cmb_TipoEmision.Text == "SUNAT" || cmb_TipoEmision.Text == "SUNAT (PARA FIRMAR)")
            {
                txt_RucEmision.Text = ConfigGlobal.RucSunatDemo;
                txt_UsuarioEmision.Text = ConfigGlobal.UsuarioSunatDemo;
                txt_ClaveEmision.Text = ConfigGlobal.ClaveSunatDemo;
            }else if (cmb_TipoEmision.Text == "OSE")
            {
                txt_RucEmision.Text = ConfigGlobal.RucOSEDemo;
                txt_UsuarioEmision.Text = ConfigGlobal.UsuarioOSEDemo;
                txt_ClaveEmision.Text = ConfigGlobal.ClaveOSEDemo;
            }
            else
            {
                txt_RucEmision.Text = ConfigGlobal.RucSunatPrd;
                txt_UsuarioEmision.Text = ConfigGlobal.UserRuc;
                txt_ClaveEmision.Text = ConfigGlobal.PassRuc;
            }
           
        }

        private void chckDemo_SliderValueChanged(object sender, EventArgs e)
        {
           
        }

        private void btnProbarCredenciales_Click(object sender, EventArgs e)
        {
            if (DLL.ValidaAcceso(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text))
            {
                Log("Credenciales Válidas " + LeerDll() + ":" + Environment.NewLine + "Ruc: " + txt_RucEmision.Text + Environment.NewLine + "User: " + txt_UsuarioEmision.Text + Environment.NewLine + "Pass: " + txt_ClaveEmision.Text, true, false);
            }
            else
            {
                Log("Credenciales Incorrectas" + LeerDll() + ":" + Environment.NewLine + "Ruc: " + txt_RucEmision.Text + Environment.NewLine + "User: " + txt_UsuarioEmision.Text + Environment.NewLine + "Pass: " + txt_ClaveEmision.Text, false, false);
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

        private void cmb_TipoEmision_SelectedIndexChanged(object sender, EventArgs e)
        {
            gb_Archivos.Enabled = true;
            gb_PostAceptacion.Enabled = false;
            if(cmb_TipoEmision.Text == "PSE 2.1")
            {
                gb_Credenciales.Enabled = true;
                lblLeyenda.Text = "** Para las bajas el contenido del TXT debe ser Tipo-Numeracion|Motivo + Salto de linea";
                chckRequest.Enabled = true;
                chckEdicion.Enabled = true;
                btnProbarCredenciales.Enabled = true;
            }
            else if(cmb_TipoEmision.Text != "SUNAT (PARA FIRMAR)")
            {
                lblLeyenda.Text = "** Selecciona solo él/los XML/Zip";
                gb_Credenciales.Enabled = true;
                btnProbarCredenciales.Enabled = false;
            }
            else
            {
                lblLeyenda.Text = "** Selecciona solo él/los XML";
                gb_Credenciales.Enabled = true;
                btnProbarCredenciales.Enabled = false;
            }
            
            CargarParametros();
            lst_archivo.Items.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog fichero = new OpenFileDialog();
            fichero.Multiselect = true;
            //fichero.Filter = "Text (*.txt)|*.TXT|XML (*.xml)|*.XML|ZIP (*.zip)|*.ZIP";
            if(cmb_TipoEmision.Text == "PSE 2.1")
            {
                fichero.Filter = "Text (*.txt)|*.TXT";
            }
            else if (cmb_TipoEmision.Text != "SUNAT (PARA FIRMAR)")
            {
                fichero.Filter = "XML (*.xml)|*.XML|ZIP (*.zip)|*.ZIP";
            }
            else
            {
                fichero.Filter = "XML (*.xml)|*.XML";
            }

            //open.Filter = "ZIP files (*.zip)|*.zip";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < fichero.FileNames.Length; i++)
                {
                    lst_archivo.Items.Add(fichero.FileNames[i]);
                    //cmd_Procesar2.Enabled = true;
                }
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if(lst_archivo.Items.Count > 0)
            {
                if (cmb_TipoEmision.Text == "PSE 2.1")
                {
                    EmisionPSE();
                }
                else if (cmb_TipoEmision.Text == "SUNAT")
                {
                    EmisionSunat();
                }
                else if (cmb_TipoEmision.Text == "OSE")
                {
                    EmisionOse();
                }
                else if (cmb_TipoEmision.Text == "SUNAT (PARA FIRMAR)")
                {
                    EmisionSunatFirmado();
                }
            }
            else
            {
                MessageBox.Show("Debes añadir al menos un archivo al listado");
            }
           
        }

        private void EmisionPSE()
        {
            try
            {
                Log("-------------- Envío a PSE ------------", true, false);
                ts_ProgressBar1.Minimum = 1;
                ts_ProgressBar1.Maximum = lst_archivo.Items.Count;
                ts_ProgressBar1.Value = 1;
                ts_ProgressBar1.Step = 1;
                //var resp = "";
                for (int i = 0; i < lst_archivo.Items.Count; i++)
                {
                    try
                    {
                        if (chckRequestPre.Checked)
                        {
                            FolderBrowserDialog dlCarpeta = new FolderBrowserDialog();
                            dlCarpeta.RootFolder = System.Environment.SpecialFolder.Desktop;
                            dlCarpeta.ShowNewFolderButton = false;
                            dlCarpeta.Description = "Selecciona la carpeta";
                            string rutaDestino = "";
                            (int Codigo, string Mensaje, string Documento) resp2;

                            if (dlCarpeta.ShowDialog() == DialogResult.OK)
                            {
                                rutaDestino = dlCarpeta.SelectedPath;
                            }
                            DirectoryInfo di = new DirectoryInfo(lst_archivo.Items[i].ToString());
                            string nombreXml = di.Name;
                            string ruta = rutaDestino + "\\" + nombreXml + "_Old" + ".xml";
                            resp2.Mensaje = request.GenerarRequest(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, lst_archivo.Items[i].ToString(), ruta);
                            string rutaNueva = rutaDestino + "\\" + nombreXml + "_Request" + ".xml";

                            ObtenerRequest(ruta, rutaNueva);
                            if (File.Exists(ruta))
                            {
                                File.Delete(ruta);
                            }
                            Log("Se genera el request del documento: " + lst_archivo.Items[i].ToString(), true, false);
                            Log("En la ruta: " + rutaNueva, true, false);
                        }
                        else
                        {
                            aceptadoEdicionGlobal = false;
                            string NombreArchivo, Iniciales;
                            (int Codigo, string Mensaje, string Docmumento) resp;
                            resp.Docmumento = "";
                            resp.Codigo = 9;
                            (int Codigo, string Mensaje, string Docmumento, string Numeracion) respBaja;
                            string[] respDae = null;

                            NombreArchivo = Path.GetFileName(lst_archivo.Items[i].ToString());
                            string ArchivoAEnviar = lst_archivo.Items[i].ToString();
                            if (chckEdicion.Checked)
                            {
                                try
                                {
                                    //MessageBox.Show("Espera mientras se procesa tu petición, esto puede demorar unos segundos!");                                   
                                    try
                                    {
                                        string nombreArchivoTxt = Path.GetFileName(lst_archivo.Items[i].ToString());
                                        string rutaArchivoTxt = Path.GetDirectoryName(lst_archivo.Items[i].ToString());
                                        string rutaRaiz = Path.GetFullPath(lst_archivo.Items[i].ToString());
                                        string ruc = ConfigurationManager.AppSettings["Ruc"];

                                        if (nombreArchivoTxt.Split('-')[0] != ruc)
                                        {
                                            string rucAReemplazar = "";
                                            if (nombreArchivoTxt.StartsWith("DAE"))
                                            {
                                                rucAReemplazar = nombreArchivoTxt.Split('_')[1];
                                            }
                                            else
                                            {
                                                rucAReemplazar = nombreArchivoTxt.Split('-')[0];
                                            }
                                             
                                            if (File.Exists(lst_archivo.Items[i].ToString().Replace(rucAReemplazar, ruc)))
                                            {
                                                File.Delete(lst_archivo.Items[i].ToString().Replace(rucAReemplazar, ruc));
                                            }
                                            File.Copy(lst_archivo.Items[i].ToString(), lst_archivo.Items[i].ToString().Replace(rucAReemplazar, ruc));
                                            nombreArchivoTxt = Path.GetFileName(lst_archivo.Items[i].ToString().Replace(rucAReemplazar, ruc));
                                            rutaRaiz = Path.GetFullPath(lst_archivo.Items[i].ToString().Replace(rucAReemplazar, ruc));
                                            Log("Modificado: RUC del nombre del archivo original, antes: " + rucAReemplazar + " Despues: " + ruc, true, false);

                                        }

                                        ArchivoAEnviar = CambiaContenidoTxt(nombreArchivoTxt, rutaRaiz, AmbienteGlobal, rutaArchivoTxt + "\\");
                                        RutaArchivoEnviarGlobal = ArchivoAEnviar;
                                        NombreArchivo = Path.GetFileName(ArchivoAEnviar);
                                        Log("Archivo original: " + lst_archivo.Items[i].ToString(), true, false);
                                        //Log("Se Creo el archivo: " + NombreArchivo, true, false);
                                        Log("Modificado: Fecha de emisión (hoy), sucursal (0000), enviarCorreo (valor 'NO'), serie (Segun las cargadas en el área de config. tomando en cuenta el Ambiente)" +
                                            " y correlativo (aleatorio 1 - 99999999): " + NombreArchivo, true, false);

                                    }
                                    catch (Exception exc)
                                    {
                                        Log("Error: " + exc.Message, true, false);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Log("Error: " + ex.Message, true, false);
                                }
                            }
                            if (NombreArchivo.StartsWith("DAE"))
                            {
                                Iniciales = "DAE";
                            }
                            else
                            {
                                Iniciales = NombreArchivo.Split('-')[1];
                            }
                            ts_ProgressBar1.PerformStep();
                            var uno = lst_archivo.Items[i].ToString();
                            if (Iniciales != "RA" && Iniciales != "RC" && Iniciales != "09" && Iniciales != "31" && Iniciales != "20" && Iniciales != "40" && Iniciales != "42" && Iniciales != "DAE")
                            {
                                resp = DLL.Enviar(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, ArchivoAEnviar);
                                if (resp.Codigo == 0)
                                {
                                    aceptadoEdicionGlobal = true;
                                }
                                Log(NombreArchivo + " --> " + resp.Mensaje + " --> Doc real (" + resp.Docmumento + ")", aceptadoEdicionGlobal, false);
                                lblDocEdicion.Text = resp.Docmumento;
                            }
                            else if (Iniciales == "RC")
                            {
                                //resp = DllG1.EnviarResumen(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, ArchivoAEnviar);
                                resp = DLL.EnviarResumen(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, ArchivoAEnviar);
                                //bool aceptado = false;
                                if (resp.Codigo == 0)
                                {
                                    aceptadoEdicionGlobal = true;
                                }
                                Log(NombreArchivo + " --> " + resp.Mensaje + " --> Doc real (" + resp.Docmumento + ")", aceptadoEdicionGlobal, false);
                                lblDocEdicion.Text = resp.Docmumento;

                            }
                            else if (Iniciales == "09" || Iniciales == "31")
                            {
                                String cadena = ArchivoAEnviar;
                                FileInfo fi = new FileInfo(cadena);
                                string ruc = fi.Name;

                                if (ruc.Split('-')[0] == "20550728762")
                                {
                                    resp = DLL.EnviarGuiaRemision(ConfigGlobal.Ruc2, ConfigGlobal.UserRuc2, ConfigGlobal.PassRuc2, ArchivoAEnviar);
                                }
                                else
                                {
                                    resp = DLL.EnviarGuiaRemision(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, ArchivoAEnviar); 
                                }


                                //bool aceptado = false;
                                if (resp.Codigo == 0)
                                {
                                    aceptadoEdicionGlobal = true;
                                }
                                Log(NombreArchivo + " --> " + resp.Mensaje + " --> Doc real (" + resp.Docmumento + ")", aceptadoEdicionGlobal, false);
                                lblDocEdicion.Text = resp.Docmumento;

                            }
                            else if (Iniciales == "RA")
                            {
                                var RA_Docs = LeerTxtRA(ArchivoAEnviar);
                                string[] RA;
                                for (int j = 0; j < RA_Docs.Length; j++)
                                {
                                    RA = RA_Docs[j].Split('|');
                                    string docEnviado = RA[0];
                                    respBaja = DLL.ComunicacionBaja(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, docEnviado, RA[1]);
                                    //bool aceptado = false;
                                    if (respBaja.Codigo == 0)
                                    {
                                        aceptadoEdicionGlobal = true;
                                    }
                                    Log(NombreArchivo + " --> " + respBaja.Mensaje + " --> Doc real (" + respBaja.Docmumento + ")", aceptadoEdicionGlobal, false);
                                }
                            }
                            else if (Iniciales == "RR")
                            {
                                var RA_Docs = LeerTxtRA(ArchivoAEnviar);
                                string[] RA;
                                for (int j = 0; j < RA_Docs.Length; j++)
                                {
                                    RA = RA_Docs[j].Split('|');
                                    string docEnviado = RA[0];
                                    respBaja = DLL.ReversionComprobantes(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, docEnviado, RA[1]);
                                    //bool aceptado = false;
                                    if (respBaja.Codigo == 0)
                                    {
                                        aceptadoEdicionGlobal = true;
                                    }
                                    Log(NombreArchivo + " --> " + respBaja.Mensaje + " ---> Doc real (" + respBaja.Docmumento + ")", aceptadoEdicionGlobal, false);
                                }
                            }
                            else if (Iniciales == "20" || Iniciales == "40")
                            {
                                resp = DLL.EnviarPercepcionRetencion(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, ArchivoAEnviar);
                                //bool aceptado = false;
                                if (resp.Codigo == 0)
                                {
                                    aceptadoEdicionGlobal = true;
                                }
                                Log(NombreArchivo + " --> " + resp.Mensaje + " ---> Doc real (" + resp.Docmumento + ")", aceptadoEdicionGlobal, false);
                                lblDocEdicion.Text = resp.Docmumento;
                            }
                            else if (Iniciales == "42")
                            {
                                resp = DLL.EnviarDaeg1(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, ArchivoAEnviar);
                                //bool aceptado = false;
                                if (resp.Codigo == 0)
                                {
                                    aceptadoEdicionGlobal = true;
                                }
                                Log(NombreArchivo + " --> " + resp.Mensaje + " ---> Doc real (" + resp.Docmumento + ")", aceptadoEdicionGlobal, false);
                                lblDocEdicion.Text = resp.Docmumento;
                            }
                            else if (Iniciales == "DAE")
                            {
                                List<string> lstArch = new List<string>();
                                lstArch.Add(ArchivoAEnviar);
                                string[] arrayOfArch = lstArch.ToArray();
                                respDae = DllG2.EnviosDCH(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, arrayOfArch);
                                if (respDae[0].Split('|')[0] == "0")
                                {
                                    aceptadoEdicionGlobal = true;
                                }
                                Log(respDae[0].Split('|')[3] + " --> " + respDae[0].Split('|')[1] + " --> Doc real (" + NombreArchivo.Split('_')[1] + "-" + respDae[0].Split('|')[2] + ")", aceptadoEdicionGlobal, false);
                                lblDocEdicion.Text = resp.Docmumento;
                               
                            }

                            if (Iniciales == "DAE")
                            {
                                if (respDae[0].Split('|')[0] == "0")
                                {
                                    string numeracion = NombreArchivo.Split('_')[1] + "-" + respDae[0].Split('|')[2];
                                    Task t1 = Task.Run(() => ProcesaIndividual(numeracion));
                                    //gb_PostAceptacion.Enabled = true;
                                }
                            }
                            else
                            {
                                if (resp.Codigo == 0)
                                {
                                    Task t1 = Task.Run(() => ProcesaIndividual(resp.Docmumento.ToString()), token);
                                    //gb_PostAceptacion.Enabled = true;
                                }
                            }
                                
                            //else
                            //{
                            //    gb_PostAceptacion.Enabled = false;
                            //}
                        }
                    }
                    catch (Exception exe)
                    {
                        Log(exe.Message, false, false);
                    }
                }
            }
            catch (Exception e)
            {
                Log(e.Message, false, false);
            }
            if (!chckEdicion.Checked)
            {
                lst_archivo.Items.Clear();
            }
            Log("-------------- Fin envío a PSE ------------", true, false);

        }

        private void ProcesaIndividual(string numeracion)
        {
            string AmbienteGlobal = LeerDll();
            Log("--------- Consulta estatus Sunat/Ose " + AmbienteGlobal + "---------", true, false);
            bool encendido = true;
            while (encendido)
            {
                (int Codigo, string Mensaje, string Docmumento) resp;

                if (numeracion.Split('-')[0] == "20550728762")
                {
                    resp = DLL.EstatusDocumento(ConfigGlobal.Ruc2, ConfigGlobal.UserRuc2, ConfigGlobal.PassRuc2, numeracion);
                }
                else
                {
                    resp = DLL.EstatusDocumento(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, numeracion);
                }

                if (resp.Codigo == 0)
                {
                    //Log("Documento " + numeracion + " aceptado.", true, false);
                    encendido = false;
                    gb_PostAceptacion.Enabled = true;
                    //btnDescargas.Enabled = true;
                    //dtgEjemplos.Rows[index].Cells[2].Value = resp.Codigo + "|" + resp.Mensaje;
                    //dtgEjemplos.Rows[index].DefaultCellStyle.ForeColor = colorAceptados;
                    (int Codigo, string Mensaje, string Docmumento, string ArhivoBase64) respDescarga;

                    if (numeracion.Split('-')[0] == "20550728762")
                    {
                        respDescarga = DLL.DescargaArchivos(ConfigGlobal.Ruc2, ConfigGlobal.UserRuc2, ConfigGlobal.PassRuc2, numeracion, "CDR");
                    }
                    else
                    {
                        respDescarga = DLL.DescargaArchivos(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, numeracion, "CDR");
                    }

                    if (respDescarga.ArhivoBase64 != null)
                    {
                        byte[] data = System.Convert.FromBase64String(respDescarga.ArhivoBase64);
                        File.WriteAllBytes(ConfigPerso.RutaEjemplosProcesados + numeracion + ".zip", data);
                    }
                    var cdrContenido = LeerCDR(DescomprimirArchivo(ConfigPerso.RutaEjemplosProcesados + numeracion + ".zip"));
                    Log("Documento " + numeracion + " aceptado, " + cdrContenido.Split('|')[2] + ".", true, false);
                }
                else if (resp.Codigo == 95 || resp.Codigo == 99)
                {
                    Log("Documento " + numeracion + " aun no aceptado. En 30 segundos se realizara nuevamente la consulta para evitar error 99", true, false);
                    Thread.Sleep(30000);
                }
                else
                {
                    Log("Documento  " + numeracion + " rechazado: " + resp.Codigo + "-" + resp.Mensaje, false, false);
                    //dtgEjemplos.Rows[index].Cells[2].Value = resp.Codigo + "|" + resp.Mensaje;
                    //dtgEjemplos.Rows[index].DefaultCellStyle.ForeColor = Color.Red;
                    encendido = false;
                }
            }
            //pruebaDocEjemploActivo = false;
            //btnProbarTodos.Enabled = true;
            Log("--------- Fin Consulta estatus Sunat/Ose " + AmbienteGlobal + "---------", true, false);
        }

        private void EmisionSunat()
        {
            Log("-------------- Envío a SUNAT ------------", true, false);
            try
            {
                ts_ProgressBar1.Minimum = 1;
                ts_ProgressBar1.Maximum = lst_archivo.Items.Count;
                ts_ProgressBar1.Value = 1;
                ts_ProgressBar1.Step = 1;
                for (int i = 0; i < lst_archivo.Items.Count; i++)
                {
                    try
                    {
                        EnviaXmlSunat Sunat = new EnviaXmlSunat();
                        string PathXml, NombreArchivo, rutaZip;
                        PathXml = lst_archivo.Items[i].ToString();
                        Log("Ruta original: " + PathXml, true, false);

                        NombreArchivo = Path.GetFileName(lst_archivo.Items[i].ToString());
                        var extension = Path.GetExtension(NombreArchivo);
                        if(extension == ".ZIP" || extension == ".zip")
                        {
                            rutaZip = PathXml;
                        }
                        else
                        {
                            rutaZip = ComprimirArchivo(PathXml, NombreArchivo, ConfigPerso.RutaEjemplosProcesados + Path.GetFileNameWithoutExtension(NombreArchivo) + ".zip");
                        }

                        string url = "https://e-beta.sunat.gob.pe:443/ol-ti-itcpfegem-beta/billService";
                        var sunat = Sunat.EnviaXml(rutaZip, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, url);
                        string nombreCdr = Path.GetDirectoryName(ConfigPerso.RutaEjemplosProcesados + "\\toZip\\" + Path.GetFileNameWithoutExtension(PathXml) + ".zip") + "\\R-" + Path.GetFileNameWithoutExtension(NombreArchivo) + ".zip";

                        try
                        {
                            if (File.Exists(nombreCdr))
                            {
                                File.Delete(nombreCdr);
                            }
                            File.WriteAllBytes(nombreCdr, sunat.base64);
                        }catch(Exception ex)
                        {

                        }

                        string respuestaCdr = "";
                        try
                        {
                            string ruta = DescomprimirArchivo(nombreCdr);
                            respuestaCdr = LeerCDR(ruta);
                        }
                        catch (Exception ex)
                        {

                        }
                        Log("Doc eviado a Sunat Demo: " + NombreArchivo, true, false);
                        if (sunat.aceptado)
                        {
                            Log("Estado: Aceptado: " + respuestaCdr.Split('|')[1] + respuestaCdr.Split('|')[2], true, false);
                        }
                        else
                        {
                            if(respuestaCdr == "")
                            {
                                Log("Estado: Rechazado: " + sunat.mensaje, false, false);
                            }
                            else
                            {
                                Log("Estado: Rechazado: " + respuestaCdr.Split('|')[1], false, false);
                            }
                        }
                        string rutacopiar = Path.GetDirectoryName(nombreCdr) + "\\" + Path.GetFileNameWithoutExtension(NombreArchivo) + ".zip";
                        if (File.Exists(rutacopiar))
                        {
                            File.Delete(rutacopiar);
                        }
                        File.Copy(rutaZip, rutacopiar);
                        System.Diagnostics.Process.Start("explorer.exe", Path.GetDirectoryName(nombreCdr));
                        ts_ProgressBar1.PerformStep();
                        //aceptadoEdicionGlobal = false;                       
                        //string ArchivoAEnviar = lst_archivo.Items[i].ToString();                      
                        //Iniciales = NombreArchivo.Split('-')[1];
                        //ts_ProgressBar1.PerformStep();
                        //var uno = lst_archivo.Items[i].ToString();
                        //if (Iniciales == "01" || Iniciales == "03" || Iniciales == "07" || Iniciales == "08")
                        //{
                        //    string rutaZip = ComprimirArchivo(ArchivoAEnviar, NombreArchivo, ConfigPerso.RutaEjemplosProcesados + Path.GetFileNameWithoutExtension(NombreArchivo)  + ".zip");
                        //    byte[] bytes = File.ReadAllBytes(rutaZip);
                        //    try
                        //    {
                        //        string nombreCdr = Path.GetDirectoryName(ConfigPerso.RutaEjemplosProcesados + "\\toZip\\" + Path.GetFileNameWithoutExtension(NombreArchivo) + ".zip") + "\\R-" + NombreArchivo + ".zip";
                        //        var resp = sunat.sendBill(Path.GetFileName(rutaZip), bytes, "");
                        //        if (File.Exists(nombreCdr))
                        //        {
                        //            File.Delete(nombreCdr);
                        //        }
                        //        File.WriteAllBytes(nombreCdr, resp);
                        //        string respuestaCdr = LeerCDR(DescomprimirArchivo(nombreCdr));
                        //        if (respuestaCdr.Split('|')[0] == "0")
                        //        {
                        //            Log("Aceptado: " + respuestaCdr.Split('|')[1] + respuestaCdr.Split('|')[2], true,false);
                        //        }
                        //        else
                        //        {
                        //            Log("Rechazado: " + respuestaCdr.Split('|')[1], false, false);
                        //        }
                        //        string rutacopiar = Path.GetDirectoryName(nombreCdr) + "\\" + Path.GetFileNameWithoutExtension(NombreArchivo) + ".zip";
                        //        File.Copy(rutaZip, rutacopiar);
                        //        System.Diagnostics.Process.Start("explorer.exe", Path.GetDirectoryName(nombreCdr));

                        //    }
                        //    catch (FaultException ex)
                        //    {
                        //        Log("Documento rechazado, código:  " + ex.Message, false, false);                                
                        //    }
                        //    catch (Exception er)
                        //    {
                        //        Log("Error: " + er.Message, false, false);
                        //    }

                        //}
                        //
                        Log("Ruta final: " + Path.GetDirectoryName(nombreCdr), true, false);

                    }
                    catch (Exception exe)
                    {
                        Log(exe.Message, false, false);
                        Log("Prueba cerrando todas las ventana de WinRAR!", false, false);
                    }
                }
            }
            catch (Exception e)
            {
                Log(e.Message, false, false);
            }
            lst_archivo.Items.Clear();
            Log("-------------- Fin envío a SUNAT ------------", true, false);          
        }

        private void EmisionSunatFirmado()
        {
            Log("-------------- Envío a SUNAT Con Firmado ------------", true, false);
            try
            {
                ts_ProgressBar1.Minimum = 1;
                ts_ProgressBar1.Maximum = lst_archivo.Items.Count;
                ts_ProgressBar1.Value = 1;
                ts_ProgressBar1.Step = 1;
                for (int i = 0; i < lst_archivo.Items.Count; i++)
                {
                    try
                    {
                        EnviaXmlSunat Sunat = new EnviaXmlSunat();
                        string PathXml, NombreArchivo, rutaZip;        
                        PathXml = lst_archivo.Items[i].ToString();
                        Log("Ruta original: " + PathXml, true, false);
                        NombreArchivo = Path.GetFileName(lst_archivo.Items[i].ToString());
                        var extension = Path.GetExtension(NombreArchivo);

                        string rutaSinFirmar = ".\\Procesados\\NoSign\\" + NombreArchivo;
                        if (File.Exists(rutaSinFirmar))
                        {
                            File.Delete(rutaSinFirmar);
                        }
                        File.Copy(PathXml, rutaSinFirmar);

                       

                        Firma Firma2 = new Firma();
                        string pathCertificado = ConfigGlobal.RutaCertificado;
                        string claveCertificado = ConfigGlobal.ClaveCertificado;
                        XmlDocument xmlDocument_sinFirmar = new XmlDocument();
                        xmlDocument_sinFirmar.Load(rutaSinFirmar);

                        string rutaFirmado = ".\\Procesados\\Sign\\" + NombreArchivo;
                        if (File.Exists(rutaFirmado))
                        {
                            File.Delete(rutaFirmado);
                        }
                        Firma2.Firma2(xmlDocument_sinFirmar, pathCertificado, claveCertificado).Save(rutaFirmado);
                        Log("Doc Firmado exitosamente!", true, false);


                        PathXml = rutaFirmado;
                        if (extension == ".ZIP" || extension == ".zip")
                        {
                            rutaZip = PathXml;
                        }
                        else
                        {
                            rutaZip = ComprimirArchivo(PathXml, NombreArchivo, ConfigPerso.RutaEjemplosProcesados + Path.GetFileNameWithoutExtension(NombreArchivo) + ".zip");
                        }

                        string url = "https://e-beta.sunat.gob.pe:443/ol-ti-itcpfegem-beta/billService";
                        var sunat = Sunat.EnviaXml(rutaZip, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, url);
                        string nombreCdr = Path.GetDirectoryName(ConfigPerso.RutaEjemplosProcesados + "\\toZip\\" + Path.GetFileNameWithoutExtension(PathXml) + ".zip") + "\\R-" + Path.GetFileNameWithoutExtension(NombreArchivo) + ".zip";

                        try
                        {
                            if (File.Exists(nombreCdr))
                            {
                                File.Delete(nombreCdr);
                            }
                            File.WriteAllBytes(nombreCdr, sunat.base64);
                        }
                        catch (Exception ex)
                        {

                        }

                        string respuestaCdr = "";
                        try
                        {
                            string ruta = DescomprimirArchivo(nombreCdr);
                            respuestaCdr = LeerCDR(ruta);
                        }
                        catch (Exception ex)
                        {

                        }
                        Log("Doc enviado a Sunat Demo: " + NombreArchivo, true, false);
                        if (sunat.aceptado)
                        {
                            Log("Estado: Aceptado: " + respuestaCdr.Split('|')[1] + respuestaCdr.Split('|')[2], true, false);
                        }
                        else
                        {
                            if (respuestaCdr == "")
                            {
                                Log("Estado: Rechazado: " + sunat.mensaje, false, false);
                            }
                            else
                            {
                                Log("Estado: Rechazado: " + respuestaCdr.Split('|')[1], false, false);
                            }
                        }
                        string rutacopiar = Path.GetDirectoryName(nombreCdr) + "\\" + Path.GetFileNameWithoutExtension(NombreArchivo) + ".zip";
                        if (File.Exists(rutacopiar))
                        {
                            File.Delete(rutacopiar);
                        }
                        File.Copy(rutaZip, rutacopiar);
                        System.Diagnostics.Process.Start("explorer.exe", Path.GetDirectoryName(nombreCdr));
                        Log("Ruta final: " + Path.GetDirectoryName(nombreCdr), true, false);
                        ts_ProgressBar1.PerformStep();
                        //aceptadoEdicionGlobal = false;                       
                        //string ArchivoAEnviar = lst_archivo.Items[i].ToString();                      
                        //Iniciales = NombreArchivo.Split('-')[1];
                        //ts_ProgressBar1.PerformStep();
                        //var uno = lst_archivo.Items[i].ToString();
                        //if (Iniciales == "01" || Iniciales == "03" || Iniciales == "07" || Iniciales == "08")
                        //{
                        //    string rutaZip = ComprimirArchivo(ArchivoAEnviar, NombreArchivo, ConfigPerso.RutaEjemplosProcesados + Path.GetFileNameWithoutExtension(NombreArchivo)  + ".zip");
                        //    byte[] bytes = File.ReadAllBytes(rutaZip);
                        //    try
                        //    {
                        //        string nombreCdr = Path.GetDirectoryName(ConfigPerso.RutaEjemplosProcesados + "\\toZip\\" + Path.GetFileNameWithoutExtension(NombreArchivo) + ".zip") + "\\R-" + NombreArchivo + ".zip";
                        //        var resp = sunat.sendBill(Path.GetFileName(rutaZip), bytes, "");
                        //        if (File.Exists(nombreCdr))
                        //        {
                        //            File.Delete(nombreCdr);
                        //        }
                        //        File.WriteAllBytes(nombreCdr, resp);
                        //        string respuestaCdr = LeerCDR(DescomprimirArchivo(nombreCdr));
                        //        if (respuestaCdr.Split('|')[0] == "0")
                        //        {
                        //            Log("Aceptado: " + respuestaCdr.Split('|')[1] + respuestaCdr.Split('|')[2], true,false);
                        //        }
                        //        else
                        //        {
                        //            Log("Rechazado: " + respuestaCdr.Split('|')[1], false, false);
                        //        }
                        //        string rutacopiar = Path.GetDirectoryName(nombreCdr) + "\\" + Path.GetFileNameWithoutExtension(NombreArchivo) + ".zip";
                        //        File.Copy(rutaZip, rutacopiar);
                        //        System.Diagnostics.Process.Start("explorer.exe", Path.GetDirectoryName(nombreCdr));

                        //    }
                        //    catch (FaultException ex)
                        //    {
                        //        Log("Documento rechazado, código:  " + ex.Message, false, false);                                
                        //    }
                        //    catch (Exception er)
                        //    {
                        //        Log("Error: " + er.Message, false, false);
                        //    }

                        //}                       
                    }
                    catch (Exception exe)
                    {
                        Log(exe.Message, false, false);
                        Log("Prueba cerrando todas las ventana de WinRAR!", false, false);
                    }
                }
            }
            catch (Exception e)
            {
                Log(e.Message, false, false);
            }
            lst_archivo.Items.Clear();
            Log("-------------- Fin envío a SUNAT Con Firmado ------------", true, false);
        }

        private void EmisionOse()
        {
            Log("-------------- Envío a OSE ------------", true, false);
            try
            {
                ts_ProgressBar1.Minimum = 1;
                ts_ProgressBar1.Maximum = lst_archivo.Items.Count;
                ts_ProgressBar1.Value = 1;
                ts_ProgressBar1.Step = 1;
                for (int i = 0; i < lst_archivo.Items.Count; i++)
                {
                    try
                    {
                        EnviaXmlOse Sunat = new EnviaXmlOse();
                        string PathXml, NombreArchivo, rutaZip;
                        PathXml = lst_archivo.Items[i].ToString();
                        Log("Ruta original: " + PathXml, true, false);

                        NombreArchivo = Path.GetFileName(lst_archivo.Items[i].ToString());
                        var extension = Path.GetExtension(NombreArchivo);
                        if (extension == ".ZIP" || extension == ".zip")
                        {
                            rutaZip = PathXml;
                        }
                        else
                        {
                            rutaZip = ComprimirArchivo(PathXml, NombreArchivo, ConfigPerso.RutaEjemplosProcesados + Path.GetFileNameWithoutExtension(NombreArchivo) + ".zip");
                        }

                        string url = "https://demoose.thefactoryhka.com.pe/ol-ti-itcpfegem/billService";
                        var sunat = Sunat.EnviaXml(rutaZip, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, url);
                        string nombreCdr = Path.GetDirectoryName(ConfigPerso.RutaEjemplosProcesados + "\\toZip\\" + Path.GetFileNameWithoutExtension(PathXml) + ".zip") + "\\R-" + Path.GetFileNameWithoutExtension(NombreArchivo) + ".zip";

                        try
                        {
                            if (File.Exists(nombreCdr))
                            {
                                File.Delete(nombreCdr);
                            }
                            File.WriteAllBytes(nombreCdr, sunat.base64);
                        }
                        catch (Exception ex)
                        {

                        }

                        string respuestaCdr = "";
                        try
                        {
                            respuestaCdr = LeerCDR(DescomprimirArchivo(nombreCdr));
                        }
                        catch (Exception ex)
                        {

                        }
                        Log("Doc eviado a OSE Demo: " + NombreArchivo, true, false);
                        if (sunat.aceptado)
                        {
                            Log("Estado: Aceptado: " + respuestaCdr.Split('|')[1] + respuestaCdr.Split('|')[2], true, false);
                        }
                        else
                        {
                            if (respuestaCdr == "")
                            {
                                Log("Estado: Rechazado: " + sunat.mensaje, false, false);
                            }
                            else
                            {
                                Log("Estado: Rechazado: " + respuestaCdr.Split('|')[1], false, false);
                            }
                        }
                        string rutacopiar = Path.GetDirectoryName(nombreCdr) + "\\" + Path.GetFileNameWithoutExtension(NombreArchivo) + ".zip";
                        if (File.Exists(rutacopiar))
                        {
                            File.Delete(rutacopiar);
                        }
                        File.Copy(rutaZip, rutacopiar);
                        System.Diagnostics.Process.Start("explorer.exe", Path.GetDirectoryName(nombreCdr));
                        ts_ProgressBar1.PerformStep();
                        Log("Ruta final: " + Path.GetDirectoryName(nombreCdr), true, false);

                    }
                    catch (Exception exe)
                    {
                        Log(exe.Message, false, false);
                        Log("Prueba cerrando todas las ventana de WinRAR!", false, false);

                    }

                }
            }
            catch (Exception e)
            {
                Log(e.Message, false, false);
            }
            lst_archivo.Items.Clear();

            Log("-------------- Fin envío a OSE ------------", true, false);
        }

        private void EmisionSunatBackUp()
        {
            Log("-------------- Envío a SUNAT ------------", true, false);

            try
            {
                ts_ProgressBar1.Minimum = 1;
                ts_ProgressBar1.Maximum = lst_archivo.Items.Count;
                ts_ProgressBar1.Value = 1;
                ts_ProgressBar1.Step = 1;
                for (int i = 0; i < lst_archivo.Items.Count; i++)
                {
                    try
                    {
                        aceptadoEdicionGlobal = false;
                        string NombreArchivo, Iniciales;

                        NombreArchivo = Path.GetFileName(lst_archivo.Items[i].ToString());
                        string ArchivoAEnviar = lst_archivo.Items[i].ToString();
                        if (chckEdicion.Checked)
                        {
                            try
                            {
                                //MessageBox.Show("Espera mientras se procesa tu petición, esto puede demorar unos segundos!");                                   
                                try
                                {
                                    string nombreArchivoTxt = Path.GetFileName(lst_archivo.Items[i].ToString());
                                    string rutaArchivoTxt = Path.GetDirectoryName(lst_archivo.Items[i].ToString());
                                    string rutaRaiz = Path.GetFullPath(lst_archivo.Items[i].ToString());
                                    string ruc = ConfigurationManager.AppSettings["Ruc"];

                                    if (nombreArchivoTxt.Split('-')[0] != ruc)
                                    {
                                        string rucAReemplazar = nombreArchivoTxt.Split('-')[0];
                                        if (File.Exists(lst_archivo.Items[i].ToString().Replace(rucAReemplazar, ruc)))
                                        {
                                            File.Delete(lst_archivo.Items[i].ToString().Replace(rucAReemplazar, ruc));
                                        }
                                        File.Copy(lst_archivo.Items[i].ToString(), lst_archivo.Items[i].ToString().Replace(rucAReemplazar, ruc));
                                        nombreArchivoTxt = Path.GetFileName(lst_archivo.Items[i].ToString().Replace(rucAReemplazar, ruc));
                                        rutaRaiz = Path.GetFullPath(lst_archivo.Items[i].ToString().Replace(rucAReemplazar, ruc));
                                        Log("Modificado: RUC del nombre del archivo original, antes: " + rucAReemplazar + " Despues: " + ruc, true, false);

                                    }

                                    ArchivoAEnviar = CambiaContenidoTxt(nombreArchivoTxt, rutaRaiz, AmbienteGlobal, rutaArchivoTxt + "\\");
                                    NombreArchivo = Path.GetFileName(ArchivoAEnviar);
                                    Log("Archivo original: " + lst_archivo.Items[i].ToString(), true, false);
                                    //Log("Se Creo el archivo: " + NombreArchivo, true, false);
                                    Log("Modificado: Fecha de emisión (hoy), sucursal (0000), enviarCorreo (valor 'NO'), serie (Segun las cargadas en el área de config. tomando en cuenta el Ambiente)" +
                                        " y correlativo (aleatorio 1 - 99999999): " + NombreArchivo, true, false);

                                }
                                catch (Exception exc)
                                {
                                    Log("Error: " + exc.Message, true, false);
                                }
                            }
                            catch (Exception ex)
                            {
                                Log("Error: " + ex.Message, true, false);
                            }
                        }
                        Iniciales = NombreArchivo.Split('-')[1];
                        ts_ProgressBar1.PerformStep();
                        var uno = lst_archivo.Items[i].ToString();
                        if (Iniciales == "01" || Iniciales == "03" || Iniciales == "07" || Iniciales == "08")
                        {
                            string rutaZip = ComprimirArchivo(ArchivoAEnviar, NombreArchivo, ConfigPerso.RutaEjemplosProcesados + Path.GetFileNameWithoutExtension(NombreArchivo) + ".zip");
                            byte[] bytes = File.ReadAllBytes(rutaZip);
                            try
                            {
                                string nombreCdr = Path.GetDirectoryName(ConfigPerso.RutaEjemplosProcesados + "\\toZip\\" + Path.GetFileNameWithoutExtension(NombreArchivo) + ".zip") + "\\R-" + NombreArchivo + ".zip";
                                var resp = sunat.sendBill(Path.GetFileName(rutaZip), bytes, "");
                                if (File.Exists(nombreCdr))
                                {
                                    File.Delete(nombreCdr);
                                }
                                File.WriteAllBytes(nombreCdr, resp);
                                string respuestaCdr = LeerCDR(DescomprimirArchivo(nombreCdr));
                                if (respuestaCdr.Split('|')[0] == "0")
                                {
                                    Log("Aceptado: " + respuestaCdr.Split('|')[1] + respuestaCdr.Split('|')[2], true, false);
                                }
                                else
                                {
                                    Log("Rechazado: " + respuestaCdr.Split('|')[1], false, false);
                                }
                                string rutacopiar = Path.GetDirectoryName(nombreCdr) + "\\" + Path.GetFileNameWithoutExtension(NombreArchivo) + ".zip";
                                File.Copy(rutaZip, rutacopiar);
                                System.Diagnostics.Process.Start("explorer.exe", Path.GetDirectoryName(nombreCdr));

                            }
                            catch (FaultException ex)
                            {
                                Log("Documento rechazado, código:  " + ex.Message, false, false);
                            }
                            catch (Exception er)
                            {
                                Log("Error: " + er.Message, false, false);
                            }

                        }
                    }
                    catch (Exception exe)
                    {
                        Log(exe.Message, false, false);
                    }
                }
            }
            catch (Exception e)
            {
                Log(e.Message, false, false);
            }
            Log("-------------- Fin envío a SUNAT ------------", true, false);
        }


        //private void EmisionOSE()
        //{
        //    Log("-------------- Envío a OSE ------------", true, false);

        //    try
        //    {
        //        ts_ProgressBar1.Minimum = 1;
        //        ts_ProgressBar1.Maximum = lst_archivo.Items.Count;
        //        ts_ProgressBar1.Value = 1;
        //        ts_ProgressBar1.Step = 1;
        //        //var resp = "";
        //        for (int i = 0; i < lst_archivo.Items.Count; i++)
        //        {
        //            try
        //            {
        //                EnviaXmlOse ose = new EnviaXmlOse();
        //                ose.EnviaXml(lst_archivo.Items[i].ToString());




        //                aceptadoEdicionGlobal = false;
        //                string NombreArchivo, Iniciales;                        
        //                NombreArchivo = Path.GetFileName(lst_archivo.Items[i].ToString());
        //                string ArchivoAEnviar = lst_archivo.Items[i].ToString();
        //                if (chckEdicion.Checked)
        //                {
        //                    try
        //                    {
        //                        //MessageBox.Show("Espera mientras se procesa tu petición, esto puede demorar unos segundos!");                                   
        //                        try
        //                        {
        //                            string nombreArchivoTxt = Path.GetFileName(lst_archivo.Items[i].ToString());
        //                            string rutaArchivoTxt = Path.GetDirectoryName(lst_archivo.Items[i].ToString());
        //                            string rutaRaiz = Path.GetFullPath(lst_archivo.Items[i].ToString());
        //                            string ruc = ConfigurationManager.AppSettings["Ruc"];

        //                            if (nombreArchivoTxt.Split('-')[0] != ruc)
        //                            {
        //                                string rucAReemplazar = nombreArchivoTxt.Split('-')[0];
        //                                if (File.Exists(lst_archivo.Items[i].ToString().Replace(rucAReemplazar, ruc)))
        //                                {
        //                                    File.Delete(lst_archivo.Items[i].ToString().Replace(rucAReemplazar, ruc));
        //                                }
        //                                File.Copy(lst_archivo.Items[i].ToString(), lst_archivo.Items[i].ToString().Replace(rucAReemplazar, ruc));
        //                                nombreArchivoTxt = Path.GetFileName(lst_archivo.Items[i].ToString().Replace(rucAReemplazar, ruc));
        //                                rutaRaiz = Path.GetFullPath(lst_archivo.Items[i].ToString().Replace(rucAReemplazar, ruc));
        //                                Log("Modificado: RUC del nombre del archivo original, antes: " + rucAReemplazar + " Despues: " + ruc, true, false);

        //                            }

        //                            ArchivoAEnviar = CambiaContenidoTxt(nombreArchivoTxt, rutaRaiz, AmbienteGlobal, rutaArchivoTxt + "\\");
        //                            NombreArchivo = Path.GetFileName(ArchivoAEnviar);
        //                            Log("Archivo original: " + lst_archivo.Items[i].ToString(), true, false);
        //                            //Log("Se Creo el archivo: " + NombreArchivo, true, false);
        //                            Log("Modificado: Fecha de emisión (hoy), sucursal (0000), enviarCorreo (valor 'NO'), serie (Segun las cargadas en el área de config. tomando en cuenta el Ambiente)" +
        //                                " y correlativo (aleatorio 1 - 99999999): " + NombreArchivo, true, false);

        //                        }
        //                        catch (Exception exc)
        //                        {
        //                            Log("Error: " + exc.Message, true, false);
        //                        }
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        Log("Error: " + ex.Message, true, false);
        //                    }
        //                }
        //                Iniciales = NombreArchivo.Split('-')[1];
        //                ts_ProgressBar1.PerformStep();
        //                var uno = lst_archivo.Items[i].ToString();
        //                if (Iniciales == "01" || Iniciales == "03" || Iniciales == "07" || Iniciales == "08")
        //                {
        //                    string rutaZip = ComprimirArchivo(ArchivoAEnviar, NombreArchivo, ConfigPerso.RutaEjemplosProcesados + Path.GetFileNameWithoutExtension(NombreArchivo) + ".zip");
        //                    byte[] bytes = File.ReadAllBytes(rutaZip);
        //                    try
        //                    {
        //                        string nombreCdr = Path.GetDirectoryName(ConfigPerso.RutaEjemplosProcesados + "\\toZip\\" + Path.GetFileNameWithoutExtension(NombreArchivo) + ".zip") + "\\R-" + NombreArchivo + ".zip";
        //                        var resp = ose.sendBill(Path.GetFileName(rutaZip), bytes);
        //                        if (File.Exists(nombreCdr))
        //                        {
        //                            File.Delete(nombreCdr);
        //                        }
        //                        //var response64 = Convert.FromBase64String(response);
        //                        File.WriteAllBytes(nombreCdr, resp);
        //                        string respuestaCdr = LeerCDR(DescomprimirArchivo(nombreCdr));
        //                        if (respuestaCdr.Split('|')[0] == "0")
        //                        {
        //                            Log("Aceptado: " + respuestaCdr.Split('|')[1] + respuestaCdr.Split('|')[2], true, false);
        //                        }
        //                        else
        //                        {
        //                            Log("Rechazado: " + respuestaCdr.Split('|')[1], false, false);
        //                        }
        //                        string rutacopiar = Path.GetDirectoryName(nombreCdr) + "\\" + Path.GetFileNameWithoutExtension(NombreArchivo) + ".zip";
        //                        File.Copy(rutaZip, rutacopiar);
        //                        System.Diagnostics.Process.Start("explorer.exe", Path.GetDirectoryName(nombreCdr));

        //                    }
        //                    catch (FaultException ex)
        //                    {
        //                        Log("Documento rechazado, código:  " + ex.Message, false, false);
        //                    }
        //                    catch (Exception er)
        //                    {
        //                        Log("Error: " + er.Message, false, false);
        //                    }

        //                }
        //            }
        //            catch (Exception exe)
        //            {
        //                Log(exe.Message, false, false);
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Log(e.Message, false, false);
        //    }
        //    Log("-------------- Fin envío a OSE ------------", true, false);

        //    //if (!chckEdicion.Checked)
        //    //{
        //    //    lst_archivo.Items.Clear();
        //    //}
        //}

        public void ObtenerRequest(string ruta, string rutaSave)
        {
            string cabecera = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:tem=\"http://tempuri.org/\" xmlns:per=\"http://schemas.datacontract.org/2004/07/PeruService.Classes\">" + Environment.NewLine +
               "<soapenv:Header />" + Environment.NewLine +
                "<soapenv:Body >" + Environment.NewLine +
                "<tem:Enviar >" + Environment.NewLine +
                "<tem:ruc >?</tem:ruc >" + Environment.NewLine +
                "<tem:usuario >?</tem:usuario >" + Environment.NewLine +
                "<tem:clave >?</tem:clave >" + Environment.NewLine;

            string final = "</tem:Enviar>" + Environment.NewLine +
                "</soapenv:Body >" + Environment.NewLine +
                "</soapenv:Envelope >";


            var arrayRequestLines = LeerRequest(ruta);
            for (int i = 0; i < arrayRequestLines.Length; i++)
            {
                string LineaActual = arrayRequestLines[i].ToString();

                string variable1 = "d2p1:nil=\"true\" xmlns:d2p1=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://schemas.datacontract.org/2004/07/PeruService.Classes\"";
                if ((LineaActual.IndexOf(variable1) > 0))
                {
                    string valorAnterior = arrayRequestLines[i];
                    arrayRequestLines[i] = valorAnterior.Replace(variable1, "");
                }

                string variable2 = "xmlns=\"http://schemas.datacontract.org/2004/07/PeruService.Classes\"";
                if ((LineaActual.IndexOf(variable2) > 0))
                {
                    string valorAnterior = arrayRequestLines[i];
                    arrayRequestLines[i] = valorAnterior.Replace(variable2, "");
                }

                string variable3 = "d4p1:nil=\"true\" xmlns:d4p1=\"http://www.w3.org/2001/XMLSchema-instance\"";
                if ((LineaActual.IndexOf(variable3) > 0))
                {
                    string valorAnterior = arrayRequestLines[i];
                    arrayRequestLines[i] = valorAnterior.Replace(variable3, "");
                }

                string variable4 = "d3p1:nil=\"true\" xmlns:d3p1=\"http://www.w3.org/2001/XMLSchema-instance\"";
                if ((LineaActual.IndexOf(variable4) > 0))
                {
                    string valorAnterior = arrayRequestLines[i];
                    arrayRequestLines[i] = valorAnterior.Replace(variable4, "");
                }
                string valorAnterior2 = arrayRequestLines[i];
                arrayRequestLines[i] = valorAnterior2.Replace("</", "##");

                string valorAnterior1 = arrayRequestLines[i];
                arrayRequestLines[i] = valorAnterior1.Replace("<", "<per:");

                string valorAnterior3 = arrayRequestLines[i];
                arrayRequestLines[i] = valorAnterior3.Replace("##", "</per:");


                string variable5 = "/>";
                if ((LineaActual.IndexOf(variable5) > 0))
                {
                    arrayRequestLines[i] = "";
                }

                //string variable6 = "<";
                //if ((LineaActual.IndexOf(variable5) > 1))
                //{
                //    string valorAnterior = arrayRequestLines[i];
                //    arrayRequestLines[i] = valorAnterior.Replace(variable6, "<per:");
                //}


            }

            string line, requestModificado = "";
            for (int i = 0; i < arrayRequestLines.Length; i++)
            {
                if (arrayRequestLines[i] != "")
                {
                    requestModificado += arrayRequestLines[i] + Environment.NewLine;
                }
            }

            //string requestOriginal = LeerRequestString(ruta);
            //string requestModificado = requestOriginal.Replace("<?xml version=\"1.0\"?>", "Test uno sdsdsd");
            //requestModificado = requestModificado.Replace("DocumentoElectronico", "documentoElectronico");
            ////requestModificado = requestModificado.Replace("d2p1:nil=\"true\" xmlns:d2p1=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://schemas.datacontract.org/2004/07/PeruService.Classes\"", "");
            //requestModificado = requestModificado.Replace("d2p1:nil=\"true\"", "");
            //requestModificado = requestModificado.Replace("xmlns=\"http://schemas.datacontract.org/2004/07/PeruService.Classes\"", "");
            //requestModificado = requestModificado.Replace("d4p1:nil=\"true\" xmlns:d4p1=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
            //requestModificado = requestModificado.Replace("d3p1:nil=\"true\" xmlns:d3p1=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
            string Request = requestModificado;
            requestModificado = Request.Replace("<per:?xml version=\"1.0\"?>", "");
            requestModificado = requestModificado.Replace("per:DocumentoElectronico", "tem:documentoElectronico");
            System.IO.File.WriteAllText(rutaSave, cabecera + requestModificado + final);
            File.Delete(ruta);
        }

        public string[] LeerRequest(string ruta)
        {
            string line;
            List<String> ret = new List<string>();
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(ruta);
            while ((line = file.ReadLine()) != null)
            {
                //System.Console.WriteLine(line);
                ret.Add(line);
            }
            file.Close();
            return ret.ToArray();
        }

        private string CambiaContenidoTxt(string nombreArchivo, string rutaArchivo, string ambiente, string rutaSalida)
        {
            //fhfhfhfgh
            //string ambiente = LeerConfig();
            string line = null;
            string tipoTxt = "";
            int uno = 0;
            string primeraLetra = "";
            var arrayNombreArchivo = nombreArchivo.Split('-');
            string fecha = obtieneFecha();


            if (!nombreArchivo.Substring(0, 3).Equals("DAE"))
            {
                tipoTxt = nombreArchivo.Split('-')[1];
                primeraLetra = nombreArchivo.Split('-')[2].Substring(0, 1);
            }
            else
            {
                tipoTxt = "DAE";
            }

            //primeraLetra = nombreArchivo.Split('-')[2].Substring(0,1);
            Random rnd = new Random();
            int numeroConDosCotas = rnd.Next(1, 99999999);

            List<String> listLineas = new List<string>();
            using (StreamReader file = new StreamReader(rutaArchivo))
            {
                while ((line = file.ReadLine()) != null)
                {
                    string[] camposLine = line.Split('|');
                    if (tipoTxt.Equals("40") || tipoTxt.Equals("20"))
                    {
                        if (camposLine[0].Equals("03"))
                        {
                            string newLine = "";
                            string oldLine = line;
                            string[] arrayLine = oldLine.Split('|');
                            string tipoDoc = arrayLine[1].Split('-')[0];
                            if (tipoDoc.Equals("07") || tipoDoc.Equals("08"))
                            {
                                arrayLine[1] = tipoDoc + "-0001-1234";
                            }
                            else
                            {
                                arrayLine[1] = "01-0001-1234";
                            }
                            arrayLine[2] = fecha;
                            arrayLine[5] = fecha;
                            arrayLine[10] = fecha;


                            for (int t = 0; t < arrayLine.Length - 1; t++)//Envio 1x1 de documentos ubicados en ruta TXTUbicacion
                            {
                                newLine += arrayLine[t] + "|";
                            }
                            line = newLine;
                        }
                        if (camposLine[0].Equals("02"))
                        {
                            string newLine = "";
                            string oldLine = line;
                            string[] arrayLine = oldLine.Split('|');
                            arrayLine[1] = fecha;

                            if (tipoTxt.Equals("20"))
                            {
                                arrayLine[3] = ConfigGlobal.SerieRet + "-" + numeroConDosCotas;
                            }
                            else if (tipoTxt.Equals("40"))
                            {
                                arrayLine[3] = ConfigGlobal.SeriePer + "-" + numeroConDosCotas;
                            }

                            for (int t = 0; t < arrayLine.Length - 1; t++)//Envio 1x1 de documentos ubicados en ruta TXTUbicacion
                            {
                                newLine += arrayLine[t] + "|";
                            }

                            line = newLine;
                        }

                    }
                    else if (tipoTxt.Equals("09") || tipoTxt.Equals("31"))
                    {
                        if (camposLine[0].Equals("COM"))
                        {
                            string newLine = "";
                            string oldLine = line;
                            string[] arrayLine = oldLine.Split('|');
                            //string tipoDoc = arrayLine[1].Split('-')[0];
                            //if (tipoDoc.Equals("07") || tipoDoc.Equals("08"))
                            //{
                            //    arrayLine[1] = tipoDoc + "-0001-1234";
                            //}
                            //else
                            //{
                            //    arrayLine[1] = "01-0001-1234";
                            //}
                            arrayLine[3] = fecha + " 23:00:00";
                            arrayLine[2] = numeroConDosCotas.ToString();

                            for (int t = 0; t < arrayLine.Length - 1; t++)//Envio 1x1 de documentos ubicados en ruta TXTUbicacion
                            {
                                newLine += arrayLine[t] + "|";
                            }
                            line = newLine;
                        }

                        if (camposLine[0].Equals("ENV"))
                        {
                            string newLine = "";
                            string oldLine = line;
                            string[] arrayLine = oldLine.Split('|');
                            //string tipoDoc = arrayLine[1].Split('-')[0];
                            //if (tipoDoc.Equals("07") || tipoDoc.Equals("08"))
                            //{
                            //    arrayLine[1] = tipoDoc + "-0001-1234";
                            //}
                            //else
                            //{
                            //    arrayLine[1] = "01-0001-1234";
                            //}
                            arrayLine[8] = fecha;
                            arrayLine[9] = fecha;

                            for (int t = 0; t < arrayLine.Length - 1; t++)//Envio 1x1 de documentos ubicados en ruta TXTUbicacion
                            {
                                newLine += arrayLine[t] + "|";
                            }
                            line = newLine;
                        }

                    }
                    else if (!tipoTxt.Equals("DAE"))
                    {
                        if (camposLine[0].Equals("EMI"))
                        {
                            string newLine = "";
                            string oldLine = line;
                            string[] arrayLine = oldLine.Split('|');
                            arrayLine[3] = "0000";
                            for (int t = 0; t < arrayLine.Length - 1; t++)//Envio 1x1 de documentos ubicados en ruta TXTUbicacion
                            {
                                newLine += arrayLine[t] + "|";
                            }
                            line = newLine;
                        }

                        if (camposLine[0].Equals("REC"))
                        {
                            string newLine = "";
                            string oldLine = line;
                            string[] arrayLine = oldLine.Split('|');
                            arrayLine[10] = "NO";
                            for (int t = 0; t < arrayLine.Length - 1; t++)//Envio 1x1 de documentos ubicados en ruta TXTUbicacion
                            {
                                newLine += arrayLine[t] + "|";
                            }
                            line = newLine;
                        }

                        if (camposLine[0].Equals("COM"))
                        {
                            string oldLine = line;
                            string newLine = "";
                            string[] arrayLine = oldLine.Split('|');
                            arrayLine[1] = fecha + " 23:00:00";


                            if (tipoTxt.Equals("01"))
                            {
                                arrayLine[3] = ConfigGlobal.SerieFact + "-" + numeroConDosCotas;
                            }
                            else if (tipoTxt.Equals("03"))
                            {
                                arrayLine[3] = ConfigGlobal.SerieBol + "-" + numeroConDosCotas;
                            }
                            else if (tipoTxt.Equals("07"))
                            {
                                if (primeraLetra.Equals("F"))
                                {
                                    arrayLine[3] = ConfigGlobal.SerieNC.Split('/')[0] + "-" + numeroConDosCotas;
                                }
                                else
                                {
                                    arrayLine[3] = ConfigGlobal.SerieNC.Split('/')[1] + "-" + numeroConDosCotas;
                                }
                                tipoNota = arrayLine[3].ToString().Substring(0, 1);

                            }
                            else if (tipoTxt.Equals("08"))
                            {
                                if (primeraLetra.Equals("F"))
                                {
                                    arrayLine[3] = ConfigGlobal.SerieND.Split('/')[0] + "-" + numeroConDosCotas;
                                }
                                else
                                {
                                    arrayLine[3] = ConfigGlobal.SerieND.Split('/')[1] + "-" + numeroConDosCotas;
                                }
                                tipoNota = arrayLine[3].ToString().Substring(0, 1);

                            }
                            else if (tipoTxt.Equals("09"))
                            {
                                arrayLine[1] = ConfigGlobal.SerieGuia;
                                arrayLine[2] = numeroConDosCotas.ToString();
                                arrayLine[3] = fecha + " 23:00:00";
                            }
                            else if (tipoTxt.Equals("42"))
                            {
                                arrayLine[3] = ConfigGlobal.SerieDae + "-" + numeroConDosCotas;
                                arrayLine[1] = fecha;
                            }

                            for (int t = 0; t < arrayLine.Length - 1; t++)//Envio 1x1 de documentos ubicados en ruta TXTUbicacion
                            {
                                newLine += arrayLine[t] + "|";
                            }
                            line = newLine;
                        }

                        if (camposLine[0].Equals("REL-N"))
                        {
                            string newLine = "";
                            string oldLine = line;
                            string[] arrayLine = oldLine.Split('|');
                            if (tipoNota == "B")
                            {
                                arrayLine[1] = "03/0001-1234";
                            }
                            else
                            {
                                arrayLine[1] = "01/0001-1234";
                            }
                            for (int t = 0; t < arrayLine.Length - 1; t++)//Envio 1x1 de documentos ubicados en ruta TXTUbicacion
                            {
                                newLine += arrayLine[t] + "|";
                            }
                            line = newLine;
                        }
                    }
                    else
                    {
                        string newLine = "";
                        string oldLine = line;
                        string[] arrayLine = oldLine.Split('|');
                        arrayLine[0] = fecha; //Fecha 1
                        arrayLine[5] = ConfigGlobal.SerieDae + "-" + numeroConDosCotas;
                        arrayLine[11] = "66666666666";
                        arrayLine[14] = "66666666666";
                       
                        for (int t = 0; t < arrayLine.Length - 1; t++)//Envio 1x1 de documentos ubicados en ruta TXTUbicacion
                        {
                            newLine += arrayLine[t] + "|";
                        }
                        line = newLine;
                    }
                    listLineas.Add(line);
                }
                string dataTxt = "";
                for (int t = 0; t < listLineas.ToArray().Length; t++)//Envio 1x1 de documentos ubicados en ruta TXTUbicacion
                {
                    dataTxt += listLineas.ToArray()[t] + Environment.NewLine;
                }
                if (System.IO.File.Exists(rutaSalida + nombreArchivo + "-Test" + ".txt"))
                {
                    System.IO.File.Delete(rutaSalida + nombreArchivo + "-Test" + ".txt");
                }
                System.IO.File.WriteAllText(rutaSalida + nombreArchivo + "-Test" + ".txt", dataTxt);
                rtb_Log.AppendText("Creado: " + nombreArchivo + "-Test" + Environment.NewLine);
                return rutaSalida + nombreArchivo + "-Test" + ".txt";
            }
        }

        private string obtieneFecha()
        {
            string año = DateTime.Now.Year.ToString();
            string mes1 = DateTime.Now.Month.ToString(), mes = "";
            string dia1 = DateTime.Now.Day.ToString(), dia = "";
            if (mes1.Length == 1)
            {
                mes = "0" + mes1;
            }
            else
            {
                mes = mes1;
            }

            if (dia1.Length == 1)
            {
                dia = "0" + dia1;
            }
            else
            {
                dia = dia1;
            }
            return año + "-" + mes + "-" + dia;
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            token = source.Token;
            if (lblDocEdicion.Text != "-")
            {
                FolderBrowserDialog dlCarpeta = new FolderBrowserDialog();
                dlCarpeta.RootFolder = System.Environment.SpecialFolder.Desktop;
                dlCarpeta.ShowNewFolderButton = false;
                dlCarpeta.Description = "Selecciona la carpeta";
                string rutaDestino = "";
                //(int Codigo, string Mensaje, string Documento) resp2;
                if (dlCarpeta.ShowDialog() == DialogResult.OK)
                {
                    rutaDestino = dlCarpeta.SelectedPath;
                }
                Task t1 = Task.Run(() => Descargas(rutaDestino), token);
                //Task.Factory.StartNew(() => method2(rutaDestino),token);
                //button3.Text = "Detener";
            }
        }

        public string[] LeerTxtRA(string ruta)
        {
            string line;
            List<String> ret = new List<string>();
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(ruta);
            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
                ret.Add(line);
            }
            file.Close();
            return ret.ToArray();
        }

        private void Descargas(string Ruta)
        {
            bool encendido = true;
            while (encendido)
            {
                (int Codigo, string Mensaje, string Docmumento) resp;
                if (lblDocEdicion.Text != "-")
                {
                    resp = DLL.EstatusDocumento(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, lblDocEdicion.Text);
                    if (resp.Codigo == 0)
                    {
                        Log("Documento aceptado, se procede con el/las descarga(s)", true, false);
                        try
                        {
                            //btnDescargaEjemplos.Enabled = true;
                            //tlp_archivos.Enabled = true;
                            //DirectoryInfo di = new DirectoryInfo(lst_archivo.Items[i].ToString());
                            string nombreXml = lblDocEdicion.Text;
                            string rutaDestino = "";
                            if (chckPDF.Checked)
                            {
                                string rutaPdf = Ruta + "\\" + nombreXml + ".pdf";
                                var respPdf = DLL.DescargaArchivos(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, lblDocEdicion.Text, "PDF");
                                if (respPdf.ArhivoBase64 != null)
                                {
                                    byte[] data = System.Convert.FromBase64String(respPdf.ArhivoBase64);
                                    File.WriteAllBytes(rutaPdf, data);
                                    Log("Se descarga " + rutaPdf, true, false);
                                }
                                else
                                {
                                    Log("No se puede descargar PDF del doc " + nombreXml, false, false);
                                }
                            }

                            if (chckXML.Checked)
                            {
                                string rutaPdf = Ruta + "\\" + nombreXml + ".xml";
                                var respPdf = DLL.DescargaArchivos(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, lblDocEdicion.Text, "XML");
                                if (respPdf.ArhivoBase64 != null)
                                {
                                    byte[] data = System.Convert.FromBase64String(respPdf.ArhivoBase64);
                                    File.WriteAllBytes(rutaPdf, data);
                                    Log("Se descarga " + rutaPdf, true, false);
                                }
                                else
                                {
                                    Log("No se puede descargar XML del doc " + nombreXml, false, false);
                                }
                            }

                            if (chckCDR.Checked)
                            {
                                string rutaPdf = Ruta + "\\" + nombreXml + ".zip";
                                var respPdf = DLL.DescargaArchivos(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, lblDocEdicion.Text, "CDR");
                                if (respPdf.ArhivoBase64 != null)
                                {
                                    byte[] data = System.Convert.FromBase64String(respPdf.ArhivoBase64);
                                    File.WriteAllBytes(rutaPdf, data);
                                    Log("Se descarga " + rutaPdf, true, false);
                                }
                                else
                                {
                                    Log("No se puede descargar CDR del doc " + nombreXml, false, false);
                                }
                            }

                            if (chckTXT.Checked)
                            {
                                try
                                {
                                    string rutaTxt = Ruta + "\\" + lblDocEdicion.Text + "-Test.txt";

                                    if (File.Exists(rutaTxt))
                                    {
                                        File.Delete(rutaTxt);
                                    }
                                    string rutaOriginal = ConfigPerso.RutaEjemplosProcesados;
                                    File.Copy(RutaArchivoEnviarGlobal, rutaTxt);
                                    Log("Se descarga " + rutaDestino + @"\" + nombreXml + ".txt", true, false);
                                    //MensajeTipos += Environment.NewLine + "- TXT";

                                }
                                catch (Exception ff)
                                {
                                    Log("No se puede descargar TXT del doc " + nombreXml + ".txt", false, false);
                                }
                            }

                            if (chckRequest.Checked)
                            {
                                try
                                {
                                    string rutaReq1 = Ruta + "\\" + nombreXml + "_requestSinEditar.xml";
                                    string rutaReq2 = Ruta + "\\" + nombreXml + "_request.xml";
                                    string rutaOriginal = Path.GetDirectoryName(lst_archivo.Items[0].ToString() + "\\" + lblDocEdicion);
                                    request.GenerarRequest(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, rutaOriginal, rutaReq1);
                                    ObtenerRequest(rutaReq1, rutaReq2);
                                    Log("Se descarga " + rutaReq2, true, false);
                                }catch(Exception ex)
                                {
                                    Log("No se puede descargar Request del doc " + nombreXml, false, false);
                                }
                            }

                            encendido = false;
                            if (Directory.Exists(Ruta + "\\"))
                            {
                                System.Diagnostics.Process.Start("explorer.exe", Ruta);
                            }

                           
                        }
                        catch (Exception ew)
                        {
                            encendido = false;
                            Log(ew.Message + " " + lblDocEdicion.Text, false, false);
                        }
                    }
                    else if (resp.Codigo != 99)
                    {
                        Log("Documento aun no aceptado. En 25 segundos se realizara nuevamente la consulta", true, false);
                    }
                    else
                    {
                           Log("Documento rechazado: " + resp.Codigo + "-" + resp.Mensaje, false, false);
                    }

                }
                else
                {
                    MessageBox.Show("Para proceder con esta funcion, el documento debe estar aceptado por el servicio PSE");
                    encendido = false;
                }
                Thread.Sleep(25000);
            }

        }

        public string ComprimirArchivo(string rutaXML, string nombreArchivo, string rutaZIP)
        {
            if (Directory.Exists(".\\Procesados\\toZip\\"))
            {
                Directory.Delete(".\\Procesados\\toZip\\",true);
            }
            Directory.CreateDirectory(".\\Procesados\\toZip\\");
            File.Copy(rutaXML, ".\\Procesados\\toZip\\" + nombreArchivo);

            //string directotorioDestino = ".\\" + nombreArchivo.Split('.')[0] + ".zip";
            // verificar si existe el archivo y borrarlo para sobre escribirlo
            if (File.Exists(rutaZIP))
            {
                File.Delete(rutaZIP);
            }
            //Comprimir
            ZipFile.CreateFromDirectory(Path.GetDirectoryName(".\\Procesados\\toZip\\" + nombreArchivo), rutaZIP);
            //File.Move(directotorioDestino, rutaComprimir + Path.GetFileNameWithoutExtension(nombreArchivo) + ".zip");            
            //Log("Ruta ZIP Firmado: " + rutaZIP, true, false);
            return rutaZIP;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBorrarLog_Click(object sender, EventArgs e)
        {
            rtb_Log.Clear();
        }

        public string DescomprimirArchivo(string RutaComprimido)
        {
            string RutaDescomprimido = Path.GetDirectoryName(RutaComprimido) + "\\unZip\\";
            string NombreArchivo = Path.GetFileNameWithoutExtension(RutaComprimido);

            if (!Directory.Exists(RutaDescomprimido))
            {
                Directory.CreateDirectory(RutaDescomprimido);
            }
            if (Directory.Exists(RutaDescomprimido + "\\" + Path.GetFileNameWithoutExtension(NombreArchivo)))
            {
                Directory.Delete(RutaDescomprimido + "\\" + Path.GetFileNameWithoutExtension(NombreArchivo), true);
            }
            ZipFile.ExtractToDirectory(RutaComprimido, RutaDescomprimido + "\\" + Path.GetFileNameWithoutExtension(NombreArchivo));

            return RutaDescomprimido + Path.GetFileNameWithoutExtension(NombreArchivo) + "\\R-" + NombreArchivo + ".xml";
        }

        private string LeerCDR(string path)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode nodoResponse = doc.DocumentElement.LastChild;
                string respuestaSunatCodigo = "";
                string respuestaSunatDesc = "";
                string respuestaSunatObs = " SIN OBS.";

                foreach (XmlNode node in nodoResponse.ChildNodes)
                {
                    if (node.Name == "cac:Response")
                    {
                        var nodosHijos = node;
                        foreach (XmlNode node2 in nodosHijos.ChildNodes)
                        {
                            if (node2.Name == "cbc:ResponseCode")
                            {
                                respuestaSunatCodigo = node2.FirstChild.Value;
                            }
                            else if (node2.Name == "cbc:Description")
                            {
                                respuestaSunatDesc = node2.FirstChild.Value;
                            }
                        }
                        if (nodosHijos.LastChild.Name == "cac:Status")
                        {
                            respuestaSunatObs = " CON OBS.";
                        }
                    }
                }

                XmlNodeList nodoResponse2 = doc.GetElementsByTagName("cbc:Note");
                if(nodoResponse2.Count == 0)
                {

                }
                else
                {
                    respuestaSunatObs = " CON OBS.";
                }     

                return respuestaSunatCodigo + "|" + respuestaSunatDesc + "|" + respuestaSunatObs;
            }
            catch (Exception ex)
            {
                return "9999|-|-";
            }
        }
    }
}
