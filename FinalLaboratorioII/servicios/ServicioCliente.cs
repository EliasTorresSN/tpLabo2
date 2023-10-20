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
            Cliente cliente = new Cliente();
            Console.WriteLine("Ingrese cliente: ");
            cliente.NombreCliente = Console.ReadLine();
            Console.WriteLine("Ingrese C.U.I.T.: ");
            cliente.Cuit = Console.ReadLine();
            Console.WriteLine("Ingrese domicilio del cliente: ");
            cliente.Domicilio = Console.ReadLine();
            Console.WriteLine("Ingrese localidad del cliente: ");
            cliente.NombreCliente = Console.ReadLine();
            Console.WriteLine("Ingrese telefono:");
            cliente.NombreCliente = Console.ReadLine();
            Console.WriteLine("Ingrese correo electrónico:");
            cliente.NombreCliente = Console.ReadLine();

            return new Cliente();
        }

        //public Cliente editarCliente(Cliente _cliente, List<Cliente>listaClientes)
        //{
             
            

        //    if (c != null)
        //    {

               
        //        Console.WriteLine(c);

        //        Console.WriteLine("Ingrese cliente: ");
        //        c.NombreCliente = Console.ReadLine();
        //        Console.WriteLine("Ingrese C.U.I.T.: ");
        //        c.Cuit = Console.ReadLine();
        //        Console.WriteLine("Ingrese domicilio del cliente: ");
        //        c.Domicilio = Console.ReadLine();
        //        Console.WriteLine("Ingrese localidad del cliente: ");
        //        c.NombreCliente = Console.ReadLine();
        //        Console.WriteLine("Ingrese telefono:");
        //        c.NombreCliente = Console.ReadLine();
        //        Console.WriteLine("Ingrese correo electrónico:");
        //        c.NombreCliente = Console.ReadLine();
        //    }

        //    return c;
        //}

        public void eliminarCliente(Cliente _cliente)
        {


        }









    }
}
