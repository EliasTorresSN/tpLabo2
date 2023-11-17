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

            Segmento sedan = new Segmento(1, "Sedan");
            Segmento coupe = new Segmento(2, "Coupe");
            Segmento suv= new Segmento(3, "SUV");
            Segmento pickup = new Segmento(4, "Pick Up");
            Segmento enduro= new Segmento(5, "Enduro");
            Segmento rutera= new Segmento(6, "Rutera");
            Segmento scooter=new Segmento(7, "Scooter");
            Segmento camion = new Segmento(8, "Camión");

            segmentos.Add(sedan);
            segmentos.Add(coupe);   
            segmentos.Add(suv);
            segmentos.Add(pickup);
            segmentos.Add(enduro);
            segmentos.Add(rutera);
            segmentos.Add(scooter);
            segmentos.Add(camion);

            return segmentos;
        }







    }
}
