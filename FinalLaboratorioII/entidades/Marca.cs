using System;

namespace FinalLaboratorioII.entidades
{
    internal class Marca
    {
        private int id_marca {  get; set; }
        private string nombreMarca {  get; set; }

        public Marca()
        {

        }

        public Marca(int id_marca, string nombreMarca)
        {
            this.id_marca = id_marca;
            this.nombreMarca = nombreMarca ?? throw new ArgumentNullException(nameof(nombreMarca));
        }
         
        public string NombreMarca
        {
            get { return this.nombreMarca; }set { this.nombreMarca = value;}
        }
    }
}
