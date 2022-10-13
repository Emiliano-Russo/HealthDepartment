using Entidades;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Entidades;

namespace Interfaces
{
    public interface ISistema
    {
        //Admin
        string IniciarSesion(Admin admin);

        void AgregarAdmin(Admin admin);

        void BorrarDatosDePrueba();

        bool ExisteSesionAdmin(string token);      

        bool ExisteSesionSuperAdmin(string token);

        //Musica

        List<CategoriaMusical> GetCategoriasMusicales();

        void BajaVideo(int v);

        GaleriaMusical GetGaleriaMusical(CategoriaMusical categoria);

        void RegistrarGaleriaMusical(GaleriaMusical galeriaMusical);

        Cancion GetCancion(String titulo, String autor);

        Playlist GetPlayList(int id);

        int AltaVideo(Video video, List<int> idPlayLists);

        Video GetVideo(int index);

        int AltaCancion(Cancion cancion);

        int AltaCancion(Cancion cancion, List<int> IdPlaylists);

        void BajaCancion(String titulo, String autor);

        int RegistrarPlaylist(Playlist playlist);

        List<Playlist> GetTodasLasPlayList();

        List<Cancion> GetTodasLasCanciones();

        List<Video> GetTodosLosVideos();


        //Psicologia
        List<CategoriaDolencia> GetProblematicas();

        Cita AgendarCita(Paciente paciente);

        int AltaPsicologo(Psicologo psicologo);

        void ModificarPsicologo(int id, Psicologo psicologo);

        void AplicarDescuento(Descuento descuento);

        List<string> TraerMailsAptosParaDescuento();

        void BajaPsicologo(int id);

        Psicologo GetPsicologo(int id);

        List<Psicologo> GetTodosLosPsicologos();

        //Reflection

        List<string> GetNombresImportadores();

        void LeerArchivo(string ruta, string tipoArchivo);
        int AltaVideo(Video video);
    }
}
