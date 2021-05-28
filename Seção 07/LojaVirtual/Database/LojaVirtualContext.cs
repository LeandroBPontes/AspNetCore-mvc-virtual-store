using LojaVirtual.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Database
{
    public class LojaVirtualContext : DbContext
    {
        /*
         EF Core - ORM
         ORM -> Biblioteca para mapear Objetos para BANCO DE DADOS relacionais

         ligação com LojaVirtual.Models; (arquivo Cliente.cs em Models)
         */

        public LojaVirtualContext(DbContextOptions<LojaVirtualContext> options) : base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<NewsLetterEmail> NewsLetterEmail { get; set; }

        internal void Remove(object cliente)
        {
            throw new NotImplementedException();
        }
    }
}
