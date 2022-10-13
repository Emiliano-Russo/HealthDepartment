using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Excepciones
{
    public class ExcepcionPsicologia : Exception
    {
        public ExcepcionPsicologia(string error) : base(error)
        {

        }

    }
}
