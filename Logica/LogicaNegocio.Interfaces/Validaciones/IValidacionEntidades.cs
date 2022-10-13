using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Interfaces.Validaciones
{
    interface IValidacionEntidades
    {
        //Admins
        void ValidarFormato(Admin admin);

        void ValidarFormatoUnicidad(Admin admin);

        void ValidarFormatoExistencia(Admin admin);

        void ValidarFormatoToken(string token);
        //Musica
        void ValidarGaleria(GaleriaMusical galeriaMusical);

        void ValidarExistenciaGaleria(CategoriaMusical categoria);

        void ExisteIDsPlayList(List<int> idPlaylists);

        void ValidarFormatoExistenciaCancion(string autor, string titulo);

        void ValidarPlaylist(Playlist playlist);

        void ValidarExistenciaPlayList(int id);

        void ValidarFormatoUnicidad(Cancion cancion);

        void ValidarFormatoExistencia(List<int> idPlaylists);

        //Psicologia
        void ValidarFormatoPaciente(Paciente paciente);

        void ValidarFormatoPsicologo(Psicologo psicologo);

        void ValidarPsicologoExistencia(int id);
        
    }
}
