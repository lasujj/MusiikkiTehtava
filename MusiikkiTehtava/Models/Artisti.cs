using System.Collections.Generic;


namespace MusiikkiTehtava.Models
{
    public class Artisti
    {
        public int ArtistiId { get; set; }
        public string Nimi { get; set; }
        public string Genre { get; set; }

        public List<Kappale> Kappaleet { get; set; }
    }
}