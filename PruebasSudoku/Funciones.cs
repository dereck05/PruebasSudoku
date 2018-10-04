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

            

        }

        public Ubicacion NextEmpty(int[,] tab)
        {
            Ubicacion ubi;
            for(int i = 0; i < N; i++)
            {
                for(int j = 0; j < N; j++)
                {
                    if(tab[i,j] == 0)
                    {
                        ubi = new Ubicacion(i, j);
                        return ubi;
                    }
                }
            }
            ubi = new Ubicacion(-1, -1);
            return ubi;

        }

        public char GenerarOperacion()
        {
            Random rnd = new Random();
            int aleatorio = rnd.Next(0,2);
            if (aleatorio == 0)
                return '+';
            else
                return 'x';

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

                        Ubicacion u1 = new Ubicacion(pivoteX, pivoteY);
                        Ubicacion u2 = new Ubicacion(pivoteX, pivoteY + 1);
                        Ubicacion u3 = new Ubicacion(pivoteX + 1, pivoteY);
                        Ubicacion u4 = new Ubicacion(pivoteX + 1, pivoteY + 1);
                        Ubicacion[] list = new Ubicacion[4];
                        list[0] = u1;
                        list[1] = u2;
                        list[2] = u3;
                        list[3] = u4;
                        Figura fig = new Figura(list, "cuadrado");
                        
                        SetListaFiguras(fig);

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

                                Ubicacion u1 = new Ubicacion(pivoteX, pivoteY);
                                Ubicacion u2 = new Ubicacion(pivoteX + 1, pivoteY );
                                Ubicacion u3 = new Ubicacion(pivoteX + 2, pivoteY);
                                Ubicacion u4 = new Ubicacion(pivoteX + 2, pivoteY + 1);
                                Ubicacion[] list = new Ubicacion[4];
                                list[0] = u1;
                                list[1] = u2;
                                list[2] = u3;
                                list[3] = u4;
                                Figura fig = new Figura(list, "ele");
                                
                                SetListaFiguras(fig);

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

                                Ubicacion u1 = new Ubicacion(pivoteX, pivoteY);
                                Ubicacion u2 = new Ubicacion(pivoteX + 1, pivoteY );
                                Ubicacion u3 = new Ubicacion(pivoteX + 2, pivoteY);
                                Ubicacion u4 = new Ubicacion(pivoteX + 2, pivoteY - 1);
                                Ubicacion[] list = new Ubicacion[4];
                                list[0] = u1;
                                list[1] = u2;
                                list[2] = u3;
                                list[3] = u4;
                                Figura fig = new Figura(list, "ele");
                                
                                SetListaFiguras(fig);

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

                                    Ubicacion u1 = new Ubicacion(pivoteX, pivoteY);
                                    Ubicacion u2 = new Ubicacion(pivoteX, pivoteY + 1);
                                    Ubicacion u3 = new Ubicacion(pivoteX + 1, pivoteY + 1);
                                    Ubicacion u4 = new Ubicacion(pivoteX + 2, pivoteY + 1);
                                    Ubicacion[] list = new Ubicacion[4];
                                    list[0] = u1;
                                    list[1] = u2;
                                    list[2] = u3;
                                    list[3] = u4;
                                    Figura fig = new Figura(list, "ele");
                                    
                                    SetListaFiguras(fig);

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

                                    Ubicacion u1 = new Ubicacion(pivoteX, pivoteY);
                                    Ubicacion u2 = new Ubicacion(pivoteX, pivoteY + 1);
                                    Ubicacion u3 = new Ubicacion(pivoteX + 1, pivoteY );
                                    Ubicacion u4 = new Ubicacion(pivoteX + 2, pivoteY );
                                    Ubicacion[] list = new Ubicacion[4];
                                    list[0] = u1;
                                    list[1] = u2;
                                    list[2] = u3;
                                    list[3] = u4;
                                    Figura fig = new Figura(list, "ele");
                                   
                                    SetListaFiguras(fig);

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

                            Ubicacion u1 = new Ubicacion(pivoteX , pivoteY);
                            Ubicacion u2 = new Ubicacion(pivoteX + 1, pivoteY );
                            Ubicacion u3 = new Ubicacion(pivoteX + 2, pivoteY );
                            Ubicacion u4 = new Ubicacion(pivoteX + 3, pivoteY);
                            Ubicacion[] list = new Ubicacion[4];
                            list[0] = u1;
                            list[1] = u2;
                            list[2] = u3;
                            list[3] = u4;
                            Figura fig = new Figura(list, "linea");
                            
                            SetListaFiguras(fig);

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

                            Ubicacion u1 = new Ubicacion(pivoteX, pivoteY);
                            Ubicacion u2 = new Ubicacion(pivoteX, pivoteY + 1);
                            Ubicacion u3 = new Ubicacion(pivoteX, pivoteY + 2);
                            Ubicacion u4 = new Ubicacion(pivoteX , pivoteY + 3);
                            Ubicacion[] list = new Ubicacion[4];
                            list[0] = u1;
                            list[1] = u2;
                            list[2] = u3;
                            list[3] = u4;
                            Figura fig = new Figura(list, "linea");
                            
                            SetListaFiguras(fig);

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
                    if (pivoteY - 1 >= 0 && pivoteY+1 < N && pivoteX +1 < N)
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

                            Ubicacion u1 = new Ubicacion(pivoteX, pivoteY);
                            Ubicacion u2 = new Ubicacion(pivoteX+1, pivoteY );
                            Ubicacion u3 = new Ubicacion(pivoteX+1, pivoteY - 1);
                            Ubicacion u4 = new Ubicacion(pivoteX + 1, pivoteY + 1);
                            Ubicacion[] list = new Ubicacion[4];
                            list[0] = u1;
                            list[1] = u2;
                            list[2] = u3;
                            list[3] = u4;
                            Figura fig = new Figura(list, "te");
                            
                            SetListaFiguras(fig);
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

                            Ubicacion u1 = new Ubicacion(pivoteX, pivoteY);
                            Ubicacion u2 = new Ubicacion(pivoteX , pivoteY+1);
                            Ubicacion u3 = new Ubicacion(pivoteX , pivoteY + 2);
                            Ubicacion u4 = new Ubicacion(pivoteX + 1, pivoteY + 1);
                            Ubicacion[] list = new Ubicacion[4];
                            list[0] = u1;
                            list[1] = u2;
                            list[2] = u3;
                            list[3] = u4;
                            Figura fig = new Figura(list, "te");
                            SetListaFiguras(fig);
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
                    if(pivoteY - 1 >= 0 && pivoteY + 1 < N && pivoteX + 1 < N)
                    {
                        ubi1 = matrizFiguras[pivoteX, pivoteY];
                        ubi2 = matrizFiguras[pivoteX+1, pivoteY ];
                        ubi3 = matrizFiguras[pivoteX+1, pivoteY - 1];
                        ubi4 = matrizFiguras[pivoteX , pivoteY + 1];

                        if ((ubi1 == 0) && (ubi2 == 0) && (ubi3 == 0) && (ubi4 == 0))   //Que no haya casillas ocupadas
                        {
                            FigurasArray[pivoteX, pivoteY] = NumFigura;
                            FigurasArray[pivoteX + 1, pivoteY] = NumFigura;
                            FigurasArray[pivoteX + 1, pivoteY - 1] = NumFigura;
                            FigurasArray[pivoteX, pivoteY + 1] = NumFigura;

                            Ubicacion u1 = new Ubicacion(pivoteX, pivoteY);
                            Ubicacion u2 = new Ubicacion(pivoteX + 1, pivoteY);
                            Ubicacion u3 = new Ubicacion(pivoteX + 1, pivoteY - 1);
                            Ubicacion u4 = new Ubicacion(pivoteX , pivoteY + 1);
                            Ubicacion[] list = new Ubicacion[4];
                            list[0] = u1;
                            list[1] = u2;
                            list[2] = u3;
                            list[3] = u4;
                            Figura fig = new Figura(list, "snake");
                            int index = ListaFiguras.Length;
                            SetListaFiguras(fig);

                            NumFigura++;
                            return true;
                        }
                        else
                            return false;
                    }
                }
                if (orientacion == 2)  //vertical
                {
                    if (pivoteY + 1 < N && pivoteX + 2 < N)
                    {
                        ubi1 = matrizFiguras[pivoteX, pivoteY];
                        ubi2 = matrizFiguras[pivoteX+1, pivoteY ];
                        ubi3 = matrizFiguras[pivoteX + 1, pivoteY + 1];
                        ubi4 = matrizFiguras[pivoteX + 2, pivoteY + 1];

                        if ((ubi1 == 0) && (ubi2 == 0) && (ubi3 == 0) && (ubi4 == 0))   //Que no haya casillas ocupadas
                        {
                            FigurasArray[pivoteX, pivoteY] = NumFigura;
                            FigurasArray[pivoteX + 1, pivoteY] = NumFigura;
                            FigurasArray[pivoteX + 1, pivoteY + 1] = NumFigura;
                            FigurasArray[pivoteX + 2, pivoteY + 1] = NumFigura;

                            Ubicacion u1 = new Ubicacion(pivoteX, pivoteY);
                            Ubicacion u2 = new Ubicacion(pivoteX + 1, pivoteY);
                            Ubicacion u3 = new Ubicacion(pivoteX+1, pivoteY+1);
                            Ubicacion u4 = new Ubicacion(pivoteX + 2, pivoteY+1);
                            Ubicacion[] list = new Ubicacion[4];
                            list[0] = u1;
                            list[1] = u2;
                            list[2] = u3;
                            list[3] = u4;
                            Figura fig = new Figura(list, "snake");
                            int index = ListaFiguras.Length;
                            SetListaFiguras(fig);

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
                    Ubicacion u1 = new Ubicacion(pivoteX, pivoteY);
                    
                    Ubicacion[] list = new Ubicacion[1];
                    list[0] = u1;
                   
                    Figura fig = new Figura(list, "solo");
                    int index = ListaFiguras.Length;
                    SetListaFiguras(fig);
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
                            Ubicacion u1 = new Ubicacion(pivoteX, pivoteY);
                            Ubicacion u2 = new Ubicacion(pivoteX+1, pivoteY);
                            Ubicacion[] list = new Ubicacion[2];
                            list[0] = u1;
                            list[1] = u2;
                            Figura fig = new Figura(list,"dos");
                            int index = ListaFiguras.Length;
                            SetListaFiguras(fig);
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
                            Ubicacion u1 = new Ubicacion(pivoteX, pivoteY);
                            Ubicacion u2 = new Ubicacion(pivoteX, pivoteY+1);
                            Ubicacion[] list = new Ubicacion[2];
                            list[0] = u1;
                            list[1] = u2;
                            Figura fig = new Figura(list,"dos");
                            int index = ListaFiguras.Length;
                            SetListaFiguras(fig);
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
    
        public void ImprimirTableroFiguras()   //Este imprime el backtracking
        {
            string S = "";
            for(int i = 0; i < N; i++)
            {
                
                S = "";
                for(int j = 0; j < N; j++)
                {
                    string myStr = FigurasArray[i, j].ToString();
                    S += myStr + "       ";
                }
                Console.WriteLine(S);
            }
        }

        public void Print(int[,] arr)   //Funcion que imprime un array X
        {
            string S = "";
            for (int i = 0; i < N; i++)
            {

                S = "";
                for (int j = 0; j < N; j++)
                {
                    string myStr = arr[i, j].ToString();
                    S += myStr + "       ";
                }
                Console.WriteLine(S);
            }
        }

        public void GenerarFiguras()
        {
            Random rnd = new Random();
            string[] TipoFigura = new string[7] { "ele", "cuadrado", "linea" ,"snake","solo","te","dos"};
            
            int ori = 0;
            for(int i = 0; i < N; i++)
            {
                for(int j = 0; j < N; j++)
                {
                    if (FigurasArray[i, j] == 0)
                    {
                        int fig = rnd.Next(0, 7);
                        if (fig == 0)
                            ori = rnd.Next(1, 5);
                        else
                            ori = rnd.Next(1, 3);

                        while (ComprobarEspacio(FigurasArray, TipoFigura[fig], ori, i, j) != true)
                        {
                            fig = rnd.Next(0, 7);
                            if (fig == 0)
                                ori = rnd.Next(1, 5);
                            else
                                ori = rnd.Next(1, 3);
                        }
                        //Print();
                        Console.WriteLine(" ");
                    }

                    
                }
            }

           
        }

        public void ImprimirFiguras()
        {
            int cont = 0;
            
            while(ListaFiguras[cont] != null)
            {
                Figura f = ListaFiguras[cont];
                string tipoFigura = f.GetTipo();
                Ubicacion[] ubicaciones = f.GetLista();
                Console.WriteLine("Figura:" + tipoFigura);
                int cont2 = 0;
               while(cont2<ubicaciones.Length)
                {
                    Ubicacion ubi = ubicaciones[cont2];
                    string str1 = ubi.GetX().ToString();
                    string str2 = ubi.GetY().ToString();
                    Console.WriteLine("Ubicaciones: " + "[" + str1 + "," + str2 + "]");
                    cont2++;
                }
                cont++;
            }
        }

        public void SetListaFiguras(Figura fig)
        {
            int cont = 0;
            bool bandera = false;
            while(bandera != true)
            {
                if (ListaFiguras[cont] == null)
                {
                    ListaFiguras[cont] = fig;
                    bandera = true;
                }
                else
                    cont++;
            }
        }
        
       

        public bool VerificarFilas(int[,] tablero, int num, int coordenadaX,int coordenadaY)
        {
            int[] fila = new int[N];
            int cont = 0;
            
            for(int i = 0; i < N; i++)
            {
                for(int j = 0; j < N; j++)
                {
                    if( j == coordenadaY)
                    {
                        fila[cont] = tablero[i, j];
                        cont++;
                    }
                }
            }

            for (int k = 0; k < N; k++)
            {
                if (num == fila[k])
                    return false;
            }
            return true;
        }
        public bool VerificarColumnas(int[,] tablero, int num, int coordenadaX, int coordenadaY)
        {
            int[] columna = new int[N];
            int cont = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i == coordenadaX)
                    {
                        columna[cont] = tablero[i, j];
                        cont++;
                    }
                }
            }

            for (int k = 0; k < N; k++)
            {
                if (num == columna[k])
                    return false;
            }
            return true;
        }
        
        public Figura BuscarFigura(int x , int y)
        {
            Figura resul = null;
            int cont = 0;
            bool flag = false;
            while (ListaFiguras != null && flag == false) {
                Figura fig = ListaFiguras[cont];
                Ubicacion[] ubi = fig.GetLista();
                for(int i = 0; i < ubi.Length; i++)
                {
                    int ubiX = ubi[i].GetX();
                    int ubiY = ubi[i].GetY();
                    if(ubiX == x && ubiY == y)
                    {
                        resul = fig;
                        flag = true;
                        break;
                    }
                }
                cont++;


            }
            return resul;
        }
        public bool VerificarFigura(int [,] tablero, int num, int coordenadaX, int coordenadaY)
        {
            Figura fig = BuscarFigura(coordenadaX, coordenadaY);
            Ubicacion[] listaPosiciones = fig.GetLista();
            for(int i = 0; i < listaPosiciones.Length; i++)
            {
                Ubicacion ubi = listaPosiciones[i];
                int x = ubi.GetX();
                int y = ubi.GetY();
                int numTablero = tablero[x, y];
                if (num == numTablero)
                    return false;
            }
            return true;

        }
        
        public int[,] GenerarSudoku()
        {
            int cont = 0;
            Random rnd = new Random();
            while (cont <= N)
            {
                
                int aleatorioX = rnd.Next(0, N);
                int aleatorioY = rnd.Next(0, N);
                int aleatorioNum = rnd.Next(1, N + 1);
                if(VerificarColumnas(Tablero,aleatorioNum,aleatorioX,aleatorioY) && VerificarFilas(Tablero,aleatorioNum, aleatorioX, aleatorioY)&&VerificarFigura(Tablero, aleatorioNum, aleatorioX, aleatorioY))
                    Tablero[aleatorioX, aleatorioY] = aleatorioNum;
                    cont++;
            }
            return Tablero;

        }


        public bool Resolver(int [,] tablero)
        {
            Ubicacion ubi = NextEmpty(tablero);
            if (ubi.GetX() == -1 && ubi.GetY() == -1)       //resuelto
                return true;

            int parX = ubi.GetX();
            int parY = ubi.GetY();

            for(int i = 1; i <= N; i++)
            {
                if (VerificarColumnas(tablero, i, parX, parY) && VerificarFilas(tablero, i, parX, parY) && VerificarFigura(tablero, i, parX, parY))
                {
                    Tablero[parX, parY] = i;
                    //Console.WriteLine("-------------------------------------------------------------------------");
                    //Print(tablero);
                    if (Resolver(tablero))
                        return true;


                    //Console.WriteLine("**************************************************************************");
                    tablero[parX, parY] = 0;
                    //Print(tablero);
                    //Console.WriteLine("**************************************************************************");
                }
            }
            return false;
        }

    }
}
