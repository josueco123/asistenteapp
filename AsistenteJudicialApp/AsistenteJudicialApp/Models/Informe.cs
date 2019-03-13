using System;
using System.Collections.Generic;
using System.Text;

namespace AsistenteJudicialApp.Models
{
    class Informe
    {
        public int id { get; set; }
        public string fecha { get; set; }
        public string mensaje { get; set; }
        public string proceso_id { get; set; }
        public string user_id { get; set; }
    }
}
