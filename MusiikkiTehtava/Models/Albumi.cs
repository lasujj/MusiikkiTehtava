using System.Collections.Generic;

namespace MusiikkiTehtava.Models
{
    public class Albumi
    {
        public int AlbumiId { get; set; }
        public string Nimi { get; set; }
        public int Julkaisuvuosi { get; set; }
        public List<Kappale> Kappalelistaus { get; set; }
    }
}
