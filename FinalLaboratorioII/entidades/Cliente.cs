using System;

namespace FinalLaboratorioII.entidades
{
    internal class Cliente
    {
        private int id_cliente { get; set; }
        private string nombreCliente { get; set; }
        private string cuit { get; set; }
        private string domicilio { get; set; }
        private int id_localidad { get; set; }
        private string telefono { get; set; }
        private string correo { get; set; }

        public Cliente()
        { }

        public Cliente(int id_cliente, string nombreCliente, string cuit, string domicilio, int id_localidad, string telefono, string correo)
        {
            this.Id_cliente = id_cliente;
            this.NombreCliente = nombreCliente;
            this.Cuit = cuit;
            this.Domicilio = domicilio; 
            this.Id_localidad = id_localidad;
            this.Telefono = telefono;
            this.Correo = correo; 
        }

        public int Id_cliente
        {
            get { return this.id_cliente; } set {this.id_cliente = value;}
        }
        public string NombreCliente
        {
            get{return this.nombreCliente;} set { this.nombreCliente = value; }
        }
        public string Cuit
        {
            get { return this.cuit; } set { this.cuit = value; }
        }
        public string Domicilio
        {
            get { return this.domicilio; } set { this.domicilio = value; }
        }
        public int Id_localidad
        {
            get{return this.id_localidad;} set{ this.id_localidad = value;}            
        }

        public string Telefono
        {
            get { return this.telefono; } set { this.telefono = value;}
        }

        public string Correo
        {
            get { return this.correo; } set { this.correo = value;}
        }


        public override string ToString()
        {
            return  $"ID_CLIENTE: {this.Id_cliente} NOMBRE: {this.NombreCliente} C.U.I.T: {this.Cuit}" +
                $" DOMICILIO {this.Domicilio} ID_LOCALIDAD: {this.Id_localidad} TELÉFONO: {this.Telefono} CORREO: {this.Correo}"  ;

        }

    }
}
