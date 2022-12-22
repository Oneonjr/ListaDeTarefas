using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaDeTarefas.Models;

namespace Repositorio
{
    public interface ItarefaRepositorio
    {
        List<TarefaModel> BuscarTodas();
        TarefaModel Adicionar(TarefaModel tarefa);
    }
}