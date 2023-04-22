using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Minijuegos.Minijuego3
{
    class Bala
    {
        public Point posicion = new Point();
        private int velocidad;

        public Bala(int coordX, int coordY, int velocidad)
        {
            posicion.X = coordX;
            posicion.Y = coordY;
            this.velocidad = velocidad;
        }
        public void Dibujar()
        {
            Console.SetCursorPosition(posicion.X, posicion.Y);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("¤");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Actualizar()
        {
            posicion.X += velocidad;
            Reposicionar();
        }
        private void Reposicionar()
        {
            if (posicion.X <= 4)
            {
                posicion.X = 4;
                velocidad *= -1;
            }
            if (posicion.X >= 156)
            {
                posicion.X = 156;
                velocidad *= -1;
            }
        }
    }
}
