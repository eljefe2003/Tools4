using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using Application = System.Windows.Forms.Application;
using Color = System.Drawing.Color;
using FontStyle = System.Drawing.FontStyle;
using MessageBox = System.Windows.Forms.MessageBox;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace Tools
{
    public partial class Index : Form
    {

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        Color Color1, Color2, Color3, Color4;
        private Form FormHijoActual;
        private Panel leftBorderBtn;
        private IconButton currentBtn;
        private IconButton currentBtn2;
        string color;
        List<string> listPSE = null;
        List<string> listOSE = null;

        public Index(List<string> listPse, List<string> listOse)
        {
            listPSE = listPse;
            listOSE = listOse;
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 25);
            pnlMenu.Controls.Add(leftBorderBtn);

        }

        private void InicializarColores(string Tema)
        {
            Color1 = Color.FromArgb(150, 35, 88);
            Color2 = Color.FromArgb(247, 102, 174);
            Color3 = Color.FromArgb(250, 139, 241);
            Color4 = Color.FromArgb(107, 67, 97);

            if (Tema == "Rosado")
            {
                //Color1 = Color.FromArgb(107, 35, 88);
                //Color2 = Color.FromArgb(238, 150, 215);
                //Color3 = Color.FromArgb(235, 77, 193);
                //Color4 = Color.FromArgb(107, 67, 97);
                Color1 = Color.FromArgb(150, 35, 88);
                Color2 = Color.FromArgb(246, 153, 190);
                Color3 = Color.FromArgb(247, 102, 174);
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

            pnlTop.BackColor = Color1;
            pnlLeft.BackColor = Color1;
            pnlButton.BackColor = Color1;
            pnlRight.BackColor = Color1;   
            pnlForm.BackColor = Color4;
            pnlEmision.BackColor = Color2;
            pnlConsultas.BackColor = Color2;
            pnlConfiguracion.BackColor = Color2;
            pnlTop2.BackColor = Color3;
            pnlMenu.BackColor = Color3;
            //btnMinimizar.IconColor = Color1;
            //btnMaximizar.IconColor = Color1;
            //btnCerrar.IconColor = Color1;
        }

        private void AbrirFormHijo(Form childForm)
        {
            //open only form
            if (FormHijoActual != null)
            {
                FormHijoActual.Close();
            }
            FormHijoActual = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlForm.Controls.Add(childForm);
            pnlForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            //lbl_FormHijoActual.Text = childForm.Text;
        }

        private void btnEmision_Click(object sender, EventArgs e)
        {
            if (pnlEmision.Visible == true)
            {
                esconderSubMenu();
                DisableButton();
            }
            else
            {
                ActivateButton(sender, Color1);
                pnlEmision.Visible = true;
                pnlConfiguracion.Visible = false;
                pnlConsultas.Visible = false;
            }
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            if (pnlConsultas.Visible == true)
            {
                esconderSubMenu();
                DisableButton();
            }
            else
            {
                ActivateButton(sender, Color1);
                pnlConsultas.Visible = true;
                pnlConfiguracion.Visible = false;
                pnlEmision.Visible = false;
            }
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            if (pnlConfiguracion.Visible == true)
            {
                esconderSubMenu();
                DisableButton();
            }
            else
            {
                ActivateButton(sender, Color1);
                pnlConfiguracion.Visible = true;
                pnlConsultas.Visible = false;
                pnlEmision.Visible = false;

            }
        }

        private void btnConfigBD_Click(object sender, EventArgs e)
        {
            ActivateButton2(sender);
            FrmConfigBD frm_u = new FrmConfigBD();
            FrmConfigBD.ColorBotones = Color3;
            FrmConfigBD.ColorLetras = Color1;
            FrmConfigBD.ColorTXT = Color2;
            //btnNombreFormulario.Text = frm_u.Text;
            //frm_u.Show();
            DialogResult res = frm_u.ShowDialog();
            if (res == DialogResult.OK)
            {

            }
        }

        private void esconderSubMenu()
        {
            if (pnlEmision.Visible == true)
            {
                pnlEmision.Visible = false;
            }
            if (pnlConfiguracion.Visible == true)
            {
                pnlConfiguracion.Visible = false;
            }
            if (pnlConsultas.Visible == true)
            {
                pnlConsultas.Visible = false;
            }
        }

        private void btnDailyTask_Click(object sender, EventArgs e)
        {
            ActivateButton2(sender);
            FrmToolDaily childForm = new FrmToolDaily(Color1, Color2, Color3, Color4);
            if (FormHijoActual != null)
            {
                FormHijoActual.Close();
            }
            FormHijoActual = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlForm.Controls.Add(childForm);
            pnlForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblSeccion.Text = childForm.Text;
        }

        private void cmbTema_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModificaColor(cmbTema.Text);           
            InicializarColores(cmbTema.Text);
            //FrmToolDaily childForm = new FrmToolDaily(Color1, Color2, Color3, Color4);
            if (FormHijoActual != null)
            {
                FormHijoActual.Close();
            }
            //FormHijoActual = childForm;
            ////End
            //childForm.TopLevel = false;
            //childForm.FormBorderStyle = FormBorderStyle.None;
            //childForm.Dock = DockStyle.Fill;
            //pnlForm.Controls.Add(null);
            //pnlForm.Tag = childForm;
            //childForm.BringToFront();
            //childForm.Show();
            //lblSeccion.Text = childForm.Text;

        }

        private void ModificaColor(string colorCombo)
        {           
            string line = null, comparacion = "";
            //var arrayNombreArchivo = nombreArchivo.Split('-');   
            List<String> listLineas = new List<string>();
            string dataTxt = "";
            using (StreamReader file = new StreamReader(@"C:\ConfigTool\Config.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains("Tema"))
                    {
                        comparacion = line;
                        line = "Tema=" + colorCombo;
                    }
                    listLineas.Add(line);
                }
                for (int t = 0; t < listLineas.ToArray().Length; t++)//Envio 1x1 de documentos ubicados en ruta TXTUbicacion
                {
                    dataTxt += listLineas.ToArray()[t] + Environment.NewLine;
                }
                //if (File.Exists(rutaSalida + nombreArchivo + "-Test" + ".txt"))
                //{
                //    File.Delete(rutaSalida + nombreArchivo + "-Test" + ".txt");
                //}
            }
            if(comparacion != "Tema=" + colorCombo)
            {
                System.IO.File.WriteAllText(@"C:\ConfigTool\Config.txt", dataTxt);
                //DialogResult result;
                //result = MessageBox.Show("Los cambios se harán notables al reiniciar el programa. ¿Desea reiniciarlo ahora?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (result == DialogResult.Yes)
                //    Application.Restart();
            }
          
        }

        private void btnDescargas_Click(object sender, EventArgs e)
        {
            ActivateButton2(sender);
            FrmDescargas childForm = new FrmDescargas(Color1, Color2, Color3, Color4);
            if (FormHijoActual != null)
            {
                FormHijoActual.Close();
            }
            FormHijoActual = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlForm.Controls.Add(childForm);
            pnlForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblSeccion.Text = childForm.Text;
        }

        private void btnSetPruebas_Click(object sender, EventArgs e)
        {
            ActivateButton2(sender);
        }

        private void btnEjemplos_Click(object sender, EventArgs e)
        {
            ActivateButton2(sender);
            FrmEjemplos childForm = new FrmEjemplos(Color1, Color2, Color3, Color4);
            if (FormHijoActual != null)
            {
                FormHijoActual.Close();
            }
            FormHijoActual = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlForm.Controls.Add(childForm);
            pnlForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblSeccion.Text = childForm.Text;
        }

        private void btnOtros_Click(object sender, EventArgs e)
        {
            ActivateButton2(sender);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color1);

            FrmEmision childForm = new FrmEmision(Color1, Color2, Color3, Color4);
            if (FormHijoActual != null)
            {
                FormHijoActual.Close();
            }
            FormHijoActual = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlForm.Controls.Add(childForm);
            pnlForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblSeccion.Text = childForm.Text;

        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            ////string userName = Environment.UserName;
            ////MessageBox.Show(userName);
            //ActivateButton(sender, Color1);
            //ActivateButton2(sender);
            //TestColor childForm = new TestColor();
            //if (FormHijoActual != null)
            //{
            //    FormHijoActual.Close();
            //}
            //FormHijoActual = childForm;
            ////End
            //childForm.TopLevel = false;
            //childForm.FormBorderStyle = FormBorderStyle.None;
            //childForm.Dock = DockStyle.Fill;
            //pnlForm.Controls.Add(childForm);
            //pnlForm.Tag = childForm;
            //childForm.BringToFront();
            //childForm.Show();
            //lblSeccion.Text = childForm.Text;
        }

        private void pnlTop2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void leerConfigPersonal()
        {
            try
            {
                string FileToRead = @"C:\ConfigTool\Config.txt";
                if (System.IO.File.Exists(FileToRead))
                {
                    string[] lines = System.IO.File.ReadAllLines(FileToRead);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (!lines[i].StartsWith("<") && !lines[i].Equals(""))
                        {
                            string lineaYa = lines[i];
                            string clave = lines[i].Split('=')[0];
                            string valor = lines[i].Split('=')[1];
                            if (clave == "Tema")
                            {
                                color = valor;
                            }                           
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor crea tu archivo de configuracion en: " + FileToRead);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void Index_Load(object sender, EventArgs e)
        {
            leerConfigPersonal();
            InicializarColores(color);
            cmbTema.Text = color;
            RevisarMensajes();
        }

        private void RevisarMensajes()
        {
            Conexion2 conex2 = new Conexion2();
            int msj = conex2.getAllAnunciosSinLeer();
            if (msj > 0)
            {
                lblAnuncio.Font = new System.Drawing.Font(lblAnuncio.Font, FontStyle.Bold);
                lblAnuncio.Text = "Nuevos mensajes (" + msj + ") Click aca para revisarlo(s)!";
            }
            else
            {
                lblAnuncio.Font = new System.Drawing.Font(lblAnuncio.Font, FontStyle.Regular);
                lblAnuncio.Text = "Sin mensajes nuevos.";
            }
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;               
                currentBtn.TextAlign = ContentAlignment.MiddleRight;            
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.IconSize = 25;              
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();              
            }
        }

        private void btnPSE_Click(object sender, EventArgs e)
        {
            ActivateButton2(sender);
            FrmConfigPSE frm_u = new FrmConfigPSE();
            FrmConfigPSE.ColorBotones = Color3;
            FrmConfigPSE.ColorLetras = Color1;
            FrmConfigPSE.ColorTXT = Color2;


            //btnNombreFormulario.Text = frm_u.Text;
            //frm_u.Show();
            DialogResult res = frm_u.ShowDialog();
            if (res == DialogResult.OK)
            {

            }
        }

        private void btnConfigOtros_Click(object sender, EventArgs e)
        {
            ActivateButton2(sender);
            FrmConfigOtros frm_u = new FrmConfigOtros();
            FrmConfigOtros.ColorBotones = Color3;
            FrmConfigOtros.ColorLetras = Color1;
            FrmConfigOtros.ColorTXT = Color2;

            //btnNombreFormulario.Text = frm_u.Text;
            //frm_u.Show();
            DialogResult res = frm_u.ShowDialog();
            if (res == DialogResult.OK)
            {

            }
        }

        private void btnBD_Click(object sender, EventArgs e)
        {
            ActivateButton2(sender);
            //AbrirFormHijo(new FrmVentas());
            FrmConsultasBD childForm = new FrmConsultasBD(Color1, Color2, Color3, Color4, listPSE, listOSE);
            if (FormHijoActual != null)
            {
                FormHijoActual.Close();
            }
            FormHijoActual = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlForm.Controls.Add(childForm);
            pnlForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblSeccion.Text = childForm.Text;
            //FrmVentas.GlobalTest = "YA";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

        }

        private void btnSunat_Click(object sender, EventArgs e)
        {
            ActivateButton2(sender);
            //AbrirFormHijo(new FrmVentas());
            FrmConsultaSunat childForm = new FrmConsultaSunat(Color1, Color2, Color3, Color4);
            if (FormHijoActual != null)
            {
                FormHijoActual.Close();
            }
            FormHijoActual = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlForm.Controls.Add(childForm);
            pnlForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblSeccion.Text = childForm.Text;
            //FrmVentas.GlobalTest = "YA";
        }

        private void lblSeccion_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void lblAnuncio_Click(object sender, EventArgs e)
        {
            //ActivateButton2(sender);
            Anuncios childForm = new Anuncios(Color1, Color2, Color3, Color4);
            //FrmConfigBD.ColorBotones = Color3;
            //FrmConfigBD.ColorLetras = Color1;
            //FrmConfigBD.ColorTXT = Color2;
            ////btnNombreFormulario.Text = frm_u.Text;
            ////frm_u.Show();
            DialogResult res = childForm.ShowDialog();
            if (res == DialogResult.OK)
            {
                RevisarMensajes();           
            }
        }

        private void iconButton18_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnEmpresas_Click(object sender, EventArgs e)
        {
            ActivateButton2(sender);
            //AbrirFormHijo(new FrmVentas());
            FrmEmpresas childForm = new FrmEmpresas(Color1, Color2, Color3, Color4, listPSE, listOSE);
            if (FormHijoActual != null)
            {
                FormHijoActual.Close();
            }
            FormHijoActual = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlForm.Controls.Add(childForm);
            pnlForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblSeccion.Text = childForm.Text;
            //FrmVentas.GlobalTest = "YA";
        }

        private void btnZip_Click(object sender, EventArgs e)
        {
            ActivateButton2(sender);
            FrmZip childForm = new FrmZip(Color1, Color2, Color3, Color4);
            if (FormHijoActual != null)
            {
                FormHijoActual.Close();
            }
            FormHijoActual = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlForm.Controls.Add(childForm);
            pnlForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblSeccion.Text = childForm.Text;
        }

        private void btnServicio_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Próximamente...!");
            ActivateButton2(sender);
            FrmServicio childForm = new FrmServicio(Color1, Color2, Color3, Color4);
            if (FormHijoActual != null)
            {
                FormHijoActual.Close();
            }
            FormHijoActual = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlForm.Controls.Add(childForm);
            pnlForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblSeccion.Text = childForm.Text;
        }

        private void btnJson_Click(object sender, EventArgs e)
        {
            ActivateButton2(sender);
            FrmJson childForm = new FrmJson(Color1, Color2, Color3, Color4);
            if (FormHijoActual != null)
            {
                FormHijoActual.Close();
            }
            FormHijoActual = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlForm.Controls.Add(childForm);
            pnlForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblSeccion.Text = childForm.Text;
        }

        private void btnFirma_Click(object sender, EventArgs e)
        {

            ActivateButton2(sender);
            FrmFirmaXml childForm = new FrmFirmaXml(Color1, Color2, Color3, Color4);
            if (FormHijoActual != null)
            {
                FormHijoActual.Close();
            }
            FormHijoActual = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlForm.Controls.Add(childForm);
            pnlForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblSeccion.Text = childForm.Text;
        }

        private void btnIntegridad_Click(object sender, EventArgs e)
        {
            ActivateButton2(sender);
            FrmIntegridad childForm = new FrmIntegridad(Color1, Color2, Color3, Color4);
            if (FormHijoActual != null)
            {
                FormHijoActual.Close();
            }
            FormHijoActual = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlForm.Controls.Add(childForm);
            pnlForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblSeccion.Text = childForm.Text;
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {              
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconSize = 15;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                pnlEmision.Visible = false;
                pnlConfiguracion.Visible = false;
                pnlConsultas.Visible = false;
            }
        }

        private void ActivateButton2(object senderBtn)
        {
            if (senderBtn != null)
            {
                DisableButton2();
                currentBtn2 = (IconButton)senderBtn;              
                currentBtn2.TextAlign = ContentAlignment.MiddleCenter;
            }
        }

        private void DisableButton2()
        {
            if (currentBtn2 != null)
            {
                currentBtn2.TextAlign = ContentAlignment.MiddleLeft;             
            }
        }
    }
}
