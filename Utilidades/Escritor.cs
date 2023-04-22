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
            
        public static void LimpiaPantalla()
        {
            Console.Clear();
        }

        public static void AhorcadoInicial(String randomPalabra, int numeroIntentos)
        {
            EscribeAhorcado("");
            EscribeAhorcado("Que comience el juego!");
            EscribeAhorcado("");

            EscribeAhorcado("");
            EscribeAhorcado("Ya elegí una palabra, de " + randomPalabra.Length + " letras");
            EscribeAhorcado("");
            //Escritor.EscribirIzq("La palabra es " + randomPalabra);
            EscribeAhorcado("Tenés " + numeroIntentos + " intentos");
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
            EscribeAhorcado(palabra);
        }

        public static void EscribirLetrasUsadas(List<string> letrasUsadas)
        {
            EscribeAhorcado("Letras usadas: ");
            EscribeAhorcado("");
            foreach (string l in letrasUsadas)
            {
                EscribeAhorcado(l + " ");
            }
        }

        public static void DibujarAhorcado(int PartesCuerpo)
        {
            switch (PartesCuerpo)
            {
                case 0:
                    EscribeAhorcado(" _____   ");
                    EscribeAhorcado("|     |  ");
                    EscribeAhorcado("|        ");
                    EscribeAhorcado("|        ");
                    EscribeAhorcado("|        ");
                    EscribeAhorcado("|        ");
                    EscribeAhorcado("=========");
                    break;
                case 1:
                    EscribeAhorcado(" _____   ");
                    EscribeAhorcado("|     |  ");
                    EscribeAhorcado("|     O  ");
                    EscribeAhorcado("|        ");
                    EscribeAhorcado("|        ");
                    EscribeAhorcado("|        ");
                    EscribeAhorcado("=========");
                    break;
                case 2:
                    EscribeAhorcado(" _____   ");
                    EscribeAhorcado("|     |  ");
                    EscribeAhorcado("|     O  ");
                    EscribeAhorcado("|     |  ");
                    EscribeAhorcado("|        ");
                    EscribeAhorcado("|        ");
                    EscribeAhorcado("=========");
                    break;
                case 3:
                    EscribeAhorcado(" _____   ");
                    EscribeAhorcado("|     |  ");
                    EscribeAhorcado("|     O  ");
                    EscribeAhorcado("|    /|  ");
                    EscribeAhorcado("|        ");
                    EscribeAhorcado("|        ");
                    EscribeAhorcado("=========");
                    break;
                case 4:
                    EscribeAhorcado(" _____   ");
                    EscribeAhorcado("|     |  ");
                    EscribeAhorcado("|     O  ");
                    EscribeAhorcado("|    /|\\ ");
                    EscribeAhorcado("|        ");
                    EscribeAhorcado("|        ");
                    EscribeAhorcado("=========");
                    break;
                case 5:
                    EscribeAhorcado(" _____   ");
                    EscribeAhorcado("|     |  ");
                    EscribeAhorcado("|     O  ");
                    EscribeAhorcado("|    /|\\ ");
                    EscribeAhorcado("|    /   ");
                    EscribeAhorcado("|        ");
                    EscribeAhorcado("=========");
                    break;
                case 6:
                    EscribeAhorcado(" _____   ");
                    EscribeAhorcado("|     |  ");
                    EscribeAhorcado("|     O  ");
                    EscribeAhorcado("|    /|\\ ");
                    EscribeAhorcado("|    / \\ ");
                    EscribeAhorcado("|        ");
                    EscribeAhorcado("=========");
                    break;
            }
        }

        public static void EscribirDatoI(string texto) { }
        public static void EscribirDatoD(string texto) { }
        public static void EscribirDatoC(string texto) { }

    }
}
