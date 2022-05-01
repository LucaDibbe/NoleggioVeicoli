using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoli.Business.Models
{
    public class VeicoliModelView
    {
        public int Id { get; set; }
        public int? IdMarca { get; set; }
        public string Marca { get; set; }
        public string Alimentazione { get; set; }
        public int? IdAlimentazione { get; set; }
        public string Modello { get; set; }
        public string Targa { get; set; }
        public DateTime? Immatricolazione { get; set; }
        public string Noleggiato { get; set; }
        public string Nominativo { get; set; }
        public string Note { get; set; }

    }
}
