using System;

namespace FinalLaboratorioII.entidades
{
    internal class Segmento
    {
        private int id_segmento {  get; set; }
        private string segmento {  get; set; }

        public Segmento()
        {

        }

        public Segmento(int id_segmento, string segmento)
        {
            this.id_segmento = id_segmento;
            this.segmento = segmento ?? throw new ArgumentNullException(nameof(segmento));
        }
    }
}
