using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace N1B2_API.Models
{
    public class ArteModel
    {
        private int _codigo;
        private string _imagemBase64;
        private int _codigoArtista;
        private int _codigoAnime;

        public ArteModel()
        {

        }

        public ArteModel(int codigo, string imagemBase64, int codigoArtista, int codigoAnime)
        {
            this.codigo = codigo;
            this.imagemBase64 = imagemBase64;
            this.codigoArtista = codigoArtista;
            this.codigoAnime = codigoAnime;
        }
        public int codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public string imagemBase64
        {
            get { return _imagemBase64; }
            set { _imagemBase64 = value; }
        }
        public int codigoArtista
        {
            get { return _codigoArtista; }
            set { _codigoArtista = value; }
        }
        public int codigoAnime
        {
            get { return _codigoAnime; }
            set { _codigoAnime = value; }
        }
    }
}