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
    public partial class FrmConsultaSunat : Form
    {
        Thread hiloPrimario, hiloSecundario;
        ThreadStart threadPrimario, threadSecundario;
        List<string> lista1, lista2, lista3, lista4, lista5, lista6, lista7, lista8, lista9, lista10, lista11, lista12, lista13, lista14, lista15, lista16;

        private void btnBorrarLog_Click(object sender, EventArgs e)
        {
            rtb_Log.Clear();
        }

        int contador = 0;

        public FrmConsultaSunat(Color color1, Color color2, Color color3, Color color4)
        {
            InitializeComponent();
            tlpForm.BackColor = Color.White;
            btnProcesar.BackColor = color1;
            btnConsultaSunatOSE.IconColor = color1;
            btnConsultaSunatPSE.IconColor = color1;
            //tlpLog.BackColor = color1;
            //rtb_Log.BackColor = color1;
            gbAmbiente.ForeColor = color1;
            gbFiltros.ForeColor = color1;
            //rtb_Log.ForeColor = color2;
            //lbl_Log.ForeColor = color2;
        }

        private void FrmConsultaSunat_Load(object sender, EventArgs e)
        {

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
            " and status_sunat in(0)" + Environment.NewLine + Environment.NewLine +

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

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if(rtb_consultas.Text != "" && rtb_consultas.Lines.Length < 10000)
            {
                CheckForIllegalCrossThreadCalls = false;
                var recorrer = rtb_consultas.Lines;                
                ProgressBar.Maximum = recorrer.Length;
                ProgressBar.Step = 1;
                ProgressBar.Value = 0;
                var arraytotal = Calculo(recorrer);
                for (int i = 0; i < arraytotal.Length; i++)
                {
                    int temp = i;
                    Task.Factory.StartNew(() => method1(arraytotal[temp]));
                }
            }               
        }

        private void method1(string[] uno)
        {
            foreach (string iteraccion in uno)
            {
                try
                {
                    //ts_ProgressBar1.PerformStep();
                    Sunat.billValidServiceClient ServicioSunat = new Sunat.billValidServiceClient();
                    string[] campo = iteraccion.Split('|');
                    if (campo.Length > 2)
                    {
                        var resp = ServicioSunat.validaCDPcriterios(campo[0], campo[1], campo[2], campo[3], campo[4], campo[5], campo[6], Convert.ToDouble(campo[7]), " ");
                        contador++;
                        //Log(resp.statusMessage, true, LogFechaHora);
                        Log(resp.statusMessage + " |" + contador + "| ", true, false);
                        //rtb_Log.AppendText(resp.statusMessage + " |" + contador + "| " + Environment.NewLine);
                        ProgressBar.PerformStep();
                        //Log("Hilo1", true, LogFechaHora);
                    }
                    else
                    {
                        Log("Por favor valida la estructura de la cadena de caracteres", false, false);
                    }
                }
                catch (Exception e)
                {
                    //rtb_Log.AppendText("Error: " + e.Message + Environment.NewLine);
                   Log(e.Message, false, false);
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

    }
}
