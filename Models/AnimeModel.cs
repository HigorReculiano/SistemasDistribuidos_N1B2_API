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

        public AnimeModel()
        {

        }

        public AnimeModel(int codigo, string nomeAnime)
        {
            this.Codigo = codigo;
            this.NomeAnime = nomeAnime;
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
    }
}