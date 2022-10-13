using Entidades;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Entidades;

namespace Interfaces
{
    public interface IRepositorio
    {
        //Psicologia
        List<CategoriaDolencia> GetProblematicas();
        Cita AgendarCita(Paciente paciente);
        int AltaPsicologo(Psicologo psicologo);
        void ModificarPsicologo(int id, Psicologo psicologo);
        void BajaPsicologo(int id);
        Psicologo GetPsicologo(int id);
        bool ExistePsicologo(int id);
        bool HayPsicologosDisponibleParaEsaDolencia(CategoriaDolencia dolencia);
        List<Psicologo> GetTodosLosPsicologos();
        void GuardarDescuento(Descuento descuento);

        //Musica
        List<CategoriaMusical> GetCategoriasMusicales();
        GaleriaMusical GetGaleriaMusical(CategoriaMusical categoria);
        void RegistrarGaleriaMusical(GaleriaMusical galeriaMusical);
        Cancion GetCancion(String titulo, String autor);
        Playlist GetPlayList(int id);
        bool ExistePlayList(int id);
        int AltaCancion(Cancion cancion, List<int> IdPlaylists);
        void BajaCancion(String titulo, String autor);
        int RegistrarPlaylist(Playlist playlist);
        int AltaCancion(Cancion cancion);
        List<Playlist> GetTodasLasPlayLists();
        void SumarDatosGaleriaMusical(GaleriaMusical galeria);

        //Admin
        bool ExisteAdmin(Admin admin);
        string IniciarSesion(Admin admin);
        void AgregarAdmin(Admin admin);
        bool ExisteSesionAdmin(string token);
        bool ExisteSesionSuperAdmin(string token);
        bool AptoParaDescuento(string email);
        int AltaVideo(Video video, List<int> idPlayLists);
        bool ExisteVideo(Video video);
        Video GetVideo(int index);
        void BajaVideo(int index);
        List<Cancion> GetTodasLasCanciones();
        List<Video> GetTodosLosVideos();
        List<string> TraerMailsAptosParaDescuento();
        void BorrarTodosLosDatos();
        int AltaVideo(Video video);
        bool ExisteVideo(string linkVideo);
    }
}
