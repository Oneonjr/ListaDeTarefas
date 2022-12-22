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

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult Apagarconfirmacao()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Criar(TarefaModel tarefa)
        {
            _tarefaRepositorio.Adicionar(tarefa);
            return RedirectToAction("Index");
        }

    }
}