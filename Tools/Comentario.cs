using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    internal class Comentario
    {
        int id,  status;
        string mensaje, tipo;
        Version versionClase;
        public int Id { get => id; set => id = value; }
        public int Status { get => status; set => status = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
        public Version VersionClase { get => versionClase; set => versionClase = value; }
        public string Tipo { get => tipo; set => tipo = value; }
    }
}
