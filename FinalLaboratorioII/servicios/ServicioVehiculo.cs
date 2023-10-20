using FinalLaboratorioII.entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalLaboratorioII.servicios
{
    internal class ServicioVehiculo
    {

        public ServicioVehiculo()
        {

        }

        public Vehiculo crearVehiculo()
        {
            Vehiculo vehiculo1 = new Vehiculo();
            Console.WriteLine("Nuevo vehículo");
            Console.WriteLine("Ingrese patente");
            vehiculo1.Patente = Console.ReadLine();
            Console.WriteLine("kilometro");
            vehiculo1.Kilometros = Console.ReadLine();
            Console.WriteLine("anio");
            vehiculo1.Anio = Console.ReadLine();
            Console.WriteLine("id_marca");
            Console.WriteLine("modelo");
            vehiculo1.Modelo = Console.ReadLine();
            Console.WriteLine("id_segmento");
            Console.WriteLine("id_combustible");
            Console.WriteLine("precio");
            vehiculo1.Precio_vta = float.Parse(Console.ReadLine());
            Console.WriteLine("observaciones");
            vehiculo1.Observaciones = Console.ReadLine();

            return vehiculo1;
        }

        public void mostrarVehiculos(string _ruta)
        {
            List<string>lista = cargarArchivoEnLista(_ruta);
            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }
        }
       
        public void actualizarVehiculo(int _id,string _ruta)
        {
            int cont = 0;
            string aux = "";
            string res = "";
            List<string>lista = cargarArchivoEnLista(_ruta);
            foreach (var item in lista)
            {

                if (item.Substring(4, 2).Equals($"{_id}"))
                {
                    Console.WriteLine("Datos del vehículo: ");
                    Console.WriteLine(item);
                    Console.Write("Modificar datos? -> S/N");
                    res = Console.ReadLine();
                    aux = item;
                    cont = 1;
                    break;
                }
            }
            if (cont == 1)
            {

                









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

    }
}
