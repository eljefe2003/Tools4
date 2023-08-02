using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.PSE21;

namespace Tools
{
    public class ReconstruirRequest
    {
        public void ObtenerRequest(string ruta, string rutaSave)
        {
            string cabecera = "", final = "";
            cabecera = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:tem=\"http://tempuri.org/\" xmlns:per=\"http://schemas.datacontract.org/2004/07/PeruService.Classes\">" + Environment.NewLine +
             "<soapenv:Header />" + Environment.NewLine +
              "<soapenv:Body >" + Environment.NewLine +
              "<tem:Enviar >" + Environment.NewLine +
              "<tem:ruc >?</tem:ruc >" + Environment.NewLine +
              "<tem:usuario >?</tem:usuario >" + Environment.NewLine +
              "<tem:clave >?</tem:clave >" + Environment.NewLine;

            final = "</tem:Enviar>" + Environment.NewLine +
            "</soapenv:Body >" + Environment.NewLine +
            "</soapenv:Envelope >";


            var arrayRequestLines = LeerRequest(ruta);
            for (int i = 0; i < arrayRequestLines.Length; i++)
            {
                string LineaActual = arrayRequestLines[i].ToString();

                string variable1 = "d2p1:nil=\"true\" xmlns:d2p1=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://schemas.datacontract.org/2004/07/PeruService.Classes\"";
                if ((LineaActual.IndexOf(variable1) > 0))
                {
                    string valorAnterior = arrayRequestLines[i];
                    arrayRequestLines[i] = valorAnterior.Replace(variable1, "");
                }

                string variable2 = "xmlns=\"http://schemas.datacontract.org/2004/07/PeruService.Classes\"";
                if ((LineaActual.IndexOf(variable2) > 0))
                {
                    string valorAnterior = arrayRequestLines[i];
                    arrayRequestLines[i] = valorAnterior.Replace(variable2, "");
                }

                string variable3 = "d4p1:nil=\"true\" xmlns:d4p1=\"http://www.w3.org/2001/XMLSchema-instance\"";
                if ((LineaActual.IndexOf(variable3) > 0))
                {
                    string valorAnterior = arrayRequestLines[i];
                    arrayRequestLines[i] = valorAnterior.Replace(variable3, "");
                }

                string variable4 = "d3p1:nil=\"true\" xmlns:d3p1=\"http://www.w3.org/2001/XMLSchema-instance\"";
                if ((LineaActual.IndexOf(variable4) > 0))
                {
                    string valorAnterior = arrayRequestLines[i];
                    arrayRequestLines[i] = valorAnterior.Replace(variable4, "");
                }
                string valorAnterior2 = arrayRequestLines[i];
                arrayRequestLines[i] = valorAnterior2.Replace("</", "##");

                string valorAnterior1 = arrayRequestLines[i];
                arrayRequestLines[i] = valorAnterior1.Replace("<", "<per:");

                string valorAnterior3 = arrayRequestLines[i];
                arrayRequestLines[i] = valorAnterior3.Replace("##", "</per:");


                string variable5 = "/>";
                if ((LineaActual.IndexOf(variable5) > 0))
                {
                    arrayRequestLines[i] = "";
                }

                //string variable6 = "<";
                //if ((LineaActual.IndexOf(variable5) > 1))
                //{
                //    string valorAnterior = arrayRequestLines[i];
                //    arrayRequestLines[i] = valorAnterior.Replace(variable6, "<per:");
                //}


            }

            string line, requestModificado = "";
            for (int i = 0; i < arrayRequestLines.Length; i++)
            {
                if (arrayRequestLines[i] != "")
                {
                    requestModificado += arrayRequestLines[i] + Environment.NewLine;
                }
            }

            //string requestOriginal = LeerRequestString(ruta);
            //string requestModificado = requestOriginal.Replace("<?xml version=\"1.0\"?>", "Test uno sdsdsd");
            //requestModificado = requestModificado.Replace("DocumentoElectronico", "documentoElectronico");
            ////requestModificado = requestModificado.Replace("d2p1:nil=\"true\" xmlns:d2p1=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://schemas.datacontract.org/2004/07/PeruService.Classes\"", "");
            //requestModificado = requestModificado.Replace("d2p1:nil=\"true\"", "");
            //requestModificado = requestModificado.Replace("xmlns=\"http://schemas.datacontract.org/2004/07/PeruService.Classes\"", "");
            //requestModificado = requestModificado.Replace("d4p1:nil=\"true\" xmlns:d4p1=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
            //requestModificado = requestModificado.Replace("d3p1:nil=\"true\" xmlns:d3p1=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
            string Request = requestModificado;
            requestModificado = Request.Replace("<per:?xml version=\"1.0\"?>", "");
            requestModificado = requestModificado.Replace("per:DocumentoElectronico", "tem:documentoElectronico");
            requestModificado = requestModificado.Replace("per:DocumentoElectronico", "tem:documentoElectronico");

            System.IO.File.WriteAllText(rutaSave, cabecera + requestModificado + final);
        }

