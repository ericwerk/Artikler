using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artikler.Entities
{
    public class Artikel
    {
        public int Id { get; set; }
        public string Forfatter { get; set; }
        public string Overskrift { get; set; }
        public string Tekst { get; set; }
        public int Årstal { get; set; }
    }
}
