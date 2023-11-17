using FinalLaboratorioII.entidades;
using FinalLaboratorioII.entidades.subEntidades;
using FinalLaboratorioII.utilidades;
using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Reflection;

namespace FinalLaboratorioII.servicios
{
    internal class ServicioVehiculo
    {
        public ServicioVehiculo()
        {
        }

        public void menuVehiculos()
        {
            List<string> listaVehiculos = cargarArchivoEnLista("listaVehiculos.txt");

            Console.CursorVisible = false;
            string[] opciones = { "AGREGAR VEHICULO", "MOSTRAR VEHICULOS" };
            int opcionElegida = 0;

            while (true)
            {
                List<Vehiculo> vehiculos = convertirListaAVehiculo(listaVehiculos);
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

                            Vehiculo vehiculo1 = crearVehiculo(vehiculos);
                            vehiculos.Add(vehiculo1);
                            List<string> vehiculosString = listaVehiculoAString(vehiculos);
                            cargarListaEnArchivo(vehiculosString);
                            return;
                        }
                        else if (opcionElegida == 1)
                        {
                            mostrarVehiculos(vehiculos);

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
        public Vehiculo crearVehiculo(List<Vehiculo>_vehiculos)
        {
            Menu menu = new Menu();
            ServicioMarca sm = new ServicioMarca();
            ServicioSegmento ss = new ServicioSegmento();
            ServicioCombustible sc = new ServicioCombustible();
            Vehiculo vehiculo1 = new Vehiculo();
            List<Marca> marcas = sm.convertirListaAMarca(sm.cargarArchivoEnLista("listaMarcas.txt"));
            List<Segmento> segmentos = ss.crearListaSegmentos();
            List<Combustible> combustibles = sc.crearListaCombustible();
            string[]colores = { "Amarillo","Azul","Blanco","Gris","Marrón","Naranja","Negro","Rojo","Rosa","Verde" };
            string cil,dimension,cm,anio;
            bool valido = false;



            if (_vehiculos.Count == 0)
            {
                vehiculo1.Id_vehiculo = 1;
            }
            else
            {
                vehiculo1.Id_vehiculo = _vehiculos[_vehiculos.Count - 1].Id_vehiculo + 1;
            }

            Console.WriteLine("ELIJA MARCA");
            int id_marca = sm.mostrarMenuInteractivo(marcas);
            Console.Clear();
            vehiculo1.Id_marca = id_marca + 1;
            Console.Clear();
            Console.WriteLine("INGRESE MODELO");
            string mod = Console.ReadLine();
            vehiculo1.Modelo = mod;
            do
            {
                Console.WriteLine("INGRESE AÑO");

                 anio = Console.ReadLine();
                valido = validarNumeros(anio);
                if (valido)
                {
                    vehiculo1.Anio = anio;

                }
            } while (!valido);
           
            do
            {
                Console.WriteLine("INGRESE KILÓMETROS");

                string km = Console.ReadLine();
                valido = validarNumeros(km);
                if (valido)
                {
                    vehiculo1.Kilometros = km;

                }
            } while (!valido);


            Console.Clear();
            Console.WriteLine("INGRESE PATENTE");
            string patente = Console.ReadLine();
            vehiculo1.Patente = patente;
            Console.Clear();
            Console.WriteLine("ELIJA SEGMENTO");
            int id_seg = ss.mostrarMenuInteractivo(segmentos);
            vehiculo1.Id_segmento = id_seg + 1;
            Console.Clear();
            Console.WriteLine("ELIJA COMBUSTIBLE");
            int id_comb = sc.mostrarMenuInteractivo(combustibles);
            vehiculo1.Id_combustible = id_comb + 1;
            Console.Clear();
            Console.WriteLine("ELIJA COLOR");
            int col = menu.mostrarMenuInteractivo(colores);
            vehiculo1.Color = colores[col];
            Console.Clear();

            if (id_seg == 1 || id_seg == 2 || id_seg == 3 || id_seg == 5 || id_seg == 6 || id_seg == 7)
            {
                if (id_seg == 5 || id_seg == 6 || id_seg == 7)
                {
                    do
                    {
                        Console.WriteLine("INGRESE CILINDRADA");
                        cil = Console.ReadLine();
                        valido = validarNumeros(cil);
                        if (valido)
                        {
                            vehiculo1.Cilindrada = cil;
                            
                        }
                    } while (!valido);
                }
                else
                {
                    vehiculo1.Cilindrada = "n/d";
                }
                vehiculo1.Caja_carga = false;
                vehiculo1.Dimension_caja = "n/d";
                vehiculo1.Patente = "n/d";
                Console.Clear();

            }
            else if (id_seg == 4 || id_seg == 8)
            {
                vehiculo1.Cilindrada = "n/d";
                vehiculo1.Caja_carga = true;

                do
                {
                    Console.WriteLine("INGRESE DIMENSION DE CAJA");

                    dimension = Console.ReadLine();
                    valido = validarNumeros(dimension);
                    if (valido)
                    {
                        vehiculo1.Dimension_caja = $"{dimension} cm3";

                    }
                } while (!valido);
                
                Console.Clear();
                do
                {
                    Console.WriteLine("CARGA MAX");


                    cm = Console.ReadLine();

                    valido = validarNumeros(cm);
                    if (valido)
                    {
                        vehiculo1.Carga_max = $"{cm} kg";

                    }
                } while (!valido);

            }

            Console.Clear();
            Console.WriteLine("INGRESE OBSERVACIONES");
            string obs= Console.ReadLine();
            vehiculo1.Observaciones= obs;

            Console.Clear();

            do
            {
                Console.WriteLine("INGRESE PRECIO");
                string precio = Console.ReadLine();
                valido = validarPrecio(precio);

                if (valido)
                {
                    vehiculo1.Precio_vta =double.Parse(precio);
                }
            } while (!valido);

            return vehiculo1;
        }
        public void mostrarVehiculos(List<Vehiculo> _lista)
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
                        menuVehiculos();
                        break;

                }
            }
            Console.ReadKey();
        }
        public Vehiculo actualizarVehiculo(Vehiculo _vehiculo, List<Vehiculo> _lista)
        {
            Menu menu = new Menu();
            ServicioMarca sm = new ServicioMarca();
            ServicioSegmento ss = new ServicioSegmento();
            ServicioCombustible sc = new ServicioCombustible();
            List<Marca> marcas = sm.convertirListaAMarca(sm.cargarArchivoEnLista("listaMarcas.txt"));
            List<Segmento> segmentos = ss.crearListaSegmentos();
            List<Combustible> combustibles = sc.crearListaCombustible();
            string[] colores = { "Amarillo", "Azul", "Blanco", "Gris", "Marrón", "Naranja", "Negro", "Rojo", "Rosa", "Verde" };
            string cil, dimension, cm, anio;
            bool valido = false;

            string[] atributos = { "MARCA", "MODELO", "AÑO", "KILOMETROS", "PATENTE", "SEGMENTO", "COMBUSTIBLE",
                "COLOR", "CILINDRADA", "CAJA_CARGA", "DIMENSION_CAJA", "CARGA_MAX", "OBSERVACIONES", "PRECIO", "SALIR" };
            int c = 0;

            Console.CursorVisible = false;
            int opcionElegida = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("ATRIBUTO A MODIFICAR");

                if (_vehiculo.Id_segmento == 1 || _vehiculo.Id_segmento == 2 || _vehiculo.Id_segmento == 3 || _vehiculo.Id_segmento == 5 || _vehiculo.Id_segmento == 6 || _vehiculo.Id_segmento == 7)
                {

                    for (int i = 0; i < 8; i++)
                    {

                        if (i == opcionElegida)
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;
                        }
                        Console.WriteLine(atributos[i]);
                        Console.ResetColor();
                    }


                    if (_vehiculo.Id_segmento == 5 || _vehiculo.Id_segmento == 6 || _vehiculo.Id_segmento == 7)
                    {
                        for (int i = 0; i < 9; i++)
                        {

                            if (i == opcionElegida)
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                            }
                            Console.WriteLine(atributos[i]);
                            Console.ResetColor();
                        }

                    }
                    else
                    {
                        for (int i = 0; i < 8; i++)
                        {

                            if (i == opcionElegida)
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                            }
                            Console.WriteLine(atributos[i]);
                            Console.ResetColor();
                        }
                    }

                    Console.Clear();

                }
                else if (_vehiculo.Id_segmento == 4 || _vehiculo.Id_segmento == 8)
                {
                    for (int i = 0; i < atributos.Length; i++)
                    {
                        if (i==8)
                        {
                            i = 9;
                        }
                        if (i == opcionElegida)
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;
                        }
                        Console.WriteLine(atributos[i]);
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
                        opcionElegida = Math.Min(atributos.Length - 1, opcionElegida + 1);
                        break;
                    case ConsoleKey.Enter:
                        switch (opcionElegida)
                        {
                            case 0:
                                Console.WriteLine("ELIJA MARCA");
                                int id_marca = sm.mostrarMenuInteractivo(marcas);
                                Console.Clear();
                                _vehiculo.Id_marca = id_marca + 1;
                                Console.Clear(); ;
                                break;
                            case 1:
                                Console.WriteLine("INGRESE MODELO");
                                string mod = Console.ReadLine();
                                _vehiculo.Modelo = mod; ;
                                break;
                            case 2:
                                do
                                {
                                    Console.WriteLine("INGRESE AÑO");

                                    anio = Console.ReadLine();
                                    valido = validarNumeros(anio);
                                    if (valido)
                                    {
                                        _vehiculo.Anio = anio;

                                    }
                                } while (!valido); ;
                                break;
                            case 3:
                                do
                                {
                                    Console.WriteLine("INGRESE KILÓMETROS");

                                    string km = Console.ReadLine();
                                    valido = validarNumeros(km);
                                    if (valido)
                                    {
                                        _vehiculo.Kilometros = km;

                                    }
                                } while (!valido); ;
                                break;
                            case 4:
                                Console.WriteLine("INGRESE PATENTE");
                                string patente = Console.ReadLine();
                                _vehiculo.Patente = patente;
                                Console.Clear(); ;

                                break;
                            case 5:
                                Console.Clear();
                                Console.WriteLine("ELIJA SEGMENTO");
                                int id_seg = ss.mostrarMenuInteractivo(segmentos);
                                _vehiculo.Id_segmento = id_seg + 1; ;
                                break;
                            case 6:
                                Console.Clear();
                                Console.WriteLine("ELIJA COMBUSTIBLE");
                                int id_comb = sc.mostrarMenuInteractivo(combustibles);
                                _vehiculo.Id_combustible = id_comb + 1; ;
                                break;
                            case 7:
                                Console.WriteLine("ELIJA COLOR");
                                int col = menu.mostrarMenuInteractivo(colores);
                                _vehiculo.Color = colores[col];
                                Console.Clear(); ;
                                break;
                            case 8:
                                do
                                {
                                    Console.WriteLine("INGRESE CILINDRADA");
                                    cil = Console.ReadLine();
                                    valido = validarNumeros(cil);
                                    if (valido)
                                    {
                                        _vehiculo.Cilindrada = cil;

                                    }
                                } while (!valido);
                                Console.Clear();
                                break;
                            case 9:
                                _vehiculo.Caja_carga = true;
                                break;
                            case 10:
                                do
                                {
                                    Console.WriteLine("INGRESE DIMENSION DE CAJA");

                                    dimension = Console.ReadLine();
                                    valido = validarNumeros(dimension);
                                    if (valido)
                                    {
                                        _vehiculo.Dimension_caja = $"{dimension} cm3";

                                    }
                                } while (!valido); ; break;
                            case 11:
                                do
                                {
                                    Console.WriteLine("CARGA MAX");


                                    cm = Console.ReadLine();

                                    valido = validarNumeros(cm);
                                    if (valido)
                                    {
                                        _vehiculo.Carga_max = $"{cm} kg";

                                    }
                                } while (!valido); ; break;
                            case 12:
                                Console.WriteLine("INGRESE OBSERVACIONES");
                                string obs = Console.ReadLine();
                                _vehiculo.Observaciones = obs; ; break;
                            case 13:
                                do
                                {
                                    Console.WriteLine("INGRESE PRECIO");
                                    string precio = Console.ReadLine();
                                    valido = validarPrecio(precio);

                                    if (valido)
                                    {
                                        _vehiculo.Precio_vta = double.Parse(precio);
                                    }
                                } while (!valido); ; break;

                        }


                        Console.ReadKey();
                        return _vehiculo;
                }
            }
        }

        //---------------------------------------------------------------------------------
        public List<Vehiculo> convertirListaAVehiculo(List<string> lista)
        {
            List<Vehiculo>vehiculos = new List<Vehiculo>();
            
            for (int i = 0; i < (lista.Count); i++)
            {
                string[] vehiculoString = lista[i].Split(';');
                vehiculos.Add(elementoStringAVehiculo(vehiculoString));
            }
            return vehiculos;
        }
        public List<string> listaVehiculoAString(List<Vehiculo> _lista)
        {
            List<string> lista = new List<string>();
            foreach (var item in _lista)
            {
                lista.Add($"ID:;{item.Id_vehiculo};ID_Marca:;{item.Id_marca};Modelo:;{item.Modelo};Año:;{item.Anio};Kilometros:;{item.Kilometros};Patente:;{item.Patente};ID_Segmento:;{item.Id_segmento}" +
                $";ID_Combustible:;{item.Id_combustible};Color:;{item.Color};Cilindrada:;{item.Cilindrada};Caja_carga=;{item.Caja_carga};Dimension_Caja=;{item.Dimension_caja};Carga_Max =;{item.Carga_max}" +
                $";Observaciones:;{item.Observaciones};Precio_Venta:;{item.Precio_vta}");
            }
            return lista;
        }
        public Vehiculo elementoStringAVehiculo(string[]vehiculo)
        {
            Vehiculo v = new Vehiculo();
            string[]atributos = new string[15];
            int cont = 0;
            for (int i = 0; i < vehiculo.Length; i++)
            {
                if (i % 2 == 1)
                {
                    atributos[cont] = vehiculo[i];
                    cont++;
                }
            }

            v.Id_vehiculo = int.Parse(atributos[0]);
            v.Id_marca = int.Parse(atributos[1]);
            v.Modelo = atributos[2];
            v.Anio = atributos[3];
            v.Kilometros = atributos[4];
            v.Patente = atributos[5];
            v.Id_segmento = int.Parse(atributos[6]);
            v.Id_combustible = int.Parse(atributos[7]);
            v.Cilindrada = atributos[8];
            v.Caja_carga = bool.Parse(atributos[9]);
            v.Dimension_caja = atributos[10];
            v.Observaciones = atributos[11];
            v.Precio_vta = float.Parse(atributos[12]);



            return v;
        }
        //---------------------------------------------------------------------------------
        public int mostrarMenuInteractivo(string _ruta)
        {
            Console.Clear();
            List<string> lista = cargarArchivoEnLista(_ruta);
            Console.CursorVisible = false;
            int opcionElegida = 0;
            var res = 0;

            while (true)
            {
                Console.Clear();
                if (lista.Count == 0 || lista.Count == 1)
                {
                    Console.WriteLine("No hay ítems cargados");
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
                        res = opcionElegida;
                        break;
                }
            }
            return res;
        }
        public int mostrarMenuInteractivo(List<Segmento> lista)
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
                        opcionElegida = Math.Min(lista.Count - 1, opcionElegida + 1);
                        break;
                    case ConsoleKey.Enter:
                        int res = opcionElegida;
                        return res;
                }
            }
        }
        public void subMenu(List<Vehiculo> _lista, int _opcionElegida)
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
                        Vehiculo v = _lista[_opcionElegida];
                        Console.Clear();
                        switch (opcionSubMenu)
                        {
                            case 0:

                                Vehiculo aux = actualizarVehiculo(v, _lista);
                                _lista[_opcionElegida] = aux;
                                cargarListaEnArchivo(listaVehiculoAString(_lista));
                                break;
                            case 1:
                                _lista = eliminarVehiculo(l, _lista);
                                cargarListaEnArchivo(listaVehiculoAString(_lista));
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
        static bool validarNumeros(string _dato)
        {
            for (int i = 0; i <_dato.Length; i++)
            {
                if ((int)_dato[i] < 48 || (int)_dato[i] > 57)
                {
                    Console.WriteLine("Ingrese numeros validos ->");

                    return false;
                }
            }
            return true;
        }
        //---------------------------------------------------------------------------------
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
