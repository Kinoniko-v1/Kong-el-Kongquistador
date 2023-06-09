﻿using System;
using System.Collections.Generic;
namespace Utilidades
{
    static public class Transiciones
    {
        static public void MenuPrincipal(ref bool esc)
        {
            bool opcion = false;
            string jugar = "Jugar [ENTER]";
            string salir = "Salir [ESC]";
            int posX = Console.WindowWidth / 2;
            int posY = Console.WindowHeight / 2;
            Console.Clear();
            Ventana.DibujarMarco();
            Escritor.EscribirTitulo("Hello World! - Abrid paso a Kong El Kongquistador\n");

            Escritor.EscribirIzq("(No presionar teclas mientras se escriben los textos. Provoca un salto inesperado)");
            do
            {
                Escritor.Escribir(jugar, posX - jugar.Length/2,posY, true);
                Escritor.Escribir(salir, posX - salir.Length / 2, posY+1, true);
                Console.SetCursorPosition(posX, posY + 5);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                    {
                        esc = true;
                        opcion = true;
                    }
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Environment.Exit(0);
                    }
                    else
                        opcion = false;
                }

            } while (!opcion);

            Ventana.PantallazoRojo();
        }
        static public void Mensaje1()
        {
            Console.Clear();
            Ventana.DibujarMarco();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            string s1 = "¡Prepárense para la llegada del gran Kong el Kongquistador, el dueño absoluto de todos los juegos y plataformas!";
            string s2 = "¡Nadie podrá detener mi avance hacia la conquista total! ¡Recordarán mi nombre por siempre!";
            string s3 = "¡Para hacer esto interesante, te pondré 3 desafíos! Si logras pasarlos, me retiraré silenciosamente. Pero si no...";
            string s4 = "¡Infectaré tu PC para iniciar mi conquista hacia los videojuegos de todo el multiverso y llenarlos de microtransacciones!";
            string vacia = "";

            List<string> texto = new List<string> { s1, s2, vacia, s3, s4};
            Escritor.EscribirLista(texto,157 / 2-s1.Length / 2, Console.WindowHeight/2 - texto.Count);

            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = true;
            Console.ReadKey();
            Console.CursorVisible = false;
        }
        static public void FinalBueno() 
        {
            Console.Clear();
            Ventana.DibujarMarco();
            Console.ForegroundColor = ConsoleColor.Green;
            string f_texto1 = "Final Bueno";
            Escritor.EscribirTitulo(f_texto1);
            Console.ForegroundColor = ConsoleColor.White;

            string s1 = "Al parecer lograste derrotar a nada más ni nada menos que a";
            string s2 = "Kong el Kongquistador, un ser intertemporal. Pero no era él en verdad.";
            string s3 = "O acaso creíste que alguien tan poderoso iba a ser tan fácil de derrotar";
            string s4 = "Su plan no termina aún, le ganaste a una aplicación de Consola ¡Felicidades!";
            string s5 = "Por cierto, era una versión de bajo presupesto evidentemente...";
            string vacia = "";

            List<string> texto = new List<string> { s1, s2, s3, vacia, s4, vacia, s5 };
            Escritor.EscribirLista(texto, 157 / 2 - s1.Length / 2, Console.WindowHeight / 2 - texto.Count);

        }
        static public void FinalMalo() 
        {
            Console.Clear();
            Ventana.DibujarMarco();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            string f_texto1 = "Final Malo";
            Escritor.EscribirTitulo(f_texto1);
            Console.ForegroundColor = ConsoleColor.White;

            string s1 = "Tras haber perdido, y tontamente permitirle a Kong acceder a tu PC,";
            string s2 = "él consiguió entrar en la Web para infectar los demás dispositivos de la misma manera.";
            string s3 = "Quizás el verdadero héroe de esta historia sea";
            string s4 = "Alguien con bigote y un exagerado acento italiano...";
            string vacia = "";

            List<string> texto = new List<string> { s1, s2, vacia, s3, vacia, s4 };
            Escritor.EscribirLista(texto, 157 / 2 - s1.Length/2, Console.WindowHeight / 2 - texto.Count);
        }

    }
}
