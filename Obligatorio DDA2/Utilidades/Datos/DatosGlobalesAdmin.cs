using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utilidades
{
    public static class DatosGlobalesAdmin
    {

        public static Admin GetAdminCorrecto()
        {
            Admin admin = new Admin
            {
                Email = "jorge@gmail.com",
                Contrasenia = "1234"
            };
            return admin;
        }

        public static Admin GetAdminIncorrecto()
        {
            Admin admin = new Admin
            {
                Email = "",
                Contrasenia = null
            };
            return admin;
        }

    }
}
