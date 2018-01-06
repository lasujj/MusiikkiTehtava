# MusiikkiTehtava
Musiikkirajapinta on tehty Microsoft Visual studiolla käyttämällä .NET Core 2. Musiikkirajapintaan on mahdollista tallentaa musiikki-metadataa kolmeen eri luokkaan: Artisti, Albumi ja Kappale.

Artistilla on nimi, genre ja kappalelistaus. Kappaleita voi määrittää artistille, joten poistaessa artisti, myös sen kappaleet katoavat.

Albumilla on nimi, julkaisuvuosi ja kappalelistaus. Albumilla ei ole artistia, joka yksinkertaistaa asioita, jos albumilla on monia artisteja. Kappaleet ovat määritetty albumille, joten poistaessa albumi, myös sen kappaleet katoavat.

Kappaleella on nimi, kesto, sekä albumi ja artisti. Kappaleet voidaan helposti liittää artistiin ja albumiin niille määritettyjen id:iden perusteella.

Ennen testaamisen aloittamista täytyy käydä vaihtamassa Startup.cs tiedostosta connection stringiin oman sql palvelimen osoite, jonne uusi tietokanta tehdään. Tämän jälkeen täytyy kirjoittaa Package Manager Consoleen komento: update-database. Package manager console löytyy yläpalkista Tools/NuGet Package Manager. Jos tietokanta on tyhjä, sinne tulee seeddatana muutama valmiiksi tehty albumi, artisti ja kappale.

Rajapintaan on liitetty Swagger-paketti, joka helpottaa rajapinnan testaamista. Ajaessa ohjelma läpi, testaaja ohjataan suoraa swagger sivustolle, jossa on pääsee koittamaan, mitä eri pyynnöt tekevät rajapinnalle.

Kaikilla luokille toimii samat pyynnöt, paitsi kappaleen GET-pyyntöön on lisätty haku, mitä käyttämällä voidaan etsiä kappaletta genren, artistin nimen, albumin nimen tai kappaleen nimen perusteella.

