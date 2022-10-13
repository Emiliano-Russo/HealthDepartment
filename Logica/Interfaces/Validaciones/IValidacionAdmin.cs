using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Validaciones
{
    public interface IValidacionAdmin
    {
        void ValidarFormato(Admin admin);

        void ValidarFormatoUnicidad(Admin admin);

        void ValidarFormatoExistencia(Admin admin);
        void ValidarFormatoToken(string token);
    }
}
