﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleSongbook;

#nullable disable

namespace SimpleSongbook.Migrations
{
    [DbContext(typeof(SongContext))]
    partial class SongContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SimpleSongbook.Song", b =>
                {
                    b.Property<int>("SongID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SongID"));

                    b.Property<string>("Chords")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lyrics")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SongID");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            SongID = 1,
                            Chords = "C a F G\n C a F G\n C a F G",
                            Lyrics = "Cześć, robię test\nWPF fajny nie jest\nMam już dość go\nprosze zabierzcie go",
                            Title = "Testowa piosenka"
                        },
                        new
                        {
                            SongID = 2,
                            Chords = "nicG\n C a F G\n niiiiiiic",
                            Lyrics = "Cześć, robię nic\nnic fajny jest\nMam już dość go\nprosze zabierzcie go",
                            Title = "Zmęczona piosenka"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
