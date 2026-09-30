using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ClassLibrary1.Models;

namespace ClassLibrary1.Data
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Cancion> Canciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\databases\\plataformaMusicaDB.db");
        }
    }
}
