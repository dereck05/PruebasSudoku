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
        Ubicacion[] ListaUbicacion { get; set; }



        public Figura(int numeroMeta, char operacionFigura, Ubicacion[] listaUbicaciones)
        {
            NumMeta = numeroMeta;
            Operacion = operacionFigura;
            ListaUbicacion = listaUbicaciones;
        }
    }
}
