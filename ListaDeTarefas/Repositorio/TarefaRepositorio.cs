using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaDeTarefas.Data;
using ListaDeTarefas.Models;


namespace Repositorio
{
    public class TarefaRepositorio : ItarefaRepositorio 
    {
        private readonly BancoContext _BancoContext;

        public TarefaRepositorio(BancoContext bancoContext)
        {
            _BancoContext = bancoContext;
        }

        public List<TarefaModel> BuscarTodas()
        {
            return _BancoContext.Tarefas.ToList();
        }
        public TarefaModel Adicionar(TarefaModel tarefa)
        {
            _BancoContext.Tarefas.Add(tarefa);
            _BancoContext.SaveChanges();

            return tarefa;
        }


    }
}