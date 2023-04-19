using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Minijuegos.Minijuego3
{
    class Plataforma
    {
        public Point posicion = new Point();
        private int ancho;
        private int alto;

        public Plataforma(int coordX, int coordY, int anchoPlataforma, int altoPlataforma)
        {
            posicion.X = coordX;
            posicion.Y = coordY;
            ancho = anchoPlataforma;
            alto = altoPlataforma;
        }

        public void Dibujar()
        {
            for (int i = 0; i < ancho; i++)
            {
                Console.SetCursorPosition(posicion.X + i, posicion.Y);
                Console.Write("-");
                Console.SetCursorPosition(posicion.X + i, posicion.Y + alto - 1);
                Console.Write("-");
            }
            for (int i = 1; i < alto - 1; i++)
            {
                Console.SetCursorPosition(posicion.X, posicion.Y + i);
                Console.Write("|");
                Console.SetCursorPosition(posicion.X + ancho - 1, posicion.Y + i);
                Console.Write("|");
            }
        }
        public int GetTop() { return posicion.Y; }

        public int GetBottom() { return posicion.Y + alto; }

        public int GetLeft() { return posicion.X; }

        public int GetRight() { return posicion.X + ancho; }
    }
}
