using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

namespace Utilidades
{
        // La clase Escritor se utiliza para mandar mensajes en lugar de Console.WriteLine();
        // Es necesario debido a que se manejan ciertas dimensiones en la CONSOLA específicas.
        // (Ahorra tener que desplazar el cursor cada vez que se mande un mensaje)
    public static class Escritor
    {
        public static void Esribir(string texto)
        {
            // Escribe un mensaje animado donde se encuentre el cursor
            foreach (char item in texto)
            {
                Console.Write(item);
                Thread.Sleep(50);
            }
        }
        public static void Escribir(string texto, int cordX, int cordY)
        {
            // Escribe donde se le indique en coordenadas
            Console.SetCursorPosition(cordX, cordY);
            foreach (char item in texto)
            {
                Console.Write(item);
                Thread.Sleep(50);
            }
        }
        public static void Escribir(string texto, int cordX, int cordY, bool b)
        {
            // Escribe donde se le indique en coordenadas
            Console.SetCursorPosition(cordX, cordY);
            Console.Write(texto);
        }
        public static void EscribirIzq(string texto)
        {
            // Escribe en posición Default a la izquierda
            Escribir(texto, 4, 2);
        }
        public static void EscribirDer(string texto)
        {
            // Escribe en posición Default a la derecha
            Escribir(texto, Console.WindowWidth-texto.Length-3, 2);
        }
        public static void EscribirTitulo(string texto) 
        {
            // Escribe en posición Default en el centro superior
            int largo = texto.Length/2;
            Escribir(texto, Console.WindowWidth / 2 - largo, 1);
        }
        public static void EscribirLista(List<string> lista,int cordX, int cordY)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                string s = lista[i];
                Escribir(s, cordX, i + cordY);
            }
        }  
        public static void LimpiaPantalla()
        {
            Console.Clear();
        }

        public static void AhorcadoInicial(String randomPalabra, int numeroIntentos)
        {
            Escribir("Que comience el juego!", 5, 2, true);
            Escribir($"Ya elegí una palabra, de {randomPalabra.Length} letras", 12, 6, true);
            Escribir($"Tenés {numeroIntentos} intentos", 12, 7, true);
            //Escritor.EscribirIzq("La palabra es " + randomPalabra);
        }
        public static void EscribeAhorcado(String texto)
        {
            Console.SetCursorPosition(4, Console.CursorTop); //igual a EscribeIzq, pero solo en X
            Console.WriteLine(texto);
        }

        public static void EscribeAhorcadoSinSalto(string texto)
        {
            Console.SetCursorPosition(4, Console.CursorTop); //igual a EscribeIzq, pero solo en X
            Console.Write(texto);
        }

        public static void MostrarPalabraAdivinar(String randomPalabra, Array letrasAdivinadas)
        {
            string palabra = "";

            for (int i = 0; i < randomPalabra.Length; i++)
            {
                if (Array.IndexOf(letrasAdivinadas, randomPalabra[i].ToString()) != -1)
                {
                    palabra += randomPalabra[i];
                }
                else
                {
                    palabra += "_";
                }
            }
            Escribir(palabra, 12, 17, true);
        }

        public static void EscribirLetrasUsadas(List<string> letrasUsadas)
        {
            int posX = 0;
            Escribir("Letras usadas: ", 12, 23, true);
            foreach (string l in letrasUsadas)
            {
                Escribir($"{l}", 12 + posX, 24, true);
                posX++;
            }
        }

        public static void DibujarAhorcado(int PartesCuerpo)
        {
            switch (PartesCuerpo)
            {
                case 0:
                    Escribir(" _____   ", 12, 10, true);
                    Escribir("|     |  ", 12, 11, true);
                    Escribir("|        ", 12, 12, true);
                    Escribir("|        ", 12, 13, true);
                    Escribir("|        ", 12, 14, true);
                    Escribir("|        ", 12, 15, true);
                    Escribir("=========", 12, 16, true);
                    break;
                case 1:
                    Escribir(" _____   ", 12, 10, true);
                    Escribir("|     |  ", 12, 11, true);
                    Escribir("|     O  ", 12, 12, true);
                    Escribir("|        ", 12, 13, true);
                    Escribir("|        ", 12, 14, true);
                    Escribir("|        ", 12, 15, true);
                    Escribir("=========", 12, 16, true);
                    break;
                case 2:
                    Escribir(" _____   ", 12, 10, true);
                    Escribir("|     |  ", 12, 11, true);
                    Escribir("|     O  ", 12, 12, true);
                    Escribir("|     |  ", 12, 13, true);
                    Escribir("|        ", 12, 14, true);
                    Escribir("|        ", 12, 15, true);
                    Escribir("=========", 12, 16, true);
                    break;
                case 3:
                    Escribir(" _____   ", 12, 10, true);
                    Escribir("|     |  ", 12, 11, true);
                    Escribir("|     O  ", 12, 12, true);
                    Escribir("|    /|  ", 12, 13, true);
                    Escribir("|        ", 12, 14, true);
                    Escribir("|        ", 12, 15, true);
                    Escribir("=========", 12, 16, true);
                    break;
                case 4:
                    Escribir(" _____   ", 12, 10, true);
                    Escribir("|     |  ", 12, 11, true);
                    Escribir("|     O  ", 12, 12, true);
                    Escribir("|    /|\\ ", 12, 13, true);
                    Escribir("|        ", 12, 14, true);
                    Escribir("|        ", 12, 15, true);
                    Escribir("=========", 12, 16, true);
                    break;
                case 5:
                    Escribir(" _____   ", 12, 10, true);
                    Escribir("|     |  ", 12, 11, true);
                    Escribir("|     O  ", 12, 12, true);
                    Escribir("|    /|\\ ", 12, 13, true);
                    Escribir("|    /   ", 12, 14, true);
                    Escribir("|        ", 12, 15, true);
                    Escribir("=========", 12, 16, true);
                    break;
                case 6:
                    Escribir(" _____   ", 12, 10, true);
                    Escribir("|     |  ", 12, 11, true);
                    Escribir("|     O  ", 12, 12, true);
                    Escribir("|    /|\\ ", 12, 13, true);
                    Escribir("|    / \\ ", 12, 14, true);
                    Escribir("|        ", 12, 15, true);
                    Escribir("=========", 12, 16, true);
                    break;
            }
        }

        public static void EscribirDatoI(string texto) { }
        public static void EscribirDatoD(string texto) { }
        public static void EscribirDatoC(string texto) { }

    }
}
