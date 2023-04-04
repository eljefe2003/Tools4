using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using MySql.Data.MySqlClient;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO.Compression;



namespace Tools
{    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Variables
        int contador = 0;
        string[][] arrayOfArchivosTxt;
        string[] arrayOfEmpresas;
        Validaciones val = new Validaciones();
        bool LogFechaHora = false, aceptadoEdicionGlobal = false, pruebaDocEjemploActivo = false;
        List<string> lectura;
        string[] arrayOfLectura, campo, globalRutaEdicionAutomatica;
        Faby3.AppTools ToolFaby = new Faby3.AppTools();
        DataTable dt7;

        //Faby3.AppTools ToolFaby = new Faby3.AppTools();  

        PSE21.ServiceClient ServicioPse = new PSE21.ServiceClient();
        //Sunat.billValidServiceClient ServicioSunat = new Sunat.billValidServiceClient();
        
        DLL_Online.Metodos.TheFactoryHKA DllProd = new DLL_Online.Metodos.TheFactoryHKA();
        DLL_Online.Metodos.Facturacion DllG1 = new DLL_Online.Metodos.Facturacion();
        DLL_Online.Metodos.Dae_DinersClub DLLG2 = new DLL_Online.Metodos.Dae_DinersClub();
        DLL_Online.Metodos.Request request = new DLL_Online.Metodos.Request();
        string AmbienteGlobal = "", tipoNota = "";
        CancellationTokenSource source = new CancellationTokenSource();
        CancellationToken token;
        Thread hilo1, hilo2, hilo3, hilo4, hilo5, hilo6, hilo7, hilo8, hilo9, hilo10, hilo11, hilo12, hilo13, hilo14, hilo15, hilo16;
        ThreadStart thread1, thread2, thread3, thread4, thread5, thread6, thread7, thread8, thread9, thread10, thread11, thread12, thread13, thread14, thread15, thread16;
        List<string> lista1, lista2, lista3, lista4, lista5, lista6, lista7, lista8, lista9, lista10, lista11, lista12, lista13, lista14, lista15, lista16;
        string RutaEjemplosGlobal = "", nombreRealEjemplosGlobal = "", nombreEjemplosGlobal = "";

        #endregion

