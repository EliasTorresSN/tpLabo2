using FinalLaboratorioII.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalLaboratorioII.servicios
{
    internal class ServicioCombustible
    {
        public ServicioCombustible() { }


        public List<Combustible> crearListaCombustible()
        {
            List<Combustible>combustibles = new List<Combustible>();
            Combustible nafta= new Combustible(1, "Nafta");
            Combustible diesel = new Combustible(2, "Diesel");
            Combustible gnc = new Combustible(3, "GNC");
            Combustible electrico = new Combustible(4,"Eléctrico");

            combustibles.Add(nafta);
            combustibles.Add(diesel);
            combustibles.Add(gnc);
            combustibles.Add(electrico);
            return combustibles;
        }

        public int mostrarMenuInteractivo(List<Combustible> lista)
        {
            Console.Clear();

            Console.CursorVisible = false;
            int opcionElegida = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("INDIQUE COMBUSTIBLE");

                for (int i = 0; i < lista.Count; i++)
                {

                    if (i == opcionElegida)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine(lista[i]);
                    Console.ResetColor();
                }

                var key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        opcionElegida = Math.Max(0, opcionElegida - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        opcionElegida = Math.Min(lista.Count - 1, opcionElegida + 1);
                        break;
                    case ConsoleKey.Enter:
                        int res = opcionElegida;
                        return res;
                }
            }
        }
    }
}
