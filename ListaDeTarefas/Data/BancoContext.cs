using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaDeTarefas.Data.Map;
using ListaDeTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefas.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {    
        }

        public DbSet<TarefaModel> Tarefas {get; set;}
        public DbSet<UsuarioModel> Usuarios {get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TarefaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}