using System;

namespace FinalLaboratorioII.entidades
{
    internal class Venta
    {
        private int id_Cliente { get; set; }
        private int id_Vehiculo { get; set; }
        private DateTime fecha_compra { get; set; }
        private DateTime fecha_entrega { get; set; }
        private double subtotal { get; set; }
        private double iva { get; set; }
        private double descuento { get; set; }
        private double total { get; set; }

        public Venta()
        {

        }

        public Venta(int id_Cliente, int id_Vehiculo, DateTime fecha_compra, DateTime fecha_entrega, double subtotal, double iva, double descuento, double total)
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

        public int Id_Vehiculo
        {
            get { return this.id_Vehiculo; }
            set { this.id_Vehiculo = value; }
        }
        public int Id_Cliente
        {
            get { return this.id_Cliente; }
            set { this.id_Cliente = value; }
        }
        public DateTime Fecha_compra
        {
            get { return this.fecha_compra; }
            set { this.fecha_compra = value; }

        }
        public DateTime Fecha_entrega
        {
            get { return this.fecha_entrega; }
            set { this.Fecha_entrega = value; }
        }

        public double Subtotal
        {
            get { return this.subtotal; }
            set { this.subtotal = value; }
        }
        public double Iva
        {
            get { return this.iva; }
            set { this.iva = value; }
        }

        public double Descuento
        {
            get { return this.descuento; }
            set { this.descuento = value;}
        }
        public double Total
        {
            get { return this.total; }
            set { this.total = value; }
        }
    }
}
