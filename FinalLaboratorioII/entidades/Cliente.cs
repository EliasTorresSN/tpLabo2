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

        public Cliente(int id_cliente, string cliente, string cuit, string domicilio, int id_localidad, string telefono, string correo)
        {
            this.id_cliente = id_cliente;
            this.nombreCliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
            this.cuit = cuit ?? throw new ArgumentNullException(nameof(cuit));
            this.domicilio = domicilio ?? throw new ArgumentNullException(nameof(domicilio));
            this.id_localidad = id_localidad;
            this.telefono = telefono ?? throw new ArgumentNullException(nameof(telefono));
            this.correo = correo ?? throw new ArgumentNullException(nameof(correo));
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

    }
}
