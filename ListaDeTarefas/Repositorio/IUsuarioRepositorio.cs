using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaDeTarefas.Models;

namespace ListaDeTarefas.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel ListarPorId(int id);
        List<UsuarioModel> BuscarTodas();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Alterar(UsuarioModel usuario);
        bool Apagar(int id);
    }
}