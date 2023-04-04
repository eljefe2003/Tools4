using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Tools
{
    internal class EnviaXmlOse
    {


        #region Variables

        Conexion conex = new Conexion();
        int envioOseDemo = Convert.ToInt32(ConfigurationManager.AppSettings["EnvioOseDemo"]);
        int envioOsePrd = Convert.ToInt32(ConfigurationManager.AppSettings["EnvioOsePrd"]);
        string urlOseDemo = ConfigurationManager.AppSettings["UrlOseDemo"];
        string usuarioOseDemo = ConfigurationManager.AppSettings["UsuarioOseDemo"];
        string claveOseDemo = ConfigurationManager.AppSettings["ClaveOseDemo"];
        string urlOsePrd = ConfigurationManager.AppSettings["UrlOsePrd"];
        string usuarioOsePrd = ConfigurationManager.AppSettings["UsuarioOsePrd"];
        string claveOsePrd = ConfigurationManager.AppSettings["ClaveOsePrd"];

        #endregion

        #region Metodos
        public (string url, string usuario, string clave) ObtieneDatosConfig()
        {
            string url1 = "";
            string usuario1 = "";
            string clave1 = "";
            if (envioOseDemo == 1)
            {
                url1 = urlOseDemo;
                usuario1 = usuarioOseDemo;
                clave1 = claveOseDemo;
            }
            else
            {
                url1 = urlOsePrd;
                usuario1 = usuarioOsePrd;
                clave1 = claveOsePrd;
            }
            return (url1, usuario1, clave1);
        }

        public OseBeta.billServiceClient ObjetoSunat(string url, string user, string pass)
        {
            System.Net.ServicePointManager.UseNagleAlgorithm = true;
            System.Net.ServicePointManager.Expect100Continue = false;
            System.Net.ServicePointManager.CheckCertificateRevocationList = true;
            var basicHttpBinding = new BasicHttpBinding(BasicHttpSecurityMode.TransportWithMessageCredential);
            basicHttpBinding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
            EndpointAddress endPointURL = new EndpointAddress(url);
            OseBeta.billServiceClient clientOSE = new OseBeta.billServiceClient(basicHttpBinding, endPointURL);
            //Credenciales en el Header
            clientOSE.ClientCredentials.UserName.UserName = user;
            clientOSE.ClientCredentials.UserName.Password = pass;
            var elements = clientOSE.Endpoint.Binding.CreateBindingElements();
            elements.Find<SecurityBindingElement>().EnableUnsecuredResponse = true;
            clientOSE.Endpoint.Binding = new CustomBinding(elements);
            clientOSE.Open();
            return clientOSE;
        }

        public (byte[] base64, bool aceptado, string mensaje) EnviaXml(string Path, string user, string clave, string url)
        {
            var objetoSunat = ObjetoSunat(url, user, clave);

            //string rutaXml = ConfigurationManager.AppSettings["RutaXML"];
            //string rutaCDR = ConfigurationManager.AppSettings["RutaCDR"];
            //string rutaRespuestas = ConfigurationManager.AppSettings["RutaRespuestas"];
            FileInfo fi = new FileInfo(Path);
            string Numeracion = fi.Name;
            try
            {
                if (Numeracion.Split('-')[1] != "RA" && Numeracion.Split('-')[1] != "RC")
                {
                    //string path = rutaXml + "\\Zip\\" + Numeracion + ".zip";
                    if (File.Exists(Path))
                    {
                        byte[] bytes = File.ReadAllBytes(Path);
                        var resp = objetoSunat.sendBill(Numeracion, bytes);
                        //string nombreCdr = rutaCDR + "R-" + Numeracion + ".zip";
                        //if (File.Exists(nombreCdr))
                        //{
                        //    File.Delete(nombreCdr);
                        //}
                        //File.WriteAllBytes(nombreCdr, resp);
                        //System.IO.File.WriteAllText(rutaRespuestas + Numeracion + ".txt", "0|Aceptado" + Environment.NewLine + "Fecha y Hora: " + DateTime.Now);
                        return (resp, true, "");
                    }
                    else
                    {
                        return (null, false, "");
                    }
                }
                else
                {
                    return (null, false, "");
                }
                //else
                //{
                //    ////string path = rutaXml + "\\Zip\\" + Numeracion + ".zip";
                //    //if (File.Exists(Path))
                //    //{
                //    //    byte[] bytes = File.ReadAllBytes(Path);
                //    //    var resp = objetoSunat.sendSummary(Numeracion + ".zip", bytes, "");
                //    //    Thread.Sleep(2000);
                //    //    var resp2 = objetoSunat.getStatus(resp);
                //    //    //string nombreCdr = rutaCDR + "R-" + Numeracion + ".zip";
                //    //    //if (File.Exists(nombreCdr))
                //    //    //{
                //    //    //    File.Delete(nombreCdr);
                //    //    //}
                //    //    //File.WriteAllBytes(nombreCdr, resp2.content);
                //    //    //System.IO.File.WriteAllText(rutaRespuestas + Numeracion + ".txt", "0|Aceptado" + Environment.NewLine + "Fecha y Hora: " + DateTime.Now);
                //    //    return (resp, true);
                //    //}
                //    //else
                //    //{
                //    //    return "Debes regenerar el XML.";
                //    //}

                //}
            }
            catch (FaultException e)
            {
                //System.IO.File.WriteAllText(rutaRespuestas + Numeracion + ".txt", "1|Rechazado: " + e.Message + Environment.NewLine + "Fecha y Hora: " + DateTime.Now);
                byte[] resp = null;
                return (resp, false, e.Message);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Parece que existe un problema con la conexion a interntet. El documento lo podras reenviar luego!");
                byte[] resp = null;
                return (resp, false, ex.Message);
            }
        }

        #endregion
    }
}