        #region Metodos
        private string[] leerArchivoDaily()
        {            
            try
            {
                lectura = new List<string>();
                foreach (var linea in rtb_daily.Lines)
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

        private String[][] Calculo(string[] array)
        {
            List<String[]> listaGeneral = new List<string[]>();
            lista1 = new List<string>();
            lista2 = new List<string>();
            lista3 = new List<string>();
            lista4 = new List<string>();
            lista5 = new List<string>();
            lista6 = new List<string>();
            lista7 = new List<string>();
            lista8 = new List<string>();
            lista9 = new List<string>();
            lista10 = new List<string>();           


            //int valor = 111;
            if (array.Length > 10)
            {
                decimal valorResultante = array.Length / 10;
                var resultadoEntero = Math.Truncate(valorResultante);
                var acumulado = 0;
                for (int i = 0; i < resultadoEntero; i++)
                {
                    lista1.Add(array[i]);
                    acumulado++;
                }
                //listaGeneral.Add(lista1.ToArray());
                for (int i = 0; i < resultadoEntero; i++)
                {
                    lista2.Add(array[acumulado]);
                    acumulado++;
                }
                listaGeneral.Add(lista2.ToArray());

                for (int i = 0; i < resultadoEntero; i++)
                {
                    lista3.Add(array[acumulado]);
                    acumulado++;
                }
                listaGeneral.Add(lista3.ToArray());

                for (int i = 0; i < resultadoEntero; i++)
                {
                    lista4.Add(array[acumulado]);
                    acumulado++;
                }
                listaGeneral.Add(lista4.ToArray());

                for (int i = 0; i < resultadoEntero; i++)
                {
                    lista5.Add(array[acumulado]);
                    acumulado++;
                }
                listaGeneral.Add(lista5.ToArray());

                for (int i = 0; i < resultadoEntero; i++)
                {
                    lista6.Add(array[acumulado]);
                    acumulado++;
                }
                listaGeneral.Add(lista6.ToArray());

                for (int i = 0; i < resultadoEntero; i++)
                {
                    lista7.Add(array[acumulado]);
                    acumulado++;
                }
                listaGeneral.Add(lista7.ToArray());

                for (int i = 0; i < resultadoEntero; i++)
                {
                    lista8.Add(array[acumulado]);
                    acumulado++;
                }
                listaGeneral.Add(lista8.ToArray());

                for (int i = 0; i < resultadoEntero; i++)
                {
                    lista9.Add(array[acumulado]);
                    acumulado++;
                }
                listaGeneral.Add(lista9.ToArray());

                for (int i = 0; i < resultadoEntero; i++)
                {
                    lista10.Add(array[acumulado]);
                    acumulado++;
                }
                listaGeneral.Add(lista10.ToArray());
                int num1 = (Convert.ToInt32(resultadoEntero) * 10);
                if (num1 != array.Length)
                {
                    var acum = acumulado;
                    for (int i = 0; i < array.Length - acumulado; i++)
                    {
                        lista1.Add(array[acum]);
                        acum++;
                    }
                }
                listaGeneral.Add(lista1.ToArray());
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    lista1.Add(array[i]);
                }
                listaGeneral.Add(lista1.ToArray());

            }
            return listaGeneral.ToArray();
        }

        private string[] leerArchivoDescargas()
        {

            try
            {
                lectura = new List<string>();
                foreach (var linea in rtb_descarga.Lines)
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

        private string[] leerArchivoConsultas()
        {
            try
            {
                lectura = new List<string>();
                foreach (var linea in rtb_consultas.Lines)
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

        private void EliminarPDF()
        {
            var recorrer = leerArchivoDaily();
            ts_ProgressBar1.Minimum = 1;
            ts_ProgressBar1.Maximum = recorrer.Length;
            ts_ProgressBar1.Value = 1;
            ts_ProgressBar1.Step = 1;
            MessageBox.Show("Espera mientras se procesa tu petición, esto puede demorar unos minutos!");
            for (int i = 0; i < recorrer.Length; i++)
            {
                try
                {
                    ts_ProgressBar1.PerformStep();
                    campo = recorrer[i].Split('|');
                    var resp = ToolFaby.dailyTasks21(txt_Token.Text, txt_RucDaily.Text, txt_RucDaily.Text + "-" + campo[0], campo[1], lbl_Mantis.Text + txt_Mantis.Text, cmb_combo.Text, null);
                    Log(resp.errorMessage, true, LogFechaHora);
                }
                catch (Exception e)
                {
                    Log(e.Message, false, LogFechaHora);
                }
            }
            MessageBox.Show("Peticion completada! Revisa el Log");
        }

        private void Desactivar()
        {
            var recorrer = leerArchivoDaily();
            ts_ProgressBar1.Minimum = 1;
            ts_ProgressBar1.Maximum = recorrer.Length;
            ts_ProgressBar1.Value = 1;
            ts_ProgressBar1.Step = 1;
            MessageBox.Show("Espera mientras se procesa tu petición, esto puede demorar unos minutos!");
            for (int i = 0; i < recorrer.Length; i++)
            {
                try
                {
                    ts_ProgressBar1.PerformStep();
                    campo = recorrer[i].Split('|');
                    var resp = ToolFaby.dailyTasks21(txt_Token.Text, txt_RucDaily.Text, txt_RucDaily.Text + "-" + campo[0], campo[1], lbl_Mantis.Text + txt_Mantis.Text, cmb_combo.Text, null);
                    Log(resp.errorMessage, true, LogFechaHora);
                }
                catch(Exception e)
                {
                    Log(e.Message, false, LogFechaHora);
                }
            }
            MessageBox.Show("Peticion completada! Revisa el Log");
        }

        private void DesactivarOSE()
        {
            var recorrer = leerArchivoDaily();
            ts_ProgressBar1.Minimum = 1;
            ts_ProgressBar1.Maximum = recorrer.Length;
            ts_ProgressBar1.Value = 1;
            ts_ProgressBar1.Step = 1;
            MessageBox.Show("Espera mientras se procesa tu petición, esto puede demorar unos minutos!");
            for (int i = 0; i < recorrer.Length; i++)
            {
                try
                {
                    ts_ProgressBar1.PerformStep();
                    campo = recorrer[i].Split('|');
                    string supplier = campo[0], tipoDoc = campo[1], identificador = campo[2];
                    var resp = ToolFaby.dailyTasksOSE(txt_Token.Text, lbl_Mantis.Text + txt_Mantis.Text, cmb_combo.Text.Split('-')[1], txt_RucDaily.Text, supplier, tipoDoc, identificador);
                    //var resp = ToolFaby.dailyTasks21(txt_Token.Text, txt_RucDaily.Text, txt_RucDaily.Text + "-" + campo[0], campo[1], lbl_Mantis.Text + txt_Mantis.Text, cmb_combo.Text, null);
                    Log(resp.errorMessage, true, LogFechaHora);
                }
                catch (Exception e)
                {
                    Log(e.Message, false, LogFechaHora);
                }
            }
            MessageBox.Show("Peticion completada! Revisa el Log");
        }

        private void Duplicados()
        {
            var recorrer = leerArchivoDaily();
            MessageBox.Show("Espera mientras se procesa tu petición, esto puede demorar unos minutos!");
            for (int i = 0; i < recorrer.Length; i++)
            {
                campo = recorrer[i].Split('|');
                var resp = ToolFaby.dailyTasks21(campo[0], campo[1], campo[2] + '|' + campo[3], campo[4], campo[5], campo[6], null);
                //MessageBox.Show(resp.errorMessage);
                Log(resp.errorMessage, true, LogFechaHora);
            }
            MessageBox.Show("Peticion completada! Revisa el Log");
        }

        private void Bajas()
        {
            var recorrer = leerArchivoDaily();
            MessageBox.Show("Espera mientras se procesa tu petición, esto puede demorar unos minutos!");
            for (int i = 0; i < recorrer.Length; i++)
            {
                try
                {
                    campo = recorrer[i].Split('|');
                    string ruc = campo[0];
                    string numeracion = campo[1] + "|" + campo[2];
                    string metodo = cmb_combo.Text;

                    var resp = ToolFaby.dailyTasks21(txt_Token.Text, ruc, numeracion, "", lbl_Mantis.Text + txt_Mantis.Text, metodo, null);
                    //MessageBox.Show(resp.errorMessage);
                    Log(resp.errorMessage + " " + campo[1] + "|" + campo[2], true, LogFechaHora);
                }
                catch (Exception e)
                {
                    Log(e.Message, false, LogFechaHora);
                }

            }
            MessageBox.Show("Peticion completada! Revisa el Log");
        }

        private void Descargas()
        {
            //ts_ProgressBar1.Visible = true;            
            var recorrer = leerArchivoDescargas();
            ts_ProgressBar1.Minimum = 1;
            ts_ProgressBar1.Maximum = recorrer.Length;
            ts_ProgressBar1.Value = 1;
            ts_ProgressBar1.Step = 1;
            string rutaAsignada = AsignaRuta() + "/";
            MessageBox.Show("Espera mientras se procesa tu petición, esto puede demorar unos minutos!");
            for (int i = 0; i < recorrer.Length; i++)
            {
                ts_ProgressBar1.PerformStep();
                try
                {
                    string campo = txt_RucDescarga.Text + "-" + recorrer[i];
                    
                    var resp = ServicioPse.DescargaArchivo(txt_UserDescarga.Text, txt_ClaveDescarga.Text, campo, comboBox1.Text);
                    //MessageBox.Show(resp.errorMessage);
                    string extension = "";
                    if (comboBox1.Text == "CDR")
                    {
                        extension = ".zip";
                    }
                    else
                    {
                        extension = comboBox1.Text;
                    }
                    string ruta = rutaAsignada + recorrer[i] + "." + extension;
                    if (resp.archivo != null)
                    {
                        byte[] data = System.Convert.FromBase64String(resp.archivo);
                        File.WriteAllBytes(ruta, data);
                        Log(resp.mensaje + " " + extension + " " + recorrer[i], true, LogFechaHora);
                    }
                    else
                    {
                        Log(resp.mensaje + " " + recorrer[i], false, LogFechaHora);
                    }
                }
                catch (Exception e)
                {
                    Log(e.Message + " " + recorrer[i], false, LogFechaHora);
                }
            }
            MessageBox.Show("Peticion completada! Revisa el Log");
        }

       
        private string LeerConfig()
        {
            string Ambiente = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(".\\DLL_Online.dll.xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                String id = node.Attributes["service"].Value;
                if (id.IndexOf("demo") > 0)
                {
                    //cmd_Procesar.ForeColor = Color.White;                    
                    cmd_Procesar2.BackColor = Color.LightSalmon;
                    cmd_Procesar2.Text = "Demo";
                    Log("-----------------Ambiente DEMO--------------------------------------", true, LogFechaHora);
                    Ambiente = "DEMO";
                }
                else
                {
                    //cmd_Procesar.ForeColor = Color.White;
                    cmd_Procesar2.BackColor = Color.LightBlue;
                    cmd_Procesar2.Text = "Producción";
                    Log("-----------------Ambiente PRODUCTIVO-------------------------", true, LogFechaHora);
                    Ambiente = "PRD";
                }

            }
            return Ambiente;
        }    

        private void method1(string[] uno)
        {
            foreach (string iteraccion in uno)
            {
                try
                {
                    ts_ProgressBar1.PerformStep();
                    Sunat.billValidServiceClient ServicioSunat = new Sunat.billValidServiceClient();
                    string[] campo = iteraccion.Split('|');
                    if (campo.Length > 2)
                    {
                        var resp = ServicioSunat.validaCDPcriterios(campo[0], campo[1], campo[2], campo[3], campo[4], campo[5], campo[6], Convert.ToDouble(campo[7]), " ");
                        contador++;
                        //Log(resp.statusMessage, true, LogFechaHora);
                        rtb_Log.AppendText(resp.statusMessage + " |" + contador + "| " + Environment.NewLine);
                        //Log("Hilo1", true, LogFechaHora);
                    }
                    else
                    {
                        //Log("Por favor valida la estructura de la cadena: " + campo, false, LogFechaHora);
                    }
                }
                catch (Exception e)
                {
                    rtb_Log.AppendText("Error: " + e.Message + Environment.NewLine);
                    //Log(e.Message, false, LogFechaHora);
                }
            }

        }

        private void method2(string Ruta)
        {
            bool encendido = true;
            while (encendido)
            {
                (int Codigo, string Mensaje, string Docmumento) resp;
                if (lblDocEdicion.Text != "-")
                {
                    resp = DllG1.EstatusDocumento(txt_RucConfig.Text, txt_UserConfig.Text, txt_ClaveConfig.Text,lblDocEdicion.Text);
                    if (resp.Codigo == 0)
                    {
                        LogRespuesta("Documento aceptado, se habilita el boton de descargas", true, LogFechaHora);
                        try
                        {
                            btnDescargaEjemplos.Enabled = true;
                            tlp_archivos.Enabled = true;


                            //DirectoryInfo di = new DirectoryInfo(lst_archivo.Items[i].ToString());
                            string nombreXml = lblDocEdicion.Text;
                            if (chckPDF.Checked)
                            {
                                string rutaPdf = Ruta + "\\" + nombreXml + ".pdf";
                                var respPdf = DllG1.DescargaArchivos(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, lblDocEdicion.Text, "PDF");
                                if (respPdf.ArhivoBase64 != null)
                                {
                                    byte[] data = System.Convert.FromBase64String(respPdf.ArhivoBase64);
                                    File.WriteAllBytes(rutaPdf, data);
                                    LogRespuesta("Se descarga " + rutaPdf, true, LogFechaHora);
                                }
                                else
                                {
                                    LogRespuesta("No se puede descargar PDF del doc " + nombreXml, false, LogFechaHora);
                                }
                            }

                            if (chckXML.Checked)
                            {
                                string rutaPdf = Ruta + "\\" + nombreXml + ".xml";
                                var respPdf = DllG1.DescargaArchivos(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, lblDocEdicion.Text, "XML");
                                if (respPdf.ArhivoBase64 != null)
                                {
                                    byte[] data = System.Convert.FromBase64String(respPdf.ArhivoBase64);
                                    File.WriteAllBytes(rutaPdf, data);
                                    LogRespuesta("Se descarga " + rutaPdf, true, LogFechaHora);
                                }
                                else
                                {
                                    LogRespuesta("No se puede descargar XML del doc " + nombreXml, false, LogFechaHora);
                                }
                            }

                            if (chckCDR.Checked)
                            {
                                string rutaPdf = Ruta + "\\" + nombreXml + ".zip";
                                var respPdf = DllG1.DescargaArchivos(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, lblDocEdicion.Text, "CDR");
                                if (respPdf.ArhivoBase64 != null)
                                {
                                    byte[] data = System.Convert.FromBase64String(respPdf.ArhivoBase64);
                                    File.WriteAllBytes(rutaPdf, data);
                                    LogRespuesta("Se descarga " + rutaPdf, true, LogFechaHora);
                                }
                                else
                                {
                                    LogRespuesta("No se puede descargar CDR del doc " + nombreXml, false, LogFechaHora);
                                }
                            }
                            encendido = false;
                        }
                        catch (Exception ew)
                        {
                            encendido = false;
                            Log(ew.Message + " " + lblDocEdicion.Text, false, LogFechaHora);
                        }
                    }
                    else if (resp.Codigo != 99)
                    {
                        Log("Documento aun no aceptado. En 25 segundos se realizara nuevamente la consulta", true, LogFechaHora);
                        //LogRespuesta("Documento aun no aceptado. En 25 segundos se realizara nuevamente la consulta", false, LogFechaHora);
                        //MessageBox.Show("Espera unos minutos que el documento se acepte para intentarlo nuevamente");
                    }
                    else
                    {
                        LogRespuesta("Documento rechazado: " + resp.Codigo + "-" + resp.Mensaje, false, LogFechaHora);
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

        private void ProcesaIndividual(string numeracion, int index)
        {
            bool encendido = true;
            while (encendido)
            {
                (int Codigo, string Mensaje, string Docmumento) resp;
                resp = DllG1.EstatusDocumento(txt_RucConfig.Text, txt_UserConfig.Text, txt_ClaveConfig.Text, numeracion);
                if (resp.Codigo == 0)
                {
                    LogRespuesta("Documento aceptado, se habilita el boton de descargas", true, LogFechaHora);
                    encendido = false;
                    tlp_archivos.Enabled = true;
                    btnDescargaEjemplos.Enabled = true;
                    dtgEjemplos.Rows[index].Cells[2].Value = resp.Codigo + "|" + resp.Mensaje;
                    dtgEjemplos.Rows[index].DefaultCellStyle.ForeColor = Color.Blue;
                }
                else if (resp.Codigo == 95 || resp.Codigo == 99)
                {
                    Log("Documento aun no aceptado. En 125 segundos se realizara nuevamente la consulta para evitar error 99", true, LogFechaHora);
                    Thread.Sleep(120005);
                }
                else
                {
                    LogRespuesta("Documento rechazado: " + resp.Codigo + "-" + resp.Mensaje, false, LogFechaHora);
                    dtgEjemplos.Rows[index].Cells[2].Value = resp.Codigo + "|" + resp.Mensaje;
                    dtgEjemplos.Rows[index].DefaultCellStyle.ForeColor = Color.Red;
                    encendido = false;
                }
            }
            pruebaDocEjemploActivo = false;
            btnProbarTodos.Enabled = true;
        }

        private void method3(int valor)
        {
            CheckForIllegalCrossThreadCalls = false;
            try
            {
                //rtb_Log.AppendText(DateTime.Now + " Hilo: " + valor + Environment.NewLine);
                //Thread.Sleep(5000);
                rtb_Log.AppendText("Fin Hilo - " + valor + Environment.NewLine);
            }
            catch (Exception e)
            {
            }
        }

        private void Consultas()
        {
            var recorrer1 = leerArchivoConsultas();
            var arraytotal = Calculo(recorrer1);
            ts_ProgressBar1.Minimum = 1;
            ts_ProgressBar1.Maximum = recorrer1.Length;
            ts_ProgressBar1.Value = 1;
            ts_ProgressBar1.Step = 1;
            //Task.Factory.StartNew(() => method1(recorrer1));
            Log("Inicio de consulta Sunat, verificar la barra de progreso...", true, false);
            for (int i = 0; i < arraytotal.Length; i++)
            {
                //var recorrer = leerArchivoConsultas();
                //Thread t = new Thread(() => method2(i));
                //t.Start();
                int temp = i;
                Task.Factory.StartNew(() => method1(arraytotal[temp]));
            }
            //Log("Fin de consulta Sunat.", true, false);

            //Log("Culminado el proceso", true, false);666
            //MessageBox.Show("Proceso Culminado! Revisa el Log.");
        }

        private void Emision()
        {
            try
            {
                ts_ProgressBar1.Minimum = 1;
                ts_ProgressBar1.Maximum = lst_archivo.Items.Count;
                ts_ProgressBar1.Value = 1;
                ts_ProgressBar1.Step = 1;
                //var resp = "";
                for (int i = 0; i < lst_archivo.Items.Count; i++)
                {
                    try
                    {
                        if (checkBox3.Checked)
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
                            string rutaNueva = rutaDestino + "\\" + nombreXml + "_Request"+ ".xml";

                            ObtenerRequest(ruta,rutaNueva);
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
                            resp.Codigo = 9;
                            (int Codigo, string Mensaje, string Docmumento, string Numeracion) respBaja;
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
                                            Log("Modificado: RUC del nombre del archivo original, antes: " + rucAReemplazar + " Despues: "+ ruc, true, false);

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
                            if (Iniciales != "RA" && Iniciales != "RC" && Iniciales != "09" && Iniciales != "20" && Iniciales != "40" && Iniciales != "42")
                            {                                
                                resp = DllG1.Enviar(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, ArchivoAEnviar);
                                if(resp.Codigo == 0)
                                {
                                    aceptadoEdicionGlobal = true;                                    
                                }                               
                                LogRespuesta(NombreArchivo + " --> " + resp.Mensaje + " --> Doc real (" + resp.Docmumento + ")", aceptadoEdicionGlobal, LogFechaHora);
                                lblDocEdicion.Text = resp.Docmumento;
                            }
                            else if (Iniciales == "RC")
                            {
                                //resp = DllG1.EnviarResumen(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, ArchivoAEnviar);
                                resp = DllG1.EnviarResumen(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, ArchivoAEnviar);
                                //bool aceptado = false;
                                if (resp.Codigo == 0)
                                {
                                    aceptadoEdicionGlobal = true;
                                }
                                LogRespuesta(NombreArchivo + " --> " + resp.Mensaje + " --> Doc real (" + resp.Docmumento + ")", aceptadoEdicionGlobal, LogFechaHora);
                                lblDocEdicion.Text = resp.Docmumento;

                            }
                            else if (Iniciales == "09")
                            {
                                resp = DllG1.EnviarGuiaRemision(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, ArchivoAEnviar);
                                //bool aceptado = false;
                                if (resp.Codigo == 0)
                                {
                                    aceptadoEdicionGlobal = true;
                                }
                                LogRespuesta(NombreArchivo + " --> " + resp.Mensaje + " --> Doc real (" + resp.Docmumento + ")", aceptadoEdicionGlobal, LogFechaHora);
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
                                    respBaja = DllG1.ComunicacionBaja(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, docEnviado, RA[1]);
                                    //bool aceptado = false;
                                    if (respBaja.Codigo == 0)
                                    {
                                        aceptadoEdicionGlobal = true;
                                    }
                                    LogRespuesta(NombreArchivo + " --> " + respBaja.Mensaje + " --> Doc real (" + respBaja.Docmumento + ")", aceptadoEdicionGlobal, LogFechaHora);
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
                                    respBaja = DllG1.ReversionComprobantes(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, docEnviado, RA[1]);
                                    //bool aceptado = false;
                                    if (respBaja.Codigo == 0)
                                    {
                                        aceptadoEdicionGlobal = true;
                                    }
                                    LogRespuesta(NombreArchivo + " --> " + respBaja.Mensaje + " ---> Doc real (" + respBaja.Docmumento + ")", aceptadoEdicionGlobal, LogFechaHora);
                                }
                            }
                            else if (Iniciales == "20" || Iniciales == "40")
                            {
                                resp = DllG1.EnviarPercepcionRetencion(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, ArchivoAEnviar);
                                //bool aceptado = false;
                                if (resp.Codigo == 0)
                                {
                                    aceptadoEdicionGlobal = true;
                                }
                                LogRespuesta(NombreArchivo + " --> " + resp.Mensaje + " ---> Doc real (" + resp.Docmumento + ")", aceptadoEdicionGlobal, LogFechaHora);
                                lblDocEdicion.Text = resp.Docmumento;
                            }
                            else if (Iniciales == "42")
                            {
                                resp = DllG1.EnviarDaeg1(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, ArchivoAEnviar);
                                //bool aceptado = false;
                                if (resp.Codigo == 0)
                                {
                                    aceptadoEdicionGlobal = true;
                                }
                                LogRespuesta(NombreArchivo + " --> " + resp.Mensaje + " ---> Doc real (" + resp.Docmumento + ")", aceptadoEdicionGlobal, LogFechaHora);
                                lblDocEdicion.Text = resp.Docmumento;
                            }

                            if (resp.Codigo == 0)
                            {
                                gb_PostAceptacion.Enabled = true;
                            }
                            else
                            {
                                gb_PostAceptacion.Enabled = false;
                            }
                        }                     
                    }
                    catch(Exception exe)
                    {
                        Log(exe.Message, false, LogFechaHora);

                    }
                }
            }
            catch (Exception e)
            {
                Log(e.Message, false, LogFechaHora);
            }
            if (!chckEdicion.Checked)
            {
                lst_archivo.Items.Clear();
            }           
         
        }

        public void cargaCmbDoc()
        {
            string[] entries = Directory.GetFileSystemEntries(txt_RutaEjemplos.Text, "*", SearchOption.TopDirectoryOnly);

            foreach (var file in entries)
            {
                cmbTipoDoc.Items.Add(Path.GetFileName(file));
                //MessageBox.Show(Path.GetFileName(file));
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
            string cabecera = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:tem=\"http://tempuri.org/\" xmlns:per=\"http://schemas.datacontract.org/2004/07/PeruService.Classes\">"+ Environment.NewLine +
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
                if(arrayRequestLines[i] != "")
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

        public string LeerRequestString(string ruta)
        {
            string line, contenido = "";
            //List<String> ret = new List<string>();
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(ruta);
            while ((line = file.ReadLine()) != null)
            {
                contenido += file.ReadLine() + Environment.NewLine;
            }
            file.Close();
            return contenido;
        }

        private void Utilitario()
        {
            if (rb_ObtenerNombres.Checked)
            {
                MessageBox.Show("Espera mientras se procesa tu petición, esto puede demorar unos minutos!");
                if (Directory.Exists(txt_rutaObtenerNombres.Text))
                {
                    string[] ubicacion = Directory.GetFiles(txt_rutaObtenerNombres.Text);
                    for (int i = 0; i < ubicacion.Length; i++)
                    {
                        Log(Path.GetFileName(ubicacion[i]), true, false);
                    }
                }
                MessageBox.Show("Proceso Culminado! Revisa el Log.");
            }
            else if (rb_Renombrar.Checked)
            {
                MessageBox.Show("Espera mientras se procesa tu petición, esto puede demorar unos minutos!");
                string rutaRenombrados = "\\Renombrados-" + DateTime.Now.Day.ToString("d2") + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Year;
                if (!Directory.Exists(txt_Renombrar.Text + rutaRenombrados))
                {
                    Directory.CreateDirectory(txt_Renombrar.Text + rutaRenombrados);
                }
                if (Directory.Exists(txt_Renombrar.Text))
                {
                    string[] ubicacion = Directory.GetFiles(txt_Renombrar.Text);
                    ts_ProgressBar1.Minimum = 1;
                    ts_ProgressBar1.Maximum = ubicacion.Length;
                    ts_ProgressBar1.Value = 1;
                    ts_ProgressBar1.Step = 1;
                    for (int i = 0; i < ubicacion.Length; i++)
                    {
                        string nombreArchivo = "\\" + txt_Prefijo.Text + Path.GetFileName(ubicacion[i]);
                        string nombreArchivoRemov = "";
                        if (txt_eliminar.Text != "")
                        {
                            nombreArchivoRemov = nombreArchivo.Replace(txt_eliminar.Text, "");
                        }
                        else
                        {
                            nombreArchivoRemov = nombreArchivo;
                        }
                        ts_ProgressBar1.PerformStep();
                        File.Copy(Path.GetFullPath(ubicacion[i]), txt_Renombrar.Text + rutaRenombrados + nombreArchivoRemov, true);
                        Log("Creado el archivo: " + txt_Renombrar.Text + rutaRenombrados + nombreArchivoRemov, true, false);
                    }
                }
                MessageBox.Show("Proceso Culminado! Revisa el Log.");
            }
            else if (rb_Firma.Checked)
            {
                try
                {
                    FirmaDigital firma = new FirmaDigital();
                    string XML = txtRutaXmlFirma.Text;
                    string rutaCertificado = txtRutaCertificado.Text;
                    string claveCertificado = txtClaveCertificado.Text;
                    XmlDocument xmlDocument_sinFirmar = new XmlDocument();
                    xmlDocument_sinFirmar.Load(XML);
                    string rutaXMLFirmado = Path.GetDirectoryName(XML) + "\\Firmado\\";
                                      

                    if (!Directory.Exists(rutaXMLFirmado))
                    {
                        Directory.CreateDirectory(rutaXMLFirmado);
                    }

                    DirectoryInfo di = new DirectoryInfo(rutaXMLFirmado);
                    FileInfo[] files = di.GetFiles();
                    foreach (FileInfo file in files)
                    {
                        file.Delete();
                    }

                    string nombreXMLFirmado = Path.GetFileName(XML);
                    firma.FirmarDocumentoXML(xmlDocument_sinFirmar, rutaCertificado, claveCertificado).Save(rutaXMLFirmado + nombreXMLFirmado);
                    Log("Firmado Exitoso!", true, false);
                    Log("Ruta XML original: " + XML, true, false);
                    Log("Ruta XML Firmado: " + rutaXMLFirmado + nombreXMLFirmado, true, false);

                    CoprimirArchivo(rutaXMLFirmado, nombreXMLFirmado);
                    if (Directory.Exists(rutaXMLFirmado))
                    {
                        System.Diagnostics.Process.Start("explorer.exe", rutaXMLFirmado);
                    }
                }
                catch (Exception ed)
                {
                    MessageBox.Show(ed.Message);
                }
            }
        }

        public void CoprimirArchivo(string rutaComprimir, string nombreArchivo)
        {
            string directotorioDestino = ".\\" + nombreArchivo.Split('.')[0] + ".zip";
            // verificar si existe el archivo y borrarlo para sobre escribirlo
            if (File.Exists(directotorioDestino))
            {
                File.Delete(directotorioDestino);
            }
            //Comprimir
            ZipFile.CreateFromDirectory(rutaComprimir, directotorioDestino);
            File.Move(directotorioDestino, rutaComprimir + Path.GetFileNameWithoutExtension(nombreArchivo) + ".zip");
            Log("Ruta ZIP Firmado: " + rutaComprimir + Path.GetFileNameWithoutExtension(nombreArchivo) + ".zip", true, false);

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

            return RutaDescomprimido + NombreArchivo + "\\" + NombreArchivo + ".xml";
        }

        private void SetPruebas()
        {
            try
            {
                MessageBox.Show("Espera mientras se procesa tu petición, esto puede demorar unos minutos!");
                string[][] arrayOfTxt = RecorreCarpeta(); //Leo los nombres de los archivos .TXT O .txt de la ruta TXTUbicacion
                //int set = 1;
                Log("Cantidad de archivos a procesar: " + arrayOfTxt.Length, true, false);
                Log("Ruta a importar los TXT: " + txtSetRuta.Text, true, false);
                Log("Ruta a exportar los TXT: " + txtSetRutaSalida.Text, true, false);
                string ambiente = AmbienteGlobal;
                for (int i = 0; i < arrayOfTxt.Length; i++)//Envio 1x1 de documentos ubicados en ruta TXTUbicacion
                {
                    try
                    {
                        string nombreArchivoTxt = arrayOfTxt[i][0].Split('.')[0];
                        string rutaArchivoTxt = arrayOfTxt[i][1];                        
                        CambiaContenidoTxt(nombreArchivoTxt, rutaArchivoTxt, ambiente, txtSetRutaSalida.Text + "\\");                        
                    }
                    catch(Exception exc)
                    {
                        Log("Error: " + exc.Message, true, false);
                    }                    
                }
            }
            catch(Exception ex)
            {
                Log("Error: " + ex.Message, true, false);
            }            
        }

        private string CambiaContenidoTxt(string nombreArchivo, string rutaArchivo, string ambiente, string rutaSalida)
        {
            //string ambiente = LeerConfig();
            string line = null;
            string tipoTxt = "";
            int uno = 0;
            string primeraLetra = "";
            var arrayNombreArchivo = nombreArchivo.Split('-');
            if (!nombreArchivo.Substring(0,3).Equals("DAE"))
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
                    if(tipoTxt.Equals("40") || tipoTxt.Equals("20"))
                    {
                        if (camposLine[0].Equals("03"))
                        {
                            string newLine = "";
                            string oldLine = line;
                            string[] arrayLine = oldLine.Split('|');
                            string tipoDoc = arrayLine[1].Split('-')[0];
                            if(tipoDoc.Equals("07") || tipoDoc.Equals("08"))
                            {
                                arrayLine[1] = tipoDoc + "-0001-1234";
                            }
                            else
                            {
                                arrayLine[1] = "01-0001-1234";
                            }
                            arrayLine[2] = txtSetFecha.Text;
                            arrayLine[5] = txtSetFecha.Text;
                            arrayLine[10] = txtSetFecha.Text;


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
                            arrayLine[1] = txtSetFecha.Text;
                            if (ambiente.Equals("PRD"))
                            {
                                if (tipoTxt.Equals("20"))
                                {
                                    arrayLine[3] = txt_PrdRet.Text + "-" + numeroConDosCotas;
                                }
                                else if (tipoTxt.Equals("40"))
                                {
                                    arrayLine[3] = txt_PrdPerc.Text + "-" + numeroConDosCotas;
                                }
                            }
                            else
                            {
                                if (tipoTxt.Equals("20"))
                                {
                                    arrayLine[3] = txt_DemoRet.Text + "-" + numeroConDosCotas;
                                }
                                else if (tipoTxt.Equals("40"))
                                {
                                    arrayLine[3] = txt_DemoPerc.Text + "-" + numeroConDosCotas;
                                }
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
                            arrayLine[3] = txtSetFecha.Text + " 23:00:00";
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
                    else if(!tipoTxt.Equals("DAE"))
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
                            arrayLine[1] = txtSetFecha.Text + " 23:00:00";
                            if (ambiente.Equals("PRD"))
                            {
                                if (tipoTxt.Equals("01"))
                                {
                                    arrayLine[3] = txt_PrdFact.Text + "-" + numeroConDosCotas;
                                }
                                else if (tipoTxt.Equals("03"))
                                {
                                    arrayLine[3] = txt_PrdBol.Text + "-" + numeroConDosCotas;
                                }
                                else if (tipoTxt.Equals("07"))
                                {
                                    if (primeraLetra.Equals("F"))
                                    {
                                        arrayLine[3] = txt_PrdNc.Text.Split('/')[0] + "-" + numeroConDosCotas;
                                    }
                                    else
                                    {
                                        arrayLine[3] = txt_PrdNc.Text.Split('/')[1] + "-" + numeroConDosCotas;
                                    }
                                }
                                else if (tipoTxt.Equals("08"))
                                {
                                    if (primeraLetra.Equals("F"))
                                    {
                                        arrayLine[3] = txt_PrdNd.Text.Split('/')[0] + "-" + numeroConDosCotas;
                                    }
                                    else
                                    {
                                        arrayLine[3] = txt_PrdNd.Text.Split('/')[1] + "-" + numeroConDosCotas;
                                    }
                                }
                                else if (tipoTxt.Equals("09"))
                                {
                                    arrayLine[1] = txt_PrdGuia.Text;
                                    arrayLine[2] = numeroConDosCotas.ToString();
                                    arrayLine[3] = txtSetFecha.Text + " 23:00:00";
                                }
                                else if (tipoTxt.Equals("42"))
                                {
                                    arrayLine[3] = txt_PrdDae.Text + "-" + numeroConDosCotas;
                                }
                            }
                            else
                            {
                                if (tipoTxt.Equals("01"))
                                {
                                    arrayLine[3] = txt_DemoFact.Text + "-" + numeroConDosCotas;
                                }
                                else if (tipoTxt.Equals("03"))
                                {
                                    arrayLine[3] = txt_DemoBol.Text + "-" + numeroConDosCotas;
                                } 
                                else if (tipoTxt.Equals("07"))
                                {
                                    if (primeraLetra.Equals("F"))
                                    {
                                        arrayLine[3] = txt_DemoNc.Text.Split('/')[0] + "-" + numeroConDosCotas;
                                    }
                                    else
                                    {
                                        arrayLine[3] = txt_DemoNc.Text.Split('/')[1] + "-" + numeroConDosCotas;
                                    }
                                    tipoNota = arrayLine[3].ToString().Substring(0,1);
                                }
                                else if (tipoTxt.Equals("08"))
                                {
                                    if (primeraLetra.Equals("F"))
                                    {
                                        arrayLine[3] = txt_DemoNd.Text.Split('/')[0] + "-" + numeroConDosCotas;
                                    }
                                    else
                                    {
                                        arrayLine[3] = txt_DemoNd.Text.Split('/')[1] + "-" + numeroConDosCotas;
                                    }
                                    tipoNota = arrayLine[3].ToString().Substring(0, 1);

                                }
                                else if (tipoTxt.Equals("09"))
                                {
                                    arrayLine[1] = txt_DemoGuia.Text;
                                    arrayLine[2] = numeroConDosCotas.ToString();
                                    arrayLine[3] = txtSetFecha.Text + " 23:00:00";
                                }
                                else if (tipoTxt.Equals("42"))
                                {
                                    arrayLine[3] = txt_DemoDae.Text + "-" + numeroConDosCotas;
                                }
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
                            if(tipoNota == "B")
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
                        if (ambiente.Equals("PRD"))
                        {
                            arrayLine[0] = txtSetFecha.Text; //Fecha 1
                            arrayLine[5] = txt_PrdDae.Text + "-" + numeroConDosCotas;
                            arrayLine[11] = "55555555555";
                            arrayLine[14] = "55555555555";
                        }
                        else
                        {
                            arrayLine[0] = txtSetFecha.Text; //Fecha 1
                            arrayLine[5] = txt_DemoDae.Text + "-" + numeroConDosCotas;
                            arrayLine[11] = "55555555555";
                            arrayLine[14] = "55555555555";
                        }
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
                if (File.Exists(rutaSalida + nombreArchivo + "-Test" + ".txt"))
                {
                    File.Delete(rutaSalida + nombreArchivo + "-Test" + ".txt");
                }
                System.IO.File.WriteAllText(rutaSalida + nombreArchivo + "-Test" + ".txt", dataTxt);
                Log("Creado: " + nombreArchivo + "-Test", true, false);
                return rutaSalida + nombreArchivo + "-Test" + ".txt";
            }
        }

        public string[][] RecorreCarpeta()
        {
            try
            {
                List<string[]> LstArchivosTxt = new List<string[]>();
                DirectoryInfo di = new DirectoryInfo(txtSetRuta.Text);
                foreach (var fi in di.GetFiles())
                {
                    string cadena = fi.Name + "|" + fi.FullName;
                    string[] arrayOfCadena = cadena.Split('|');
                    LstArchivosTxt.Add(arrayOfCadena);
                }
                if (LstArchivosTxt != null)
                {
                    arrayOfArchivosTxt = LstArchivosTxt.ToArray();
                }
                else
                {
                    MessageBox.Show("No hay archivos por procesar");
                }
                return arrayOfArchivosTxt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ListadoTxt -" + ex.ToString());
                return null;
            }
        }

        private void EmisionG1()
        {
            try
            {
                ts_ProgressBar1.Minimum = 1;
                ts_ProgressBar1.Maximum = lst_archivo.Items.Count;
                ts_ProgressBar1.Value = 1;
                ts_ProgressBar1.Step = 1;

                for (int i = 0; i < lst_archivo.Items.Count; i++)
                {
                    string NombreArchivo = Path.GetFileName(lst_archivo.Items[i].ToString());

                    (int Codigo, string Mensaje, string Documento) resp;
                    string rutaDestino = "";
                    ts_ProgressBar1.PerformStep();
                    if (chckEdicion.Checked)
                    {
                        FolderBrowserDialog dlCarpeta = new FolderBrowserDialog();
                        dlCarpeta.RootFolder = System.Environment.SpecialFolder.Desktop;
                        dlCarpeta.ShowNewFolderButton = false;
                        dlCarpeta.Description = "Selecciona la carpeta";
                        if (dlCarpeta.ShowDialog() == DialogResult.OK)
                        {
                            rutaDestino = dlCarpeta.SelectedPath;
                        }
                        DirectoryInfo di = new DirectoryInfo(lst_archivo.Items[i].ToString());
                        string nombreXml = di.Name;
                        resp.Mensaje = request.GenerarRequest(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, lst_archivo.Items[i].ToString(), rutaDestino + "/" + nombreXml);

                    }
                    else
                    {
                        DirectoryInfo di = new DirectoryInfo(lst_archivo.Items[i].ToString());
                        string iniciales = di.Name.Split('-')[1];
                        if (iniciales == "42")
                        {
                            resp = DllG1.EnviarDaeg1(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, lst_archivo.Items[i].ToString());
                        }
                        else
                        {
                            resp = DllG1.Enviar(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, lst_archivo.Items[i].ToString());
                        }
                    }
                    //resp = DllProd.FacturaBoleta(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, listBox1.Items[i].ToString());
                    Log(NombreArchivo + " --> " + resp.Mensaje, true, LogFechaHora);
                }
            }
            catch (Exception e)
            {
                Log(e.Message, false, LogFechaHora);
            }
            lst_archivo.Items.Clear();
        }

        private void EnvioSunat()
        {
            for (int i = 0; i < lst_archivo.Items.Count; i++)
            {
                DirectoryInfo di = new DirectoryInfo(lst_archivo.Items[i].ToString());
                string extension = "";
                if (di.Name.IndexOf(".") > 0)
                {
                    extension = di.Name.Split('.')[1];
                }
                if(extension == "zip")
                {
                    
                }
                else
                {

                }
            }
        }

        private void EmisionG2()
        {
            try
            {
                ts_ProgressBar1.Minimum = 1;
                ts_ProgressBar1.Maximum = lst_archivo.Items.Count;
                ts_ProgressBar1.Value = 1;
                ts_ProgressBar1.Step = 1;
                string[] EnviarDocumento = null;

                for (int i = 0; i < lst_archivo.Items.Count; i++)
                {
                    (int Codigo, string Mensaje, string Documento) resp;
                    string rutaDestino = "";
                    ts_ProgressBar1.PerformStep();
                    if (chckEdicion.Checked)
                    {
                        FolderBrowserDialog dlCarpeta = new FolderBrowserDialog();
                        dlCarpeta.RootFolder = System.Environment.SpecialFolder.Desktop;
                        dlCarpeta.ShowNewFolderButton = false;
                        dlCarpeta.Description = "Selecciona la carpeta";
                        if (dlCarpeta.ShowDialog() == DialogResult.OK)
                        {
                            rutaDestino = dlCarpeta.SelectedPath;
                        }
                        DirectoryInfo di = new DirectoryInfo(lst_archivo.Items[i].ToString());
                        string nombreXml = di.Name;
                        string ruta = rutaDestino + "\\" + nombreXml;
                        resp.Mensaje = request.GenerarRequest(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, lst_archivo.Items[i].ToString(), ruta);

                    }
                    else
                    {
                        DirectoryInfo di = new DirectoryInfo(lst_archivo.Items[i].ToString());
                        string iniciales = "";
                        if (di.Name.IndexOf("_") > 0)
                        {
                            iniciales = di.Name.Split('_')[0];
                        }
                        if (iniciales == "DAE")
                        {
                            List<String> listado = new List<string>();
                            listado.Add(lst_archivo.Items[i].ToString());
                            EnviarDocumento = DLLG2.EnviosDCH(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, listado.ToArray());
                        }
                        else
                        {
                            List<String> listado = new List<string>();
                            listado.Add(lst_archivo.Items[i].ToString());
                            EnviarDocumento = DLLG2.EnvioNotaCreditoDCH(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, listado.ToArray());
                        }
                    }
                    Log(EnviarDocumento[0].Split('|')[0] + " - " + EnviarDocumento[0].Split('|')[1], true, LogFechaHora);
                }
            }
            catch (Exception e)
            {
                Log(e.Message, false, LogFechaHora);
            }
            lst_archivo.Items.Clear();
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
                                txt_Token.Text = valor;
                            }
                            else if (clave == "LogHora")
                            {
                                if (valor == "SI")
                                {
                                    LogFechaHora = true;
                                    chk_LogHora.Checked = true;
                                }
                                else
                                {
                                    LogFechaHora = false;
                                    chk_LogHora.Checked = false;
                                }
                            }
                            else if (clave == "RutaEjemplos")
                            {
                                txt_RutaEjemplos.Text = valor;
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

        private void CargaParametros()
        {
            try
            {
                leerConfigPersonal();
                string rutaCert = ConfigurationManager.AppSettings["RutaCertificado"];
                string claveCert = ConfigurationManager.AppSettings["ClaveCertificado"];
                txtRutaCertificado.Text = rutaCert;
                txtClaveCertificado.Text = claveCert;

                string usuarioConfig = ConfigurationManager.AppSettings["Usuario"];
                string claveConfig = ConfigurationManager.AppSettings["Clave"];
                string rucConfig = ConfigurationManager.AppSettings["Ruc"];
                txt_RucConfig.Text = rucConfig;
                txt_UserConfig.Text = usuarioConfig;
                txt_ClaveConfig.Text = claveConfig;

                string usuarioConfigPRD = ConfigurationManager.AppSettings["UsuarioPRD"];
                string claveConfigPRD = ConfigurationManager.AppSettings["ClavePRD"];
                string rucConfigPRD = ConfigurationManager.AppSettings["RucPRD"];
                txt_RucConfigPRD.Text = rucConfigPRD;
                txt_UserConfigPRD.Text = usuarioConfigPRD;
                txt_ClaveConfigPRD.Text = claveConfigPRD;

                //string rutaEjemplos = ConfigurationManager.AppSettings["RutaEjemplos"];
                string rutaEjemplosProcesados = ConfigurationManager.AppSettings["RutaEjemplosProcesados"];
                //string tokenConfig = ConfigurationManager.AppSettings["Token"];
                //string logHora = ConfigurationManager.AppSettings["LogHora"];
                txtRutaProcesados.Text = rutaEjemplosProcesados;
                if (!Directory.Exists(rutaEjemplosProcesados))
                {
                    Directory.CreateDirectory(rutaEjemplosProcesados);
                }
               

                //string hostPse = ConfigurationManager.AppSettings["HostBdPse"];
                //string puertoPse = ConfigurationManager.AppSettings["PuertoBdPse"]; 
                //string usuarioPse = ConfigurationManager.AppSettings["UsuarioBdPse"];
                //string clavePse = ConfigurationManager.AppSettings["ClaveBdPse"];
               
                //string hostPse20 = ConfigurationManager.AppSettings["HostBdPse20"];
                //string puertoPse20 = ConfigurationManager.AppSettings["PuertoBdPse20"];
                //string usuarioPse20 = ConfigurationManager.AppSettings["UsuarioBdPse20"];
                //string clavePse20 = ConfigurationManager.AppSettings["ClaveBdPse20"];


                //string hostOse = ConfigurationManager.AppSettings["HostBdOse"];
                //string puertoOse = ConfigurationManager.AppSettings["PuertoBdOse"];
                //string usuarioOse = ConfigurationManager.AppSettings["UsuarioBdOse"];
                //string claveOse = ConfigurationManager.AppSettings["ClaveBdOse"];


                string factDemo = ConfigurationManager.AppSettings["FactDemo"];
                string bolDemo = ConfigurationManager.AppSettings["BolDemo"];
                string NcDemo = ConfigurationManager.AppSettings["NCDemo"];
                string NdDemo = ConfigurationManager.AppSettings["NDDemo"];
                string GuiaDemo = ConfigurationManager.AppSettings["GuiaDemo"];
                string DaeDemo = ConfigurationManager.AppSettings["DaeDemo"];
                string RetDemo = ConfigurationManager.AppSettings["RetDemo"];
                string PerDemo = ConfigurationManager.AppSettings["PercDemo"];
                txt_DemoFact.Text = factDemo;
                txt_DemoBol.Text = bolDemo;
                txt_DemoNc.Text = NcDemo;
                txt_DemoNd.Text = NdDemo;
                txt_DemoGuia.Text = GuiaDemo;
                txt_DemoDae.Text = DaeDemo;
                txt_DemoRet.Text = RetDemo;
                txt_DemoPerc.Text = PerDemo;

                string factPrd = ConfigurationManager.AppSettings["FactPRD"];
                string bolPrd = ConfigurationManager.AppSettings["BolPRD"];
                string NcPrd = ConfigurationManager.AppSettings["NCPRD"];
                string NdPrd = ConfigurationManager.AppSettings["NDPRD"];
                string GuiaPrd = ConfigurationManager.AppSettings["GuiaPRD"];
                string DaePrd = ConfigurationManager.AppSettings["DaePRD"];
                string RetPrd = ConfigurationManager.AppSettings["RetPRD"];
                string PerPrd = ConfigurationManager.AppSettings["PercPRD"];
                txt_PrdFact.Text = factPrd;
                txt_PrdBol.Text = bolPrd;
                txt_PrdNc.Text = NcPrd;
                txt_PrdNd.Text = NdPrd;
                txt_PrdGuia.Text = GuiaPrd;
                txt_PrdDae.Text = DaePrd;
                txt_PrdRet.Text = RetPrd;
                txt_PrdPerc.Text = PerPrd;

                if (AmbienteGlobal == "PRD")
                {
                    usuarioConfig = usuarioConfigPRD;
                    claveConfig = claveConfigPRD;
                    rucConfig = rucConfigPRD;
                }
                txt_UserDescarga.Text = usuarioConfig;
                txt_ClaveDescarga.Text = claveConfig;
                txt_RucDescarga.Text = rucConfig;
                txt_UsuarioEmision.Text = usuarioConfig;
                txt_ClaveEmision.Text = claveConfig;
                txt_RucEmision.Text = rucConfig;     

            }
            catch(Exception e)
            {
                
            }
        }

        public void Log(string msg, bool msj, bool fecha)
        {
            if (fecha)
            {
                if (msj)
                {
                    this.rtb_Log.SelectionStart = this.rtb_Log.Text.Length;
                    rtb_Log.SelectionColor = Color.Black;
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
                    rtb_Log.SelectionColor = Color.Black;
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

        public void LogRespuesta(string msg, bool msj, bool fecha)
        {
            if (fecha)
            {
                if (msj)
                {
                    this.rtb_Log.SelectionStart = this.rtb_Log.Text.Length;
                    rtb_Log.SelectionColor = Color.DarkBlue;
                    //rtb_Log.SelectionFont = new Font(rtb_Log.Font, FontStyle.Bold);
                    rtb_Log.AppendText("[" + DateTime.Now.Day.ToString("d2") + "-" + DateTime.Now.Month.ToString("d2") + "-" + DateTime.Now.Year + " " +
                    DateTime.Now.Hour.ToString("d2") + ":" + DateTime.Now.Minute.ToString("d2") + ":" + DateTime.Now.Second.ToString("d2") + "] " + msg + Environment.NewLine);
                }
                else
                {
                    this.rtb_Log.SelectionStart = this.rtb_Log.Text.Length;
                    rtb_Log.SelectionColor = Color.Red;
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
                    rtb_Log.SelectionColor = Color.DarkBlue;
                    rtb_Log.AppendText(msg + Environment.NewLine);
                }
                else
                {
                    this.rtb_Log.SelectionStart = this.rtb_Log.Text.Length;
                    rtb_Log.SelectionColor = Color.Red;
                    rtb_Log.AppendText(msg + Environment.NewLine);
                    //msj = true;
                }
                this.rtb_Log.ScrollToCaret();
            }

        }

        private string ObtieneDesde()
        {
            string dia = dateTimePicker1.Value.Day.ToString();
            string mes = dateTimePicker1.Value.Month.ToString();
            string año = dateTimePicker1.Value.Year.ToString();            
            if (dia.Length == 1)
            {
                dia = "0" + dia;
            }
            if (mes.Length == 1)
            {
                mes = "0" + mes;
            }
            string desde = año + "-" + mes + "-" + dia;
            return desde;            
        }

        private string ObtieneFechaHoy()
        {
            string dia = DateTime.Today.Day.ToString();
            string mes = DateTime.Today.Month.ToString();
            string año = DateTime.Today.Year.ToString();
            if (dia.Length == 1)
            {
                dia = "0" + dia;
            }
            if (mes.Length == 1)
            {
                mes = "0" + mes;
            }
            string desde = año + "-" + mes + "-" + dia;
            return desde;
        }

        private string ObtieneHasta()
        {
            string dia2 = dateTimePicker2.Value.Day.ToString();
            string mes2 = dateTimePicker2.Value.Month.ToString();
            string año2 = dateTimePicker2.Value.Year.ToString();
            if (dia2.Length == 1)
            {
                dia2 = "0" + dia2;
            }
            if (mes2.Length == 1)
            {
                mes2 = "0" + mes2;
            }
            string hasta = año2 + "-" + mes2 + "-" + dia2;
            return hasta;
        }

        private string ObtieneAmbiente()
        {
            String Ambiente = "";
            if (radioButton3.Checked)
            {
                Ambiente = "PSE";
            }
            else if (radioButton4.Checked)
            {
                Ambiente = "OSE";
            }
            else
            {
                Ambiente = "PSE20";
            }
            return Ambiente;
        }

        private string ObtieneCadenaConexion()
        {
            string Ambiente = ObtieneAmbiente();
            string connectionString = "";
            if (Ambiente == "PSE")
            {
                connectionString =
                "datasource=" + txt_HostDPSE.Text +
                ";port=" + txt_PortDPSE.Text +
                ";username=" + txt_UserDPSE.Text +
                ";password=" + txt_PassDPSE.Text;
            }
            else if (Ambiente == "PSE20")
            {
                connectionString =
                "datasource=" + txt_HostPse20.Text +
                ";port=" + txt_PortPse20.Text +
                ";username=" + txt_UserPse20.Text +
                ";password=" + txt_PassPse20.Text;
            }
            else
            {
                connectionString =
                "datasource=" + txt_HostBdOse.Text +
                ";port=" + txt_PortBdOse.Text +
                ";username=" + txt_UserBdOse.Text +
                ";password=" + txt_PassBdOse.Text;
            }
            return connectionString;
        }

        private string ObtieneTipoDoc(string Nombre)
        {
            string tipo = "";
            if (Nombre != "")
            {
                try
                {
                    tipo = Nombre.Split('-')[1];
                    return tipo;
                }
                catch(Exception ex)
                {                    
                    return null;
                }
            }
            return null;
        }

        private void ProcesaBD()
        {
            string desde = ObtieneDesde(), hasta = ObtieneHasta(), ruc = txt_RucPse.Text, QueryLog = "", Ambiente = ObtieneAmbiente();        
            bool aceptado = false, emision = false, creacion = false, activo = false;
            Conexion conex;
            MessageBox.Show("Espera mientras se procesa tu petición, esto puede demorar unos minutos!");
            ts_ProgressBar1.Minimum = 1;
            ts_ProgressBar1.Maximum = 3;
            ts_ProgressBar1.Value = 1;
            ts_ProgressBar1.Step = 1;
            //Log("----------------------------", true, false);
            Log("Cargando resultados...", true, false);

            ts_ProgressBar1.PerformStep();
            QueryLog += "Ruc(s): " + ruc + Environment.NewLine;
            QueryLog += "Razon social: " + txt_RazonS.Text + Environment.NewLine;
            if (Ambiente.Equals("PSE"))
            {
                QueryLog += "Servicio PSE 2.1" + Environment.NewLine;
            }
            else if (Ambiente.Equals("PSE20"))
            {
                QueryLog += "Servicio PSE 2.0" + Environment.NewLine;
            }
            else
            {
                QueryLog += "Servicio OSE" + Environment.NewLine;
            }

            if (checkBox4.Checked && radioButton2.Checked)
            {
                QueryLog += "Fecha Desde: " + desde + " Hasta: " + hasta + Environment.NewLine;
                QueryLog += "Filtrado por fecha de creación" + Environment.NewLine;
                creacion = true;
            }
            else if (checkBox4.Checked && radioButton1.Checked)
            {
                QueryLog += "Fecha Desde: " + desde + " Hasta: " + hasta + Environment.NewLine;
                QueryLog += "Filtrado por fecha de emisión" + Environment.NewLine;
                emision = true;            
            }
            if (checkBox5.Checked)
            {
                activo = true;
                QueryLog += "Filtrado por documentos activos" + Environment.NewLine;
            }
            if (checkBox6.Checked)
            {
                aceptado = true;
                QueryLog += "Filtrado por documentos aceptados" + Environment.NewLine;
            }
            conex = new Conexion();
            //conex.conection(ObtieneCadenaConexion());
            Ambiente = ObtieneAmbiente();
            List<String> listDocumentos = conex.getDocumentos(ruc, Ambiente,
                desde, hasta, "", "", activo, emision, creacion, aceptado, ObtieneCadenaConexion());
            if(listDocumentos != null)
            {
                var arrayDocumentos = listDocumentos.ToArray();
                for (int i = 0; i < arrayDocumentos.Length; i++)
                {
                    string linea = arrayDocumentos[i];
                    QueryLog += linea + Environment.NewLine;
                }
                ts_ProgressBar1.PerformStep();
                Log("Resultados cargados con Exito!", true, false);
                Log(QueryLog, true, false);
            } 
        }

        private void GuardaConfigOtros()
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //config.AppSettings.Settings["RutaEjemplos"].Value = txt_RutaEjemplos.Text;
                //config.AppSettings.Settings["Token"].Value = txt_TokenConfig.Text;
                //if (chk_LogHora.Checked)
                //{
                //    config.AppSettings.Settings["LogHora"].Value = "SI";
                //}
                //else
                //{
                //    config.AppSettings.Settings["LogHora"].Value = "NO";
                //}
                config.AppSettings.Settings["RutaCertificado"].Value = txtRutaCertificado.Text;
                config.AppSettings.Settings["ClaveCertificado"].Value = txtClaveCertificado.Text;

                config.Save(ConfigurationSaveMode.Modified);
                MessageBox.Show("Actualizacion Exitosa!");
                CargaParametros();
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

        private void GuardaConfigBD()
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
                CargaParametros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.ToString());
            }
            CargaParametros();
            DialogResult result;
            result = MessageBox.Show("Los cambios se harán notables al reiniciar el programa. ¿Desea reiniciarlo ahora?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Restart();
        }

        private void GuardaConfigPSE()
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //PSE DEMO
                config.AppSettings.Settings["Usuario"].Value = txt_UserConfig.Text;
                config.AppSettings.Settings["Ruc"].Value = txt_RucConfig.Text;
                config.AppSettings.Settings["Clave"].Value = txt_ClaveConfig.Text;
                config.AppSettings.Settings["FactDemo"].Value = txt_DemoFact.Text;
                config.AppSettings.Settings["BolDemo"].Value = txt_DemoBol.Text;
                config.AppSettings.Settings["NCDemo"].Value = txt_DemoNc.Text;
                config.AppSettings.Settings["NDDemo"].Value = txt_DemoNd.Text;
                config.AppSettings.Settings["GuiaDemo"].Value = txt_DemoGuia.Text;
                config.AppSettings.Settings["DaeDemo"].Value = txt_DemoDae.Text;
                config.AppSettings.Settings["RetDemo"].Value = txt_DemoRet.Text;
                config.AppSettings.Settings["PercDemo"].Value = txt_DemoPerc.Text;
                //PSE DEMO
                //PSE PRD
                config.AppSettings.Settings["UsuarioPRD"].Value = txt_UserConfigPRD.Text;
                config.AppSettings.Settings["RucPRD"].Value = txt_RucConfigPRD.Text;
                config.AppSettings.Settings["ClavePRD"].Value = txt_ClaveConfigPRD.Text;
                config.AppSettings.Settings["FactPRD"].Value = txt_PrdFact.Text;
                config.AppSettings.Settings["BolPRD"].Value = txt_PrdBol.Text;
                config.AppSettings.Settings["NCPRD"].Value = txt_PrdNc.Text;
                config.AppSettings.Settings["NDPRD"].Value = txt_PrdNd.Text;
                config.AppSettings.Settings["GuiaPRD"].Value = txt_PrdGuia.Text;
                config.AppSettings.Settings["DaePRD"].Value = txt_PrdDae.Text;
                config.AppSettings.Settings["RetPRD"].Value = txt_PrdRet.Text;
                config.AppSettings.Settings["PercPRD"].Value = txt_PrdPerc.Text;
                //PSE PRD              
               


                config.Save(ConfigurationSaveMode.Modified);
                MessageBox.Show("Actualizacion Exitosa!");
                CargaParametros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.ToString());
            }
            //CargaParametros();
            DialogResult result;
            result = MessageBox.Show("Los cambios se harán notables al reiniciar el programa. ¿Desea reiniciarlo ahora?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Restart();
        }


        #endregion

        #region Componentes Formulario

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (rtb_consultas.Text != "")
            {
                //cmd_Procesar2.Enabled = true;
            }
            else
            {
                //cmd_Procesar2.Enabled = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (DllG1.ValidaAcceso(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text))
            {
                Log("Credenciales Validas", true, LogFechaHora);
            }
            else
            {
                Log("Credenciales Incorrectas", false, LogFechaHora);
            }
        }

        private void tab_HijoEmision_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmd_Procesar2.Enabled = false;
            //if (tab_HijoEmision.SelectedTab == tab_Pse)
            //{
            //    lbl_Seccion.Text = "Emision PSE 2.1";
            //}
            //if (tab_HijoEmision.SelectedTab == tab_G1)
            //{
            //    lbl_Seccion.Text = "Emision G1";
            //}
            //if (tab_HijoEmision.SelectedTab == tab_G2)
            //{
            //    lbl_Seccion.Text = "Emision G2";
            //}
        }

        private void tab_HijoTools_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmd_Procesar2.Enabled = false;
            if (tab_HijoTools.SelectedTab == tab_ToolFaby)
            {
                lbl_Seccion.Text = "Daily Task";
            }
            if (tab_HijoTools.SelectedTab == tab_Descargas)
            {
                lbl_Seccion.Text = "Descarga de Documentos PSE";
            }
            if (tab_HijoTools.SelectedTab == tab_Set)
            {
                lbl_Seccion.Text = "Set de Pruebas";
            }
            if (tab_HijoTools.SelectedTab == tab_Otros)
            {
                lbl_Seccion.Text = "Otras utilidades";
            }
        }

        private void tab_HijoConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmd_Procesar2.Enabled = false;
            if (tab_HijoConfig.SelectedTab == tab_configBd)
            {
                lbl_Seccion.Text = "Configuración BD";
            }
            if (tab_HijoConfig.SelectedTab == tab_configPse)
            {
                lbl_Seccion.Text = "Configuración PSE";
            }
            if (tab_HijoConfig.SelectedTab == tab_configOtros)
            {
                lbl_Seccion.Text = "Configuración Otros";
            }
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //.Enabled = true;
            if(tab_Principal.SelectedTab == tab_Emision)
            {
                lbl_Seccion.Text = "Emision PSE 2.1";

                //if (tab_HijoEmision.SelectedTab == tab_Pse)
                //{
                //    lbl_Seccion.Text = "Emision PSE 2.1";
                //}
                //if (tab_HijoEmision.SelectedTab == tab_G1)
                //{
                //    lbl_Seccion.Text = "Emision G1";
                //}
                //if (tab_HijoEmision.SelectedTab == tab_G2)
                //{
                //    lbl_Seccion.Text = "Emision G2";
                //}
            }else if (tab_Principal.SelectedTab == tab_Tools)
            {
                if (tab_HijoTools.SelectedTab == tab_ToolFaby)
                {
                    lbl_Seccion.Text = "Daily Task";
                }
                if (tab_HijoTools.SelectedTab == tab_Descargas)
                {
                    lbl_Seccion.Text = "Descarga de Documentos PSE";
                }
                if (tab_HijoTools.SelectedTab == tab_Set)
                {
                    lbl_Seccion.Text = "Set de Pruebas";
                }
                if (tab_HijoTools.SelectedTab == tab_Otros)
                {
                    lbl_Seccion.Text = "Otras utilidades";
                }
            }else if(tab_Principal.SelectedTab == tab_Config)
            {
                if (tab_HijoConfig.SelectedTab == tab_configBd)
                {
                    lbl_Seccion.Text = "Configuración BD";
                    //cmd_Procesar2.Enabled = true;

                }
                if (tab_HijoConfig.SelectedTab == tab_configPse)
                {
                    lbl_Seccion.Text = "Configuración PSE";
                    //cmd_Procesar2.Enabled = true;
                }
            }else if(tab_Principal.SelectedTab == tab_Consultas)
            {
                if (tab_HijoConsultas.SelectedTab == tab_ConsultaSunat)
                {
                    lbl_Seccion.Text = "Consulta de Documentos-Sunat";
                }
                if (tab_HijoConsultas.SelectedTab == tab_consultaBd)
                {
                    lbl_Seccion.Text = "Consulta de Base de Datos";
                }
            }
        }

        private void tab_HijoConsultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmd_Procesar2.Enabled = false;
            if (tab_HijoConsultas.SelectedTab == tab_ConsultaSunat)
            {
                lbl_Seccion.Text = "Consulta de Documentos-Sunat";
            }
            if (tab_HijoConsultas.SelectedTab == tab_consultaBd)
            {
                lbl_Seccion.Text = "Consulta de Base de Datos";
            }
        }

        private void Cmd_Procesar_Click(object sender, EventArgs e)
        {
            #region Emision

            Log(Environment.NewLine + Environment.NewLine + "-------------------------------------------------------------------------------", true, false);

            if (lbl_Seccion.Text == "Emision PSE 2.1")
            {
                if (AmbienteGlobal == "PRD" && txt_RucEmision.Text != "55555555555")
                {
                    if (MessageBox.Show("Estas seguro de enviar un documento en Produccion para el ruc: " + txt_RucEmision.Text + "?", "Advertencia", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Emision();
                    }
                }
                else
                {
                    Emision();

                }
            }
            else if (lbl_Seccion.Text == "Emision G1")
            {
                if (AmbienteGlobal == "PRD" && txt_RucEmision.Text != "55555555555")
                {
                    if (MessageBox.Show("Estas seguro de enviar un documento en Produccion para el ruc: " + txt_RucEmision.Text + "?", "Advertencia", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        EmisionG1();
                    }
                }
                else
                {
                    EmisionG1();

                }
            }
            else if (lbl_Seccion.Text == "Emision G2")
            {
                if (AmbienteGlobal == "PRD" && txt_RucEmision.Text != "55555555555")
                {
                    if (MessageBox.Show("Estas seguro de enviar un documento en Produccion para el ruc: " + txt_RucEmision.Text + "?", "Advertencia", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        EmisionG2();
                    }
                }
                else
                {
                    EmisionG2();

                }
            }              


            #endregion

            #region Tool

            else if (lbl_Seccion.Text == "Daily Task")
            {
                if (cmb_combo.Text == "BajasCancelado")
                {
                    Bajas();
                }
                else if (cmb_combo.Text == "Desactivar")
                {
                    Desactivar();
                }
                else if(cmb_combo.Text == "EliminarPDF")
                {
                    EliminarPDF();
                }
                else
                {
                    DesactivarOSE();
                }

            }
            else if (lbl_Seccion.Text == "Descarga de Documentos PSE")
            {
                Descargas();
            }
            else if (lbl_Seccion.Text == "Set de Pruebas")
            {
                SetPruebas();
            }
            else if (lbl_Seccion.Text == "Otras utilidades")
            {
                Utilitario();
            }

            #endregion

            #region Consultas

            else if (lbl_Seccion.Text == "Consulta de Documentos-Sunat")
            {
                Consultas();
            }
            else if (lbl_Seccion.Text == "Consulta de Base de Datos")
            {
                ProcesaBD();
            }

            #endregion

            #region Configuracion

            else if (lbl_Seccion.Text == "Configuración BD")
            {
                GuardaConfigBD();
            }
            else if (lbl_Seccion.Text == "Configuración PSE")
            {
                GuardaConfigPSE();
            }

            #endregion

        }

        private void Cmd_Procesar2_Click(object sender, EventArgs e)
        {
            #region Emision

            Log(Environment.NewLine + Environment.NewLine + "-------------------------------------------------------------------------------", true, false);

            if (lbl_Seccion.Text == "Emision PSE 2.1")
            {
                if (AmbienteGlobal == "PRD" && txt_RucEmision.Text != "55555555555")
                {
                    if (MessageBox.Show("Estas seguro de enviar un documento en Produccion para el ruc: " + txt_RucEmision.Text + "?", "Advertencia", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Emision();
                    }
                }
                else
                {
                    Emision();

                }
            }
            else if (lbl_Seccion.Text == "Emision G1")
            {
                if (AmbienteGlobal == "PRD" && txt_RucEmision.Text != "55555555555")
                {
                    if (MessageBox.Show("Estas seguro de enviar un documento en Produccion para el ruc: " + txt_RucEmision.Text + "?", "Advertencia", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        EmisionG1();
                    }
                }
                else
                {
                    EmisionG1();

                }
            }
            else if (lbl_Seccion.Text == "Emision G2")
            {
                if (AmbienteGlobal == "PRD" && txt_RucEmision.Text != "55555555555")
                {
                    if (MessageBox.Show("Estas seguro de enviar un documento en Produccion para el ruc: " + txt_RucEmision.Text + "?", "Advertencia", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        EmisionG2();
                    }
                }
                else
                {
                    EmisionG2();

                }
            }


            #endregion

            #region Tool

            else if (lbl_Seccion.Text == "Daily Task")
            {
                if (cmb_combo.Text == "BajasCancelado")
                {
                    Bajas();
                }
                else if (cmb_combo.Text == "Desactivar")
                {
                    Desactivar();
                }
                else if (cmb_combo.Text == "EliminarPDF")
                {
                    EliminarPDF();
                }
                else
                {
                    DesactivarOSE();
                }

            }
            else if (lbl_Seccion.Text == "Descarga de Documentos PSE")
            {
                Descargas();
            }
            else if (lbl_Seccion.Text == "Set de Pruebas")
            {
                SetPruebas();
            }
            else if (lbl_Seccion.Text == "Otras utilidades")
            {
                Utilitario();
            }

            #endregion

            #region Consultas

            else if (lbl_Seccion.Text == "Consulta de Documentos-Sunat")
            {
                Consultas();
            }
            else if (lbl_Seccion.Text == "Consulta de Base de Datos")
            {
                ProcesaBD();
            }

            #endregion

            #region Configuracion

            else if (lbl_Seccion.Text == "Configuración BD")
            {
                GuardaConfigBD();
            }
            else if (lbl_Seccion.Text == "Configuración PSE")
            {
                GuardaConfigPSE();
            }

            #endregion

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                cmb_TipoEmision.Text = "PSE 2.1";
                CheckForIllegalCrossThreadCalls = false;
                checkBox8.Visible = false;
                AmbienteGlobal = LeerConfig();
                txtSetFecha.Text = ObtieneFechaHoy();
                lbl_Seccion.Text = "Emision PSE 2.1";
                //LeerConfig();
                //cmd_Procesar2.Enabled = false;
                lbl_Formato.Visible = false;
                rtb_daily.EnableAutoDragDrop = false;
                CargaParametros();
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox6.Checked = true;
                radioButton1.Checked = true;
                //radioButton3.Checked = true;
                cmb_combo.SelectedIndex = 1;
                comboBox1.SelectedIndex = 1;
                if (File.Exists(".\\CHANGELOG.txt"))
                {
                    rtb_changeLog.LoadFile(".\\CHANGELOG.txt", RichTextBoxStreamType.PlainText);
                }
                cargaCmbDoc();
            }catch(Exception d)
            {
                MessageBox.Show(d.Message);
            }          

        }

        private void Cmb_combo_TextChanged(object sender, EventArgs e)
        {
            if (cmb_combo.Text == "Desactivar")
            {
                //cmd_Procesar.Enabled = true;
                lbl_Formato.Visible = true;
                lbl_Formato.Text = "Formato: Tipo-documento|IssueDate (YYYY-MM-DD)";
                rtb_daily.EnableAutoDragDrop = true;
                //cmd_Procesar.Enabled = true;
            }
            else if (cmb_combo.Text == "BajasCancelado")
            {
                //cmd_Procesar.Enabled = true;
                lbl_Formato.Visible = true;
                lbl_Formato.Text = "Formato: Ruc|RA|Tipo-Serie-Correlativo";
                rtb_daily.EnableAutoDragDrop = true;
                //cmd_Procesar.Enabled = true;

            }
            else if (cmb_combo.Text == "EliminarPDF")
            {
                lbl_Formato.Visible = true;
                lbl_Formato.Text = "Formato: Tipo-documento|IssueDate (YYYY-MM-DD)";
                rtb_daily.EnableAutoDragDrop = true;
                //cmd_Procesar.Enabled = true;
            }
            else
            {
                lbl_Formato.Visible = true;
                lbl_Formato.Text = "Formato: SupplierRuc|TipoDocumento|Identificador";
                rtb_daily.EnableAutoDragDrop = true;
            }
        }

        private void TableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (DllG1.ValidaAcceso(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text))
            {
                Log("Credenciales Validas", true, LogFechaHora);
            }
            else
            {
                Log("Credenciales Incorrectas", false, LogFechaHora);
            }
        }

        private void chckEdicion_CheckedChanged(object sender, EventArgs e)
        {
            checkBox3.Checked = false;
            if (chckEdicion.Checked)
            {
                //tableLayoutPanel49.Enabled = true;
                //checkBox3.Enabled = false;

            }
            else
            {
                //tableLayoutPanel49.Enabled = false;
                //checkBox3.Enabled = true;

            }
            lblDocEdicion.Text = "-";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //token = source.Token;

            //if (button3.Text == "Descarga")
            //{
            //    FolderBrowserDialog dlCarpeta = new FolderBrowserDialog();
            //    dlCarpeta.RootFolder = System.Environment.SpecialFolder.Desktop;
            //    dlCarpeta.ShowNewFolderButton = false;
            //    dlCarpeta.Description = "Selecciona la carpeta";
            //    string rutaDestino = "";
            //    //(int Codigo, string Mensaje, string Documento) resp2;
            //    if (dlCarpeta.ShowDialog() == DialogResult.OK)
            //    {
            //        rutaDestino = dlCarpeta.SelectedPath;
            //    }
            //    Task t1 = Task.Run(() => method2(rutaDestino), token);
            //    //Task.Factory.StartNew(() => method2(rutaDestino),token);
            //    //button3.Text = "Detener";
            //}


            //(int Codigo, string Mensaje, string Docmumento) resp;

            //if (lblDocEdicion.Text != "-")
            //{
            //    resp = DllG1.EstatusDocumento(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, lblDocEdicion.Text);
            //    if(resp.Codigo == 0)
            //    {
            //        try
            //        {
            //            FolderBrowserDialog dlCarpeta = new FolderBrowserDialog();
            //            dlCarpeta.RootFolder = System.Environment.SpecialFolder.Desktop;
            //            dlCarpeta.ShowNewFolderButton = false;
            //            dlCarpeta.Description = "Selecciona la carpeta";
            //            string rutaDestino = "";
            //            //(int Codigo, string Mensaje, string Documento) resp2;
            //            if (dlCarpeta.ShowDialog() == DialogResult.OK)
            //            {
            //                rutaDestino = dlCarpeta.SelectedPath;
            //            }
            //            //DirectoryInfo di = new DirectoryInfo(lst_archivo.Items[i].ToString());
            //            string nombreXml = lblDocEdicion.Text;
            //            if (chckPDF.Checked)
            //            {
            //                string rutaPdf = rutaDestino + "\\" + nombreXml + ".pdf";
            //                var respPdf = DllG1.DescargaArchivos(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, lblDocEdicion.Text, "PDF");
            //                if (respPdf.ArhivoBase64 != null)
            //                {
            //                    byte[] data = System.Convert.FromBase64String(respPdf.ArhivoBase64);
            //                    File.WriteAllBytes(rutaPdf, data);
            //                    Log("Se descarga " + rutaPdf, true, LogFechaHora);
            //                }
            //                else
            //                {
            //                    Log("No se puede descargar PDF del doc " + nombreXml, false, LogFechaHora);
            //                }
            //            }

            //            if (chckXML.Checked)
            //            {
            //                string rutaPdf = rutaDestino + "\\" + nombreXml + ".xml";
            //                var respPdf = DllG1.DescargaArchivos(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, lblDocEdicion.Text, "XML");
            //                if (respPdf.ArhivoBase64 != null)
            //                {
            //                    byte[] data = System.Convert.FromBase64String(respPdf.ArhivoBase64);
            //                    File.WriteAllBytes(rutaPdf, data);
            //                    Log("Se descarga " + rutaPdf, true, LogFechaHora);
            //                }
            //                else
            //                {
            //                    Log("No se puede descargar XML del doc " + nombreXml, false, LogFechaHora);
            //                }
            //            }

            //            if (chckCDR.Checked)
            //            {
            //                string rutaPdf = rutaDestino + "\\" + nombreXml + ".zip";
            //                var respPdf = DllG1.DescargaArchivos(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, lblDocEdicion.Text, "CDR");
            //                if (respPdf.ArhivoBase64 != null)
            //                {
            //                    byte[] data = System.Convert.FromBase64String(respPdf.ArhivoBase64);
            //                    File.WriteAllBytes(rutaPdf, data);
            //                    Log("Se descarga " + rutaPdf, true, LogFechaHora);
            //                }
            //                else
            //                {
            //                    Log("No se puede descargar CDR del doc " + nombreXml, false, LogFechaHora);
            //                }
            //            }

            //            //string ruta = rutaDestino + "\\" + nombreXml + ".pdf";
            //            //var resp2 = ServicioPse.DescargaArchivo(txt_UsuarioEmision.Text, txt_ClaveEmision.Text, lblDocEdicion.Text, "PDF");
            //            ////MessageBox.Show(resp.errorMessage);
            //            ////string extension = "";
            //            ////if (comboBox1.Text == "CDR")
            //            ////{
            //            ////    extension = ".zip";
            //            ////}
            //            ////else
            //            ////{
            //            ////    extension = comboBox1.Text;
            //            ////}
            //            ////string ruta = rutaAsignada + recorrer[i] + "." + extension;
            //            //if (resp2.archivo != null)
            //            //{
            //            //    byte[] data = System.Convert.FromBase64String(resp2.archivo);
            //            //    File.WriteAllBytes(ruta, data);
            //            //    Log(resp2.mensaje + " " + " PDF " + " " + lblDocEdicion.Text, true, LogFechaHora);
            //            //}
            //            //else
            //            //{
            //            //    Log(resp2.mensaje + " " + lblDocEdicion.Text, false, LogFechaHora);
            //            //}
            //        }
            //        catch (Exception ew)
            //        {
            //            Log(ew.Message + " " + lblDocEdicion.Text, false, LogFechaHora);
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Espera unos minutos que el documento se acepte para intentarlo nuevamente");
            //    }

            //}
            //else
            //{
            //    MessageBox.Show("Para proceder con esta funcion, el documento debe estar acepatado por el servicio PSE");
            //}
        }

        private void btnConsultaSunatPSE_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT CONCAT(s.ruc, '|01|', s.serie, '|', s.correlativo, '|', s.adquirienteTipoDocumento, '|', s.adquirienteNumDocumento, '|', DATE_FORMAT(s.fechaHoraEmision, '%d/%m/%Y'), '|', st.importeTotalVenta)" + Environment.NewLine +
                "FROM peprodpse.invoices as s" + Environment.NewLine +
                "JOIN peprodpse.invoice_totals st ON s.id = st.invoiceId" + Environment.NewLine +
                "WHERE s.ruc = xxxxxxxxxx" + Environment.NewLine +
                "AND s.numeracion in ('F001-1234')" + Environment.NewLine +
                "AND s.activo = 1" + Environment.NewLine +
                "AND DATE_FORMAT(fechaHoraEmision, '%Y-%m') BETWEEN '2020-06' AND '2020-06'";
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

        private void btnConsultaSunatOSE_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = " -- Fact emitidas de manera individual" + Environment.NewLine +
            "select CONCAT(supplier_ruc, '|', '01', '|', serie, '|', correlative, '|', customer_type, '|', customer_ruc, '|', DATE_FORMAT(issue_date, '%d/%m/%Y'), '|', total)" + Environment.NewLine +
            " from peproduccionose.invoices i" + Environment.NewLine +
            " -- where id_summary_document in ('xxxx')" + Environment.NewLine +
            " where numeration in ('F001-1324')" + Environment.NewLine +
            " and supplier_ruc = xxxx" + Environment.NewLine +
            " and ruc = xxxx" + Environment.NewLine +
            " and status_sunat in(0)" + Environment.NewLine+ Environment.NewLine +

            " select CONCAT(supplier_ruc, '|', invoice_type, '|', serie, '|', correlative, '|', customer_docType, '|', customer_doc, '|', DATE_FORMAT(issue_date, '%d/%m/%Y'), '|', total_amount) " + Environment.NewLine +
            " from peproduccionose.summary_lines sl" + Environment.NewLine +
            " -- where summary_id in ('xxxx')" + Environment.NewLine +
            " where numeration in ('B001-1234')" + Environment.NewLine +
            " and supplier_ruc = xxxx" + Environment.NewLine +
            " and ruc = 'xxxx'";
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

        private void button12_Click_1(object sender, EventArgs e)
        {
            //var dos = dtgEjemplos.SelectedRows[dtgEjemplos.].Cells[1].Value;
            //MessageBox.Show(dos.ToString());
            //var uno = dtgEjemplos.Rows[e.RowIndex].Cells[0].Value;
                                       

            //Log("Documento F001-1234.text (Gravado 1 Item) Aceptado por servicio PSE, a la espera de aceptacion Sunat/OSE", true, false);
            //Log("...", true, false);
            //Log("...", true, false);
            //Log("...", true, false);
            //Log("Documento F001-1234.text (Gravado 1 Item) Aceptado por Sunat/OSE", true, false);

        }

        private void button13_Click(object sender, EventArgs e)
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

            if (chckPdfEjemplos.Checked)
            {
                string rutaPdf = rutaDestino + "\\" + nombreEjemplosGlobal + ".pdf";
                var respPdf = DllG1.DescargaArchivos(txt_RucConfig.Text, txt_UserConfig.Text, txt_ClaveConfig.Text, nombreRealEjemplosGlobal, "PDF");
                if (respPdf.ArhivoBase64 != null)
                {
                    byte[] data = System.Convert.FromBase64String(respPdf.ArhivoBase64);
                    File.WriteAllBytes(rutaPdf, data);
                    LogRespuesta("Se descarga " + rutaPdf, true, LogFechaHora);
                }
                else
                {
                    LogRespuesta("No se puede descargar PDF del doc " + nombreEjemplosGlobal, false, LogFechaHora);
                }
            }

            if (chckXmlEjemplos.Checked)
            {
                string rutaPdf = rutaDestino + "\\" + nombreEjemplosGlobal + ".xml";
                var respPdf = DllG1.DescargaArchivos(txt_RucConfig.Text, txt_UserConfig.Text, txt_ClaveConfig.Text, nombreRealEjemplosGlobal, "XML");
                if (respPdf.ArhivoBase64 != null)
                {
                    byte[] data = System.Convert.FromBase64String(respPdf.ArhivoBase64);
                    File.WriteAllBytes(rutaPdf, data);
                    LogRespuesta("Se descarga " + rutaPdf, true, LogFechaHora);
                }
                else
                {
                    LogRespuesta("No se puede descargar XML del doc " + nombreEjemplosGlobal, false, LogFechaHora);
                }
            }

            if (chckCdrEjemplos.Checked)
            {
                string rutaPdf = rutaDestino + "\\" + nombreEjemplosGlobal + ".zip";
                var respPdf = DllG1.DescargaArchivos(txt_RucConfig.Text, txt_UserConfig.Text, txt_ClaveConfig.Text, nombreRealEjemplosGlobal, "CDR");
                if (respPdf.ArhivoBase64 != null)
                {
                    byte[] data = System.Convert.FromBase64String(respPdf.ArhivoBase64);
                    File.WriteAllBytes(rutaPdf, data);
                    LogRespuesta("Se descarga " + rutaPdf, true, LogFechaHora);
                }
                else
                {
                    LogRespuesta("No se puede descargar CDR del doc " + nombreEjemplosGlobal, false, LogFechaHora);
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
                    string rutaOriginal = txtRutaProcesados.Text;
                    File.Copy(rutaOriginal + nombreEjemplosGlobal, rutaDestino + @"\" + nombreEjemplosGlobal);
                    LogRespuesta("Se descarga " + rutaDestino + @"\" + nombreEjemplosGlobal, true, LogFechaHora);
                }catch(Exception ff)
                {
                    LogRespuesta("No se puede descargar TXT del doc " + nombreEjemplosGlobal, false, LogFechaHora);
                }

                //string rutaPdf = Ruta + "\\" + nombreXml + ".zip";
                //var respPdf = DllG1.DescargaArchivos(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text, lblDocEdicion.Text, "CDR");
                //if (respPdf.ArhivoBase64 != null)
                //{
                //    byte[] data = System.Convert.FromBase64String(respPdf.ArhivoBase64);
                //    File.WriteAllBytes(rutaPdf, data);
                //    LogRespuesta("Se descarga " + rutaPdf, true, LogFechaHora);
                //}
                //else
                //{
                //    LogRespuesta("No se puede descargar CDR del doc " + nombreXml, false, LogFechaHora);
                //}
            }

            if (chckRequestEjemplos.Checked)
            {
                string rutaOriginal = txtRutaProcesados.Text + nombreEjemplosGlobal;
                request.GenerarRequest(txt_RucConfig.Text, txt_UserConfig.Text, txt_ClaveConfig.Text, rutaOriginal, txtRutaProcesados.Text + nombreEjemplosGlobal + "_request.xml");
                ObtenerRequest(txtRutaProcesados.Text + nombreEjemplosGlobal + "_request.xml", rutaDestino + "\\" + nombreEjemplosGlobal + ". Request.xml");       
                
            }

        }

        private void cmbTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaDtgUsuario();
            //string[] entries = Directory.GetFileSystemEntries(@"C:\Users\guevarae\Desktop\Ejemplos\" + cmbTipoDoc.Text + "\\", "*", SearchOption.TopDirectoryOnly);

            //foreach (var file in entries)
            //{
            //    string caracteristica
            //    //cmbTipoDoc.Items.Add(Path.GetFileName(file));
            //    //MessageBox.Show(Path.GetFileName(file));
            //}
        }

        private void cmd_Procesar2_Click_1(object sender, EventArgs e)
        {
            #region Emision

            Log(Environment.NewLine + Environment.NewLine + "-------------------------------------------------------------------------------", true, false);
            if(lbl_Seccion.Text == "Emision PSE 2.1" && lst_archivo.Items.Count > 0)
            {
                if (cmb_TipoEmision.Text == "PSE 2.1")
                {
                    if (AmbienteGlobal == "PRD" && txt_RucEmision.Text != "55555555555")
                    {
                        if (MessageBox.Show("Estas seguro de enviar un documento en Produccion para el ruc: " + txt_RucEmision.Text + "?", "Advertencia", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            Emision();
                        }
                    }
                    else
                    {
                        Emision();
                    }
                }
                else if (cmb_TipoEmision.Text == "G1")
                {
                    if (AmbienteGlobal == "PRD" && txt_RucEmision.Text != "55555555555")
                    {
                        if (MessageBox.Show("Estas seguro de enviar un documento en Produccion para el ruc: " + txt_RucEmision.Text + "?", "Advertencia", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            EmisionG1();
                        }
                    }
                    else
                    {
                        EmisionG1();

                    }
                }
                else if (cmb_TipoEmision.Text == "G2")
                {
                    if (AmbienteGlobal == "PRD" && txt_RucEmision.Text != "55555555555")
                    {
                        if (MessageBox.Show("Estas seguro de enviar un documento en Produccion para el ruc: " + txt_RucEmision.Text + "?", "Advertencia", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            EmisionG2();
                        }
                    }
                    else
                    {
                        EmisionG2();

                    }
                }
                else
                {
                    EnvioSunat();
                }
            }          


            #endregion

            #region Tool

            else if (lbl_Seccion.Text == "Daily Task")
            {
                if (cmb_combo.Text == "BajasCancelado")
                {
                    Bajas();
                }
                else if (cmb_combo.Text == "Desactivar")
                {
                    Desactivar();
                }
                else if (cmb_combo.Text == "EliminarPDF")
                {
                    EliminarPDF();
                }
                else
                {
                    DesactivarOSE();
                }

            }
            else if (lbl_Seccion.Text == "Descarga de Documentos PSE")
            {
                Descargas();
            }
            else if (lbl_Seccion.Text == "Set de Pruebas")
            {
                SetPruebas();
            }
            else if (lbl_Seccion.Text == "Otras utilidades")
            {
                Utilitario();
            }

            #endregion

            #region Consultas

            else if (lbl_Seccion.Text == "Consulta de Documentos-Sunat")
            {
                Consultas();
            }
            else if (lbl_Seccion.Text == "Consulta de Base de Datos")
            {
                ProcesaBD();
            }

            #endregion

            #region Configuracion           
            else if (lbl_Seccion.Text == "Configuración BD")
            {
                GuardaConfigBD();
            }
            else if (lbl_Seccion.Text == "Configuración PSE")
            {
                GuardaConfigPSE();
            }
            else if (lbl_Seccion.Text == "Configuración Otros")
            {
                GuardaConfigOtros();
            }

            #endregion

        }

        private void btnProbarCredenciales_Click(object sender, EventArgs e)
        {
            if (DllG1.ValidaAcceso(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text))
            {
                Log("Credenciales Validas", true, LogFechaHora);
            }
            else
            {
                Log("Credenciales Incorrectas", false, LogFechaHora);
            }
        }

        private void tableLayoutPanel9_Paint(object sender, PaintEventArgs e)
        {

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
                Task t1 = Task.Run(() => method2(rutaDestino), token);
                //Task.Factory.StartNew(() => method2(rutaDestino),token);
                //button3.Text = "Detener";
            }
        }

        private void btnProbarTodos_Click(object sender, EventArgs e)
        {
            btnProbarTodos.Enabled = false;
            Task t1 = Task.Run(() => EnvioPSE(), token);          
        }

        private void dtgEjemplos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string nombreArchivoTxt = dtgEjemplos.Rows[e.RowIndex].Cells[1].Value.ToString();
                Process.Start(txt_RutaEjemplos + nombreArchivoTxt);
            }
            catch(Exception ex)
            {

            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
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
                //nsManager.AddNamespace(prefix, uri);
                XmlNode nodo = xmlDoc.SelectSingleNode("Service", nsManager);
                if (nodo != null)
                {
                    XmlNode nodo2 = nodo.SelectSingleNode("Ambiente", nsManager);
                    if (nodo2 != null)
                    {
                        if (nodo2.Attributes[0].Value == "http://int.thefactoryhka.com.pe/Service.svc")
                        {
                            nodo2.Attributes[0].Value = "http://demoint.thefactoryhka.com.pe/Service.svc";
                        }
                        else
                        {
                            nodo2.Attributes[0].Value = "http://int.thefactoryhka.com.pe/Service.svc";
                        }
                        xmlDoc.Save(path);
                        AmbienteGlobal = LeerConfig();
                        CargaParametros();
                    }
                }
            }
            catch (Exception ex) { result = ex.ToString(); }


        }

        private void btnDescargaEjemplos_Click(object sender, EventArgs e)
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
                if (chckPdfEjemplos.Checked)
                {
                    string rutaPdf = rutaDestino + "\\" + nombreEjemplosGlobal + ".pdf";
                    var respPdf = DllG1.DescargaArchivos(txt_RucConfig.Text, txt_UserConfig.Text, txt_ClaveConfig.Text, nombreRealEjemplosGlobal, "PDF");
                    if (respPdf.ArhivoBase64 != null)
                    {
                        byte[] data = System.Convert.FromBase64String(respPdf.ArhivoBase64);
                        File.WriteAllBytes(rutaPdf, data);
                        LogRespuesta("Se descarga " + rutaPdf, true, LogFechaHora);
                    }
                    else
                    {
                        LogRespuesta("No se puede descargar PDF del doc " + nombreEjemplosGlobal, false, LogFechaHora);
                    }
                }

                if (chckXmlEjemplos.Checked)
                {
                    string rutaPdf = rutaDestino + "\\" + nombreEjemplosGlobal + ".xml";
                    var respPdf = DllG1.DescargaArchivos(txt_RucConfig.Text, txt_UserConfig.Text, txt_ClaveConfig.Text, nombreRealEjemplosGlobal, "XML");
                    if (respPdf.ArhivoBase64 != null)
                    {
                        byte[] data = System.Convert.FromBase64String(respPdf.ArhivoBase64);
                        File.WriteAllBytes(rutaPdf, data);
                        LogRespuesta("Se descarga " + rutaPdf, true, LogFechaHora);
                    }
                    else
                    {
                        LogRespuesta("No se puede descargar XML del doc " + nombreEjemplosGlobal, false, LogFechaHora);
                    }
                }

                if (chckCdrEjemplos.Checked)
                {
                    string rutaPdf = rutaDestino + "\\" + nombreEjemplosGlobal + ".zip";
                    var respPdf = DllG1.DescargaArchivos(txt_RucConfig.Text, txt_UserConfig.Text, txt_ClaveConfig.Text, nombreRealEjemplosGlobal, "CDR");
                    if (respPdf.ArhivoBase64 != null)
                    {
                        byte[] data = System.Convert.FromBase64String(respPdf.ArhivoBase64);
                        File.WriteAllBytes(rutaPdf, data);
                        LogRespuesta("Se descarga " + rutaPdf, true, LogFechaHora);
                    }
                    else
                    {
                        LogRespuesta("No se puede descargar CDR del doc " + nombreEjemplosGlobal, false, LogFechaHora);
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
                        string rutaOriginal = txtRutaProcesados.Text;
                        File.Copy(rutaOriginal + nombreEjemplosGlobal, rutaDestino + @"\" + nombreEjemplosGlobal);
                        LogRespuesta("Se descarga " + rutaDestino + @"\" + nombreEjemplosGlobal, true, LogFechaHora);
                    }
                    catch (Exception ff)
                    {
                        LogRespuesta("No se puede descargar TXT del doc " + nombreEjemplosGlobal, false, LogFechaHora);
                    }
                }

                if (chckRequestEjemplos.Checked)
                {

                    string rutaOriginal = txtRutaProcesados.Text + nombreEjemplosGlobal;
                    request.GenerarRequest(txt_RucConfig.Text, txt_UserConfig.Text, txt_ClaveConfig.Text, rutaOriginal, txtRutaProcesados.Text + nombreEjemplosGlobal + "_request.xml");
                    ObtenerRequest(txtRutaProcesados.Text + nombreEjemplosGlobal + "_request.xml", rutaDestino + "\\" + nombreEjemplosGlobal + ". Request.xml");

                }

                if (Directory.Exists(rutaDestino + "\\"))
                {
                    System.Diagnostics.Process.Start("explorer.exe", rutaDestino);
                }
            }     
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            btnProbarTodos.Enabled = false;
            Task t1 = Task.Run(() => EnvioPSE(), token);
        }

        private void txtBusquedaEjemplo_TextChanged(object sender, EventArgs e)
        {
            string filterField = "DETALLE";
            ((DataTable)dtgEjemplos.DataSource).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, txtBusquedaEjemplo.Text);
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

        private void rb_Firma_CheckedChanged(object sender, EventArgs e)
        {
            groupBox12.Enabled = true;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
        }

        private void btnBuscaXml_Click(object sender, EventArgs e)
        {
            OpenFileDialog fichero = new OpenFileDialog();
            fichero.Multiselect = false;
            //fichero.Filter = "Text (*.txt)|*.TXT|XML (*.xml)|*.XML|ZIP (*.zip)|*.ZIP";
            fichero.Filter = "XML (*.xml)|*.XML";
            //open.Filter = "ZIP files (*.zip)|*.zip";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                txtRutaXmlFirma.Text = fichero.FileName;               
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

        public void EnvioPSE()
        {
            Log("--------- Envio a PSE ---------", true, LogFechaHora);
            (string nombreTxt, string documentoInterno, string status) Doc;
            List<(string, string, string)> lstDocs = new List<(string, string, string)>();
            for (int i = 0; i < dtgEjemplos.RowCount-1; i++)
            {
                string rutaRaiz = txt_RutaEjemplos.Text + cmbTipoDoc.Text + @"\";
                string nombreArchivoOriginal = dtgEjemplos.Rows[i].Cells[1].Value.ToString();
                string rutaArchivoTxtNueva = txtRutaProcesados.Text;
                string rutaArchivoTxtVieja = rutaRaiz + nombreArchivoOriginal;
                string ArchivoAEnviar = CambiaContenidoTxt(nombreArchivoOriginal, rutaArchivoTxtVieja, AmbienteGlobal, rutaArchivoTxtNueva);
                string NombreArchivoaEnviar = Path.GetFileName(ArchivoAEnviar);
                (int Codigo, string Mensaje, string Documento) resp;
                if (ArchivoAEnviar.Split('-')[1] == "20" || ArchivoAEnviar.Split('-')[1] == "40")
                {
                    resp = DllG1.EnviarPercepcionRetencion(txt_RucConfig.Text, txt_UserConfig.Text, txt_ClaveConfig.Text, ArchivoAEnviar);
                }
                else
                {
                    resp = DllG1.Enviar(txt_RucConfig.Text, txt_UserConfig.Text, txt_ClaveConfig.Text, ArchivoAEnviar);
                }
                dtgEjemplos.Rows[i].Cells[2].Value = resp.Codigo + "|" + resp.Mensaje;
                bool msj = false;
                if(resp.Codigo == 0)
                {
                    msj = true;
                    Doc.documentoInterno = resp.Documento;
                    Doc.nombreTxt = nombreArchivoOriginal;
                    Doc.status = resp.Codigo.ToString();
                    lstDocs.Add(Doc);
                }               
                LogRespuesta("Archivo TXT: " + NombreArchivoaEnviar + " (" + resp.Documento+ "): " + resp.Codigo + "|" +resp.Mensaje, msj, LogFechaHora);
                         
            }
            Log("--------- Fin Envio a PSE ---------", true, LogFechaHora);
            Log("--------- Consulta estatus Sunat/Ose ---------", true, LogFechaHora);
            (string nombreTxt,string documentoInterno, string status)[] arrayDocs = lstDocs.ToArray();
            for (int i = 0; i < arrayDocs.Length; i++)
            {
                bool encendido = true;
                (int Codigo, string Mensaje, string Documento) resp2;
                resp2.Codigo = 911;
                resp2.Mensaje = "911";
                while (encendido)
                {
                    resp2 = DllG1.EstatusDocumento(txt_RucConfig.Text, txt_UserConfig.Text, txt_ClaveConfig.Text, arrayDocs[i].documentoInterno);
                    if(resp2.Codigo == 0)
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
                        Log("Se esperan 25 segundos para consultar el status de los documentos",true,LogFechaHora);
                        Thread.Sleep(25000);
                    }
                }
                bool msj = false;
                if(resp2.Codigo == 0)
                {
                    msj = true;
                }
                LogRespuesta("Status del doc " + arrayDocs[i].nombreTxt + " (" + arrayDocs[i].documentoInterno+ "): " + resp2.Codigo.ToString(), msj, LogFechaHora);
                //dtgEjemplos.Rows[i].Cells[2].Value = resp2.Codigo;
                dtgEjemplos.Rows[i].Cells[2].Value = resp2.Codigo + "|" + resp2.Mensaje;
                foreach (DataGridViewRow dgvr in dtgEjemplos.Rows) {
                    if(dgvr.Cells[2].Value != null)
                    {
                        if (dgvr.Cells[2].Value.ToString().Split('|')[0] != "0")
                        {
                            dgvr.DefaultCellStyle.ForeColor = Color.Red;
                        }
                        else
                        {
                            dgvr.DefaultCellStyle.ForeColor = Color.Blue;
                        }
                    }                 
                }

            }


            Log("--------- Fin Consulta estatus Sunat/Ose ---------", true, LogFechaHora);
            btnProbarTodos.Enabled = true;
        }

        public void CargaDtgUsuario()
        {
            if(cmbTipoDoc.Text != "desktop.ini")
            {
                dtgEjemplos.Columns.Clear();
                dt7 = new DataTable();
                dt7.Columns.Add("DETALLE");
                dt7.Columns.Add("NOMBRE");
                dt7.Columns.Add("ESTADO");

                string[] entries = Directory.GetFileSystemEntries(txt_RutaEjemplos.Text + cmbTipoDoc.Text + "\\", "*", SearchOption.TopDirectoryOnly);


                for (int i = 0; i < entries.Length; i++)
                {
                    if (entries[i].IndexOf('_') > 0)
                    {
                        DataRow row7 = dt7.NewRow();
                        row7["DETALLE"] = entries[i].Split('_')[1];
                        row7["NOMBRE"] = Path.GetFileName(entries[i]);
                        row7["ESTADO"] = "-";
                        dt7.Rows.Add(row7);
                        btnProbarTodos.Enabled = true;
                    }
                }
                dtgEjemplos.DataSource = dt7;
                dtgEjemplos.Columns[0].Width = 275;
                dtgEjemplos.Columns[1].Width = 50;
                dtgEjemplos.Columns[2].Width = 50;


                //dtgEjemplos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dtgEjemplos.ReadOnly = true;

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dtgEjemplos.Columns.Add(btn);
                btn.Text = "Probar";
                btn.Name = "ACCION";
                btn.Width = 60;
                btn.UseColumnTextForButtonValue = true;
            }          

        }

        private void dtgEjemplos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!pruebaDocEjemploActivo && e.RowIndex >= 0 && e.RowIndex + 1 < dtgEjemplos.RowCount)
                {
                    if (dtgEjemplos.Columns[e.ColumnIndex].Name == "ACCION") // Eliminar
                    {
                        btnProbarTodos.Enabled = false;
                        btnDescargaEjemplos.Enabled = false;
                        tlp_archivos.Enabled = false;
                        pruebaDocEjemploActivo = true;
                        nombreEjemplosGlobal = "";
                        nombreRealEjemplosGlobal = "";
                        List<string> strFiles = Directory.GetFiles(txtRutaProcesados.Text, "*", SearchOption.AllDirectories).ToList();
                        foreach (string fichero in strFiles)
                        {
                            File.Delete(fichero);
                        }
                        string nombreArchivoTxt = dtgEjemplos.Rows[e.RowIndex].Cells[1].Value.ToString();
                        string rutaArchivoTxt = txtRutaProcesados.Text;
                        string rutaRaiz = txt_RutaEjemplos.Text + cmbTipoDoc.Text + @"\" + nombreArchivoTxt;
                        string ArchivoAEnviar = CambiaContenidoTxt(nombreArchivoTxt, rutaRaiz, AmbienteGlobal, rutaArchivoTxt);
                        string NombreArchivo = Path.GetFileName(ArchivoAEnviar);
                        (int Codigo, string Mensaje, string Documento) resp;
                        resp.Codigo = 9;
                        resp.Mensaje = "";
                        resp.Documento = "";
                        string Iniciales = ArchivoAEnviar.Split('-')[1];
                        if (Iniciales != "RA" && Iniciales != "RC" && Iniciales != "09" && Iniciales != "31" && Iniciales != "20" && Iniciales != "40")
                        {
                            resp = DllG1.Enviar(txt_RucConfig.Text, txt_UserConfig.Text, txt_ClaveConfig.Text, ArchivoAEnviar);
                        }
                        else if (Iniciales == "20" || Iniciales == "40")
                        {
                            resp = DllG1.EnviarPercepcionRetencion(txt_RucConfig.Text, txt_UserConfig.Text, txt_ClaveConfig.Text, ArchivoAEnviar);
                        }
                        else if (Iniciales == "09" || Iniciales == "31")
                        {
                            resp = DllG1.EnviarGuiaRemision("20550728762", "20550728762_INT_3", "RtBjfl76yx", ArchivoAEnviar);
                        }

                        if (resp.Codigo == 0)
                        {
                            LogRespuesta(NombreArchivo + " --> " + resp.Mensaje + " --> Doc real (" + resp.Documento + ")", true, LogFechaHora);
                            aceptadoEdicionGlobal = true;
                            nombreEjemplosGlobal = NombreArchivo;
                            nombreRealEjemplosGlobal = resp.Documento;
                            Task t1 = Task.Run(() => ProcesaIndividual(resp.Documento.ToString(), e.RowIndex), token);
                        }
                        else
                        {
                            LogRespuesta(NombreArchivo + " --> " + resp.Mensaje + " --> Doc real (" + resp.Documento + ")", false, LogFechaHora);
                            dtgEjemplos.Rows[e.RowIndex].Cells[2].Value = resp.Codigo + "|" + resp.Mensaje;
                            dtgEjemplos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                            aceptadoEdicionGlobal = false;
                            pruebaDocEjemploActivo = false;
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Deseas abrir el TXT con el Editor de Texto predeterminado?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            string nombreArchivoTxt = dtgEjemplos.Rows[e.RowIndex].Cells[1].Value.ToString();
                            string ruta = txt_RutaEjemplos.Text + cmbTipoDoc.Text + "\\" + nombreArchivoTxt;
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
            catch(Exception ex)
            {
                pruebaDocEjemploActivo = false;
                MessageBox.Show(ex.Message);
            }          
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            chckEdicion.Checked = false;
            lblDocEdicion.Text = "-";
        }

        private void Lst_archivo_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string File in fileNames)
                    lst_archivo.Items.Add(File);
            }
        }

        private void txt_RucPse_KeyDown(object sender, KeyEventArgs e)
        {
            //bool paste = (Convert.ToInt32(e.KeyData) == (Convert.ToInt32(Keys.Control) | Convert.ToInt32(Keys.V)));
            //bool copy = (Convert.ToInt32(e.KeyData) == (Convert.ToInt32(Keys.Control) | Convert.ToInt32(Keys.C)));
            //if (paste || copy)
            //{
            //    MessageBox.Show("SI");            
            //}
            //else
            //{
            //    MessageBox.Show("NO");
            //}
        }

        private void Lst_archivo_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            //cmd_Procesar2.Enabled = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var ruta = AsignaRuta();
            System.IO.File.WriteAllText(ruta + "/Log.txt", rtb_Log.Text.Replace("\n", Environment.NewLine));
            MessageBox.Show("Exportacion Exitosa! revisa tu ruta: " + ruta + "/Log.txt");
        }

        private void Btn_BuscarEmision_Click(object sender, EventArgs e)
        {
            OpenFileDialog fichero = new OpenFileDialog();
            fichero.Multiselect = true;
            //fichero.Filter = "Text (*.txt)|*.TXT|XML (*.xml)|*.XML|ZIP (*.zip)|*.ZIP";
            fichero.Filter = "Text (*.txt)|*.TXT";

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

        private void Button4_Click(object sender, EventArgs e)
        {
            if (DllG1.ValidaAcceso(txt_RucEmision.Text, txt_UsuarioEmision.Text, txt_ClaveEmision.Text))
            {
                Log("Credenciales Validas", true, LogFechaHora);
            }
            else
            {
                Log("Credenciales Incorrectas", false, LogFechaHora);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog fichero = new OpenFileDialog();
            fichero.Multiselect = true;
            fichero.Filter = "Text (*.txt)|*.TXT";
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

        private void button6_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlCarpeta = new FolderBrowserDialog();
            dlCarpeta.RootFolder = System.Environment.SpecialFolder.Desktop;
            dlCarpeta.ShowNewFolderButton = false;
            dlCarpeta.Description = "Selecciona la carpeta";
            if (dlCarpeta.ShowDialog() == DialogResult.OK)
            {
                txt_rutaObtenerNombres.Text = dlCarpeta.SelectedPath;
                //cmd_Procesar2.Enabled = true;
            }
        }

        private void rb_ObtenerNombres_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            groupBox12.Enabled = false;

        }

        private void rb_Renombrar_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            groupBox1.Enabled = false;
            groupBox12.Enabled = false;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlCarpeta = new FolderBrowserDialog();
            dlCarpeta.RootFolder = System.Environment.SpecialFolder.Desktop;
            dlCarpeta.ShowNewFolderButton = false;
            dlCarpeta.Description = "Selecciona la carpeta";
            if (dlCarpeta.ShowDialog() == DialogResult.OK)
            {
                txt_Renombrar.Text = dlCarpeta.SelectedPath;
                //cmd_Procesar2.Enabled = true;
            }
        }

        private void cmd_BorrarLog_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    FirmaDigital firma = new FirmaDigital();
            //    string stringXML = "C:\\Users\\guevarae\\Desktop\\55555555555-01-F030-27060905.xml";
            //    XmlDocument xmlDocument_sinFirmar = new XmlDocument();
            //    xmlDocument_sinFirmar.Load(stringXML);
            //    firma.FirmarDocumentoXML(xmlDocument_sinFirmar, "C:\\Users\\guevarae\\Desktop\\20550728762.pfx", "13245678").Save("C:\\Users\\guevarae\\Desktop\\55555555555-01-F030-27060905_Firmado.xml");

            //}
            //catch (Exception ed)
            //{
            //    MessageBox.Show(ed.Message);
            //}

            rtb_Log.Clear();
            lst_archivo.Items.Clear();
            lst_archivo.Items.Clear();
            lst_archivo.Items.Clear();
            lblDocEdicion.Text = "-";
            gb_PostAceptacion.Enabled = false;
            btnProbarTodos.Enabled = false;
            btnDescargaEjemplos.Enabled = false;
            tlp_archivos.Enabled = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenFileDialog fichero = new OpenFileDialog();
            fichero.Multiselect = true;
            fichero.Filter = "Text (*.txt)|*.TXT";
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

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                tableLayoutPanel27.Enabled = true;
            }
            else
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                tableLayoutPanel27.Enabled = false;

            }
        }

        private void txt_RucPse_TextChanged(object sender, EventArgs e)
        {
            if (txt_RucPse.Text != "")
            {
                if (txt_RucPse.TextLength == 11)
                {
                    //cmd_Procesar2.Enabled = true;
                }
                else
                {
                    //cmd_Procesar2.Enabled = false;
                }
            }
            if (txt_RucPse.Text != "" && txt_RazonS.Text == "")
            {
                for (int i = 0; i < arrayOfEmpresas.Length; i++)
                {
                    if (txt_RucPse.Text == arrayOfEmpresas[i].Split('|')[0])
                    {
                        txt_RazonS.Text = arrayOfEmpresas[i].Split('|')[1];
                    }
                }
            }
        }

        private void txt_RucDaily_TextChanged(object sender, EventArgs e)
        {
            if (txt_Token.Text != "" && txt_Mantis.Text.Length == 5 && txt_RucDaily.Text.Length == 11)
            {
                //cmd_Procesar2.Enabled = true;
            }
            else
            {
                //cmd_Procesar2.Enabled = false;
            }
        }

        private void txt_Mantis_TextChanged(object sender, EventArgs e)
        {
            if (txt_Token.Text != "" && txt_Mantis.Text.Length == 5 && txt_RucDaily.Text.Length == 11)
            {
                //cmd_Procesar2.Enabled = true;
            }
            else
            {
                //cmd_Procesar2.Enabled = false;
            }
        }

        private void txt_Token_TextChanged(object sender, EventArgs e)
        {
            if (txt_Token.Text != "" && txt_Mantis.Text.Length == 5 && txt_RucDaily.Text.Length == 11)
            {
                //cmd_Procesar2.Enabled = true;
            }
            else
            {
                //cmd_Procesar2.Enabled = false;
            }
        }

        private void txt_UserDescarga_TextChanged(object sender, EventArgs e)
        {
            if(txt_UserDescarga.Text != "" && txt_ClaveDescarga.Text != "" &&
                txt_RucDescarga.Text.Length == 11 && rtb_descarga.Text != "")
            {
                //cmd_Procesar2.Enabled = true;
            }
            else
            {
                //cmd_Procesar2.Enabled = false;
            }
        }

        private void txt_ClaveDescarga_TextChanged(object sender, EventArgs e)
        {
            if (txt_UserDescarga.Text != "" && txt_ClaveDescarga.Text != "" &&
            txt_RucDescarga.Text.Length == 11 && rtb_descarga.Text != "")
            {
                //cmd_Procesar2.Enabled = true;
            }
            else
            {
                //cmd_Procesar2.Enabled = false;
            }
        }

        private void txt_RucDescarga_TextChanged(object sender, EventArgs e)
        {
            if (txt_UserDescarga.Text != "" && txt_ClaveDescarga.Text != "" &&
            txt_RucDescarga.Text.Length == 11 && rtb_descarga.Text != "")
            {
                //cmd_Procesar2.Enabled = true;
            }
            else
            {
                //cmd_Procesar2.Enabled = false;
            }
        }

        private void rtb_descarga_TextChanged(object sender, EventArgs e)
        {
            if (txt_UserDescarga.Text != "" && txt_ClaveDescarga.Text != "" &&
            txt_RucDescarga.Text.Length == 11 && rtb_descarga.Text != "")
            {
                //cmd_Procesar2.Enabled = true;
            }
            else
            {
                //cmd_Procesar2.Enabled = false;
            }
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog dlCarpeta = new FolderBrowserDialog();
            dlCarpeta.RootFolder = System.Environment.SpecialFolder.Desktop;
            dlCarpeta.ShowNewFolderButton = false;
            dlCarpeta.Description = "Selecciona la carpeta";
            if (dlCarpeta.ShowDialog() == DialogResult.OK)
            {
                txtSetRuta.Text = dlCarpeta.SelectedPath + @"\";
            }
        }

        private void txt_RucEmision_KeyPress(object sender, KeyPressEventArgs e)
        {
            //val.ValidaSoloNumero(e);
        }

        private void txt_RucEmision2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //val.ValidaSoloNumero(e);
        }

        private void txt_RucEmision3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //val.ValidaSoloNumero(e);
        }

        private void txt_RucDaily_KeyPress(object sender, KeyPressEventArgs e)
        {
            //val.ValidaSoloNumero(e);
        }

        private void txt_Mantis_KeyPress(object sender, KeyPressEventArgs e)
        {
            //val.ValidaSoloNumero(e);
        }

        private void txt_RucDescarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            //val.ValidaSoloNumero(e);
        }

        private void txtSetFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            //val.ValidaSoloTextoNumGuion(e);
        }

        private void txtSetSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            //val.ValidaSoloTexto(e);
        }

        private void txt_RucPse_KeyPress(object sender, KeyPressEventArgs e)
        {
            //val.ValidaSoloNumero(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //val.ValidaSoloTexto(e);
        }

        private void txt_RucConfig_KeyPress(object sender, KeyPressEventArgs e)
        {
            //val.ValidaSoloNumero(e);
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog dlCarpeta = new FolderBrowserDialog();
            dlCarpeta.RootFolder = System.Environment.SpecialFolder.Desktop;
            dlCarpeta.ShowNewFolderButton = false;
            dlCarpeta.Description = "Selecciona la carpeta";
            if (dlCarpeta.ShowDialog() == DialogResult.OK)
            {
                txtSetRutaSalida.Text = dlCarpeta.SelectedPath + @"\";
                //cmd_Procesar2.Enabled = true;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["Token"].Value = txt_TokenConfig.Text;
                //PSE DEMO
                config.AppSettings.Settings["Usuario"].Value = txt_UserConfig.Text;
                config.AppSettings.Settings["Ruc"].Value = txt_RucConfig.Text;
                config.AppSettings.Settings["Clave"].Value = txt_ClaveConfig.Text;
                //PSE DEMO
                //PSE PRD
                config.AppSettings.Settings["UsuarioPRD"].Value = txt_UserConfigPRD.Text;
                config.AppSettings.Settings["RucPRD"].Value = txt_RucConfigPRD.Text;
                config.AppSettings.Settings["ClavePRD"].Value = txt_ClaveConfigPRD.Text;
                //PSE PRD
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
                CargaParametros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.ToString());
            }
            CargaParametros();
        }


