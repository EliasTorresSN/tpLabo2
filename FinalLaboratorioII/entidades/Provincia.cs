using System;

namespace FinalLaboratorioII.entidades
{
    internal class Provincia
    {
        private int id_provincia { get; set; }
        private string provincia { get; set; }

        public Provincia()
        {

        }

        public Provincia(int id_provincia, string provincia)
        {
            this.id_provincia = id_provincia;
            this.provincia = provincia ?? throw new ArgumentNullException(nameof(provincia));
        }
    }
}


