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
            combustibles.Add(new Combustible(1,"Nafta"));
            combustibles.Add(new Combustible(2,"Diesel"));
            combustibles.Add(new Combustible(3,"GNC"));
            combustibles.Add(new Combustible(4,"Eléctrico"));
            return combustibles;
        }




    }
}
