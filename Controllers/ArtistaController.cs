using N1B2_API.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace N1B2_API.Controllers
{
    [RoutePrefix("api/artista")]
    public class ArtistaController : ApiController
    {
        private static List<ArtistaModel> listaArtistas = new List<ArtistaModel>();

        [AcceptVerbs("POST")]
        [Route("CadastrarArtista")]
        public string CadastrarUsuario(ArtistaModel artista)
        {
            string erro = ValidaDado(artista);
            if (!string.IsNullOrEmpty(erro))
                return erro;

            listaArtistas.Add(artista);
            return "Usuário cadastrado com sucesso!";
        }

        [AcceptVerbs("PUT")]
        [Route("AlterarArtista")]
        public string AlterarUsuario(ArtistaModel artista)
        {
            string erro = ValidaDado(artista);
            if (!string.IsNullOrEmpty(erro))
                return erro;

            listaArtistas.Where(n => n.Codigo ==
            artista.Codigo)
            .Select(s =>
            {
                s.Codigo = artista.Codigo;
                s.Email = artista.Email;
                s.NomeArtista = artista.NomeArtista;
                return s;
            }).ToList();
            return "Usuário alterado com sucesso!";
        }

        [AcceptVerbs("DELETE")]
        [Route("ExcluirUsuario/{codigo}")]
        public string ExcluirUsuario(int codigo)
        {
            ArtistaModel artista = listaArtistas.Where(n => n.Codigo == codigo)
            .Select(n => n)
            .First();
            if (artista == null)
                return "Código não existente!";

            listaArtistas.Remove(artista);
            return "Registro excluido com sucesso!";
        }

        [AcceptVerbs("GET")]
        [Route("ConsultarArtistaPorCodigo/{codigo}")]
        public ArtistaModel ConsultarUsuarioPorCodigo(int codigo)
        {
            ArtistaModel artista = listaArtistas.Where(n => n.Codigo == codigo)
            .Select(n => n)
            .FirstOrDefault();
            return artista;
        }

        [AcceptVerbs("GET")]
        [Route("GetArtistas")]
        public List<ArtistaModel> GetArtistas()
        {
            return listaArtistas.ToList();
        }
        
        private string ValidaDado(ArtistaModel artista)
        {
            if (!ValidaNome(artista.NomeArtista))
                return "Nome de usuário inválido, não pode texto vazio!";
            if (!IsValidEmail(artista.Email))
                return "Email inválido";
            if (EmailExiste(artista.Email))
                return "Email já existe!";
            return string.Empty;
        }

        private bool ValidaNome(string nomeArtista)
        {
            if (string.IsNullOrEmpty(nomeArtista))
                return false;
            return true;
        }

        private bool EmailExiste(string email)
        {
            var emailExistente = listaArtistas.Where(a => a.Email.ToUpper() == email.ToUpper()).Select(n => n.Email).FirstOrDefault();
            if (string.IsNullOrEmpty(emailExistente))
                return false;
            return true;
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}