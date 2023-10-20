using System;

namespace FinalLaboratorioII.entidades
{
    internal class Vehiculo
    {
        private int id_vehiculo { get; set; }
        private string patente { get; set; }
        private string kilometros { get; set; }
        private string anio { get; set; }
        private int id_marca { get; set; }
        private string modelo { get; set; }
        private int id_segmento { get; set; }
        private int id_combustible { get; set; }
        private double precio_vta { get; set; }
        private string observaciones { get; set; }


        public Vehiculo()
        {

        }

        public Vehiculo(int id_vehiculo, string patente, string kilometros, string anio, int id_marca, string modelo, int id_segmento, int id_combustible, double precio_vta, string observaciones)
        {
            this.id_vehiculo = id_vehiculo;
            this.id_marca = id_marca;
            this.modelo = modelo ?? throw new ArgumentNullException(nameof(modelo));
            this.anio = anio ?? throw new ArgumentNullException(nameof(anio));
            this.kilometros = kilometros ?? throw new ArgumentNullException(nameof(kilometros));
            this.patente = patente ?? throw new ArgumentNullException(nameof(patente));
            this.id_segmento = id_segmento;
            this.id_combustible = id_combustible;
            this.observaciones = observaciones ?? throw new ArgumentNullException(nameof(observaciones));
            this.precio_vta = precio_vta;
        }

        public int Id_vehiculo
        {
            get {  return this.id_vehiculo;} set { this.id_vehiculo = value; }
        }
        public int Id_marca
        {
            get { return this.id_marca; }
            set { this.id_marca = value; }
        }
        public string Modelo
        {
            get { return this.modelo; } set { this.modelo = value; }
        }
        public  string Anio
        {
            get { return this.anio; }
            set { this.anio = value; }
        }
        public string Kilometros
        {
            get { return this.kilometros;}set { this.kilometros = value;}
        }
        public string Patente
        {
            get { return this.patente; } set { this.patente = value; }
        }
        public int Id_segmento
        {
            get { return this.id_segmento; }
            set { this.id_segmento = value;}
        }
        public int Id_combustible
        {
            get { return this.id_combustible; }
            set { this.id_combustible = value; }
        }
        public string Observaciones
        {
            get { return this.observaciones; }
            set { this.observaciones = value;}
        }
        public double Precio_vta
        {
            get { return this.precio_vta; }
            set { this.precio_vta = value; }
        }

        public override string ToString()
        {
            return $"ID: {id_vehiculo} ID Marca: {id_marca} Modelo: {modelo} Anio: {anio} Kilometros: {kilometros} Patente: {patente} ID Segmento: {id_segmento} ID Combustible: {id_combustible}" +
                $"Observaciones: {observaciones} Precio-Venta: {precio_vta}";
        }

    }
}