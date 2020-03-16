using Artikler.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artikler.Database
{
    public class ArtikelContext : DbContext
    {
        public ArtikelContext(DbContextOptions<ArtikelContext> options)
            : base(options)
        {
        }

        public DbSet<Artikel> Artikler { get; set; }
    }
}
