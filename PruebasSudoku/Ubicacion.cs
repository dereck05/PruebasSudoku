using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasSudoku
{
    public class Ubicacion
    {
        int ValX { set; get; }
        int ValY { set; get; }



        public Ubicacion(int x, int y)
        {
            ValX = x;
            ValY = y;
        }

    }
}
