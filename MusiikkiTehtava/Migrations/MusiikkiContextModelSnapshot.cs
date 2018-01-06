﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MusiikkiTehtava.Models;
using System;

namespace MusiikkiTehtava.Migrations
{
    [DbContext(typeof(MusiikkiContext))]
    partial class MusiikkiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MusiikkiTehtava.Models.Albumi", b =>
                {
                    b.Property<int>("AlbumiId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Julkaisuvuosi");

                    b.Property<string>("Nimi");

                    b.HasKey("AlbumiId");

                    b.ToTable("Albumit");
                });

            modelBuilder.Entity("MusiikkiTehtava.Models.Artisti", b =>
                {
                    b.Property<int>("ArtistiId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Genre");

                    b.Property<string>("Nimi");

                    b.HasKey("ArtistiId");

                    b.ToTable("Artistit");
                });

            modelBuilder.Entity("MusiikkiTehtava.Models.Kappale", b =>
                {
                    b.Property<long>("KappaleId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AlbumiId");

                    b.Property<int?>("ArtistiId");

                    b.Property<int>("Kesto");

                    b.Property<string>("Nimi");

                    b.HasKey("KappaleId");

                    b.HasIndex("AlbumiId");

                    b.HasIndex("ArtistiId");

                    b.ToTable("Kappaleet");
                });

            modelBuilder.Entity("MusiikkiTehtava.Models.Kappale", b =>
                {
                    b.HasOne("MusiikkiTehtava.Models.Albumi", "Albumi")
                        .WithMany("Kappalelistaus")
                        .HasForeignKey("AlbumiId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MusiikkiTehtava.Models.Artisti", "Artisti")
                        .WithMany("Kappaleet")
                        .HasForeignKey("ArtistiId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
