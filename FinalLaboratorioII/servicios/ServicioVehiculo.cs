using FinalLaboratorioII.entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalLaboratorioII.servicios
{
    internal class ServicioVehiculo
    {

        public ServicioVehiculo()
        {

        }

        public Vehiculo crearVehiculo()
        {
            Vehiculo vehiculo1 = new Vehiculo();
            Console.WriteLine("Nuevo vehículo");
            Console.WriteLine("Ingrese patente");
            vehiculo1.Patente = Console.ReadLine();
            Console.WriteLine("Cantidad de kilometros");
            vehiculo1.Kilometros = Console.ReadLine();
            Console.WriteLine("Año");
            vehiculo1.Anio = Console.ReadLine();
            Console.WriteLine("id_marca");
            Console.WriteLine("Modelo:");
            vehiculo1.Modelo = Console.ReadLine();
            Console.WriteLine("id_segmento");
            Console.WriteLine("id_combustible");
            Console.WriteLine("Precio:");
            vehiculo1.Precio_vta = float.Parse(Console.ReadLine());
            Console.WriteLine("Observaciones:");
            vehiculo1.Observaciones = Console.ReadLine();

            return vehiculo1;
        }

        public void mostrarVehiculos(string _ruta)
        {
            List<string>lista = cargarArchivoEnLista(_ruta);
            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }
        }
       
        public void actualizarVehiculo(int _id,string _ruta)
        {
            int cont = 0;
           
            string lineaAReemplazar = "";
            string res = "";
            List<string>lista = cargarArchivoEnLista(_ruta);


            Console.WriteLine("Modificar el ultimo vehiculo cargado?");
            res = Console.ReadLine();
            if (res != "si")
            {
                Console.WriteLine("Datos del ultimo vehiculo cargado");
                Console.WriteLine(lista[lista.Count - 1]);
            }




            foreach (var item in lista)
            {

                if (item.Substring(4, 2).Equals($"{_id}"))
                {
                    lineaAReemplazar = item;
                    Console.WriteLine("Datos del vehículo: ");
                    Console.WriteLine(item);
                    Console.Write("Modificar datos? -> S/N");
                    res = Console.ReadLine();
                    cont = 1;
                    break;
                }
            }
          
        }

        public List<string> cargarArchivoEnLista(string _ruta)
        {
            FileStream _archivo = new FileStream(_ruta, FileMode.Open);
            StreamReader reader = new StreamReader(_archivo);
            List<string> lista = new List<string>();
            while (!reader.EndOfStream)
            {
                string linea = reader.ReadLine();
                lista.Add(linea);
            }
            reader.Close();
            _archivo.Close();
            return lista;
        }

        public void menuVehiculos() {

            Console.CursorVisible = false;
            string[] options = { "Agregar vehículo", "Mostrar lista de vehiculos", "eliminar vehiculo", "Salir" };
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
                            crearVehiculo();
                        }
                        else if (selectedOption == 1)
                        {
                            mostrarVehiculos("listaVehiculos.txt");
                            Console.ReadKey();
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
