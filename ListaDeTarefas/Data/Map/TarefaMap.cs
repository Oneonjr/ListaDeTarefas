using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaDeTarefas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ListaDeTarefas.Data.Map
{
    public class TarefaMap : IEntityTypeConfiguration<TarefaModel>
    {
        public void Configure(EntityTypeBuilder<TarefaModel> builder)
        {
           builder.HasKey(x => x.Id);
           builder.HasOne(x => x.Usuario);
        }
    }
}