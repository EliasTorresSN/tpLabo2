using FinalLaboratorioII.entidades;
using FinalLaboratorioII.utilidades;
using System;
using System.Collections;
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
                            List<string> ventasString = listaVentaAString(ventas);
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
            Console.Clear();


            Console.WriteLine("Ingrese Vehiculo: ");
            venta.Id_Vehiculo = mostrarMenuInteractivo(listaVehiculos);
            Console.Clear();

            Console.WriteLine("Ingrese fecha de compra :  dd/mm/yyyy");
            venta.Fecha_compra = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Ingrese fecha de entrega :  dd/mm/yyyy");
            venta.Fecha_entrega = Console.ReadLine();
            Console.Clear();


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
        public void mostrarVentas(List<Venta> _lista)
        {
            Menu menu = new Menu();
            bool activo = true;
            Console.CursorVisible = false;
            int opcionElegida = 0;

            while (activo)
            {
                Console.Clear();
                if (_lista.Count == 0)
                {
                    Console.WriteLine("No hay ítems cargados");
                    break;
                }
                else
                {
                    for (int i = 0; i < _lista.Count; i++)
                    {
                        if (i == opcionElegida)
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;
                        }
                        Console.WriteLine(_lista[i].ToString());
                        Console.ResetColor();
                    }
                }


                var key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        opcionElegida = Math.Max(0, opcionElegida - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        opcionElegida = Math.Min(_lista.Count - 1, opcionElegida + 1);
                        break;
                    case ConsoleKey.Enter:
                        subMenu(_lista, opcionElegida);
                        break;
                    case ConsoleKey.Escape:
                        menuVentas();
                        break;


                }
            }
            Console.ReadKey();
        }
        public List<Venta> eliminarVenta(Venta _venta, List<Venta> _ventas)
        {
            _ventas.Remove(_venta);
            Console.WriteLine("ÍTEM ELIMINADO");
            Console.ReadKey();
            return _ventas;
        }
        public Venta actualizarVenta(Venta _venta, List<Venta> _lista)
        {
            string[] atributos = { "Nombre", "Cuit", "Domicilio", "Localidad", "Teléfono", "Correo", "Salir" };
            int c = 0;
            bool valido = false;

            Console.CursorVisible = false;
            int opcionElegida = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("ATRIBUTO A MODIFICAR");
                for (int i = 0; i < atributos.Length; i++)
                {
                    if (i == opcionElegida)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine(atributos[i]);
                    Console.ResetColor();
                }

                var key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        opcionElegida = Math.Max(0, opcionElegida - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        opcionElegida = Math.Min(atributos.Length - 1, opcionElegida + 1);
                        break;
                    case ConsoleKey.Enter:

                        List<string> lista = new List<string>() { "Fecha compra", "Fecha entrega", "Subtotal", "IVA", "Descuento", "Total", "Salir" };
                        Console.WriteLine("Elija que modificar");
                        int atributo = mostrarMenuInteractivo(lista);
                        switch (atributo)
                        {
                            case 0:
                                Console.WriteLine("Ingrese fecha de compra :  dd/mm/yyyy");
                                _venta.Fecha_compra = Console.ReadLine();
                                break;
                            case 1:
                                Console.WriteLine("Ingrese fecha de entrega :  dd/mm/yyyy");
                                _venta.Fecha_entrega = Console.ReadLine();
                                break;
                            case 2:
                                do
                                {
                                    Console.WriteLine("Ingrese Subtotal: ");
                                    string subtotal = Console.ReadLine();
                                    valido = validarPrecio(subtotal);
                                    if (valido)
                                    {
                                        _venta.Subtotal = Double.Parse(subtotal);

                                    }
                                } while (!valido);
                                break;
                            case 3:
                                do
                                {
                                    Console.WriteLine("Ingrese IVA: ");
                                    string iva = Console.ReadLine();
                                    valido = validarPrecio(iva);
                                    if (valido)
                                    {
                                        _venta.Iva= Double.Parse(iva);

                                    }
                                } while (!valido);
                                break;
                            case 4:
                                do
                                {
                                    Console.WriteLine("Ingrese Descuento: ");
                                    string desc = Console.ReadLine();
                                    valido = validarPrecio(desc);
                                    if (valido)
                                    {
                                        _venta.Descuento = Double.Parse(desc);

                                    }
                                } while (!valido);
                                break;
                            case 5:
                                do
                                {
                                    Console.WriteLine("Ingrese Total: ");
                                    string total = Console.ReadLine();
                                    valido = validarPrecio(total);
                                    if (valido)
                                    {
                                        _venta.Total= Double.Parse(total);

                                    }
                                } while (!valido);
                                break;
                            case 6:
                                Console.WriteLine("Saliendo sin modificar datos");
                                Console.ReadKey();
                                break;

                        }
                        if (atributo != 6)
                        {
                            Console.Clear();
                            Console.WriteLine("Datos actualizados con éxito");
                        }
                        Console.ReadKey();
                        return _venta;
                }
            }
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
               

                for (int i = 0; i < lista.Count; i++)
                {
                    Console.Clear();
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
                        res = opcionElegida+1;
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
        public void subMenu(List<Venta> _lista, int _opcionElegida)
        {
            Menu menu = new Menu();
            bool subMenuActivo = true;
            int opcionSubMenu = 0;
            string[] opciones = { "MODIFICAR ÍTEM", "ELIMINAR ÍTEM" };

            while (subMenuActivo)
            {
                Console.Clear();
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
                        Venta v1 = _lista[_opcionElegida];
                        Console.Clear();
                        switch (opcionSubMenu)
                        {
                            case 0:

                                Venta aux = actualizarVenta(v1, _lista);
                                _lista[_opcionElegida] = aux;
                                cargarListaEnArchivo(listaVentaAString(_lista));
                                menu.menu();
                                break;
                            case 1:
                                _lista = eliminarVenta(v1, _lista);
                                cargarListaEnArchivo(listaVentaAString(_lista));
                                menu.menu();
                                break;
                        }
                        subMenuActivo = false;
                        break;
                    case ConsoleKey.Escape:
                        subMenuActivo = false;
                        break;
                }
            }
        }
        public List<Venta> convertirListaAVenta(List<string> lista)
        {
            List<Venta> ventas = new List<Venta>();
            string[] ventasString;
            for (int i = 0; i < lista.Count; i++)
            {
                ventasString = lista[i].Split(';');
                ventas.Add(elementoStringAVenta(ventasString));
            }
            return ventas;
        }
        public Venta elementoStringAVenta(string[] _venta)
        {
            Venta v1 = new Venta();
            string[] atributos = new string[9];
            int cont = 0;
            for (int i = 0; i < _venta.Length; i++)
            {
                if (i % 2 == 1)
                {
                    atributos[cont] = _venta[i];
                    cont++;
                }
                if (cont > 8)
                {
                    cont = 0;
                }
            }

            v1.Id_venta = int.Parse(atributos[0]);
            v1.Id_Cliente = int.Parse(atributos[1]);
            v1.Id_Vehiculo = int.Parse(atributos[2]);
            v1.Fecha_compra= atributos[3];
            v1.Fecha_entrega= atributos[4];
            v1.Subtotal = double.Parse(atributos[5]);
            v1.Iva = double.Parse(atributos[6]);
            v1.Descuento = double.Parse(atributos[7]);
            v1.Total= double.Parse(atributos[8]);

            return v1;
        }

        public List<string> listaVentaAString(List<Venta> _lista)
        {
            List<string> lista = new List<string>();
            foreach (var item in _lista)
            {
                lista.Add($"ID VENTA:;{item.Id_venta};ID CLIENTE:;{item.Id_Cliente};ID_VEHICULO:;{item.Id_Vehiculo};FECHACOMPRA:;{item.Fecha_compra};FECHAENTREGA:;{item.Fecha_entrega};SUBTOTAL:;{item.Subtotal};IVA:;{item.Iva}; DESCUENTO:;{item.Descuento};TOTAL:;{item.Total}");
            }
            return lista;
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
