using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tools
{
    public class LeerConfigPersonal
    {
        string rutaEjemplos, rutaEjemplosProcesados, rutaDrive, rutaZip;
        string hostPSE21, hostPSE20, hostOSE, portPSE21, portPSE20, portOSE, clavePSE21, clavePSE20, claveOSE, userPSE20, userPSE21, userOSE;
        string hostAdmin, portAdmin, claveAdmin, userAdmin;
        string color;

        public string RutaEjemplos { get => rutaEjemplos; set => rutaEjemplos = value; }
        public string RutaEjemplosProcesados { get => rutaEjemplosProcesados; set => rutaEjemplosProcesados = value; }
        public string RutaDrive { get => rutaDrive; set => rutaDrive = value; }
        public string HostPSE21 { get => hostPSE21; set => hostPSE21 = value; }
        public string HostPSE20 { get => hostPSE20; set => hostPSE20 = value; }
        public string HostOSE { get => hostOSE; set => hostOSE = value; }
        public string PortPSE21 { get => portPSE21; set => portPSE21 = value; }
        public string PortPSE20 { get => portPSE20; set => portPSE20 = value; }
        public string PortOSE { get => portOSE; set => portOSE = value; }
        public string ClavePSE21 { get => clavePSE21; set => clavePSE21 = value; }
        public string ClavePSE20 { get => clavePSE20; set => clavePSE20 = value; }
        public string ClaveOSE { get => claveOSE; set => claveOSE = value; }
        public string UserPSE20 { get => userPSE20; set => userPSE20 = value; }
        public string UserPSE21 { get => userPSE21; set => userPSE21 = value; }
        public string UserOSE { get => userOSE; set => userOSE = value; }
        public string HostAdmin { get => hostAdmin; set => hostAdmin = value; }
        public string PortAdmin { get => portAdmin; set => portAdmin = value; }
        public string ClaveAdmin { get => claveAdmin; set => claveAdmin = value; }
        public string UserAdmin { get => userAdmin; set => userAdmin = value; }
        public string RutaZip { get => rutaZip; set => rutaZip = value; }
        public string Color { get => color; set => color = value; }

        public LeerConfigPersonal()
        {
            leer();           
        }

        private void leer()
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
                            if (clave == "RutaEjemplos")
                            {
                                RutaEjemplos = valor;
                            }
                            else if (clave == "RutaProcesados")
                            {
                                RutaEjemplosProcesados = valor;
                            }
                            else if (clave == "RutaDrive")
                            {
                                RutaDrive = valor;
                            }
                            else if (clave == "RutaZip")
                            {
                                rutaZip = valor;
                            }
                            else if (clave == "HostBdPse")
                            {
                                hostPSE21 = valor;
                            }
                            else if (clave == "PuertoBdPse")
                            {
                                portPSE21 = valor;
                            }
                            else if (clave == "UsuarioBdPse")
                            {
                                UserPSE21 = valor;
                            }
                            else if (clave == "ClaveBdPse")
                            {
                                ClavePSE21 = valor;
                            }
                            else if (clave == "HostBdPse20")
                            {
                                hostPSE20 = valor;
                            }
                            else if (clave == "PuertoBdPse20")
                            {
                                PortPSE20 = valor;
                            }
                            else if (clave == "UsuarioBdPse20")
                            {
                                userPSE20 = valor;
                            }
                            else if (clave == "ClaveBdPse20")
                            {
                                try
                                {
                                    if (lines[i].Split('=')[2] != null)
                                    {
                                        clavePSE20 = valor + "=";
                                    }
                                    else
                                    {
                                        clavePSE20 = valor;

                                    }
                                }catch(Exception ee)
                                {
                                    clavePSE20 = valor;
                                }

                            }
                            else if (clave == "HostBdOse")
                            {
                                hostOSE = valor;
                            }
                            else if (clave == "PuertoBdOse")
                            {
                                portOSE = valor;
                            }
                            else if (clave == "UsuarioBdOse")
                            {
                                userOSE = valor;
                            }
                            else if (clave == "ClaveBdOse")
                            {
                                try
                                {
                                    if (lines[i].Split('=')[2] != null)
                                    {
                                        claveOSE = valor + "=";
                                    }
                                    else
                                    {
                                        claveOSE = valor;
                                    }
                                }catch(Exception ex)
                                {
                                    claveOSE = valor;
                                }

                            }
                            else if (clave == "HostBdAdmin")
                            {
                                hostAdmin = valor;
                            }
                            else if (clave == "PuertoBdAdmin")
                            {
                                portAdmin = valor;
                            }
                            else if (clave == "UsuarioBdAdmin")
                            {
                                userAdmin = valor;
                            }
                            else if (clave == "ClaveBdAdmin")
                            {
                                claveAdmin = valor;
                            }
                            else if (clave == "Color")
                            {
                                color = valor;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor crea tu archivo de configuración en: " + FileToRead);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

    }
}
