using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ListaDeTarefas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repositorio;

namespace ListaDeTarefas.Controllers
{
    // [Route("[Tarefas]")]
    public class TarefaController : Controller
    {
        private readonly ItarefaRepositorio _tarefaRepositorio;

        public TarefaController(ItarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }
        public IActionResult Index()
        {
            var tarefas = _tarefaRepositorio.BuscarTodas();
            
            return View(tarefas);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
           TarefaModel tarefa = _tarefaRepositorio.ListarPorId(id);
            return View(tarefa);
        }

        public IActionResult Apagarconfirmacao(int id)
        {
            TarefaModel tarefa = _tarefaRepositorio.ListarPorId(id);
            return View(tarefa);
        }

        public IActionResult Apagar(int id)
        {
           try
           {
                bool apagado = _tarefaRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Tarefa Apagada com sucesso";
                }
                else 
                {
                    TempData["MensagemErro"] = $"Não conseguimos Apagar sua Tarefa.";
                }
                return RedirectToAction("Index");
           }
           catch (System.Exception erro)
           {
             TempData["MensagemErro"] = $"Não conseguimos Apagar sua Tarefa, Erro: {erro.Message}";
             return RedirectToAction("Index");
           }
        }
        
        [HttpPost]
        public IActionResult Criar(TarefaModel tarefa)
        {
            try
            {
                    if(ModelState.IsValid)
                {
                    _tarefaRepositorio.Adicionar(tarefa);
                    TempData["MensagemSucesso"] = "Tarefa cadastrada com sucesso"; 
                    return RedirectToAction("Index");
                }
                
                return View(tarefa);
            }
            catch (System.Exception erro)
            {
                
                TempData["MensagemErro"] = $"Não conseguimos cadastrar sua Tarefa, Tente novamente, Erro: {erro.Message}"; 
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(TarefaModel tarefa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _tarefaRepositorio.Alterar(tarefa);
                    TempData["MensagemSucesso"] = "Tarefa alterada com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", tarefa);

            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos Alterar sua Tarefa, Tente novamente, Erro: {erro.Message}"; 
                return RedirectToAction("Index");
            }
        }

    }
}