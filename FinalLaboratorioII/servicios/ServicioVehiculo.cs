using FinalLaboratorioII.entidades;
using FinalLaboratorioII.entidades.subEntidades;
using System;
using System.Collections.Specialized;

namespace FinalLaboratorioII.servicios
{
    internal class ServicioVehiculo
    {
        public ServicioVehiculo()
        {
        }
        public Vehiculo crearVehiculo(List<Vehiculo>_vehiculos)
        {
            ServicioMarca sm = new ServicioMarca();
            ServicioSegmento ss = new ServicioSegmento();
            ServicioCombustible sc = new ServicioCombustible();
            Vehiculo vehiculo1 = new Vehiculo();
            List<Marca> marcas = sm.convertirListaAMarca(sm.cargarArchivoEnLista("listaMarcas.txt"););

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
            vehiculo1.Id_marca = id_marca;
            Console.Clear();
            Console.WriteLine("INGRESE MODELO");
            string mod = Console.ReadLine();
            vehiculo1.Modelo = mod;
            Console.WriteLine("INGRESE AÑO");
            string anio = Console.ReadLine();
            vehiculo1.Anio = anio;
            Console.WriteLine("INGRESE KILÓMETROS");
            string km = Console.ReadLine();
            vehiculo1.Kilometros = km;
            Console.WriteLine("INGRESE PATENTE");
            string patente = Console.ReadLine();
            vehiculo1.Patente = patente;



            //ID SEG
            //id_comb
            //color
            //cilindrada
            //caja carga
            //dimensio
            //cargamax
            //observacion
            //preciovta






            return vehiculo1;
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
        /*public List<string> cargarVehiculoEnLista()
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
          } */
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
        public void agregarVehiculo(List<Vehiculo>_listaVehiculos)
        {
            int id, idMarca, idSegmento, idCombustible;
            string modelo, anio, patente, kms, color;

            Camion camion = new Camion();
           
            Console.WriteLine("Nuevo vehículo");
            //id_vehiculo
            id = _listaVehiculos[_listaVehiculos.Count - 1].Id_vehiculo + 1;

            Console.WriteLine("Marca");
            idMarca = 1;
            Console.WriteLine("Modelo");
            string model = Console.ReadLine();
            Console.WriteLine("Año");
            string Anio = Console.ReadLine();

            Console.WriteLine("Patente");
            patente = Console.ReadLine();

            Console.WriteLine("Cantidad de kilometros");
            kms = Console.ReadLine();

            Console.WriteLine("Combustible");
            idCombustible = 1;

            Console.WriteLine("Segmento");
            idSegmento = 1;

            Console.WriteLine("Color");
            color = Console.ReadLine();

            if (idSegmento == 1 || idSegmento == 2 || idSegmento == 3 )
            {



            }
            else if ( idSegmento == 4)
            {

            }
            else if (idSegmento == 5 || idSegmento == 6 || idSegmento == 7)
            {

            }
            else if (idSegmento == 8)
            {

            }




            //Console.WriteLine("id_combustible");
            //vehiculo1.Id_combustible = 1;

            //Console.WriteLine("Observaciones:");
            //vehiculo1.Observaciones = Console.ReadLine();

            //Console.WriteLine("Precio:");
            //vehiculo1.Precio_vta = float.Parse(Console.ReadLine());



        }


    }



}
