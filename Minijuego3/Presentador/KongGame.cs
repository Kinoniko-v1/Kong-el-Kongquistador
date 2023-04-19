using Minijuegos.Minijuego3;
using System;
using System.Collections.Generic;
using System.Text;
using Utilidades;

namespace Minijuegos
{
    public class KongGame : IMiniJuego
    {
        private readonly IVista _vista;

        private List<Plataforma> plataformas;
        private List<Bala> balas;
        Jugador jugador;

        private int vidas = 3;
        private bool jugando = true;
        private bool victoria = false;
        public KongGame()
        {
            // Inicializar objetos
            jugador = new Jugador(10, 31);
            plataformas = new List<Plataforma>
            {
                new Plataforma(4, 34, 145, 3),  // suelo
                new Plataforma(10, 26, 125, 3),  // primer piso
                new Plataforma(24, 18, 125, 3), // segundo piso
                new Plataforma(4, 10, 125, 3)   // último piso
            };
            balas = new List<Bala>
            {
                new Bala(150,33,-3),
                new Bala(4,25,3),
                new Bala(150,17,-3),
                new Bala(4,9,3)
            };

            
        }
        public void Iniciar()
        {
            // Inicializa y controla el estado del minijuego
            Escritor.Escribir("MiniJuego Kong - ejecutándose", 0, 0);
            Actualizar();
            Finalizar();
        }
        private void Reiniciar()
        {
            jugador = new Jugador(10, 31);
            jugando = true;
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
                    if (jugador.ColisionaCon(plataforma))
                    {
                        jugador.posicion.Y = plataforma.GetTop() - jugador.Alto;
                    }
                }

                // Comprobar si termino la partida
                if (ComprobarDerrota())
                    jugando = false;
                if(ComprobarVictoria())
                    jugando = false;

                // Pausa el juego para mantener la velocidad
                System.Threading.Thread.Sleep(35);
            }

            if (vidas > 0)
                Reiniciar();
        }

        public void Finalizar()
        {
            // Se ejecuta una vez finalizado el minijuego para realizar una transición
        }
        private void Entradas()
        {
            // Manejar los Inputs
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    jugador.MoverIzq();
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    jugador.MoverDer();
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    jugador.Saltar();
                }
            }
        }

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
        }
        private void ActualizarGameObjects()
        {
            jugador.Actualizar();
            foreach (Bala bala in balas)
            {
                bala.Actualizar();
            }
        }
        #endregion

        #region Condiciones de victoria o derrota
        private bool ComprobarVictoria()
        {
            // Chequear si el jugador alcanzo el objetivo
            if (jugador.posicion.X <= 8 && jugador.posicion.Y <= 10)
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
        #endregion
    }
}