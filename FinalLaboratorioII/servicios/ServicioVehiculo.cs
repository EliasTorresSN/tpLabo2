using FinalLaboratorioII.entidades;
using FinalLaboratorioII.entidades.subEntidades;
using FinalLaboratorioII.utilidades;
using System;
using System.Collections.Specialized;

namespace FinalLaboratorioII.servicios
{
    internal class ServicioVehiculo
    {
        public ServicioVehiculo()
        {
        }

        public void menuVehiculos()
        {
            List<string> listaLocalidades = cargarArchivoEnLista("listaVehiculos.txt");

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
            string cil,dimension,cm;
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
            Console.WriteLine("INGRESE AÑO");
            string anio = Console.ReadLine();
            vehiculo1.Anio = anio;
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

                    valido = validarNumeros(dimension);
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

        //---------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------
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
        List<Vehiculo> convertirListaAVehiculos(List<string> lista)
        {
            List<Vehiculo>vehiculos = new List<Vehiculo>();
            
            for (int i = 0; i < (lista.Count*2); i++)
            {
                string[] vehiculoString = lista[i].Split(';');
                vehiculos.Add(elementoStringAVehiculo(vehiculoString));
            }
            return vehiculos;
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
        }
        public void mostrarVehiculos(List<string>_lista)
        {

            List<string> lista = _lista;
            int cont = 0;
            Console.CursorVisible = false;            
            int opcionElegida = 0;

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
                                            actualizarVehiculo(opcionElegida);
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

        }
        public void actualizarVehiculo(int opcion)
        {
            Console.Clear();
            Console.CursorVisible = false;
            List<string> lista = cargarArchivoEnLista("listaVehiculos.txt");
            string[] opciones = { "Si", "No" };
            int opcionElegida = 0;
            bool subMenu = true;

            if (lista.Count > 1)
            {
                Console.Clear();
                Console.WriteLine("¿Modificar item seleccionado?");

                while (subMenu)
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
                                    Vehiculo v = vehiculoParaActualizar(lista,opcion);


                                    FileStream archivoNuevo = new FileStream("listaVehiculos.txt", FileMode.Create);
                                    archivoNuevo.Close();
                                    cargarListaEnArchivo(lista);
                                    Console.WriteLine("Item modificado");
                                    Console.ReadKey();
                                    break;
                                case 1:
                                    Console.WriteLine("No se modificó el ítem");
                                    Console.ReadKey();
                                    break;
                            }
                            subMenu = false;
                            break;

                        case ConsoleKey.Escape:
                            subMenu = false;
                            break;
                    }
                }
            }
        }
        public Vehiculo vehiculoParaActualizar(List<string>lista, int opcion)
      {   
            
            string[] atributos = lista[opcion].Split(" ");
            string[] datos = new string[10];
            string[] datosRecorrido = { "Marca", "Modelo", "Año", "Kilometros", "Patente", "Segmento", "Combustible", "Observaciones", "Precio" };

            int cont = 0,cont2 = 0;
            
            for (int i = 0; i < atributos.Length; i++)
            {
                if (i % 2 == 1)
                {
                    datos[cont] = atributos[i];
                    cont++;
                }
            }

            Vehiculo v = new Vehiculo();            
            v.Id_vehiculo = int.Parse(datos[0]);
            v.Id_marca = int.Parse(datos[1]);
            v.Modelo = datos[2];
            v.Anio = datos[3];
            v.Kilometros = datos[4];
            v.Patente = datos[5];
            v.Id_segmento = int.Parse(datos[6]);
            v.Id_combustible = int.Parse(datos[7]);
            v.Observaciones = datos[8];
            v.Precio_vta = double.Parse(datos[9]);

            Console.CursorVisible = false;            
            int opcionElegida = 0;

            while (true)
            {
                Console.Clear();
                for (int i = 0; i < datosRecorrido.Length; i++)
                {
                    if (i == opcionElegida)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine(datosRecorrido[i]);
                    Console.ResetColor();
                }

                var key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        opcionElegida = Math.Max(0, opcionElegida - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        opcionElegida = Math.Min(datosRecorrido.Length - 1, opcionElegida + 1);
                        break;
                    case ConsoleKey.Enter:

                        string nValor = "";
                        bool isOk = false;
                        Console.Write($"Ingrese el nuevo valor para -> {opcionElegida}:\n");
                        if (opcionElegida==0)
                        {
                            int res = mostrarMenuInteractivo("listaMarcas.txt");
                            v.Id_marca = res;
                        }
                        if (opcionElegida==5)
                        {
                            int res = mostrarMenuInteractivo("listaSegmentos.txt");
                        }
                        if (opcionElegida == 6)
                        {
                            mostrarMenuInteractivo("listaCombustibles.txt");
                        }
                        if (opcionElegida == 8)
                        {
                            isOk = false;

                            double n = 0;
                            while (!isOk)
                            {
                                try
                                {
                                    nValor = Console.ReadLine();
                                    n = double.Parse(nValor);
                                    isOk = true;
                                }
                                catch (Exception)
                                {
                                    isOk = false;
                                    Console.WriteLine("Debe ingresar sólo numeros");
                                    Console.WriteLine("Ingrese nuevamente el valor");

                                }
                            }

                            v.Precio_vta = n;

                        }
                        else
                        {
                            nValor = Console.ReadLine();

                        }


                        


                        Console.Clear();
                        Console.ReadKey();
                        break;
                }
            }

            for (int i = 0; i < datosRecorrido.Length; i++)
            {
                Console.WriteLine("dr " + datosRecorrido[i]);
            }

            v.Id_vehiculo = int.Parse(datos[0]);
            v.Id_marca = int.Parse(datos[1]);
            v.Modelo = datos[2];
            v.Anio = datos[3];
            v.Kilometros = datos[4];
            v.Patente = datos[5];
            v.Id_segmento = int.Parse(datos[6]);
            v.Id_combustible = int.Parse(datos[7]);
            v.Observaciones = datos[8];
            v.Precio_vta = double.Parse(datos[9]);

            return v;
      }      
        public void eliminarVehiculo()
        {
            Console.Clear();
            List<string> lista = cargarArchivoEnLista("listaVehiculos.txt");
            Console.CursorVisible = false;
            int opcionElegida = 0;

            if (lista.Count>1)
            {
                while (true)
                {
                    Console.Clear();
                    for (int i = 0; i < lista.Count; i++)
                    {
                        if (i != lista.Count-1)
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

                            Console.Clear();
                            Console.WriteLine($"Seleccionaste: {lista[opcionElegida]}");
                            eliminarVehiculo(opcionElegida);
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("No hay items cargados"); 
            }
           
        }
        public void eliminarVehiculo(int opcion)
        {
            Console.Clear();
            Console.CursorVisible = false;
            List<string> lista = cargarArchivoEnLista("listaVehiculos.txt");
            string[] opciones = { "Si", "No"};
            int opcionElegida = 0;
            bool subMenu = true;

            if (lista.Count>1)
            {
                Console.Clear();
                Console.WriteLine("¿Eliminar item seleccionado?");

                while (subMenu)
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
                                    Console.WriteLine("Item eliminado");
                                    break;
                                case 1:
                                    Console.WriteLine("No se eliminó el ítem");
                                    Console.ReadKey();
                                    break;
                            }
                            subMenu = false;
                            break;
                        case ConsoleKey.Escape:
                            subMenu = false;
                            break;
                    }

                }
                FileStream archivoNuevo = new FileStream("listaVehiculos.txt", FileMode.Create);
                archivoNuevo.Close();
                cargarListaEnArchivo(lista);
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("No hay items cargados");
            }
            

            
        }
        public void menuVehiculos() {
            Console.Clear();
            List<string> lista = cargarArchivoEnLista("listaVehiculos.txt");
            List<Vehiculo>listaVehiculos = convertirListaAVehiculos(lista);

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
                            cargarListaEnArchivo(lista);
                        }
                        else if (opcionElegida == 1)
                        {
                            mostrarVehiculos(lista);
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
                        
                        Console.Clear();
                        Console.WriteLine($"Seleccionaste: {opciones[opcionElegida]}");
                        Console.ReadKey();
                    break;
                }
            }

        }
        public  int mostrarMenuInteractivo(string _ruta)
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





    }



}
