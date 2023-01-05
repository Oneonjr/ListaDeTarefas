using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ListaDeTarefas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ListaDeTarefas.Repositorio;

namespace ListaDeTarefas.Controllers
{
    //[Route("[controller]")]
    public class LoginController : Controller
    {   
        private readonly IUsuarioRepositorio  _usuarioRepositorio;
        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario2 = _usuarioRepositorio.BuscarPorLogin(loginModel.Login); // validação de login

                    if (usuario2 != null)
                    {
                        if (usuario2.SenhaValida(loginModel.Senha)) //validação senha
                        {
                            return RedirectToAction("Index","Home"); 
                        } 

                       TempData["MensagemErro"] =$"Senha do Usuario é invalida.Tente novamente.";
                           
                    }

                    TempData["MensagemErro"] =$"Usuario e/ou Senha incorreto(s). Por favor, tente novamente.";
                }

                return View("Index");
            }
            catch (System.Exception erro)
            {
                
                TempData["MensagemErro"] = $"Não conseguimos Realizar seu login, Tente novamente"; 
                return RedirectToAction("Index");
            }
        }

    }
}