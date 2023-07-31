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
    public partial class FrmServicio : Form
    {
        bool Encendido = false;

        public FrmServicio(Color color1, Color color2, Color color3, Color color4)
        {
            InitializeComponent();
            //tlpLog.BackColor = color1;
            //rtb_Log.BackColor = color1;
            //rtb_Log.ForeColor = color2;
            //lbl_Log.ForeColor = color2;
            btnTarea.BackColor = color1;
            btnForzarEjecucion.BackColor = color1;
            btnDetalleFact95.BackColor = color1;
            btnDetalleNC95.BackColor = color1;
            btnDetalleGR95.BackColor = color1;
            btnDetalleGR98.BackColor = color1;
            gbFiltros.ForeColor = color1;
            gbAcciones.ForeColor = color1;

            lbl_Log.ForeColor = color1;
            btnBorrarLog.IconColor = color1;
            rtb_Log.ForeColor = color1;
            rtb_Log.ReadOnly = true;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private string ObtieneCadenaConexion()
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

        private int ObtieneFrecuenciaMilisegundos()
        {
            int num = 0;

            if (rbFrec10min.Checked)
                num = 600000;
            else if (rbFrec20min.Checked)
                num = 1200000;
            else if (rbFrec30min.Checked)
                num = 1800000;

            return num;
        }

        private string ObtieneDesde()
        {
            string año, mes, dia, hora, minuto, segundo;
            DateTime tiempo = DateTime.Now;

            if (rbDesde1hora.Checked)
                tiempo = DateTime.Now.AddHours(-1);
            else if (rbDesde2horas.Checked)
                tiempo = DateTime.Now.AddHours(-2);
            else if (rbDesde6horas.Checked)
                tiempo = DateTime.Now.AddHours(-6);
            else if (rbDesdeDia.Checked)
                tiempo = DateTime.Now.AddHours(-24);

            año = tiempo.Year.ToString();
            mes = tiempo.Month.ToString();
            dia = tiempo.Day.ToString();
            hora = tiempo.Hour.ToString();
            minuto = tiempo.Minute.ToString();
            segundo = tiempo.Second.ToString();

            if (mes.Length == 1)
                mes = "0" + mes;

            if (dia.Length == 1)
                dia = "0" + dia;

            if (hora.Length == 1)
                hora = "0" + hora;

            if (minuto.Length == 1)
                minuto = "0" + minuto;

            if (segundo.Length == 1)
                segundo = "0" + segundo;

            return año + "-" + mes + "-" + dia + " " + hora + ":" + minuto + ":" + segundo;
        }

        private string ObtieneHasta()
        {
            string año, mes, dia, hora, minuto, segundo;
            DateTime tiempo = DateTime.Now;

            if (rbHasta15min.Checked)
                tiempo = DateTime.Now.AddMinutes(-15);
            else if (rbHastaDia.Checked)
                tiempo = DateTime.Now.AddDays(1);           

            año = tiempo.Year.ToString();
            mes = tiempo.Month.ToString();
            dia = tiempo.Day.ToString();
            hora = tiempo.Hour.ToString();
            minuto = tiempo.Minute.ToString();
            segundo = tiempo.Second.ToString();

            if (mes.Length == 1)
                mes = "0" + mes;

            if (dia.Length == 1)
                dia = "0" + dia;

            if (hora.Length == 1)
                hora = "0" + hora;

            if (minuto.Length == 1)
                minuto = "0" + minuto;

            if (segundo.Length == 1)
                segundo = "0" + segundo;

            return año + "-" + mes + "-" + dia + " " + hora + ":" + minuto + ":" + segundo;
        }

        private string ObtieneHoraActual()
        {
            string hora, minuto, segundo;
            DateTime tiempo = DateTime.Now;
            hora = tiempo.Hour.ToString();
            minuto = tiempo.Minute.ToString();
            segundo = tiempo.Second.ToString();         

            if (hora.Length == 1)
                hora = "0" + hora;

            if (minuto.Length == 1)
                minuto = "0" + minuto;

            if (segundo.Length == 1)
                segundo = "0" + segundo;

            return hora + ":" + minuto + ":" + segundo;
        }

        private string ObtieneHoraProxima()
        {
            string hora, minuto, segundo;
            DateTime tiempo = DateTime.Now.AddMilliseconds(ObtieneFrecuenciaMilisegundos());
            hora = tiempo.Hour.ToString();
            minuto = tiempo.Minute.ToString();
            segundo = tiempo.Second.ToString();

            if (hora.Length == 1)
                hora = "0" + hora;

            if (minuto.Length == 1)
                minuto = "0" + minuto;

            if (segundo.Length == 1)
                segundo = "0" + segundo;

            return hora + ":" + minuto + ":" + segundo;
        }

        private void FrmServicio_Load(object sender, EventArgs e)
        {
            //EjecutaTarea();
        }

        private void EjecutaTarea()
        {
            CheckForIllegalCrossThreadCalls = false;
            Task.Factory.StartNew(() => method1());
        }

        private void method1()
        {
            while (Encendido)
            {
                Conexion conex = new Conexion();
                if(chckFact.IsOn)
                    lblStatus95Facts.Text = conex.getFact95(ObtieneDesde(), ObtieneHasta(), ObtieneCadenaConexion()).ToString();

                if(chckNCND.IsOn)
                    lblStatus95NCND.Text = conex.getNotes95(ObtieneDesde(), ObtieneHasta(), ObtieneCadenaConexion()).ToString();

                if (chckGR.IsOn)
                    lblStatus95GR.Text = conex.getGR95(ObtieneDesde(), ObtieneHasta(), ObtieneCadenaConexion()).ToString();

                if (chckGR.IsOn)
                    lblStatus98GR.Text = conex.getGR98(ObtieneDesde(), ObtieneHasta(), ObtieneCadenaConexion()).ToString();

                lblUltHoraEjec.Text = ObtieneHoraActual();
                lblProxHoraEjec.Text = ObtieneHoraProxima();
                string Mensaje = "-------------------" + Environment.NewLine;
                Mensaje += "Fact 95: " + lblStatus95Facts.Text;
                Mensaje += ", NC/ND 95: " + lblStatus95NCND.Text;
                Mensaje += ", GR 95: " + lblStatus95GR.Text;
                Mensaje += ", GR 98: " + lblStatus98GR.Text + Environment.NewLine;
                Mensaje += "Hora: " + lblUltHoraEjec.Text + Environment.NewLine;
                Mensaje += "-------------------";
                Log(Mensaje, true, false);

                Thread.Sleep(ObtieneFrecuenciaMilisegundos());               
            }
        }

        private void btnTarea_Click(object sender, EventArgs e)
        {
            if (btnTarea.Text == "Iniciar tarea")
            {
                Log("-------- Tarea iniciada -------- ", true, false);
                lblEstadoTarea.Text = "Encendida";
                Encendido = true;
                btnTarea.Text = "Detener tarea";
                //lblUltHoraEjec.Text = ObtieneHoraActual();
                //lblProxHoraEjec.Text = ObtieneHoraProxima();
                EjecutaTarea();              
            }
            else
            {
                Log("-------- Tarea detenida -------- ", true, false);

                lblEstadoTarea.Text = "Apagada";
                btnTarea.Text = "Iniciar tarea";
                lblProxHoraEjec.Text = "00:00:00";
                lblStatus95GR.Text = "-";
                lblStatus95Facts.Text = "-";
                lblStatus95NCND.Text = "-";
                lblStatus98GR.Text = "-";
                Encendido = false;
            }

        }

        private void btnForzarEjecucion_Click(object sender, EventArgs e)
        {

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

        private void btnBorrarLog_Click(object sender, EventArgs e)
        {
            rtb_Log.Clear();
        }
    }
}
