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
        public string NomeTarefa { get; set; }
        public string DescricaoTarefa { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataInicio { get; set; }
        
    }
}