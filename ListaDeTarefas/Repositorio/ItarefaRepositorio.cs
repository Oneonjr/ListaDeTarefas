using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaDeTarefas.Models;

namespace Repositorio
{
    public interface ItarefaRepositorio
    {
        TarefaModel ListarPorId(int id);
        List<TarefaModel> BuscarTodas();
        TarefaModel Adicionar(TarefaModel tarefa);
        TarefaModel Alterar(TarefaModel tarefa);
        bool Apagar(int id);
    }
}