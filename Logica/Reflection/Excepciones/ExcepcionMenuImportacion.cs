using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection.Excepciones
{
    public class ExcepcionMenuImportacion : Exception
    {
        public ExcepcionMenuImportacion(string error) : base(error)
        {

        }
    }
}
