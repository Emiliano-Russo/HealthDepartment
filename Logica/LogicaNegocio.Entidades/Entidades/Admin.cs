using System;
using System.Diagnostics.CodeAnalysis;

namespace LogicaNegocio
{
    //Clave Email 
    public class Admin : IEquatable<Admin>
    {
        public string Email { get; set; }

        public string Contrasenia { get; set; }

        internal Admin Clon()
        {
            Admin agregarAdmin = new Admin
            {
                Email = this.Email,
                Contrasenia = this.Contrasenia
            };
            return agregarAdmin;
        }

        public bool Equals([AllowNull] Admin other)
        {
            return this.Email == other.Email;
        }
    }
}