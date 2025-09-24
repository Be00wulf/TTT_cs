using System;
using System.Linq;

class Minimax
{
    public static Tuple<int, int> MejorMovimiento(int[,] tablero)
    {
        int mejorPuntaje = int.MinValue;
        Tuple<int, int> movimiento = new Tuple<int, int>(-1, -1);
        
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (ReglasJuego.CuadradoDisponible(tablero, i, j))
                {
                    int[,] tableroSimulado = (int[,])tablero.Clone();
                    tableroSimulado[i, j] = 2; // ia
                    
                    int puntaje = CalcularMinimax(tableroSimulado, 0, false);
                    
                    if (puntaje > mejorPuntaje)
                    {
                        mejorPuntaje = puntaje;
                        movimiento = new Tuple<int, int>(i, j);
                    }
                }
            }
        }
        return movimiento;
    }

    private static int CalcularMinimax(int[,] tablero, int profundidad, bool esMaximizando)
    {
        if (ReglasJuego.VerificarGanador(tablero, 2)) return 1000;
        if (ReglasJuego.VerificarGanador(tablero, 1)) return -1000;
        if (ReglasJuego.EsTableroCompleto(tablero)) return 0;
        
        if (esMaximizando)
        {
            int mejorPuntaje = int.MinValue;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (ReglasJuego.CuadradoDisponible(tablero, i, j))
                    {
                        int[,] tableroSimulado = (int[,])tablero.Clone();
                        tableroSimulado[i, j] = 2;
                        int puntaje = CalcularMinimax(tableroSimulado, profundidad + 1, false);
                        mejorPuntaje = Math.Max(puntaje, mejorPuntaje);
                    }
                }
            }
            return mejorPuntaje;
        }
        else
        {
            int mejorPuntaje = int.MaxValue;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (ReglasJuego.CuadradoDisponible(tablero, i, j))
                    {
                        int[,] tableroSimulado = (int[,])tablero.Clone();
                        tableroSimulado[i, j] = 1;
                        int puntaje = CalcularMinimax(tableroSimulado, profundidad + 1, true);
                        mejorPuntaje = Math.Min(puntaje, mejorPuntaje);
                    }
                }
            }
            return mejorPuntaje;
        }
    }
}