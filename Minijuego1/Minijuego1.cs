using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Media;
using NAudio.Wave;
using Utilidades;

namespace Minijuegos
{
    public class Minijuego1 : IMiniJuego
    {
        private static string[] palabras = { "quark", "nave", "alien", "planeta", "estrella", "galaxia", "satelite", "astronauta", "exploracion", "orbita", "supernova", "telescopio", "cometa", "meteorito", "constelacion", "eclipse", "cosmos", "espacio", "gravedad", "luna", "marte", "nebulosa", "sistema", "nuclear", "tierra", "cohete", "mision" };

        private static Random random = new Random();

        private static int randomNumero = random.Next(palabras.Length);
        private static String randomPalabra = palabras[randomNumero];

        private int numeroIntentos = 6;
        private int partesCuerpo = 0;

        private String[] letrasAdivinadas = new String[randomPalabra.Length];

        List<string> letrasUsadas = new List<string>();
        public Minijuego1()
        {
            Escritor.EscribirIzq("Minijuego Uno - Objeto creado");
        }
        public void Iniciar()
        {
            Escritor.Escribir("MiniJuego Uno - ejecutándose", 0, 0);

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
            bool ganasteAhorcado = false;
            while (numeroIntentos > 0 && ganasteAhorcado == false)
            {
                Escritor.EscribeAhorcado("");
                Escritor.EscribeAhorcado("¿Qué letra elegís?");
                String letraElegida = Console.ReadLine().ToLower();

                if (letraElegida.Length == 1 && char.IsLetter(letraElegida[0]) && !letrasUsadas.Contains(letraElegida))
                {
                    Console.Clear();
                    if (randomPalabra.Contains(letraElegida))
                    {
                        letrasAdivinadas[randomPalabra.IndexOf(letraElegida)] = letraElegida;
                        Escritor.EscribeAhorcado("Acertaste la letra");
                        //PLAY SOUND
                        var playerLetraSi = new SoundPlayer(@"Sonidos\jump.wav");
                        playerLetraSi.Play();

                    }
                    else
                    {
                        partesCuerpo++;
                        numeroIntentos--;
                        Escritor.EscribeAhorcado("Esa letra no está");
                        //PLAY SOUND
                        var playerLetraNo = new SoundPlayer(@"Sonidos\explosion.wav");
                        playerLetraNo.Play();
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
                        //var player = new SoundPlayer(@"D:\Martin\CS\C#_QuarkAcademy\GameJam03\Sonidos\Laser_Shoot.wav");
                        //var player = new SoundPlayer(@"D:\Martin\CS\C#_QuarkAcademy\GameJam03\00_AhorcadoMVP\Domain_AhorcadoMVP\Sonidos\Laser_Shoot.wav");
                        var playerGana = new SoundPlayer(@"Sonidos\recover.wav");
                        playerGana.Play();

                        numeroIntentos = 0;
                        ganasteAhorcado = true;
                        //Finalizar();
                    }

                }
                else
                {
                    if (letraElegida.Length != 1)
                    {
                        Escritor.EscribirIzq("Ingresaste más de una letra");
                    }
                    else if (letrasUsadas.Contains(letraElegida))
                    {
                        Escritor.EscribirIzq("Ya elegiste esa letra");
                    }
                    else
                    {
                        Escritor.EscribirIzq("Lo que tocaste no es una letra");
                    }
                    Escritor.EscribirIzq("Por favor ingresá un caracter válido");
                }
            }
            if (ganasteAhorcado == false)
            {
                //PLAY SOUND
                //var player = new SoundPlayer(@"D:\Martin\CS\C#_QuarkAcademy\GameJam03\Sonidos\evilLaugh.wav");
                var playerPierde = new SoundPlayer(@"Sonidos\evilLaugh.wav");
                playerPierde.Play();
                Escritor.EscribeAhorcado("");
                Escritor.EscribeAhorcado("Game over! La palabra era " + randomPalabra);
                Escritor.EscribeAhorcado("Presioná cualquier tecla para jugar de nuevo");
                Console.ReadKey();
                Escritor.LimpiaPantalla();
                //Volver a iniciar hasta que se gane?
                Iniciar();
                Actualizar();
            }
        }

        public void Finalizar()
        {
            Escritor.EscribeAhorcado("");
            Escritor.EscribeAhorcado("ME GANASTE!");
            Escritor.EscribeAhorcado("Presioná cualquier tecla para avanzar");
            Console.ReadKey();
            Escritor.LimpiaPantalla();
            //Escritor.EscribirIzq("Minijuego1 finalizado, pasando a Minijuego2");
        }
    }
}
