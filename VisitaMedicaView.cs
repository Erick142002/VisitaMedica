using System;

namespace MP09.UF01.P01.VisitaMedica.model.domain
{
    public class VisitaMedicaView
    {
        public VisitaMedica GetVisitaMedica()
        {
            VisitaMedica visitaMedica = new VisitaMedica();

            Console.WriteLine("Introduzca el nombre del paciente: ");
            visitaMedica.NomPacient = Console.ReadLine();

            Console.WriteLine("Introduzca el nombre del médico: ");
            visitaMedica.NomMetge = Console.ReadLine();

            Console.WriteLine("Introduzca la fecha (dd/MM/yyyy HH:mm:ss): ");
            if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                visitaMedica.Data = date;
            }
            else
            {
                Console.WriteLine("Fecha inválida.");
            }

            Console.WriteLine("Introduzca el diagnóstico: ");
            visitaMedica.Diagnosi = Console.ReadLine();

            Console.WriteLine("Introduzca el mail: ");
            visitaMedica.Mail = Console.ReadLine();

            Console.WriteLine("Introduzca la contraseña: ");
            visitaMedica.Password = Console.ReadLine();

            return visitaMedica;
        }

        public void ShowVisitaMedica(VisitaMedica visitaMedica)
        {
            Console.WriteLine(visitaMedica.ToString());
        }

        public void ShowMissatge(string mensaje, bool esError)
        {
            if (esError)
            {
                Console.Error.WriteLine(mensaje);
            }
            else
            {
                Console.WriteLine(mensaje);
            }
        }
    }
}
