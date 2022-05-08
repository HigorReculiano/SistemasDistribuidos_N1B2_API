using N1B2_API.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace N1B2_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/arte")]
    public class ArteController : Controller
    {
        private List<ArteModel> listaArte = new List<ArteModel>();

        [AcceptVerbs("POST")]
        [Route("CadastrarArte")]
        public string CadastrarArte(ArteModel arte)
        {
            string erro = ValidaDados(arte);
            if(string.IsNullOrEmpty(erro))
                return erro;
            arte.codigo = listaArte.Count + 1;
            listaArte.Add(arte);
            return "Arte salva com sucesso!";
        }

        [AcceptVerbs("PUT")]
        [Route("AlterarArte")]
        public string AlterarArte(ArteModel arte)
        {
            string erro = ValidaDados(arte);
            if (string.IsNullOrEmpty(erro))
                return erro;
            var arteAlterar = listaArte.Where(a => a.codigo == arte.codigo).Select(e => {
                e.codigoAnime = arte.codigo;
                e.codigoArtista = arte.codigoArtista;
                e.imagemBase64 = arte.imagemBase64;
                return e;
            }).ToList();
            return "Sucesso na alteração";
        }

        [AcceptVerbs("DELETE")]
        [Route("DeleteArte")]
        public string DeletaArte(ArteModel arte)
        {
            if (!VerificaExistenciaArte(arte.codigo))
                return "Código não existe!";
            listaArte.Remove(arte);
            return "Arte removida com sucesso!";
        }

        private string ValidaDados(ArteModel arte)
        {
            if (!ValidaImagem(arte.imagemBase64))
                return "Não foi possível salvar a imagem, valor inválido de imagem!";
            if (!ValidaCodigoArtista(arte))
                return "Código do artista inválido!";
            if (!ValidaCodigoAnime(arte))
                return "Código do anime inválido!";
            return string.Empty;
        }

        private bool ValidaCodigoArtista(ArteModel arte)
        {
            if (arte.codigoArtista <= 0)
                return false;
            return true;
        }
        private bool ValidaCodigoAnime(ArteModel arte)
        {
            if (arte.codigoAnime <= 0)
                return false;
            return true;
        }

        private bool ValidaImagem(string imagemBase64)
        {
            if (string.IsNullOrEmpty(imagemBase64))
                return false;
            return true;
        }

        private bool VerificaExistenciaArte(int codigo)
        {
            int codigoLista = listaArte.Where(a => a.codigo == codigo).Select(e => e.codigo).Count();
            if (codigoLista == 0)
                return true;
            return false;
        }

    }
}