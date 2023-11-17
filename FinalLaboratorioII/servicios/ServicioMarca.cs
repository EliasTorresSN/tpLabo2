using FinalLaboratorioII.entidades;
using FinalLaboratorioII.utilidades;
using System;
using System.Collections.Generic;

namespace FinalLaboratorioII.servicios
{
    internal class ServicioMarca
    {


        public ServicioMarca(){}
        public void menuMarcas()
        {
            List<string> listaMarcas = cargarArchivoEnLista("listaMarcas.txt");

            Console.CursorVisible = false;
            string[] opciones = { "AGREGAR MARCA", "MOSTRAR MARCAS" };
            int opcionElegida = 0;

            while (true)
            {
                List<Marca> marcas= convertirListaAMarca(listaMarcas);
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

                            Marca marca1 = crearMarca(marcas);
                            marcas.Add(marca1);
                            List<string> marcasString = listaMarcaAString(marcas);
                            cargarListaEnArchivo(marcasString);
                        }
                        else if (opcionElegida == 1)
                        {
                            mostrarMarcas(marcas);

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
        public Marca crearMarca(List<Marca> _marcas)
        {
            
           Marca marca = new Marca();
            if (_marcas.Count == 0)
            {
                marca.Id_marca = 1;

            }
            else
            {
                marca.Id_marca = _marcas[_marcas.Count - 1].Id_marca + 1;
            }
            Console.WriteLine("Ingrese Marca");
            string m = Console.ReadLine();
            marca.NombreMarca = m;
            
            Console.Clear();
            Console.WriteLine("Marca agregada con éxito");
            Console.ReadKey();
            return marca;
        }
        public void mostrarMarcas(List<Marca> _lista)
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
                        menuMarcas();
                        break;


                }
            }
            Console.ReadKey();
        }
        public Marca actualizarMarca(Marca _marca, List<Marca> _lista)
        {
            string[] atributos = { "MARCA", "SALIR" };
            int c = 0;
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

                        if (opcionElegida == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("INGRESE MARCA");
                            string m = Console.ReadLine();
                            _marca.NombreMarca = m;
                            c = 1;
                        }
                        else
                        {
                            Console.Clear();
                            if (c != 0) { Console.WriteLine("DATOS MODIFICADOS CON ÉXITO"); }
                            else { Console.WriteLine("NO SE MODIFICÓ NINGÚN DATO"); }
                        }
                        Console.ReadKey();
                        return _marca;
                }
            }
        }
        public List<Marca> eliminarMarca(Marca _marca, List<Marca> _marcas)
        {
            _marcas.Remove(_marca);
            Console.WriteLine("ÍTEM ELIMINADO");
            Console.ReadKey();
            return _marcas;
        }
        //--------------------------------------------------------------------------------
        public void subMenu(List<Marca>_lista,int _opcionElegida)
        {
            bool subMenuActivo = true;
            int opcionSubMenu = 0;
            string[] opciones = { "MODIFICAR ÍTEM", "ELIMINAR ÍTEM" };

            while (subMenuActivo)
            {
                Console.Clear();
                Console.WriteLine("MARCA: " + _lista[_opcionElegida]);
                Console.WriteLine("SELECCIONE:");
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
                        Marca m = _lista[_opcionElegida];
                        Console.Clear();
                        switch (opcionSubMenu)
                        {
                            case 0:
                               
                                Marca aux = actualizarMarca(m,_lista);
                                _lista[_opcionElegida] = aux;
                                cargarListaEnArchivo(listaMarcaAString(_lista));
                                break;
                            case 1:
                                _lista = eliminarMarca(m, _lista);
                                cargarListaEnArchivo(listaMarcaAString(_lista));
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

        //---------------------------------------------------------------------------------
        List<Marca> convertirListaAMarca(List<string> lista)
        {
            List<Marca> marcas= new List<Marca>();
            string[] marcaString;
            for (int i = 0; i < lista.Count; i++)
            {
                marcaString = lista[i].Split(';');
                marcaString = lista[i].Split(';');
                marcas.Add(elementoStringAMarca(marcaString));
            }
            return marcas;
        }
        public Marca elementoStringAMarca(string[] _marca)
        {
            Marca m = new Marca();
            string[] atributos = new string[2];
            int cont = 0;
            for (int i = 0; i < _marca.Length; i++)
            {
                if (i % 2 == 1)
                {
                    atributos[cont] = _marca[i];
                    cont++;
                }
                if (cont > 2)
                {
                    cont = 0;
                }
            }

            m.Id_marca = int.Parse(atributos[0]);
            m.NombreMarca= atributos[1];

            return m;
        }
        public List<string> listaMarcaAString(List<Marca> _lista)
        {
            List<string> lista = new List<string>();
            foreach (var item in _lista)
            {
                lista.Add($"ID_MARCA:;{item.Id_marca};MARCA:;{item.NombreMarca}");
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
            FileStream archivo = new FileStream("listaMarcas.txt", FileMode.Create);

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
