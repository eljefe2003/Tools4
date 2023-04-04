using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Clases_varias
{
    public class Anuncio
    {
        string id, status, leido;
        string mensaje, asunto, version;

        public string Id { get => id; set => id = value; }
        public string Status { get => status; set => status = value; }
        public string Leido { get => leido; set => leido = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
        public string Asunto { get => asunto; set => asunto = value; }
        public string Version { get => version; set => version = value; }
    }
}
