using FinalLaboratorioII.entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalLaboratorioII.servicios
{
    internal class ServicioLocalidad
    {

        public ServicioLocalidad() { }

        public Localidad crearLocalidad(List<Localidad>_localidades)
        {
            ServicioProvincia sp = new ServicioProvincia();
            List<Provincia> lista = sp.crearListaProvincias();
            Localidad localidad1 = new Localidad();

            Console.WriteLine("Elija provincia");
            int id_provincia = mostrarMenuInteractivo(lista);
            Console.Clear();
            localidad1.Id_provincia = id_provincia;
            if (_localidades.Count==0)
            {
                localidad1.Id_localidad = 1;

            }
            else
            {
                localidad1.Id_localidad = _localidades[_localidades.Count - 1].Id_localidad + 1;
            }
            Console.WriteLine("Ingrese nombre de localidad");
            string loc = Console.ReadLine();
            localidad1.NombreLocalidad = loc;
            Console.Clear();
            Console.WriteLine("Localidad agregada con éxito");
            Console.ReadKey();
            return localidad1;
        }
        public void agregarLocalidadALista(List<Localidad>_lista, Localidad _localidad)
        {
            _lista.Add(_localidad);           
        }
        public List<string> listaLocalidadAString(List<Localidad>_lista)
        {
            List<string>lista = new List<string>();
            foreach (var item in _lista)
            {
                lista.Add($"ID_LOCALIDAD:;{item.Id_localidad};ID_PROVINCIA:;{item.Id_provincia};LOCALIDAD:;{item.NombreLocalidad};");
            }
            return lista;
        }
        public void mostrarLocalidades(List<Localidad> _lista)
        {
            int cont = 0;
            Console.CursorVisible = false;
            int opcionElegida = 0;

            while (true)
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
                        subMenu(_lista,opcionElegida);
                        
                         break;


                }
            }
            Console.ReadKey();
        }
        public void actualizarLocalidad(Localidad _localidad)
        {
                        

            string[] atributos= {"ID_PROVINCIA","NOMBRE","SALIR"};

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


                        if (opcionElegida==0)
                        {
                            ServicioProvincia sp = new ServicioProvincia();
                            List<Provincia> lista = sp.crearListaProvincias();
                            _localidad.Id_provincia = mostrarMenuInteractivo(lista);
                        }
                        else if (opcionElegida==1)
                        {
                            Console.WriteLine("Ingrese nombre de localidad");
                            string loc = Console.ReadLine();
                            _localidad.NombreLocalidad = loc;
                        }
                        else
                        {
                            Console.WriteLine("NO SE MODIFICÓ NINGÚN DATO");
                            break;
                        }
                        Console.WriteLine("DATOS MODIFICADOS CON ÉXITO");
                        Console.Clear();
                        Console.ReadKey();
                    break;
                }
            }
        }
        public void eliminarLocalidad(Localidad _localidad, List<Localidad>_localidades)
        {
            _localidades.Remove(_localidad);
            Console.WriteLine("ÍTEM ELIMINADO");
        }
        public int mostrarMenuInteractivo(List<Localidad> lista)
        {            
            Console.Clear();            
            Console.CursorVisible = false;
            int opcionElegida = 0;

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
                        opcionElegida = Math.Min(lista.Count- 1, opcionElegida + 1);
                        break;
                    case ConsoleKey.Enter:
                       int res = opcionElegida;
                    return res;
                }
            }
        }
        public int mostrarMenuInteractivo(List<Provincia> lista)
        {
            Console.Clear();
            Console.WriteLine("Elija provincia");
            Console.CursorVisible = false;
            int opcionElegida = 0;

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
                    Console.WriteLine(lista[i].NombreProvincia);
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
                       int res = opcionElegida;
                        return res;
                }
            }
        }
        public void menuLocalidades()
        {
            List<string>listaLocalidades = cargarArchivoEnLista("listaLocalidades.txt");
            List<Localidad>localidades = convertirListaALocalidad(listaLocalidades);

            Console.CursorVisible = false;
            string[] opciones = { "AGREGAR LOCALIDAD", "MOSTRAR LOCALIDADES", "ELIMINAR LOCALIDAD", "SALIR" };
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
                            Localidad localidad1 = crearLocalidad(localidades);
                            localidades.Add(localidad1) /*agregarLocalidadALista(localidades, localidad1)*/;
                            Console.ReadKey();
                        }
                        else if (opcionElegida == 1)
                        {
                            mostrarLocalidades(localidades);
                        }
                        else if (opcionElegida == 2)
                        {
                            //eliminarVehiculo();
                            Console.ReadKey();
                        }
                        else if (opcionElegida == opciones.Length - 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Saliendo del programa.");
                            return;
                        }

                        Console.Clear();
                        Console.WriteLine($"Seleccionaste: {opciones[opcionElegida]}");
                        Console.ReadKey();
                        break;
                }
            }












        }
        public void subMenu(List<Localidad>_lista,int _opcionElegida)
        {
            bool subMenuActivo = true;
            int opcionSubMenu = 0;
            string[] opciones = { "MODIFICAR ÍTEM", "ELIMINAR ÍTEM" };

            while (subMenuActivo)
            {
                Console.Clear();
                Console.WriteLine("LOCALIDAD: " + _lista[_opcionElegida]);
                Console.WriteLine("SELECCIONE:");
                for (int i = 0; i < opciones.Length; i++)
                {
                    Console.Clear();
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
                        Localidad l = _lista[_opcionElegida];


                        Console.Clear();
                        switch (opcionSubMenu)
                        {
                            case 0:
                                actualizarLocalidad(l);
                                Console.ReadKey();
                                break;
                            case 1:
                                eliminarLocalidad(l, _lista);
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
        List<Localidad> convertirListaALocalidad(List<string> lista)
        {
            List<Localidad> localidades = new List<Localidad>();

            for (int i = 0; i < (lista.Count * 2); i++)
            {
                string[]LocalidadString = lista[i].Split(';');
                localidades.Add(elementoStringALocalidad(LocalidadString));
            }
            return localidades;
        }

        public Localidad elementoStringALocalidad(string[] _localidad)
        {
            Localidad l = new Localidad();
            string[] atributos = new string[3];
            int cont = 0;
            for (int i = 0; i < _localidad.Length; i++)
            {
                if (i % 2 == 1)
                {
                    atributos[cont] = _localidad[i];
                    cont++;
                }
            }

            l.Id_localidad = int.Parse(atributos[0]);
            l.Id_provincia = int.Parse(atributos[1]);
            l.NombreLocalidad = atributos[2];
           
            return l;
        }


    }
}
