using N1B2_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace N1B2_API.Controllers
{
    [RoutePrefix("")]
    public class AnimeController : Controller
    {
        private List<AnimeModel> listaAnimes = new List<AnimeModel>();

        [AcceptVerbs("POST")]
        [Route("CadastrarAnime")]
        public string CadastrarUsuario(AnimeModel anime)
        {
            listaAnimes.Add(anime);
            return "Anime cadastrado com sucesso!";
        }

        [AcceptVerbs("PUT")]
        [Route("AlterarAnime")]
        public string AlterarAnime(AnimeModel anime)
        {
            listaAnimes.Where(a => a.Codigo == anime.Codigo).Select(n =>
            {
                n.Codigo = anime.Codigo;
                n.NomeAnime = anime.NomeAnime;
                n.Genero = anime.Genero;
                return n;
            }).ToList();
            return "Anime alterado com sucesso!";
        }

        [AcceptVerbs("DELETE")]
        [Route("DeleteAnime")]
        public string DeleteAnime(int codigo)
        {
            var anime = listaAnimes.Where((a) => a.Codigo == codigo).FirstOrDefault();
            listaAnimes.Remove(anime);
            return "Anime excluido com sucesso!";
        }

        [AcceptVerbs("GET")]
        [Route("GetAnime")]
        public AnimeModel GetAnime(int codigo)
        {
            var anime = listaAnimes.Where((a) => a.Codigo == codigo).FirstOrDefault();
            return anime;
        }
    }
}