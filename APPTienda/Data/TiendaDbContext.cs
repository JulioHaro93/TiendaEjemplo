using APPTienda.Models;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


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
            modelBuilder.Entity<Articulo>(eb =>
            {
                eb.HasNoKey();
            });
            modelBuilder.Entity<Categoria>(eb =>
            {
                eb.HasNoKey();
            });
            modelBuilder.Entity<SubCategoria>(eb =>
            {
                eb.HasNoKey();
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
