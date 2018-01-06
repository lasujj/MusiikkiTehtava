using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusiikkiTehtava.Models;

namespace MusiikkiTehtava.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MusiikkiContext(
                serviceProvider.GetRequiredService<DbContextOptions<MusiikkiContext>>()))
            {
                // Etsii onko albumeita, kappaleita tai artisteja
                if (context.Albumit.Any() || context.Artistit.Any() || context.Kappaleet.Any())
                {
                    return;
                }

                context.Artistit.AddRange(

                    new Artisti { Nimi = "Adele", Genre = "Pop" },
                    new Artisti { Nimi = "Rihanna", Genre = "Pop" },
                    new Artisti { Nimi = "Metallica", Genre = "Rock" },
                    new Artisti { Nimi = "Cheek", Genre = "Rap" },
                    new Artisti { Nimi = "JVG", Genre = "Rap" },
                    new Artisti { Nimi = "Hevisaurus", Genre = "Hevi" }
                );
                context.SaveChanges();

                context.Albumit.AddRange(

                    new Albumi { Nimi = "Pop Kokoelma", Julkaisuvuosi = 2001 },
                    new Albumi { Nimi = "Rock Kokoelma", Julkaisuvuosi = 1994 },
                    new Albumi { Nimi = "Rap Kokoelma", Julkaisuvuosi = 2010 },
                    new Albumi { Nimi = "Hevisaurus Tulee", Julkaisuvuosi = 2002 },
                    new Albumi { Nimi = "Hevisaurus Tyrannosaurus", Julkaisuvuosi = 2002 }
                
                );
                context.SaveChanges();

                context.Kappaleet.AddRange(

                    new Kappale { Nimi = "Rolling", AlbumiId = 1, ArtistiId = 1, Kesto = 300 },
                    new Kappale { Nimi = "SOS", AlbumiId = 1, ArtistiId = 2, Kesto = 300 },
                    new Kappale { Nimi = "Sandman", AlbumiId = 2, ArtistiId = 3, Kesto = 300 },
                    new Kappale { Nimi = "Timantit", AlbumiId = 3, ArtistiId = 4, Kesto = 300 },
                    new Kappale { Nimi = "Koutsi", AlbumiId = 3, ArtistiId = 5, Kesto = 300 },
                    new Kappale { Nimi = "Dinosaurus", AlbumiId = 4, ArtistiId = 6, Kesto = 300 },
                    new Kappale { Nimi = "Velociraptor", AlbumiId = 4, ArtistiId = 6, Kesto = 300 } ,
                    new Kappale { Nimi = "Strutsit on dinoja", AlbumiId = 5, ArtistiId = 6, Kesto = 300 },
                    new Kappale { Nimi = "Luola", AlbumiId = 5, ArtistiId = 6, Kesto = 300 }
                  
                );


                context.SaveChanges();
            }
        }
    }
}
