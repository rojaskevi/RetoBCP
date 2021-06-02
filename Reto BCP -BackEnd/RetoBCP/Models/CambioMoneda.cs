using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetoBCP.Models
{
    public class CambioMoneda
    {       
        public string MonedaOrigen { get; set; }
        public string MonedaDestino { get; set; }       
        public decimal Cambio { get; set; }
        public decimal Monto { get; set; }

        public decimal MontoCambiado { get; set; }


    }
}
