using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ListaDeTarefas.Helper;
using ListaDeTarefas.Models;
using ListaDeTarefas.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ListaDeTarefas.Controllers
{
    //[Route("[controller]")]
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        public AlterarSenhaController(IUsuarioRepositorio usuarioRepositorio,
                                        ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(AlterarSenhaModel alterarSenhaModel)
        {
            try
            {
                UsuarioModel usuarioLogado = _sessao.BuscarSessaoUsuario();
                alterarSenhaModel.Id = usuarioLogado.Id;
                
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.AlterarSenha(alterarSenhaModel);
                    TempData["MensagemSucesso"] = "Senha Alterada com sucesso";
                    return View("Index",alterarSenhaModel);
                }

                return View("Index",alterarSenhaModel);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos Alterar sua Senha, Tente novamente, Erro: {erro.Message}";
                return View("Index",alterarSenhaModel);
            }
        }

    }
}