using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NekoSpace.Data.Interfaces;
using NekoSpace.Seed.Interfaces;
using NekoSpaceList.Models.Anime;

namespace NekoSpace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimesController : ControllerBase
    {
        private IAnimeRepository _animeRepository;
        private IDBSeed<Anime> _idbSeed;
        public AnimesController(IAnimeRepository animeRepository, IDBSeed<Anime> idbSeed)
        {
            _animeRepository = animeRepository;
            _idbSeed = idbSeed;
        }

        // GET: AnimesController
        [HttpGet]
        public IEnumerable<Anime> Index()
        {
            var animes = _animeRepository.GetAll().Take(100).ToList();

            var a = _animeRepository.GetAll().ToList();
            return animes;
        }

        [HttpGet("/runSeeding")]
        public void RunSeeding()
        {
            var animes = _idbSeed.RunSeed().ToList();

            int itemCount = animes.Count();
            int offset = 100;
            int page = 1;
            int limit = 1000;

            while (page * offset <= itemCount)
            {
                for (int i = offset * (page - 1); i < offset * page; i++)
                {
                    _animeRepository.Insert(animes[i]);
                }
                page++;
                _animeRepository.Save();
            }

            /*foreach (var anime in animes)
            {
                _animeRepository.Insert(anime);
            }
            _animeRepository.Save();*/
        }

        // GET: AnimesController/Details/5
        /*public ActionResult Details(int id)
        {
            //return View();
        }*/

        // GET: AnimesController/Create
        [HttpPost]
        public void Create(Anime anime)
        {
            _animeRepository.Insert(anime);
        }

        // POST: AnimesController/Create
        /*[HttpPost]
        [ValidateAntiForgeryToken]*/
        /*public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/

        // GET: AnimesController/Edit/5
        /*public ActionResult Edit(int id)
        {
            return View();
        }*/

        // POST: AnimesController/Edit/5
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/

        // GET: AnimesController/Delete/5
        /*public ActionResult Delete(int id)
        {
            return View();
        }*/

        // POST: AnimesController/Delete/5
        /*[HttpPost]
        [ValidateAntiForgeryToken]*/
        /*public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/
    }
}
