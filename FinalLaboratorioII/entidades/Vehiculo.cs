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
        private string color {  get; set; }
        private string cilindrada {  get; set; }
        private bool caja_carga { get; set; }
        private string dimension_caja {  get; set; }
        private string carga_max {  get; set; }



        public Vehiculo()
        {

        }
        
        public Vehiculo(int id_vehiculo, string patente, string kilometros, string anio, int id_marca,
            string modelo, int id_segmento, int id_combustible, double precio_vta, string observaciones, string color, string cilindrada,bool caja_carga, string dimension_caja, string carga_max)
        {
            this.Id_vehiculo = id_vehiculo;
            this.Id_marca = id_marca;
            this.Modelo = modelo;
            this.Anio = anio;
            this.Kilometros = kilometros;
            this.Patente = patente;
            this.Id_segmento = id_segmento;
            this.Id_combustible = id_combustible;
            this.Cilindrada = cilindrada;
            this.Caja_carga = caja_carga;
            this.Dimension_caja = dimension_caja;
            this.Observaciones = observaciones;
            this.Precio_vta = precio_vta;
        }

        public int Id_vehiculo
        {
            get {  return this.id_vehiculo;} set { this.id_vehiculo = value; }
        }
        public int Id_marca
        {
            get { return this.id_marca; }set { this.id_marca = value; }
        }
        public string Modelo
        {
            get { return this.modelo; } set { this.modelo = value; }
        }
        public  string Anio
        {
            get { return this.anio; }set { this.anio = value; }
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
            get { return this.id_segmento; }set { this.id_segmento = value;}
        }
        public int Id_combustible
        {
            get { return this.id_combustible; }set { this.id_combustible = value; }
        }
        public string Observaciones
        {
            get { return this.observaciones; } set { this.observaciones = value; }
        }
        public double Precio_vta
        {
            get { return this.precio_vta; }set { this.precio_vta = value; }
        }
        public string Color
        {
            get { return this.color; }set { this.color = value; }
        }
        public string Cilindrada
        {
            get { return this.cilindrada; }set { this.cilindrada = value; }
        }
        public bool Caja_carga
        {
            get { return this.caja_carga; }set { this.caja_carga = value; }
        }
        public string Dimension_caja
        {
            get { return this.dimension_caja; }set { this.dimension_caja = value; }
        }
        public string Carga_max { 
            get { return this.carga_max; } set { this.carga_max = value; } 
        }

        public override string ToString()
        {
            return $" ID: {id_vehiculo} ID_Marca: {id_marca} Modelo: {modelo} Año: {anio} Kilometros: {kilometros} Patente: {patente} ID_Segmento: {id_segmento} ID_Combustible: {id_combustible}" + 
                $"Caja_carga: {caja_carga} Dimension_caja: {dimension_caja}m2 Carga_max: {carga_max}  Observaciones: {observaciones} Precio_Venta: {precio_vta}";
        }

    }
}