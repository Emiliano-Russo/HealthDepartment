using LogicaNegocio.Enumeraciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Interfaces
{
    public interface ISistema
    {
        void SetMemoria(TipoMemoria tipo);

        List<CategoriaDolencia> GetProblematicas();

        Cita AgendarCita(Paciente paciente);

        List<CategoriaMusical> GetCategoriasMusicales();

        GaleriaMusical GetGaleriaMusical(CategoriaMusical categoria);

        void RegistrarGaleriaMusical(GaleriaMusical galeriaMusical);

        Cancion GetCancion(String titulo, String autor);

        Playlist GetPlayList(int id);

        string IniciarSesion(Admin admin);

        int AltaPsicologo(Psicologo psicologo);

        void ModificarPsicologo(int id, Psicologo psicologo);

        void BajaPsicologo(int id);

        void AltaCancion(Cancion cancion);

        void AltaCancion(Cancion cancion, List<int> IdPlaylists);

        void BajaCancion(String titulo, String autor);

        int RegistrarPlaylist(Playlist playlist);

        Psicologo GetPsicologo(int id);

        void AgregarAdmin(Admin admin);

        void BorrarDatosDePrueba();

        List<Playlist> GetTodasLasPlayList();

        List<Psicologo> GetTodosLosPsicologos();

        bool ExisteSesionAdmin(string token);

        bool ExisteSesionSuperAdmin(string token);
    }
}
