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
            this.Id_marca = id_marca;
            this.NombreMarca = nombreMarca ?? throw new ArgumentNullException(nameof(nombreMarca));
        }

        public int Id_marca
        {
            get { return this.id_marca; }
            set { this.id_marca = value; }
        }

        public string NombreMarca
        {
            get { return this.nombreMarca; }set { this.nombreMarca = value;}
        }


        public override string  ToString()
        {
            return $"ID: {this.Id_marca} MARCA: {this.NombreMarca} ";
        }





    }
}
