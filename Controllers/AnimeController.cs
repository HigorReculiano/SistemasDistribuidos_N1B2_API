
using N1B2_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;


namespace N1B2_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/anime")]
    public class AnimeController : ApiController
    {
        private static List<AnimeModel> listaAnimes = new List<AnimeModel>();
        [AcceptVerbs("POST")]
        [Route("CadastrarAnime")]
        public string CadastrarAnime(AnimeModel anime)
        {
            if (!ValidaDadosAnime(anime))
                return "Erro no cadastro, não permitido nome vazio!";
            if (VerificaAnimeExiste(anime.nomeAnime))
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
                n.nomeAnime = anime.nomeAnime;
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

        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        private bool ValidaDadosAnime(AnimeModel anime)
        {
            if (string.IsNullOrEmpty(anime.nomeAnime))
                return false;
            return true;
        }

        private bool VerificaAnimeExiste(string anime)
        {
            var nome = listaAnimes.Where(a => a.nomeAnime.ToUpper() == anime.ToUpper()).FirstOrDefault();
            if (nome == null)
                return false;
            return true;
        }
    }
}