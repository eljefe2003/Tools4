using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Tools
{
    public class LeerConfig
    {
        String serieRet, seriePer, serieBol, serieFact, serieNC, serieND, serieGuia, serieDae, tipoNota, ruc, userRuc, passRuc;
        String ruc2, userRuc2, passRuc2;
        String urlSunatDemo, usuarioSunatDemo, claveSunatDemo, urlSunatPrd, usuarioSunatPrd, claveSunatPrd, rucSunatDemo, rucSunatPrd;
        String urlOSEDemo, usuarioOSEDemo, claveOSEDemo, urlOSEPrd, usuarioOSEPrd, claveOSEPrd, rucOSEDemo, rucOSEPrd;
        String rutaCertificado, claveCertificado;
        public LeerConfig()
        {
            Leer();
        }

        public string SerieRet { get => serieRet; set => serieRet = value; }
        public string SeriePer { get => seriePer; set => seriePer = value; }
        public string SerieBol { get => serieBol; set => serieBol = value; }
        public string SerieFact { get => serieFact; set => serieFact = value; }
        public string SerieNC { get => serieNC; set => serieNC = value; }
        public string SerieND { get => serieND; set => serieND = value; }
        public string SerieGuia { get => serieGuia; set => serieGuia = value; }
        public string SerieDae { get => serieDae; set => serieDae = value; }
        public string TipoNota { get => tipoNota; set => tipoNota = value; }
        public string Ruc { get => ruc; set => ruc = value; }
        public string UserRuc { get => userRuc; set => userRuc = value; }
        public string PassRuc { get => passRuc; set => passRuc = value; }
        public string Ruc2 { get => ruc2; set => ruc2 = value; }
        public string UserRuc2 { get => userRuc2; set => userRuc2 = value; }
        public string PassRuc2 { get => passRuc2; set => passRuc2 = value; }
        public string UrlSunatDemo { get => urlSunatDemo; set => urlSunatDemo = value; }
        public string UsuarioSunatDemo { get => usuarioSunatDemo; set => usuarioSunatDemo = value; }
        public string ClaveSunatDemo { get => claveSunatDemo; set => claveSunatDemo = value; }
        public string UrlSunatPrd { get => urlSunatPrd; set => urlSunatPrd = value; }
        public string UsuarioSunatPrd { get => usuarioSunatPrd; set => usuarioSunatPrd = value; }
        public string ClaveSunatPrd { get => claveSunatPrd; set => claveSunatPrd = value; }
        public string RucSunatDemo { get => rucSunatDemo; set => rucSunatDemo = value; }
        public string RucSunatPrd { get => rucSunatPrd; set => rucSunatPrd = value; }
        public string UrlOSEDemo { get => urlOSEDemo; set => urlOSEDemo = value; }
        public string UsuarioOSEDemo { get => usuarioOSEDemo; set => usuarioOSEDemo = value; }
        public string ClaveOSEDemo { get => claveOSEDemo; set => claveOSEDemo = value; }
        public string UrlOSEPrd { get => urlOSEPrd; set => urlOSEPrd = value; }
        public string UsuarioOSEPrd { get => usuarioOSEPrd; set => usuarioOSEPrd = value; }
        public string ClaveOSEPrd { get => claveOSEPrd; set => claveOSEPrd = value; }
        public string RucOSEDemo { get => rucOSEDemo; set => rucOSEDemo = value; }
        public string RucOSEPrd { get => rucOSEPrd; set => rucOSEPrd = value; }
        public string RutaCertificado { get => rutaCertificado; set => rutaCertificado = value; }
        public string ClaveCertificado { get => claveCertificado; set => claveCertificado = value; }

        private void Leer()
        {
            try
            {
                Ruc = ConfigurationManager.AppSettings["Ruc"];
                UserRuc = ConfigurationManager.AppSettings["Usuario"];
                string ambiente = LeerDll();
                if (ambiente == "DEMO")
                {
                    SerieFact = ConfigurationManager.AppSettings["FactDemo"];
                    SerieBol = ConfigurationManager.AppSettings["BolDemo"];
                    SerieNC = ConfigurationManager.AppSettings["NCDemo"];
                    SerieND = ConfigurationManager.AppSettings["NDDemo"];
                    SerieGuia = ConfigurationManager.AppSettings["GuiaDemo"];
                    SerieDae = ConfigurationManager.AppSettings["DaeDemo"];
                    SerieRet = ConfigurationManager.AppSettings["RetDemo"];
                    SeriePer = ConfigurationManager.AppSettings["PercDemo"];
                    Ruc = ConfigurationManager.AppSettings["Ruc"];
                    UserRuc = ConfigurationManager.AppSettings["Usuario"];
                    PassRuc = ConfigurationManager.AppSettings["Clave"];
                    Ruc2 = ConfigurationManager.AppSettings["Ruc2"];
                    UserRuc2 = ConfigurationManager.AppSettings["Usuario2"];
                    PassRuc2 = ConfigurationManager.AppSettings["Clave2"];
                    
                    //ambienteDemo = true;
                }
                else
                {
                    SerieFact = ConfigurationManager.AppSettings["FactPRD"];
                    SerieBol = ConfigurationManager.AppSettings["BolPRD"];
                    SerieNC = ConfigurationManager.AppSettings["NCPRD"];
                    SerieND = ConfigurationManager.AppSettings["NDPRD"];
                    SerieGuia = ConfigurationManager.AppSettings["GuiaPRD"];
                    SerieDae = ConfigurationManager.AppSettings["DaePRD"];
                    SerieRet = ConfigurationManager.AppSettings["RetPRD"];
                    SeriePer = ConfigurationManager.AppSettings["PercPRD"];
                    PassRuc = ConfigurationManager.AppSettings["Clave"];
                    Ruc = ConfigurationManager.AppSettings["RucPRD"];
                    UserRuc = ConfigurationManager.AppSettings["UsuarioPRD"];
                    PassRuc = ConfigurationManager.AppSettings["ClavePRD"];
                    Ruc2 = ConfigurationManager.AppSettings["RucPRD2"];
                    UserRuc2 = ConfigurationManager.AppSettings["UsuarioPRD2"];
                    PassRuc2 = ConfigurationManager.AppSettings["ClavePRD2"];                   
                    //ambienteDemo = false;
                }
                UrlSunatDemo = ConfigurationManager.AppSettings["UrlSunatDemo"];
                UsuarioSunatDemo = ConfigurationManager.AppSettings["UsuarioSunatDemo"];
                ClaveSunatDemo = ConfigurationManager.AppSettings["ClaveSunatDemo"];
                RucSunatDemo = ConfigurationManager.AppSettings["RucSunatDemo"];
                UrlSunatPrd = ConfigurationManager.AppSettings["UrlSunatPrd"];
                UsuarioSunatPrd = ConfigurationManager.AppSettings["UsuarioSunatPrd"];
                ClaveSunatPrd = ConfigurationManager.AppSettings["ClaveSunatPrd"];
                RucSunatPrd = ConfigurationManager.AppSettings["RucSunatPrd"];

                UrlOSEDemo = ConfigurationManager.AppSettings["UrlOseDemo"];
                UsuarioOSEDemo = ConfigurationManager.AppSettings["UsuarioOseDemo"];
                ClaveOSEDemo = ConfigurationManager.AppSettings["ClaveOseDemo"];
                RucOSEDemo = ConfigurationManager.AppSettings["RucOseDemo"];
                UrlOSEPrd = ConfigurationManager.AppSettings["UrlOsePrd"];
                UsuarioOSEPrd = ConfigurationManager.AppSettings["UsuarioOsePrd"];
                ClaveOSEPrd = ConfigurationManager.AppSettings["ClaveOsePrd"];
                RucOSEPrd = ConfigurationManager.AppSettings["RucOsePrd"];
                RutaCertificado = ConfigurationManager.AppSettings["RutaCertificado"];
                ClaveCertificado = ConfigurationManager.AppSettings["ClaveCertificado"];

            }
            catch (Exception e)
            {

            }
        }
        
        private string LeerDll()
        {
            string Ambiente = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(".\\DLL_Online.dll.xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                String id = node.Attributes["service"].Value;
                if (id.IndexOf("demo") > 0)
                {
                    Ambiente = "DEMO";
                    //chckDemo.IsOn = true;
                }
                else
                {
                    Ambiente = "PRD";
                    //chckDemo.IsOn = false;
                }
            }
            return Ambiente;
        }
    }
}
