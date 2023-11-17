using FinalLaboratorioII.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalLaboratorioII.servicios
{
    internal class ServicioCombustible
    {
        public ServicioCombustible() { }


        public List<Combustible> crearListaCombustible()
        {
            List<Combustible>combustibles = new List<Combustible>();
            Combustible nafta= new Combustible(1, "Nafta");
            Combustible diesel = new Combustible(2, "Diesel");
            Combustible gnc = new Combustible(3, "GNC");
            Combustible electrico = new Combustible(4,"Eléctrico");

            combustibles.Add(nafta);
            combustibles.Add(diesel);
            combustibles.Add(gnc);
            combustibles.Add(electrico);
            return combustibles;
        }


    }
}
