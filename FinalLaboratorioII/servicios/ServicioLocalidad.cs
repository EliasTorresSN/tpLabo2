using FinalLaboratorioII.entidades;
using FinalLaboratorioII.utilidades;
using System.IO;
using System.Collections;
using System.Collections.Generic;


namespace FinalLaboratorioII.servicios
{
    internal class ServicioLocalidad
    {

        public ServicioLocalidad() { }
        public void menuLocalidades()
        {
            Menu menu1 = new Menu();
            List<string> listaLocalidades = cargarArchivoEnLista("listaLocalidades.txt");
           
            Console.CursorVisible = false;
            string[] opciones = { "AGREGAR LOCALIDAD", "MOSTRAR LOCALIDADES" };
            int opcionElegida = 0;

            while (true)
            {
                List<Localidad> localidades = convertirListaALocalidad(listaLocalidades);
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
                            localidades.Add(localidad1);
                            List<string> localidadesString = listaLocalidadAString(localidades);
                            cargarListaEnArchivo(localidadesString);
                            menu1.menu();
                            return;
                        }
                        else if (opcionElegida == 1)
                        {
                            mostrarLocalidades(localidades);
                            
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
        public Localidad crearLocalidad(List<Localidad>_localidades)
        {
            ServicioProvincia sp = new ServicioProvincia();
            List<Provincia> lista = sp.crearListaProvincias();
            Localidad localidad1 = new Localidad();

            Console.WriteLine("ELIJA PROVINCIA");
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
            return localidad1;
        }
        public void mostrarLocalidades(List<Localidad> _lista)
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
                        subMenu(_lista,opcionElegida);
                        break;
                    case ConsoleKey.Escape:
                        menuLocalidades();
                        break;


                }
            }
            Console.ReadKey();
        }
        public Localidad actualizarLocalidad(Localidad _localidad, List<Localidad>_lista)
        {
                        

            string[] atributos= {"ID_PROVINCIA","NOMBRE","SALIR"};
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

                        if (opcionElegida==0)
                        {
                            Console.Clear();
                            Console.WriteLine("INGRESE NUEVA PROVINCIA");

                            ServicioProvincia sp = new ServicioProvincia();
                            List<Provincia> lista = sp.crearListaProvincias();
                            int id = mostrarMenuInteractivo(lista);
                            _localidad.Id_provincia = id;
                            c = 1;
                        }
                        else if (opcionElegida==1)
                        {
                            Console.Clear();
                            Console.WriteLine("INGRESE NUEVO NOMBRE");
                            string loc = Console.ReadLine();
                            _localidad.NombreLocalidad = loc;
                            c = 1;
                        }
                        else
                        {
                            Console.Clear();
                            if (c!=0){Console.WriteLine("DATOS MODIFICADOS CON ÉXITO");}                            
                            else { Console.WriteLine("NO SE MODIFICÓ NINGÚN DATO");}
                        }
                        Console.ReadKey();
                        return _localidad;
                }
            }
        }
        public List<Localidad> eliminarLocalidad(Localidad _localidad, List<Localidad>_localidades)
        {
            _localidades.Remove(_localidad);
            Console.WriteLine("ÍTEM ELIMINADO");
            Console.ReadKey();
            return _localidades;
        }
        //---------------------------------------------------------------------------------
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
        public void subMenu(List<Localidad>_lista,int _opcionElegida)
        {
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
                        Localidad l = _lista[_opcionElegida];
                        Console.Clear();
                        switch (opcionSubMenu)
                        {
                            case 0:
                               
                                Localidad aux = actualizarLocalidad(l,_lista);
                                _lista[_opcionElegida] = aux;
                                cargarListaEnArchivo(listaLocalidadAString(_lista));
                                break;
                            case 1:
                                _lista = eliminarLocalidad(l, _lista);
                                cargarListaEnArchivo(listaLocalidadAString(_lista));
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
        List<Localidad> convertirListaALocalidad(List<string> lista)
        {
            List<Localidad> localidades = new List<Localidad>();
            string[] localidadString;
            for (int i = 0; i < lista.Count; i++)
            {
                localidadString = lista[i].Split(';');
                localidades.Add(elementoStringALocalidad(localidadString));
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
        public List<string> listaLocalidadAString(List<Localidad>_lista)
        {
            List<string>lista = new List<string>();
            foreach (var item in _lista)
            {
                lista.Add($"ID_LOCALIDAD:;{item.Id_localidad};ID_PROVINCIA:;{item.Id_provincia};LOCALIDAD:;{item.NombreLocalidad};");
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
            FileStream archivo = new FileStream("listaLocalidades.txt", FileMode.Create);

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
