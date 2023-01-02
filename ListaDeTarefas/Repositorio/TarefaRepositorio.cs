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
        public TarefaModel ListarPorId(int id)
        {
            return _BancoContext.Tarefas.FirstOrDefault(x => x.Id == id);
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

        public TarefaModel Alterar(TarefaModel tarefa)
        {
            TarefaModel tarefaDB = ListarPorId(tarefa.Id);

            if(tarefaDB == null) throw new System.Exception("Houve um erro ao Alterar");

            tarefaDB.NomeTarefa = tarefa.NomeTarefa;
            tarefaDB.DescricaoTarefa = tarefa.DescricaoTarefa;
            tarefaDB.Tefefone = tarefa.Tefefone;

            _BancoContext.Tarefas.Update(tarefaDB);
            _BancoContext.SaveChanges();

            return tarefaDB;
        }

        public bool Apagar(int id)
        {
            TarefaModel tarefaDB = ListarPorId(id);

            if(tarefaDB == null) throw new System.Exception("Houve um erro ao Apagar a tarefa");

            _BancoContext.Tarefas.Remove(tarefaDB);
            _BancoContext.SaveChanges();

            return true;
        }
    }
}