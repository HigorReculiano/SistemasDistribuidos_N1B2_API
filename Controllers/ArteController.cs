using N1B2_API.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace N1B2_API.Controllers
{
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
            arte.Codigo = listaArte.Count + 1;
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
            var arteAlterar = listaArte.Where(a => a.Codigo == arte.Codigo).Select(e => {
                e.CodigoAnime = arte.Codigo;
                e.CodigoArtista = arte.CodigoArtista;
                e.ImagemBase64 = arte.ImagemBase64;
                return e;
            }).ToList();
            return "Sucesso na alteração";
        }

        [AcceptVerbs("DELETE")]
        [Route("DeleteArte")]
        public string DeletaArte(ArteModel arte)
        {
            if (!VerificaExistenciaArte(arte.Codigo))
                return "Código não existe!";
            listaArte.Remove(arte);
            return "Arte removida com sucesso!";
        }

        private string ValidaDados(ArteModel arte)
        {
            if (!ValidaImagem(arte.ImagemBase64))
                return "Não foi possível salvar a imagem, valor inválido de imagem!";
            if (!ValidaCodigoArtista(arte))
                return "Código do artista inválido!";
            if (!ValidaCodigoAnime(arte))
                return "Código do anime inválido!";
            return string.Empty;
        }

        private bool ValidaCodigoArtista(ArteModel arte)
        {
            if (arte.CodigoArtista <= 0)
                return false;
            return true;
        }
        private bool ValidaCodigoAnime(ArteModel arte)
        {
            if (arte.CodigoAnime <= 0)
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
            int codigoLista = listaArte.Where(a => a.Codigo == codigo).Select(e => e.Codigo).Count();
            if (codigoLista == 0)
                return true;
            return false;
        }

    }
}