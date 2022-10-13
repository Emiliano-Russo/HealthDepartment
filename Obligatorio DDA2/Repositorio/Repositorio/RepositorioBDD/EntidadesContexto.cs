using Entidades;
using Entidades.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Repositorio.Logica.Entidades;
using Repositorio.Repositorio.RepositorioBDD.Entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Web.Api.Entidades;

namespace Repositorio.Repositorio.RepositorioBDD
{
    public class EntidadesContexto : DbContext
    {

        public EntidadesContexto(DbContextOptions<EntidadesContexto> opciones) : base(opciones)
        {

        }

        internal DbSet<GaleriaMusical> GaleriasMusicales { get; set; }
        
        internal DbSet<IXCancionGaleria> IndiceCancionGaleria { get; set; }

        internal DbSet<IXCancionPlayList> IndiceCancionPlayList { get; set; }

        internal DbSet<IXGaleriaPlayList> IndiceGaleriaPlayList { get; set; }

        internal DbSet<IXVideoGaleria> IndiceVideoGaleria { get; set; }

        internal DbSet<IXVideoPlayList> IndiceVideoPlayList { get; set; }

        internal DbSet<Cancion> Canciones { get; set; }

        internal DbSet<Playlist> PlayList { get; set; }

        internal DbSet<Video> Videos { get; set; }

        internal DbSet<Admin> Admins { get; set; }

        internal DbSet<Sesion> SesionAdmin { get; set; }

        internal DbSet<Psicologo> Psicologos { get; set; }

        internal DbSet<Cita> Citas { get; set; }

        internal DbSet<IXPsicologoDolencia> IndicePsicologoDolencia { get; set; }

        internal DbSet<Descuento> Descuentos { get; set; }

        internal DbSet<Credito> Creditos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //string nombrePC = System.IO.File.ReadAllText(@"C:\Users\Public\ArchivosTexto\Conexion.txt");
            //options.UseSqlServer("Data Source="+ nombrePC + "\\SQLEXPRESS; Initial Catalog = ObligatorioDDA2; Integrated Security = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
