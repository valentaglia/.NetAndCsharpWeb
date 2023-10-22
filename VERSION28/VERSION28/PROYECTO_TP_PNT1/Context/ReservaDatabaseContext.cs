using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PROYECTO_TP_PNT1.Models;

namespace PROYECTO_TP_PNT1.Context
{
    public class ReservaDatabaseContext : DbContext
    {
            public ReservaDatabaseContext(DbContextOptions<ReservaDatabaseContext> options) : base(options)
            {
            }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        //aca se mapean las "listas" que querramos usar. son las listas que se mapearan en sql
        public DbSet<Cliente> Clientes{ get; set; }
        public DbSet<Reserva> Reservas{ get; set; }
        public DbSet<Alojamiento> Alojamientos{ get; set; }
        
    }
    
}

