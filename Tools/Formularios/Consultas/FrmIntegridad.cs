using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools
{
    public partial class FrmIntegridad : Form
    {
        Thread hiloPrimario, hiloSecundario;
        ThreadStart threadPrimario, threadSecundario;
        public FrmIntegridad(Color color1, Color color2, Color color3, Color color4)
        {
            InitializeComponent();
            btnProcesar.BackColor = color1;
            gbAcciones.ForeColor = color1;
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            Log("----------- Inicia proceso de búsqueda --------------", true, false);

            HiloPrincipal();

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
            string desde = ObtieneDesde(), hasta = ObtieneHasta(), codigoError = cmbCodError.Text, TipoDoc = cmbTipoDoc.Text;
            Conexion conex = new Conexion();
            var uno = conex.ConsultaIntegridad(desde, hasta,TipoDoc, codigoError).ToArray();
            string resumenLog = "";
            Log("Son: " + uno.Length + " casos a revisar.", true, false);

            if (uno != null){
                for (int i = 0; i < uno.Length; i++)
                {
                    Log("----------------------------", true, false);
                    Log("ID: " + uno[i].Id, true, false);
                    Log("Identificador: " + uno[i].Identificador, true, false);
                    Log("RUC: " + uno[i].Ruc, true, false);
                    Log("Supplier: " + uno[i].Supplier, true, false);
                    Log("Hora creación OSE: " + uno[i].HoraCreacionOse, true, false);
                    Log("Hora envío Sunat: " + uno[i].HoraEnvioSunat, true, false);
                    Log("Respuesta Sunat: " + uno[i].MsjSunat, true, false);
                    string cant = uno[i].DocsInformados.Split('|')[0];
                    Log("Total Docs informados en el RC" + "(" + cant + "): " + uno[i].DocsInformados.Split('|')[1], true, false);
                    resumenLog += uno[i].Supplier + "-" + uno[i].Identificador + Environment.NewLine;
                    string Rechazados = ObtenerRechazados(uno[i].MsjSunat);
                    string cant2 = Rechazados.Split('|')[0];
                    string docsRechazados = Rechazados.Split('|')[1];

                    Log("Total Docs rechazados en el RC" + "(" + cant2 + "): " + docsRechazados, true, false);
                    string respuesta1 = conex.ConsultaDocsRechazadosIndiv(uno[i].Ruc, uno[i].Supplier, docsRechazados);
                    Log("Revisión Docs rechazados en el RC, Informados de manera individual: " + Environment.NewLine + respuesta1, true, false);

                    if(respuesta1 == "No existe información.")
                    {
                        string respuesta2 = conex.ConsultaDocsRechazadosMasiv(uno[i].Ruc, uno[i].Supplier, docsRechazados);
                        Log("Revisión Docs rechazados en el RC, Informados de manera Masiva (RC): " + Environment.NewLine + respuesta2, true, false);
                    }                   

                    Log("----------------------------" + Environment.NewLine, true, false);
                }
            }

            Log("----------- Finaliza proceso de búsqueda --------------", true, false);
            Log(Environment.NewLine + resumenLog, true, false);


            //QueryLog += "Ruc(s): " + ruc + Environment.NewLine;
            //QueryLog += "Razon social: " + txt_RazonS.Text + Environment.NewLine;
            //if (Ambiente.Equals("PSE"))
            //{
            //    QueryLog += "Servicio PSE 2.1" + Environment.NewLine;
            //}
            //else if (Ambiente.Equals("PSE20"))
            //{
            //    QueryLog += "Servicio PSE 2.0" + Environment.NewLine;
            //}
            //else
            //{
            //    QueryLog += "Servicio OSE" + Environment.NewLine;
            //}

            //if (btnFecha.IsOn && rbCreacion.Checked)
            //{
            //    QueryLog += "Fecha Desde: " + desde + " Hasta: " + hasta + Environment.NewLine;

            //    if (btnHora.IsOn)
            //    {
            //        QueryLog += "Hora Desde: " + horaDesde + " Hasta: " + horaHasta + Environment.NewLine;
            //    }
            //    QueryLog += "Filtrado por fecha de creación" + Environment.NewLine;
            //    creacion = true;
            //}
            //else if (btnFecha.IsOn && rbEmision.Checked)
            //{
            //    QueryLog += "Fecha Desde: " + desde + " Hasta: " + hasta + Environment.NewLine;
            //    QueryLog += "Filtrado por fecha de emisión" + Environment.NewLine;
            //    emision = true;
            //}

            //if (chckActivo.Checked)
            //{
            //    activo = true;
            //    QueryLog += "Filtrado por documentos activos" + Environment.NewLine;
            //}

            //if (chckAceptado.Checked)
            //{
            //    aceptado = true;
            //    QueryLog += "Filtrado por documentos aceptados" + Environment.NewLine;
            //}

            //conex = new Conexion();
            ////conex.conection(ObtieneCadenaConexion());
            //Ambiente = ObtieneAmbiente();
            //List<String> listDocumentos = conex.getDocumentos(ruc, Ambiente,
            //    desde, hasta, horaDesde, horaHasta, activo, emision, creacion, aceptado, ObtieneCadenaConexion());
            //if (listDocumentos != null)
            //{
            //    var arrayDocumentos = listDocumentos.ToArray();
            //    for (int i = 0; i < arrayDocumentos.Length; i++)
            //    {
            //        string linea = arrayDocumentos[i];
            //        QueryLog += linea + Environment.NewLine;
            //    }
            //    //ts_ProgressBar1.PerformStep();
            //    Log("Resultados cargados con Exito!", true, false);
            //    Log(QueryLog, true, false);
            //}
        }

        private void FrmIntegridad_Load(object sender, EventArgs e)
        {
            cmbTipoDoc.SelectedIndex = 0;
            cmbCodError.SelectedIndex = 0;
            dtpDesde.Value = DateTime.Now;
            dtpHasta.Value = DateTime.Now;

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

        private string ObtenerRechazados(string cadena) {
            string uno = cadena.Replace("[[", "$");
            string inicio = uno.Split('$')[1];
            string inicio2 = uno.Split('[')[0];

            string final;
            string dos = "";
            final = inicio.Replace("]", "");
            final = final.Replace("[", "");

            int cant = final.Split(',').Length;
            return cant.ToString() + "|" + final;
        }

    }
}
