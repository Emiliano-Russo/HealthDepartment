using Entidades;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Entidades;

namespace Interfaces.Validaciones
{
    public interface IValidacionEntidades
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
        void ValidarDatosNuevos(GaleriaMusical galeria);
        void ValidarFormatoExistenciaVideo(Video video);
        void ValidarExistenciaVideo(int index);

        //Psicologia
        void ValidarFormatoPaciente(Paciente paciente);

        void ValidarFormatoPsicologo(Psicologo psicologo);

        void ValidarPsicologoExistencia(int id);
        void ValidacionDescuento(Descuento descuento);
        void ValidarFormatoUnicidad(Video video);
    }
}
