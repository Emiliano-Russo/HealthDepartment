using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Excepciones
{
    public class ExcepcionDatosAdmin : Exception
    {
        public ExcepcionDatosAdmin(string error) : base(error)
        {

        }

    }
}
