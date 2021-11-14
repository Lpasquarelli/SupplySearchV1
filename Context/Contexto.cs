using Microsoft.EntityFrameworkCore;
using SupplySearchV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupplySearchV1.Context
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions options) : base(options) { }
        public DbSet<Doador> Doador { get; set; }
        public DbSet<Donatario> Donatario { get; set; }
        public DbSet<Local> Local { get; set; }
        public DbSet<Doacoes> Doacoes{ get; set; }
    }
}
