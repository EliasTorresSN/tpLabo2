using System;

namespace FinalLaboratorioII.entidades
{
    internal class Combustible
    {
        private int id_combustible {  get; set; }
        private string combustible {  get; set; }

        public Combustible()
        {

        }

        public Combustible(int id_combustible, string combustible)
        {
            this.id_combustible = id_combustible;
            this.combustible = combustible ?? throw new ArgumentNullException(nameof(combustible));
        }
    }
}