        private void btn_Cambio_Click(object sender, EventArgs e)
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
                //nsManager.AddNamespace(prefix, uri);
                XmlNode nodo = xmlDoc.SelectSingleNode("Service", nsManager);
                if (nodo != null)
                {
                    XmlNode nodo2 = nodo.SelectSingleNode("Ambiente", nsManager);
                    if (nodo2 != null)
                    {
                        if (nodo2.Attributes[0].Value == "http://int.thefactoryhka.com.pe/Service.svc")
                        {
                            nodo2.Attributes[0].Value = "http://demoint.thefactoryhka.com.pe/Service.svc";
                        }
                        else
                        {
                            nodo2.Attributes[0].Value = "http://int.thefactoryhka.com.pe/Service.svc";
                        }
                        xmlDoc.Save(path);
                        AmbienteGlobal = LeerConfig();
                        CargaParametros();
                    }
                }
            }
            catch (Exception ex) { result = ex.ToString(); }


        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            checkBox8.Visible = false;

            txt_RucPse.Text = "";
            txt_RazonS.Text = "";
            tableLayoutPanel28.Enabled = true;
            if (radioButton5.Checked)
            {
                try
                {
                    Conexion conex = new Conexion();
                    Log("Cargando empresas...", true, false);
                    tableLayoutPanel28.Enabled = false;
                    List<String> listClientes = conex.getClientes(txt_RucPse.Text, ObtieneAmbiente(), ObtieneCadenaConexion());
                    ts_ProgressBar1.Minimum = 1;
                    ts_ProgressBar1.Maximum = listClientes.Count;
                    ts_ProgressBar1.Value = 1;
                    ts_ProgressBar1.Step = 1;
                    arrayOfEmpresas = listClientes.ToArray();
                    for (int i = 0; i < arrayOfEmpresas.Length; i++)
                    {
                        txt_RazonS.AutoCompleteCustomSource.Add(arrayOfEmpresas[i].Split('|')[1]);
                        ts_ProgressBar1.PerformStep();
                    }
                    Log("Cargado con éxito!", true, false);
                    tableLayoutPanel28.Enabled = true;
                }
                catch (Exception ez)
                {
                    MessageBox.Show("Error en la carga de empresas PSE 21: " + ez.Message);
                }

            }
            else
            {
                txt_RazonS.AutoCompleteCustomSource.Clear();
                txt_RazonS.Text = "";
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            txt_RucPse.Text = "";
            txt_RazonS.Text = "";
            tableLayoutPanel28.Enabled = true;
            if (radioButton4.Checked)
            {
                try
                {
                    Conexion conex = new Conexion();
                    Log("Cargando empresas...", true, false);
                    tableLayoutPanel28.Enabled = false;
                    List<String> listClientes = conex.getClientes(txt_RucPse.Text, ObtieneAmbiente(), ObtieneCadenaConexion());
                    ts_ProgressBar1.Minimum = 1;
                    ts_ProgressBar1.Maximum = listClientes.Count;
                    ts_ProgressBar1.Value = 1;
                    ts_ProgressBar1.Step = 1;
                    arrayOfEmpresas = listClientes.ToArray();
                    //txt_RazonS.AutoCompleteCustomSource.AddRange(arrayOfEmpresas);
                    for (int i = 0; i < arrayOfEmpresas.Length; i++)
                    {
                        txt_RazonS.AutoCompleteCustomSource.Add(arrayOfEmpresas[i].Split('|')[1]);
                        ts_ProgressBar1.PerformStep();
                    }
                    Log("Cargado con éxito!", true, false);
                    tableLayoutPanel28.Enabled = true;
                    checkBox8.Visible = true;
                }
                catch (Exception ez)
                {
                    MessageBox.Show("Error en la carga de empresas OSE: " + ez.Message);
                }
              
            }
            else
            {
                txt_RazonS.AutoCompleteCustomSource.Clear();
                txt_RazonS.Text = "";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox8.Visible = false;

            txt_RucPse.Text = "";
            txt_RazonS.Text = "";
            tableLayoutPanel28.Enabled = true;
            if (radioButton3.Checked)
            {
                try
                {
                    Conexion conex = new Conexion();
                    Log("Cargando empresas...", true, false);
                    tableLayoutPanel28.Enabled = false;
                    List<String> listClientes = conex.getClientes(txt_RucPse.Text, ObtieneAmbiente(), ObtieneCadenaConexion());
                    ts_ProgressBar1.Minimum = 1;
                    ts_ProgressBar1.Maximum = listClientes.Count;
                    ts_ProgressBar1.Value = 1;
                    ts_ProgressBar1.Step = 1;
                    arrayOfEmpresas = listClientes.ToArray();
                    for (int i = 0; i < arrayOfEmpresas.Length; i++)
                    {
                        txt_RazonS.AutoCompleteCustomSource.Add(arrayOfEmpresas[i].Split('|')[1]);
                        ts_ProgressBar1.PerformStep();
                    }
                    Log("Cargado con éxito!", true, false);
                    tableLayoutPanel28.Enabled = true;
                }catch(Exception ez)
                {
                    MessageBox.Show("Error en la carga de empresas PSE 20: " + ez.Message);
                }
               
            }
            else
            {
                txt_RazonS.AutoCompleteCustomSource.Clear();
                txt_RazonS.Text = "";
            }
        }

        private void txt_RazonS_TextChanged(object sender, EventArgs e)
        {
            if(txt_RazonS.Text != "" && txt_RucPse.Text == "")
            {
                for (int i = 0; i < arrayOfEmpresas.Length; i++)
                {
                    if (txt_RazonS.Text == arrayOfEmpresas[i].Split('|')[1])
                    {
                        txt_RucPse.Text = arrayOfEmpresas[i].Split('|')[0];
                    }
                }                
            }
        }

        private void txt_RucPse_Click(object sender, EventArgs e)
        {
            txt_RazonS.Text = "";
        }

        private void txt_RazonS_Click(object sender, EventArgs e)
        {
            txt_RucPse.Text = "";
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string File in fileNames)
                    lst_archivo.Items.Add(File);
            }
        }

        private void listBox2_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string File in fileNames)
                    lst_archivo.Items.Add(File);
            }
        }

        private void listBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            //cmd_Procesar2.Enabled = true;
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            //cmd_Procesar2.Enabled = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string connectionString = "datasource=172.16.40.7;port=3306;username=eguevara;password=G00gle123..";
            string query = "SELECT * FROM pedemopse.salebills where ruc =('20202540334') and numeracion in ('B011-00018899')";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                // Abre la base de datos
                databaseConnection.Open();
                // Ejecuta la consultas
                reader = commandDatabase.ExecuteReader();
                // Hasta el momento todo bien, es decir datos obtenidos
                // IMPORTANTE :#
                // Si tu consulta retorna un resultado, usa el siguiente proceso para obtener datos

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // En nuestra base de datos, el array contiene:  ID 0, FIRST_NAME 1,LAST_NAME 2, ADDRESS 3
                        // Hacer algo con cada fila obtenida
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                    }
                }
                else
                {
                    Console.WriteLine("No se encontraron datos.");
                }

                // Cerrar la conexión
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Mostrar cualquier excepción
                MessageBox.Show(ex.Message);
            }

        }

        #endregion

    }
}
