

namespace MusiikkiTehtava.Models
{
    
    public class Kappale
    {
        public long KappaleId { get; set; }
        public string Nimi { get; set; }
        public int Kesto { get; set; }

        public virtual Albumi Albumi { get; set; }
        public int? AlbumiId { get; set; }
        public virtual Artisti Artisti { get; set; }
        public int? ArtistiId { get; set; }
    }
}
