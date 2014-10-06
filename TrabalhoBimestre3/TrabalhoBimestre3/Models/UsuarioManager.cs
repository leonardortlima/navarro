using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoBimestre3.Models
{
    public class UsuarioManager
    {
        public List<Usuario> Usuarios { get; set; }

        public UsuarioManager()
        {
            if (HttpContext.Current.Session["lista"] == null)
            {
                Usuarios = new List<Usuario>();
                var user1 = new Usuario() { Id = 1, NomeCompleto = "Leonardo", DataNascimento = "01/01/2014", NomeUsuario = "leonardo", Senha = "123456" };
                Usuarios.Add(user1);
                HttpContext.Current.Session["lista"] = Usuarios;
            }

        }

        // Lista todos os usuarios
        public List<Usuario> ListaUsuarios()
        {
            Usuarios = (List<Usuario>)HttpContext.Current.Session["lista"];
            return Usuarios;
        }

        // Busca um usuario pelo seu id
        public Usuario BuscaUsuario(int id)
        {
            Usuarios = (List<Usuario>)HttpContext.Current.Session["lista"];
            var usuario = Usuarios.SingleOrDefault(x => x.Id == id);
            return usuario;
        }

        // Adiciona um novo usuario
        public void AdicionaUsuario(Usuario usuario)
        {
            if (HttpContext.Current.Session["lista"] != null)
            {
                Usuarios = (List<Usuario>)HttpContext.Current.Session["lista"];
                usuario.Id = Usuarios.Count + 1;
                Usuarios.Add(usuario);
                HttpContext.Current.Session["lista"] = Usuarios;
            }
        }

        // Modifica um usuario
        public void ModificaUsuario(Usuario usuario)
        {
            Usuarios = (List<Usuario>)HttpContext.Current.Session["lista"];
            var usuarioAnterior = Usuarios.SingleOrDefault(x => x.Id == usuario.Id);
            if (usuarioAnterior != null)
            {
                usuarioAnterior.NomeCompleto = usuario.NomeCompleto;
                usuarioAnterior.DataNascimento = usuario.DataNascimento;
                usuarioAnterior.NomeUsuario = usuario.NomeUsuario;
                usuarioAnterior.Senha = usuario.Senha;
            }

        }

        // Apaga um usuario
        public void DeletaUsuario(Usuario usuario)
        {
            Usuarios = (List<Usuario>)HttpContext.Current.Session["lista"];
            var usuarioDeletar = Usuarios.SingleOrDefault(x => x.Id == usuario.Id);
            if (usuarioDeletar != null)
            {
                Usuarios.Remove(usuarioDeletar);
            }
        }

    }
}