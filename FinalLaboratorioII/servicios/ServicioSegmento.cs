using FinalLaboratorioII.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalLaboratorioII.servicios
{
    internal class ServicioSegmento
    {
        public ServicioSegmento() { }



        public List<Segmento> crearListaSegmentos()
        {
            List<Segmento>segmentos = new List<Segmento>();

            Segmento sedan = new Segmento(1, "Sedan");
            Segmento coupe = new Segmento(2, "Coupe");
            Segmento suv= new Segmento(3, "SUV");
            Segmento pickup = new Segmento(4, "Pick Up");
            Segmento enduro= new Segmento(5, "Enduro");
            Segmento rutera= new Segmento(6, "Rutera");
            Segmento scooter=new Segmento(7, "Scooter");
            Segmento camion = new Segmento(8, "Camión");

            segmentos.Add(sedan);
            segmentos.Add(coupe);   
            segmentos.Add(suv);
            segmentos.Add(pickup);
            segmentos.Add(enduro);
            segmentos.Add(rutera);
            segmentos.Add(scooter);
            segmentos.Add(camion);

            return segmentos;
        }


        public int mostrarMenuInteractivo(List<Segmento> lista)
        {
            Console.Clear();
            Console.CursorVisible = false;
            int opcionElegida = 0;

            while (true)
            {
                Console.Clear();

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
