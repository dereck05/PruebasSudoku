using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasSudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 6;
            int[,] ArrayFiguras = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    ArrayFiguras[i, j] = 0;
                }
            }
            Funciones f = new Funciones(N);
            f.GenerarFiguras();
            Console.ReadKey();      //para que no se cierre la ventana
        }
    }
}
