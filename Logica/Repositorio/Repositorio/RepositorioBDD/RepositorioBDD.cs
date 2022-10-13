using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using Entidades.Entidades;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Repositorio.Repositorio.RepositorioBDD;
using Web.Api.Entidades;

namespace Repositorio.Repositorio.RepositorioBDD
{
    public class RepositorioBDD : IRepositorio
    {
        private RepoAdmin repositorioAdmin;
        private RepoMusica repositorioMusica;
        private RepoPsicologia repositorioPsicologia;

        public RepositorioBDD(DbContextOptions<EntidadesContexto> opciones)
        {
            repositorioAdmin = new RepoAdmin(opciones);
            repositorioMusica = new RepoMusica(opciones);
            repositorioPsicologia = new RepoPsicologia(opciones);
        }

        public Cita AgendarCita(Paciente paciente)
        {
            return repositorioPsicologia.AgendarCita(paciente);
        }

        public void AgregarAdmin(Admin admin)
        {
            repositorioAdmin.AgregarAdmin(admin);
        }

        public int AltaCancion(Cancion cancion, List<int> idPlaylists)
        {
            return repositorioMusica.AltaCancion(cancion, idPlaylists);
        }

        public int AltaCancion(Cancion cancion)
        {
            return repositorioMusica.AltaCancion(cancion);
        }

        public int AltaPsicologo(Psicologo psicologo)
        {
            return repositorioPsicologia.AltaPsicologo(psicologo);
        }

        public int AltaVideo(Video video)
        {
            return repositorioMusica.AltaVideo(video);
        }

        public int AltaVideo(Video video, List<int> idPlayLists)
        {
            return repositorioMusica.AltaVideo(video, idPlayLists);
        }

        public bool AptoParaDescuento(string email)
        {
            return repositorioPsicologia.AptoParaDescuento(email);
        }

        public void BajaCancion(string titulo, string autor)
        {
            repositorioMusica.BajaCancion(titulo, autor);
        }

        public void BajaPsicologo(int id)
        {
            repositorioPsicologia.BajaPsicologo(id);
        }

        public void BajaVideo(int index)
        {
            repositorioMusica.BajaVideo(index);
        }

        public void BorrarTodosLosDatos()
        {
            repositorioAdmin.BorrarTodosLosDatos();
            repositorioMusica.BorrarTodosLosDatos();
            repositorioPsicologia.BorrarTodosLosDatos();
        }

        public bool ExisteAdmin(Admin admin)
        {
            return repositorioAdmin.ExisteAdmin(admin);
        }

        public bool ExistePlayList(int id)
        {
            return repositorioMusica.ExistePlayList(id);
        }

        public bool ExistePsicologo(int id)
        {
            return repositorioPsicologia.ExistePsicologo(id);
        }

        public bool ExisteSesionAdmin(string token)
        {
            return repositorioAdmin.ExisteSesionAdmin(token);
        }

        public bool ExisteSesionSuperAdmin(string token)
        {
            return repositorioAdmin.ExisteSesionSuperAdmin(token);
        }

        public bool ExisteVideo(Video video)
        {
            return repositorioMusica.ExisteVideo(video);
        }

        public bool ExisteVideo(string linkVideo)
        {
            return repositorioMusica.ExisteVideo(linkVideo);
        }

        public Cancion GetCancion(string titulo, string autor)
        {
            return repositorioMusica.GetCancion(titulo, autor);
        }

        public List<CategoriaMusical> GetCategoriasMusicales()
        {
            return repositorioMusica.GetCategoriasMusicales();
        }

        public GaleriaMusical GetGaleriaMusical(CategoriaMusical categoria)
        {
            return repositorioMusica.GetGaleriaMusical(categoria);
        }

        public Playlist GetPlayList(int id)
        {
            return repositorioMusica.GetPlayList(id);
        }

        public List<CategoriaDolencia> GetProblematicas()
        {
            return repositorioPsicologia.GetProblematicas();
        }

        public Psicologo GetPsicologo(int id)
        {
            return repositorioPsicologia.GetPsicologo(id);
        }

        public List<Cancion> GetTodasLasCanciones()
        {
            return repositorioMusica.GetTodasLasCanciones();
        }

        public List<Playlist> GetTodasLasPlayLists()
        {
            return repositorioMusica.GetTodasLasPlayLists();
        }

        public List<Psicologo> GetTodosLosPsicologos()
        {
            return repositorioPsicologia.GetTodosLosPsicologos();
        }

        public List<Video> GetTodosLosVideos()
        {
            return repositorioMusica.GetTodosLosVideos();
        }

        public Video GetVideo(int index)
        {
            return repositorioMusica.GetVideo(index);
        }

        public void GuardarDescuento(Descuento descuento)
        {
            repositorioPsicologia.GuardarDescuento(descuento);
        }

        public bool HayPsicologosDisponibleParaEsaDolencia(CategoriaDolencia dolencia)
        {
            return repositorioPsicologia.HayPsicologosDisponibleParaEsaDolencia(dolencia);
        }

        public string IniciarSesion(Admin admin)
        {
            return repositorioAdmin.IniciarSesion(admin);
        }

        public void ModificarPsicologo(int id, Psicologo psicologo)
        {
            repositorioPsicologia.ModificarPsicologo(id, psicologo);
        }

        public void RegistrarGaleriaMusical(GaleriaMusical galeriaMusical)
        {
            repositorioMusica.RegistrarGaleriaMusical(galeriaMusical);
        }

        public int RegistrarPlaylist(Playlist playlist)
        {
            return repositorioMusica.RegistrarPlaylist(playlist);
        }

        public void SumarDatosGaleriaMusical(GaleriaMusical galeria)
        {
            repositorioMusica.SumarDatosGaleriaMusical(galeria);
        }

        public List<string> TraerMailsAptosParaDescuento()
        {
            return repositorioPsicologia.TraerMailsAptosParaDescuento();
        }
    }
}
