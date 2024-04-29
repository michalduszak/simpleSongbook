using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSongbook
{
    class SongContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Songbook;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().HasData(
                new Song { SongID = 1, Title = "Testowa piosenka", Lyrics = "Cześć, robię test\nWPF fajny nie jest\nMam już dość go\nprosze zabierzcie go", Chords = "C a F G\n C a F G\n C a F G" },
                new Song { SongID = 2, Title = "Zmęczona piosenka", Lyrics = "Cześć, robię nic\nnic fajny jest\nMam już dość go\nprosze zabierzcie go", Chords = "nicG\n C a F G\n niiiiiiic" }
                );
        }
    }
}
