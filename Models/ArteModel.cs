using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace N1B2_API.Models
{
    public class ArteModel
    {
        private int codigo;
        private string imagemBase64;
        private int codigoArtista;
        private int codigoAnime;

        public ArteModel()
        {

        }

        public ArteModel(int codigo, string imagemBase64, int codigoArtista, int codigoAnime)
        {
            this.Codigo = codigo;
            this.ImagemBase64 = imagemBase64;
            this.CodigoArtista = codigoArtista;
            this.CodigoAnime = codigoAnime;
        }
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public string ImagemBase64
        {
            get { return imagemBase64; }
            set { imagemBase64 = value; }
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