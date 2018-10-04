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
            int N = 18;
            int[,] ArrayFiguras = new int[N, N];

            TimeSpan stop;
            TimeSpan start = new TimeSpan(DateTime.Now.Ticks);


            Funciones f = new Funciones(N);
            
            f.GenerarFiguras();
            f.ImprimirTableroFiguras();
            //f.ImprimirFiguras();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            
            


            
            int[,] sudoku = f.GenerarSudoku();
            f.Print(sudoku);
            Console.WriteLine("  ");
            Console.WriteLine("------------------------------------------------------------------------------------------");
            if (true == f.Resolver(sudoku))
                f.Print(sudoku);
            else
                Console.WriteLine("Fail");

            stop = new TimeSpan(DateTime.Now.Ticks);
            Console.WriteLine();
            Console.WriteLine(stop.Subtract(start).TotalMilliseconds);

            
            Console.ReadKey();      //para que no se cierre la ventana
        }
    }
}
