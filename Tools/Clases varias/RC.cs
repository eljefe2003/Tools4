using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class RC
    {
        string id, ruc, supplier, horaCreacionOse, horaEnvioSunat, msjSunat, identificador, docsInformados;

        public string Id { get => id; set => id = value; }
        public string Ruc { get => ruc; set => ruc = value; }
        public string Supplier { get => supplier; set => supplier = value; }
        public string HoraCreacionOse { get => horaCreacionOse; set => horaCreacionOse = value; }
        public string HoraEnvioSunat { get => horaEnvioSunat; set => horaEnvioSunat = value; }
        public string MsjSunat { get => msjSunat; set => msjSunat = value; }
        public string Identificador { get => identificador; set => identificador = value; }
        public string DocsInformados { get => docsInformados; set => docsInformados = value; }
    }
}
