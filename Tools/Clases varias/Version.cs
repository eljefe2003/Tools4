using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    internal class Version
    {
        int id, estado, leido;
        string versionNum, asunto;

        public int Id { get => id; set => id = value; }
        public int Estado { get => estado; set => estado = value; }
        public int Leido { get => leido; set => leido = value; }
        public string Asunto { get => asunto; set => asunto = value; }
        public string VersionNum { get => versionNum; set => versionNum = value; }
    }
}
