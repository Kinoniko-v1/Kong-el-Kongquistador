using Minijuegos.Minijuego3;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using Utilidades;

namespace Minijuegos
{
    public class KongGame : IMiniJuego
    {
        private Plataforma[] plataformas;
        private Bala[] balas;
        Jugador jugador;

        private int vidas = 3;
        private bool jugando = true;
        private bool victoria = false;
        private Point objetivo = new Point();
        public KongGame()
        {
            // Inicializar objetos
            objetivo.X = 12;
            objetivo.Y = 10;
            jugador = new Jugador(10, 31);
            plataformas = new Plataforma[]
            {
                new Plataforma(4, 34, 145, 3),  // suelo
                new Plataforma(10, 26, 125, 3),  // primer piso
                new Plataforma(24, 18, 125, 3), // segundo piso
                new Plataforma(4, 10, 125, 3)   // último piso
            };
            balas = new Bala[]
            {
                new Bala(150,33,-2),
                new Bala(4,25,2),
                new Bala(150,17,-2),
                new Bala(4,9,2)
            };
        }
        #region Métodos GameLoop
        public void Iniciar()
        {
            // Inicializa y controla el estado del minijuego
            Escritor.Escribir("MiniJuego Kong - ejecutándose", 0, 0);
            Tutorial();
            Actualizar();
        }
        private void Reiniciar()
        {
            
            jugador = new Jugador(10, 31);
            jugando = true;
            Thread.Sleep(300);
            Actualizar();
        }
        public void Actualizar()
        {
            string s = "Vidas: " + vidas;
            // Permite la ejecuión del GameLoop
            while (jugando)
            {
                // Disponer la pantalla
                Console.Clear();
                Ventana.DibujarMarco();
                Console.SetCursorPosition(Console.WindowWidth - s.Length - 3, 3);
                Console.Write(s);

                DibujarGameObjects();

                // Recibir Inputs del jugador y Actualizar GameObject
                Entradas();
                ActualizarGameObjects();

                // Chequear colisiones
                foreach (Plataforma plataforma in plataformas)
                {
                    jugador.ColisionTecho(plataforma);
                    jugador.ColisionPiso(plataforma);
                }

                // Comprobar si termino la partida o se debe reiniciar el gameLoop
                if (ComprobarDerrota())
                    jugando = false;
                if (ComprobarVictoria())
                {
                    jugando = false;
                    victoria = true;
                }

                // Pausa el juego para mantener la velocidad
                System.Threading.Thread.Sleep(35);
            }

            if (vidas > 0 && !victoria)
                Reiniciar();
            else if (vidas <= 0)
                victoria = false;
        }
        public int Finalizar()
        {
            // Se ejecuta una vez finalizado el minijuego para realizar una transición
            if (victoria)
            {
                AnimarVictoria();
                return 1;
            }
            else
            {
                AnimarDerrota();
                return 0;
            }
        }
        private void Entradas()
        {
            // Manejar los Inputs
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow)
                    jugador.MoverIzq();
                else if (key.Key == ConsoleKey.RightArrow)
                    jugador.MoverDer();
                else if (key.Key == ConsoleKey.UpArrow)
                    jugador.Saltar();
            }
        }
        #endregion

        #region GameObjects
        private void DibujarGameObjects()
        {
            // Dibujar los GameObjects
            jugador.Dibujar();
            foreach (Plataforma plataforma in plataformas)
            {
                plataforma.Dibujar();
            }
            foreach (Bala bala in balas)
            {
                bala.Dibujar();
            }
            DibujarObjetivo();
        }
        private void ActualizarGameObjects()
        {
            jugador.Actualizar();
            foreach (Bala bala in balas)
            {
                bala.Actualizar();
            }
        }
        private void DibujarObjetivo()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(5, 6);
            Console.Write("      _");
            Console.SetCursorPosition(5, 7);
            Console.Write("     c .");
            Console.SetCursorPosition(5, 8);
            Console.Write("\\_   /\\");
            Console.SetCursorPosition(5, 9);
            Console.Write("  \\_| ||");
            Console.ForegroundColor = ConsoleColor.White;
        }
        #endregion

        #region Condiciones de victoria o derrota
        private bool ComprobarVictoria()
        {
            // Chequear si el jugador alcanzo el objetivo
            if (jugador.posicion.X <= objetivo.X && jugador.posicion.Y <= objetivo.Y)
            {
                Escritor.EscribirTitulo("Ganaste!");
                Console.ReadKey();
                victoria = true;
                return true;
            }
            return false;
        }
        private bool ComprobarDerrota()
        {
            // Chequear si el jugador cayo
            if (jugador.posicion.X >= 151 && jugador.posicion.Y >= 31)
            {
                Console.WriteLine("Game over!");
                vidas--;
                return true;
            }
            // Chequear si la bala golpeo al jugador
            foreach (Bala bala in balas)
            {
                if (jugador.ColisionaCon(bala))
                {
                    Console.WriteLine("Game over!");
                    vidas--;
                    return true;
                }
            }

            return false;
        }
        private void AnimarVictoria()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(5, 6);
            Console.Write("      X");
            Thread.Sleep(500);
            Console.SetCursorPosition(5, 7);
            Console.Write("     X X");
            Thread.Sleep(500);
            Console.SetCursorPosition(5, 8);
            Console.Write("XX   XX");
            Thread.Sleep(500);
            Console.SetCursorPosition(5, 9);
            Console.Write("  XXX XX");
            Thread.Sleep(500);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void AnimarDerrota()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(jugador.posicion.X,jugador.posicion.Y);
            Console.Write("XXX");
            Thread.Sleep(500);
            Console.SetCursorPosition(jugador.posicion.X, jugador.posicion.Y+1);
            Console.Write(" X ");
            Thread.Sleep(500);
            Console.SetCursorPosition(jugador.posicion.X, jugador.posicion.Y+2);
            Console.Write("X X");
            Thread.Sleep(500);
            Console.ForegroundColor = ConsoleColor.White;
        }

        #endregion

        private void Tutorial()
        {

            Console.Clear();
            Ventana.DibujarMarco();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            string s1 = "Este es el último desafío, acá se decide todo...";
            string s2 = "Las reglas son fáciles, te mueves con las flechas del teclado:";
            string s3 = "Mover izquierda: <- | Mover derecha: -> | Saltar: ^ (flecha arriba)";
            string s4 = "Si alcanzas a mi versión inferior ganas, si mueres 3 veces pierdes...";
            string vacia = "";

            List<string> texto = new List<string> { s1,vacia, s2, vacia, s3, vacia, s4 };
            Escritor.EscribirLista(texto, 157 / 2 - s1.Length / 2, Console.WindowHeight / 2 - texto.Count);
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = true;
            Console.ReadKey();
            Console.CursorVisible = false;
            Console.Clear();
            Ventana.DibujarMarco();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Escritor.Escribir("Este eres tú:", 10,7);
            Jugador jugador_temp = new Jugador(25, 7);
            jugador_temp.Dibujar();

            Escritor.Escribir("Este soy yo:", 40,7);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(55, 7);
            Console.Write("      _");
            Console.SetCursorPosition(55, 8);
            Console.Write("     c .");
            Console.SetCursorPosition(55, 9);
            Console.Write("\\_   /\\");
            Console.SetCursorPosition(55, 10);
            Console.Write("  \\_| ||");

            Escritor.Escribir("Esquiva esto:", 85,7);
            Bala bala_temp = new Bala(100, 7,0);
            bala_temp.Dibujar();

            Escritor.EscribirTitulo("¿Estás listo?");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
