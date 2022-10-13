using Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Entidades;

namespace Interfaces.Validaciones
{
    public interface IValidacionPsicologia
    {
        void ValidarFormatoPaciente(Paciente paciente);

        void ValidarFormatoPsicologo(Psicologo psicologo);

        void ValidarPsicologoExistencia(int id);
        void ValidarDescuento(Descuento descuento);
    }
}
