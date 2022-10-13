using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Interfaces.Validaciones
{
    interface IValidacionAdmin
    {
        void ValidarFormato(Admin admin);

        void ValidarFormatoUnicidad(Admin admin);

        void ValidarFormatoExistencia(Admin admin);
        void ValidarFormatoToken(string token);
    }
}
