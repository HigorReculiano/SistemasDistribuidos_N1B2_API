using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace N1B2_API.Models
{
    public class ArteModel
    {
        private int codigo;
        private string linkImagem;
        private int codigoArtista;
        private int codigoAnime;

        public ArteModel()
        {

        }

        public ArteModel(int codigo, string linkImagem, int codigoArtista, int codigoAnime)
        {
            this.Codigo = codigo;
            this.LinkImagem = linkImagem;
            this.CodigoArtista = codigoArtista;
            this.CodigoAnime = codigoAnime;
        }
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public string LinkImagem
        {
            get { return linkImagem; }
            set { linkImagem = value; }
        }
        public int CodigoArtista
        {
            get { return codigoArtista; }
            set { codigoArtista = value; }
        }
        public int CodigoAnime
        {
            get { return codigoAnime; }
            set { codigoAnime = value; }
        }
    }
}