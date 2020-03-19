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

        [Route("/Artikel")]
        public IActionResult Documentation()
        {
            var host = ControllerContext.HttpContext.Request.Host.ToString();
            var actions = new Dictionary<string, string>();
            actions.Add("List",  $"{host}/Artikler/List");

            return new JsonResult(actions);
        }

        /// <summary>
        /// Liste af artikler
        /// </summary>
        /// <param name="skip">Springer over det angivne antal artikler</param>
        /// <param name="take">begrænser antallet af artikler i resultatsættet</param>
        /// <returns></returns>
        [HttpGet]
        public Task<List<ArtikelHoved>> List(int skip = 0, int take = 10)
        {
            if (skip <= 0) skip = 0;
            if (take <= 0) take = 1;

            return _context
                .Artikler
                .OrderByDescending(a => a.Årstal)
                .ThenBy(a => a.Forfatter)
                .ThenBy(a => a.Overskrift)
                .ThenBy(a => a.Id)
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
            _context.Artikler.Add(new Artikel
            {
                Årstal = year,
                Forfatter = author,
                Overskrift = title,
                Tekst = content
            });
            _context.SaveChanges();
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
        public async void Update(Artikel artikel)
        {
            if (null != artikel?.Id)
            {
                var a = await _context.Artikler.FindAsync(artikel.Id);
                a.Årstal = artikel.Årstal;
                a.Forfatter = artikel.Forfatter;
                a.Overskrift = artikel.Overskrift;
                a.Tekst = artikel.Tekst;

                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Søg efter artikler
        /// </summary>
        /// <param name="skip">Springer over det angivne antal artikler</param>
        /// <param name="take">begrænser antallet af artikler i resultatsættet</param>
        /// <param name="query">Søge kriterie</param>
        /// <returns></returns>
        [HttpGet]
        public Task<List<ArtikelHoved>> Search(string query, int skip = 0, int take = 100)
        {
            if (string.IsNullOrEmpty(query))
            {
                RedirectToAction("List");
            }

            return _context
                .Artikler
                .OrderByDescending(a => a.Årstal)
                .ThenBy(a => a.Forfatter)
                .ThenBy(a => a.Overskrift)
                .ThenBy(a => a.Id)
                .Where(a => a.Forfatter.Contains(query) || a.Overskrift.Contains(query) || a.Tekst.Contains(query))
                .Skip(skip)
                .Take(take)
                .Select(a => new ArtikelHoved(a))
                .ToListAsync();
        }

    }
}
