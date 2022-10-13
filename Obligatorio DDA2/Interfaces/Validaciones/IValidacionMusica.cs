using Entidades;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Validaciones
{
    public interface IValidacionMusica
    {
        void ValidarGaleria(GaleriaMusical galeriaMusical);

        void ValidarExistenciaGaleria(CategoriaMusical categoria);

        void ExisteIDsPlayList(List<int> idPlaylists);

        void ValidarFormatoExistenciaCancion(string autor, string titulo);

        void ValidarPlaylist(Playlist playlist);

        void ValidarExistenciaPlayList(int id);

        void ValidarFormatoUnicidad(Cancion cancion);

        void ValidarFormatoExistencia(List<int> idPlaylists);
        void ValidarFormatoExistenciaVideo(Video video);
        void ValidarExistenciaVideo(int index);
        void ValidarDatosNuevos(GaleriaMusical galeria);
        void ValidarFormatoUnicidad(Video video);
    }
}
