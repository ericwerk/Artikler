using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artikler.Database;
using Artikler.Entities;
using Artikler.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Artikler.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ArtikelController : ControllerBase
    {
        private readonly ILogger<ArtikelController> _logger;
        private readonly ArtikelContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="context"></param>
        public ArtikelController(ILogger<ArtikelController> logger, ArtikelContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Liste af artikler
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        [HttpGet]
        public Task<List<ArtikelHoved>> List(int skip = 0, int take = 100)
        {
            if (skip <= 0) skip = 0;
            if (take <= 0) take = 1;

            return _context
                .Artikler
                .OrderByDescending(a => a.Årstal)
                .ThenBy(a => a.Forfatter)
                .Skip(skip)
                .Take(take)
                .Select( a => new ArtikelHoved(a))
                .ToListAsync();
        }
        /// <summary>
        /// Hent en artikel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ValueTask<Artikel> Get(int id)
        {
            return _context.Artikler.FindAsync(id);
        }

        /// <summary>
        /// Tilføj en ny artikel
        /// </summary>
        /// <param name="year">Arstallet artiklen er skevet</param>
        /// <param name="author">Forfatter</param>
        /// <param name="title">En god overskrift</param>
        /// <param name="content">En fed historie</param>
        /// <returns></returns>
        [HttpPost]
        public void Create(int year, string author, string title, string content)
        {
            var x = _context.Artikler.Add(new Artikel
            {
                Årstal = year,
                Forfatter = author,
                Overskrift = title,
                Tekst = content
            });
            _context.SaveChanges();

        }

        /// <summary>
        /// Søg efter artikler
        /// </summary>
        /// <param name="query">Søge kriterie</param>
        /// <returns></returns>
        [HttpGet]
        public Task<List<ArtikelHoved>> Search(string query)
        {
            return _context
                .Artikler
                .OrderByDescending(a => a.Årstal)
                .ThenBy(a => a.Forfatter)
                .Where(a => a.Forfatter.Contains(query) || a.Overskrift.Contains(query) || a.Tekst.Contains(query))
                .Select(a => new ArtikelHoved(a))
                .ToListAsync();
        }

    }
}
