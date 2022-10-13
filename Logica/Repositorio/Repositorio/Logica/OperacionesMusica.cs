using Entidades;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Repositorio.Logica
{
    internal class OperacionesMusica
    {
        internal GaleriaMusical SumarDatosGaleria(GaleriaMusical galeriaNueva, GaleriaMusical galeriaDelSistema)
        {
            this.RegistrarVideosFiltrando(galeriaNueva, ref galeriaDelSistema);
            this.RegistrarCancionesFiltrando(galeriaNueva, ref galeriaDelSistema);
            this.RegistrarPlayListFiltrando(galeriaNueva, ref galeriaDelSistema);
            return galeriaDelSistema;
        }

        private void RegistrarVideosFiltrando(GaleriaMusical galeriaNueva, ref GaleriaMusical galeriaDelSistema)
        {
            foreach (Video video in galeriaNueva.Videos)
                if (!galeriaDelSistema.Videos.Contains(video))
                    galeriaDelSistema.Videos.Add(video);
        }

        private void RegistrarCancionesFiltrando(GaleriaMusical galeriaNueva, ref GaleriaMusical galeriaDelSistema)
        {
            foreach (Cancion cancion in galeriaNueva.Canciones)
                if (!galeriaDelSistema.Canciones.Contains(cancion))
                    galeriaDelSistema.Canciones.Add(cancion);
        }

        private void RegistrarPlayListFiltrando(GaleriaMusical galeriaNueva, ref GaleriaMusical galeriaDelSistema)
        {
            foreach (Playlist playlist in galeriaNueva.PlayLists)
                if (!galeriaDelSistema.PlayLists.Contains(playlist))
                    galeriaDelSistema.PlayLists.Add(playlist);
        }
    }
}
