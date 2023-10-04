using System;

namespace FinalLaboratorioII.entidades
{
    internal class Venta
    {
        private int id_Cliente { get; set; }
        private int id_Vehiculo { get; set; }
        private DateTime fecha_compra { get; set; }
        private DateTime fecha_entrega { get; set; }
        private int subtotal { get; set; }
        private double iva { get; set; }
        private double descuento { get; set; }
        private double total { get; set; }

        public Venta()
        {

        }

        public Venta(int id_Cliente, int id_Vehiculo, DateTime fecha_compra, DateTime fecha_entrega, int subtotal, double iva, double descuento, double total)
        {
            this.id_Cliente = id_Cliente;
            this.id_Vehiculo = id_Vehiculo;
            this.fecha_compra = fecha_compra;
            this.fecha_entrega = fecha_entrega;
            this.subtotal = subtotal;
            this.iva = iva;
            this.descuento = descuento;
            this.total = total;
        }
    }
}
