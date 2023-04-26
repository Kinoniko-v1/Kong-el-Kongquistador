using System;
using System.Collections.Generic;
using System.Threading;
using Utilidades;

namespace JuegoRetro
{
    public class GameLoop
    {
        private int jugadorPosX = 1;
        private int jugadorPosY = 1;

        private int enemigoPosX = 6;
        private int enemigoPosY = 6;

        private static int mapaNumero = 0;
        private bool gano = false;

        private int margenY = 11;
        private int margen = 66;

        private static int vidas = 3;

        Laberinto lab = new Laberinto();
        public int IniciarGameLoop()
        {
            char[,] mapaActual = lab.DevolverLaberinto(mapaNumero);

            ConsoleKeyInfo tecla = new ConsoleKeyInfo();
            do
            {
                if (mapaNumero > 0)
                {
                    gano = true;
                    break;
                }
                if (vidas < 1)
                {
                    gano = false;
                    break;
                }
                Console.Clear();
                Console.CursorVisible= false;
                Ventana.DibujarMarco();
                DibujarLaberinto(mapaActual);
                MostrarInfo(mapaActual);

                DibujarJugador();
                DibujarEnemigo();

                tecla = Console.ReadKey();
                MoverJugador(tecla.Key, ref mapaActual);
                MoverEnemigo(ref mapaActual);
            } while (vidas > 0);

            if (gano)
            {
                Console.Clear();
                Ventana.DibujarMarco();
                Escritor.Escribir($"¡Ganaste!", margen, margenY, true);
                Console.ReadKey();
                Console.Clear();
                return 1;
            }
            else
                return 0;
        }
        private void MostrarInfo(char[,] mapaActual)
        {
            //puntos restantes:
            int cantPuntos = ObtenerCantidadDePuntos(mapaActual);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Escritor.Escribir($"Vidas: {vidas}", margen, margenY - 2, true);
            Escritor.Escribir($"Mapa N°: {mapaNumero + 1}", margen, margenY - 1, true);
            Escritor.Escribir($"Cantidad de puntos restantes: {cantPuntos}", margen, 12 + margenY, true);
            Console.ForegroundColor = ConsoleColor.White;
            if (cantPuntos < 1 || cantPuntos == 0)
            {
                DibujarPuerta();
            }
        }
        private bool TeAlcanzoElEnemigo()
        {
            return jugadorPosX == enemigoPosX && jugadorPosY == enemigoPosY;
        }
        private void DibujarLaberinto(char[,] laberinto)
        {
            for (int i = 0; i < laberinto.GetLength(0); i++)
            {
                for (int j = 0; j < laberinto.GetLength(1); j++)
                {
                    Console.SetCursorPosition(margen + j, margenY + i);
                    Console.Write(laberinto[i, j]);
                }
                Console.WriteLine();
            }
        }
        private int ObtenerCantidadDePuntos(char[,] laberinto)
        {
            int puntos = 0;
            for (int i = 0; i < laberinto.GetLength(0); i++)
            {
                for (int j = 0; j < laberinto.GetLength(1); j++)
                {
                    if (laberinto[i, j] == '.')
                    {
                        puntos++;
                    }
                }
            }
            return puntos;
        }
        private void DibujarJugador()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(jugadorPosY + margen, jugadorPosX + margenY);
            Console.Write('P');
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void DibujarEnemigo()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(enemigoPosY + margen, enemigoPosX + margenY);
            Console.Write('E');
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void MoverJugador(ConsoleKey tecla, ref char[,] laberinto)
        {
            int nuevaPosX = jugadorPosX;
            int nuevaPosY = jugadorPosY;

            switch (tecla)
            {
                case ConsoleKey.UpArrow:
                    nuevaPosX--;
                    break;
                case ConsoleKey.DownArrow:
                    nuevaPosX++;
                    break;
                case ConsoleKey.LeftArrow:
                    nuevaPosY--;
                    break;
                case ConsoleKey.RightArrow:
                    nuevaPosY++;
                    break;
            }
            if (TeAlcanzoElEnemigo())
            {
                vidas--;
                jugadorPosX = 1;
                jugadorPosY = 1;

                enemigoPosX = 6;
                enemigoPosY = 6;

                IniciarGameLoop();
            }
            if (laberinto[nuevaPosX, nuevaPosY] != '#')
            {
                laberinto[jugadorPosX, jugadorPosY] = ' ';
                jugadorPosX = nuevaPosX;
                jugadorPosY = nuevaPosY;
            }
            if (laberinto[nuevaPosX, nuevaPosY] == '¦')
            {
                mapaNumero++;
                laberinto = lab.SiguienteNivel(mapaNumero);
                jugadorPosX = 1;
                jugadorPosY = 1;
                SpawnearEnemigo(ref laberinto);
            }
        }
        private void SpawnearEnemigo(ref char[,] laberinto)
        {
            Random r = new Random();
            do
            {
                enemigoPosX = r.Next(7, 11);
                enemigoPosY = r.Next(7, 11);

            } while (laberinto[enemigoPosX, enemigoPosY] == '#');
        }
        private void MoverEnemigo(ref char[,] laberinto)
        {
            // Buscar la posición del jugador
            int jugadorDistanciaX = jugadorPosX - enemigoPosX;
            int jugadorDistanciaY = jugadorPosY - enemigoPosY;

            // Mover al enemigo en la dirección del jugador
            if (Math.Abs(jugadorDistanciaX) > Math.Abs(jugadorDistanciaY))
            {
                if (jugadorDistanciaX > 0 && laberinto[enemigoPosX + 1, enemigoPosY] != '#')
                {
                    enemigoPosX++;
                }
                else if (jugadorDistanciaX < 0 && laberinto[enemigoPosX - 1, enemigoPosY] != '#')
                {
                    enemigoPosX--;
                }
            }
            else
            {
                if (jugadorDistanciaY > 0 && laberinto[enemigoPosX, enemigoPosY + 1] != '#')
                {
                    enemigoPosY++;
                }
                else if (jugadorDistanciaY < 0 && laberinto[enemigoPosX, enemigoPosY - 1] != '#')
                {
                    enemigoPosY--;
                }
            }
        }
        private void DibujarPuerta()
        {
            lab.CrearPuerta(mapaNumero);
        }
    }
}