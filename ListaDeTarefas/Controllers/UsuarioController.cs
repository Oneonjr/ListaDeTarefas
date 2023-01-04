using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ListaDeTarefas.Models;
using ListaDeTarefas.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ListaDeTarefas.Controllers
{
    //[Route("[controller]")]
    public class UsuarioController : Controller
    {
        
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodas();
            
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                    if(ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrada com sucesso"; 
                    return RedirectToAction("Index");
                }
                
                return View(usuario);
            }
            catch (System.Exception erro)
            {
                
                TempData["MensagemErro"] = $"Não conseguimos cadastrar seu Usuário, Tente novamente, Erro: {erro.Message}"; 
                return RedirectToAction("Index");
            }
        }



    }
}