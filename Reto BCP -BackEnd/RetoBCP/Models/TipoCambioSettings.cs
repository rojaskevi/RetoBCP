using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetoBCP.Models
{
    public class TipoCambioSettings : ITipoCambioSettings
    {
        public string  Server{ get; set; }
        public string Database { get; set; }
        public string Collection { get; set; }
    }

    public interface ITipoCambioSettings //categorizacion-inyeccion de dependencias
    {
        string Server { get; set; }
        string Database { get; set; }
        string Collection { get; set; }
    }
}
