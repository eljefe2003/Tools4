using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools
{
    public partial class FrmEmpresas : Form
    {
        public FrmEmpresas()
        {
            InitializeComponent();
        }

        Thread hiloPrimario, hiloSecundario;
        ThreadStart threadPrimario, threadSecundario;
        string[] arrayOfEmpresas;
        public FrmEmpresas(Color color1, Color color2, Color color3, Color color4)
        {
            InitializeComponent();

            tlpForm.BackColor = Color.White;
            btnProcesar.BackColor = color1;
            tlpLog.BackColor = color1;
            rtb_Log.BackColor = color1;
            gbAmbiente.ForeColor = color1;
            gbFiltros.ForeColor = color1;
            rtb_Log.ForeColor = color2;
            lbl_Log.ForeColor = color2;

        }

        private void FrmEmpresas_Load(object sender, EventArgs e)
        {
            HiloSecundario();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            int recorrer = 6;
            ProgressBar.Maximum = recorrer;
            ProgressBar.Step = 1;
            ProgressBar.Value = 0;
            ProgressBar.PerformStep();
            Task.Factory.StartNew(() => method1());

            //var arraytotal = Calculo(recorrer);
            //for (int i = 0; i < arraytotal.Length; i++)
            //{
            //    int temp = i;
            //    Task.Factory.StartNew(() => method1(arraytotal[temp]));
            //}         
  

        }

        private void method1()
        {
            Conexion conex = new Conexion();
            string usuario = conex.getEmpresaUserPortal(txt_RucPse.Text, ObtieneCadenaConexion());
            ProgressBar.PerformStep();
            string firmado = conex.getEmpresaFirmado(txt_RucPse.Text, ObtieneCadenaConexion());
            ProgressBar.PerformStep();
            string Envio = conex.getEmpresaEnvia(txt_RucPse.Text, ObtieneCadenaConexion());
            ProgressBar.PerformStep();
            string folios = conex.getEmpresaFolios(txt_RucPse.Text, ObtieneCadenaConexion2());
            ProgressBar.PerformStep();
            Log("---------------------------", true, false);
            Log("Ruc: " + txt_RucPse.Text, true, false);
            Log("Razon S.: " + txt_RazonS.Text, true, false);
            Log("Usuario Portal Administrador: " + usuario, true, false);
            Log("Firmado XML: " + firmado, true, false);
            Log("Envia a: " + Envio, true, false);
            Log("Folios disponibles: " + folios, true, false);
            //Log("¡Se ha copiado el usuario secundario en el portapapeles!", true, false);
            Log("---------------------------", true, false);
            ProgressBar.PerformStep();
            //Clipboard.SetDataObject(usuario, true);

        }

        private string ObtieneCadenaConexion()
        {
            LeerConfigPersonal config = new LeerConfigPersonal();
            string connectionString = "";
            connectionString =
             "datasource=" + config.HostAdmin +
             ";port=" + config.PortAdmin +
             ";username=" + config.UserAdmin +
             ";password=" + config.ClaveAdmin;           
            return connectionString;
        }

        private string ObtieneCadenaConexion2()
        {
            LeerConfigPersonal config = new LeerConfigPersonal();
            string connectionString = "";
            connectionString =
             "datasource=" + config.HostPSE21 +
             ";port=" + config.PortPSE21 +
             ";username=" + config.UserPSE21 +
             ";password=" + config.ClavePSE21;
            return connectionString;
        }

        public void HiloSecundario()
        {
            if (hiloSecundario != null)
            {
                hiloSecundario.Abort();
            }
            CheckForIllegalCrossThreadCalls = false;
            threadSecundario = new ThreadStart(cargaEmpresasPSE21);
            hiloSecundario = new Thread(threadSecundario);
            hiloSecundario.Start();
        }

        private void txt_RucPse_TextChanged(object sender, EventArgs e)
        {
            if (txt_RucPse.Text != "")
            {
                for (int i = 0; i < arrayOfEmpresas.Length; i++)
                {
                    if (txt_RucPse.Text == arrayOfEmpresas[i].Split('|')[0])
                    {
                        txt_RazonS.Text = arrayOfEmpresas[i].Split('|')[1];
                        btnProcesar.Enabled = true;
                        return;
                    }
                    else
                    {
                        txt_RazonS.Text = "";
                        btnProcesar.Enabled = false;
                    }
                }
            }
        }

        private void cargaEmpresasPSE21()
        {
            try
            {
                Conexion conex = new Conexion();
                Log("Cargando empresas... Espera unos segundos por favor", true, false);
                gbFiltros.Enabled = false;
                btnProcesar.Enabled = false;
                List<String> listClientes = conex.getClientesAdmin("PSE", ObtieneCadenaConexion());
                //ts_ProgressBar1.Minimum = 1;
                //ts_ProgressBar1.Maximum = listClientes.Count;
                //ts_ProgressBar1.Value = 1;
                //ts_ProgressBar1.Step = 1;
                arrayOfEmpresas = listClientes.ToArray();
                for (int i = 0; i < arrayOfEmpresas.Length; i++)
                {
                    //string uno = arrayOfEmpresas[i].Split('|')[1];
                    //MessageBox.Show(uno);
                    //txt_RazonS.AutoCompleteCustomSource.Add(uno);
                }
                Log("Cargado con éxito!", true, false);
                gbFiltros.Enabled = true;
                //btnProcesar.Enabled = true;
            }
            catch (Exception ez)
            {
                MessageBox.Show("Error en la carga de empresas PSE 21: " + ez.Message);
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

    }
}
