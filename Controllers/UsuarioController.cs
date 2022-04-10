using N1B2_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace N1B2_API.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        private static List<UsuarioModel> listaUsuarios = new List<UsuarioModel>();

        [AcceptVerbs("POST")]
        [Route("CadastrarUsuario")]
        public string CadastrarUsuario(UsuarioModel usuario)
        {
            listaUsuarios.Add(usuario);
            return "Usuário cadastrado com sucesso!";
        }

        [AcceptVerbs("PUT")]
        [Route("AlterarUsuario")]
        public string AlterarUsuario(UsuarioModel usuario)
        {
            listaUsuarios.Where(n => n.Codigo ==
            usuario.Codigo)
            .Select(s =>
            {
                s.Codigo = usuario.Codigo;
                s.Login = usuario.Login;
                s.Nome = usuario.Nome;
                return s;
            }).ToList();
            return "Usuário alterado com sucesso!";
        }

        [AcceptVerbs("DELETE")]
        [Route("ExcluirUsuario/{codigo}")]
        public string ExcluirUsuario(int codigo)
        {
            UsuarioModel usuario = listaUsuarios.Where(n => n.Codigo == codigo)
            .Select(n => n)
            .First();
            listaUsuarios.Remove(usuario);
            return "Registro excluido com sucesso!";
        }

        [AcceptVerbs("GET")]
        [Route("ConsultarUsuarioPorCodigo/{codigo}")]
        public UsuarioModel ConsultarUsuarioPorCodigo(int codigo)
        {
            UsuarioModel usuario = listaUsuarios.Where(n => n.Codigo == codigo)
            .Select(n => n)
            .FirstOrDefault();
            return usuario;
        }

        [AcceptVerbs("GET")]
        [Route("ConsultarUsuarios")]
        public List<UsuarioModel> ConsultarUsuarios()
        {
            CarregarUsuarios();
            return listaUsuarios;
        }

        private void CarregarUsuarios()
        {
            listaUsuarios.Clear();
            listaUsuarios.Add(new UsuarioModel(1, "NOME1", "LOGIN 1"));
            listaUsuarios.Add(new UsuarioModel(2, "NOME2", "LOGIN 2"));
        }

    }
}