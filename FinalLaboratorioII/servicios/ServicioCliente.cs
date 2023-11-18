using FinalLaboratorioII.entidades;
using FinalLaboratorioII.utilidades;
using System.IO;
using System.Net.Http.Headers;

namespace FinalLaboratorioII.servicios
{
    internal class ServicioCliente
    {
        public ServicioCliente()
        {
        }
        public void menuClientes()
        {
            Menu menu1 = new Menu();
            List<string> listaClientes = cargarArchivoEnLista("listaClientes.txt");
            List<string> listaLocalidades = cargarArchivoEnLista("listaLocalidades.txt");

            Console.CursorVisible = false;
            string[] opciones = { "AGREGAR CLIENTE", "MOSTRAR CLIENTES" };
            int opcionElegida = 0;

            while (true)
            {
                List<Cliente> clientes = convertirListaACliente(listaClientes);
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
                            Cliente cliente1 = crearCliente(clientes);
                            clientes.Add(cliente1);
                            List<string> clientesString= listaClienteAString(clientes);
                            cargarListaEnArchivo(clientesString);
                            menu1.menu();
                            return;
                        }
                        else if (opcionElegida == 1)
                        {
                            mostrarClientes(clientes);

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
        public Cliente crearCliente(List<Cliente> _clientes)
        {
            bool valido;
            List<string>listaLocalidades = cargarArchivoEnLista("listaLocalidades.txt");
            Cliente cliente = new Cliente();

            if (_clientes.Count == 0)
            {
                cliente.Id_cliente= 1;

            }
            else
            {
                cliente.Id_cliente = _clientes[_clientes.Count - 1].Id_localidad + 1;
            }



            Console.WriteLine("Ingrese Nombre Cliente: ");
            cliente.NombreCliente = Console.ReadLine();
            do
            {
                Console.WriteLine("Ingrese C.U.I.T.: ");
                string cuit = Console.ReadLine();
                valido = validarNumeros(cuit);
                if (valido)
                {
                    cliente.Cuit = cuit;

                }
            } while (!valido);

            Console.Clear();

            Console.WriteLine("Ingrese domicilio del cliente: ");
            cliente.Domicilio = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Ingrese localidad del cliente: ");
            int loc = mostrarMenuInteractivo(listaLocalidades);
            cliente.Id_localidad = loc;
            Console.Clear();


            do
            {
                Console.WriteLine("Ingrese telefono:");
               
                string tel = Console.ReadLine();
                valido = validarNumeros(tel);
                if (valido)
                {
                    cliente.Telefono = tel;
                }
            } while (!valido);

            Console.Clear();

            Console.WriteLine("Ingrese correo electrónico:");
            cliente.Correo = Console.ReadLine();


            return cliente;


        }
        public void mostrarClientes(List<Cliente> _lista)
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
                        menuClientes();
                        break;


                }
            }
            Console.ReadKey();
        }
        public Cliente  actualizarCliente(Cliente _cliente, List<Cliente> _lista)
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

                        List<string> lista = new List<string>() { "Nombre", "Cuit", "Domicilio", "Localidad", "Teléfono", "Correo", "Salir" };
                        Console.WriteLine("Elija que modificar");
                        int atributo = mostrarMenuInteractivo(lista);
                        switch (atributo)
                        {
                            case 0:
                                Console.Write("Ingrese nuevo nombre ->");
                                _cliente.NombreCliente = Console.ReadLine();

                                break;
                            case 1:
                                do
                                {
                                    Console.WriteLine("Ingrese C.U.I.T.: ");
                                    string cuit = Console.ReadLine();
                                    valido = validarNumeros(cuit);
                                    if (valido)
                                    {
                                        _cliente.Cuit = cuit;

                                    }
                                } while (!valido);
                                break;
                            case 2:
                                Console.Write("Ingrese nuevo domicilio ->");
                                _cliente.Domicilio = Console.ReadLine(); ;
                                break;
                            case 3:
                                Console.Write("Ingrese nueva localidad ->");
                                _cliente.Id_localidad = int.Parse(Console.ReadLine());
                                break;
                            case 4:
                                do
                                {
                                    Console.WriteLine("Ingrese telefono:");
                                    string tel = Console.ReadLine();
                                    valido = validarNumeros(tel);
                                    if (valido)
                                    {
                                        _cliente.Telefono = tel;
                                    }
                                } while (!valido);
                                break;
                            case 5:
                                Console.Write("Ingrese nuevo correo ->");
                                _cliente.Correo = Console.ReadLine(); ;
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
                        return _cliente;
                }
            }
        }
        public List<Cliente> eliminarCliente(Cliente _cliente, List<Cliente> _clientes)
        {
            _clientes.Remove(_cliente);
            Console.WriteLine("ÍTEM ELIMINADO");
            Console.ReadKey();
            return _clientes;
        }
        //---------------------------------------------------------------------------------
        public List<Cliente> convertirListaACliente(List<string> lista)
        {
            List<Cliente> clientes= new List<Cliente>();
            string[] clienteString;
            for (int i = 0; i < lista.Count; i++)
            {
                clienteString = lista[i].Split(';');
                clientes.Add(elementoStringACliente(clienteString));
            }
            return clientes;
        }
        public Cliente elementoStringACliente(string[] _cliente)
        {
            Cliente c = new Cliente();
            string[] atributos = new string[8];
            int cont = 0;
            for (int i = 0; i < _cliente.Length; i++)
            {
                if (i % 2 == 1)
                {
                    atributos[cont] = _cliente[i];
                    cont++;
                }
                if (cont > 7)
                {
                    cont = 0;
                }
            }

            c.Id_cliente = int.Parse(atributos[0]);
            c.NombreCliente = atributos[1];
            c.Cuit = atributos[2];
            c.Domicilio = atributos[3];
            c.Id_localidad = int.Parse(atributos[4]);
            c.Telefono = atributos[5];
            c.Correo = atributos[6];

            return c;
        }
        public List<string> listaClienteAString(List<Cliente> _lista)
        {
            List<string> lista = new List<string>();
            foreach (var item in _lista)
            {
                lista.Add($"ID_CLIENTE:;{item.Id_cliente};NOMBRE:;{item.NombreCliente};C.U.I.T:;{item.Cuit}" +
                $";DOMICILIO:;{item.Domicilio};ID_LOCALIDAD:;{item.Id_localidad};TELÉFONO:;{item.Telefono};CORREO:;{item.Correo};");
            }
            return lista;
        }
        static bool validarNumeros(string _dato)
        {
            for (int i = 0; i < _dato.Length; i++)
            {
                if ((int)_dato[i] < 48 || (int)_dato[i] > 57)
                {
                    Console.WriteLine("Ingrese numeros validos ->");

                    return false;
                }
            }
            return true;
        }
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
        public void subMenu(List<Cliente> _lista, int _opcionElegida)
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
                        Cliente c = _lista[_opcionElegida];
                        Console.Clear();
                        switch (opcionSubMenu)
                        {
                            case 0:

                                Cliente aux = actualizarCliente(c, _lista);
                                _lista[_opcionElegida] = aux;
                                cargarListaEnArchivo(listaClienteAString(_lista));
                                menu.menu();
                                break;
                            case 1:
                                _lista = eliminarCliente(c, _lista);
                                cargarListaEnArchivo(listaClienteAString(_lista));
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
            FileStream archivo = new FileStream("listaClientes.txt", FileMode.Create);

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
