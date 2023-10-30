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

            Console.Clear();
            List<string> lista = cargarArchivoEnLista(_ruta);
            int cont = 0;
            Console.CursorVisible = false;            
            int opcionElegida = 0;

            while (true)
            {
                Console.Clear();
                if (lista.Count == 0 || lista.Count == 1)
                {
                    Console.WriteLine("No hay vehiculos cargados");
                    break;
                }
                else
                {
                    for (int i = 0; i < lista.Count; i++)
                    {
                        if (i != lista.Count - 1)
                        {
                            if (i == opcionElegida)
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                            }
                            Console.WriteLine(lista[i]);
                            Console.ResetColor();
                        }

                    }

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
                        bool subMenuActivo = true;
                        int opcionSubMenu = 0;
                        string[] opciones = { "Modificar datos", "Eliminar vehiculo"};
                        while (subMenuActivo)
                        {
                            Console.Clear();
                            Console.WriteLine("Has seleccionado el vehículo: " + lista[opcionElegida]);
                            Console.WriteLine("Selecciona una opción:");
                            for (int i = 0; i < opciones.Length; i++)
                            {
                                if (i == opcionSubMenu)
                                {
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.BackgroundColor = ConsoleColor.White;
                                }
                                Console.WriteLine(opciones[i]);
                                Console.ResetColor();
                            }
                            //Console.WriteLine(opcionSubMenu == 0 ? "> Opción 1" : "  Opción 1");
                            //Console.WriteLine(opcionSubMenu == 1 ? "> Opción 2" : "  Opción 2");
                            //Console.WriteLine("Presiona Enter para confirmar, Esc para volver al menú anterior.");

                            var subMenuKey = Console.ReadKey().Key;

                            switch (subMenuKey)
                            {
                                case ConsoleKey.UpArrow:
                                    opcionSubMenu = Math.Max(0, opcionSubMenu - 1);
                                    break;
                                case ConsoleKey.DownArrow:
                                    opcionSubMenu = Math.Min(1, opcionSubMenu + 1);
                                    break;
                                case ConsoleKey.Enter:
                                    Console.Clear();
                                    switch (opcionSubMenu)
                                    {
                                        case 0:
                                            Console.WriteLine("Has seleccionado la Opción 1 del submenú. Realiza la acción correspondiente.");
                                            Console.ReadKey();
                                            break;
                                        case 1:
                                            eliminarVehiculo(opcionElegida);
                                            break;
                                    }
                                    subMenuActivo = false;
                                    break;
                                case ConsoleKey.Escape:
                                    subMenuActivo = false;
                                    break;
                            }
                        }
                        break;
                }
            }

            //Console.Clear();
            //if (lista.Count == 0 || lista.Count == 1)
            //{
            //    Console.WriteLine("No hay vehiculos cargados");
            //}
            //else
            //{
            //    foreach (var item in lista)
            //    {

            //        if (cont != lista.Count - 1)
            //        {
            //            Console.WriteLine(item);
            //        }
            //        cont++;
            //    }
            //}

        }
        public void actualizarVehiculo()
        {
            List<string> lista = cargarArchivoEnLista("listaVehiculos.txt");

           

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
            string[] opciones = { "Agregar vehículo", "Mostrar lista de vehiculos", "Eliminar vehiculo", "Salir" };
            int opcionElegida = 0;

            while (true)
            {
                Console.Clear();
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
                            List<string> listaVehiculos = cargarVehiculoEnLista();
                            cargarListaEnArchivo(listaVehiculos);
                        }
                        else if (opcionElegida == 1)
                        {
                            mostrarVehiculos("listaVehiculos.txt");
                            Console.ReadKey();
                        }
                        else if (opcionElegida == 2)
                        {
                            eliminarVehiculo();
                            Console.ReadKey();
                        }
                        else if (opcionElegida == opciones.Length - 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Saliendo del programa.");
                            return;
                        }
                        // Realiza alguna acción según la opción seleccionada.
                        Console.Clear();
                        Console.WriteLine($"Seleccionaste: {opciones[opcionElegida]}");
                        Console.ReadKey();
                        break;
                }
            }

        }
        public void eliminarVehiculo()
        {
            Console.Clear();
            List<string> lista = cargarArchivoEnLista("listaVehiculos.txt");

            Console.CursorVisible = false;
            int selectedOption = 0;
            if (lista.Count>1)
            {
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
                            if (res == "si")
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
            else
            {
                Console.WriteLine("No hay items cargados");            }
           
        }
        public void eliminarVehiculo(int opcion)
        {
            List<string> lista = cargarArchivoEnLista("listaVehiculos.txt");
            string[] opciones = { "Si", "No" };
            Console.CursorVisible = false;
            bool subMenuActivo = true;
            int opcionElegida = 0;

            Console.Clear();

            if (lista.Count>1)
            {
                Console.WriteLine("¿Eliminar item seleccionado?");
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
                var subMenuKey = Console.ReadKey().Key;

                switch (subMenuKey)
                {
                    case ConsoleKey.UpArrow:
                        opcionElegida = Math.Max(0, opcionElegida - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        opcionElegida = Math.Min(1, opcionElegida + 1);
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (opcionElegida)
                        {
                            case 0:
                                lista.RemoveAt(opcion);
                                Console.WriteLine("vehiculo eliminado");

                                break;
                            case 1:
                                Console.WriteLine("Has seleccionado la Opción 1 del submenú. Realiza la acción correspondiente.");
                                Console.ReadKey();
                                break;
                        }
                        subMenuActivo = false;
                        break;
                    case ConsoleKey.Escape:
                        subMenuActivo = false;
                        break;
                }
            }
            else
            {
                Console.WriteLine("No hay items cargados");
            }
            

            FileStream archivoNuevo = new FileStream("listaVehiculos.txt", FileMode.Create);
            archivoNuevo.Close();
            cargarListaEnArchivo(lista);
            Console.ReadKey();
        }

    }
}
