using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Interfaces.Validaciones
{
    interface IValidacionMusica
    {
        void ValidarGaleria(GaleriaMusical galeriaMusical);

        void ValidarExistenciaGaleria(CategoriaMusical categoria);

        void ExisteIDsPlayList(List<int> idPlaylists);

        void ValidarFormatoExistenciaCancion(string autor, string titulo);

        void ValidarPlaylist(Playlist playlist);

        void ValidarExistenciaPlayList(int id);

        void ValidarFormatoUnicidad(Cancion cancion);

        void ValidarFormatoExistencia(List<int> idPlaylists);

    }
}
