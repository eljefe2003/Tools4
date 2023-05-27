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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

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
        List<String> listClientes = null;
        //Log("Cargando empresas OSE... Espera unos segundos por favor", true, false);
        List<String> listClientes2 = null;

        public FrmEmpresas(Color color1, Color color2, Color color3, Color color4, List<String> lisCli1, List<String> listCli2)
        {
            InitializeComponent();
            tlpForm.BackColor = Color.White;
            btnProcesar.BackColor = color1;
            btnConsumoFolios.BackColor = color1;
            tlpLog.BackColor = color1;
            rtb_Log.BackColor = color1;
            gbFiltros.ForeColor = color1;
            gbFiltroConsumo.ForeColor = color1;
            rtb_Log.ForeColor = color2;
            lbl_Log.ForeColor = color2;
            listClientes = lisCli1;
            listClientes2 = listCli2;
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
            string usuario = conex.getEmpresaUserPortal(Ruc, ObtieneCadenaConexionAdmin());
            ProgressBar.PerformStep();
            string firmado = conex.getEmpresaFirmado(Ruc, ObtieneCadenaConexionAdmin());
            ProgressBar.PerformStep();
            string Envio = conex.getEmpresaEnvia(Ruc, ObtieneCadenaConexionAdmin());
            ProgressBar.PerformStep();
            string folios = conex.getEmpresaFolios(Ruc, ObtieneCadenaConexionPSE21());
            ProgressBar.PerformStep();
            string VigenciaFolios = conex.getEmpresaFoliosVigencia(Ruc, ObtieneCadenaConexionPSE21());
            ProgressBar.PerformStep();
            string Emitio2Meses = conex.getEmpresaEmitio2Meses(Ruc, ObtieneCadenaConexionPSE21());
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
            string TipoPlan = conex.getEmpresaOSETipoPlan(Ruc, ObtieneCadenaConexionOSE());
            ProgressBar.PerformStep();
            string Pse = conex.getEmpresaOSEPSE(Ruc, ObtieneCadenaConexionOSE());
            ProgressBar.PerformStep();
            string folios = conex.getEmpresaFoliosOSE(Ruc, ObtieneCadenaConexionOSE());
            ProgressBar.PerformStep();
            string VigenciaFolios = conex.getEmpresaOSEFoliosVigencia(Ruc, ObtieneCadenaConexionOSE());
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

        private string ObtieneCadenaConexionAdmin()
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

        private string ObtieneCadenaConexionPSE21()
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

        private string ObtieneCadenaConexionOSE()
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

        private string ObtieneCadenaConexionPSE20()
        {
            LeerConfigPersonal config = new LeerConfigPersonal();
            string connectionString = "";
            connectionString =
             "datasource=" + config.HostPSE20 +
             ";port=" + config.PortPSE20 +
             ";username=" + config.UserPSE20 +
             ";password=" + config.ClavePSE20;
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

        private void btnBorrarLog_Click(object sender, EventArgs e)
        {
            rtb_Log.Clear();
        }

        private void btnConsumoFolios_Click(object sender, EventArgs e)
        {
            Log("Cargando resultados, espera por favor unos segundos (Si el rango de fechas es elevado, el tiempo de espera tambien lo sera!)", true, false);
            HiloPrincipal();
        }

        public void HiloPrincipal()
        {
            if (hiloPrimario != null)
            {
                hiloPrimario.Abort();
            }
            CheckForIllegalCrossThreadCalls = false;
            threadPrimario = new ThreadStart(ProcesaBD);
            hiloPrimario = new Thread(threadPrimario);
            hiloPrimario.Start();
        }

        private string ObtieneDesde()
        {
            string dia = dtpDesde.Value.Day.ToString();
            string mes = dtpDesde.Value.Month.ToString();
            string año = dtpDesde.Value.Year.ToString();
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
            string dia2 = dtpHasta.Value.Day.ToString();
            string mes2 = dtpHasta.Value.Month.ToString();
            string año2 = dtpHasta.Value.Year.ToString();
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
            string Ambiente = dtgEmpresas.CurrentRow.Cells[2].Value.ToString();
            if (Ambiente == "PSE" && rb20.Checked)
                Ambiente = "PSE20";
            return Ambiente;
        }

        private void ProcesaBD()
        {
            string desde = ObtieneDesde(), hasta = ObtieneHasta(), ruc = dtgEmpresas.CurrentRow.Cells[0].Value.ToString(), QueryLog = "", Ambiente = ObtieneAmbiente();
            bool aceptado = false, emision = false, creacion = false, activo = false;
            Conexion conex = new Conexion();
            //MessageBox.Show("Espera mientras se procesa tu petición, esto puede demorar unos minutos!");
            //ts_ProgressBar1.Minimum = 1;
            //ts_ProgressBar1.Maximum = 3;
            //ts_ProgressBar1.Value = 1;
            //ts_ProgressBar1.Step = 1;
            //Log("----------------------------", true, false);
            //ts_ProgressBar1.PerformStep();
            QueryLog += "Ruc(s): " + ruc + Environment.NewLine;
            QueryLog += "Razon social: " + dtgEmpresas.CurrentRow.Cells[1].Value.ToString() + Environment.NewLine;
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

            if (rbCreacion.Checked)
            {
                QueryLog += "Fecha Desde: " + desde + " Hasta: " + hasta + Environment.NewLine;              
                QueryLog += "Filtrado por fecha de creación" + Environment.NewLine;
                creacion = true;
            }
            else if (rbEmision.Checked)
            {
                QueryLog += "Fecha Desde: " + desde + " Hasta: " + hasta + Environment.NewLine;
                QueryLog += "Filtrado por fecha de emisión" + Environment.NewLine;
                emision = true;
            }

            if (chckActivo.Checked)
            {
                activo = true;
                QueryLog += "Filtrado por documentos activos" + Environment.NewLine;
            }

            if (chckAceptado.Checked)
            {
                aceptado = true;
                QueryLog += "Filtrado por documentos aceptados" + Environment.NewLine;
            }

            conex = new Conexion();
            //conex.conection(ObtieneCadenaConexion());
            Ambiente = ObtieneAmbiente();
            List<String> listDocumentos = null;
            if (Ambiente == "PSE")
                listDocumentos = conex.getDocumentos(ruc, Ambiente,
                desde, hasta, "", "", activo, emision, creacion, aceptado, ObtieneCadenaConexionPSE21());
            else if(Ambiente == "PSE20")
                listDocumentos = conex.getDocumentos(ruc, Ambiente,
                desde, hasta, "", "", activo, emision, creacion, aceptado, ObtieneCadenaConexionPSE20());
            else
                listDocumentos = conex.getDocumentos(ruc, Ambiente,
                desde, hasta, "", "", activo, emision, creacion, aceptado, ObtieneCadenaConexionOSE());

            if (listDocumentos != null)
            {
                var arrayDocumentos = listDocumentos.ToArray();
                for (int i = 0; i < arrayDocumentos.Length; i++)
                {
                    string linea = arrayDocumentos[i];
                    QueryLog += linea + Environment.NewLine;
                }
                //ts_ProgressBar1.PerformStep();
                Log("Resultados cargados con Exito!", true, false);
                Log(QueryLog, true, false);
            }
        }

        private void cargaEmpresasPSE21()
        {
            try
            {
                Conexion conex = new Conexion();
                gbFiltros.Enabled = false;
                //btnProcesar.Enabled = false;
                //Log("Cargando empresas PSE... Espera unos segundos por favor", true, false);
                //List<String> listClientes = conex.getClientesAdmin("PSE", ObtieneCadenaConexion());
                //Log("Cargando empresas OSE... Espera unos segundos por favor", true, false);
                //List<String> listClientes2 = conex.getClientesAdmin("OSE", ObtieneCadenaConexion3());

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
                List<String> listClientes = conex.getClientesAdmin("OSE", ObtieneCadenaConexionOSE());
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
