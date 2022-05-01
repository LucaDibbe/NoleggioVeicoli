using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoleggioVeicoli.Business.Models
{
    public class RicercaVeicoliModel
    {
        public int? Id { get; set; }
        public string Marca { get; set; }
        public int? IdMarca { get; set; }
        public string Alimentazione { get; set; }
        public int? IdAlimentazione { get; set; }
        public string Modello { get; set; }
        public string Targa { get; set; }
        public DateTime? Immatricolazione { get; set; }
        public DateTime? ImmatricolazioneDA { get; set; }
        public DateTime? ImmatricolazioneA { get; set; }
        public string Noleggiato { get; set; }
        public string Note { get; set; }



    }
}
