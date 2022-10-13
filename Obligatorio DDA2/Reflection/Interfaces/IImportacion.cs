using Entidades;

namespace Reflection.Interfaces
{
    public interface IImportacion
    {
        public GaleriaMusical ConvertirDatos(string direccionArchivo);

        public bool FormatoCorrecto(string direccionArchivo);
    }
}
