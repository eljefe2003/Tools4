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
using Tools.Clases_varias;
//using System.Windows.Media;

namespace Tools
{
    public partial class FrmCargaInicial : Form
    {
        Color Color1, Color2, Color3, Color4;
        Thread hiloSecundario;
        ThreadStart threadSecundario;
        List<String> listClientesPSE = null;
        List<String> listClientesOSE = null;

        public FrmCargaInicial()
        {
            InitializeComponent();
        }

        private void FrmCargaInicial_Load(object sender, EventArgs e)
        {
            LeerConfigPersonal configPersonal = new LeerConfigPersonal();
            InicializarColores(configPersonal.Color);
            CheckForIllegalCrossThreadCalls = false;
            //HiloCargaEmpresas();
            btnAceptar.Enabled = true;
        }

        public void HiloCargaEmpresas()
        {
            if (hiloSecundario != null)
            {
                hiloSecundario.Abort();
            }
            CheckForIllegalCrossThreadCalls = false;
            threadSecundario = new ThreadStart(cargaEmpresas);
            hiloSecundario = new Thread(threadSecundario);
            hiloSecundario.Start();
        }

        private void cargaEmpresas()
        {
            btnAceptar.Visible = false;
            try
            {
                Conexion conex = new Conexion();
                listClientesPSE = conex.getClientesAdmin("PSE", ObtieneCadenaConexion());
                //lblEmpresasPSE.Text = "Exitoso!";
            }
            catch (Exception ez)
            {
                lblEmpresasPSE.Text = "Error: " + ez.Message;
            }
            finally
            {
                if(listClientesPSE is null)
                    lblEmpresasPSE.Text = "Error, revisa tus Credenciales PSE";
                else
                    lblEmpresasPSE.Text = "Exitoso!";

                pcEmpresasPSE.Spin = false;
                pcEmpresasPSE.Others = Color1;
            }

            try
            {
                Conexion conex = new Conexion();
                listClientesOSE = conex.getClientesAdmin("OSE", ObtieneCadenaConexion3());
                //lblEmpresasOSE.Text = "Exitoso!";
            }
            catch (Exception ez)
            {
                lblEmpresasOSE.Text = "Error: " + ez.Message;
            }
            finally
            {
                if (listClientesOSE is null)
                    lblEmpresasOSE.Text = "Error, revisa tus Credenciales OSE";
                else
                    lblEmpresasOSE.Text = "Exitoso!";

                pcEmpresasOSE.Spin = false;
                pcEmpresasOSE.Others = Color1;
            }

            try
            {
                if (cargaDrive())
                    lblEjemplos.Text = "Exitoso!";
                else
                    lblEjemplos.Text = "Verifica la ruta de tu google Drive!";
            }
            catch (Exception ez)
            {
                lblEjemplos.Text = "Error: " + ez.Message;
            }
            finally
            {
                pcEjemplos.Spin = false;
                pcEjemplos.Others = Color1;
            }
            btnAceptar.Visible = true;

        }

        public bool cargaDrive()
        {
            LeerConfigPersonal ConfigPerso = new LeerConfigPersonal();
            try
            {
                string nombre = "GoogleDriveFS";
                string currPrsName = Process.GetCurrentProcess().ProcessName;
                Process[] allProcessWithThisName
                             = Process.GetProcessesByName(nombre);
                if (allProcessWithThisName.Length > 1)
                {
                    foreach (Process proceso in Process.GetProcesses())
                    {
                        if (proceso.ProcessName == nombre)
                        {
                            proceso.Kill();
                        }
                    }
                }
                System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
                start.FileName = ConfigPerso.RutaDrive;
                start.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                System.Diagnostics.Process.Start(start);
                Thread.Sleep(5000);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                //MessageBox.Show("Verifica la ruta de tu google Drive, la sgte. ruta no existe: " + ConfigPerso.RutaDrive);
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Index frm_u = new Index(listClientesPSE, listClientesOSE);
            DialogResult res = frm_u.ShowDialog();
            if (res == DialogResult.OK)
            {

            }
            //LecturaCdr cdr = new LecturaCdr();
            //var uno = cdr.LeerCDR("C:\\Users\\guevarae\\Downloads\\R-20550728762-09-T001-75799041.xml");
        }

        private void InicializarColores(string Tema)
        {
            Color1 = Color.FromArgb(107, 35, 88);
            Color2 = Color.FromArgb(238, 150, 215);
            Color3 = Color.FromArgb(235, 77, 193);
            Color4 = Color.FromArgb(107, 67, 97);

            if (Tema == "Rosado")
            {
                Color1 = Color.FromArgb(150, 35, 88);
                Color2 = Color.FromArgb(238, 150, 215);
                Color3 = Color.FromArgb(250, 139, 241);
                Color4 = Color.FromArgb(107, 67, 97);
            }
            else if (Tema == "Azul")
            {
                Color1 = Color.FromArgb(35, 64, 107);
                Color2 = Color.FromArgb(150, 185, 238);
                Color3 = Color.FromArgb(77, 140, 235);
                Color4 = Color.FromArgb(67, 83, 107);
            }
            else if (Tema == "Verde")
            {
                Color1 = Color.FromArgb(33, 107, 48);
                Color2 = Color.FromArgb(145, 238, 164);
                Color3 = Color.FromArgb(73, 235, 105);
                Color4 = Color.FromArgb(65, 107, 74);
            }
            else if (Tema == "Amarillo")
            {
                Color1 = Color.FromArgb(107, 98, 39);
                Color2 = Color.FromArgb(238, 227, 157);
                Color3 = Color.FromArgb(235, 215, 84);
                Color4 = Color.FromArgb(107, 102, 71);
            }
            tableLayoutPanel2.BackColor = Color2;
            btnAceptar.BackColor = Color1;
            btnAceptar.ForeColor = Color2;
            pcEmpresasPSE.Others = Color3;
            pcEmpresasPSE.IndexColor = Color1;
            pcEmpresasOSE.Others = Color3;
            pcEmpresasOSE.IndexColor = Color1; 
            pcEjemplos.Others = Color3;
            pcEjemplos.IndexColor = Color1;

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

    }
}
