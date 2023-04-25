using System;
using System.Drawing;

namespace Minijuegos.Minijuego3
{
    class Jugador
    {
        public Point posicion = new Point();
        private int ancho;
        private int alto;
        private int velocidadX;
        private int velocidadY;
        private bool saltando;

        public int Alto { get => alto; }
        public Jugador(int coordX, int coordY)
        {
            posicion.X = coordX;
            posicion.Y = coordY;
            ancho = 3;
            alto = 3;
            velocidadX = 0;
            velocidadY = 0;
            saltando = false;
        }

        public void Dibujar()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (velocidadY > 0)
            {
                Console.SetCursorPosition(posicion.X, posicion.Y);
                Console.Write("\\o/");
                Console.SetCursorPosition(posicion.X, posicion.Y + 1);
                Console.Write(" | ");
            }
            else
            {
                Console.SetCursorPosition(posicion.X, posicion.Y);
                Console.Write(" o ");
                Console.SetCursorPosition(posicion.X, posicion.Y + 1);
                Console.Write("<|>");
            }
            Console.SetCursorPosition(posicion.X, posicion.Y + 2);
            Console.Write("/ \\");
            Console.ForegroundColor = ConsoleColor.White;
        }
        #region Métodos de Inputs
        public void MoverIzq() { velocidadX = -1; }

        public void MoverDer() { velocidadX = 1; }

        public void Saltar()
        {
            if (!saltando)
            {
                velocidadY = -4;
                saltando = true;
            }
        }
        public void PararSalto()
        {
            if (velocidadY > 5)
            {
                saltando = false;
            }
        }
        #endregion
        public void Actualizar()
        {
            // Actualizar posicion en X y en Y
            posicion.X += velocidadX;
            posicion.Y += velocidadY;

            // Aplicar Graveadad
            if (saltando)
                velocidadY++;
            else
                velocidadY = 0;

            PararSalto();

            // Limita la posición en pantalla (para no salirse de los marcos)
            if (posicion.X < 5)
                posicion.X = 5;
            else if (posicion.X > 154)
                posicion.X = 154;

            if (posicion.Y > 31 && posicion.X < 150)
                posicion.Y = 31;
            else if (posicion.Y < 5)
                posicion.Y = 5;
        }
        public void ColisionPiso(Plataforma plataforma) //Funciona bien
        {
            if (posicion.Y <= plataforma.GetTop() && posicion.Y + Alto >= plataforma.GetTop()
                && posicion.X >= plataforma.GetLeft()-1 && posicion.X + ancho <= plataforma.GetRight()+1)
            {
                velocidadY = 0;
                posicion.Y = plataforma.GetTop() - Alto;
                saltando = false;
            }
        }
        public void ColisionTecho(Plataforma plataforma)
        {
            if (posicion.Y <= plataforma.GetBottom() && posicion.Y + Alto >= plataforma.GetBottom()
                && posicion.X >= plataforma.GetLeft()-1 && posicion.X + ancho <= plataforma.GetRight()+1)
            { 
                posicion.Y = plataforma.GetBottom();
            }
        }
        public bool ColisionaCon(Bala bala)
        {
            if (bala.posicion.X > posicion.X && bala.posicion.X < posicion.X + ancho - 1
                && bala.posicion.Y >= posicion.Y && bala.posicion.Y <= posicion.Y + alto - 1)
                return true;
            else
                return false;
        }
    }
}
