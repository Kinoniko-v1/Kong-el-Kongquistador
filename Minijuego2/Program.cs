﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace JuegoRetro
{
    public class Program
    {
        static int jugadorPosX = 1;
        static int jugadorPosY = 1;

        static int enemigoPosX = 6;
        static int enemigoPosY = 6;

        static int mapaNumero = 0;

        static bool perdiste = false;
        static void Main()
        {
            
            char[,] mapaActual = Laberinto.DevolverLaberinto(mapaNumero);
            int cantPuntos;

            ConsoleKeyInfo tecla;
            do
            {
                Console.Clear();
                DibujarLaberinto(mapaActual);

                //puntos restantes:
                cantPuntos = CantidadDePuntos(mapaActual);
                Console.WriteLine($"Mapa N°: {mapaNumero + 1}");
                Console.WriteLine($"Cantidad de puntos restantes: {cantPuntos}");
                if (cantPuntos <= 1)
                {
                    DibujarPuerta();
                }

                DibujarJugador();
                DibujarEnemigo();

                tecla = Console.ReadKey();
                MoverJugador(tecla.Key, ref mapaActual);
                MoverEnemigo(ref mapaActual);
            } while (tecla.Key != ConsoleKey.Escape && !TeAlzanzoElEnemigo());
        }

        private static bool TeAlzanzoElEnemigo()
        {
            return jugadorPosX == enemigoPosX && jugadorPosY == enemigoPosY;
        }
        static void DibujarLaberinto(char[,] laberinto)
        {
            for (int i = 0; i < laberinto.GetLength(0); i++)
            {
                for (int j = 0; j < laberinto.GetLength(1); j++)
                {
                    Console.Write(laberinto[i, j]);
                }
                Console.WriteLine();
            }
        }
        static int CantidadDePuntos(char[,] laberinto)
        {
            int puntos = 0;
            for (int i = 0; i < laberinto.GetLength(0); i++)
            {
                for (int j = 0; j < laberinto.GetLength(1); j++)
                {
                    if (laberinto[i,j] == '.')
                    {
                        puntos++;
                    }
                }
            }
            return puntos;
        }
        static void DibujarJugador()
        {
            Console.SetCursorPosition(jugadorPosY, jugadorPosX);
            Console.Write('P');
        }
        static void DibujarEnemigo()
        {
            Console.SetCursorPosition(enemigoPosY, enemigoPosX);
            Console.Write('E');
        }
        static void MoverJugador(ConsoleKey tecla, ref char[,] laberinto)
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

            if (laberinto[nuevaPosX, nuevaPosY] != '#')
            {
                laberinto[jugadorPosX, jugadorPosY] = ' ';
                jugadorPosX = nuevaPosX;
                jugadorPosY = nuevaPosY;
            }
            if (laberinto[nuevaPosX, nuevaPosY] == 'K')
            {
                mapaNumero++;
                laberinto = Laberinto.SiguienteNivel(mapaNumero);
                jugadorPosX = 1;
                jugadorPosY = 1;
                SpawnearEnemigo(ref laberinto);
            }
        }

        private static void SpawnearEnemigo(ref char[,] laberinto)
        {
            Random r = new Random();
            do
            {
                enemigoPosX = r.Next(7, 11);
                enemigoPosY = r.Next(7, 11);
                
            } while (laberinto[enemigoPosX, enemigoPosY] == '#');
        }

        static void MoverEnemigo(ref char[,] laberinto)
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
        static void DibujarPuerta()
        {
            Laberinto.CrearPuerta(mapaNumero);
        }
    }
}