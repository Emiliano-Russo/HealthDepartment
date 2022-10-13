using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Entidades
{
    [Table("Sesion")]
    public class Sesion
    {
        public string Email { get; set; }
        [Key]
        public string Token { get; set; }

        public bool EsSuperAdmin { get; set; }
    }
}
