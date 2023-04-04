using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Clases_varias;
using Microsoft.Data.Sqlite;

namespace Tools
{
    internal class Conexion2
    {
        private SQLiteConnection con;

        public void conection()
        {
            try
            {
                con = new SQLiteConnection("Data Source = .\\Anuncios.db");
                con.Open();
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
        }

        public void closeCon()
        {
            if (con != null)
            {
                con.Close();
                con = null;
            }
        }

        public void saveAnuncio(Anuncio anun, bool inserta)
        {
            string sql = "";
            bool upt = false;
            try
            {
                if (inserta)
                {
                    upt = true;
                    sql = "INSERT INTO Mensajes (asunto, mensaje, leido, version, status) VALUES (@p1,@p2,@p3,@p4,@p5)";
                }
                else
                {
                    sql = "UPDATE Mensajes set asunto=@p1, mensaje=@p2, leido=@p3, version=@p4, status=@p5 WHERE id=@p6";
                }
                conection();
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                cmd.Parameters.Add(new SQLiteParameter("@p1", anun.Asunto));
                cmd.Parameters.Add(new SQLiteParameter("@p2", anun.Mensaje));
                cmd.Parameters.Add(new SQLiteParameter("@p3", anun.Leido));
                cmd.Parameters.Add(new SQLiteParameter("@p4", anun.Version));
                cmd.Parameters.Add(new SQLiteParameter("@p5", anun.Status));
                if (!upt)
                {
                    cmd.Parameters.Add(new SQLiteParameter("@p6", anun.Id));
                }

                int y = cmd.ExecuteNonQuery();
                Console.WriteLine("Result: {0}", y);
                closeCon();
            }
            catch (Exception ex)
            {
                closeCon();
                throw new Exception(ex.Message);
            }
        }

        public void saveAnuncioTodosLeidos()
        {
            string sql = "";
            try
            {
                sql = "UPDATE Mensajes set leido=1";
                conection();
                SQLiteCommand cmd = new SQLiteCommand(sql, con);    
                int y = cmd.ExecuteNonQuery();
                Console.WriteLine("Result: {0}", y);
                closeCon();
            }
            catch (Exception ex)
            {
                closeCon();
                throw new Exception(ex.Message);
            }
        }


        public List<Anuncio> getAllAnuncios()
        {
            List<Anuncio> lst = new List<Anuncio>();
            Anuncio anun;
            try
            {
                conection();
                string query = "";
                query = "select * from mensajes WHERE status=1";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    anun = new Anuncio();
                    anun.Id = Convert.ToString(reader[0]);
                    anun.Mensaje = Convert.ToString(reader.GetString(1));
                    anun.Leido = Convert.ToString(reader[2]);
                    anun.Version = Convert.ToString(reader.GetString(3));
                    anun.Status = Convert.ToString(reader[4]);
                    anun.Asunto = Convert.ToString(reader.GetString(5));                 
                    lst.Add(anun);
                }
                closeCon();
                return lst;
            }
            catch (Exception ex)
            {
                closeCon();
                return lst;
                throw new Exception(ex.Message);
            }
        }

        public int getAllAnunciosSinLeer()
        {
            int contador = 0;
            try
            {
                conection();
                string query = "";
                query = "select * from mensajes WHERE status=1 and leido=0";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    contador++;
                }
                closeCon();
                return contador;
            }
            catch (Exception ex)
            {
                closeCon();
                return contador;
                throw new Exception(ex.Message);
            }
        }


        public Anuncio getAnuncio(string id)
        {
            Anuncio anun = null;
            try
            {
                conection();
                string query = "";
                query = "select * from mensajes WHERE status=1 and id =" + id;
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    anun = new Anuncio();
                    anun.Id = Convert.ToString(reader[0]);
                    anun.Mensaje = Convert.ToString(reader.GetString(1));
                    anun.Leido = Convert.ToString(reader[2]);
                    anun.Version = Convert.ToString(reader.GetString(3));
                    anun.Status = Convert.ToString(reader[4]);
                    anun.Asunto = Convert.ToString(reader.GetString(5));
                }
                closeCon();
                return anun;
            }
            catch (Exception ex)
            {
                closeCon();
                return anun;
                throw new Exception(ex.Message);
            }
        }

        //public Documento getDocument(string serie_correlativo)
        //{
        //    List<Documento> lst = new List<Documento>();
        //    Documento doc = new Documento();
        //    try
        //    {
        //        conection();
        //        string query = "";
        //        query = "SELECT * FROM documento WHERE serie_correlativo like ('%" + serie_correlativo + "%') and status=1 and statusDfacture like ('0%') and (serie_correlativo not like ('RA%') or serie_correlativo not like ('%-RA%'))";

        //        SQLiteCommand cmd = new SQLiteCommand(query, con);
        //        SQLiteDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            //doc = new Documento();
        //            doc.Id = Convert.ToString(reader[0]);
        //            doc.SerieCorrelativo = Convert.ToString(reader.GetString(1));
        //            doc.EstadoDfacture = Convert.ToString(reader.GetString(2));
        //            doc.EstadoSunat = Convert.ToString(reader.GetString(3));
        //            doc.Xml = Convert.ToString(reader[4]);
        //            doc.Pdf = Convert.ToString(reader[5]);
        //            doc.Cdr = Convert.ToString(reader[6]);
        //            doc.Estado = Convert.ToString(reader[7]);
        //            doc.NombreARchivoTxt1 = Convert.ToString(reader.GetString(8));
        //            //lst.Add(doc);
        //        }
        //        closeCon();
        //        return doc;
        //    }
        //    catch (Exception ex)
        //    {
        //        closeCon();
        //        return doc;
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public void updateFabrica()
        //{
        //    string sql = "";
        //    try
        //    {

        //        sql = "UPDATE Documento set status=0";
        //        conection();
        //        SQLiteCommand cmd = new SQLiteCommand(sql, con);
        //        int y = cmd.ExecuteNonQuery();
        //        Console.WriteLine("Result: {0}", y);
        //        closeCon();
        //    }
        //    catch (Exception ex)
        //    {
        //        closeCon();
        //        throw new Exception(ex.Message);
        //    }
        //}

    }
}
