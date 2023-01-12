using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListaDeTarefas.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome da tarefa")]
        public string NomeTarefa { get; set; }

        [Required(ErrorMessage = "Digite a descrição da Tarefa")]
        public string DescricaoTarefa { get; set; }

        // [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        // public DateTime DataCriação { get; set; }
        [Required(ErrorMessage = "Digite o telefone do contato")]
        [Phone(ErrorMessage = "O celular informado não é valido")]
        public string Tefefone { get; set; }
        public int? UsuarioId { get; set; }
        public UsuarioModel Usuario { get; set; }

    }
}