using System;
using System.Linq;

namespace Utilidades
{
    public class Util
    {
        public static bool FechasEnMismaSemanaEmpezandoElSabado(DateTime original, DateTime referencia)
        {
            DayOfWeek primerDiaSemana = DayOfWeek.Saturday;

            DateTime primerFechaSemana = referencia;
            while (primerFechaSemana.DayOfWeek != primerDiaSemana)
            { primerFechaSemana = primerFechaSemana.AddDays(-1d); }

            DateTime UltimaFechaSemana = primerFechaSemana.AddDays(6d);

            return original.Date >= primerFechaSemana.Date && original.Date <= UltimaFechaSemana.Date;
        }

        public static string StringAleatorio(int largo)
        {
            System.Random random = new System.Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, largo)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static bool EsSabadoODomingo(DateTime dia)
        {
            return dia.DayOfWeek == DayOfWeek.Saturday || dia.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}
