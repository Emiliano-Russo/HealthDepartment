using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Entidades
{
 
    [Table("Admin")]
    public class Admin : IEquatable<Admin>
    {
        [Key]
        public string Email { get; set; }

        public string Contrasenia { get; set; }

        public bool EsSuperAdmin { get; set; }

        public bool Equals([AllowNull] Admin other)
        {
            return this.Email == other.Email;
        }
    }
}