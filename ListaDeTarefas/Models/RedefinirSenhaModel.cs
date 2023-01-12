using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListaDeTarefas.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Digite o Login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o E-mail")]
        public string Email { get; set; }
    }
}