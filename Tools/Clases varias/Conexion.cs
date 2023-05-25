using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools
{
    class Conexion
    {
        MySqlConnection databaseConnection;
         
        public void conection(string connectionString)
        {
            try
            {
                databaseConnection = new MySqlConnection(connectionString);
                databaseConnection.Open();
            }
            catch (Exception e)
            {
                //MessageBox.Show("Revisa tus parametros de conexión a la BD: " + connectionString);
                e.GetBaseException();                
            }
        }

        public void closeCon()
        {
            if (databaseConnection != null)
            {
                databaseConnection.Close();
                databaseConnection = null;
            }
        }

        public List<String> getDocumentos(string ruc, string ambiente, string desde, string hasta, string Horadesde, string Horahasta,
            bool activo, bool emision, bool creacion, bool aceptado, string cadenaConexion)
        {
            string query = QueryFactura(ruc, ambiente, desde, hasta, activo, emision, creacion, aceptado, Horadesde, Horahasta) +
                " union " + QueryBoleta(ruc, ambiente, desde, hasta, activo, emision, creacion, aceptado, Horadesde, Horahasta) +
                " union " + QueryNota(ruc, ambiente, desde, hasta, activo, emision, creacion, aceptado, Horadesde, Horahasta) +
                " union " + QueryBajas(ruc, ambiente, desde, hasta, activo, emision, creacion, aceptado, Horadesde, Horahasta) +
                " union " + QueryRc(ruc, ambiente, desde, hasta, activo, emision, creacion, aceptado, Horadesde, Horahasta) +
                " union " + QueryRetPerc(ruc, ambiente, desde, hasta, activo, emision, creacion, aceptado, Horadesde, Horahasta);
            if (!ambiente.Equals("PSE20"))
            {
                string queryOld = query;
                if (ambiente.Equals("PSE"))
                {
                    query = queryOld + " union " + QueryGuias(ruc, ambiente, desde, hasta, activo, emision, creacion, aceptado, Horadesde, Horahasta) +
                   " union " + QueryDAE(ruc, ambiente, desde, hasta, activo, emision, creacion, aceptado, Horadesde, Horahasta);
                }
                else
                {
                    query = queryOld + " union " + QueryGuias(ruc, ambiente, desde, hasta, activo, emision, creacion, aceptado, Horadesde, Horahasta);
                } 
            }
            if (!ambiente.Equals("OSE"))
            {
                string queryOld = query;
                query = queryOld + " union " + QueryReversiones(ruc, ambiente, desde, hasta, activo, emision, creacion, aceptado, Horadesde, Horahasta);
            }
            if (ambiente.Equals("OSE"))
            {
                string queryOld = query;
                query = queryOld + " union " + QueryRcBol(ruc, ambiente, desde, hasta, activo, emision, creacion, aceptado, Horadesde, Horahasta) +
                    " union " + QueryRcNotas(ruc, ambiente, desde, hasta, activo, emision, creacion, aceptado, Horadesde, Horahasta);
            }

            List<String> listDoc = new List<string>();
            int TotalFolios = 0;
            conection(cadenaConexion);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60000;

            MySqlDataReader reader;
            try
            {
                //databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listDoc.Add(reader.GetString(0));
                        TotalFolios += Convert.ToInt32(reader.GetString(0).Split(':')[1]);
                    }
                    listDoc.Add("---------------");
                    listDoc.Add("Total Folios: " + TotalFolios.ToString());
                }
                else
                {
                    Console.WriteLine("No se encontraron datos.");
                }
                closeCon();
                return listDoc;
            }
            catch (Exception ex)
            {
                closeCon();
                return null;
            }
        }

        //public List<String> getDocumentosDetalle(string ruc, string ambiente, string desde, string hasta,
        //    bool activo, bool emision, bool creacion, bool aceptado, string cadenaConexion)
        //{
        //    string query = QueryFacturaD(ruc, ambiente, desde, hasta, activo, emision, creacion, aceptado) +
        //        " union " + QueryBoletaD(ruc, ambiente, desde, hasta, activo, emision, creacion, aceptado) +
        //        " union " + QueryNotaD(ruc, ambiente, desde, hasta, activo, emision, creacion, aceptado) +
        //        " union " + QueryBajasD(ruc, ambiente, desde, hasta, activo, emision, creacion, aceptado) +
        //        " union " + QueryRcD(ruc, ambiente, desde, hasta, activo, emision, creacion, aceptado) +
        //        " union " + QueryRetPercD(ruc, ambiente, desde, hasta, activo, emision, creacion, aceptado);

        //    if (ambiente.Equals("OSE"))
        //    {
        //        string queryOld = query;
        //        query = queryOld + " union " + QueryRcBolD(ruc, ambiente, desde, hasta, activo, emision, creacion, aceptado) +
        //            " union " + QueryRcNotasD(ruc, ambiente, desde, hasta, activo, emision, creacion, aceptado);
        //    }

        //    List<String> listDoc = new List<string>();
        //    int TotalFolios = 0;
        //    conection(cadenaConexion);
        //    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
        //    commandDatabase.CommandTimeout = 60;

        //    MySqlDataReader reader;
        //    try
        //    {
        //        //databaseConnection.Open();
        //        reader = commandDatabase.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                listDoc.Add(reader.GetString(0));
        //                TotalFolios += Convert.ToInt32(reader.GetString(0).Split(':')[1]);
        //            }
        //            listDoc.Add("---------------");
        //            listDoc.Add("Total Folios: " + TotalFolios.ToString());
        //        }
        //        else
        //        {
        //            Console.WriteLine("No se encontraron datos.");
        //        }
        //        closeCon();
        //        return listDoc;
        //    }
        //    catch (Exception ex)
        //    {
        //        closeCon();
        //        return null;
        //    }
        //}

        public List<String> getClientes(string ruc, string ambiente, string cadenaConexion)
        {
            string query = "";
            if(ambiente == "PSE")
            {
                query = QueryClientesPSE21();
            }
            else if(ambiente == "PSE20")
            {
                query = QueryClientesPSE20();
            }
            else
            {
                query = QueryClientesOSE();
            }
            List<String> listDoc = new List<string>();
            conection(cadenaConexion);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listDoc.Add(reader.GetString(0));
                    }
                }
                else
                {
                    Console.WriteLine("No se encontraron datos.");
                }
                closeCon();
                return listDoc;
            }
            catch (Exception ex)
            {
                closeCon();
                return null;
            }
        }

        public List<String> getClientesAdmin(string ambiente, string cadenaConexion)
        {
            string query = "";
            if (ambiente == "PSE")
            {
                query = QueryClientesPSE21Admin();
            }
            else if (ambiente == "PSE20")
            {
                query = QueryClientesPSE20();
            }
            else
            {
                query = QueryClientesOSE();
            }
            List<String> listDoc = new List<string>();
            conection(cadenaConexion);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listDoc.Add(reader.GetString(0));
                    }
                }
                else
                {
                    Console.WriteLine("No se encontraron datos.");
                }
                closeCon();
                return listDoc;
            }
            catch (Exception ex)
            {
                closeCon();
                return null;
            }
        }

        private string QueryFactura(string ruc, string ambiente, string desde, string hasta,
            bool activo, bool emision, bool creacion, bool aceptado, string horaDesde, string horaHasta)
        {
            string QBasico = "", QFecha = "", QActivo = "", QAceptado = "";
            if (ambiente.Equals("PSE"))
            {
                QBasico = "select CONCAT('Facturas: ', count(DISTINCT ruc, serie, correlativo, status)) from peprodpse.invoices where ruc in ('" + ruc + "')";
                if (creacion)
                {
                    QFecha = " and SUBSTRING(created_at,1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                    if(horaDesde != "")
                    {
                        QFecha += " and SUBSTRING(created_at,12,19) BETWEEN '" + horaDesde + "' AND '" + horaHasta + "'";
                    }
                }
                else if (emision)
                {
                    QFecha = " and SUBSTRING(fechaHoraEmision, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                }
                if (activo)
                {
                    QActivo = " and activo = 1";
                }
                if (aceptado)
                {
                    QAceptado = " and status = 0";
                }
                return QBasico + QFecha + QActivo + QAceptado;
            }
            else if (ambiente.Equals("PSE20"))
            {
                QBasico = "select CONCAT('Facturas: ', count(*)) from peru_produccion.invoices where ruc in ('" + ruc + "') and invoice_type = 01";
                if (creacion)
                {
                    QFecha = " and SUBSTRING(created_at,1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                    if (horaDesde != "")
                    {
                        QFecha += " and SUBSTRING(created_at,12,19) BETWEEN '" + horaDesde + "' AND '" + horaHasta + "'";
                    }
                }
                else if (emision)
                {
                    QFecha = " and SUBSTRING(issue_date, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                }
                if (activo)
                {
                    QActivo = " and activo = 1";
                }
                if (aceptado)
                {
                    QAceptado = " and status = 0";
                }
                return QBasico + QFecha + QActivo + QAceptado;
            }
            else // OSE
            {
                QBasico = "select CONCAT('Facturas: ', count(DISTINCT supplier_ruc, serie, correlative, status)) from peproduccionose.invoices where ruc in ('" + ruc + "')";
                if (creacion)
                {
                    QFecha = " and SUBSTRING(reception_date,1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                    if (horaDesde != "")
                    {
                        QFecha += " and SUBSTRING(reception_date,12,19) BETWEEN '" + horaDesde + "' AND '" + horaHasta + "'";
                    }
                }
                else if (emision)
                {
                    QFecha = " and SUBSTRING(issue_date, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                }
                if (activo)
                {
                    QActivo = " and active = 1";
                }
                if (aceptado)
                {
                    // QAceptado = " and status = 0"; OSE no maneja este campo
                }
                return QBasico + QFecha + QActivo + QAceptado;
            }
        }

        private string QueryFacturaD(string ruc, string ambiente, string desde, string hasta,
            bool activo, bool emision, bool creacion, bool aceptado)
        {
            string QBasico = "", QFecha = "", QActivo = "", QAceptado = "";
            QBasico = "select CONCAT('Facturas: ', count(*)) from peproduccionose.invoices where ruc in ('" + ruc + "')";
            if (creacion)
            {
                QFecha = " and SUBSTRING(reception_date,1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
            }
            else if (emision)
            {
                QFecha = " and SUBSTRING(issue_date, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
            }
            if (activo)
            {
                QActivo = " and active = 1";
            }
            if (aceptado)
            {
                // QAceptado = " and status = 0"; OSE no maneja este campo
            }
            return QBasico + QFecha + QActivo + QAceptado;
        }

        private string QueryClientesPSE20()
        {
            string QBasico = "";
            QBasico = "select CONCAT(ruc, '|', name) from peru_produccion.companies c  where ruc <> '00000000000' and id <> 0";
            return QBasico;
        }

        private string QueryClientesPSE21()
        {
            string QBasico = "";
            QBasico = "select CONCAT(ruc, '|' ,razonSocial) from peprodpse.companies where ruc <> '00000000000'";
            return QBasico;
        }

        private string QueryClientesPSE21Admin()
        {
            string QBasico = "";
            QBasico = "select CONCAT(ruc, '|' ,nombre) from peru_administracion.empresas where ruc <> '00000000000'";
            return QBasico;
        }

        private string QueryClientesOSE()
        {
            string QBasico = "";
            QBasico = "select CONCAT(ruc, '|', registration_name) from peproduccionose.taxpayers as t";
            return QBasico;
        }

        #region Conteo Folios

        private string QueryBoleta(string ruc, string ambiente, string desde, string hasta,
           bool activo, bool emision, bool creacion, bool aceptado, string horaDesde, string horaHasta)
        {
            string QBasico = "", QFecha = "", QActivo = "", QAceptado = "";
            if (ambiente.Equals("PSE"))
            {
                QBasico = "select CONCAT('Boletas: ', count(DISTINCT ruc, serie, correlativo, status)) from peprodpse.salebills where ruc in ('" + ruc + "')";
                if (creacion)
                {
                    QFecha = " and SUBSTRING(created_at, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                    if (horaDesde != "")
                    {
                        QFecha += " and SUBSTRING(created_at,12,19) BETWEEN '" + horaDesde + "' AND '" + horaHasta + "'";
                    }
                }
                else if (emision)
                {
                    QFecha = " and SUBSTRING(fechaHoraEmision, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                }
                if (activo)
                {
                    QActivo = " and activo = 1";
                }
                if (aceptado)
                {
                    QAceptado = " and status = 0";
                }
                return QBasico + QFecha + QActivo + QAceptado;
            }
            else if (ambiente.Equals("PSE20"))
            {
                QBasico = "select CONCAT('Boletas: ', count(*)) from peru_produccion.invoices where ruc in ('" + ruc + "') and invoice_type = 03";
                if (creacion)
                {
                    QFecha = " and SUBSTRING(created_at,1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                    if (horaDesde != "")
                    {
                        QFecha += " and SUBSTRING(created_at,12,19) BETWEEN '" + horaDesde + "' AND '" + horaHasta + "'";
                    }
                }
                else if (emision)
                {
                    QFecha = " and SUBSTRING(issue_date, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                }
                if (activo)
                {
                    QActivo = " and activo = 1";
                }
                if (aceptado)
                {
                    QAceptado = " and status = 0";
                }
                return QBasico + QFecha + QActivo + QAceptado;
            }
            else
            {
                QBasico = "select CONCAT('Boletas: ', count(DISTINCT supplier_ruc, serie, correlative, status)) from peproduccionose.invoice_salebills where ruc in ('" + ruc + "')";
                if (creacion)
                {
                    QFecha = " and SUBSTRING(reception_date, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                    if (horaDesde != "")
                    {
                        QFecha += " and SUBSTRING(reception_date,12,19) BETWEEN '" + horaDesde + "' AND '" + horaHasta + "'";
                    }
                }
                else if (emision)
                {
                    QFecha = " and SUBSTRING(issue_date, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                }
                if (activo)
                {
                    QActivo = " and active = 1";
                }
                if (aceptado)
                {
                    //QAceptado = " and status = 0";
                }
                return QBasico + QFecha + QActivo + QAceptado;
            }
        }

        private string QueryNota(string ruc, string ambiente, string desde, string hasta,
            bool activo, bool emision, bool creacion, bool aceptado, string horaDesde, string horaHasta)
        {
            string QBasico = "", QFecha = "", QActivo = "", QAceptado = "";


            if (ambiente.Equals("PSE"))
            {
                QBasico = "select CONCAT('Notas: ', count(DISTINCT ruc, serie, correlativo, status)) from peprodpse.notes where ruc in ('" + ruc + "')";
                if (creacion)
                {
                    QFecha = " and SUBSTRING(created_at, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                    if (horaDesde != "")
                    {
                        QFecha += " and SUBSTRING(created_at,12,19) BETWEEN '" + horaDesde + "' AND '" + horaHasta + "'";
                    }
                }
                else if (emision)
                {
                    QFecha = " and SUBSTRING(fechaHoraEmision, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                }
                if (activo)
                {
                    QActivo = " and activo = 1";
                }
                if (aceptado)
                {
                    QAceptado = " and status = 0";
                }
                return QBasico + QFecha + QActivo + QAceptado;
            }
            else if (ambiente.Equals("PSE20"))
            {
                QBasico = "select CONCAT('Notas: ', count(*)) from peru_produccion.invoices where ruc in ('" + ruc + "') and invoice_type in ('07','08')";
                if (creacion)
                {
                    QFecha = " and SUBSTRING(created_at,1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                    if (horaDesde != "")
                    {
                        QFecha += " and SUBSTRING(created_at,12,19) BETWEEN '" + horaDesde + "' AND '" + horaHasta + "'";
                    }
                }
                else if (emision)
                {
                    QFecha = " and SUBSTRING(issue_date, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                }
                if (activo)
                {
                    QActivo = " and activo = 1";
                }
                if (aceptado)
                {
                    QAceptado = " and status = 0";
                }
                return QBasico + QFecha + QActivo + QAceptado;
            }
            else
            {
                QBasico = "select CONCAT('Notas: ', count(DISTINCT supplier_ruc, serie, correlative, status)) from peproduccionose.invoice_notes where ruc in ('" + ruc + "')";
                if (creacion)
                {
                    QFecha = " and SUBSTRING(reception_date, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                    if (horaDesde != "")
                    {
                        QFecha += " and SUBSTRING(reception_date,12,19) BETWEEN '" + horaDesde + "' AND '" + horaHasta + "'";
                    }
                }
                else if (emision)
                {
                    QFecha = " and SUBSTRING(issue_date, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                }
                if (activo)
                {
                    QActivo = " and active = 1";
                }
                if (aceptado)
                {
                    //QAceptado = " and status = 0";
                }
                return QBasico + QFecha + QActivo + QAceptado;

            }
        }

        private string QueryBajas(string ruc, string ambiente, string desde, string hasta,
            bool activo, bool emision, bool creacion, bool aceptado, string horaDesde, string horaHasta)
        {
            string QFecha = "", QActivo = "", QBasico = "", QAceptado = "";

            if (ambiente.Equals("PSE"))
            {
                QBasico = "select CONCAT('Bajas: ', count(DISTINCT c.ruc, vs.identificador, vs.status)) from peprodpse.voided_documents as vs, peprodpse.companies " +
                    "as c" + " where vs.company_id = c.id " + "and c.ruc in ('" + ruc + "') ";
                if (creacion || emision)
                {
                    QFecha = " and SUBSTRING(vs.created_at, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                    if (horaDesde != "")
                    {
                        QFecha += " and SUBSTRING(vs.created_at,12,19) BETWEEN '" + horaDesde + "' AND '" + horaHasta + "'";
                    }
                }
                if (activo)
                {
                    QActivo = " and activo = 1";
                }
                if (aceptado)
                {
                    QAceptado = " and status = 0";
                }
                return QBasico + QFecha + QActivo + QAceptado;
            }
            else if (ambiente.Equals("PSE20"))
            {
                QBasico = "select CONCAT('Bajas: ', count(*)) from peru_produccion.voided_documents as vs, peru_produccion.companies " +
                    "as c" + " where vs.company_id = c.id " + "and c.ruc in ('" + ruc + "') ";
                if (creacion || emision)
                {
                    QFecha = " and SUBSTRING(vs.created_at, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                    if (horaDesde != "")
                    {
                        QFecha += " and SUBSTRING(vs.created_at,12,19) BETWEEN '" + horaDesde + "' AND '" + horaHasta + "'";
                    }
                }
                if (activo)
                {
                    //QActivo = " and activo = 1"; //-> Comentado porque no existe ese campo en 2.0
                }
                if (aceptado)
                {
                    QAceptado = " and status = 0";
                }
                return QBasico + QFecha + QActivo + QAceptado;
            }
            else
            {
                QBasico = "select CONCAT('Bajas: ', count(DISTINCT supplier_ruc, invoice_type, identificator, status)) from peproduccionose.voided_documents where ruc in ('" + ruc + "') ";
                if (creacion || emision)
                {
                    QFecha = " and SUBSTRING(created_at, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                    if (horaDesde != "")
                    {
                        QFecha += " and SUBSTRING(created_at,12,19) BETWEEN '" + horaDesde + "' AND '" + horaHasta + "'";
                    }
                }
                if (activo)
                {
                    QActivo = " and active = 1";
                }
                if (aceptado)
                {
                    //QAceptado = " and status = 0";
                }
                return QBasico + QFecha + QActivo + QAceptado;
            }
        }

        private string QueryRc(string ruc, string ambiente, string desde, string hasta,
            bool activo, bool emision, bool creacion, bool aceptado, string horaDesde, string horaHasta)
        {
            string QFecha = "", QActivo = "", QBasico = "", QAceptado = "";

            if (ambiente.Equals("PSE"))
            {
                QBasico = "select CONCAT('Resumenes de boletas: ', count(DISTINCT c.ruc, vs.identificador_resumen, vs.status)) from peprodpse.summary_documents as vs, peprodpse.companies " +
                    "as c" + " where vs.company_id = c.id " + "and c.ruc in ('" + ruc + "') ";
                if (creacion || emision)
                {
                    QFecha = " and SUBSTRING(vs.created_at, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                    if (horaDesde != "")
                    {
                        QFecha += " and SUBSTRING(vs.created_at,12,19) BETWEEN '" + horaDesde + "' AND '" + horaHasta + "'";
                    }
                }
                if (activo)
                {
                    QActivo = " and activo = 1";
                }
                if (aceptado)
                {
                    QAceptado = " and status = 0";
                }
                return QBasico + QFecha + QActivo + QAceptado;
            }
            else if (ambiente.Equals("PSE20"))
            {
                QBasico = "select CONCAT('Resumenes de boletas: ', count(*)) from peru_produccion.summary_documents as vs, peru_produccion.companies " +
                    "as c" + " where vs.company_id = c.id " + "and c.ruc in ('" + ruc + "') ";
                if (creacion || emision)
                {
                    QFecha = " and SUBSTRING(vs.created_at, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                    if (horaDesde != "")
                    {
                        QFecha += " and SUBSTRING(vs.created_at,12,19) BETWEEN '" + horaDesde + "' AND '" + horaHasta + "'";
                    }
                }
                if (activo)
                {
                    QActivo = " and activo = 1"; // -> Comentado porque no existe ese campo en 2.0
                }
                if (aceptado)
                {
                    QAceptado = " and status = 0";
                }
                return QBasico + QFecha + QActivo + QAceptado;
            }
            else
            {
                QBasico = "select CONCAT('Resumenes de boletas: ', count(DISTINCT supplier_ruc, invoice_type, identificator, status)) from peproduccionose.summary_documents where ruc in ('" + ruc + "') ";
                if (creacion || emision)
                {
                    QFecha = " and SUBSTRING(created_at, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                    if (horaDesde != "")
                    {
                        QFecha += " and SUBSTRING(created_at,12,19) BETWEEN '" + horaDesde + "' AND '" + horaHasta + "'";
                    }
                }
                if (activo)
                {
                    QActivo = " and active = 1";
                }
                if (aceptado)
                {
                    QAceptado = " and (status_cdrose like ('0%') or status_cdrose like (',%')) ";
                }
                return QBasico + QFecha + QActivo + QAceptado;
            }
        }

        private string QueryRcBol(string ruc, string ambiente, string desde, string hasta,
            bool activo, bool emision, bool creacion, bool aceptado, string horaDesde, string horaHasta)
        {
            string QFecha = "", QActivo = "", QBasico = "", QAceptado = "";
            QBasico = "select CONCAT('Boletas RC: ', count(DISTINCT supplier_ruc, invoice_type, serie, correlative, status)) from peproduccionose.summary_lines where ruc in ('" + ruc + "') and invoice_type = '03'";
            if (creacion || emision)
            {
                QFecha = " and SUBSTRING(reception_date, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                if (horaDesde != "")
                {
                    QFecha += " and SUBSTRING(reception_date,12,19) BETWEEN '" + horaDesde + "' AND '" + horaHasta + "'";
                }
            }
            if (activo)
            {
                QActivo = " and active = 1";
            }
            if (aceptado)
            {
                //QAceptado = " and status_cdrose like ('0%')";
            }
            return QBasico + QFecha + QActivo + QAceptado;
        }

        private string QueryRcNotas(string ruc, string ambiente, string desde, string hasta,
            bool activo, bool emision, bool creacion, bool aceptado, string horaDesde, string horaHasta)
        {
            string QFecha = "", QActivo = "", QBasico = "", QAceptado = "";
            QBasico = "select CONCAT('Notas RC: ', count(DISTINCT supplier_ruc, invoice_type, serie, correlative, status)) from peproduccionose.summary_lines where ruc in ('" + ruc + "') and invoice_type in ('07','08')";
            if (creacion || emision)
            {
                QFecha = " and SUBSTRING(reception_date, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                if (horaDesde != "")
                {
                    QFecha += " and SUBSTRING(reception_date,12,19) BETWEEN '" + horaDesde + "' AND '" + horaHasta + "'";
                }
            }
            if (activo)
            {
                QActivo = " and active = 1";
            }
            if (aceptado)
            {
                //QAceptado = " and status_cdrose like ('0%')";
            }
            return QBasico + QFecha + QActivo + QAceptado;

        }

        private string QueryGuias(string ruc, string ambiente, string desde, string hasta,
            bool activo, bool emision, bool creacion, bool aceptado, string horaDesde, string horaHasta)
        {
            string QFecha = "", QActivo = "", QBasico = "", QAceptado = "";

            if (ambiente.Equals("PSE"))
            {
                QBasico = "select CONCAT('Guias: ', count(DISTINCT ruc, serie, correlativo, status)) from peprodpse.despatch_advice where ruc in ('" + ruc + "')";
                if (creacion)
                {
                    QFecha = " and SUBSTRING(created_at, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                    if (horaDesde != "")
                    {
                        QFecha += " and SUBSTRING(created_at,12,19) BETWEEN '" + horaDesde + "' AND '" + horaHasta + "'";
                    }
                }
                else if (emision)
                {
                    QFecha = " and SUBSTRING(fecha_emision, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                }
                if (activo)
                {
                    QActivo = " and activo = 1";
                }
                if (aceptado)
                {
                    QAceptado = " and status = 0";
                }
                return QBasico + QFecha + QActivo + QAceptado;
            }
            else
            {
                QBasico = "select CONCAT('Guias: ', count(DISTINCT supplier_ruc, serie, correlative, status)) from peproduccionose.despatch_advice where ruc in ('" + ruc + "')";
                if (creacion)
                {
                    QFecha = " and SUBSTRING(reception_date, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                    if (horaDesde != "")
                    {
                        QFecha += " and SUBSTRING(reception_date,12,19) BETWEEN '" + horaDesde + "' AND '" + horaHasta + "'";
                    }
                }
                else if (emision)
                {
                    QFecha = " and SUBSTRING(issue_date, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                }
                if (activo)
                {
                    QActivo = " and active = 1";
                }
                if (aceptado)
                {
                    //QAceptado = " and status = 0";
                }
                return QBasico + QFecha + QActivo + QAceptado;
            }
        }

        private string QueryRetPerc(string ruc, string ambiente, string desde, string hasta,
            bool activo, bool emision, bool creacion, bool aceptado, string horaDesde, string horaHasta)
        {
            string QFecha = "", QActivo = "", QBasico = "", QAceptado = "";

            if (ambiente.Equals("PSE"))
            {
                QBasico = "select CONCAT('Ret/Perc: ', count(DISTINCT ruc, serie, tipoDocumento, correlativo, status)) from peprodpse.comprobantes where ruc in ('" + ruc + "')";
                if (creacion)
                {
                    QFecha = " and SUBSTRING(created_at, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                    if (horaDesde != "")
                    {
                        QFecha += " and SUBSTRING(created_at,12,19) BETWEEN '" + horaDesde + "' AND '" + horaHasta + "'";
                    }
                }
                else if (emision)
                {
                    QFecha = " and SUBSTRING(fechaEmision, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                }
                if (activo)
                {
                    QActivo = " and activo = 1";
                }
                if (aceptado)
                {
                    QAceptado = " and status = 0";
                }
                return QBasico + QFecha + QActivo + QAceptado;
            }
            else if (ambiente.Equals("PSE20"))
            {
                QBasico = "select CONCAT('Ret/Perc: ', count(*)) from peru_produccion.comprobantes where ruc in ('" + ruc + "')";
                if (creacion)
                {
                    QFecha = " and SUBSTRING(created_at, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                    if (horaDesde != "")
                    {
                        QFecha += " and SUBSTRING(created_at,12,19) BETWEEN '" + horaDesde + "' AND '" + horaHasta + "'";
                    }
                }
                else if (emision)
                {
                    QFecha = " and SUBSTRING(issue_date, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                }
                if (activo)
                {
                    QActivo = " and activo = 1";
                }
                if (aceptado)
                {
                    QAceptado = " and status = 0";
                }
                return QBasico + QFecha + QActivo + QAceptado;
            }
            {
                QBasico = "select CONCAT('Ret/Perc: ', count(*)) from peproduccionose.retentions_perceptions where ruc in ('" + ruc + "')";
                if (creacion)
                {
                    QFecha = " and SUBSTRING(reception_date, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                    if (horaDesde != "")
                    {
                        QFecha += " and SUBSTRING(reception_date,12,19) BETWEEN '" + horaDesde + "' AND '" + horaHasta + "'";
                    }
                }
                else if (emision)
                {
                    QFecha = " and SUBSTRING(issue_date, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                }
                if (activo)
                {
                    QActivo = " and active = 1";
                }
                if (aceptado)
                {
                    //QAceptado = " and status = 0";
                }
                return QBasico + QFecha + QActivo + QAceptado;
            }
        }

        private string QueryReversiones(string ruc, string ambiente, string desde, string hasta,
            bool activo, bool emision, bool creacion, bool aceptado, string horaDesde, string horaHasta)
        {
            string QFecha = "", QActivo = "", QBasico = "", QAceptado = "";

            if (ambiente.Equals("PSE"))
            {
                QBasico = "select CONCAT('Reversiones: ', count(DISTINCT c.ruc, vs.identificador, vs.status)) from peprodpse.reversions as vs, peprodpse.companies " +
                    "as c" + " where vs.company_id = c.id " + "and c.ruc in ('" + ruc + "') ";

                QFecha = " and SUBSTRING(vs.created_at, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                if (horaDesde != "")
                {
                    QFecha += " and SUBSTRING(vs.created_at,12,19) BETWEEN '" + horaDesde + "' AND '" + horaHasta + "'";
                }
                if (activo)
                {
                    QActivo = " and activo = 1";
                }
                if (aceptado)
                {
                    QAceptado = " and status = 0";
                }
                return QBasico + QFecha + QActivo + QAceptado;
            }
            else if (ambiente.Equals("PSE20"))
            {
                QBasico = "select CONCAT('Reversiones: ', count(*)) from peru_produccion.reversions as vs, peru_produccion.companies " +
                    "as c" + " where vs.company_id = c.id " + "and c.ruc in ('" + ruc + "') ";
                QFecha = " and SUBSTRING(vs.created_at, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                if (horaDesde != "")
                {
                    QFecha += " and SUBSTRING(vs.created_at,12,19) BETWEEN '" + horaDesde + "' AND '" + horaHasta + "'";
                }
                if (activo)
                {
                    // QActivo = " and activo = 1"; -> Comentado porque no existe ese campo en 2.0
                }
                if (aceptado)
                {
                    QAceptado = " and status = 0";
                }
                return QBasico + QFecha + QActivo + QAceptado;
            }
            {
                return "";
            }
        }

        private string QueryDAE(string ruc, string ambiente, string desde, string hasta,
           bool activo, bool emision, bool creacion, bool aceptado, string horaDesde, string horaHasta)
        {
            string QFecha = "", QActivo = "", QBasico = "", QAceptado = "";
            QBasico = "select CONCAT('Dae: ', count(DISTINCT ruc, serie, correlativo, status)) from peprodpse.documents_dae where ruc in ('" + ruc + "')";
            if (creacion)
            {
                QFecha = " and SUBSTRING(created_at, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
                if (horaDesde != "")
                {
                    QFecha += " and SUBSTRING(created_at,12,19) BETWEEN '" + horaDesde + "' AND '" + horaHasta + "'";
                }
            }
            else if (emision)
            {
                QFecha = " and SUBSTRING(fechaHoraEmision, 1,10) BETWEEN '" + desde + "' AND '" + hasta + "'";
            }
            if (activo)
            {
                QActivo = " and activo = 1";
            }
            if (aceptado)
            {
                QAceptado = " and status = 0";
            }
            return QBasico + QFecha + QActivo + QAceptado;
        }

        #endregion       

        #region PSE Consulta Empresas

        public String getEmpresaUserPortal(string ruc, string cadenaConexion)
        {
            string query = "select u.username from peru_administracion.usuarios u, peru_administracion.empresas e where e.id = u.id_empresa and u.tipo  = 'A' and e.ruc = '" + ruc + "' limit 1";
            string resultado = "";
            List<String> listDoc = new List<string>();
            conection(cadenaConexion);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        resultado = reader.GetString(0);
                    }
                }
                else
                {
                    resultado = "No se encontraron datos.";
                }
                closeCon();
                return resultado;
            }
            catch (Exception ex)
            {
                closeCon();
                return null;
            }
        }

        public String getEmpresaFirmado(string ruc, string cadenaConexion)
        {
            string query = "SELECT sub_id FROM peru_administracion.configurationPSE WHERE ruc=" + ruc;
            string resultado = "";
            List<String> listDoc = new List<string>();
            conection(cadenaConexion);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.GetString(0) == "0")
                        {
                            resultado = "Firma con su propio certificado";
                        }
                        else
                        {
                            resultado = "HKA firma sus documentos";
                        }
                    }
                }
                else
                {
                    resultado = "Firma con su propio certificado";
                }
                closeCon();
                return resultado;
            }
            catch (Exception ex)
            {
                closeCon();
                return null;
            }
        }

        public String getEmpresaEnvia(string ruc, string cadenaConexion)
        {
            string query = "SELECT * FROM peru_administracion.ose_empresas WHERE ruc=" + ruc;
            string resultado = "";
            List<String> listDoc = new List<string>();
            conection(cadenaConexion);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        resultado = "OSE";
                    }
                }
                else
                {
                    resultado = "Sunat";
                }
                closeCon();
                return resultado;
            }
            catch (Exception ex)
            {
                closeCon();
                return null;
            }
        }

        public string getEmpresaFolios(string ruc, string cadenaConexion)
        {
            string query1 = "select id from peprodpse.companies c where ruc = " + ruc;
            string id = "";
            string resultado1 = "";
            int Comprados = 0;
            int folios21 = 0;
            int folios20 = 0;
            List<String> listDoc = new List<string>();
            conection(cadenaConexion);
            MySqlCommand commandDatabase = new MySqlCommand(query1, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = reader.GetString(0);
                        string query2 = "select total_folios_comprados, total_folios_asignados, total_folios_asignados20 from peprodpse.configurations c2 where  company_id =" + id;
                        string resultado2 = "";
                        //closeCon();
                        conection(cadenaConexion);
                        MySqlCommand commandDatabase2 = new MySqlCommand(query2, databaseConnection);
                        commandDatabase2.CommandTimeout = 60;
                        MySqlDataReader reader2;
                        try
                        {
                            reader2 = commandDatabase2.ExecuteReader();
                            if (reader2.HasRows)
                            {
                                while (reader2.Read())
                                {
                                    Comprados = reader2.GetInt32(0);
                                    folios21 = reader2.GetInt32(1);
                                    folios20 = reader2.GetInt32(2);
                                }
                            }
                            closeCon();
                            return (Comprados - folios21 - folios20).ToString();
                        }
                        catch (Exception ex)
                        {
                            closeCon();
                            return null;
                        }
                    }
                }
                closeCon();
                return resultado1;
            }
            catch (Exception ex)
            {
                closeCon();
                return null;
            }
        }

        public string getEmpresaFoliosVigencia(string ruc, string cadenaConexion)
        {
            string query1 = "select id from peprodpse.companies c where ruc = " + ruc;
            string id = "";
            string resultado1 = "";
            //string resul = 0;
            int folios21 = 0;
            int folios20 = 0;
            List<String> listDoc = new List<string>();
            conection(cadenaConexion);
            MySqlCommand commandDatabase = new MySqlCommand(query1, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = reader.GetString(0);
                        string query2 = "select vigencia_fin from peprodpse.configurations c2 where  company_id =" + id;
                        string resultado2 = "";
                        //closeCon();
                        conection(cadenaConexion);
                        MySqlCommand commandDatabase2 = new MySqlCommand(query2, databaseConnection);
                        commandDatabase2.CommandTimeout = 60;
                        MySqlDataReader reader2;
                        try
                        {
                            reader2 = commandDatabase2.ExecuteReader();
                            if (reader2.HasRows)
                            {
                                while (reader2.Read())
                                {
                                    resultado1 = reader2.GetString(0);
                                }
                            }
                            closeCon();
                            return resultado1;
                        }
                        catch (Exception ex)
                        {
                            closeCon();
                            return null;
                        }
                    }
                }
                closeCon();
                return resultado1;
            }
            catch (Exception ex)
            {
                closeCon();
                return null;
            }
        }

        public string getEmpresaEmitio2Meses(string ruc, string cadenaConexion)
        {
            string query1 = "select id from peprodpse.companies c where ruc = " + ruc;
            string id = "";
            string resultado1 = "";
            //string resul = 0;
            int folios21 = 0;
            int folios20 = 0;
            List<String> listDoc = new List<string>();
            conection(cadenaConexion);
            MySqlCommand commandDatabase = new MySqlCommand(query1, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = reader.GetString(0);
                        string query2 = "select vigencia_fin from peprodpse.configurations c2 where  company_id =" + id;
                        string resultado2 = "";
                        //closeCon();
                        conection(cadenaConexion);
                        MySqlCommand commandDatabase2 = new MySqlCommand(query2, databaseConnection);
                        commandDatabase2.CommandTimeout = 60;
                        MySqlDataReader reader2;
                        try
                        {
                            reader2 = commandDatabase2.ExecuteReader();
                            if (reader2.HasRows)
                            {
                                while (reader2.Read())
                                {
                                    resultado1 = reader2.GetString(0);
                                }
                            }
                            closeCon();
                            return resultado1;
                        }
                        catch (Exception ex)
                        {
                            closeCon();
                            return null;
                        }
                    }
                }
                closeCon();
                return resultado1;
            }
            catch (Exception ex)
            {
                closeCon();
                return null;
            }
        }

        #endregion

        #region OSE Consulta Empresas

        public String getEmpresaOSETipoPlan(string ruc, string cadenaConexion)
        {
            string query = " select t.tipoplan from peproduccionose.taxpayers t where t.ruc = '" + ruc + "' limit 1";
            string resultado = "";
            List<String> listDoc = new List<string>();
            conection(cadenaConexion);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        resultado = reader.GetString(0);
                    }
                }
                else
                {
                    resultado = "No se encontraron datos.";
                }
                closeCon();
                return resultado;
            }
            catch (Exception ex)
            {
                closeCon();
                return null;
            }
        }

        public String getEmpresaOSEPSE(string ruc, string cadenaConexion)
        {
            string query = " select t.pse from peproduccionose.taxpayers t where t.ruc = '" + ruc + "' limit 1";
            string resultado = "NO";
            List<String> listDoc = new List<string>();
            conection(cadenaConexion);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if(reader.GetInt32(0) == 1)
                            resultado = "SI";
                    }
                }
                else
                {
                    resultado = "No se encontraron datos.";
                }
                closeCon();
                return resultado;
            }
            catch (Exception ex)
            {
                closeCon();
                return null;
            }
        }

        public string getEmpresaFoliosOSE(string ruc, string cadenaConexion)
        {
            string query1 = " select t.folios_purchased, t.folios_assigned from peproduccionose.taxpayers t where t.ruc = '" + ruc + "' limit 1";
            string resultado1 = "";
            int Comprados = 0;
            int folios21 = 0;
            List<String> listDoc = new List<string>();
            conection(cadenaConexion);
            MySqlCommand commandDatabase = new MySqlCommand(query1, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Comprados = reader.GetInt32(0);
                        folios21 = reader.GetInt32(1);
                    }
                }
                closeCon();
                return (Comprados - folios21).ToString();
            }
            catch (Exception ex)
            {
                closeCon();
                return null;
            }
        }

        public string getEmpresaOSEFoliosVigencia(string ruc, string cadenaConexion)
        {
            string query1 = " select t.validity_end from peproduccionose.taxpayers t where t.ruc = '" + ruc + "' limit 1";
            string resultado1 = "";
            conection(cadenaConexion);
            MySqlCommand commandDatabase = new MySqlCommand(query1, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        resultado1 = reader.GetString(0);
                    }
                }
                closeCon();
                return resultado1;
            }
            catch (Exception ex)
            {
                closeCon();
                return null;
            }
        }


        #endregion

        #region Consulta Servicio

        public int getFact95(string desde, string hasta, string cadenaConexion)
        {
            string query = "select COUNT(*) from peprodpse.invoices i where status = 95 and activo = 1 and created_at BETWEEN '" + desde + "' and '" + hasta + "'";
            int resultado = 0;
            List<String> listDoc = new List<string>();
            conection(cadenaConexion);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        resultado = reader.GetInt32(0);
                    }
                }
                closeCon();
                return resultado;
            }
            catch (Exception ex)
            {
                closeCon();
                return 0;
            }
        }

        public int getNotes95(string desde, string hasta, string cadenaConexion)
        {
            string query = "select COUNT(*) from peprodpse.notes n where status = 95 and activo = 1 and created_at BETWEEN '" + desde + "' and '" + hasta + "'";
            int resultado = 0;
            List<String> listDoc = new List<string>();
            conection(cadenaConexion);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        resultado = reader.GetInt32(0);
                    }
                }
                closeCon();
                return resultado;
            }
            catch (Exception ex)
            {
                closeCon();
                return 0;
            }
        }

        public int getGR95(string desde, string hasta, string cadenaConexion)
        {
            string query = "select COUNT(*) from peprodpse.despatch_advice where status = 95 and activo = 1 and created_at BETWEEN '" + desde + "' and '" + hasta + "'";
            int resultado = 0;
            List<String> listDoc = new List<string>();
            conection(cadenaConexion);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        resultado = reader.GetInt32(0);
                    }
                }
                closeCon();
                return resultado;
            }
            catch (Exception ex)
            {
                closeCon();
                return 0;
            }
        }

        public int getGR98(string desde, string hasta, string cadenaConexion)
        {
            string query = "select COUNT(*) from peprodpse.despatch_advice where status = 98 and activo = 1 and created_at BETWEEN '" + desde + "' and '" + hasta + "'";
            int resultado = 0;
            List<String> listDoc = new List<string>();
            conection(cadenaConexion);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        resultado = reader.GetInt32(0);
                    }
                }
                closeCon();
                return resultado;
            }
            catch (Exception ex)
            {
                closeCon();
                return 0;
            }
        }

        #endregion

    }
}
