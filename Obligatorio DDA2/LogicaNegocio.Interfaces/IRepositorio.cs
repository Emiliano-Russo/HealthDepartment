using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Interfaces
{
    interface IRepositorio
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

        //Musica
        List<CategoriaMusical> GetCategoriasMusicales();
        GaleriaMusical GetGaleriaMusical(CategoriaMusical categoria);
        void RegistrarGaleriaMusical(GaleriaMusical galeriaMusical);
        Cancion GetCancion(String titulo, String autor);
        Playlist GetPlayList(int id);
        bool ExistePlayList(int id);
        void AltaCancion(Cancion cancion, List<int> IdPlaylists);
        void BajaCancion(String titulo, String autor);
        int RegistrarPlaylist(Playlist playlist);
        void AltaCancion(Cancion cancion);
        List<Playlist> GetTodasLasPlayLists();

        //Admin
        bool ExisteAdmin(Admin admin);
        string IniciarSesion(Admin admin);
        void AgregarAdmin(Admin admin);
        bool ExisteSesionAdmin(string token);
        bool ExisteSesionSuperAdmin(string token);


    }
}
