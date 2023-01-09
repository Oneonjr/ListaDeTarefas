using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ListaDeTarefas.Filter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ListaDeTarefas.Controllers
{
    [PaginaUsuarioLogado]
    public class RestritoController : Controller
    {
           public IActionResult Index()
        {
            return View();
        }

    }
}