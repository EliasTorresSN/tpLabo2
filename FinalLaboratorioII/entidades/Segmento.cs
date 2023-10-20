using System;

namespace FinalLaboratorioII.entidades
{
    internal class Segmento
    {
        private int id_segmento {  get; set; }
        private string tipoSegmento {  get; set; }
        public Segmento(){}
        public Segmento(int id_segmento, string segmento)
        {
            this.id_segmento = id_segmento;
            this.tipoSegmento = segmento ?? throw new ArgumentNullException(nameof(segmento));
        }
        public int Id_segmento
        {
            get { return id_segmento; } set { id_segmento = value; }
        }
        public string TipoSegmento
        {
            get { return tipoSegmento; } set { tipoSegmento = value; }
        }

    }
}
