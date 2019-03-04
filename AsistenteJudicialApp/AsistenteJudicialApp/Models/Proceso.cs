using System;
using System.Collections.Generic;
using System.Text;

namespace AsistenteJudicialApp.Models
{
    class Proceso
    {
        public int id { get; set; }
        public string radicacion { get; set; }
        public string juzgado { get; set; }
        public string demandante { get; set; }
        public string demandado { get; set; }
    }
}
