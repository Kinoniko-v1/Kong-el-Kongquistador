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

        public static void EscribirDatoI(string texto) { }
        public static void EscribirDatoD(string texto) { }
        public static void EscribirDatoC(string texto) { }

    }
}
