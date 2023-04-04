using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools
{
    public partial class FrmConfigPSE : Form
    {
        static public Color ColorBotones;
        static public Color ColorFondo;
        static public Color ColorTXT;
        static public Color ColorLetras;
        public FrmConfigPSE()
        {
            InitializeComponent();
        }

        private void InicializarColores()
        {
            //tlpForm.BackColor = ColorFondo;
            btnGuardar.BackColor = ColorBotones;
            gbDemo.ForeColor = ColorLetras;
            gbPRD.ForeColor = ColorLetras;

            foreach (Control cComponente in tlpDEMO.Controls)
            {
                if (cComponente is TextBox)
                {
                    cComponente.BackColor = ColorTXT;
                }
            }
            foreach (Control cComponente in tlpPRD.Controls)
            {
                if (cComponente is TextBox)
                {
                    cComponente.BackColor = ColorTXT;
                }
            }        
        }

        private void FrmConfigPSE_Load(object sender, EventArgs e)
        {
            InicializarColores();
            LeerConfig();
        }

        private void LeerConfig()
        {
            try
            {          
                string usuarioConfig = ConfigurationManager.AppSettings["Usuario"];
                string claveConfig = ConfigurationManager.AppSettings["Clave"];
                string rucConfig = ConfigurationManager.AppSettings["Ruc"];
                txt_RucConfig.Text = rucConfig;
                txt_UserConfig.Text = usuarioConfig;
                txt_ClaveConfig.Text = claveConfig;

                string usuarioConfigPRD = ConfigurationManager.AppSettings["UsuarioPRD"];
                string claveConfigPRD = ConfigurationManager.AppSettings["ClavePRD"];
                string rucConfigPRD = ConfigurationManager.AppSettings["RucPRD"];
                txt_RucConfigPRD.Text = rucConfigPRD;
                txt_UserConfigPRD.Text = usuarioConfigPRD;
                txt_ClaveConfigPRD.Text = claveConfigPRD;          


                string factDemo = ConfigurationManager.AppSettings["FactDemo"];
                string bolDemo = ConfigurationManager.AppSettings["BolDemo"];
                string NcDemo = ConfigurationManager.AppSettings["NCDemo"];
                string NdDemo = ConfigurationManager.AppSettings["NDDemo"];
                string GuiaDemo = ConfigurationManager.AppSettings["GuiaDemo"];
                string DaeDemo = ConfigurationManager.AppSettings["DaeDemo"];
                string RetDemo = ConfigurationManager.AppSettings["RetDemo"];
                string PerDemo = ConfigurationManager.AppSettings["PercDemo"];
                txt_DemoFact.Text = factDemo;
                txt_DemoBol.Text = bolDemo;
                txt_DemoNc.Text = NcDemo;
                txt_DemoNd.Text = NdDemo;
                txt_DemoGuia.Text = GuiaDemo;
                txt_DemoDae.Text = DaeDemo;
                txt_DemoRet.Text = RetDemo;
                txt_DemoPerc.Text = PerDemo;

                string factPrd = ConfigurationManager.AppSettings["FactPRD"];
                string bolPrd = ConfigurationManager.AppSettings["BolPRD"];
                string NcPrd = ConfigurationManager.AppSettings["NCPRD"];
                string NdPrd = ConfigurationManager.AppSettings["NDPRD"];
                string GuiaPrd = ConfigurationManager.AppSettings["GuiaPRD"];
                string DaePrd = ConfigurationManager.AppSettings["DaePRD"];
                string RetPrd = ConfigurationManager.AppSettings["RetPRD"];
                string PerPrd = ConfigurationManager.AppSettings["PercPRD"];
                txt_PrdFact.Text = factPrd;
                txt_PrdBol.Text = bolPrd;
                txt_PrdNc.Text = NcPrd;
                txt_PrdNd.Text = NdPrd;
                txt_PrdGuia.Text = GuiaPrd;
                txt_PrdDae.Text = DaePrd;
                txt_PrdRet.Text = RetPrd;
                txt_PrdPerc.Text = PerPrd;          

            }
            catch (Exception e)
            {

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //PSE DEMO
                config.AppSettings.Settings["Usuario"].Value = txt_UserConfig.Text;
                config.AppSettings.Settings["Ruc"].Value = txt_RucConfig.Text;
                config.AppSettings.Settings["Clave"].Value = txt_ClaveConfig.Text;

                config.AppSettings.Settings["FactDemo"].Value = txt_DemoFact.Text;
                config.AppSettings.Settings["BolDemo"].Value = txt_DemoBol.Text;
                config.AppSettings.Settings["NCDemo"].Value = txt_DemoNc.Text;
                config.AppSettings.Settings["NDDemo"].Value = txt_DemoNd.Text;
                config.AppSettings.Settings["GuiaDemo"].Value = txt_DemoGuia.Text;
                config.AppSettings.Settings["DaeDemo"].Value = txt_DemoDae.Text;
                config.AppSettings.Settings["RetDemo"].Value = txt_DemoRet.Text;
                config.AppSettings.Settings["PercDemo"].Value = txt_DemoPerc.Text;
                //PSE DEMO
                //PSE PRD
                config.AppSettings.Settings["UsuarioPRD"].Value = txt_UserConfigPRD.Text;
                config.AppSettings.Settings["RucPRD"].Value = txt_RucConfigPRD.Text;
                config.AppSettings.Settings["ClavePRD"].Value = txt_ClaveConfigPRD.Text;

                config.AppSettings.Settings["FactPRD"].Value = txt_PrdFact.Text;
                config.AppSettings.Settings["BolPRD"].Value = txt_PrdBol.Text;
                config.AppSettings.Settings["NCPRD"].Value = txt_PrdNc.Text;
                config.AppSettings.Settings["NDPRD"].Value = txt_PrdNd.Text;
                config.AppSettings.Settings["GuiaPRD"].Value = txt_PrdGuia.Text;
                config.AppSettings.Settings["DaePRD"].Value = txt_PrdDae.Text;
                config.AppSettings.Settings["RetPRD"].Value = txt_PrdRet.Text;
                config.AppSettings.Settings["PercPRD"].Value = txt_PrdPerc.Text;
                //PSE PRD             

                config.Save(ConfigurationSaveMode.Modified);
                MessageBox.Show("Actualizacion Exitosa!");
                LeerConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.ToString());
            }
            //CargaParametros();
            DialogResult result;
            result = MessageBox.Show("Los cambios se harán notables al reiniciar el programa. ¿Desea reiniciarlo ahora?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Restart();
        }
    }
}