        public void ObtenerRequestGR(string ruta, string rutaSave)
        {
            string cabecera = "", final = "";
            cabecera = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:tem=\"http://tempuri.org/\" xmlns:per=\"http://schemas.datacontract.org/2004/07/PeruService.Classes\">" + Environment.NewLine +
             "<soapenv:Header />" + Environment.NewLine +
              "<soapenv:Body >" + Environment.NewLine +
              "<tem:GuiasRemision >" + Environment.NewLine +
              "<tem:ruc >?</tem:ruc >" + Environment.NewLine +
              "<tem:usuario >?</tem:usuario >" + Environment.NewLine +
              "<tem:clave >?</tem:clave >" + Environment.NewLine;

            final = "</tem:GuiasRemision>" + Environment.NewLine +
            "</soapenv:Body >" + Environment.NewLine +
            "</soapenv:Envelope >";


            var arrayRequestLines = LeerRequest(ruta);
            for (int i = 0; i < arrayRequestLines.Length; i++)
            {
                string LineaActual = arrayRequestLines[i].ToString();

                string variable1 = "d2p1:nil=\"true\" xmlns:d2p1=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://schemas.datacontract.org/2004/07/PeruService.Classes\"";
                if ((LineaActual.IndexOf(variable1) > 0))
                {
                    string valorAnterior = arrayRequestLines[i];
                    arrayRequestLines[i] = valorAnterior.Replace(variable1, "");
                }

                string variable2 = "xmlns=\"http://schemas.datacontract.org/2004/07/PeruService.Classes\"";
                if ((LineaActual.IndexOf(variable2) > 0))
                {
                    string valorAnterior = arrayRequestLines[i];
                    arrayRequestLines[i] = valorAnterior.Replace(variable2, "");
                }

                string variable3 = "d4p1:nil=\"true\" xmlns:d4p1=\"http://www.w3.org/2001/XMLSchema-instance\"";
                if ((LineaActual.IndexOf(variable3) > 0))
                {
                    string valorAnterior = arrayRequestLines[i];
                    arrayRequestLines[i] = valorAnterior.Replace(variable3, "");
                }

                string variable4 = "d3p1:nil=\"true\" xmlns:d3p1=\"http://www.w3.org/2001/XMLSchema-instance\"";
                if ((LineaActual.IndexOf(variable4) > 0))
                {
                    string valorAnterior = arrayRequestLines[i];
                    arrayRequestLines[i] = valorAnterior.Replace(variable4, "");
                }
                string valorAnterior2 = arrayRequestLines[i];
                arrayRequestLines[i] = valorAnterior2.Replace("</", "##");

                string valorAnterior1 = arrayRequestLines[i];
                arrayRequestLines[i] = valorAnterior1.Replace("<", "<per:");

                string valorAnterior3 = arrayRequestLines[i];
                arrayRequestLines[i] = valorAnterior3.Replace("##", "</per:");


                string variable5 = "/>";
                if ((LineaActual.IndexOf(variable5) > 0))
                {
                    arrayRequestLines[i] = "";
                }

                //string variable6 = "<";
                //if ((LineaActual.IndexOf(variable5) > 1))
                //{
                //    string valorAnterior = arrayRequestLines[i];
                //    arrayRequestLines[i] = valorAnterior.Replace(variable6, "<per:");
                //}


            }

            string line, requestModificado = "";
            for (int i = 0; i < arrayRequestLines.Length; i++)
            {
                if (arrayRequestLines[i] != "")
                {
                    requestModificado += arrayRequestLines[i] + Environment.NewLine;
                }
            }

            //string requestOriginal = LeerRequestString(ruta);
            //string requestModificado = requestOriginal.Replace("<?xml version=\"1.0\"?>", "Test uno sdsdsd");
            //requestModificado = requestModificado.Replace("DocumentoElectronico", "documentoElectronico");
            ////requestModificado = requestModificado.Replace("d2p1:nil=\"true\" xmlns:d2p1=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://schemas.datacontract.org/2004/07/PeruService.Classes\"", "");
            //requestModificado = requestModificado.Replace("d2p1:nil=\"true\"", "");
            //requestModificado = requestModificado.Replace("xmlns=\"http://schemas.datacontract.org/2004/07/PeruService.Classes\"", "");
            //requestModificado = requestModificado.Replace("d4p1:nil=\"true\" xmlns:d4p1=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
            //requestModificado = requestModificado.Replace("d3p1:nil=\"true\" xmlns:d3p1=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
            string Request = requestModificado;
            requestModificado = Request.Replace("<per:?xml version=\"1.0\"?>", "");
            requestModificado = requestModificado.Replace("per:GuiaRemision", "tem:documentoElectronico");
            //requestModificado = requestModificado.Replace("per:DocumentoElectronico", "tem:documentoElectronico");

            System.IO.File.WriteAllText(rutaSave, cabecera + requestModificado + final);
        }

        public string[] LeerRequest(string ruta)
        {
            string line;
            List<String> ret = new List<string>();
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(ruta);
            while ((line = file.ReadLine()) != null)
            {
                //System.Console.WriteLine(line);
                ret.Add(line);
            }
            file.Close();
            return ret.ToArray();
        }
    }
}
