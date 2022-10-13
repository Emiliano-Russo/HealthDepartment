using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Interfaces.Validaciones
{
    interface IValidacionPsicologia
    {
        void ValidarFormatoPaciente(Paciente paciente);

        void ValidarFormatoPsicologo(Psicologo psicologo);

        void ValidarPsicologoExistencia(int id);

    }
}
