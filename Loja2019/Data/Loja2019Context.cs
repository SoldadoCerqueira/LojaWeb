using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Loja2019.Models;

namespace Loja2019.Data
{
    public class Loja2019Context : DbContext
    {
        public Loja2019Context (DbContextOptions<Loja2019Context> options)
            : base(options)
        {
        }

        public DbSet<Loja2019.Models.Confeccao> Confeccao { get; set; }

        public DbSet<Loja2019.Models.Roupa> Roupa { get; set; }
    }
}
