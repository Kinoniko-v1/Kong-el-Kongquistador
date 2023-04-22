﻿using System;

namespace JuegoRetro
{
    public class Laberinto
    {
        private char[,] mapaLaberinto0 = new char[,]
        {
        {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
        {'#', '#', '.', '.', '.', '.', '.', '.', '.', '.', '#', '#', '#', '#', '#' },
        {'#', '#', '.', '#', '.', '#', '.', '#', '#', '.', '#', '.', '#', '#', '#' },
        {'#', '#', '.', '.', '.', '.', '.', '.', '#', '.', '#', '.', '#', '#', '#' },
        {'#', '#', '.', '#', '#', '#', '.', '#', '#', '.', '.', '.', '.', '#', '#' },
        {'#', '#', '.', '.', '.', '.', '.', '.', '#', '.', '#', '.', '#', '#', '#' },
        {'#', '#', '.', '#', '.', '#', '#', '#', '#', '#', '#', '.', '#', '#', '#' },
        {'#', '#', '.', '#', '.', '#', '.', '.', '.', '#', '#', '.', '#', '#', '#' },
        {'#', '#', '.', '.', '.', '#', '.', '#', '.', '#', '.', '.', '.', '#', '#' },
        {'#', '#', '.', '#', '#', '#', '.', '#', '.', '#', '.', '#', '.', '#', '#' },
        {'#', '#', '.', '.', '.', '.', '.', '#', '.', '.', '.', '#', '.', '#', '#' }, // 10,13
        {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
        };

        private char[,] mapaLaberinto1 = new char[,]
        {
        {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
        {'#', '#', '.', '.', '.', '.', '.', '.', '.', '.', '#', '#', '#', '#', '#' },
        {'#', '#', '#', '#', '#', '#', '.', '#', '#', '.', '#', '.', '.', '#', '#' },
        {'#', '#', '#', '.', '.', '.', '.', '#', '#', '.', '#', '.', '#', '#', '#' },
        {'#', '#', '#', '#', '#', '#', '.', '#', '#', '.', '#', '.', '.', '.', '#' },
        {'#', '#', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '#' },
        {'#', '#', '#', '#', '.', '#', '#', '.', '#', '#', '#', '.', '#', '.', '#' },
        {'#', '#', '.', '.', '.', '#', '.', '.', '.', '#', '#', '.', '#', '.', '#' },
        {'#', '#', '.', '#', '#', '#', '.', '#', '.', '#', '#', '.', '#', '.', '#' },
        {'#', '#', '.', '#', '#', '#', '.', '#', '.', '.', '.', '.', '.', '.', '#' },
        {'#', '.', '.', '#', '#', '#', '.', '.', '.', '#', '#', '#', '#', '#', '#' }, // 10,13
        {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
        };

        private char[,] mapaLaberinto2 = new char[,]
        {
        {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
        {'#', '#', '.', '#', '.', '.', '.', '.', '.', '.', '#', '#', '#', '#', '#' },
        {'#', '#', '.', '#', '.', '#', '.', '#', '#', '.', '#', '.', '#', '#', '#' },
        {'#', '.', '.', '.', '.', '.', '.', '#', '#', '.', '#', '.', '#', '#', '#' },
        {'#', '.', '#', '#', '#', '#', '.', '#', '#', '.', '.', '.', '.', '#', '#' },
        {'#', '.', '#', '#', '.', '#', '.', '.', '.', '.', '#', '.', '#', '#', '#' },
        {'#', '.', '#', '#', '.', '#', '#', '#', '.', '#', '#', '.', '#', '#', '#' },
        {'#', '.', '.', '.', '.', '#', '.', '.', '.', '#', '#', '.', '#', '#', '#' },
        {'#', '#', '.', '#', '#', '#', '.', '#', '.', '.', '.', '.', '.', '#', '#' },
        {'#', '#', '.', '#', '#', '#', '.', '#', '#', '#', '#', '.', '.', '#', '#' },
        {'#', '#', '.', '.', '.', '.', '.', '#', '#', '#', '#', '#', '.', '#', '#' }, // 10,13
        {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
        };

        public char[,] DevolverLaberinto(int mapaNumero)
        {
            switch (mapaNumero)
            {
                case 0:
                    return mapaLaberinto0;
                case 1:
                    return mapaLaberinto1;
                case 2:
                    return mapaLaberinto2;
                default:
                    return mapaLaberinto0;
            }
        }
        public char[,] SiguienteNivel(int numeroMapa)
        {
            return DevolverLaberinto(numeroMapa);
        }
        public char[,] CrearPuerta(int numeroMapa)
        {
            char[,] mapa = DevolverLaberinto(numeroMapa);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            mapa[10, 13] = '¦';
            mapa[11, 13] = '¦';
            Console.ForegroundColor = ConsoleColor.White;
            return mapa;
        }
    }
}