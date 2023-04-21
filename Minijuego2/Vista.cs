using System;
using System.Collections.Generic;
using System.Text;
using Utilidades;

namespace JuegoRetro
{
    internal class Vista
    {
        public void MostrarMenu()
        {
            GameLoop gameLoop = new GameLoop();
            int opcion;
            int posX = 11, posY = 7;
            do
            {
                Console.Clear();
                Ventana.DibujarMarco();
                Escritor.Escribir("¡Hola, 'P'layer espero que estes listo para perder!", posX, posY, true);
                Escritor.Escribir("En este minijuego tendrás que superar 3 laberintos, recogiendo todos los puntos", posX, posY + 1, true);
                Escritor.Escribir("de cada nivel para que así se desbloquee la puerta(K) y puedas avanzar.", posX, posY + 2, true);
                Escritor.Escribir("Pero no será tan sencillo, ya que un 'E'nemigo te estará persiguiendo >:)", posX, posY + 3, true);
                Escritor.Escribir("[1] Jugar - [0] Salir", posX, posY + 4, true);
                Console.SetCursorPosition(posX, posY + 5);
                Console.CursorVisible = true;
            } while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 0 || opcion > 1);

            if (opcion == 1) gameLoop.IniciarGameLoop();
        }
    }
}
