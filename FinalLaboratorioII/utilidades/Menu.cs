using FinalLaboratorioII.servicios;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalLaboratorioII.utilidades
{
    internal class Menu
    {
        public Menu() { }



        public void menu()
        {
            ServicioVehiculo sv = new ServicioVehiculo();
            ServicioLocalidad sl = new ServicioLocalidad();
            Console.CursorVisible = false;
            string[] opciones = { "CLIENTES", "VEHICULOS", "VENTAS", "LOCALIDADES" };
            int opcionElegida = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Tecla Enter para seleccionar opción - Tecla escape para salir");

                for (int i = 0; i < opciones.Length; i++)
                {
                    if (i == opcionElegida)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine(opciones[i]);
                    Console.ResetColor();
                }

                var key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        opcionElegida = Math.Max(0, opcionElegida - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        opcionElegida = Math.Min(opciones.Length - 1, opcionElegida + 1);
                        break;
                    case ConsoleKey.Enter:

                        if (opcionElegida == 0)
                        {

                        }
                        else if (opcionElegida == 1)
                        {
                            sv.menuVehiculos();
                        }
                        else if (opcionElegida == 2)
                        {
                        }
                        else if (opcionElegida == 3)
                        {
                            sl.menuLocalidades();

                        }
                        else if (opcionElegida == opciones.Length - 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Saliendo del programa.");
                            return;
                        }
                        Console.Clear();
                        Console.WriteLine("Volviendo al menu principal");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Console.WriteLine("AAplicación cerrada.");
                        Console.ReadKey();
                        Process proc = Process.GetCurrentProcess();
                        proc.Kill();
                        break;
                }
            }
        }
    }
}
