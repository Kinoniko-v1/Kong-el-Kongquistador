using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

namespace Utilidades
{
    public static class Ventana
    {
        // Si no se ejecuta este método almenos una vez antes de los demás EL PROGRAMA DEJA DE FUNCIONAR.
        public static void AjustarVentana()
        // Setea las dimensiones de la Consola, a partir de estas proporciones se ejecutan los métodos de...
        // las clases Narrador y Ventana (esta misma).
        {
            if (Console.LargestWindowWidth > 240 
                && Console.LargestWindowHeight > 63) // 1920x1080 = 240x63 | 
            {
                Console.SetWindowSize(160, 40);
                Console.BufferWidth = 160;
                Console.BufferHeight = 40;
                Console.CursorVisible = false;
            }
            else
            {
                Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                Console.BufferWidth = Console.LargestWindowWidth;
                Console.BufferHeight = Console.LargestWindowHeight;
                Console.CursorVisible = false;
            }
        }
        public static void DibujarMarco() // La idea es que el GameLoop se muestre dentro de un marco.
        {
            // Crea el marco en las dimensiones establecidas.
            // llamarlo cada vez que sea necesario: por ejemplo, luego del uso Console.Clear();

            // Utilizar estos objetos Point como referencia sobre dónde escribir en consola.
            Point limiteSuperior = new Point(3, 4);
            Point limiteInferior = new Point(157, 37);
            for (int i = limiteSuperior.X; i <= limiteInferior.X; i++)
            {
                Console.SetCursorPosition(i, limiteSuperior.Y);
                Console.Write("═");
                Console.SetCursorPosition(i, limiteInferior.Y);
                Console.Write("═");
            }
            for (int i = limiteSuperior.Y; i <= limiteInferior.Y; i++)
            {
                Console.SetCursorPosition(limiteSuperior.X, i);
                Console.Write("║");
                Console.SetCursorPosition(limiteInferior.X, i);
                Console.Write("║");
            }
            Console.SetCursorPosition(limiteSuperior.X, limiteSuperior.Y);
            Console.Write("╔");
            Console.SetCursorPosition(limiteSuperior.X, limiteInferior.Y);
            Console.Write("╚");
            Console.SetCursorPosition(limiteInferior.X, limiteSuperior.Y);
            Console.Write("╗");
            Console.SetCursorPosition(limiteInferior.X, limiteInferior.Y);
            Console.Write("╝");
        }
        public static void PantallazoRojo()
        {
            // Una animación, puede ser utilizada entre juegos o al comienzo.
            // Genera 3 pantallazos rojos.
            for (int i = 0; i < 3; i++)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Thread.Sleep(500);
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                Thread.Sleep(500);
            }
            Console.Clear();
        }
    }
}
