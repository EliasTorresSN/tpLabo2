using FinalLaboratorioII.entidades;
using System.IO;
namespace FinalLaboratorioII.servicios
{
    internal class ServicioCliente
    {
        public ServicioCliente()
        {
        }

        public Cliente crearCliente()
        {
            bool valDni = false, valSex = false;
            string doc,sexo;
            Cliente cliente = new Cliente();
            Console.WriteLine("Ingrese cliente: ");
            cliente.NombreCliente = Console.ReadLine();

            Console.WriteLine("Ingrese C.U.I.T.: ");

            string codCompleto = "";
            int[] coef = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            int suma = 0;
            do
            {
                Console.WriteLine("Ingrese los ocho digitos del dni");
                doc  = Console.ReadLine();
                if (doc.Length != 8)
                {
                    Console.WriteLine("Ingrese dni válido");
                    
                }
                else { valDni = true; }

            } while (!valDni);

            do
            {
                Console.WriteLine("Ingrese sexo (m o f)");
               sexo= Console.ReadLine();
                if (sexo!="m"&&sexo!="f")
                {
                    Console.WriteLine("Ingrese 'm' o 'f'");
                    Console.ReadKey();
                    Console.Clear();
                }
                else {valSex = true; }
               
            } while (!valSex);

            if (sexo.Equals("m"))
            {
                codCompleto = "20" + doc;
            }
            else if (sexo.Equals("f"))
            {
                codCompleto = "27" + doc;
            }
            for (int i = 0; i < coef.Length; i++)
            {
                suma += int.Parse(codCompleto[i].ToString()) * coef[i];
            }

            decimal cod = suma / 11;
            int resto = suma - (Convert.ToInt32(Math.Round(cod) * 11));
            int z = 11 - resto;
            string cuil_cuit = codCompleto + z;
            cliente.Cuit = cuil_cuit;


            Console.WriteLine("Ingrese domicilio del cliente: ");
            cliente.Domicilio = Console.ReadLine();

            Console.WriteLine("Ingrese localidad del cliente: ");
            //menu interactivo
            cliente.Id_localidad = 1;

            Console.WriteLine("Ingrese telefono:");
            cliente.Telefono = Console.ReadLine();

            Console.WriteLine("Ingrese correo electrónico:");
            cliente.Correo = Console.ReadLine();

            return new Cliente();
        }

        public void eliminarCliente(Cliente _cliente, List<Cliente>listaClientes)
        {
            listaClientes.Remove(_cliente);
        }

        public void actualizarCLiente(Cliente c)
        {
            string[] lista = { "Nombre", "Cuit", "Domicilio", "Localidad", "Teléfono", "Correo","Salir" };
            Console.WriteLine("Elija que modificar");
            int atributo = mostrarMenuInteractivo(lista);
            switch(atributo)
            {
                case 0:
                    Console.WriteLine($"Nombre actual: {c.NombreCliente}");
                    Console.Write("Ingrese nuevo nombre ->");
                    c.NombreCliente = Console.ReadLine();
                
                break;
                case 1:
                    Console.WriteLine($"C.U.I.T. actual: {c.Cuit}");
                    Console.Write("Ingrese nuevo C.U.I.T. ->");
                    c.Cuit = Console.ReadLine(); ;
                break;
                case 2:
                    Console.WriteLine($"Domicilio actual: {c.Domicilio}");
                    Console.Write("Ingrese nuevo domicilio ->");
                    c.Domicilio = Console.ReadLine(); ;
                break;
                case 3:
                    Console.WriteLine($"Localidad actual: {c.Id_localidad}");
                    Console.Write("Ingrese nueva localidad ->");
                    c.Id_localidad = int.Parse(Console.ReadLine()); 
                break;
                case 4:
                    Console.WriteLine($"Teléfono actual: {c.Telefono}");
                    Console.Write("Ingrese nuevo teléfono ->");
                    c.Telefono = Console.ReadLine(); ;
                break;
                case 5:
                    Console.WriteLine($"Correo actual: {c.Correo}");
                    Console.Write("Ingrese nuevo correo ->");
                    c.Correo = Console.ReadLine(); ;
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
        }


        public void mostrarClientes(List<Cliente>_listaClientes)
        {
            foreach (var item in _listaClientes)
            {
                Console.WriteLine(item.ToString());
            }
        }



        public int mostrarMenuInteractivo(string[] _lista)
        {
            Console.Clear();
            string[] lista = _lista;
            Console.CursorVisible = false;
            int opcionElegida = 0;
            var res = 0;

            while (true)
            {
                Console.Clear();

                for (int i = 0; i < lista.Length; i++)
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
                        opcionElegida = Math.Min(lista.Length - 1, opcionElegida + 1);
                        break;
                    case ConsoleKey.Enter:
                        res = opcionElegida;
                        return res;
                }
            }

            
        }

    }
}
