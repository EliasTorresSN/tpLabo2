using System;

namespace FinalLaboratorioII.entidades
{
    internal class Vehiculo
    {
        private int id_vehiculo { get; set; }
        private string patente { get; set; }
        private string kilometros { get; set; }
        private string anio { get; set; }
        private string id_marca { get; set; }
        private string modelo { get; set; }
        private int id_segmento { get; set; }
        private int id_combustible { get; set; }
        private double precio_vta { get; set; }
        private string observaciones { get; set; }


        public Vehiculo()
        {

        }

        public Vehiculo(int id_vehiculo, string patente, string kilometros, string anio, string id_marca, string modelo, int id_segmento, int id_combustible, double precio_vta, string observaciones)
        {
            this.id_vehiculo = id_vehiculo;
            this.patente = patente ?? throw new ArgumentNullException(nameof(patente));
            this.kilometros = kilometros ?? throw new ArgumentNullException(nameof(kilometros));
            this.anio = anio ?? throw new ArgumentNullException(nameof(anio));
            this.id_marca = id_marca ?? throw new ArgumentNullException(nameof(id_marca));
            this.modelo = modelo ?? throw new ArgumentNullException(nameof(modelo));
            this.id_segmento = id_segmento;
            this.id_combustible = id_combustible;
            this.precio_vta = precio_vta;
            this.observaciones = observaciones ?? throw new ArgumentNullException(nameof(observaciones));
        }
    }
}
