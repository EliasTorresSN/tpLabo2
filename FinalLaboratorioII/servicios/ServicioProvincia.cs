using FinalLaboratorioII.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalLaboratorioII.servicios
{
    internal class ServicioProvincia
    {

        public ServicioProvincia(){}

        public List<Provincia> crearListaProvincias()
        {
            List<Provincia> provincias = new List<Provincia> ();
            Provincia SinDef = new Provincia(0, "Sin definir");
            Provincia BsAs = new Provincia(1,"Buenos Aires");
            Provincia Catamarca = new Provincia(2,"Catamarca");
            Provincia CABA = new Provincia(3,"Ciudad Autónoma de Buenos Aires");
            Provincia Chaco = new Provincia(4, "Chaco");
            Provincia Chubut = new Provincia(5,"Chubut");
            Provincia Cordoba = new Provincia(6,"Córdoba");
            Provincia Corrientes = new Provincia(7,"Corrientes");
            Provincia Entre_Rios = new Provincia(8,"Entre Ríos");
            Provincia Formosa= new Provincia(9,"Formosa");
            Provincia Jujuy= new Provincia(10,"Jujuy");
            Provincia La_Pampa= new Provincia(11,"La Pampa");
            Provincia La_Rioja= new Provincia(12,"La Rioja");
            Provincia Mendoza= new Provincia(13,"Mendoza");
            Provincia Misiones= new Provincia(14,"Misiones");
            Provincia Neuquen= new Provincia(15,"Neuquén");
            Provincia Rio_negro= new Provincia(16,"Río Negro");
            Provincia Salta= new Provincia(17,"Salta");
            Provincia San_Juan= new Provincia(18,"San Juan");
            Provincia San_Luis= new Provincia(19,"San Luis");
            Provincia Santa_Cruz= new Provincia(20,"Santa Cruz");
            Provincia Santa_Fe= new Provincia(21,"Santa Fe");
            Provincia Santiago_Del_Estero= new Provincia(22,"Santiago Del Estero");
            Provincia Tierra_Del_Fuego= new Provincia(23,"Tierra Del Fuego");
            Provincia Tucuman= new Provincia(24,"Tucumán");

            provincias.Add(SinDef);
            provincias.Add(BsAs);
            provincias.Add(Catamarca);
            provincias.Add(CABA);
            provincias.Add(Chaco);
            provincias.Add(Chubut);
            provincias.Add(Cordoba);
            provincias.Add(Corrientes);
            provincias.Add(Entre_Rios);
            provincias.Add(Formosa);
            provincias.Add(Jujuy);
            provincias.Add(La_Pampa);
            provincias.Add(La_Rioja);
            provincias.Add(Mendoza);
            provincias.Add(Misiones);
            provincias.Add(Neuquen);
            provincias.Add(Rio_negro);
            provincias.Add(Salta);
            provincias.Add(San_Juan);
            provincias.Add(San_Luis);
            provincias.Add(Santa_Cruz);
            provincias.Add(Santa_Fe);
            provincias.Add(Santiago_Del_Estero);
            provincias.Add(Tierra_Del_Fuego);
            provincias.Add(Tucuman);

            return provincias;
        }


    }
}
