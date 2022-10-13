using Entidades;
using Entidades.Entidades;
using Interfaces;
using Interfaces.Validaciones;
using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Entidades;

namespace LogicaNegocio.Validaciones.Implementaciones
{
    public class ValidacionEntidades : IValidacionEntidades
    {
        private IValidacionAdmin validacionAdmin;
        private IValidacionMusica validacionMusica;
        private IValidacionPsicologia validacionPsicologia;

        public ValidacionEntidades(IRepositorio repositorio)
        {
            validacionAdmin = new ValidacionAdmin(repositorio);
            validacionMusica = new ValidacionMusica(repositorio);
            validacionPsicologia = new ValidacionPsicologia(repositorio);
        }

        public void ExisteIDsPlayList(List<int> idPlaylists)
        {
            validacionMusica.ExisteIDsPlayList(idPlaylists);
        }

        public void ValidarFormatoExistenciaCancion(string autor, string titulo)
        {
            validacionMusica.ValidarFormatoExistenciaCancion(autor, titulo);
        }

        public void ValidarExistenciaGaleria(CategoriaMusical categoria)
        {
            validacionMusica.ValidarExistenciaGaleria(categoria);
        }

        public void ValidarExistenciaPlayList(int id)
        {
            validacionMusica.ValidarExistenciaPlayList(id);
        }

        public void ValidarFormato(Admin admin)
        {
            validacionAdmin.ValidarFormato(admin);
        }

        public void ValidarFormatoExistencia(List<int> idPlaylists)
        {
            validacionMusica.ValidarFormatoExistencia(idPlaylists);
        }

        public void ValidarFormatoPaciente(Paciente paciente)
        {
            validacionPsicologia.ValidarFormatoPaciente(paciente);
        }

        public void ValidarFormatoPsicologo(Psicologo psicologo)
        {
            validacionPsicologia.ValidarFormatoPsicologo(psicologo);
        }

        public void ValidarFormatoUnicidad(Admin admin)
        {
            validacionAdmin.ValidarFormatoUnicidad(admin);
        }

        public void ValidarFormatoUnicidad(Cancion cancion)
        {
            validacionMusica.ValidarFormatoUnicidad(cancion);
        }

        public void ValidarGaleria(GaleriaMusical galeriaMusical)
        {
            validacionMusica.ValidarGaleria(galeriaMusical);
        }

        public void ValidarPlaylist(Playlist playlist)
        {
            validacionMusica.ValidarPlaylist(playlist);
        }

        public void ValidarPsicologoExistencia(int id)
        {
            validacionPsicologia.ValidarPsicologoExistencia(id);
        }

        public void ValidarFormatoExistencia(Admin admin)
        {
            validacionAdmin.ValidarFormatoExistencia(admin);
        }

        public void ValidarFormatoToken(string token)
        {
            validacionAdmin.ValidarFormatoToken(token);
        }

        public void ValidacionDescuento(Descuento descuento)
        {
            validacionPsicologia.ValidarDescuento(descuento);
        }

        public void ValidarFormatoExistenciaVideo(Video video)
        {
            validacionMusica.ValidarFormatoExistenciaVideo(video);
        }

        public void ValidarExistenciaVideo(int index)
        {
            validacionMusica.ValidarExistenciaVideo(index);
        }

        public void ValidarDatosNuevos(GaleriaMusical galeria)
        {
            validacionMusica.ValidarDatosNuevos(galeria);
        }

        public void ValidarFormatoUnicidad(Video video)
        {
            validacionMusica.ValidarFormatoUnicidad(video);
        }
    }
}
