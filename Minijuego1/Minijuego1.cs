using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Media;
using Utilidades;
using System.Drawing.Printing;

namespace Minijuegos
{
    public class Minijuego1 : IMiniJuego
    {
        private static string[] palabras = 
            { "donkeykong", "pong", "spaceinvaders", "tetris", "galaga", "pacman", "frogger" };

        private static Random random = new Random();

        private static int randomNumero = random.Next(palabras.Length);
        private static String randomPalabra = palabras[randomNumero];

        private int numeroIntentos = 6;
        private int partesCuerpo = 0;

        private String[] letrasAdivinadas = new String[randomPalabra.Length];

        List<string> letrasUsadas = new List<string>();
        
        private bool ganaste = false;
        
        public Minijuego1()
        {
            Escritor.EscribirIzq("Minijuego Uno - Objeto creado");
        }
        public void Iniciar()
        {
            Escritor.Escribir("MiniJuego Uno - ejecutándose", 0, 0);
            Escritor.EscribirIzq("Desafío Ahorcado: adiviná el nombre del juego retro");

            //inicializa variables
            randomNumero = random.Next(palabras.Length);
            randomPalabra = palabras[randomNumero];

            numeroIntentos = 6;
            partesCuerpo = 0;

            letrasAdivinadas = new String[randomPalabra.Length];

            letrasUsadas = new List<string>();

            Escritor.LimpiaPantalla();

            Escritor.AhorcadoInicial(randomPalabra, numeroIntentos);

            Escritor.DibujarAhorcado(partesCuerpo);
        }

        public void Actualizar()
        {
            while (numeroIntentos > 0 && ganaste == false)
            {
                Ventana.DibujarMarco();

                Escritor.EscribeAhorcado("");
                Escritor.Escribir("¿Qué letra elegís?", 12, 19, true);
                Escritor.Escribir("", 12, 20, true);
                Console.CursorVisible = true;
                String letraElegida = Console.ReadLine().ToLower();
                Console.CursorVisible = false;

                if (letraElegida.Length == 1 && char.IsLetter(letraElegida[0]) && !letrasUsadas.Contains(letraElegida))
                {
                    Console.Clear();
                    if (randomPalabra.Contains(letraElegida))
                    {
                        letrasAdivinadas[randomPalabra.IndexOf(letraElegida)] = letraElegida;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Escritor.Escribir("Acertaste la letra", 12, 21, true);
                        Console.ForegroundColor = ConsoleColor.Gray;

                    }
                    else
                    {
                        partesCuerpo++;
                        numeroIntentos--;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Escritor.Escribir("Esa letra no está", 12, 21, true);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    Escritor.DibujarAhorcado(partesCuerpo);
                    Escritor.MostrarPalabraAdivinar(randomPalabra, letrasAdivinadas);
                    Escritor.Escribir($"Tenés {numeroIntentos} intentos", 12, 7, true);
                    letrasUsadas.Add(letraElegida);

                    Escritor.EscribirLetrasUsadas(letrasUsadas);

                    //procedimiento para chequear si se adivinó la palabra
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

                    if (palabra.ToString() == randomPalabra.ToString())
                    {
                        numeroIntentos = 0;
                        ganaste = true;
                        Finalizar();
                    }

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (letraElegida.Length != 1)
                    {
                        Escritor.Escribir("Ingresaste más de una letra", 12, 21, true);
                    }
                    else if (letrasUsadas.Contains(letraElegida))
                    {
                        Escritor.Escribir("Ya elegiste esa letra", 12, 21, true);
                    }
                    else
                    {
                        Escritor.Escribir("Lo que tocaste no es una letra", 12, 21, true);
                    }
                    Escritor.Escribir("Por favor ingresá un caracter válido", 12, 22, true);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            if (ganaste == false)
            {
                Ventana.DibujarMarco();
                Escritor.Escribir($"Game over! La palabra era {randomPalabra}", 60, 11, true);
                Escritor.Escribir("Cada victoria es solo una piedra más en el camino hacia mi dominio final", 60, 12, true);
                Escritor.Escribir("Presioná cualquier tecla", 60, 13, true);
                //Console.ReadKey();
                //Escritor.LimpiaPantalla();
                Finalizar();
            }
        }

        public int Finalizar()
        {
            if (ganaste)
            {
                Ventana.DibujarMarco();
                Escritor.Escribir("ME GANASTE!", 60, 11, true);
                Escritor.Escribir("¿Que cómo llevaré a cabo mi plan...? Supongo que chat GPT me ayudará. Pero no es momento para eso aún...", 60, 12, true);
                Escritor.Escribir("Presioná cualquier tecla", 60, 13, true);
                //Console.ReadKey();
                //Escritor.LimpiaPantalla();
                //Escritor.EscribirIzq("Minijuego1 finalizado, pasando a Minijuego2");
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
