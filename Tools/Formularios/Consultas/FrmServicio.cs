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

        public FrmServicio()
        {
            InitializeComponent();
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

                Thread.Sleep(ObtieneFrecuenciaMilisegundos());
            }
        }

        private void btnTarea_Click(object sender, EventArgs e)
        {
            if (btnTarea.Text == "Iniciar tarea")
            {
                lblEstadoTarea.Text = "Encendida";
                Encendido = true;
                btnTarea.Text = "Detener tarea";
                EjecutaTarea();
                lblUltHoraEjec.Text = ObtieneHoraActual();
                lblProxHoraEjec.Text = ObtieneHoraProxima();
            }
            else
            {
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
    }
}
