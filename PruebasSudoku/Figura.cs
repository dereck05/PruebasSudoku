using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasSudoku
{
    public class Figura
    {
        int NumMeta { get; set; }
        char Operacion { get; set; }
        string Tipo { set; get; }
        Ubicacion[] ListaUbicacion { get; set; }



        public Figura(/*int numeroMeta,*/ Ubicacion[] listaUbicaciones,string type)
        {
            //NumMeta = numeroMeta;
            //Operacion = operacionFigura;
            Tipo = type;
            ListaUbicacion = listaUbicaciones;
        }

        public String GetTipo()
        {
            return Tipo;
        }
        public Ubicacion[] GetLista()
        {
            return ListaUbicacion;
        }
    }

}
