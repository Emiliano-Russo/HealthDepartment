using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Excepciones
{
    public class ExcepcionMusica : Exception
    {

        public ExcepcionMusica(string error) : base(error)
        {

        }

    }
}
