using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools
{

    public partial class FrmConsultasBD : Form
    {
        string[] arrayOfEmpresas;
        List<String> listClientesPSE = null;
        List<String> listClientesOSE = null;
        public FrmConsultasBD(Color color1, Color color2, Color color3, Color color4, List<String> lisCliPSE, List<String> listCliOSE)
        {
            InitializeComponent();
            tlpForm.BackColor = Color.White;
            btnProcesar.BackColor = color1;
            //tlpLog.BackColor = color1;
            //rtb_Log.BackColor = color1;
            gbAmbiente.ForeColor = color1;
            gbFiltros.ForeColor = color1;
            //rtb_Log.ForeColor = color2;
            //lbl_Log.ForeColor = color2;
            listClientesPSE = lisCliPSE;
            listClientesOSE = listCliOSE;
        }
        Thread hiloPrimario, hiloSecundario;
        ThreadStart threadPrimario, threadSecundario;


        private bool validaCampos()
        {
            int errores = 0;
            string Mensaje = "";
            if(txt_RucPse.TextLength != 11)
            {
                errores++;
                Mensaje += "El ruc debe poseer 11 caracteres" + Environment.NewLine;
            }
            if (!Regex.IsMatch(txt_RucPse.Text, @"^[0-9]+$"))
            {
                errores++;
                Mensaje += "El ruc debe ser numérico." + Environment.NewLine;
            }
            if(btnFecha.IsOn == false)
            {
                errores++;
                Mensaje += "Debes indicar un rango de fecha obligatoriamente" + Environment.NewLine;
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
                Log("Cargando resultados, espera por favor unos segundos (Si el rango de fechas es elevado, el tiempo de espera tambien lo sera!)", true, false);
                HiloPrincipal();
            }           
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

        private void ProcesaBD()
        {
            string desde = ObtieneDesde(), hasta = ObtieneHasta(), ruc = txt_RucPse.Text, QueryLog = "", Ambiente = ObtieneAmbiente(), horaDesde = ObtieneHoraDesde(), horaHasta = ObtieneHoraHasta();
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

            if (btnFecha.IsOn && rbCreacion.Checked)
            {
                QueryLog += "Fecha Desde: " + desde + " Hasta: " + hasta + Environment.NewLine;
              
                if (btnHora.IsOn)
                {
                    QueryLog += "Hora Desde: " + horaDesde + " Hasta: " + horaHasta + Environment.NewLine;
                }
                QueryLog += "Filtrado por fecha de creación" + Environment.NewLine;
                creacion = true;
            }
            else if (btnFecha.IsOn && rbEmision.Checked)
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
            List<String> listDocumentos = conex.getDocumentos(ruc, Ambiente,
                desde, hasta, horaDesde, horaHasta, activo, emision, creacion, aceptado, ObtieneCadenaConexion());
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

        private string ObtieneCadenaConexion()
        {
            string Ambiente = ObtieneAmbiente();
            LeerConfigPersonal config = new LeerConfigPersonal();
            
            string connectionString = "";
            if (Ambiente == "PSE")
            {
                connectionString =
                "datasource=" + config.HostPSE21 +
                ";port=" + config.PortPSE21 +
                ";username=" + config.UserPSE21 +
                ";password=" + config.ClavePSE21;
            }
            else if (Ambiente == "PSE20")
            {
                connectionString =
               "datasource=" + config.HostPSE20 +
               ";port=" + config.PortPSE20 +
               ";username=" + config.UserPSE20 +
               ";password=" + config.ClavePSE20;
            }
            else
            {
                connectionString =
               "datasource=" + config.HostOSE +
               ";port=" + config.PortOSE +
               ";username=" + config.UserOSE +
               ";password=" + config.ClaveOSE;
            }
            return connectionString;
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

        private string ObtieneAmbiente()
        {
            String Ambiente = "";
            if (rbPSE21.Checked)
            {
                Ambiente = "PSE";
            }
            else if (rbOSE.Checked)
            {
                Ambiente = "OSE";
            }
            else
            {
                Ambiente = "PSE20";
            }
            return Ambiente;
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

        private string ObtieneHoraDesde()
        {
            string desde = "";
            if (btnHora.IsOn)
            {
                string hora = dtpHoraDesde.Value.Hour.ToString();
                string minuto = dtpHoraDesde.Value.Minute.ToString();
                string segundo = dtpHoraDesde.Value.Second.ToString();
                if (hora.Length == 1)
                {
                    hora = "0" + hora;
                }
                if (minuto.Length == 1)
                {
                    minuto = "0" + minuto;
                }
                if (segundo.Length == 1)
                {
                    segundo = "0" + segundo;
                }
                desde = hora + ":" + minuto + ":" + segundo;
            }           
            return desde;
        }

        private string ObtieneHoraHasta()
        {
            string desde = "";
            if (btnHora.IsOn)
            {
                string hora = dtpHoraHasta.Value.Hour.ToString();
                string minuto = dtpHoraHasta.Value.Minute.ToString();
                string segundo = dtpHoraHasta.Value.Second.ToString();
                if (hora.Length == 1)
                {
                    hora = "0" + hora;
                }
                if (minuto.Length == 1)
                {
                    minuto = "0" + minuto;
                }
                if (segundo.Length == 1)
                {
                    segundo = "0" + segundo;
                }
                desde = hora + ":" + minuto + ":" + segundo;
            }            
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

        private void FrmConsultasBD_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now;
            dtpHasta.Value = DateTime.Now;
            chckAceptado.Checked = true;
            chckActivo.Checked = true;
            rbEmision.Checked = true;
            pnl3.Visible = false;
            pnl4.Visible = false;
            pnl5.Visible = false;
        }

        private void cargaEmpresasPSE21()
        {
            try
            {
                Conexion conex = new Conexion();
                Log("Cargando empresas... Espera unos segundos por favor", true, false);
                gbFiltros.Enabled = false;
                btnProcesar.Enabled = false;
                List<String> listClientes = conex.getClientes(txt_RucPse.Text, ObtieneAmbiente(), ObtieneCadenaConexion());
                //ts_ProgressBar1.Minimum = 1;
                //ts_ProgressBar1.Maximum = listClientes.Count;
                //ts_ProgressBar1.Value = 1;
                //ts_ProgressBar1.Step = 1;
                arrayOfEmpresas = listClientes.ToArray();
                for (int i = 0; i < arrayOfEmpresas.Length; i++)
                {
                    //MessageBox.Show(arrayOfEmpresas[i].Split('|')[1]);
                    //txt_RazonS.AutoCompleteCustomSource.Add(arrayOfEmpresas[i].Split('|')[1]);
                    //ts_ProgressBar1.PerformStep();
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

        private void rbPSE21_CheckedChanged(object sender, EventArgs e)
        {
            //chckHora.Visible = false;
            txt_RucPse.Text = "";
            txt_RazonS.Text = "";
            //tableLayoutPanel28.Enabled = true;
            if (rbPSE21.Checked)
            {
                HiloSecundario();
            }           
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

        private void rbOSE_CheckedChanged(object sender, EventArgs e)
        {
            //chckHora.Visible = false;
            txt_RucPse.Text = "";
            txt_RazonS.Text = "";
            //tableLayoutPanel28.Enabled = true;
            if (rbOSE.Checked)
            {
                HiloSecundario();
            }
        }

        private void rbPSE20_CheckedChanged(object sender, EventArgs e)
        {
            //chckHora.Visible = false;
            txt_RucPse.Text = "";
            txt_RazonS.Text = "";
            //tableLayoutPanel28.Enabled = true;
            if (rbPSE20.Checked)
            {
                HiloSecundario();
            }
        }

        private void chckFecha_CheckedChanged(object sender, EventArgs e)
        {
            if(dtpDesde.Enabled == true)
            {
                dtpDesde.Enabled = false;
                dtpHasta.Enabled = false;
                dtpHoraDesde.Enabled = false;
                dtpHoraHasta.Enabled = false;
                rbCreacion.Enabled = false;
                rbEmision.Enabled = false;
                //chckHora.Enabled = false;
            }
            else
            {
                dtpDesde.Enabled = true;
                dtpHasta.Enabled = true;
                rbCreacion.Enabled = true;
                rbEmision.Enabled = true;
            }
        }

        private void txt_RucPse_Click_1(object sender, EventArgs e)
        {
            txt_RazonS.Text = "";
        }

        private void txt_RazonS_Click_1(object sender, EventArgs e)
        {
            //txt_RucPse.Text = "";
        }

        private void txt_RucPse_TextChanged_1(object sender, EventArgs e)
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

        private void txt_RazonS_TextChanged_1(object sender, EventArgs e)
        {
            if (txt_RazonS.Text != "" && txt_RucPse.Text == "")
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

        private void chckHora_Click(object sender, EventArgs e)
        {
            if (!btnHora.IsOn)
            {              
                dtpHoraDesde.Enabled = false;
                dtpHoraHasta.Enabled = false;
            }
            else
            {
                dtpHoraDesde.Enabled = true;
                dtpHoraHasta.Enabled = true;           
            }
        }

        private void rbEmision_Click(object sender, EventArgs e)
        {
            if (rbEmision.Checked)
            {
                dtpHoraDesde.Enabled = false;
                dtpHoraHasta.Enabled = false;
                btnHora.Visible = false;
            }
            else
            {
                dtpHoraDesde.Enabled = true;
                dtpHoraHasta.Enabled = true;
                btnHora.Visible = true;
            }
        }

        private void rbCreacion_Click(object sender, EventArgs e)
        {
            if (rbCreacion.Checked)
            {
                //dtpHoraDesde.Enabled = true;
                //dtpHoraHasta.Enabled = true;
                btnHora.Visible = true;
            }
            else
            {
                //dtpHoraDesde.Enabled = false;
                //dtpHoraHasta.Enabled = false;
                btnHora.Visible = false;
            }
        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void btnFecha_SliderValueChanged(object sender, EventArgs e)
        {
            if (pnl3.Visible == true)
            {
                pnl3.Visible = false;
                pnl4.Visible = false;
                pnl5.Visible = false;
            }
            else
            {
                pnl3.Visible = true;
                pnl4.Visible = true;
                rbEmision.Enabled = true;
                rbCreacion.Enabled = true;
            }
        }

        private void btnHora_SliderValueChanged(object sender, EventArgs e)
        {
            if (pnl5.Visible == true)
            {
                pnl5.Visible = false;
            }
            else
            {
                pnl5.Visible = true;
            }
        }

        private void btnBorrarLog_Click(object sender, EventArgs e)
        {
            rtb_Log.Clear();
        }

        private void slideButton1_Click(object sender, EventArgs e)
        {

            //if (pnl3.Visible == true)
            //{
            //    pnl3.Visible = false;
            //    pnl4.Visible = false;
            //    pnl5.Visible = false;
            //}
            //else
            //{
            //    pnl3.Visible = true;
            //    pnl4.Visible = true;
            //    rbEmision.Enabled = true;
            //    rbCreacion.Enabled = true;
            //}
            //if (pnl3.Visible == true)
            //{
            //    dtpDesde.Enabled = false;
            //    dtpHasta.Enabled = false;
            //    dtpHoraDesde.Enabled = false;
            //    dtpHoraHasta.Enabled = false;
            //    rbCreacion.Enabled = false;
            //    rbEmision.Enabled = false;
            //    btnHora.Visible = false;
            //}
            //else
            //{
            //    dtpDesde.Enabled = true;
            //    dtpHasta.Enabled = true;
            //    rbCreacion.Enabled = true;
            //    rbEmision.Enabled = true;
            //}
        }

        private void slideButton2_Click(object sender, EventArgs e)
        {
            //if (pnl5.Visible == true)
            //{
            //    pnl5.Visible = false;
            //}
            //else
            //{
            //    pnl5.Visible = true;
            //}
        }
    }
}
