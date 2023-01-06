using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaDeTarefas.Models;
using Newtonsoft.Json;

namespace ListaDeTarefas.Helper
{
    public class Sessao : ISessao
    {   
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public UsuarioModel BuscarSessaoUsuario()
        {
           string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

           if (string.IsNullOrEmpty(sessaoUsuario)) 
           {
                return null;
           }

           return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
        }

        public void CriarSessaoUsuario(UsuarioModel usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario); // Transformando objeto usuario em Json

            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }
        public void RemoverSessaoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
        
    }
}