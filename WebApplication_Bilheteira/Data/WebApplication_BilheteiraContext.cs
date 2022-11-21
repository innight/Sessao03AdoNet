using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bilheteira;

namespace WebApplication_Bilheteira.Data
{
    public class WebApplication_BilheteiraContext : DbContext
    {
        public WebApplication_BilheteiraContext (DbContextOptions<WebApplication_BilheteiraContext> options)
            : base(options)
        {
        }

        public DbSet<Bilheteira.Lugar> Lugar { get; set; }

        public DbSet<Bilheteira.Local> Local { get; set; }

        public DbSet<Bilheteira.TipoEvento> TipoEvento { get; set; }

        public DbSet<Bilheteira.SubTipoEvento> SubTipoEvento { get; set; }

        public DbSet<Bilheteira.Evento> Evento { get; set; }

        public DbSet<Bilheteira.Sessao> Sessao { get; set; }

        public DbSet<Bilheteira.Sector> Sector { get; set; }

        public DbSet<Bilheteira.Bilhete> Bilhete { get; set; }

        public DbSet<Bilheteira.Cliente> Cliente { get; set; }
    }
}
