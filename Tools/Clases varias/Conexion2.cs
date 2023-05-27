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

        public void saveVersion(Version ver, bool inserta)
        {
            string sql = "";
            bool upt = false;
            try
            {
                if (inserta)
                {
                    upt = true;
                    sql = "INSERT INTO version (version_num, asunto, estado, leido) VALUES (@p1,@p2,@p3,@p4)";
                }
                else
                {
                    sql = "UPDATE version set version_num=@p1, asunto=@p2, estado=@p3, leido=@p4 WHERE id=@p5";
                }
                conection();
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                cmd.Parameters.Add(new SQLiteParameter("@p1", ver.VersionNum));
                cmd.Parameters.Add(new SQLiteParameter("@p2", ver.Asunto));
                cmd.Parameters.Add(new SQLiteParameter("@p3", ver.Estado));
                cmd.Parameters.Add(new SQLiteParameter("@p4", ver.Leido));
                if (!upt)
                {
                    cmd.Parameters.Add(new SQLiteParameter("@p5", ver.Id));
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
                sql = "UPDATE version set leido=1";
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

        //public List<Anuncio> getAllVersion()
        //{
        //    List<Anuncio> lst = new List<Anuncio>();
        //    Anuncio anun;
        //    try
        //    {
        //        conection();
        //        string query = "";
        //        query = "select * from version WHERE estado=1";
        //        SQLiteCommand cmd = new SQLiteCommand(query, con);
        //        SQLiteDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            anun = new Anuncio();
        //            anun.Id = Convert.ToString(reader[0]);
        //            anun.Mensaje = Convert.ToString(reader.GetString(1));
        //            anun.Leido = Convert.ToString(reader[2]);
        //            anun.Version = Convert.ToString(reader.GetString(3));
        //            anun.Status = Convert.ToString(reader[4]);
        //            anun.Asunto = Convert.ToString(reader.GetString(5));                 
        //            lst.Add(anun);
        //        }
        //        closeCon();
        //        return lst;
        //    }
        //    catch (Exception ex)
        //    {
        //        closeCon();
        //        return lst;
        //        throw new Exception(ex.Message);
        //    }
        //}

        public int getAllAnunciosSinLeer()
        {
            int contador = 0;
            try
            {
                conection();
                string query = "";
                query = "select * from version WHERE estado=1 and leido=0";
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

        public List<Version> getAllVersion()
        {
            List<Version> lst = new List<Version>();
            Version ver;
            try
            {
                conection();
                string query = "";
                query = "select * from version WHERE estado=1 order by id desc";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ver = new Version();
                    ver.Id = Convert.ToInt32(reader[0]);
                    ver.VersionNum = Convert.ToString(reader[1]);
                    ver.Asunto = Convert.ToString(reader[2]);
                    ver.Estado = Convert.ToInt32(reader[3]);
                    ver.Leido = Convert.ToInt32(reader[4]);
                    lst.Add(ver);
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

        public Version getVersion(string version)
        {
            Version ver = null;
            try
            {
                conection();
                string query = "";
                query = "select * from version WHERE estado=1 and version_num =" + version;
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ver = new Version();
                    ver.Id = Convert.ToInt32(reader[0]);
                    ver.VersionNum = Convert.ToString(reader[1]);
                    ver.Asunto = Convert.ToString(reader[2]);
                    ver.Estado = Convert.ToInt32(reader[3]);
                    ver.Leido = Convert.ToInt32(reader[4]);
                }
                closeCon();
                return ver;
            }
            catch (Exception ex)
            {
                closeCon();
                return ver;
                throw new Exception(ex.Message);
            }
        }

        public Version getVersionID(string id)
        {
            Version ver = null;
            try
            {
                conection();
                string query = "";
                query = "select * from version WHERE estado=1 and id =" + id;
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ver = new Version();
                    ver.Id = Convert.ToInt32(reader[0]);
                    ver.VersionNum = Convert.ToString(reader[1]);
                    ver.Asunto = Convert.ToString(reader[2]);
                    ver.Estado = Convert.ToInt32(reader[3]);
                    ver.Leido = Convert.ToInt32(reader[4]);
                }
                closeCon();
                return ver;
            }
            catch (Exception ex)
            {
                closeCon();
                return ver;
                throw new Exception(ex.Message);
            }
        }

        public void saveMensaje(Comentario com, bool inserta)
        {
            string sql = "";
            bool upt = false;
            try
            {
                if (inserta)
                {
                    upt = true;
                    sql = "INSERT INTO mensaje (mensaje, version, status, tipo) VALUES (@p1,@p2,@p3,@p4)";
                }
                else
                {
                    sql = "UPDATE mensaje set mensaje=@p1, version=@p2, status=@p3, tipo=@p4 WHERE id=@p5";
                }
                conection();
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                cmd.Parameters.Add(new SQLiteParameter("@p1", com.Mensaje));
                cmd.Parameters.Add(new SQLiteParameter("@p2", com.VersionClase.Id));
                cmd.Parameters.Add(new SQLiteParameter("@p3", com.Status));
                cmd.Parameters.Add(new SQLiteParameter("@p4", com.Tipo));

                if (!upt)
                {
                    cmd.Parameters.Add(new SQLiteParameter("@p5", com.Id));
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

        public List<Comentario> getAllComentarios(int idVersion)
        {
            List<Comentario> lst = new List<Comentario>();
            Comentario com;
            try
            {
                conection();
                string query = "";
                query = "select * from mensaje WHERE status=1 and version="+ idVersion;
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    com = new Comentario();
                    com.Id = Convert.ToInt32(reader[0]);
                    com.Mensaje = Convert.ToString(reader[1]);
                    com.VersionClase = getVersionID(Convert.ToString(reader[2]));
                    com.Status = Convert.ToInt32(reader[3]);
                    com.Tipo = Convert.ToString(reader[4]);

                    lst.Add(com);
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
