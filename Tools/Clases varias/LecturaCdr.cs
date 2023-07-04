using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Tools.PSE21;

namespace Tools
{
    public class LecturaCdr
    {
        public string[] LeerCDR(string path)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode nodoResponse = doc.DocumentElement.LastChild;
                string respuestaSunatCodigo = "";
                string respuestaSunatDesc = "";
                string respuestaSunatObs = "SIN OBS.";
                List<string> respuestaObsList = new List<string>();

                foreach (XmlNode node in nodoResponse.ChildNodes)
                {
                    if (node.Name == "cac:Response")
                    {
                        var nodosHijos = node;
                        foreach (XmlNode node2 in nodosHijos.ChildNodes)
                        {
                            if (node2.Name == "cbc:ResponseCode")
                            {
                                respuestaSunatCodigo = node2.FirstChild.Value;
                            }
                            else if (node2.Name == "cbc:Description")
                            {
                                respuestaSunatDesc = node2.FirstChild.Value;
                            }
                            else if (node2.Name == "cac:Status")
                            {
                                respuestaSunatObs = " CON OBS.";

                                if (respuestaObsList.Count == 0)
                                    respuestaObsList.Add(respuestaSunatCodigo + "|" + respuestaSunatDesc + "|" + respuestaSunatObs); string texto = "";

                                texto += node2.FirstChild.InnerText;
                                texto += " - " + node2.LastChild.InnerText;
                                respuestaObsList.Add(texto);
                            }

                            //XmlNodeList nodoResponse3 = doc.GetElementsByTagName("cac:Status");
                            //if (nodoResponse3.Count != 0)
                            //{
                            //    respuestaSunatObs = " CON OBS.";
                            //    respuestaObsList.Add(respuestaSunatCodigo + "|" + respuestaSunatDesc + "|" + respuestaSunatObs);
                            //    foreach (XmlNode node33 in nodoResponse3)
                            //    {
                            //        string texto = "";
                            //        texto += node33.FirstChild.InnerText;
                            //        texto += " - " + node33.LastChild.InnerText;
                            //        respuestaObsList.Add(texto);
                            //    }
                            //}
                            //else
                            //{
                            //    respuestaObsList.Add(respuestaSunatCodigo + "|" + respuestaSunatDesc + "|" + respuestaSunatObs);
                            //}
                        }
                        //if (nodosHijos.LastChild.Name == "cac:Status")
                        //{
                        //    respuestaSunatObs = "CON OBS.";
                        //}
                    }
                }
                //XmlNodeList nodoResponse44 = doc.GetElementsByTagName("cac:Status");
                //    respuestaObsList.Add(respuestaSunatCodigo + "|" + respuestaSunatDesc + "|" + respuestaSunatObs);

                XmlNodeList nodoResponse2 = doc.GetElementsByTagName("cbc:Note");                
                if (nodoResponse2.Count != 0)
                {
                    respuestaSunatObs = " CON OBS.";
                    respuestaObsList.Add(respuestaSunatCodigo + "|" + respuestaSunatDesc + "|" + respuestaSunatObs);
                    foreach (XmlNode node in nodoResponse2)
                    {
                        if (node.Name == "cbc:Note")
                        {
                            respuestaObsList.Add(node.InnerText);
                        }
                    }
                }
                else
                {
                    if(respuestaObsList.Count == 0)
                        respuestaObsList.Add(respuestaSunatCodigo + "|" + respuestaSunatDesc + "|" + respuestaSunatObs);
                }

                return respuestaObsList.ToArray();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
