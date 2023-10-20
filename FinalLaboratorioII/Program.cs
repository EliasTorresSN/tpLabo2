using FinalLaboratorioII.entidades;
using FinalLaboratorioII.entidades.subEntidades;
using FinalLaboratorioII.servicios;
using System.IO;

namespace FinalLaboratorioII
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicioVehiculo sv = new ServicioVehiculo();
            //sv.mostrarVehiculos("listaVehiculos.txt");
            sv.actualizarVehiculo(10,"listaVehiculos.txt");

            //Vehiculo vehiculo1 = new Vehiculo();
            //vehiculo1.Anio = "2005";
            //vehiculo1.Id_vehiculo = 10;
            //vehiculo1.Precio_vta = 21321;

            //Console.WriteLine(vehiculo1.ToString());
        }

        static FileStream crearArchivo()
        {
            string ruta = "ListaClientes.txt";
            StreamWriter writer;
            FileStream archivo = new FileStream(ruta, FileMode.Create);
            archivo.Close();
            return archivo;
        }
    } 

}