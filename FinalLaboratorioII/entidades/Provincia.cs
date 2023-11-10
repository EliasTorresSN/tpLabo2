using System;

namespace FinalLaboratorioII.entidades
{
    internal class Provincia
    {
        private int id_provincia;
        private string nombreProvincia { get; set; }

        public Provincia()
        {

        }
       
        public Provincia(int id_provincia, string nombreProvincia)
        {
            this.id_provincia = id_provincia;
            this.nombreProvincia = nombreProvincia ?? throw new ArgumentNullException(nameof(nombreProvincia));
        }
        public int Id_provincia
        {
            get { return id_provincia; }set { id_provincia = value; }
        }
        public string NombreProvincia
        {
            get { return nombreProvincia; }
            set { nombreProvincia = value; }
        }



    }
}


