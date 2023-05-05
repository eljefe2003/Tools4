using DLL_Online.Metodos;
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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace Tools
{
    public partial class FrmEjemplos : Form
    {
        DataTable dt7;
        String rutaEjemplos = "", rutaEjemplosProcesados = "", rutaDrive = "", nombreEjemplosGlobal, nombreRealEjemplosGlobal, tipoNota = "";
        bool ambienteDemo = true, pruebaDocEjemploActivo = false;
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
            tlpLog.BackColor = color1;
            rtb_Log.BackColor = color1;
            rtb_Log.ForeColor = color2;
            lbl_Log.ForeColor = color2;
            btnDescargaEjemplos.BackColor = color1;
            btnProbarTodos.BackColor = color1;
            colorAceptados = color1;

            //tlpForm.BackColor = Color.White;

            //rtbDaily.BackColor = color2;
            //gbFiltros.ForeColor = color1;
            //lblFormato.ForeColor = color1;


            //rtb_Log.ForeColor = color2;
            //lbl_Log.ForeColor = color2;
            //tlpLog.BackColor = color1;
            //rtb_Log.BackColor = color1;
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
            //leerConfigPersonal();
            cargaDrive();
            //LeerConfig();
            cargaCmbDoc();
            LeerDll();
        }

        public void IniciaDrive()
        {
            System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
            start.FileName = @"C:\xampp\xampp_start.exe";
            start.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden; //Hides GUI start.CreateNoWindow = true; //Hides console
            System.Diagnostics.Process.Start(start);
            //System.Diagnostics.ProcessWindowStyle.Hidden;

            //System.Diagnostics.Process.Start(@"C:\xampp\xampp_start.exe");
            Thread.Sleep(5000);           
        }

        //private void LeerConfig()
        //{
        //    try
        //    {        
        //        ruc = ConfigurationManager.AppSettings["Ruc"];
        //        userRuc = ConfigurationManager.AppSettings["Usuario"];
        //        string ambiente = LeerDll();
        //        if (ambiente == "DEMO")
        //        {
        //            serieFact = ConfigurationManager.AppSettings["FactDemo"];
        //            serieBol = ConfigurationManager.AppSettings["BolDemo"];
        //            serieNC = ConfigurationManager.AppSettings["NCDemo"];
        //            serieND = ConfigurationManager.AppSettings["NDDemo"];
        //            serieGuia = ConfigurationManager.AppSettings["GuiaDemo"];
        //            serieDae = ConfigurationManager.AppSettings["DaeDemo"];
        //            serieRet = ConfigurationManager.AppSettings["RetDemo"]; 
        //            seriePer = ConfigurationManager.AppSettings["PercDemo"];
        //            ruc = ConfigurationManager.AppSettings["Ruc"];
        //            userRuc = ConfigurationManager.AppSettings["Usuario"];
        //            passRuc = ConfigurationManager.AppSettings["Clave"];
        //            ambienteDemo = true;
        //        }
        //        else
        //        {
        //            serieFact = ConfigurationManager.AppSettings["FactPRD"];
        //            serieBol = ConfigurationManager.AppSettings["BolPRD"];
        //            serieNC = ConfigurationManager.AppSettings["NCPRD"];
        //            serieND = ConfigurationManager.AppSettings["NDPRD"];
        //            serieGuia = ConfigurationManager.AppSettings["GuiaPRD"];
        //            serieDae = ConfigurationManager.AppSettings["DaePRD"];
        //            serieRet = ConfigurationManager.AppSettings["RetPRD"];
        //            seriePer = ConfigurationManager.AppSettings["PercPRD"];
        //            passRuc = ConfigurationManager.AppSettings["Clave"];
        //            ruc = ConfigurationManager.AppSettings["RucPRD"];
        //            userRuc = ConfigurationManager.AppSettings["UsuarioPRD"];
        //            passRuc = ConfigurationManager.AppSettings["ClavePRD"];
        //            ambienteDemo = false;
        //        }
        //        //string rutaEjemplosProcesados = ConfigurationManager.AppSettings["RutaEjemplosProcesados"];
        //        //txtRutaProcesados.Text = rutaEjemplosProcesados;
        //        //if (!Directory.Exists(rutaEjemplosProcesados))
        //        //{
        //        //    Directory.CreateDirectory(rutaEjemplosProcesados);
        //        //}
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}

        private void btnDescargas_Click(object sender, EventArgs e)
        {
            //if(pnlDescargas.Visible == true)
            //{
            //    pnlDescargas.Visible = false;
            //}
            //else
            //{
            //    pnlDescargas.Visible = true;
            //}
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
            }catch(Exception ex)
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
                    if (dtgEjemplos.Columns[e.ColumnIndex].Name == "ACCION") // Eliminar
                    {
                        string AmbienteGlobal = LeerDll();                       
                        Log("--------- Envío a PSE " + AmbienteGlobal + "---------", true, false);
                        btnProbarTodos.Enabled = false;
                        btnDescargas.Enabled = false;
                        //btnDescargaEjemplos.Enabled = false;
                        tlp_archivos.Enabled = false;
                        pruebaDocEjemploActivo = true;
                        nombreEjemplosGlobal = "";
                        nombreRealEjemplosGlobal = "";
                        List<string> strFiles = Directory.GetFiles(ConfigPerso.RutaEjemplosProcesados, "*", SearchOption.AllDirectories).ToList();
                        foreach (string fichero in strFiles)
                        {
                            File.Delete(fichero);
                        }
                        string nombreArchivoTxt = dtgEjemplos.Rows[e.RowIndex].Cells[1].Value.ToString();
                        string rutaArchivoTxt = ConfigPerso.RutaEjemplosProcesados;
                        string rutaRaiz = ConfigPerso.RutaEjemplos + cmbTipoDoc.Text + @"\" + nombreArchivoTxt;
                        string ArchivoAEnviar = CambiaContenidoTxt(nombreArchivoTxt, rutaRaiz, AmbienteGlobal, rutaArchivoTxt);
                        string NombreArchivo = Path.GetFileName(ArchivoAEnviar);
                        (int Codigo, string Mensaje, string Documento) resp;
                        resp.Codigo = 9;
                        resp.Mensaje = "";
                        resp.Documento = "";
                        string[] respDae = null;
                        string Iniciales = "";
                        if (NombreArchivo.StartsWith("DAE") || NombreArchivo.StartsWith("NCE"))
                        {
                            Iniciales = "DAE";
                        }
                        else
                        {
                            Iniciales = NombreArchivo.Split('-')[1];
                        }
                         
                        if (Iniciales != "RA" && Iniciales != "RC" && Iniciales != "09" && Iniciales != "31" && Iniciales != "20" && Iniciales != "40" && Iniciales != "42" && Iniciales != "DAE" && Iniciales != "NCE")
                        {
                            resp = DllG1.Enviar(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, ArchivoAEnviar);
                        }
                        else if (Iniciales == "20" || Iniciales == "40")
                        {
                            resp = DllG1.EnviarPercepcionRetencion(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, ArchivoAEnviar);
                        }
                        else if (Iniciales == "09" || (Iniciales == "31"))
                        {
                            if (ArchivoAEnviar.Split('-')[0] == ".\\Procesados\\20550728762")
                            {
                                resp = DllG1.EnviarGuiaRemision(ConfigGlobal.Ruc2, ConfigGlobal.UserRuc2, ConfigGlobal.PassRuc2, ArchivoAEnviar);
                            }
                            else
                            {
                                resp = DllG1.EnviarGuiaRemision(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, ArchivoAEnviar);
                            }
                        }
                        else if (Iniciales == "42")
                        {
                            resp = DllG1.EnviarDaeg1(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, ArchivoAEnviar);
                        }
                        else if (Iniciales == "DAE" || Iniciales == "NCE")
                        {
                            List<string> lstArch = new List<string>();
                            lstArch.Add(ArchivoAEnviar);
                            string[] arrayOfArch = lstArch.ToArray();
                            respDae = DllG2.EnviosDCH(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, arrayOfArch);
                        }


                        if (Iniciales == "DAE")
                        {
                            if (respDae[0].Split('|')[0] == "0")
                            {
                                Log("Enviado: " + respDae[0].Split('|')[3] + " --> " + respDae[0].Split('|')[1] + " --> Doc real (" + respDae[0].Split('|')[2] + ")", true, false);
                                aceptadoEdicionGlobal = true;
                                nombreEjemplosGlobal = NombreArchivo;
                                nombreRealEjemplosGlobal = resp.Documento;
                                Task t1 = Task.Run(() => ProcesaIndividual(NombreArchivo.Split('_')[1] + "-" + respDae[0].Split('|')[2], e.RowIndex), token);
                            }
                            else
                            {
                                Log(respDae[0].Split('|')[3] + " --> " + respDae[0].Split('|')[1] + " --> Doc real (" + respDae[0].Split('|')[2] + ")", false, false);
                                dtgEjemplos.Rows[e.RowIndex].Cells[2].Value = resp.Codigo + "|" + resp.Mensaje;
                                dtgEjemplos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                                aceptadoEdicionGlobal = false;
                                pruebaDocEjemploActivo = false;
                            }
                        }
                        else
                        {
                            if (resp.Codigo == 0)
                            {
                                Log("Enviado: " + NombreArchivo + " --> " + resp.Mensaje + " --> Doc real (" + resp.Documento + ")", true, false);
                                aceptadoEdicionGlobal = true;
                                nombreEjemplosGlobal = NombreArchivo;
                                nombreRealEjemplosGlobal = resp.Documento;
                                Task t1 = Task.Run(() => ProcesaIndividual(resp.Documento.ToString(), e.RowIndex), token);
                            }
                            else
                            {
                                Log(NombreArchivo + " --> " + resp.Mensaje + " --> Doc real (" + resp.Documento + ")", false, false);
                                dtgEjemplos.Rows[e.RowIndex].Cells[2].Value = resp.Codigo + "|" + resp.Mensaje;
                                dtgEjemplos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                                aceptadoEdicionGlobal = false;
                                pruebaDocEjemploActivo = false;
                            }
                        }                           
                        Log("--------- Fin Envío a PSE " + AmbienteGlobal + "---------", true, false);
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

            string[] entries = Directory.GetFileSystemEntries(ConfigPerso.RutaEjemplos + cmbTipoDoc.Text + "\\", "*", SearchOption.TopDirectoryOnly);

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


        //private void leerConfigPersonal()
        //{
        //    try
        //    {
        //        string FileToRead = @"C:\ConfigTool\Config.txt";
        //        if (System.IO.File.Exists(FileToRead))
        //        {
        //            string[] lines = System.IO.File.ReadAllLines(FileToRead);
        //            for (int i = 0; i < lines.Length; i++)
        //            {
        //                if (!lines[i].StartsWith("<") && !lines[i].Equals(""))
        //                {
        //                    string lineaYa = lines[i];
        //                    string clave = lines[i].Split('=')[0];
        //                    string valor = lines[i].Split('=')[1];
        //                    if (clave == "RutaEjemplos")
        //                    {
        //                        rutaEjemplos = valor;
        //                    }
        //                    else if (clave == "RutaProcesados")
        //                    {
        //                        rutaEjemplosProcesados = valor;
        //                    }
        //                    else if (clave == "RutaDrive")
        //                    {
        //                        rutaDrive = valor;
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Por favor crea tu archivo de configuracion en: " + FileToRead);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex.Message);
        //    }

        //}

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
            }
            else
            {
                chckCdrEjemplos.Checked = false;
                chckPdfEjemplos.Checked = false;
                chckXmlEjemplos.Checked = false;
                chckRequestEjemplos.Checked = false;
                chckTxtEjemplos.Checked = false;
                chckSpeech.Checked = false;

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
            //if (chckTodo.Checked)
            //{
            //    chckCdrEjemplos.Checked = true;
            //    chckPdfEjemplos.Checked = true;
            //    chckXmlEjemplos.Checked = true;
            //    chckRequestEjemplos.Checked = true;
            //    chckTxtEjemplos.Checked = true;
            //}
            //else
            //{
            //    chckCdrEjemplos.Checked = false;
            //    chckPdfEjemplos.Checked = false;
            //    chckXmlEjemplos.Checked = false;
            //    chckRequestEjemplos.Checked = false;
            //    chckTxtEjemplos.Checked = false;
            //}           
        }

        private void txtBusquedaEjemplo_TextChanged(object sender, EventArgs e)
        {
            string filterField = "DETALLE";
            ((DataTable)dtgEjemplos.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, txtBusquedaEjemplo.Text);
        }

        private void btnProbarTodos_Click(object sender, EventArgs e)
        {
            btnProbarTodos.Enabled = false;
            btnDescargas.Enabled = false;
            Task t1 = Task.Run(() => EnvioPSE(), token);
        }

        private string obtieneFecha()
        {
            string año = DateTime.Now.Year.ToString();
            string mes1 = DateTime.Now.Month.ToString(), mes = "";
            string dia1 = DateTime.Now.Day.ToString(), dia = "";
            if(mes1.Length == 1)
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
            return año + "-" +  mes + "-" + dia;
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
                if (!nombreArchivo.Substring(0, 3).Equals("DAE"))
                {
                    tipoTxt = "NCE";
                }
                else
                {
                    tipoTxt = "DAE";
                }
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

                        //if (camposLine[0].Equals("02"))
                        //{
                        //    string newLine = "";
                        //    string oldLine = line;
                        //    string[] arrayLine = oldLine.Split('|');
                        //    arrayLine[1] = txtSetFecha.Text;
                        //    if (ambiente.Equals("PRD"))
                        //    {
                        //        if (tipoTxt.Equals("20"))
                        //        {
                        //            arrayLine[3] = txt_PrdRet.Text + "-" + numeroConDosCotas;
                        //        }
                        //        else if (tipoTxt.Equals("40"))
                        //        {
                        //            arrayLine[3] = txt_PrdPerc.Text + "-" + numeroConDosCotas;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        if (tipoTxt.Equals("20"))
                        //        {
                        //            arrayLine[3] = txt_DemoRet.Text + "-" + numeroConDosCotas;
                        //        }
                        //        else if (tipoTxt.Equals("40"))
                        //        {
                        //            arrayLine[3] = txt_DemoPerc.Text + "-" + numeroConDosCotas;
                        //        }
                        //    }
                        //    for (int t = 0; t < arrayLine.Length - 1; t++)//Envio 1x1 de documentos ubicados en ruta TXTUbicacion
                        //    {
                        //        newLine += arrayLine[t] + "|";
                        //    }

                        //    line = newLine;
                        //}

                    }
                    else if (!tipoTxt.Equals("DAE") && !tipoTxt.Equals("NCE"))
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
                        if (tipoTxt.Equals("DAE"))
                        {
                            arrayLine[5] = ConfigGlobal.SerieDae + "-" + numeroConDosCotas;
                        }
                        else
                        {
                            arrayLine[5] = ConfigGlobal.SerieNC + "-" + numeroConDosCotas;
                        }
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
                    string respPdf = "";
                    if (nombreRealEjemplosGlobal.Split('-')[0] == "20550728762")
                    {
                        string rutaOriginal = ConfigPerso.RutaEjemplosProcesados + nombreEjemplosGlobal;
                        request.GenerarRequest(ConfigGlobal.Ruc2, ConfigGlobal.UserRuc2, ConfigGlobal.PassRuc2, rutaOriginal, ConfigPerso.RutaEjemplosProcesados + nombreEjemplosGlobal + "_request.xml");
                        ObtenerRequest(ConfigPerso.RutaEjemplosProcesados + nombreEjemplosGlobal + "_request.xml", rutaDestino + "\\" + nombreEjemplosGlobal + ". Request.xml");
                        MensajeTipos += Environment.NewLine + "- REQUEST";
                    }
                    else
                    {
                        string rutaOriginal = ConfigPerso.RutaEjemplosProcesados + nombreEjemplosGlobal;
                        request.GenerarRequest(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, rutaOriginal, ConfigPerso.RutaEjemplosProcesados + nombreEjemplosGlobal + "_request.xml");
                        ObtenerRequest(ConfigPerso.RutaEjemplosProcesados + nombreEjemplosGlobal + "_request.xml", rutaDestino + "\\" + nombreEjemplosGlobal + ". Request.xml");
                        MensajeTipos += Environment.NewLine + "- REQUEST";
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

        }

        private void chckDemo_SliderValueChanged(object sender, EventArgs e)
        {
            //string result = "";
            //try
            //{
            //    XmlDocument xmlDoc = new XmlDocument();
            //    string path = ".\\DLL_Online.dll.xml";
            //    if (System.IO.File.Exists(path))
            //    {
            //        xmlDoc.Load(path);
            //    }
            //    XmlNamespaceManager nsManager = new XmlNamespaceManager(xmlDoc.NameTable);
            //    //nsManager.AddNamespace(prefix, uri);
            //    XmlNode nodo = xmlDoc.SelectSingleNode("Service", nsManager);
            //    if (nodo != null)
            //    {
            //        XmlNode nodo2 = nodo.SelectSingleNode("Ambiente", nsManager);
            //        if (nodo2 != null)
            //        {
            //            if (chckDemo.IsOn)
            //            {
            //                nodo2.Attributes[0].Value = "http://demoint.thefactoryhka.com.pe/Service.svc";
            //            }
            //            else
            //            {
            //                nodo2.Attributes[0].Value = "http://int.thefactoryhka.com.pe/Service.svc";
            //            }
            //            xmlDoc.Save(path);
            //            LeerDll();
            //        }
            //    }
            //}
            //catch (Exception ex) { result = ex.ToString(); }
            //ConfigGlobal = new LeerConfig();
        }

        public void EnvioPSE()
        {
            string AmbienteGlobal = LeerDll();
            bool LogFechaHora = false;
            if (AmbienteGlobal == "DEMO")
            {
                Log("--------- Envío a PSE DEMO ---------", true, false);
            }
            else
            {
                Log("--------- Envío a PSE PRD ---------", true, false);
            }
            (string nombreTxt, string documentoInterno, string status) Doc;
            List<(string, string, string)> lstDocs = new List<(string, string, string)>();
            for (int i = 0; i < dtgEjemplos.RowCount - 1; i++)
            {
                string rutaRaiz = ConfigPerso.RutaEjemplos + cmbTipoDoc.Text + @"\";
                string nombreArchivoOriginal = dtgEjemplos.Rows[i].Cells[1].Value.ToString();
                string rutaArchivoTxtNueva = ConfigPerso.RutaEjemplosProcesados;
                string rutaArchivoTxtVieja = rutaRaiz + nombreArchivoOriginal;
                string ArchivoAEnviar = CambiaContenidoTxt(nombreArchivoOriginal, rutaArchivoTxtVieja, AmbienteGlobal, rutaArchivoTxtNueva);
                string NombreArchivoaEnviar = Path.GetFileName(ArchivoAEnviar);
                (int Codigo, string Mensaje, string Documento) resp;
                if (ArchivoAEnviar.Split('-')[1] == "20" || ArchivoAEnviar.Split('-')[1] == "40")
                {
                    resp = DllG1.EnviarPercepcionRetencion(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, ArchivoAEnviar);
                }
                else if (ArchivoAEnviar.Split('-')[1] == "30" || ArchivoAEnviar.Split('-')[1] == "09")
                {
                    resp = DllG1.EnviarGuiaRemision(ConfigGlobal.Ruc2, ConfigGlobal.UserRuc2, ConfigGlobal.PassRuc2, ArchivoAEnviar);
                }
                else
                {
                    resp = DllG1.Enviar(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, ArchivoAEnviar);
                }
                dtgEjemplos.Rows[i].Cells[2].Value = resp.Codigo + "|" + resp.Mensaje;
                bool msj = false;
                if (resp.Codigo == 0)
                {
                    msj = true;
                    Doc.documentoInterno = resp.Documento;
                    Doc.nombreTxt = nombreArchivoOriginal;
                    Doc.status = resp.Codigo.ToString();
                    lstDocs.Add(Doc);
                }
                Log("Enviado: " + NombreArchivoaEnviar + " (" + resp.Documento + "): " + resp.Codigo + "|" + resp.Mensaje, true, false);

            }
            Log("--------- Fin Envio a PSE ---------", true, false);
            Log("--------- Consulta estatus Sunat/Ose ---------", true, false);
            (string nombreTxt, string documentoInterno, string status)[] arrayDocs = lstDocs.ToArray();
            for (int i = 0; i < arrayDocs.Length; i++)
            {
                bool encendido = true;
                (int Codigo, string Mensaje, string Documento) resp2;
                resp2.Codigo = 911;
                resp2.Mensaje = "911";
                while (encendido)
                {
                    if (arrayDocs[i].documentoInterno.Split('-')[0] == "20550728762")
                    {
                        resp2 = DllG1.EstatusDocumento(ConfigGlobal.Ruc2, ConfigGlobal.UserRuc2, ConfigGlobal.PassRuc2, arrayDocs[i].documentoInterno);
                    }
                    else
                    {
                        resp2 = DllG1.EstatusDocumento(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, arrayDocs[i].documentoInterno);
                    }

                    if (resp2.Codigo == 0)
                    {
                        encendido = false;
                        arrayDocs[i].status = resp2.ToString();
                    }
                    else if (resp2.Codigo != 95)
                    {
                        encendido = false;
                        arrayDocs[i].status = resp2.ToString();
                    }
                    else
                    {
                        Log("Se esperan 25 segundos para consultar el status de los documentos", true, false);
                        Thread.Sleep(25000);
                    }
                }
                bool msj = false;
                string cdrContenido = "";
                if (resp2.Codigo == 0)
                {
                    msj = true;
                    (int Codigo, string Mensaje, string Docmumento, string ArhivoBase64) respDescarga;

                    if (arrayDocs[i].documentoInterno.Split('-')[0] == "20550728762")
                    {
                        respDescarga = DllG1.DescargaArchivos(ConfigGlobal.Ruc2, ConfigGlobal.UserRuc2, ConfigGlobal.PassRuc2, arrayDocs[i].documentoInterno, "CDR");
                    }
                    else
                    {
                        respDescarga = DllG1.DescargaArchivos(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, arrayDocs[i].documentoInterno, "CDR");
                    }

                    if (respDescarga.ArhivoBase64 != null)
                    {
                        byte[] data = System.Convert.FromBase64String(respDescarga.ArhivoBase64);
                        File.WriteAllBytes(ConfigPerso.RutaEjemplosProcesados + arrayDocs[i].documentoInterno + ".zip", data);
                    }
                    cdrContenido = LeerCDR(DescomprimirArchivo(ConfigPerso.RutaEjemplosProcesados + arrayDocs[i].documentoInterno + ".zip"));
                    //Log("Documento " + numeracion + " aceptado, " + cdrContenido.Split('|')[2] + ".", true, false);

                }
                Log("Status del doc " + arrayDocs[i].nombreTxt + " (" + arrayDocs[i].documentoInterno + ") --> " + cdrContenido, true, false);
                //dtgEjemplos.Rows[i].Cells[2].Value = resp2.Codigo;
                dtgEjemplos.Rows[i].Cells[2].Value = resp2.Codigo + "|" + resp2.Mensaje;
                foreach (DataGridViewRow dgvr in dtgEjemplos.Rows)
                {
                    if (dgvr.Cells[2].Value != null)
                    {
                        if (dgvr.Cells[2].Value.ToString().Split('|')[0] != "0")
                        {
                            dgvr.DefaultCellStyle.ForeColor = Color.Red;
                        }
                        else
                        {
                            dgvr.DefaultCellStyle.ForeColor = colorAceptados;
                        }
                    }
                }

            }


            Log("--------- Fin Consulta estatus Sunat/Ose ---------", true, false);
            btnProbarTodos.Enabled = true;
            btnDescargas.Enabled = true;

        }

        public string DescomprimirArchivo(string RutaComprimido)
        {
            string RutaDescomprimido = Path.GetDirectoryName(RutaComprimido) + "\\unZip\\";
            string NombreArchivo = Path.GetFileNameWithoutExtension(RutaComprimido);
            if (!Directory.Exists(RutaDescomprimido))
            {
                Directory.CreateDirectory(RutaDescomprimido);
            }
            if (Directory.Exists(RutaDescomprimido + NombreArchivo))
            {
                Directory.Delete(RutaDescomprimido + NombreArchivo, true);
            }
            ZipFile.ExtractToDirectory(RutaComprimido, RutaDescomprimido + NombreArchivo);
            return RutaDescomprimido + NombreArchivo + "\\R-" + NombreArchivo + ".xml";
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
                string respuestaSunatObs = "SIN OBS.";

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
                            respuestaSunatObs = "CON OBS.";
                        }
                    }
                }
                XmlNodeList nodoResponse2 = doc.GetElementsByTagName("cbc:Note");
                if (nodoResponse2.Count == 0)
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

        private void ProcesaIndividual(string numeracion, int index)
        {
            string AmbienteGlobal = LeerDll();
            Log("--------- Envío a PSE " + AmbienteGlobal + "---------", true, false);
            Log("--------- Consulta estatus Sunat/Ose " + AmbienteGlobal + "---------", true, false);
            bool encendido = true;
            while (encendido)
            {
                (int Codigo, string Mensaje, string Docmumento) resp;

                if (numeracion.Split('-')[0] == "20550728762")
                {
                    resp = DllG1.EstatusDocumento(ConfigGlobal.Ruc2, ConfigGlobal.UserRuc2, ConfigGlobal.PassRuc2, numeracion);
                }
                else
                {
                    resp = DllG1.EstatusDocumento(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, numeracion);
                }


                if (resp.Codigo == 0)
                {
                    //Log("Documento " + numeracion + " aceptado.", true, false);
                    encendido = false;
                    tlp_archivos.Enabled = true;
                    btnDescargas.Enabled = true;
                    dtgEjemplos.Rows[index].Cells[2].Value = resp.Codigo + "|" + resp.Mensaje;
                    dtgEjemplos.Rows[index].DefaultCellStyle.ForeColor = colorAceptados;
                    (int Codigo, string Mensaje, string Docmumento, string ArhivoBase64) respDescarga;

                    if (numeracion.Split('-')[0] == "20550728762")
                    {
                        respDescarga = DllG1.DescargaArchivos(ConfigGlobal.Ruc2, ConfigGlobal.UserRuc2, ConfigGlobal.PassRuc2, numeracion, "CDR");
                    }
                    else
                    {
                        respDescarga = DllG1.DescargaArchivos(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, numeracion, "CDR");
                    }
                    
                    if (respDescarga.ArhivoBase64 != null)
                    {
                        byte[] data = System.Convert.FromBase64String(respDescarga.ArhivoBase64);
                        File.WriteAllBytes(ConfigPerso.RutaEjemplosProcesados + numeracion + ".zip" , data);
                    }
                    var cdrContenido = LeerCDR(DescomprimirArchivo(ConfigPerso.RutaEjemplosProcesados + numeracion + ".zip"));
                    Log("Documento " + numeracion + " aceptado, " + cdrContenido.Split('|')[2] + ".", true, false);
                }
                else if (resp.Codigo == 95 || resp.Codigo == 99)
                {
                    Log("Documento "+ numeracion +" aun no aceptado. En 30 segundos se realizara nuevamente la consulta para evitar error 99", true, false);
                    Thread.Sleep(30000);
                }
                else
                {
                    Log("Documento  " + numeracion + " rechazado: " + resp.Codigo + "-" + resp.Mensaje, false, false);
                    dtgEjemplos.Rows[index].Cells[2].Value = resp.Codigo + "|" + resp.Mensaje;
                    dtgEjemplos.Rows[index].DefaultCellStyle.ForeColor = Color.Red;
                    encendido = false;
                }
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
