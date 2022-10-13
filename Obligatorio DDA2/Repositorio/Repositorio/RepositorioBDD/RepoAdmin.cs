using System;
using Entidades;
using System.Collections.Generic;
using System.Text;
using Utilidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Repositorio.RepositorioBDD
{
    internal class RepoAdmin
    {
        private DbContextOptions<EntidadesContexto> opciones;

        public RepoAdmin(DbContextOptions<EntidadesContexto> opciones)
        {
            this.opciones = opciones;
        }

        internal void AgregarAdmin(Admin admin)
        {
            using (var contexto = new EntidadesContexto(opciones))
            {
                contexto.Admins.Add(admin);
                contexto.SaveChanges();
            }
        }

        internal bool ExisteAdmin(Admin admin)
        {
            bool existe = false;
            using(var contexto = new EntidadesContexto(opciones))
            {
                Admin a = contexto.Admins.Find(admin.Email);
                existe = a != null;
            }
            return existe;
        }

        internal bool ExisteSesionAdmin(string token)
        {
            bool existe = false;
            using(var contexto = new EntidadesContexto(opciones))
            {
                existe = contexto.SesionAdmin.Find(token) != null;
            }
            return existe;
        }

        internal bool ExisteSesionSuperAdmin(string token)
        {
            bool existe = false;
            Sesion sesion = null;
            using (var contexto = new EntidadesContexto(opciones))
            {
                sesion = contexto.SesionAdmin.Find(token);
                existe = sesion != null && sesion.EsSuperAdmin == true;
            }
            return existe;
        }

        internal string IniciarSesion(Admin admin)
        {
            Sesion sesion = new Sesion
            {
                Email = admin.Email,
                Token = Util.StringAleatorio(10),
                EsSuperAdmin = admin.EsSuperAdmin
            };
            using (var contexto = new EntidadesContexto(opciones))
            {
                admin = contexto.Admins.Find(admin.Email);
                sesion.EsSuperAdmin = admin.EsSuperAdmin;
                contexto.SesionAdmin.Add(sesion);
                contexto.SaveChanges();
            }
            return sesion.Token;
        }

        internal void BorrarTodosLosDatos()
        {
            using(var contexto = new EntidadesContexto(opciones))
            {
                contexto.Database.EnsureDeleted();
                contexto.SaveChanges();
            }
        }
    }
}
