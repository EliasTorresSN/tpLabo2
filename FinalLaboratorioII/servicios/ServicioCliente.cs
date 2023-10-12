using FinalLaboratorioII.entidades;
using System;
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









    }
}
