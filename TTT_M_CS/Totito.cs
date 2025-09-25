using System;

class Totito
{
    static int[,] tablero = new int[3, 3];
    static int jugadorActual = 1;       //yo
    static bool juegoTerminado = false;

    static void Main(string[] args)
    {
        ReiniciarJuego();

        while (!juegoTerminado)
        {
            DibujarTablero();

            // mi turno
            if (jugadorActual == 1)
            {
                Console.WriteLine("Ingrese la fila y columna de su tiro (ej: 2 2)");
                string[] entrada = Console.ReadLine().Split(' ');

                try
                {
                    int fila = int.Parse(entrada[0]);
                    int col = int.Parse(entrada[1]);

                    if (ReglasJuego.CuadradoDisponible(tablero, fila, col))
                    {
                        ReglasJuego.MarcarCuadrado(tablero, fila, col, jugadorActual);

                        if (ReglasJuego.VerificarGanador(tablero, jugadorActual))
                        {
                            juegoTerminado = true;
                            DibujarTablero();
                            Console.WriteLine("LE HAS GANADO A LA IA");
                        }
                        else if (ReglasJuego.EsTableroCompleto(tablero))
                        {
                            juegoTerminado = true;
                            DibujarTablero();
                            Console.WriteLine("EMPATE");
                        }

                        jugadorActual = 2;
                    }
                    else
                    {
                        Console.WriteLine("Casilla no disponible, intente nuevamente ");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("ADVERTENCIA: Ingrese una casilla disponible ");
                }
            }
            // ia
            else
            {
                Console.WriteLine("Turno de la IA [X] ");
                Tuple<int, int> movimientoIA = Minimax.MejorMovimiento(tablero);
                ReglasJuego.MarcarCuadrado(tablero, movimientoIA.Item1, movimientoIA.Item2, jugadorActual);

                if (ReglasJuego.VerificarGanador(tablero, jugadorActual))
                {
                    juegoTerminado = true;
                    DibujarTablero();
                    Console.WriteLine("HA GANADO LA IA ");
                }
                else if (ReglasJuego.EsTableroCompleto(tablero))
                {
                    juegoTerminado = true;
                    DibujarTablero();
                    Console.WriteLine("EMPATE");
                }

                jugadorActual = 1;
            }
        }
    }

    static void DibujarTablero()
    {
        // Console.Clear(); 
        Console.WriteLine("\n   0   1   2");
        Console.WriteLine("  -----------");
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"{i} | ");
            for (int j = 0; j < 3; j++)
            {
                string simbolo = tablero[i, j] == 1 ? "O" : tablero[i, j] == 2 ? "X" : " ";
                Console.Write($"{simbolo} | ");
            }
            Console.WriteLine("\n  -----------");
        }
        Console.WriteLine();
    }

    static void ReiniciarJuego()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                tablero[i, j] = 0;
            }
        }
        jugadorActual = 1;
        juegoTerminado = false;
    }
}

//https://be00wulf.github.io/mj-ba.github.io/bitacoras/csharp/proyecto_consola.html