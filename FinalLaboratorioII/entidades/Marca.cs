using System;

namespace FinalLaboratorioII.entidades
{
    internal class Marca
    {
        private int id_marca {  get; set; }
        private string marca {  get; set; }

        public Marca()
        {

        }

        public Marca(int id_provincia, string provincia)
        {
            this.id_marca = id_marca;
            this.marca = marca ?? throw new ArgumentNullException(nameof(marca));
        }
    }
}
