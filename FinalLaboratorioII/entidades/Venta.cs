using System;

namespace FinalLaboratorioII.entidades
{
    internal class Venta
    {
        private int id_venta;
        private int id_Cliente;
        private int id_Vehiculo;
        private string fecha_compra;
        private string fecha_entrega;
        private double subtotal;
        private double iva;
        private double descuento;
        private double total;

        public Venta()
        {

        }

        public Venta(int id_venta,int id_Cliente, int id_Vehiculo, string fecha_compra, string fecha_entrega, double subtotal, double iva, double descuento, double total)
        {
            this.Id_venta = id_venta;
            this.Id_Cliente = id_Cliente;
            this.Id_Vehiculo = id_Vehiculo;
            this.Fecha_compra = fecha_compra;
            this.Fecha_entrega = fecha_entrega;
            this.Subtotal = subtotal;
            this.Iva = iva;
            this.Descuento = descuento;
            this.Total = total;
        }
        public int Id_venta
        {
            get { return this.id_venta; }
            set { this.id_venta = value; }
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
        public string Fecha_compra
        {
            get { return this.fecha_compra; }
            set { this.fecha_compra = value; }

        }
        public string Fecha_entrega
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

        public override string ToString()
        {
            return $"ID VENTA: {this.Id_venta} ID CLIENTE: {this.Id_Cliente}  ID_VEHICULO: {this.Id_Vehiculo} FECHACOMPRA: {this.Fecha_compra} FECHAENTREGA: {this.Fecha_entrega} SUBTOTAL:{this.Subtotal} IVA DESCUENTO:{this.Descuento} TOTAL: {this.Total}";
        }
    }
}
