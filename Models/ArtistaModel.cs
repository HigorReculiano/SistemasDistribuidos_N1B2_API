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
        private string email;

        public ArtistaModel()
        {

        }

        public ArtistaModel(int codigo, string nomeArtista, string email)
        {
            this.Codigo = codigo;
            this.NomeArtista = nomeArtista;
            this.Email = email;
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
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}