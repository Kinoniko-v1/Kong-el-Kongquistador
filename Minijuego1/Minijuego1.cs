using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Media;
using Utilidades;

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
                Escritor.EscribeAhorcado("");
                Escritor.EscribeAhorcado("¿Qué letra elegís?");
                Ventana.DibujarMarco();
                Console.CursorVisible = true;
                Console.SetCursorPosition(4, 16);
                String letraElegida = Console.ReadLine().ToLower();
                Console.CursorVisible = false;

                if (letraElegida.Length == 1 && char.IsLetter(letraElegida[0]) && !letrasUsadas.Contains(letraElegida))
                {
                    Console.Clear();
                    if (randomPalabra.Contains(letraElegida))
                    {
                        letrasAdivinadas[randomPalabra.IndexOf(letraElegida)] = letraElegida;
                        Escritor.EscribeAhorcado("Acertaste la letra");
                    }
                    else
                    {
                        partesCuerpo++;
                        numeroIntentos--;
                        Escritor.EscribeAhorcado("Esa letra no está");
                    }

                    Escritor.DibujarAhorcado(partesCuerpo);
                    Escritor.EscribeAhorcado("");
                    Escritor.MostrarPalabraAdivinar(randomPalabra, letrasAdivinadas);
                    Escritor.EscribeAhorcado("");
                    Escritor.EscribeAhorcado("Tenés " + numeroIntentos + " intentos");
                    Escritor.EscribeAhorcado("");
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
                    if (letraElegida.Length != 1)
                    {
                        Escritor.EscribeAhorcado("Ingresaste más de una letra");
                    }
                    else if (letrasUsadas.Contains(letraElegida))
                    {
                        Escritor.EscribeAhorcado("Ya elegiste esa letra");
                    }
                    else
                    {
                        Escritor.EscribeAhorcado("Lo que tocaste no es una letra");
                    }
                    Escritor.EscribeAhorcado("Por favor ingresá un caracter válido");
                }
                Console.Clear();
            }
            if (ganaste == false)
            {
                Escritor.EscribeAhorcado("");
                Escritor.EscribeAhorcado("Game over! La palabra era " + randomPalabra);
                Escritor.EscribeAhorcado("Presioná cualquier tecla para jugar de nuevo");
                Console.ReadKey();
                Escritor.LimpiaPantalla();
                Finalizar();
            }
        }

        public int Finalizar()
        {
            if (ganaste)
            {
                Escritor.EscribeAhorcado("");
                Escritor.EscribeAhorcado("ME GANASTE!");
                Escritor.EscribeAhorcado("Presioná cualquier tecla para avanzar");
                Console.ReadKey();
                Escritor.LimpiaPantalla();
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
