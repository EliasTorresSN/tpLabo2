using FinalLaboratorioII.entidades;
using FinalLaboratorioII.entidades.subEntidades;
using FinalLaboratorioII.servicios;
using System.IO;

namespace FinalLaboratorioII
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicioVehiculo sv = new ServicioVehiculo();
            //List<string> listaVehiculos = sv.cargarVehiculoEnLista();
            //sv.cargarListaEnArchivo(listaVehiculos);


            Console.CursorVisible = false;
            string[] options = { "Opción 1", "Vehiculos", "Opción 3", "Salir" };
            int selectedOption = 0;

            while (true)
            {
                Console.Clear();
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedOption)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine(options[i]);
                    Console.ResetColor();
                }

                var key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selectedOption = Math.Max(0, selectedOption - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        selectedOption = Math.Min(options.Length - 1, selectedOption + 1);
                        break;
                    case ConsoleKey.Enter:

                        if (selectedOption == 0)
                        {

                        }
                        else if (selectedOption == 1)
                        {
                            sv.menuVehiculos();
                        }
                        else if (selectedOption == options.Length - 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Saliendo del programa.");
                            return;
                        }


                        // Realiza alguna acción según la opción seleccionada.
                        Console.Clear();
                        Console.WriteLine($"Seleccionaste: {options[selectedOption]}");
                        Console.ReadKey();
                        break;
                }
            }






        }


    }

}