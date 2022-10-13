using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Reflection.Interfaces;
using Reflection.Excepciones;
using Relfection.Interfaces;

namespace Reflection
{
    public class MenuImportaciones : IMenuImportaciones
    {
        private string direccionCarpetaCodigoTerceros = "C:\\Assemblies";
        private IImportacion importadorSeleccionado;
        
        public MenuImportaciones()
        {
            this.importadorSeleccionado = null;
        }

        public List<string> DevolverNombresImportadores()
        {
            List<string> devolverNombreImportadores = new List<string>();
            if (Directory.GetFiles(direccionCarpetaCodigoTerceros, "*.dll").Length == 0) return devolverNombreImportadores;
            foreach (var archivoDll in Directory.GetFiles(direccionCarpetaCodigoTerceros, "*.dll"))
            {
                InsertarNombresEnLista(ref devolverNombreImportadores, archivoDll);
            }
            return devolverNombreImportadores;
        }

        public GaleriaMusical ProcesarFormatoImportacion(string direccionArchivo, string tipoImportador)
        {
            bool esValidaLaEstructuraArchivo = EsValidaEstructuraConImportador(direccionArchivo, tipoImportador);
            if (esValidaLaEstructuraArchivo)
            {
                return this.importadorSeleccionado.ConvertirDatos(direccionArchivo);
            }
            else
            {
                throw new ExcepcionMenuImportacion("La estructura del archivo no es la correcta");
            }
        }

        private bool EsValidaEstructuraConImportador(string direccionArchivo, string tipoImportador)
        {
            bool formatoCorrecto = false;
            foreach (var archvioDll in Directory.GetFiles(direccionCarpetaCodigoTerceros, "*.dll"))
            {
                var clasesConcretas = Assembly.LoadFrom(archvioDll);
                formatoCorrecto = this.EsValidaEstructuraParaInstanciaImportacion(clasesConcretas, direccionArchivo, tipoImportador);
                if (formatoCorrecto) return formatoCorrecto;
            }
            return formatoCorrecto;
        }

        private void InsertarNombresEnLista(ref List<string> devolverNombreImportadores, string archivoDll)
        {
            var clasesConcretas = Assembly.LoadFrom(archivoDll);
            foreach (var claseConcreta in clasesConcretas.GetTypes())
            {
                if (claseConcreta.GetInterface("IImportacion") == typeof(IImportacion))
                {
                    devolverNombreImportadores.Add(claseConcreta.Name);
                }
            }
        }

        private bool EsValidaEstructuraParaInstanciaImportacion(Assembly clasesConcretas, string direccionArchivo, string tipoImportador)
        {
            bool formatoCorrecto = false;
            foreach (var claseConcreta in clasesConcretas.GetTypes())
            {
                if (claseConcreta.GetInterface("IImportacion") == typeof(IImportacion))
                {
                    IImportacion instanciaImportacion = (IImportacion)Activator.CreateInstance(claseConcreta);
                    formatoCorrecto = instanciaImportacion.FormatoCorrecto(direccionArchivo);
                    if (formatoCorrecto)
                    {
                        importadorSeleccionado = instanciaImportacion;
                    }
                    return formatoCorrecto;
                }
            }
            return formatoCorrecto;
        }
    }
}
