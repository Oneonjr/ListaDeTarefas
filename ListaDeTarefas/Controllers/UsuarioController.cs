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
        public IActionResult Editar(int id)
        {
            UsuarioModel usuario =_usuarioRepositorio.ListarPorId(id);
            return View(usuario);
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

        public IActionResult Apagarconfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult Apagar(int id)
        {
           try
           {
                bool apagado = _usuarioRepositorio.Apagar(id);
                if (apagado) TempData["MensagemSucesso"] = "Usuario Apagado com sucesso"; else TempData["MensagemErro"] = $"Não conseguimos Apagar seu Usuario.";
                return RedirectToAction("Index");
           }
           catch (System.Exception erro)
           {
             TempData["MensagemErro"] = $"Não conseguimos Apagar seu Usuario, Erro: {erro.Message}";
             return RedirectToAction("Index");
           }
        }

        [HttpPost]
        public IActionResult Editar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                UsuarioModel usuario = null;

                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Nome = usuarioSemSenhaModel.Nome,
                        Login = usuarioSemSenhaModel.Login,
                        Email = usuarioSemSenhaModel.Email,
                        Perfil = usuarioSemSenhaModel.Perfil
                    };

                    usuario = _usuarioRepositorio.Alterar(usuario);
                    TempData["MensagemSucesso"] = "Usuario alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(usuario);

            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos Alterar seu Usuario, Tente novamente, Erro: {erro.Message}"; 
                return RedirectToAction("Index");
            }
        }




    }
}