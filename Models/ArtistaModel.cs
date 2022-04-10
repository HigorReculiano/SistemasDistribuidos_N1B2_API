using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace N1B2_API.Models
{
    public class ArtistaModel
    {
        private int codigo;
        private string nomeArtista;
        private int idade;

        public ArtistaModel()
        {

        }

        public ArtistaModel(int codigo, string nomeArtista, int idade)
        {
            this.Codigo = codigo;
            this.NomeArtista = nomeArtista;
            this.Idade = idade;
        }
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public string NomeArtista
        {
            get { return nomeArtista; }
            set { nomeArtista = value; }
        }
        public int Idade
        {
            get { return idade; }
            set { idade = value; }
        }
    }
}