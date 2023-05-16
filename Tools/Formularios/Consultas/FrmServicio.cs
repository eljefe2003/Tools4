using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools
{
    public partial class FrmServicio : Form
    {
        public FrmServicio()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

            return año + "-" + mes + "-" + dia + " " + hora + "-" + minuto + "-" + segundo;
        }

        private void btnActualizaParametros_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ObtieneDesde());
        }
    }
}
