using System;

namespace FinalLaboratorioII.entidades
{
    internal class Cliente
    {
        private int id_cliente { get; set; }
        private string cliente { get; set; }
        private string cuit { get; set; }
        private string domicilio { get; set; }
        private Localidad id_localidad { get; set; }
        private string telefono { get; set; }
        private string correo { get; set; }

        public Cliente()
        { }

        public Cliente(int id_cliente, string cliente, string cuit, string domicilio, Localidad id_localidad, string telefono, string correo)
        {
            this.id_cliente = id_cliente;
            this.cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
            this.cuit = cuit ?? throw new ArgumentNullException(nameof(cuit));
            this.domicilio = domicilio ?? throw new ArgumentNullException(nameof(domicilio));
            this.id_localidad = id_localidad ?? throw new ArgumentNullException(nameof(id_localidad));
            this.telefono = telefono ?? throw new ArgumentNullException(nameof(telefono));
            this.correo = correo ?? throw new ArgumentNullException(nameof(correo));
        }

        

    }
}
