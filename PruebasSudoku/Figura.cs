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
        int Operacion { get; set; }
        string Tipo { set; get; }
        int Acumulado { set; get; } 
        Ubicacion[] ListaUbicacion { get; set; }
        int Ocupado { set; get; }



        public Figura(Ubicacion[] listaUbicaciones,string type,int numeroMeta, int operacionFigura,int acum,int ocupados)
        {
            NumMeta = numeroMeta;
            Operacion = operacionFigura;
            Tipo = type;
            ListaUbicacion = listaUbicaciones;
            Acumulado = acum;
            Ocupado = ocupados;

        }

        public String GetTipo()
        {
            return Tipo;
        }
        public Ubicacion[] GetLista()
        {
            return ListaUbicacion;
        }
        public int GetNumMeta()
        {
            return NumMeta;
        }
        public int GetOperacion()
        {
            return Operacion;
        }
        public int GetAcumulado()
        {
            return Acumulado;
        }
        public int GetOcupado()
        {
            return Ocupado;
        }
        public void AumentarOcupado(int num)
        {
            Ocupado = Ocupado + num;
        }
        public void DisminuirOcupado(int num)
        {
            Ocupado = Ocupado - num;
        }

        public void AumentarAcumuladoSum(int num)
        {
            Acumulado = Acumulado + num;
        }
        public void AumentarAcumuladoMul(int num)
        {
            Acumulado = Acumulado * num;
        }
        public void DisminuirAcumuladoSum(int num)
        {
            Acumulado = Acumulado - num;
        }
        public void DisminuirAcumuladoMul(int num)
        {
            Acumulado = Acumulado / num;
        }
    }

}
