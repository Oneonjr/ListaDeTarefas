using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaDeTarefas.Data;
using ListaDeTarefas.Models;
using ListaDeTarefas.Repositorio;

namespace Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _BancoContext;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _BancoContext = bancoContext;
        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            return _BancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _BancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }
        public List<UsuarioModel> BuscarTodas()
        {
            return _BancoContext.Usuarios.ToList();
        }
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            _BancoContext.Usuarios.Add(usuario);
            _BancoContext.SaveChanges();

            return usuario;
        }

        public UsuarioModel Alterar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListarPorId(usuario.Id);

            if(usuarioDB == null) throw new System.Exception("Houve um erro ao Alterar usuario");
            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacao = DateTime.Now;

            _BancoContext.Usuarios.Update(usuarioDB);
            _BancoContext.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = ListarPorId(id);

            if(usuarioDB == null) throw new System.Exception("Houve um erro ao Apagar a usuario");

            _BancoContext.Usuarios.Remove(usuarioDB);
            _BancoContext.SaveChanges();

            return true;
        }


    }
}