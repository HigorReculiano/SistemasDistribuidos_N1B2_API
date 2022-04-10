using N1B2_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace N1B2_API.Controllers
{
    public class AnimeController : Controller
    {
        private List<AnimeModel> listaAnimes = new List<AnimeModel>();
        // GET: Anime
        public ActionResult Index()
        {
            return View();
        }
    }
}