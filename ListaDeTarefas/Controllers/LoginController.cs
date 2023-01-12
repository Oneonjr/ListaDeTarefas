using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ListaDeTarefas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ListaDeTarefas.Repositorio;
using ListaDeTarefas.Helper;

namespace ListaDeTarefas.Controllers
{
    //[Route("[controller]")]
    public class LoginController : Controller
    {   
        private readonly IUsuarioRepositorio  _usuarioRepositorio;
        private readonly ISessao _sessao;
        public LoginController(IUsuarioRepositorio usuarioRepositorio,
                                 ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            // Se o usuario estiver logado ir para home.

            if (_sessao.BuscarSessaoUsuario() != null )
            {
                return RedirectToAction("Index","Home");
            }

            return View();
        }

        public IActionResult RedefinirSenha()
        {
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();

            return RedirectToAction("Index","Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login); // validação de login

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha)) //validação senha
                        {
                            _sessao.CriarSessaoUsuario(usuario);
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

        [HttpPost] 
        public IActionResult EnviarLinkParaRedefinirSenha(RedefinirSenhaModel redefinirSenhaModel)
        {
             try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorEmailELogin(redefinirSenhaModel.Email, redefinirSenhaModel.Login); // validação de login

                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();

                        TempData["MensagemSucesso"] =$"Enviamos para seu E-mail cadastrado uma nova senha.";
                        return RedirectToAction("Index","Login");
                    }

                    TempData["MensagemErro"] =$"Não conseguimos Redefinir sua senha. Por favor, tente novamente.";
                }

                return View("Index");
            }
            catch (System.Exception erro)
            {
                
                TempData["MensagemErro"] = $"Não conseguimos Redefinir sua senha, Tente novamente, detalhe do erro:{erro.Message}"; 
                return RedirectToAction("Index");
            }
        }

    }
}