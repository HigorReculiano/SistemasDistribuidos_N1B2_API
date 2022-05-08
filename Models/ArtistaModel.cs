using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace N1B2_API.Models
{
    public class ArtistaModel
    {
        private int _codigo;
        private string _nomeArtista;
        private string _email;

        public ArtistaModel()
        {

        }

        public ArtistaModel(int codigo, string nomeArtista, string email)
        {
            this.codigo = codigo;
            this.nomeArtista = nomeArtista;
            this.email = email;
        }
        public int codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public string nomeArtista
        {
            get { return _nomeArtista; }
            set { _nomeArtista = value; }
        }
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }
    }
}