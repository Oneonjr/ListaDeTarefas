using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaDeTarefas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace ListaDeTarefas.Filter
{
    public class PaginaRestritaSoAdmin : ActionFilterAttribute 
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary{{"controller", "Login"},{"action","Index"}});
            }
            else
            {
                UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);

                if (usuario == null)
                {
                   context.Result = new RedirectToRouteResult(new RouteValueDictionary{{"controller", "Login"},{"action","Index"}}); 
                }
                if (usuario.Perfil != ListaDeTarefas.Enums.PerfilEnum.Admin)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary{{"controller", "Restrito"},{"action","Index"}}); 
                }
            }

            base.OnActionExecuting(context);
        }
    }
}