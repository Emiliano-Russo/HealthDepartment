using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LogicaNegocio
{
    //ID es un int autogenerado
    public class Playlist
    {
        public int ID { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        private List<Cancion> canciones;

        private List<CategoriaMusical> categorias;

        public Playlist()
        {
            this.canciones = new List<Cancion>();
            this.Categorias = new List<CategoriaMusical>();
        }

        public IReadOnlyCollection<Cancion> Canciones
        {
            get
            {
                return canciones;
            }
        }

        public List<CategoriaMusical> Categorias
        {
            get
            {
                return categorias;
            }
            set
            {
                categorias = value;
                SumarCategoriasFaltantesParaCanciones(this.canciones);
            }
        }

        public void AgregarCancion(Cancion cancion)
        {
           cancion = SumarCategoriaFaltanteParaCancion(cancion);
           this.canciones.Add(cancion);
        }

        //Refactoreo
        public void SustituirListaCancion(List<Cancion> listaCancion)
        {
            if (listaCancion == null)
                return;
            if (listaCancion.Count == 0)
                this.canciones = listaCancion;
            foreach (Cancion cancion in listaCancion)
            {
                AgregarCancion(cancion);
            }
        }

        public void QuitarCancion(string autor, string titulo)
        {
            Cancion cancion = this.canciones.Find(c => c.Autor == autor && c.Titulo == titulo);
            this.canciones.Remove(cancion);
        }

        //Refactoreo
        private List<Cancion> SumarCategoriasFaltantesParaCanciones(List<Cancion> lista)
        {
            List<Cancion> listaCanciones = new List<Cancion>();
            if (lista == null)
                return null;

            foreach (Cancion cancion in lista)
            {
                listaCanciones.Add(SumarCategoriaFaltanteParaCancion(cancion));
            }
            return listaCanciones;
        }

        //Refactoreo
        private Cancion SumarCategoriaFaltanteParaCancion(Cancion cancion)
        {
            if (this.categorias == null)
                return cancion;
            foreach (CategoriaMusical categoria in this.Categorias)
            {
                if(!cancion.CategoriaMusical.Contains(categoria))
                    cancion.CategoriaMusical.Add(categoria);
            }
            return cancion;
        }

        //Refactoreo
        internal bool EsVacia()
        {
            if (Nombre == null || Descripcion == null || canciones == null || categorias == null)
                return true;
            else 
                return false;
        }

        //Refactoreo
        internal Playlist Clon()
        {
            Playlist playlist = new Playlist
            {
                Categorias = this.Categorias,
                Descripcion = this.Descripcion,
                Nombre = this.Nombre
            };
            List<Cancion> lista = (List<Cancion>)this.Canciones;
            playlist.SustituirListaCancion(lista);
            return playlist;
        }
    }
}