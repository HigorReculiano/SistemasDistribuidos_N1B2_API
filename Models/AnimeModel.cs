using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace N1B2_API.Models
{
    public class AnimeModel
    {
        private int _codigo;
        private string _nome_Anime;

        public AnimeModel()
        {

        }

        public AnimeModel(int codigo, string nomeAnime)
        {
            this.Codigo = codigo;
            this.nomeAnime = nomeAnime;
        }
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public string nomeAnime
        {
            get { return _nome_Anime; }
            set { _nome_Anime = value; }
        }
    }
}