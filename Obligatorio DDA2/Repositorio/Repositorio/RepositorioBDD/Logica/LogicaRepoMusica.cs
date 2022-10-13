using Entidades;
using Entidades.Entidades;
using Entidades.Indices;
using Repositorio.Repositorio.RepositorioBDD.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio.Repositorio.RepositorioBDD.Logica
{
    internal class LogicaRepoMusica
    {
        internal Playlist TraerPlayList(int id, EntidadesContexto contexto)
        {
            Playlist playList = null;
            playList = contexto.PlayList.Find(id);
            if (playList != null)
            {
                List<Cancion> listaCanciones = ArmarCancionesParaPlayList(id, contexto);
                playList.SustituirListaCancion(listaCanciones);
                List<Video> listaVideos = ArmarVideoParaPlayList(id, contexto);
                playList.SustituirListVideos(listaVideos);
                List<CategoriaMusical> listaCategorias = ArmarCategoriasPlayList(id, contexto);
                playList.SustituirListaCategoriaMusical(listaCategorias);
            }
            else
                playList = new Playlist();
            return playList;
        }

        

        internal List<Playlist> ArmarPlayListsGaleria(EntidadesContexto contexto, CategoriaMusical categoria)
        {
            List<IXGaleriaPlayList> ixGaleriaPlayList = contexto.
                    IndiceGaleriaPlayList.Where(x => x.IDGaleria == categoria).ToList();

            List<Playlist> listaPlaylist = new List<Playlist>();
            foreach (IXGaleriaPlayList indice in ixGaleriaPlayList)
            {
                Playlist playlist = contexto.PlayList.Single(x => x.ID == indice.IDPlaylist);
                List<Cancion> listaCanciones = ArmarCancionesParaPlayList(playlist.ID, contexto);
                List<CategoriaMusical> listaCategorias = ArmarCategoriasPlayList(playlist.ID, contexto);

                playlist.SustituirListaCancion(listaCanciones);
                playlist.SustituirListaCategoriaMusical(listaCategorias);
                listaPlaylist.Add(playlist);
            }

            return listaPlaylist;
        }

        internal List<CategoriaMusical> ArmarCategoriasPlayList(int IDPlaylist, EntidadesContexto contexto)
        {
            List<CategoriaMusical> categoriasMusicales = new List<CategoriaMusical>();
            List<IXGaleriaPlayList> listaIndiceCancionGaleria = contexto
                                .IndiceGaleriaPlayList.Where(x => x.IDPlaylist == IDPlaylist).ToList();
            if (listaIndiceCancionGaleria == null) return categoriasMusicales;
            foreach (IXGaleriaPlayList indice in listaIndiceCancionGaleria)
                categoriasMusicales.Add(indice.IDGaleria);

            return categoriasMusicales;
        }

        internal List<Cancion> ArmarCancionesParaPlayList(int IDPlayList, EntidadesContexto contexto)
        {
            List<Cancion> listaCanciones = new List<Cancion>();
            List<IXCancionPlayList> listaIndiceCancionPlaylist = contexto.
                   IndiceCancionPlayList.ToList();
            listaIndiceCancionPlaylist = listaIndiceCancionPlaylist.Where(x => x.IDPlayList == IDPlayList).ToList();
            if (listaIndiceCancionPlaylist == null) return listaCanciones;
            foreach (IXCancionPlayList index in listaIndiceCancionPlaylist)
            {
                Cancion cancion = GetCancionConCategorias(index.IDCancion, contexto);
                listaCanciones.Add(cancion);
            }
            return listaCanciones;
        }

        private List<Video> ArmarVideoParaPlayList(int IDPlayList, EntidadesContexto contexto)
        {
            List<Video> listaVideos = new List<Video>();
            List<IXVideoPlayList> listaIndiceVideosPlaylist = contexto.
                IndiceVideoPlayList.Where(x => x.IDPlayList == IDPlayList).ToList();
            if (listaIndiceVideosPlaylist == null)
                return listaVideos;
            foreach (IXVideoPlayList index in listaIndiceVideosPlaylist)
            {
                Video video = GetVideoConCategorias(index.IDVideo, contexto);
                listaVideos.Add(video);
            }
            return listaVideos;
        }

        private Cancion GetCancionConCategorias(int IDCancion, EntidadesContexto contexto)
        {
            Cancion cancion = contexto.Canciones.Find(IDCancion);
            List<CategoriaMusical> listaCategorias = this.GetListaCategoria(IDCancion, contexto);
            cancion.SustituirListaCategorias(listaCategorias);
            return cancion;
        }

        private Video GetVideoConCategorias(int IDVideo, EntidadesContexto contexto)
        {
            Video video = contexto.Videos.Find(IDVideo);
            List<CategoriaMusical> listaCategorias = this.GetListaCategoria(IDVideo, contexto);
            video.SustituirListaCategorias(listaCategorias);
            return video;
        }

        internal List<Cancion> ArmarCancionesGaleria(EntidadesContexto contexto, CategoriaMusical categoria)
        {
            List<Cancion> listaCanciones = new List<Cancion>();
            List<IXCancionGaleria> listaCancionGaleria = contexto
                .IndiceCancionGaleria.Where(x => x.IDGaleria == categoria).ToList();
            if (listaCancionGaleria == null) return listaCanciones;
            foreach (IXCancionGaleria indice in listaCancionGaleria)
            {
                Cancion cancion = this.GetCancionConCategorias(indice.IDCancion, contexto);
                listaCanciones.Add(cancion);
            }
            return listaCanciones;
        }

        internal List<Video> ArmarVideoGaleria(EntidadesContexto contexto, CategoriaMusical categoria)
        {
            List<Video> listaVideos = new List<Video>();
            List<IXVideoGaleria> listaVideoGaleria = contexto.
                IndiceVideoGaleria.Where(x => x.IDGaleria == categoria).ToList();
            if (listaVideoGaleria == null) 
                return listaVideos;
            foreach (IXVideoGaleria indice in listaVideoGaleria)
            {
                Video video = this.GetVideoConCategorias(indice.IDVideo, contexto);
                listaVideos.Add(video);
            }
            return listaVideos;
        }

        internal List<CategoriaMusical> GetListaCategoria(int IDCancion, EntidadesContexto contexto)
        {
            List<CategoriaMusical> categoriasMusicales = new List<CategoriaMusical>();
            List<IXCancionGaleria> listaIndiceCancionGaleria = contexto
                    .IndiceCancionGaleria.Where(x => x.IDCancion == IDCancion).ToList();
            if (listaIndiceCancionGaleria == null) return categoriasMusicales;
            foreach (IXCancionGaleria indice in listaIndiceCancionGaleria)
                categoriasMusicales.Add(indice.IDGaleria);

            return categoriasMusicales;
        }

        internal void FiltrarCancioneSueltas(ref List<Playlist> listaPlayList, ref List<Cancion> listaCanciones)
        {
            foreach (Playlist playlist in listaPlayList)
                foreach (Cancion cancion in playlist.Canciones)
                    listaCanciones.Remove(cancion);
        }
        internal void FiltrarVideosSueltos(ref List<Playlist> listaPlayList, ref List<Video> listaVideos)
        {
            foreach (Playlist playlist in listaPlayList)           
                foreach (Video video in playlist.Videos)
                    listaVideos.Remove(video);           
        }

        internal List<CategoriaMusical> GetListaCategoriaVideo(int iD, EntidadesContexto contexto)
        {
            List<CategoriaMusical> categoriasMusicales = new List<CategoriaMusical>();
            List<IXVideoGaleria> listaIndiceVideoGaleria = contexto.
                    IndiceVideoGaleria.Where(x => x.IDVideo == iD).ToList();
            if  (listaIndiceVideoGaleria == null) return categoriasMusicales;
            listaIndiceVideoGaleria.ForEach(x => categoriasMusicales.Add(x.IDGaleria));
            return categoriasMusicales;
        }

        internal int RegistrarCancion(Cancion cancion, EntidadesContexto contexto)
        {
            cancion = cancion.Clon();
            contexto.Canciones.Add(cancion);
            contexto.SaveChanges();
            foreach (TipoCategoriaMusical tipoCategoria in cancion.CategoriaMusical)
            {
                IXCancionGaleria indice = new IXCancionGaleria(cancion.ID, tipoCategoria.Musical);
                contexto.IndiceCancionGaleria.Add(indice);
            }
            contexto.SaveChanges();

            return cancion.ID;
        }

        internal int RegistrarVideo(Video video, EntidadesContexto contexto)
        {
            contexto.Videos.Add(video);
            contexto.SaveChanges();
            foreach (TipoCategoriaMusical tipoCategoria in video.Categorias)
            {
                IXVideoGaleria indice = new IXVideoGaleria(video.ID, tipoCategoria.Musical);
                contexto.IndiceVideoGaleria.Add(indice);
            }
            contexto.SaveChanges();

            return video.ID;
        }

        internal int AltaPlayList(Playlist playlist, EntidadesContexto contexto)
        {
            contexto.PlayList.Add(playlist);
            contexto.SaveChanges();
            int idPlayList = playlist.ID;
            foreach (TipoCategoriaMusical tipoCategoria in playlist.Categorias)
            {
                IXGaleriaPlayList indiceGaleriaPlayList = new IXGaleriaPlayList(idPlayList, tipoCategoria.Musical);
                contexto.IndiceGaleriaPlayList.Add(indiceGaleriaPlayList);
            }
          
            foreach (Cancion cancion in playlist.Canciones)
            {
                IXCancionPlayList indice = new IXCancionPlayList(cancion.ID, idPlayList);
                contexto.IndiceCancionPlayList.Add(indice);
            }

            foreach (Video video in playlist.Videos)
            {
                IXVideoPlayList indice = new IXVideoPlayList(video.ID, idPlayList);
                contexto.IndiceVideoPlayList.Add(indice);
            }

            contexto.SaveChanges();
            return idPlayList;
        }

        internal void RemoverIndicesCancion(int idCancion, EntidadesContexto contexto)
        {
            List<IXCancionGaleria> listaIndiceCancionGaleria = contexto.
                    IndiceCancionGaleria.Where(x => x.IDCancion == idCancion).ToList();

            List<IXCancionPlayList> listaIndiceCancionPlayList = contexto.
                IndiceCancionPlayList.Where(x => x.IDCancion == idCancion).ToList();

            foreach (IXCancionGaleria index in listaIndiceCancionGaleria)
                contexto.IndiceCancionGaleria.Remove(index);

            if (listaIndiceCancionPlayList != null)
                foreach (IXCancionPlayList index in listaIndiceCancionPlayList)
                    contexto.IndiceCancionPlayList.Remove(index);
        }

        internal void RemoverIndiceVideo(int idVideo, EntidadesContexto contexto)
        {
            List<IXVideoGaleria> listaIndiceVideoGaleria = contexto.
                    IndiceVideoGaleria.Where(x => x.IDVideo == idVideo).ToList();

            List<IXVideoPlayList> listaIndiceVideoPlayList = contexto.
                    IndiceVideoPlayList.Where(x => x.IDVideo == idVideo).ToList();

            foreach (IXVideoGaleria index in listaIndiceVideoGaleria)
                contexto.IndiceVideoGaleria.Remove(index);

            if (listaIndiceVideoPlayList != null)
                foreach (IXVideoPlayList index in listaIndiceVideoPlayList)
                    contexto.IndiceVideoPlayList.Remove(index);
        }
    }
}
