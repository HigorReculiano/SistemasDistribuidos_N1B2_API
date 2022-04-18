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
        private static List<AnimeModel> listaAnimes = new List<AnimeModel>();
        [AcceptVerbs("POST")]
        [Route("CadastrarAnime")]
        public string CadastrarAnime(AnimeModel anime)
        {
            if (!ValidaDadosAnime(anime))
                return "Erro no cadastro, não permitido nome vazio!";
            if (VerificaAnimeExiste(anime.NomeAnime))
                return "Anime já existente!";
            anime.Codigo = listaAnimes.Count + 1;
            listaAnimes.Add(anime);
            return "Anime cadastrado com sucesso!";
        }

        [AcceptVerbs("PUT")]
        [Route("AlterarAnime")]
        public string AlterarAnime(AnimeModel anime)
        {
            if (!ValidaDadosAnime(anime))
                return "Erro na alteração, não permitido nome vazio!";

            listaAnimes.Where(a => a.Codigo == anime.Codigo).Select(n =>
            {
                n.Codigo = listaAnimes.Count() + 1;
                n.NomeAnime = anime.NomeAnime;
                return n;
            }).ToList();
            return "Anime alterado com sucesso!";
        }

        [AcceptVerbs("DELETE")]
        [Route("DeleteAnime")]
        public string DeleteAnime(int codigo)
        {
            var anime = listaAnimes.Where((a) => a.Codigo == codigo).FirstOrDefault();
            if (anime == null)
                return "Código não existente!";

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

        [AcceptVerbs("GET")]
        [Route("GetListaAnimes")]
        public List<AnimeModel> GetListaAnimes()
        {
            var anime = listaAnimes.ToList();
            return anime;
        }

        private bool ValidaDadosAnime(AnimeModel anime)
        {
            if (string.IsNullOrEmpty(anime.NomeAnime))
                return false;
            return true;
        }

        private bool VerificaAnimeExiste(string anime)
        {
            var nome = listaAnimes.Where(a => a.NomeAnime.ToUpper() == anime.ToUpper()).FirstOrDefault();
            if (string.IsNullOrEmpty(nome.NomeAnime))
                return false;
            return true;
        }
    }
}