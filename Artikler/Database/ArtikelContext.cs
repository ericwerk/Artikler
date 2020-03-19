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

        public void AddSeedData()
        {
            var firstnames = new List<string> { "Eric", "Ole", "Mette", "Janne" };
            var lastnames  = new List<string> { "Werk", "Caprani", "Jensen", "d'Arc" };
            var attributes = new List<string> { "Greatness", "Hubris", "Beauty", "Courage" };
            var loremipsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. ".Split(". ");
            var rand = new Random();

            for (int i=0; i<12; i++)
            {
                Artikler.Add(new Artikel
                {
                    Årstal = DateTime.Today.Year - rand.Next(5),
                    Forfatter = $"{firstnames[rand.Next(4)]} {lastnames[rand.Next(4)]}",
                    Overskrift = $"The {attributes[rand.Next(4)]} of {lastnames[rand.Next(4)]}",
                    Tekst = $"{firstnames[rand.Next(4)]} is known for {attributes[rand.Next(4)].ToLower()}, but have you heard about {lastnames[rand.Next(4)]}? Not all is well in the land of {attributes[rand.Next(4)]}. {loremipsum[rand.Next(loremipsum.Length)]}."
                });
            }
            SaveChanges();
        }
    }
}
