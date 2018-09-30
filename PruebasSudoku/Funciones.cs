using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasSudoku
{
    public class Funciones
    {
        

        int N { set; get; } //este es el tam del tablero 
        int[,] EspacioSoluciones { get; set; }
        int[,] Tablero { get; set; }
        int NumFigura { get; set; }
        int[,] FigurasArray { get; set; }
        Figura[] ListaFiguras { get; set; }

        public Funciones(int Num)
        {
            N = Num;
            ListaFiguras = new Figura[N*N];
            Tablero = new int[N, N];
            EspacioSoluciones = new int[N, N];
            NumFigura = 1;
            FigurasArray = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    FigurasArray[i, j] = 0;
                }
            }

        }

        public bool LlenoFiguras(int[,] lista)
        {
            bool Flag = true;
            int i = 0;
            int j = 0;
            while((i < lista.Length) && (Flag = true))
            {
                while((j < lista.Length) && (Flag = true))
                {
                    if (lista[i, j] == 0)
                    {
                        Flag = false;
                        j++;
                    }
                    else
                        j++;

                }
                i++;
            }
            if (Flag == true)
                return true;
            else
                return false;

        }

        public bool ComprobarEspacio(int[,] matrizFiguras,string figura,int orientacion, int pivoteX,int pivoteY)  //pivote es par de donde empieza la figura
        {                                                                                                           
            
            int ubi1 = 0;
            int ubi2 = 0;
            int ubi3 = 0;
            int ubi4 = 0;


            if (figura == "cuadrado") {
                if (pivoteY + 1 < N && pivoteX + 1 < N)      //Que no se salga de los limites
                {
                    ubi1 = matrizFiguras[pivoteX, pivoteY];
                    ubi2 = matrizFiguras[pivoteX, pivoteY + 1];
                    ubi3 = matrizFiguras[pivoteX + 1, pivoteY];
                    ubi4 = matrizFiguras[pivoteX + 1, pivoteY + 1];

                    if ((ubi1 == 0) && (ubi2 == 0) && (ubi3 == 0) && (ubi4 == 0))   //Que no haya casillas ocupadas
                    {
                        FigurasArray[pivoteX, pivoteY] = NumFigura;
                        FigurasArray[pivoteX, pivoteY+1] = NumFigura;
                        FigurasArray[pivoteX+1, pivoteY] = NumFigura;
                        FigurasArray[pivoteX+1, pivoteY+1] = NumFigura;
                        NumFigura++;
                        return true;
                    }
                    else
                        return false;

                }
                else
                    return false;
            }
            if (figura == "ele")
            {
                if (orientacion == 1 || orientacion == 2 || orientacion == 3 || orientacion == 4)
                {

                    if (orientacion == 1)
                    {
                        if (pivoteX + 2 < N && pivoteY + 1 < N)
                        {
                            ubi1 = matrizFiguras[pivoteX, pivoteY];
                            ubi2 = matrizFiguras[pivoteX + 1, pivoteY];
                            ubi3 = matrizFiguras[pivoteX + 2, pivoteY];
                            ubi4 = matrizFiguras[pivoteX + 2, pivoteY + 1];

                            if ((ubi1 == 0) && (ubi2 == 0) && (ubi3 == 0) && (ubi4 == 0))   //Que no haya casillas ocupadas
                            {
                                FigurasArray[pivoteX, pivoteY] = NumFigura;
                                FigurasArray[pivoteX + 1, pivoteY] = NumFigura;
                                FigurasArray[pivoteX + 2, pivoteY] = NumFigura;
                                FigurasArray[pivoteX + 2, pivoteY + 1] = NumFigura;
                                NumFigura++;
                                return true;
                            }
                            else
                                return false;
                        }
                        else
                            return false;
                    }
                    if (orientacion == 2)
                    {
                        if (pivoteX + 2 < N && pivoteY - 1 > 0)
                        {
                            ubi1 = matrizFiguras[pivoteX, pivoteY];
                            ubi2 = matrizFiguras[pivoteX + 1, pivoteY];
                            ubi3 = matrizFiguras[pivoteX + 2, pivoteY];
                            ubi4 = matrizFiguras[pivoteX + 2, pivoteY - 1];

                            if ((ubi1 == 0) && (ubi2 == 0) && (ubi3 == 0) && (ubi4 == 0))   //Que no haya casillas ocupadas
                            {
                                FigurasArray[pivoteX, pivoteY] = NumFigura;
                                FigurasArray[pivoteX + 1, pivoteY] = NumFigura;
                                FigurasArray[pivoteX + 2, pivoteY] = NumFigura;
                                FigurasArray[pivoteX + 2, pivoteY - 1] = NumFigura;
                                NumFigura++;
                                return true;
                            }
                            else
                                return false;
                        }
                        else
                            return false;
                    }
                    if (orientacion == 3 || orientacion == 4)       //ver si en realidad mata dos pajaros de un tiro
                    {
                        if (pivoteX + 2 < N && pivoteY + 1 < N)
                        {
                            if (orientacion == 3)
                            {
                                ubi1 = matrizFiguras[pivoteX, pivoteY];
                                ubi2 = matrizFiguras[pivoteX, pivoteY + 1];
                                ubi3 = matrizFiguras[pivoteX + 1, pivoteY + 1];
                                ubi4 = matrizFiguras[pivoteX + 2, pivoteY + 1];

                                if ((ubi1 == 0) && (ubi2 == 0) && (ubi3 == 0) && (ubi4 == 0))   //Que no haya casillas ocupadas
                                {
                                    FigurasArray[pivoteX, pivoteY] = NumFigura;
                                    FigurasArray[pivoteX, pivoteY + 1] = NumFigura;
                                    FigurasArray[pivoteX + 1, pivoteY + 1] = NumFigura;
                                    FigurasArray[pivoteX + 2, pivoteY + 1] = NumFigura;
                                    NumFigura++;
                                    return true;
                                }
                                else
                                    return false;
                            }
                            if (orientacion == 4)
                            {
                                ubi1 = matrizFiguras[pivoteX, pivoteY];
                                ubi2 = matrizFiguras[pivoteX, pivoteY + 1];
                                ubi3 = matrizFiguras[pivoteX + 1, pivoteY];
                                ubi4 = matrizFiguras[pivoteX + 2, pivoteY];

                                if ((ubi1 == 0) && (ubi2 == 0) && (ubi3 == 0) && (ubi4 == 0))   //Que no haya casillas ocupadas
                                {
                                    FigurasArray[pivoteX, pivoteY] = NumFigura;
                                    FigurasArray[pivoteX, pivoteY + 1] = NumFigura;
                                    FigurasArray[pivoteX + 1, pivoteY] = NumFigura;
                                    FigurasArray[pivoteX + 2, pivoteY] = NumFigura;
                                    NumFigura++;
                                    return true;
                                }
                                else
                                    return false;
                            }

                        }
                        else
                            return false;
                    }
                }
                else
                    return false;

            }
            if(figura == "linea")
            {
                if(orientacion == 1) //vertical
                {
                    if (pivoteX + 3 < N)
                    {
                        ubi1 = matrizFiguras[pivoteX, pivoteY];
                        ubi2 = matrizFiguras[pivoteX + 1, pivoteY];
                        ubi3 = matrizFiguras[pivoteX + 2, pivoteY];
                        ubi4 = matrizFiguras[pivoteX + 3, pivoteY];

                        if ((ubi1 == 0) && (ubi2 == 0) && (ubi3 == 0) && (ubi4 == 0))   //Que no haya casillas ocupadas
                        {
                            FigurasArray[pivoteX, pivoteY] = NumFigura;
                            FigurasArray[pivoteX + 1, pivoteY] = NumFigura;
                            FigurasArray[pivoteX + 2, pivoteY] = NumFigura;
                            FigurasArray[pivoteX + 3, pivoteY] = NumFigura;
                            NumFigura++;
                            return true;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
                if(orientacion == 2)  //horizontal
                {
                    if (pivoteY + 3 < N)
                    {
                        ubi1 = matrizFiguras[pivoteX, pivoteY];
                        ubi2 = matrizFiguras[pivoteX , pivoteY+1];
                        ubi3 = matrizFiguras[pivoteX , pivoteY+2];
                        ubi4 = matrizFiguras[pivoteX , pivoteY+3];

                        if ((ubi1 == 0) && (ubi2 == 0) && (ubi3 == 0) && (ubi4 == 0))   //Que no haya casillas ocupadas
                        {
                            FigurasArray[pivoteX, pivoteY] = NumFigura;
                            FigurasArray[pivoteX, pivoteY + 1] = NumFigura;
                            FigurasArray[pivoteX, pivoteY + 2] = NumFigura;
                            FigurasArray[pivoteX, pivoteY + 3] = NumFigura;
                            NumFigura++;
                            return true;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
            }
            if(figura == "te")
            {
                if(orientacion == 1)
                {
                    if (pivoteY - 1 >= 0 && pivoteY < N - 1)
                    {
                        ubi1 = matrizFiguras[pivoteX, pivoteY];
                        ubi2 = matrizFiguras[pivoteX +1, pivoteY ];
                        ubi3 = matrizFiguras[pivoteX + 1, pivoteY - 1];
                        ubi4 = matrizFiguras[pivoteX+1, pivoteY +1];

                        if ((ubi1 == 0) && (ubi2 == 0) && (ubi3 == 0) && (ubi4 == 0))   //Que no haya casillas ocupadas
                        {
                            FigurasArray[pivoteX, pivoteY] = NumFigura;
                            FigurasArray[pivoteX + 1, pivoteY] = NumFigura;
                            FigurasArray[pivoteX + 1, pivoteY - 1] = NumFigura;
                            FigurasArray[pivoteX + 1, pivoteY + 1] = NumFigura;
                            NumFigura++;
                            return true;
                        }
                        else
                            return false;
                    }
                }
                if (orientacion == 2)
                {
                    if (pivoteY + 2 < N && pivoteX + 1 < N)
                    {
                        ubi1 = matrizFiguras[pivoteX, pivoteY];
                        ubi2 = matrizFiguras[pivoteX, pivoteY + 1];
                        ubi3 = matrizFiguras[pivoteX, pivoteY + 2];
                        ubi4 = matrizFiguras[pivoteX + 1, pivoteY + 1];

                        if ((ubi1 == 0) && (ubi2 == 0) && (ubi3 == 0) && (ubi4 == 0))   //Que no haya casillas ocupadas
                        {
                            FigurasArray[pivoteX, pivoteY] = NumFigura;
                            FigurasArray[pivoteX, pivoteY + 1] = NumFigura;
                            FigurasArray[pivoteX, pivoteY + 2] = NumFigura;
                            FigurasArray[pivoteX + 1, pivoteY + 1] = NumFigura;
                            NumFigura++;
                            return true;
                        }
                        else
                            return false;
                    }
                }
                else
                    return false;
            }
            if (figura == "snake")      //la figura que parece una serpiente
            {
                if(orientacion == 1)  //horizontal
                {
                    if(pivoteX-1 >= 0 && pivoteY+2 < N)
                    {
                        ubi1 = matrizFiguras[pivoteX, pivoteY];
                        ubi2 = matrizFiguras[pivoteX, pivoteY + 1];
                        ubi3 = matrizFiguras[pivoteX-1, pivoteY + 1];
                        ubi4 = matrizFiguras[pivoteX - 1, pivoteY + 2];

                        if ((ubi1 == 0) && (ubi2 == 0) && (ubi3 == 0) && (ubi4 == 0))   //Que no haya casillas ocupadas
                        {
                            FigurasArray[pivoteX, pivoteY] = NumFigura;
                            FigurasArray[pivoteX, pivoteY + 1] = NumFigura;
                            FigurasArray[pivoteX - 1, pivoteY + 1] = NumFigura;
                            FigurasArray[pivoteX - 1, pivoteY + 2] = NumFigura;
                            NumFigura++;
                            return true;
                        }
                        else
                            return false;
                    }
                }
                if (orientacion == 2)  //vertical
                {
                    if (pivoteY - 1 >= 0 && pivoteX + 2 < N)
                    {
                        ubi1 = matrizFiguras[pivoteX, pivoteY];
                        ubi2 = matrizFiguras[pivoteX+1, pivoteY ];
                        ubi3 = matrizFiguras[pivoteX + 1, pivoteY - 1];
                        ubi4 = matrizFiguras[pivoteX + 2, pivoteY - 1];

                        if ((ubi1 == 0) && (ubi2 == 0) && (ubi3 == 0) && (ubi4 == 0))   //Que no haya casillas ocupadas
                        {
                            FigurasArray[pivoteX, pivoteY] = NumFigura;
                            FigurasArray[pivoteX + 1, pivoteY] = NumFigura;
                            FigurasArray[pivoteX + 1, pivoteY - 1] = NumFigura;
                            FigurasArray[pivoteX + 2, pivoteY - 1] = NumFigura;
                            NumFigura++;
                            return true;
                        }
                        else
                            return false;
                    }
                }

            }
            if(figura == "solo")
            {
                ubi1 = matrizFiguras[pivoteX, pivoteY];
                if (ubi1 == 0)
                {
                    FigurasArray[pivoteX, pivoteY] = NumFigura;
                    NumFigura++;
                    return true;
                }
                else
                    return false;
            }
            if (figura == "dos")
            {
                if (orientacion == 1)   //vertical
                {
                    if (pivoteX + 1 < N)
                    {
                        ubi1 = matrizFiguras[pivoteX, pivoteY];
                        ubi2 = matrizFiguras[pivoteX + 1, pivoteY];

                        if (ubi1 == 0 && ubi2 == 0)
                        {
                            FigurasArray[pivoteX, pivoteY] = NumFigura;
                            FigurasArray[pivoteX + 1, pivoteY] = NumFigura;
                            NumFigura++;
                            return true;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
                if (orientacion == 2)   //horizontal
                {
                    if (pivoteY + 1 < N)
                    {
                        ubi1 = matrizFiguras[pivoteX, pivoteY];
                        ubi2 = matrizFiguras[pivoteX , pivoteY+1];

                        if (ubi1 == 0 && ubi2 == 0)
                        {
                            FigurasArray[pivoteX, pivoteY] = NumFigura;
                            FigurasArray[pivoteX , pivoteY+1] = NumFigura;
                            NumFigura++;
                            return true;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
            }


            return false;
        }
    
        public void Print()
        {
            string S = "";
            for(int i = 0; i < N; i++)
            {
                Console.WriteLine(S);
                S = "";
                for(int j = 0; j < N; j++)
                {
                    string myStr = FigurasArray[i, j].ToString();
                    S += myStr + "    ";
                }
            }
        }

        public void GenerarFiguras()
        {
            Random rnd = new Random();
            string[] TipoFigura = new string[7] { "cuadrado", "linea" ,"snake","solo","ele","te","dos"};
            int[,] ArrayFiguras = new int[N, N];
            int ori = 0;
            for(int i = 0; i < N; i++)
            {
                for(int j = 0; j < N; j++)
                {
                    if (FigurasArray[i, j] == 0)
                    {
                        int fig = rnd.Next(0, 5);
                        if (fig == 4 || fig == 5)
                            ori = rnd.Next(1, 4);
                        else
                            ori = rnd.Next(1, 2);

                        while (ComprobarEspacio(FigurasArray, TipoFigura[fig], ori, i, j) != true)
                        {
                            fig = rnd.Next(0, 5);
                            if (fig == 4 || fig == 5)
                                ori = rnd.Next(1, 4);
                            else
                                ori = rnd.Next(1, 2);
                        }
                        Print();
                    }

                    
                }
            }

           
        }

    }
}
