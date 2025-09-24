class ReglasJuego
{
    public static bool CuadradoDisponible(int[,] tablero, int fila, int col)
    {
        return fila >= 0 && fila < 3 && col >= 0 && col < 3 && tablero[fila, col] == 0;
    }

    public static void MarcarCuadrado(int[,] tablero, int fila, int col, int jugador)
    {
        tablero[fila, col] = jugador;
    }

    public static bool EsTableroCompleto(int[,] tablero)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (tablero[i, j] == 0)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool VerificarGanador(int[,] tablero, int jugador)
    {
        for (int i = 0; i < 3; i++)
        {
            if (tablero[i, 0] == jugador && tablero[i, 1] == jugador && tablero[i, 2] == jugador)
            {
                return true;
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if (tablero[0, i] == jugador && tablero[1, i] == jugador && tablero[2, i] == jugador)
            {
                return true;
            }
        }

        if (tablero[0, 0] == jugador && tablero[1, 1] == jugador && tablero[2, 2] == jugador)
        {
            return true;
        }
        if (tablero[0, 2] == jugador && tablero[1, 1] == jugador && tablero[2, 0] == jugador)
        {
            return true;
        }

        return false;
    }
}