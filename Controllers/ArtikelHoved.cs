using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artikler.Entities;

namespace Artikler.Controllers
{
    public class ArtikelHoved
    {
        public ArtikelHoved(Artikel artikel)
        {
            Id = artikel.Id;
            Forfatter = artikel.Forfatter;
            Overskrift = artikel.Overskrift;
            Årstal = artikel.Årstal;
        }
        public int Id { get; }
        public string Forfatter { get; set; }
        public string Overskrift { get; set; }
        public int Årstal { get; set; }
    }
}
