using System;
namespace FinalLaboratorioII.entidades
{
    internal class Localidad
    {
        private int id_localidad { get; set; }
        private int id_provincia {  get; set; }
        private string nombreLocalidad {  get; set; }

        public Localidad()
        {

        }

        public Localidad(int id_localidad, int id_provincia, string localidad)
        {
            this.id_localidad = id_localidad;
            this.id_provincia = id_provincia;
            this.nombreLocalidad = localidad ?? throw new ArgumentNullException(nameof(localidad));
        }


        public int Id_localidad
        {
            get { return id_localidad;}set { id_localidad = value; }
        }

        public int Id_provincia
        {
            get { return id_provincia;} set { id_provincia = value;}
        }

        public string NombreLocalidad
        {
            get { return nombreLocalidad; }set { nombreLocalidad = value; }
        }

        public override string ToString()
        {
            return $"ID_LOCALIDAD: {this.Id_localidad} ID_PROVINCIA: {this.Id_provincia} LOCALIDAD: {this.NombreLocalidad}";
        }


    }
}
