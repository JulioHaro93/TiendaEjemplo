using APPTienda.Models;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace APPTienda.Data
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public class TiendaDbContext: DbContext
    {


        public TiendaDbContext(DbContextOptions<TiendaDbContext> opciones) : base(opciones)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Articulo>(eb => {
                object value = eb.HasKey(t => t.Sku);
            });
            modelBuilder.Entity<Categoria>(eb =>
            {
                object value = eb.HasKey(t => t.Id_Categoria);
            });
            modelBuilder.Entity<SubCategoria>(eb =>
            {
                object value = eb.HasKey(t => t.Id_SubCategoria);
            });
        }

        

        DefaultConnectionContext _connectionContext;

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<SubCategoria> SubCategoria { get; set; }

        public static implicit operator List<object>(TiendaDbContext v)
        {
            throw new NotImplementedException();
        }
    }



}
