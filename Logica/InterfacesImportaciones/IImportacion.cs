using Entidades;

namespace InterfacesImportaciones.IImportacion
{
    public interface IImportacion
    {
        public GaleriaMusical ConvertirDatos(string direccionArchivo);

        public bool FormatoCorrecto(string direccionArchivo);
    }
}
