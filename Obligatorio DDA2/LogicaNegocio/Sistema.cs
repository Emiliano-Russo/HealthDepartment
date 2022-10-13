using Entidades;
using Entidades.Entidades;
using Interfaces;
using Interfaces.Validaciones;
using LogicaNegocio.Validaciones.Implementaciones;
using Reflection;
using Relfection.Interfaces;
using System;
using System.Collections.Generic;
using Web.Api.Entidades;

namespace LogicaNegocio
{
    public class Sistema : ISistema
    {
        private IRepositorio memoria;
        private IValidacionEntidades validacion;
        private IMenuImportaciones menuImportacion;

        public Sistema(IRepositorio repositorio, IValidacionEntidades validacion, IMenuImportaciones menuImportacion)
        {
            this.memoria = repositorio;
            this.validacion = validacion;
            this.menuImportacion = menuImportacion;
        }

        //Opreaciones Usuario
        public List<CategoriaDolencia> GetProblematicas()
        {
            return memoria.GetProblematicas();
        }

        public Cita AgendarCita(Paciente paciente)
        {
            validacion.ValidarFormatoPaciente(paciente);
            return memoria.AgendarCita(paciente);
        }

        public List<CategoriaMusical> GetCategoriasMusicales()
        {
            return memoria.GetCategoriasMusicales();
        }

        public GaleriaMusical GetGaleriaMusical(CategoriaMusical categoria)
        {
            validacion.ValidarExistenciaGaleria(categoria);
            GaleriaMusical galeriaMusical = memoria.GetGaleriaMusical(categoria);
            return galeriaMusical;
        }

        public void RegistrarGaleriaMusical(GaleriaMusical galeriaMusical)
        {
            validacion.ValidarGaleria(galeriaMusical);
            memoria.RegistrarGaleriaMusical(galeriaMusical);
        }

        public Cancion GetCancion(String titulo, String autor)
        {
            validacion.ValidarFormatoExistenciaCancion(autor, titulo);
            return memoria.GetCancion(titulo, autor);
        }

        public Playlist GetPlayList(int id)
        {
            validacion.ValidarExistenciaPlayList(id);
            return memoria.GetPlayList(id);
        }

        //Opreaciones Administrador

        public int AltaPsicologo(Psicologo psicologo)
        {
            validacion.ValidarFormatoPsicologo(psicologo);
            return memoria.AltaPsicologo(psicologo);
        }

        public void ModificarPsicologo(int id, Psicologo psicologo)
        {
            validacion.ValidarFormatoPsicologo(psicologo);
            validacion.ValidarPsicologoExistencia(id);
            memoria.ModificarPsicologo(id, psicologo);
        }

        public void BajaPsicologo(int id)
        {
            validacion.ValidarPsicologoExistencia(id);
            memoria.BajaPsicologo(id);
        }

        public int AltaCancion(Cancion cancion)
        {
            validacion.ValidarFormatoUnicidad(cancion);
            return memoria.AltaCancion(cancion);
        }
        public int AltaVideo(Video video)
        {
            validacion.ValidarFormatoUnicidad(video);
            return memoria.AltaVideo(video);
        }

        public void BajaVideo(int index)
        {
            validacion.ValidarExistenciaVideo(index);
            memoria.BajaVideo(index);
        }

        public Video GetVideo(int index)
        {
            return memoria.GetVideo(index);
        }

        public int AltaCancion(Cancion cancion, List<int> IdPlaylists)
        {
            validacion.ValidarFormatoUnicidad(cancion);
            validacion.ValidarFormatoExistencia(IdPlaylists);
            return memoria.AltaCancion(cancion, IdPlaylists);
        }

        public int AltaVideo(Video video, List<int> idPlayLists)
        {
            validacion.ValidarFormatoUnicidad(video);
            validacion.ValidarFormatoExistencia(idPlayLists);
            return memoria.AltaVideo(video, idPlayLists);
        }

        public void BajaCancion(String titulo, String autor)
        {
            validacion.ValidarFormatoExistenciaCancion(autor, titulo);
            memoria.BajaCancion(titulo, autor);
        }

        public int RegistrarPlaylist(Playlist playlist)
        {
            validacion.ValidarPlaylist(playlist);
            return memoria.RegistrarPlaylist(playlist);
        }

        public Psicologo GetPsicologo(int id)
        {
            validacion.ValidarPsicologoExistencia(id);
            return memoria.GetPsicologo(id);
        }

        public List<Psicologo> GetTodosLosPsicologos()
        {
            return memoria.GetTodosLosPsicologos();
        }

        public void AplicarDescuento(Descuento descuento)
        {
            validacion.ValidacionDescuento(descuento);
            memoria.GuardarDescuento(descuento);
        }

        public List<Cancion> GetTodasLasCanciones()
        {
            return memoria.GetTodasLasCanciones();
        }

        public List<Video> GetTodosLosVideos()
        {
            return memoria.GetTodosLosVideos();
        }

        public List<string> TraerMailsAptosParaDescuento()
        {
            return memoria.TraerMailsAptosParaDescuento();
        }
        
        public List<string> GetNombresImportadores()
        {
            return menuImportacion.DevolverNombresImportadores();
        }

        

        //Opreaciones Super Administrador
        public void AgregarAdmin(Admin admin)
        {
            validacion.ValidarFormatoUnicidad(admin);
            memoria.AgregarAdmin(admin);
        }

        public void BorrarDatosDePrueba()
        {
            memoria.BorrarTodosLosDatos();
        }

        public List<Playlist> GetTodasLasPlayList()
        {
            return memoria.GetTodasLasPlayLists();
        }

        public bool ExisteSesionAdmin(string token)
        {
            validacion.ValidarFormatoToken(token);
            return memoria.ExisteSesionAdmin(token);
        }

        public bool ExisteSesionSuperAdmin(string token)
        {
            validacion.ValidarFormatoToken(token);
            return memoria.ExisteSesionSuperAdmin(token);
        }

        public string IniciarSesion(Admin admin)
        {
            validacion.ValidarFormatoExistencia(admin);
            return memoria.IniciarSesion(admin);
        }  

        public void LeerArchivo(string dirArchivo, string tipoImportador)
        {
            GaleriaMusical galeria = menuImportacion.ProcesarFormatoImportacion(dirArchivo, tipoImportador);
            this.validacion.ValidarDatosNuevos(galeria);
            this.memoria.SumarDatosGaleriaMusical(galeria);
        }

        
    }
}
