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
            List<string> lista = cargarArchivoEnLista("listaVehiculos.txt");
            Vehiculo vehiculo1 = new Vehiculo();
            Console.WriteLine("Nuevo vehículo");
            int numAux = 0;

            if (lista.Count==0)
            {
                vehiculo1.Id_vehiculo = 1;
            }
            else
            {
                string[] n = lista[lista.Count - 1].Split(";");
                string n2 = n[1];
                Console.WriteLine("n2 "+n2);
                numAux = int.Parse(n2) + 1;
                vehiculo1.Id_vehiculo = numAux;
            }

            //Console.WriteLine("id_marca");
            vehiculo1.Id_marca = 1;

            Console.WriteLine("Modelo:");
            vehiculo1.Modelo = Console.ReadLine();

            Console.WriteLine("Año");
            vehiculo1.Anio = Console.ReadLine();

            Console.WriteLine("Ingrese patente");
            vehiculo1.Patente = Console.ReadLine();

            Console.WriteLine("Cantidad de kilometros");
            vehiculo1.Kilometros = Console.ReadLine();
                      
            
            //Console.WriteLine("id_segmento");
            vehiculo1.Id_segmento = 1;

            //Console.WriteLine("id_combustible");
            vehiculo1.Id_combustible = 1;

            Console.WriteLine("Observaciones:");
            vehiculo1.Observaciones = Console.ReadLine();

            Console.WriteLine("Precio:");
            vehiculo1.Precio_vta = float.Parse(Console.ReadLine());

            return vehiculo1;
        }
        public List<string> cargarVehiculoEnLista()
        {
            List<string> lista = cargarArchivoEnLista("listaVehiculos.txt");
            Vehiculo v = crearVehiculo();
            string cantTotal = "";
            int numAux = 0;
            if (lista.Count== 0) {
                lista.Add(v.ToString());
                cantTotal = "Cant:;" + lista.Count + ";";
                lista.Add(cantTotal);
            }
            else
            {
                string[] n = lista[lista.Count - 1].Split(";");
                string n2 = n[1];
                numAux = int.Parse(n2) + 1;
                lista[lista.Count - 1] = v.ToString();
                lista.Add("Cant:;" + numAux+";");
            }
            return lista;
        }
        public void  cargarListaEnArchivo(List<string>lista)
        {
            FileStream _archivo = new FileStream("listaVehiculos.txt", FileMode.Open);

            using (StreamWriter writer = new StreamWriter(_archivo))
            {
                foreach (string item in lista)
                {
                    writer.WriteLine(item);
                }
            }
            _archivo.Close();
        }
        public void mostrarVehiculos(string _ruta)
        {
            List<string>lista = cargarArchivoEnLista(_ruta);
            int cont = 0;
            Console.Clear();
            if (lista.Count==0||lista.Count==1)
            {
                Console.WriteLine("No hay vehiculos cargados");
            }
            else
            {
                foreach (var item in lista)
                {
                    
                    if (cont != lista.Count -1)
                    {
                        Console.WriteLine(item);
                    }
                    cont++;
                }
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
        public void eliminarVehiculo()
        {
            List<string> lista = cargarArchivoEnLista("listaVehiculos.txt");

            Console.CursorVisible = false;
            int selectedOption = 0;

            while (true)
            {
                Console.Clear();
                for (int i = 0; i < lista.Count; i++)
                {
                    if (i == selectedOption)
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
                        selectedOption = Math.Max(0, selectedOption - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        selectedOption = Math.Min(lista.Count - 1, selectedOption + 1);
                        break;
                    case ConsoleKey.Enter:
                       
                        // Realiza alguna acción según la opción seleccionada.
                        Console.Clear();
                        Console.WriteLine($"Seleccionaste: {lista[selectedOption]}");
                        Console.WriteLine("Eliminar?");
                        string res = Console.ReadLine();
                        if (res=="si")
                        {
                            lista.RemoveAt(selectedOption);
                            Console.WriteLine("vehiculo eliminado");
                           
                        }
                        FileStream archivoNuevo = new FileStream("listaVehiculos.txt", FileMode.Create);
                        archivoNuevo.Close();
                        cargarListaEnArchivo(lista);
                        Console.ReadKey();
                        break;
                }
            }

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
                            List<string> listaVehiculos = cargarVehiculoEnLista();
                            cargarListaEnArchivo(listaVehiculos);
                        }
                        else if (selectedOption == 1)
                        {
                            mostrarVehiculos("listaVehiculos.txt");
                            Console.ReadKey();
                        }
                        else if (selectedOption == 2)
                        {
                           eliminarVehiculo();
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
