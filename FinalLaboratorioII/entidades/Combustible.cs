using System;

namespace FinalLaboratorioII.entidades
{
    internal class Combustible
    {
        private int id_combustible {  get; set; }
        private string tipoCombustible {  get; set; }

        public Combustible()
        {

        }
        public Combustible(int id_combustible, string tipoCombustible)
        {
            this.id_combustible = id_combustible;
            this.tipoCombustible = tipoCombustible ?? throw new ArgumentNullException(nameof(tipoCombustible));
        }

        public int Id_combustible
        {
            get { return id_combustible;} set { id_combustible = value; }
        }
        public string TipoCombustible
        {
            get { return tipoCombustible; }
            set { tipoCombustible = value; }

        }

    }
}
