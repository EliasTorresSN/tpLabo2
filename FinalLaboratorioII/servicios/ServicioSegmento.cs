using FinalLaboratorioII.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalLaboratorioII.servicios
{
    internal class ServicioSegmento
    {
        public ServicioSegmento() { }



        public List<Segmento> listaSegmentos()
        {
            List<Segmento>segmentos = new List<Segmento>();

            segmentos.Add(new Segmento(1,"Sedan"));
            segmentos.Add(new Segmento(2, "Coupe"));
            segmentos.Add(new Segmento(3, "SUV"));
            segmentos.Add(new Segmento(4, "Pick Up"));
            segmentos.Add(new Segmento(5, "Enduro"));
            segmentos.Add(new Segmento(6, "Rutera"));
            segmentos.Add(new Segmento(7, "Scooter"));
            segmentos.Add(new Segmento(8, "Camión"));

            return segmentos;
        }







    }
}
