using DLL_Online.Metodos;
using Facturantes;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Tools.PSE21;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace Tools
{
    public partial class FrmEjemplos : Form
    {
        DataTable dt7;
        String rutaEjemplos = "", rutaEjemplosProcesados = "", rutaDrive = "", nombreEjemplosGlobal, nombreRealEjemplosGlobal, tipoNota = "";
        bool ambienteDemo = true, pruebaDocEjemploActivo = false, ejecutarTask = true;
        CancellationToken token;
        DLL_Online.Metodos.Facturacion DllG1 = new DLL_Online.Metodos.Facturacion();
        DLL_Online.Metodos.Dae_DinersClub DllG2 = new Dae_DinersClub();
        LeerConfigPersonal ConfigPerso = new LeerConfigPersonal();
        LeerConfig ConfigGlobal = new LeerConfig();
        bool aceptadoEdicionGlobal;
        Color colorAceptados;
        DLL_Online.Metodos.Request request = new DLL_Online.Metodos.Request();
        string MensajeTipos = "";

        public FrmEjemplos(Color color1, Color color2, Color color3, Color color4)
        {
            InitializeComponent();          
            btnDescargaEjemplos.BackColor = color1;
            btnProbarTodos.BackColor = color1;
            colorAceptados = color1;
            this.dtgEjemplos.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dtgEjemplos.DefaultCellStyle.SelectionBackColor = color2;
            this.dtgEjemplos.ColumnHeadersDefaultCellStyle.SelectionBackColor = color2;         
            lbl_Log.ForeColor = color1;
            btnBorrarLog.IconColor = color1;
            rtb_Log.ForeColor = color1;
            rtb_Log.ReadOnly = true;
            gbAcciones.ForeColor = color1;
            gbFiltros.ForeColor = color1;

        }

        public void cargaDrive()
        {
            try
            {
                string nombre = "GoogleDriveFS";
                string currPrsName = Process.GetCurrentProcess().ProcessName;
                Process[] allProcessWithThisName
                             = Process.GetProcessesByName(nombre);
                if (allProcessWithThisName.Length > 1)
                {
                    foreach (Process proceso in Process.GetProcesses())
                    {
                        if (proceso.ProcessName == nombre)
                        {
                            proceso.Kill();
                        }
                    }
                }
                System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
                start.FileName = ConfigPerso.RutaDrive;
                start.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                System.Diagnostics.Process.Start(start);
                Thread.Sleep(5000);
            }catch(Exception ex)
            {
                MessageBox.Show("Verifica la ruta de tu google Drive, la sgte. ruta no existe: " + ConfigPerso.RutaDrive);
            }
                    
        }

        private void FrmEjemplos_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            pnlDescargas.Visible = false;          
            cargaCmbDoc();
            LeerDll();
        }
             

        public void cargaCmbDoc()
        {
            try
            {
                string[] entries = Directory.GetFileSystemEntries(ConfigPerso.RutaEjemplos, "*", SearchOption.TopDirectoryOnly);

                foreach (var file in entries)
                {
                    if (Path.GetFileName(file) != "desktop.ini" && Path.GetFileName(file) != "Tool")
                    {
                        cmbTipoDoc.Items.Add(Path.GetFileName(file));
                    }
                    //MessageBox.Show(Path.GetFileName(file));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void dtgEjemplos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!pruebaDocEjemploActivo && e.RowIndex >= 0 && e.RowIndex + 1 < dtgEjemplos.RowCount)
                {
                    string columna = dtgEjemplos.Columns[e.ColumnIndex].Name;

                    if (columna == "ACCION") // Eliminar
                    {
                        string AmbienteGlobal = LeerDll();
                        Log("--------- Envío a PSE " + AmbienteGlobal + " ---------", true, false);

                        btnProbarTodos.Enabled = false;
                        btnDescargas.Enabled = false;
                        tlp_archivos.Enabled = false;
                        pruebaDocEjemploActivo = true;
                        nombreEjemplosGlobal = "";
                        nombreRealEjemplosGlobal = "";

                        PruebaEjemplo pruebaEjemplo = new PruebaEjemplo();
                        pruebaEjemplo.EliminaProcesados();
                        string nombreArchivoTxt = dtgEjemplos.Rows[e.RowIndex].Cells[1].Value.ToString();
                        string rutaRaiz = ConfigPerso.RutaEjemplos + cmbTipoDoc.Text + @"\" + nombreArchivoTxt;

                        string ArchivoAEnviar = pruebaEjemplo.CambiaContenidoTxt(nombreArchivoTxt, rutaRaiz);
                        rtb_Log.AppendText("Creado: " + ArchivoAEnviar + Environment.NewLine);

                        string NombreArchivo = Path.GetFileName(ArchivoAEnviar);
                        var Respuesta = pruebaEjemplo.Enviar(NombreArchivo, ArchivoAEnviar);
                        Log("Enviado: " + NombreArchivo + " --> "  +  Respuesta.Codigo + " --> " + Respuesta.Mensaje + " --> Doc real (" + Respuesta.Documento + ")", true, false);


                        if (Respuesta.Codigo == 0)
                        {
                            aceptadoEdicionGlobal = true;
                            nombreEjemplosGlobal = NombreArchivo;
                            nombreRealEjemplosGlobal = Respuesta.Documento;
                            dtgEjemplos.Rows[e.RowIndex].Cells[2].Value = Respuesta.Codigo + "|" + Respuesta.Mensaje;
                            dtgEjemplos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = colorAceptados;
                            Task t1 = Task.Run(() => ProcesaIndividual(Respuesta.Documento.ToString(), e.RowIndex), token);
                        }
                        else
                        {
                            dtgEjemplos.Rows[e.RowIndex].Cells[2].Value = Respuesta.Codigo + "|" + Respuesta.Mensaje;
                            dtgEjemplos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                            aceptadoEdicionGlobal = false;
                            pruebaDocEjemploActivo = false;
                        }                     
                        Log("--------- Fin Envío a PSE " + AmbienteGlobal + " ---------", true, false);
                    }
                    else
                    {
                        if (MessageBox.Show("Deseas abrir el TXT con el Editor de Texto predeterminado?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            string nombreArchivoTxt = dtgEjemplos.Rows[e.RowIndex].Cells[1].Value.ToString();
                            rutaEjemplos = ConfigPerso.RutaEjemplos;
                            string ruta = rutaEjemplos + cmbTipoDoc.Text + "\\" + nombreArchivoTxt;
                            if (File.Exists(ruta))
                            {
                                Process.Start(ruta);
                            }
                        }
                    }

                }
                else
                {
                    if (e.RowIndex >= 0)
                    {
                        MessageBox.Show("Por favor espera que se termine la prueba anterior. Revisa el Log");
                    }
                }
            }
            catch (Exception ex)
            {
                pruebaDocEjemploActivo = false;
                MessageBox.Show(ex.Message);
            }
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
        }

        public void CargaDtgUsuario()
        {
            dtgEjemplos.Columns.Clear();
            dt7 = new DataTable();
            dt7.Columns.Add("DETALLE");
            dt7.Columns.Add("NOMBRE");
            dt7.Columns.Add("ESTADO");

            string[] entries = null;           
            entries = Directory.GetFileSystemEntries(ConfigPerso.RutaEjemplos + cmbTipoDoc.Text + "\\", "*", SearchOption.TopDirectoryOnly);


            for (int i = 0; i < entries.Length; i++)
            {
                if (entries[i].IndexOf('_') > 0)
                {
                    DataRow row7 = dt7.NewRow();
                    if(entries[i].Contains("DAE"))
                    {
                        row7["DETALLE"] = entries[i].Split('_')[2];
                    }
                    else
                    {
                        row7["DETALLE"] = entries[i].Split('_')[1];
                    }
                    row7["NOMBRE"] = Path.GetFileName(entries[i]);
                    row7["ESTADO"] = "-";
                    dt7.Rows.Add(row7);
                    btnProbarTodos.Enabled = true;
                    //btnDescargas.Enabled = true;
                }
            }
            dtgEjemplos.DataSource = dt7;
            var num = dtgEjemplos.Size.Width / 7;
            dtgEjemplos.Columns[0].Width = num * 4;
            dtgEjemplos.Columns[1].Width = num;
            dtgEjemplos.Columns[2].Width = num * 2;
            this.dtgEjemplos.Columns["NOMBRE"].Visible = false;

            //dtgEjemplos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgEjemplos.ReadOnly = true;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dtgEjemplos.Columns.Add(btn);
            btn.Text = "Enviar";
            btn.Name = "ACCION";
            btn.Width = 65;
            btn.UseColumnTextForButtonValue = true;

        }
               
        private void cmbTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaDtgUsuario();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chckTodo.Checked)
            {
                chckCdrEjemplos.Checked = true;
                chckPdfEjemplos.Checked = true;
                chckXmlEjemplos.Checked = true;
                chckRequestEjemplos.Checked = true;
                chckTxtEjemplos.Checked = true;
                chckSpeech.Checked = true;
                chckJsonEjemplos.Checked = true;

            }
            else
            {
                chckCdrEjemplos.Checked = false;
                chckPdfEjemplos.Checked = false;
                chckXmlEjemplos.Checked = false;
                chckRequestEjemplos.Checked = false;
                chckTxtEjemplos.Checked = false;
                chckSpeech.Checked = false;
                chckJsonEjemplos.Checked = false;

            }

        }

        private void btnDescargas_SliderValueChanged(object sender, EventArgs e)
        {
            if (pnlDescargas.Visible == true)
            {
                pnlDescargas.Visible = false;
            }
            else
            {
                pnlDescargas.Visible = true;
            }          
        }

        private void txtBusquedaEjemplo_TextChanged(object sender, EventArgs e)
        {
            string filterField = "DETALLE";
            ((DataTable)dtgEjemplos.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, txtBusquedaEjemplo.Text);
        }

        private CancellationTokenSource miToken = new CancellationTokenSource();

        private void btnProbarTodos_Click(object sender, EventArgs e)
        {

            Task t1;

            if(btnProbarTodos.Text == "Iniciar prueba masiva")
            {
                if (MessageBox.Show("Seguro que desea Iniciar las pruebas masivas?", "Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ejecutarTask = true;
                    btnProbarTodos.Text = "Detener prueba masiva";
                    //btnProbarTodos.Enabled = false;
                    btnDescargas.Enabled = false;
                    t1 = Task.Run(() => EnvioPSE());
                }
            }
            else
            {
                if (MessageBox.Show("Seguro que desea Cancelar las pruebas masivas?", "Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ejecutarTask = false;
                    btnProbarTodos.Text = "Iniciar prueba masiva";
                }
                  
                //btnProbarTodos.Enabled = true;
            }

        }              
       
        private void btnDescargaEjemplos_Click(object sender, EventArgs e)
        {
            MensajeTipos = "";
            bool PDF = false, CDR = false, XML = false, Request = false, TXT = false;
            FolderBrowserDialog dlCarpeta = new FolderBrowserDialog();
            dlCarpeta.RootFolder = System.Environment.SpecialFolder.Desktop;
            dlCarpeta.ShowNewFolderButton = false;
            dlCarpeta.Description = "Selecciona la carpeta";
            string rutaDestino = "";
            //(int Codigo, string Mensaje, string Documento) resp2;
            if (dlCarpeta.ShowDialog() == DialogResult.OK)
            {
                rutaDestino = dlCarpeta.SelectedPath;
                if (chckPdfEjemplos.Checked)
                {
                    string rutaPdf = rutaDestino + "\\" + nombreEjemplosGlobal + ".pdf";
                    string respPdf = "";

                    if (nombreRealEjemplosGlobal.Split('-')[0] == "20550728762")
                    {
                        respPdf = DllG1.DescargaArchivos(ConfigGlobal.Ruc2, ConfigGlobal.UserRuc2, ConfigGlobal.PassRuc2, nombreRealEjemplosGlobal, "PDF").ArhivoBase64;
                    }
                    else
                    {
                        respPdf = DllG1.DescargaArchivos(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, nombreRealEjemplosGlobal, "PDF").ArhivoBase64;
                    }
                     
                    if (respPdf != null)
                    {
                        byte[] data = System.Convert.FromBase64String(respPdf);
                        File.WriteAllBytes(rutaPdf, data);
                        Log("Se descarga " + rutaPdf, true, false);
                        MensajeTipos += Environment.NewLine + "- PDF";
                    }
                    else
                    {
                        Log("No se puede descargar PDF del doc " + nombreEjemplosGlobal, false, false);
                    }

                }

                if (chckXmlEjemplos.Checked)
                {
                    string rutaPdf = rutaDestino + "\\" + nombreEjemplosGlobal + ".xml";
                    string respPdf = "";
                    if (nombreRealEjemplosGlobal.Split('-')[0] == "20550728762")
                    {
                        respPdf = DllG1.DescargaArchivos(ConfigGlobal.Ruc2, ConfigGlobal.UserRuc2, ConfigGlobal.PassRuc2, nombreRealEjemplosGlobal, "XML").ArhivoBase64;
                    }
                    else
                    {
                        respPdf = DllG1.DescargaArchivos(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, nombreRealEjemplosGlobal, "XML").ArhivoBase64;
                    }


                    if (respPdf != null)
                    {
                        byte[] data = System.Convert.FromBase64String(respPdf);
                        File.WriteAllBytes(rutaPdf, data);
                        Log("Se descarga " + rutaPdf, true, false);
                        MensajeTipos += Environment.NewLine + "- XML";

                    }
                    else
                    {
                        Log("No se puede descargar XML del doc " + nombreEjemplosGlobal, false, false);
                    }

                }

                if (chckCdrEjemplos.Checked)
                {
                    string rutaPdf = rutaDestino + "\\" + nombreEjemplosGlobal + ".zip";
                    string respPdf = "";
                    if (nombreRealEjemplosGlobal.Split('-')[0] == "20550728762")
                    {
                        respPdf = DllG1.DescargaArchivos(ConfigGlobal.Ruc2, ConfigGlobal.UserRuc2, ConfigGlobal.PassRuc2, nombreRealEjemplosGlobal, "CDR").ArhivoBase64;
                    }
                    else
                    {
                        respPdf = DllG1.DescargaArchivos(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, nombreRealEjemplosGlobal, "CDR").ArhivoBase64;
                    }


                    if (respPdf != null)
                    {
                        byte[] data = System.Convert.FromBase64String(respPdf);
                        File.WriteAllBytes(rutaPdf, data);
                        Log("Se descarga " + rutaPdf, true, false);
                        MensajeTipos += Environment.NewLine + "- CDR";

                    }
                    else
                    {
                        Log("No se puede descargar CDR del doc " + nombreEjemplosGlobal, false, false);
                    }
                }

                if (chckTxtEjemplos.Checked)
                {
                    try
                    {
                        if (File.Exists(rutaDestino + @"\" + nombreEjemplosGlobal))
                        {
                            File.Delete(rutaDestino + @"\" + nombreEjemplosGlobal);
                        }
                        string rutaOriginal = ConfigPerso.RutaEjemplosProcesados;
                        File.Copy(rutaOriginal + nombreEjemplosGlobal, rutaDestino + @"\" + nombreEjemplosGlobal);
                        Log("Se descarga " + rutaDestino + @"\" + nombreEjemplosGlobal, true, false);
                        MensajeTipos += Environment.NewLine + "- TXT";

                    }
                    catch (Exception ff)
                    {
                        Log("No se puede descargar TXT del doc " + nombreEjemplosGlobal, false, false);
                    }
                }

                if (chckRequestEjemplos.Checked)
                {
                    ReconstruirRequest req = new ReconstruirRequest();
                    string respPdf = "";
                    if (nombreRealEjemplosGlobal.Split('-')[0] == "20550728762")
                    {
                        string rutaOriginal = ConfigPerso.RutaEjemplosProcesados + nombreEjemplosGlobal;
                        request.GenerarRequest(ConfigGlobal.Ruc2, ConfigGlobal.UserRuc2, ConfigGlobal.PassRuc2, rutaOriginal, ConfigPerso.RutaEjemplosProcesados + nombreEjemplosGlobal + "_request.xml");
                        req.ObtenerRequestGR(ConfigPerso.RutaEjemplosProcesados + nombreEjemplosGlobal + "_request.xml", rutaDestino + "\\" + nombreEjemplosGlobal + ". Request.xml");
                        MensajeTipos += Environment.NewLine + "- REQUEST";
                    }
                    else
                    {
                        string rutaOriginal = ConfigPerso.RutaEjemplosProcesados + nombreEjemplosGlobal;
                        request.GenerarRequest(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, rutaOriginal, ConfigPerso.RutaEjemplosProcesados + nombreEjemplosGlobal + "_request.xml");
                        req.ObtenerRequest(ConfigPerso.RutaEjemplosProcesados + nombreEjemplosGlobal + "_request.xml", rutaDestino + "\\" + nombreEjemplosGlobal + ". Request.xml");
                        MensajeTipos += Environment.NewLine + "- REQUEST";
                    }
                }

                if (chckJsonEjemplos.Checked)
                {
                    string rutaPdf = rutaDestino + "\\" + nombreEjemplosGlobal + ".json";
                    string respPdf = "";

                    if (nombreRealEjemplosGlobal.Split('-')[0] == "20550728762")
                    {
                        respPdf = DllG1.DescargaArchivos(ConfigGlobal.Ruc2, ConfigGlobal.UserRuc2, ConfigGlobal.PassRuc2, nombreRealEjemplosGlobal, "JSON").ArhivoBase64;
                    }
                    else
                    {
                        respPdf = DllG1.DescargaArchivos(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, nombreRealEjemplosGlobal, "JSON").ArhivoBase64;
                    }

                    if (respPdf != null)
                    {
                        byte[] data = System.Convert.FromBase64String(respPdf);
                        File.WriteAllBytes(rutaPdf, data);
                        Log("Se descarga " + rutaPdf, true, false);
                        MensajeTipos += Environment.NewLine + "- JSON";
                    }
                    else
                    {
                        Log("No se puede descargar JSON del doc " + nombreEjemplosGlobal, false, false);
                    }

                }

                if (chckSpeech.Checked)
                {
                    SpeechBaja();
                }
                

                if (Directory.Exists(rutaDestino + "\\"))
                {
                    System.Diagnostics.Process.Start("explorer.exe", rutaDestino);
                }
            }
        }

        private void SpeechBaja()
        {
            string Cabecera = Environment.NewLine + "Speech para correo:" + Environment.NewLine  + "-------------------" + Environment.NewLine + Environment.NewLine
                       + "Estimado cliente, se adjunta: " + MensajeTipos + Environment.NewLine + "Documento que servirá de ejemplo y posee aceptación en Demo." + Environment.NewLine + Environment.NewLine + "Saludos Cordiales.";
           
            rtb_Log.AppendText(Cabecera);
        }           

        private void btnBorrarLog_Click_1(object sender, EventArgs e)
        {
            rtb_Log.Clear();
        }

        public void EnvioPSE()
        {
            string AmbienteGlobal = LeerDll();
            PruebaEjemplo pruebaEjemplo = new PruebaEjemplo();
            //bool LogFechaHora = false;
            if (AmbienteGlobal == "DEMO")
            {
                Log("--------- Envío a PSE DEMO masivo ---------", true, false);
            }
            else
            {
                Log("--------- Envío a PSE PRD masivo ---------", true, false);
            }
            (string documentoInterno, int index) Doc;
            List<(string doc, int index)> lstDocs = new List<(string, int)>();
            for (int i = 0; i < dtgEjemplos.RowCount - 1; i++)
            {
                if (ejecutarTask)
                {
                    string rutaRaiz = ConfigPerso.RutaEjemplos + cmbTipoDoc.Text + @"\" + dtgEjemplos.Rows[i].Cells[1].Value.ToString();
                    string nombreArchivoOriginal = dtgEjemplos.Rows[i].Cells[1].Value.ToString();
                    string ArchivoAEnviar = pruebaEjemplo.CambiaContenidoTxt(nombreArchivoOriginal, rutaRaiz);
                    string NombreArchivoaEnviar = Path.GetFileName(ArchivoAEnviar);
                    (int Codigo, string Mensaje, string Documento) resp = pruebaEjemplo.Enviar(NombreArchivoaEnviar, ArchivoAEnviar);
                    dtgEjemplos.Rows[i].Cells[2].Value = resp.Codigo + "|" + resp.Mensaje;
                    bool msj = false;

                    if (resp.Codigo == 0)
                    {
                        msj = true;
                        Doc.documentoInterno = resp.Documento;
                        Doc.index = i;
                        lstDocs.Add(Doc);
                    }
                    Log("Enviado: " + NombreArchivoaEnviar + " (" + resp.Documento + "): " + resp.Codigo + "|" + resp.Mensaje, true, false);
                }
            }
            Log("--------- Fin Envio a PSE masivo ---------", true, false);


            var arrayAceptados = lstDocs.ToArray();
            for (int i = 0; i < arrayAceptados.Length; i++)
            {
                ProcesaIndividual(arrayAceptados[i].doc, arrayAceptados[i].index);
            }





            //if (!ejecutarTask)
            //    Log("--------- Proceso DETENIDO ---------", true, false);

            //Log("--------- Consulta estatus Sunat/Ose ---------", true, false);
            //(string nombreTxt, string documentoInterno, string status, int index)[] arrayDocs = lstDocs.ToArray();
            //if (AmbienteGlobal == "PRD")
            //{
            //    Log("Se detiene la consulta debido a que nunca obtendra aceptación en PRD", true, false);
            //}
            //else
            //{
            //    for (int i = 0; i < arrayDocs.Length; i++)
            //    {
            //        if (ejecutarTask)
            //        {
            //            bool encendido = true;
            //            (int Codigo, string Mensaje, string Documento) resp2;
            //            resp2.Codigo = 911;
            //            resp2.Mensaje = "911";
            //            while (encendido)
            //            {
            //                if (arrayDocs[i].documentoInterno.Split('-')[0] == "20550728762")
            //                {
            //                    resp2 = DllG1.EstatusDocumento(ConfigGlobal.Ruc2, ConfigGlobal.UserRuc2, ConfigGlobal.PassRuc2, arrayDocs[i].documentoInterno);
            //                }
            //                else
            //                {
            //                    resp2 = DllG1.EstatusDocumento(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, arrayDocs[i].documentoInterno);
            //                }

            //                if (resp2.Codigo == 0)
            //                {
            //                    encendido = false;
            //                    arrayDocs[i].status = resp2.ToString();
            //                }
            //                else if (resp2.Codigo != 95)
            //                {
            //                    encendido = false;
            //                    arrayDocs[i].status = resp2.ToString();
            //                }
            //                else
            //                {
            //                    Log("Se esperan 25 segundos para consultar el status de los documentos", true, false);
            //                    Thread.Sleep(25000);
            //                }
            //            }
            //            bool msj = false;
            //            //string cdrContenido = "";
            //            if (resp2.Codigo == 0)
            //            {
            //                msj = true;
            //                (int Codigo, string Mensaje, string Docmumento, string ArhivoBase64) respDescarga;

            //                if (arrayDocs[i].documentoInterno.Split('-')[0] == "20550728762")
            //                {
            //                    respDescarga = DllG1.DescargaArchivos(ConfigGlobal.Ruc2, ConfigGlobal.UserRuc2, ConfigGlobal.PassRuc2, arrayDocs[i].documentoInterno, "CDR");
            //                }
            //                else
            //                {
            //                    respDescarga = DllG1.DescargaArchivos(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, arrayDocs[i].documentoInterno, "CDR");
            //                }

            //                if (respDescarga.ArhivoBase64 != null)
            //                {
            //                    byte[] data = System.Convert.FromBase64String(respDescarga.ArhivoBase64);
            //                    File.WriteAllBytes(ConfigPerso.RutaEjemplosProcesados + arrayDocs[i].documentoInterno + ".zip", data);
            //                }

            //                LecturaCdr cdr = new LecturaCdr();
            //                var cdrContenido2 = cdr.LeerCDR(DescomprimirArchivo(ConfigPerso.RutaEjemplosProcesados + arrayDocs[i].documentoInterno + ".zip"));
            //                Log("Status del doc " + arrayDocs[i].nombreTxt + " (" + arrayDocs[i].documentoInterno + ") --> " + cdrContenido2[0].Split('|')[2], true, false);
            //                //Log("Documento " + numeracion + " aceptado, " + cdrContenido[0].Split('|')[2] + ".", true, false);
            //                if (cdrContenido2.Length > 1)
            //                {
            //                    for (int k = 0; k < cdrContenido2.Length - 1; k++)
            //                    {
            //                        Log("OBS " + cdrContenido2[k + 1], true, false);
            //                    }
            //                }

            //                //cdrContenido = LeerCDR(DescomprimirArchivo(ConfigPerso.RutaEjemplosProcesados + arrayDocs[i].documentoInterno + ".zip"));
            //                //Log("Documento " + numeracion + " aceptado, " + cdrContenido.Split('|')[2] + ".", true, false);

            //            }
            //            //Log("Status del doc " + arrayDocs[i].nombreTxt + " (" + arrayDocs[i].documentoInterno + ") --> " + cdrContenido, true, false);
            //            //dtgEjemplos.Rows[i].Cells[2].Value = resp2.Codigo;
            //            dtgEjemplos.Rows[i].Cells[2].Value = resp2.Codigo + "|" + resp2.Mensaje;
            //            foreach (DataGridViewRow dgvr in dtgEjemplos.Rows)
            //            {
            //                if (dgvr.Cells[2].Value != null)
            //                {
            //                    if (dgvr.Cells[2].Value.ToString().Split('|')[0] != "0")
            //                    {
            //                        dgvr.DefaultCellStyle.ForeColor = Color.Red;
            //                    }
            //                    else
            //                    {
            //                        dgvr.DefaultCellStyle.ForeColor = colorAceptados;
            //                    }
            //                }
            //            }
            //        }

            //    }

            //}

            //Log("--------- Fin Consulta estatus Sunat/Ose ---------", true, false);
            //if (!ejecutarTask)
            //    Log("--------- Proceso DETENIDO ---------", true, false);
            //btnProbarTodos.Enabled = true;
            //btnDescargas.Enabled = true;

        }               
      
        private void ProcesaIndividual(string numeracion, int index)
        {
            string AmbienteGlobal = LeerDll();
            Log("--------- Consulta estatus Sunat/Ose " + AmbienteGlobal + " ---------", true, false);
            PruebaEjemplo pruebaEjemplo = new PruebaEjemplo();
            var resp = pruebaEjemplo.ProcesaIndividual(numeracion, index);

            if (resp.Codigo == 0)
            {
                tlp_archivos.Enabled = true;
                btnDescargas.Enabled = true;
                dtgEjemplos.Rows[index].Cells[2].Value = resp.Codigo + "|" + resp.Mensaje;
                dtgEjemplos.Rows[index].DefaultCellStyle.ForeColor = colorAceptados;
                Log("Documento " + numeracion + " aceptado. " + Environment.NewLine + resp.Observacion, true, false);
            }
            else
            {
                Log("Documento  " + numeracion + " rechazado: " + resp.Codigo + "-" + resp.Mensaje, false, false);
                dtgEjemplos.Rows[index].Cells[2].Value = resp.Codigo + "|" + resp.Mensaje;
                dtgEjemplos.Rows[index].DefaultCellStyle.ForeColor = Color.Red;
            }

            pruebaDocEjemploActivo = false;
            btnProbarTodos.Enabled = true;
            Log("--------- Fin Consulta estatus Sunat/Ose " + AmbienteGlobal + "---------", true, false);
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

    }
}
