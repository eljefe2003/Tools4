using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        string[] arrayOfEmpresas, arrayOfEmpresas2;
        DataTable dtCarga;

        public FrmEmpresas(Color color1, Color color2, Color color3, Color color4)
        {
            InitializeComponent();

            tlpForm.BackColor = Color.White;
            btnProcesar.BackColor = color1;
            tlpLog.BackColor = color1;
            rtb_Log.BackColor = color1;
            gbFiltros.ForeColor = color1;
            rtb_Log.ForeColor = color2;
            lbl_Log.ForeColor = color2;

        }

        private void FrmEmpresas_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
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
            string Ambiente = dtgEmpresas.CurrentRow.Cells[2].Value.ToString();
            if(Ambiente == "PSE")
                Task.Factory.StartNew(() => method1());
            else
                Task.Factory.StartNew(() => method2());


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
            string Ruc = dtgEmpresas.CurrentRow.Cells[0].Value.ToString();
            string usuario = conex.getEmpresaUserPortal(Ruc, ObtieneCadenaConexion());
            ProgressBar.PerformStep();
            string firmado = conex.getEmpresaFirmado(Ruc, ObtieneCadenaConexion());
            ProgressBar.PerformStep();
            string Envio = conex.getEmpresaEnvia(Ruc, ObtieneCadenaConexion());
            ProgressBar.PerformStep();
            string folios = conex.getEmpresaFolios(Ruc, ObtieneCadenaConexion2());
            ProgressBar.PerformStep();
            string VigenciaFolios = conex.getEmpresaFoliosVigencia(Ruc, ObtieneCadenaConexion2());
            ProgressBar.PerformStep();
            string Emitio2Meses = conex.getEmpresaEmitio2Meses(Ruc, ObtieneCadenaConexion2());
            ProgressBar.PerformStep();
            Log("---------- PSE -----------", true, false);
            Log("Ruc: " + Ruc, true, false);
            Log("Razon S.: " + dtgEmpresas.CurrentRow.Cells[1].Value.ToString(), true, false);
            Log("Usuario Portal: " + usuario, true, false);
            Log("Firmado XML: " + firmado, true, false);
            Log("Envia a: " + Envio, true, false);
            Log("Folios disponibles: " + folios, true, false);
            Log("Vigencia fin de folios (dd/MM/aaaa): " + VigenciaFolios.Split(' ')[0], true, false);
            Log("---------- PSE -----------", true, false);
            ProgressBar.PerformStep();
        }

        private void method2()
        {
            Conexion conex = new Conexion();
            string Ruc = dtgEmpresas.CurrentRow.Cells[0].Value.ToString();
            ProgressBar.PerformStep();
            string TipoPlan = conex.getEmpresaOSETipoPlan(Ruc, ObtieneCadenaConexion3());
            ProgressBar.PerformStep();
            string Pse = conex.getEmpresaOSEPSE(Ruc,ObtieneCadenaConexion3());
            ProgressBar.PerformStep();
            string folios = conex.getEmpresaFoliosOSE(Ruc, ObtieneCadenaConexion3());
            ProgressBar.PerformStep();
            string VigenciaFolios = conex.getEmpresaOSEFoliosVigencia(Ruc, ObtieneCadenaConexion3());
            ProgressBar.PerformStep();

            Log("---------- OSE -----------", true, false);
            Log("Ruc: " + Ruc, true, false);
            Log("Razon S.: " + dtgEmpresas.CurrentRow.Cells[1].Value.ToString(), true, false);
            Log("Usuario Portal: " + Ruc, true, false);
            Log("Cliente tiene asociado otros Rucs (PSE): " + Pse, true, false);
            Log("Folios disponibles: " + folios, true, false);
            Log("Vigencia fin de folios (dd/MM/aaaa): " + VigenciaFolios.Split(' ')[0], true, false);
            Log("Tipo de Asignación de Folios: " + TipoPlan, true, false);

            Log("---------- OSE -----------", true, false);
            ProgressBar.PerformStep();

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

        private string ObtieneCadenaConexion3()
        {
            LeerConfigPersonal config = new LeerConfigPersonal();
            string connectionString = "";
            connectionString =
             "datasource=" + config.HostOSE +
             ";port=" + config.PortOSE +
             ";username=" + config.UserOSE +
             ";password=" + config.ClaveOSE;
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
            txt_RazonS.Text = "";
            if (txt_RucPse.Text != "")
            {
                dtCarga.DefaultView.RowFilter = $"RUC LIKE '%{txt_RucPse.Text}%'";
            }
        }

        private void txt_RazonS_TextChanged(object sender, EventArgs e)
        {
            txt_RucPse.Text = "";
            if (txt_RazonS.Text != "")
            {
                dtCarga.DefaultView.RowFilter = $"NOMBRE LIKE '%{txt_RazonS.Text}%'";
            }
        }

        private void cargaEmpresasPSE21()
        {
            try
            {
                Conexion conex = new Conexion();
                gbFiltros.Enabled = false;
                //btnProcesar.Enabled = false;
                Log("Cargando empresas PSE... Espera unos segundos por favor", true, false);
                List<String> listClientes = conex.getClientesAdmin("PSE", ObtieneCadenaConexion());
                Log("Cargando empresas OSE... Espera unos segundos por favor", true, false);
                List<String> listClientes2 = conex.getClientesAdmin("OSE", ObtieneCadenaConexion3());

                ProgressBar.Minimum = 0;
                ProgressBar.Maximum = listClientes.Count + listClientes2.Count;
                ProgressBar.Value = 1;
                ProgressBar.Step = 1;
                arrayOfEmpresas = listClientes.ToArray();
                arrayOfEmpresas2 = listClientes2.ToArray();

                dtCarga = new DataTable();
                dtCarga.Columns.Add("RUC");
                dtCarga.Columns.Add("NOMBRE");
                dtCarga.Columns.Add("SERV.");
                ProgressBar.PerformStep();

                for (int i = 0; i < arrayOfEmpresas.Length; i++)
                {
                    DataRow row7 = dtCarga.NewRow();
                    row7["RUC"] = arrayOfEmpresas[i].Split('|')[0];
                    row7["NOMBRE"] = arrayOfEmpresas[i].Split('|')[1];
                    row7["SERV."] = "PSE";
                    dtCarga.Rows.Add(row7);
                    ProgressBar.PerformStep();
                }

                for (int i = 0; i < arrayOfEmpresas2.Length; i++)
                {
                    DataRow row7 = dtCarga.NewRow();
                    row7["RUC"] = arrayOfEmpresas2[i].Split('|')[0];
                    row7["NOMBRE"] = arrayOfEmpresas2[i].Split('|')[1];
                    row7["SERV."] = "OSE";
                    dtCarga.Rows.Add(row7);
                    ProgressBar.PerformStep();
                }
                dtgEmpresas.DataSource = dtCarga;
                var num = dtgEmpresas.Size.Width / 20;
                dtgEmpresas.Columns["RUC"].Width = num * 4;
                dtgEmpresas.Columns["NOMBRE"].Width = num * 12;
                //dtgDocumento.Columns["FECHA"].Width = num;
                dtgEmpresas.Columns["SERV."].Width = num *3;

                //for (int i = 0; i < arrayOfEmpresas.Length; i++)
                //{
                //    string uno = arrayOfEmpresas[i].Split('|')[1];
                //    //MessageBox.Show(uno);
                //    txt_RazonS.AutoCompleteCustomSource.Add(uno);
                //}
                //txt_RazonS.AutoCompleteCustomSource.Add("UNO");
                //txt_RazonS.AutoCompleteCustomSource.Add("DOS");
                //txt_RazonS.AutoCompleteCustomSource.Add("TRES");

                Log("Cargado con éxito!", true, false);
                gbFiltros.Enabled = true;
                //cargaEmpresasOSE();
                //btnProcesar.Enabled = true;
            }
            catch (Exception ez)
            {
                MessageBox.Show("Error en la carga de empresas PSE 21: " + ez.Message);
            }
        }

        private void cargaEmpresasOSE()
        {
            try
            {
                Conexion conex = new Conexion();
                Log("Cargando empresas OSE... Espera unos segundos por favor", true, false);
                gbFiltros.Enabled = false;
                //btnProcesar.Enabled = false;
                List<String> listClientes = conex.getClientesAdmin("OSE", ObtieneCadenaConexion3());
                ProgressBar.Minimum = 0;
                ProgressBar.Maximum = listClientes.Count;
                ProgressBar.Value = 1;
                ProgressBar.Step = 1;
                arrayOfEmpresas = listClientes.ToArray();
                dtCarga = new DataTable();
                dtCarga.Columns.Add("RUC");
                dtCarga.Columns.Add("NOMBRE");
                dtCarga.Columns.Add("SERV.");
                ProgressBar.PerformStep();

                for (int i = 0; i < arrayOfEmpresas.Length; i++)
                {
                    DataRow row7 = dtCarga.NewRow();
                    row7["RUC"] = arrayOfEmpresas[i].Split('|')[0];
                    row7["NOMBRE"] = arrayOfEmpresas[i].Split('|')[1];
                    row7["SERV."] = "OSE";
                    dtCarga.Rows.Add(row7);
                    ProgressBar.PerformStep();
                }
                dtgEmpresas.DataSource = dtCarga;
                var num = dtgEmpresas.Size.Width / 20;
                dtgEmpresas.Columns["RUC"].Width = num * 4;
                dtgEmpresas.Columns["NOMBRE"].Width = num * 12;
                //dtgDocumento.Columns["FECHA"].Width = num;
                dtgEmpresas.Columns["SERV."].Width = num * 3;

                //for (int i = 0; i < arrayOfEmpresas.Length; i++)
                //{
                //    string uno = arrayOfEmpresas[i].Split('|')[1];
                //    //MessageBox.Show(uno);
                //    txt_RazonS.AutoCompleteCustomSource.Add(uno);
                //}
                //txt_RazonS.AutoCompleteCustomSource.Add("UNO");
                //txt_RazonS.AutoCompleteCustomSource.Add("DOS");
                //txt_RazonS.AutoCompleteCustomSource.Add("TRES");

                Log("Cargado OSE con éxito!", true, false);
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
