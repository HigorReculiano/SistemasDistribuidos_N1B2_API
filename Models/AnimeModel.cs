using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace N1B2_API.Models
{
    public class AnimeModel
    {
        private int codigo;
        private string nomeAnime;
        private string genero;

        public AnimeModel()
        {

        }

        public AnimeModel(int codigo, string nomeAnime, string genero)
        {
            this.Codigo = codigo;
            this.NomeAnime = nomeAnime;
            this.Genero = genero;
        }
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public string NomeAnime
        {
            get { return nomeAnime; }
            set { nomeAnime = value; }
        }
        public string Genero
        {
            get { return genero; }
            set { genero = value; }
        }
    }
}