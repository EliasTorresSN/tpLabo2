using System;
namespace FinalLaboratorioII.entidades
{
    internal class Localidad
    {
        private int id_localidad { get; set; }
        private int id_provincia {  get; set; }
        private string localidad {  get; set; }

        public Localidad()
        {

        }

        public Localidad(int id_localidad, int id_provincia, string localidad)
        {
            this.id_localidad = id_localidad;
            this.id_provincia = id_provincia;
            this.localidad = localidad ?? throw new ArgumentNullException(nameof(localidad));
        }
    }
}
