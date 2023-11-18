using FinalLaboratorioII.entidades;
using FinalLaboratorioII.utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalLaboratorioII.servicios
{
    internal class ServicioVenta
    {

        public ServicioVenta()
        {

        }
        public void menuVentas()
        {
            Menu menu1 = new Menu();
            List<string> listaVentas= cargarArchivoEnLista("listaVentas.txt");
            List<string> listaLocalidades = cargarArchivoEnLista("listaLocalidades.txt");

            Console.CursorVisible = false;
            string[] opciones = { "AGREGAR VENTA", "MOSTRAR VENTAS" };
            int opcionElegida = 0;

            while (true)
            {
                List<Venta> ventas= convertirListaAVenta(listaVentas);
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
                            Console.Clear();
                            Venta v1= crearVenta(ventas);
                            ventas.Add(v1);
                            List<Venta> ventasString = convertirListaAVenta(listaVentas);
                            cargarListaEnArchivo(ventasString);
                            menu1.menu();
                            return;
                        }
                        else if (opcionElegida == 1)
                        {
                            mostrarVentas(ventas);

                        }
                        else if (opcionElegida == opciones.Length - 1)
                        {
                            Console.Clear();
                            return;
                        }
                        break;
                    case ConsoleKey.Escape:
                        Menu menu = new Menu();
                        menu.menu();
                        break;

                }
            }


        }
        //---------------------------------------------------------------------------------
        public Venta crearVenta(List<Venta> _ventas)
        {
            bool valido;
            List<string> listaClientes = cargarArchivoEnLista("listaClientes.txt");
            List<string> listaVehiculos = cargarArchivoEnLista("listaVehiculos.txt");
            List<string> listaVentas = cargarArchivoEnLista("listaVentas.txt");
            Venta venta = new Venta();

            if (_ventas.Count == 0)
            {
                venta.Id_venta = 1;

            }
            else
            {
                venta.Id_venta = _ventas[_ventas.Count - 1].Id_venta + 1;
            }

            Console.WriteLine("Ingrese Cliente: ");
            venta.Id_Cliente = mostrarMenuInteractivo(listaClientes);

            Console.WriteLine("Ingrese Vehiculo: ");
            venta.Id_Vehiculo = mostrarMenuInteractivo(listaClientes);

            Console.WriteLine("Ingrese fecha de compra :  dd/mm/yyyy");
            venta.Fecha_compra = Console.ReadLine();
            Console.WriteLine("Ingrese fecha de entrega :  dd/mm/yyyy");
            venta.Fecha_entrega = Console.ReadLine();

            do
            {
                Console.WriteLine("Ingrese Subtotal: ");
                string subtotal = Console.ReadLine();
                valido = validarPrecio(subtotal);
                if (valido)
                {
                    venta.Subtotal = Double.Parse(subtotal);

                }
            } while (!valido);

            venta.Iva = 21;

            Console.Clear();

            do
            {
                Console.WriteLine("Ingrese Descuento: ");
                string desc = Console.ReadLine();
                valido = validarPrecio(desc);
                if (valido)
                {
                    venta.Descuento = Double.Parse(desc);

                }
            } while (!valido);

            venta.Total = (venta.Subtotal + (venta.Subtotal * venta.Iva)) - (venta.Subtotal * venta.Descuento);
            return venta;
        }

        //---------------------------------------------------------------------------------
        public int mostrarMenuInteractivo(List<string> _lista)
        {
            Console.Clear();
            List<string> lista = _lista;
            Console.CursorVisible = false;
            int opcionElegida = 0;
            var res = 0;

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
                        res = opcionElegida;
                        return res;
                }
            }


        }
        static bool validarPrecio(string _dato)
        {
            double precio;
            try
            {
                precio = Double.Parse(_dato);
            }
            catch (Exception)
            {
                Console.WriteLine("Ingrese números validos.");
                return false;
            }

            return true;
        }

        //--------------------------------------------------------------------------------
        public List<string> cargarArchivoEnLista(string _ruta)
        {
            FileStream _archivo = new FileStream(_ruta, FileMode.Open);
            List<string> lista = new List<string>();
            using (StreamReader reader = new StreamReader(_archivo))
            {
                while (!reader.EndOfStream)
                {
                    string linea = reader.ReadLine();
                    lista.Add(linea);
                }
            }
            return lista;
        }
        public void cargarListaEnArchivo(List<string> _lista)
        {
            FileStream archivo = new FileStream("listaVentas.txt", FileMode.Create);

            using (StreamWriter writer = new StreamWriter(archivo))
            {
                foreach (string item in _lista)
                {
                    writer.WriteLine(item);
                }
            }
        }


        
    }
}
