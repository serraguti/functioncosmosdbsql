using ControlCochesCosmosSql.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlCochesCosmosSql.Data
{
    public class CochesContext: DbContext
    {
        public CochesContext(DbContextOptions<CochesContext> options) : base(options) { }
        public DbSet<Coche> Coches { get; set; }
    }
}
