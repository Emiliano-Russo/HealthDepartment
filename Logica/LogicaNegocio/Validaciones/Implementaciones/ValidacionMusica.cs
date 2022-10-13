using Entidades;
using Entidades.Entidades;
using Entidades.Indices;
using Interfaces;
using Interfaces.Validaciones;
using LogicaNegocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegocio.Validaciones
{
    internal class ValidacionMusica : IValidacionMusica
    {

        private IRepositorio repositorio;
        internal ValidacionMusica(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        //public

        public void ValidarDatosNuevos(GaleriaMusical galeria)
        {
            List<Cancion> listaCanciones = galeria.Canciones;
            List<Video> listaVideos = galeria.Videos;
            List<Playlist> listaPlaylist = galeria.PlayLists;

            ValidarNoNula(listaCanciones);
            foreach (var cancion in listaCanciones)
                this.ValidarFormatoCancion(cancion);

            ValidarNoNula(listaVideos);
            foreach (var video in listaVideos)
                this.DatosCorrectosVideo(video);

            ValidarNoNula(listaPlaylist);
            foreach (var playlist in listaPlaylist)
                ValidarDatosCorrectos(playlist);
        }

        public void ValidarGaleria(GaleriaMusical galeriaMusical)
        {
            List<Cancion> listaCanciones = galeriaMusical.Canciones;
            List<Playlist> listaPlaylist = galeriaMusical.PlayLists;
            ValidarListaCanciones(listaCanciones);
            ValidarListaPlayList(listaPlaylist);
            ValidarCorrespondeCategoria(galeriaMusical);
        }

        public void ValidarExistenciaGaleria(CategoriaMusical categoria)
        {
            GaleriaMusical galeria = repositorio.GetGaleriaMusical(categoria);
            if (galeria == null || galeria.Canciones == null)
                throw new ExcepcionMusica("No existe la Galeria Musical");
        }

        public void ExisteIDsPlayList(List<int> idPlaylists)
        {
            foreach (int id in idPlaylists)
            {
                Playlist playlist = repositorio.GetPlayList(id);
                ValidarNoNula(playlist);
            }
        }

        public void ValidarFormatoExistenciaCancion(string autor, string titulo)
        {
            if (String.IsNullOrEmpty(titulo) || String.IsNullOrEmpty(autor))
                throw new ExcepcionMusica("Nombre Autor Incorrecto");
            Cancion cancion = repositorio.GetCancion(titulo, autor);
            if (cancion == null || cancion.EsVacia())
                throw new ExcepcionMusica("No existe la cancion");
        }

        public void ValidarPlaylist(Playlist playlist)
        {
            ValidarNoNula(playlist);
            ValidarDatosCorrectos(playlist);
            List<Cancion> lista = (List<Cancion>)playlist.Canciones;
            ValidacionFormatoYExistencia(lista);
        }


        public void ValidarExistenciaPlayList(int id)
        {
            Playlist playlist = repositorio.GetPlayList(id);
            ValidarNoNula(playlist);
        }

        public void ValidarFormatoUnicidad(Cancion cancion)
        {
            ValidarFormatoCancion(cancion);
            ValidarUnicidadCancion(cancion.Autor, cancion.Titulo);
        }

        public void ValidarFormatoUnicidad(Video video)
        {
            ValidarFormatoVideo(video);
            ValidarUnicidadVideo(video.LinkVideo);
        }

        private void ValidarUnicidadVideo(string linkVideo)
        {
            bool existeVideo = repositorio.ExisteVideo(linkVideo);
            if (existeVideo)
                throw new ExcepcionMusica("El video ya existe");
        }

        private void ValidarFormatoVideo(Video video)
        {
            bool duracionPositiva = video.DuracionMins > 0;
            bool autorCorrecto = !String.IsNullOrEmpty(video.Autor);
            bool linkVideoCorrecto = !String.IsNullOrEmpty(video.LinkVideo);
            bool nombreCorrecto = !String.IsNullOrEmpty(video.Nombre);
            bool tieneCategorias = video.Categorias.Count != 0;
            bool todoOk = duracionPositiva && autorCorrecto && linkVideoCorrecto && nombreCorrecto && tieneCategorias;
            if (!todoOk)
                throw new ExcepcionMusica("Datos del video incorrectos");
        }

        public void ValidarFormatoExistencia(List<int> idPlaylists)
        {
            if (idPlaylists == null || !idPlaylists.Any())
                throw new ExcepcionMusica("Lista ID PlayList Nula o Vacia");
            bool numerosNaturales = idPlaylists.All(x => x >= 0);
            if (!numerosNaturales)
                throw new ExcepcionMusica("Lista Id PlayList incorrectos");
            foreach (var id in idPlaylists)
            {
                repositorio.GetPlayList(id);
            }
        }

        public void ValidarFormatoExistenciaVideo(Video video)
        {
            if (!DatosCorrectosVideo(video))
                throw new ExcepcionMusica("Datos Video Incorrectos");
            bool existeVideo = repositorio.ExisteVideo(video);
            if (!existeVideo)
                throw new ExcepcionMusica("El video no existe en el sistema");
        }

        public void ValidarExistenciaVideo(int index)
        {
            Video video = repositorio.GetVideo(index);
            if (video == null || !DatosCorrectosVideo(video))
                throw new ExcepcionMusica("ID de video no existente");
        }

        //Private

        private void ValidarDatosCorrectos(Playlist playlist)
        {
            bool nombreValido = !String.IsNullOrEmpty(playlist.Nombre);
            bool descripcionValido = !String.IsNullOrEmpty(playlist.Descripcion);
            bool listaCancionesNull = playlist.Canciones == null;
            if (!nombreValido || !descripcionValido || listaCancionesNull)
                throw new ExcepcionMusica("Datos de Playlist invalidos");
        }


        private bool DatosCorrectosVideo(Video video)
        {
            bool nombreCorrecto = !String.IsNullOrEmpty(video.Nombre);
            bool autorCorrecto = !String.IsNullOrEmpty(video.Autor);
            bool minsCorrectos = video.DuracionMins > 0;
            bool linkVideoCorrecto = !String.IsNullOrEmpty(video.LinkVideo);
            bool categoriasCorrectas = CategoriasVideoCorrectas(video.Categorias);
            if (!nombreCorrecto || !autorCorrecto
                || !minsCorrectos || !linkVideoCorrecto || !categoriasCorrectas)
                return false;
            return true;
        }

        private bool CategoriasVideoCorrectas(IReadOnlyCollection<TipoCategoriaMusical> categorias)
        {
            bool categoriasCorrectas = categorias.Count > 0
               && categorias.Count <= 4
               && categorias.Distinct().ToList().Count == categorias.Count;
            return categoriasCorrectas;
        }

        private void ValidarCorrespondeCategoria(GaleriaMusical galeriaMusical)
        {
            bool categoriaCorrecta = true;
            CategoriaMusical categoriaPrincipal = galeriaMusical.CategoriaMusical;
            categoriaCorrecta = categoriaCorrecta && CancionesIncluyeCategoria(galeriaMusical.Canciones, categoriaPrincipal);
            categoriaCorrecta = categoriaCorrecta && PlaylistsPertenecenCategoria(galeriaMusical.PlayLists, categoriaPrincipal);
            if (!categoriaCorrecta)
                throw new ExcepcionMusica("Categoria Musical no correspondiente");
        }

        private bool PlaylistsPertenecenCategoria(List<Playlist> playlists, CategoriaMusical categoriaPrincipal)
        {
            bool categoriaCorrecta = true;
            foreach (Playlist playlist in playlists)
                categoriaCorrecta = (categoriaCorrecta)
                    && playlist.Canciones.Any(c => c.CategoriaMusical.Contains(new TipoCategoriaMusical(categoriaPrincipal)));
            return categoriaCorrecta;
        }

        private bool CancionesIncluyeCategoria(List<Cancion> listaCanciones, CategoriaMusical categoriaPrincipal)
        {
            return listaCanciones.All(c => c.CategoriaMusical.Contains(new TipoCategoriaMusical(categoriaPrincipal)));
        }

        private void ValidarUnicidadCancion(string autor, string titulo)
        {
            Cancion cancion = repositorio.GetCancion(titulo, autor);
            if (cancion != null && !cancion.EsVacia())
                throw new ExcepcionMusica("La cancion ya existe");
        }

        private void ValidacionFormatoYExistencia(List<Cancion> listaCanciones)
        {
            ValidarNoNula(listaCanciones);
            foreach (Cancion cancion in listaCanciones)
            {
                this.ValidarFormatoExistenciaCancion(cancion.Autor, cancion.Titulo);
            }
        }

        private void ValidarFormatoCancion(Cancion cancion)
        {
            bool camposTextoValidos = ValidarCamposDeTexto(cancion);
            bool duracionValida = cancion.Duracion >= 0;
            bool listaCategoriaValida = ValidarListaCategorias((List<TipoCategoriaMusical>)cancion.CategoriaMusical);

            bool todoCorrecto = duracionValida && listaCategoriaValida && camposTextoValidos;
            if (!todoCorrecto)
                throw new ExcepcionMusica("Datos de cancion invalidos");
        }

        private bool ValidarCamposDeTexto(Cancion cancion)
        {
            bool autorValido = !String.IsNullOrEmpty(cancion.Autor);
            bool tituloValido = !String.IsNullOrEmpty(cancion.Titulo);
            bool descripcionValida = !String.IsNullOrEmpty(cancion.Descripcion) && cancion.Descripcion.Length <= 150;
            bool linkAudioValida = !String.IsNullOrEmpty(cancion.LinkAudio);
            bool linkImagenValida = cancion.LinkImagen != null;
            return autorValido && tituloValido && descripcionValida && linkAudioValida && linkImagenValida;
        }

        private bool ValidarListaCategorias(List<TipoCategoriaMusical> listaCategorias)
        {
            bool listaSinRepetir = listaCategorias.Distinct().Count() == listaCategorias.Count;
            bool listaNoVacia = listaCategorias.Count > 0;
            return listaSinRepetir && listaNoVacia;
        }

        private void ValidarListaCanciones(List<Cancion> listaCanciones)
        {
            ValidarNoNula(listaCanciones);

            foreach (var cancion in listaCanciones)
            {
                this.ValidarFormatoCancion(cancion);
                this.ValidarFormatoExistenciaCancion(cancion.Autor, cancion.Titulo);
            }
        }

        private void ValidarListaPlayList(List<Playlist> listaPlaylist)
        {
            ValidarNoNula(listaPlaylist);
            foreach (var playlist in listaPlaylist)
                this.ValidarPlaylist(playlist);
        }

        private void ValidarNoNula(List<Cancion> listaCanciones)
        {
            if (listaCanciones == null)
                throw new ExcepcionMusica("Lista Canciones null");
        }

        private void ValidarNoNula(List<Video> listaVideos)
        {
            if (listaVideos == null)
                throw new ExcepcionMusica("Lista Videos null");
        }

        private void ValidarNoNula(List<Playlist> listaPlaylist)
        {
            if (listaPlaylist == null)
                throw new ExcepcionMusica("Lista de PlayList null");
        }

        private void ValidarNoNula(Playlist playlist)
        {
            if (playlist == null)
                throw new ExcepcionMusica("Playlist Null");
            if (playlist.EsVacia())
                throw new ExcepcionMusica("No existe la PlayList");
        }

        
    }
}
