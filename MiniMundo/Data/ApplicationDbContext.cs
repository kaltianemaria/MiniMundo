using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniMundo.Models;

namespace MiniMundo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MiniMundo.Models.Funcionario> Funcionario { get; set; } = default!;
        public DbSet<MiniMundo.Models.Cliente> Cliente { get; set; }
        public DbSet<MiniMundo.Models.Produto> Produto { get; set; }
        public DbSet<MiniMundo.Models.Venda> Venda { get; set; }


    }
}
