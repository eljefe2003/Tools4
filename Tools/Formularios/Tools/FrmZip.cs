using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools
{
    public partial class FrmZip : Form
    {
        LeerConfigPersonal configPerso = new LeerConfigPersonal();
        public FrmZip()
        {
            InitializeComponent();
        }
        public FrmZip(Color color1, Color color2, Color color3, Color color4)
        {
            InitializeComponent();

            tlpLog.BackColor = color1;
            rtb_Log.BackColor = color1;
            rtb_Log.ForeColor = color2;
            lbl_Log.ForeColor = color2;
            btnProcesar.BackColor = color1;
            btnBuscar.BackColor = color1;
            //colorAceptados = color1;

            //tlpForm.BackColor = Color.White;

            //rtbDaily.BackColor = color2;
            //gbFiltros.ForeColor = color1;
            //lblFormato.ForeColor = color1;


            //rtb_Log.ForeColor = color2;
            //lbl_Log.ForeColor = color2;
            //tlpLog.BackColor = color1;
            //rtb_Log.BackColor = color1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog fichero = new OpenFileDialog();
            fichero.Multiselect = true;
            //fichero.Filter = "Text (*.txt)|*.TXT|XML (*.xml)|*.XML|ZIP (*.zip)|*.ZIP";
            fichero.Filter = "XML (*.xml)|*.XML|ZIP (*.zip)|*.ZIP";

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

        public string ComprimirArchivo(string rutaCarpeta, string nombreArchivo, string rutaZipFinal)
        {
            if (Directory.Exists(".\\Procesados\\toZip\\"))
            {
                Directory.Delete(".\\Procesados\\toZip\\", true);
            }
            Directory.CreateDirectory(".\\Procesados\\toZip\\");
            Directory.Move(rutaCarpeta, ".\\Procesados\\toZip\\" + nombreArchivo);

            ////string directotorioDestino = ".\\" + nombreArchivo.Split('.')[0] + ".zip";
            //// verificar si existe el archivo y borrarlo para sobre escribirlo
            //if (File.Exists(rutaZIP))
            //{
            //    File.Delete(rutaZIP);
            //}
            //Comprimir
            ZipFile.CreateFromDirectory(Path.GetDirectoryName(".\\Procesados\\toZip\\" + nombreArchivo), rutaZipFinal + nombreArchivo + ".zip");
            //File.Move(directotorioDestino, rutaComprimir + Path.GetFileNameWithoutExtension(nombreArchivo) + ".zip");            
            //Log("Ruta ZIP Firmado: " + rutaZIP, true, false);
            return rutaZipFinal;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if(lst_archivo.Items.Count > 0)
            {
                Log("Inicia el proceso de creado de Zip's...", true, false);

                var rutaZip = configPerso.RutaZip;
                if (Directory.Exists(rutaZip))
                {
                    Directory.Delete(rutaZip, true);
                    //Log("Se elimina ruta: " + rutaZip, true, false);
                }
                Directory.CreateDirectory(rutaZip);
                //Log("Se crea ruta: " + rutaZip + Environment.NewLine, true, false);

                List<string> listaNombres = new List<string>();
                //Log("1ra ruta destino: " + rutaZip, true, false);

                for (int i = 0; i < lst_archivo.Items.Count; i++)
                {
                    string nombre = Path.GetFileNameWithoutExtension(lst_archivo.Items[i].ToString());
                    listaNombres.Add(RevisaNombre(nombre));
                    Directory.CreateDirectory(rutaZip + RevisaNombre(nombre));
                    try
                    {
                        File.Copy(lst_archivo.Items[i].ToString(), rutaZip + RevisaNombre(nombre) + "\\" + RevisaNombreCopiar(Path.GetFileName(lst_archivo.Items[i].ToString())));
                        //Log("Archivo copiado: " + lst_archivo.Items[i].ToString(), true, false);
                    }
                    catch (Exception ew)
                    {

                    }
                }
                var nombres = Directory.GetDirectories(rutaZip);
                Log("Creado " + nombres.Length + " archivos zipeados como contenido." + rutaZip, true, false);

                for (int i = 0; i < nombres.Length; i++)
                {
                    string nombre = Path.GetFileNameWithoutExtension(nombres[i]);
                    //Directory.CreateDirectory(rutaZip + RevisaNombre(nombre));
                    try
                    {
                        ComprimirArchivo(rutaZip + RevisaNombre(nombre), RevisaNombre(nombre), rutaZip);
                    }
                    catch (Exception ew)
                    {

                    }
                }
                if (File.Exists(".\\" + Path.GetDirectoryName(rutaZip) + ".zip"))
                {
                    File.Delete(".\\" + Path.GetDirectoryName(rutaZip) + ".zip");
                    //Log("Se elimina ruta: " + rutaZip, true, false);
                }
                ZipFile.CreateFromDirectory(rutaZip, ".\\" + Path.GetDirectoryName(rutaZip) + ".zip");
                Log("Proceso culminado, creado el Zip a enviar a Sunat en ruta " + rutaZip + Environment.NewLine, true, false);
                System.Diagnostics.Process.Start(".\\");
            }         

        }

        private string RevisaNombre(string nombre)
        {
            string corregido = nombre;
            if (nombre.StartsWith("R-"))
            {
                corregido = nombre.Replace("RR-", "RR#");
                corregido = corregido.Replace("R-", "");
                corregido = corregido.Replace("RR#", "RR-");
                nombre = corregido;
            }
            if (nombre.IndexOf("_cdr") > 0)
            {
                corregido = nombre.Replace("_cdr", "");
                nombre = corregido;
            }
            if (nombre.IndexOf("(1)") > 0)
            {
                corregido = nombre.Replace(" (1)", "");
                nombre = corregido;
            }
            if (nombre.IndexOf("(2)") > 0)
            {
                corregido = nombre.Replace(" (2)", "");
                nombre = corregido;
            }
            if (nombre.IndexOf("(3)") > 0)
            {
                corregido = nombre.Replace(" (3)", "");
                nombre = corregido;
            }
            return corregido;
        }

        private string RevisaNombreCopiar(string nombre)
        {
            string corregido = nombre;          
            if (nombre.IndexOf("(1)") > 0)
            {
                corregido = nombre.Replace(" (1)", "");
                nombre = corregido;
            }
            if (nombre.IndexOf("(2)") > 0)
            {
                corregido = nombre.Replace(" (2)", "");
                nombre = corregido;
            }
            if (nombre.IndexOf("(3)") > 0)
            {
                corregido = nombre.Replace(" (3)", "");
                nombre = corregido;
            }
            return corregido;
        }

        private void btnBorrarLog_Click(object sender, EventArgs e)
        {
            rtb_Log.Clear();
        }
    }
}
