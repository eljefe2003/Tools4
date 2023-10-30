using DLL_Online.Metodos;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tools
{
    class PruebaEjemplo
    {
        LeerConfigPersonal ConfigPerso = new LeerConfigPersonal();
        LeerConfig ConfigGlobal = new LeerConfig();
        DLL_Online.Metodos.Facturacion DllG1 = new DLL_Online.Metodos.Facturacion();

        public void EliminaProcesados()
        {
            List<string> strFiles = Directory.GetFiles(ConfigPerso.RutaEjemplosProcesados, "*", SearchOption.AllDirectories).ToList();
            foreach (string fichero in strFiles)
            {
                File.Delete(fichero);
            }
        }

        public (int Codigo, string Mensaje, string Documento) Enviar(string NombreArchivo, string rutaArchivoTxt)
        {
            //EliminaProcesados();
            string ArchivoAEnviar = rutaArchivoTxt;
            DLL_Online.Metodos.Dae_DinersClub DllG2 = new Dae_DinersClub();

            (int Codigo, string Mensaje, string Documento) resp = (0, "", "");
            string[] respDae = null;
            string Iniciales = "";

            if (NombreArchivo.StartsWith("DAE") || NombreArchivo.StartsWith("NCE"))
            {
                Iniciales = "DAE";
            }
            else
            {
                Iniciales = NombreArchivo.Split('-')[1];
            }

            switch (Iniciales)
            {
                case "RA":
                case "RC":
                    resp = (0, "", ""); // Asigna un valor válido a resp en este caso
                    break;

                case "09":
                case "31":
                    resp = (ArchivoAEnviar.Split('-')[0] == ".\\Procesados\\20550728762") ?
                        DllG1.EnviarGuiaRemision(ConfigGlobal.Ruc2, ConfigGlobal.UserRuc2, ConfigGlobal.PassRuc2, ArchivoAEnviar) :
                        DllG1.EnviarGuiaRemision(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, ArchivoAEnviar);
                    break;

                case "20":
                case "40":
                    resp = DllG1.EnviarPercepcionRetencion(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, ArchivoAEnviar);
                    break;

                case "42":
                    resp = DllG1.EnviarDaeg1(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, ArchivoAEnviar);
                    break;

                case "DAE":
                case "NCE":
                    List<string> lstArch = new List<string> { ArchivoAEnviar };
                    string[] arrayOfArch = lstArch.ToArray();
                    respDae = DllG2.EnviosDCH(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, arrayOfArch);
                    break;

                default:
                    resp = DllG1.Enviar(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, ArchivoAEnviar);
                    break;
            }

            if (Iniciales == "DAE")
            {
                if (respDae[0].Split('|')[0] == "0")
                {
                    resp.Codigo = Convert.ToInt32(respDae[0].Split('|')[0]);
                    resp.Mensaje = respDae[0].Split('|')[1];
                    resp.Documento = respDae[0].Split('|')[2];
                    //Log("Enviado: " + respDae[0].Split('|')[3] + " --> " + respDae[0].Split('|')[1] + " --> Doc real (" + respDae[0].Split('|')[2] + ")", true, false);
                    //aceptadoEdicionGlobal = true;
                    //nombreEjemplosGlobal = NombreArchivo;
                    //nombreRealEjemplosGlobal = resp.Documento;
                    //Task t1 = Task.Run(() => ProcesaIndividual(NombreArchivo.Split('_')[1] + "-" + respDae[0].Split('|')[2], e.RowIndex), token);
                }
                else
                {
                    resp.Codigo = Convert.ToInt32(respDae[0].Split('|')[0]);
                    resp.Mensaje = respDae[0].Split('|')[1];
                    resp.Documento = respDae[0].Split('|')[2];
                    //Log(respDae[0].Split('|')[3] + " --> " + respDae[0].Split('|')[1] + " --> Doc real (" + respDae[0].Split('|')[2] + ")", false, false);
                    //dtgEjemplos.Rows[e.RowIndex].Cells[2].Value = resp.Codigo + "|" + resp.Mensaje;
                    //dtgEjemplos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    //aceptadoEdicionGlobal = false;
                    //pruebaDocEjemploActivo = false;
                }
            }
            //else
            //{
            //    if (resp.Codigo == 0)
            //    {
            //        Log("Enviado: " + NombreArchivo + " --> " + resp.Mensaje + " --> Doc real (" + resp.Documento + ")", true, false);
            //        aceptadoEdicionGlobal = true;
            //        nombreEjemplosGlobal = NombreArchivo;
            //        nombreRealEjemplosGlobal = resp.Documento;
            //        Task t1 = Task.Run(() => ProcesaIndividual(resp.Documento.ToString(), e.RowIndex), token);
            //    }
            //    else
            //    {
            //        Log(NombreArchivo + " --> " + resp.Mensaje + " --> Doc real (" + resp.Documento + ")", false, false);
            //        dtgEjemplos.Rows[e.RowIndex].Cells[2].Value = resp.Codigo + "|" + resp.Mensaje;
            //        dtgEjemplos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
            //        aceptadoEdicionGlobal = false;
            //        pruebaDocEjemploActivo = false;
            //    }
            //}
            return resp;

        }

        private string obtieneFecha()
        {
            string año = DateTime.Now.Year.ToString();
            string mes1 = DateTime.Now.Month.ToString(), mes = "";
            string dia1 = DateTime.Now.Day.ToString(), dia = "";
            if (mes1.Length == 1)
            {
                mes = "0" + mes1;
            }
            else
            {
                mes = mes1;
            }

            if (dia1.Length == 1)
            {
                dia = "0" + dia1;
            }
            else
            {
                dia = dia1;
            }
            return año + "-" + mes + "-" + dia;
        }

        private string obtieneFechaMañana()
        {
            DateTime fecha = DateTime.Now.AddDays(1);
            string año = fecha.Year.ToString();
            string mes1 = fecha.Month.ToString(), mes = "";
            string dia1 = fecha.Day.ToString(), dia = "";
            if (mes1.Length == 1)
            {
                mes = "0" + mes1;
            }
            else
            {
                mes = mes1;
            }

            if (dia1.Length == 1)
            {
                dia = "0" + dia1;
            }
            else
            {
                dia = dia1;
            }
            return año + "-" + mes + "-" + dia;
        }

        public string CambiaContenidoTxt(string nombreArchivo, string rutaArchivo)
        {             
            string tipoTxt = "", tipoNota = "", primeraLetra = "", line = null, rutaSalida = ConfigPerso.RutaEjemplosProcesados, fecha = obtieneFecha();
            var arrayNombreArchivo = nombreArchivo.Split('-');             

            if (!nombreArchivo.Substring(0, 3).Equals("DAE"))
            {
                tipoTxt = nombreArchivo.Split('-')[1];
                primeraLetra = nombreArchivo.Split('-')[2].Substring(0, 1);
            }
            else
            {
                if (!nombreArchivo.Substring(0, 3).Equals("DAE"))
                {
                    tipoTxt = "NCE";
                }
                else
                {
                    tipoTxt = "DAE";
                }
            }

            //primeraLetra = nombreArchivo.Split('-')[2].Substring(0,1);
            Random rnd = new Random();
            int numeroConDosCotas = rnd.Next(1, 99999999);

            List<String> listLineas = new List<string>();
            using (StreamReader file = new StreamReader(rutaArchivo))
            {
                while ((line = file.ReadLine()) != null)
                {
                    string[] camposLine = line.Split('|');
                    if (tipoTxt.Equals("40") || tipoTxt.Equals("20"))
                    {
                        if (camposLine[0].Equals("03"))
                        {
                            string newLine = "";
                            string oldLine = line;
                            string[] arrayLine = oldLine.Split('|');
                            string tipoDoc = arrayLine[1].Split('-')[0];
                            if (tipoDoc.Equals("07") || tipoDoc.Equals("08"))
                            {
                                arrayLine[1] = tipoDoc + "-0001-1234";
                            }
                            else
                            {
                                arrayLine[1] = "01-0001-1234";
                            }
                            arrayLine[2] = fecha;
                            arrayLine[5] = fecha;
                            arrayLine[10] = fecha;


                            for (int t = 0; t < arrayLine.Length - 1; t++)//Envio 1x1 de documentos ubicados en ruta TXTUbicacion
                            {
                                newLine += arrayLine[t] + "|";
                            }
                            line = newLine;
                        }
                        if (camposLine[0].Equals("02"))
                        {
                            string newLine = "";
                            string oldLine = line;
                            string[] arrayLine = oldLine.Split('|');
                            arrayLine[1] = fecha;

                            if (tipoTxt.Equals("20"))
                            {
                                arrayLine[3] = ConfigGlobal.SerieRet + "-" + numeroConDosCotas;
                            }
                            else if (tipoTxt.Equals("40"))
                            {
                                arrayLine[3] = ConfigGlobal.SeriePer + "-" + numeroConDosCotas;
                            }

                            for (int t = 0; t < arrayLine.Length - 1; t++)//Envio 1x1 de documentos ubicados en ruta TXTUbicacion
                            {
                                newLine += arrayLine[t] + "|";
                            }

                            line = newLine;
                        }

                    }
                    else if (tipoTxt.Equals("09") || tipoTxt.Equals("31"))
                    {
                        if (camposLine[0].Equals("COM"))
                        {
                            string newLine = "";
                            string oldLine = line;
                            string[] arrayLine = oldLine.Split('|');
                            //string tipoDoc = arrayLine[1].Split('-')[0];
                            //if (tipoDoc.Equals("07") || tipoDoc.Equals("08"))
                            //{
                            //    arrayLine[1] = tipoDoc + "-0001-1234";
                            //}
                            //else
                            //{
                            //    arrayLine[1] = "01-0001-1234";
                            //}
                            arrayLine[3] = fecha + " 23:00:00";
                            arrayLine[2] = numeroConDosCotas.ToString();

                            for (int t = 0; t < arrayLine.Length - 1; t++)//Envio 1x1 de documentos ubicados en ruta TXTUbicacion
                            {
                                newLine += arrayLine[t] + "|";
                            }
                            line = newLine;
                        }

                        if (camposLine[0].Equals("ENV"))
                        {
                            string newLine = "";
                            string oldLine = line;
                            string[] arrayLine = oldLine.Split('|');
                            //string tipoDoc = arrayLine[1].Split('-')[0];
                            //if (tipoDoc.Equals("07") || tipoDoc.Equals("08"))
                            //{
                            //    arrayLine[1] = tipoDoc + "-0001-1234";
                            //}
                            //else
                            //{
                            //    arrayLine[1] = "01-0001-1234";
                            //}
                            arrayLine[8] = fecha;
                            arrayLine[9] = fecha;

                            for (int t = 0; t < arrayLine.Length - 1; t++)//Envio 1x1 de documentos ubicados en ruta TXTUbicacion
                            {
                                newLine += arrayLine[t] + "|";
                            }
                            line = newLine;
                        }

                        //if (camposLine[0].Equals("02"))
                        //{
                        //    string newLine = "";
                        //    string oldLine = line;
                        //    string[] arrayLine = oldLine.Split('|');
                        //    arrayLine[1] = txtSetFecha.Text;
                        //    if (ambiente.Equals("PRD"))
                        //    {
                        //        if (tipoTxt.Equals("20"))
                        //        {
                        //            arrayLine[3] = txt_PrdRet.Text + "-" + numeroConDosCotas;
                        //        }
                        //        else if (tipoTxt.Equals("40"))
                        //        {
                        //            arrayLine[3] = txt_PrdPerc.Text + "-" + numeroConDosCotas;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        if (tipoTxt.Equals("20"))
                        //        {
                        //            arrayLine[3] = txt_DemoRet.Text + "-" + numeroConDosCotas;
                        //        }
                        //        else if (tipoTxt.Equals("40"))
                        //        {
                        //            arrayLine[3] = txt_DemoPerc.Text + "-" + numeroConDosCotas;
                        //        }
                        //    }
                        //    for (int t = 0; t < arrayLine.Length - 1; t++)//Envio 1x1 de documentos ubicados en ruta TXTUbicacion
                        //    {
                        //        newLine += arrayLine[t] + "|";
                        //    }

                        //    line = newLine;
                        //}

                    }
                    else if (!tipoTxt.Equals("DAE") && !tipoTxt.Equals("NCE"))
                    {
                        if (camposLine[0].Equals("EMI"))
                        {
                            string newLine = "";
                            string oldLine = line;
                            string[] arrayLine = oldLine.Split('|');
                            arrayLine[3] = "0000";
                            for (int t = 0; t < arrayLine.Length - 1; t++)//Envio 1x1 de documentos ubicados en ruta TXTUbicacion
                            {
                                newLine += arrayLine[t] + "|";
                            }
                            line = newLine;
                        }

                        if (camposLine[0].Equals("REC"))
                        {
                            string newLine = "";
                            string oldLine = line;
                            string[] arrayLine = oldLine.Split('|');
                            arrayLine[10] = "NO";
                            for (int t = 0; t < arrayLine.Length - 1; t++)//Envio 1x1 de documentos ubicados en ruta TXTUbicacion
                            {
                                newLine += arrayLine[t] + "|";
                            }
                            line = newLine;
                        }

                        if (camposLine[0].Equals("COM"))
                        {
                            string oldLine = line;
                            string newLine = "";
                            string[] arrayLine = oldLine.Split('|');
                            arrayLine[1] = fecha + " 23:00:00";


                            if (tipoTxt.Equals("01"))
                            {
                                arrayLine[3] = ConfigGlobal.SerieFact + "-" + numeroConDosCotas;
                            }
                            else if (tipoTxt.Equals("03"))
                            {
                                arrayLine[3] = ConfigGlobal.SerieBol + "-" + numeroConDosCotas;
                            }
                            else if (tipoTxt.Equals("07"))
                            {
                                if (primeraLetra.Equals("F"))
                                {
                                    arrayLine[3] = ConfigGlobal.SerieNC.Split('/')[0] + "-" + numeroConDosCotas;
                                }
                                else
                                {
                                    arrayLine[3] = ConfigGlobal.SerieNC.Split('/')[1] + "-" + numeroConDosCotas;
                                }
                                tipoNota = arrayLine[3].ToString().Substring(0, 1);

                            }
                            else if (tipoTxt.Equals("08"))
                            {
                                if (primeraLetra.Equals("F"))
                                {
                                    arrayLine[3] = ConfigGlobal.SerieND.Split('/')[0] + "-" + numeroConDosCotas;
                                }
                                else
                                {
                                    arrayLine[3] = ConfigGlobal.SerieND.Split('/')[1] + "-" + numeroConDosCotas;
                                }
                                tipoNota = arrayLine[3].ToString().Substring(0, 1);

                            }
                            else if (tipoTxt.Equals("09"))
                            {
                                arrayLine[1] = ConfigGlobal.SerieGuia;
                                arrayLine[2] = numeroConDosCotas.ToString();
                                arrayLine[3] = fecha + " 23:00:00";
                            }
                            else if (tipoTxt.Equals("42"))
                            {
                                arrayLine[3] = ConfigGlobal.SerieDae + "-" + numeroConDosCotas;
                                arrayLine[1] = fecha;
                            }



                            for (int t = 0; t < arrayLine.Length - 1; t++)//Envio 1x1 de documentos ubicados en ruta TXTUbicacion
                            {
                                newLine += arrayLine[t] + "|";
                            }
                            line = newLine;
                        }

                        if (camposLine[0].Equals("REL-N"))
                        {
                            string newLine = "";
                            string oldLine = line;
                            string[] arrayLine = oldLine.Split('|');
                            if (tipoNota == "B")
                            {
                                arrayLine[1] = "03/0001-1234";
                            }
                            else
                            {
                                arrayLine[1] = "01/0001-1234";
                            }
                            for (int t = 0; t < arrayLine.Length - 1; t++)//Envio 1x1 de documentos ubicados en ruta TXTUbicacion
                            {
                                newLine += arrayLine[t] + "|";
                            }
                            line = newLine;
                        }

                        if (camposLine[0].Equals("CUO"))
                        {
                            string newLine = "";
                            string oldLine = line;
                            string[] arrayLine = oldLine.Split('|');
                            arrayLine[3] = obtieneFechaMañana();
                            for (int t = 0; t < arrayLine.Length - 1; t++)//Envio 1x1 de documentos ubicados en ruta TXTUbicacion
                            {
                                newLine += arrayLine[t] + "|";
                            }
                            line = newLine;
                        }
                    }
                    else
                    {
                        string newLine = "";
                        string oldLine = line;
                        string[] arrayLine = oldLine.Split('|');
                        arrayLine[0] = fecha; //Fecha 1
                        if (tipoTxt.Equals("DAE"))
                        {
                            arrayLine[5] = ConfigGlobal.SerieDae + "-" + numeroConDosCotas;
                        }
                        else
                        {
                            arrayLine[5] = ConfigGlobal.SerieNC + "-" + numeroConDosCotas;
                        }
                        arrayLine[11] = "66666666666";
                        arrayLine[14] = "66666666666";
                        for (int t = 0; t < arrayLine.Length - 1; t++)//Envio 1x1 de documentos ubicados en ruta TXTUbicacion
                        {
                            newLine += arrayLine[t] + "|";
                        }
                        line = newLine;
                    }
                    listLineas.Add(line);
                }
                string dataTxt = "";
                for (int t = 0; t < listLineas.ToArray().Length; t++)//Envio 1x1 de documentos ubicados en ruta TXTUbicacion
                {
                    dataTxt += listLineas.ToArray()[t] + Environment.NewLine;
                }
                if (System.IO.File.Exists(rutaSalida + nombreArchivo + "-Test" + ".txt"))
                {
                    System.IO.File.Delete(rutaSalida + nombreArchivo + "-Test" + ".txt");
                }
                System.IO.File.WriteAllText(rutaSalida + nombreArchivo + "-Test" + ".txt", dataTxt);
                //rtb_Log.AppendText("Creado: " + nombreArchivo + "-Test" + Environment.NewLine);
                return rutaSalida + nombreArchivo + "-Test" + ".txt";
            }
        }

        public string DescomprimirArchivo(string RutaComprimido)
        {
            string RutaDescomprimido = Path.GetDirectoryName(RutaComprimido) + "\\unZip\\";
            string NombreArchivo = Path.GetFileNameWithoutExtension(RutaComprimido);
            if (!Directory.Exists(RutaDescomprimido))
            {
                Directory.CreateDirectory(RutaDescomprimido);
            }
            if (Directory.Exists(RutaDescomprimido + NombreArchivo))
            {
                Directory.Delete(RutaDescomprimido + NombreArchivo, true);
            }
            ZipFile.ExtractToDirectory(RutaComprimido, RutaDescomprimido + NombreArchivo);
            return RutaDescomprimido + NombreArchivo + "\\R-" + NombreArchivo + ".xml";
        }

        public (int Codigo, string Mensaje, string Docmumento, string Observacion) ProcesaIndividual(string numeracion, int index)
        {
            (int Codigo, string Mensaje, string Documento, string Observacion) resp = (0, "", "", "");
            (int Codigo, string Mensaje, string Documento) resp2 = (0, "", "");

            bool encendido = true;
            while (encendido)
            {
                if (numeracion.Split('-')[0] == "20550728762")
                {
                    resp2 = DllG1.EstatusDocumento(ConfigGlobal.Ruc2, ConfigGlobal.UserRuc2, ConfigGlobal.PassRuc2, numeracion);                  
                }
                else
                {
                    resp2 = DllG1.EstatusDocumento(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, numeracion);                   
                }
                resp.Codigo = resp2.Codigo;
                resp.Mensaje = resp2.Mensaje;
                resp.Documento = resp2.Documento;
                resp.Observacion = "";


                if (resp.Codigo == 0)
                {
                    encendido = false;                   
                    (int Codigo, string Mensaje, string Docmumento, string ArhivoBase64) respDescarga;
                    if (numeracion.Split('-')[0] == "20550728762")
                    {
                        respDescarga = DllG1.DescargaArchivos(ConfigGlobal.Ruc2, ConfigGlobal.UserRuc2, ConfigGlobal.PassRuc2, numeracion, "CDR");
                    }
                    else
                    {
                        respDescarga = DllG1.DescargaArchivos(ConfigGlobal.Ruc, ConfigGlobal.UserRuc, ConfigGlobal.PassRuc, numeracion, "CDR");
                    }

                    if (respDescarga.ArhivoBase64 != null)
                    {
                        byte[] data = System.Convert.FromBase64String(respDescarga.ArhivoBase64);
                        File.WriteAllBytes(ConfigPerso.RutaEjemplosProcesados + numeracion + ".zip", data);
                    }
                    LecturaCdr cdr = new LecturaCdr();
                    var cdrContenido = cdr.LeerCDR(DescomprimirArchivo(ConfigPerso.RutaEjemplosProcesados + numeracion + ".zip"));
                    if (cdrContenido.Length > 1)
                    {
                        string Obs = "Observaciones:" + Environment.NewLine;
                        for (int i = 0; i < cdrContenido.Length - 1; i++)
                        {
                            Obs += cdrContenido[i + 1] + Environment.NewLine;
                        }
                        resp.Observacion = Obs;
                    }
                }
                else if (resp.Codigo == 95 || resp.Codigo == 99)
                {
                    Thread.Sleep(15000);
                }
                else
                {
                    encendido = false;
                }
            }
            return resp;
        }
    }
}
