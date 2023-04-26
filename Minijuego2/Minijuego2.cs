using JuegoRetro;
using System;
using System.Collections.Generic;
using System.Text;
using Utilidades;

namespace Minijuegos
{
    public class Minijuego2 : IMiniJuego
    {
        int valor = 0;
        public Minijuego2()
        {
            //Escritor.EscribirIzq("Minijuego Dos - Objeto creado");
        }
        public void Iniciar()
        {
            //Escritor.Escribir("MiniJuego Dos - ejecutándose", 0, 0);
            valor = new Vista().MostrarMenu();
        }

        public void Actualizar()
        {

        }

        public int Finalizar()
        {
            Console.Clear();
            Ventana.DibujarMarco();
            Console.ForegroundColor= ConsoleColor.DarkRed;
            if (valor == 1) Escritor.Escribir("¡Si no lo consigo en esta vida, alguna otra vida lo hará!", 52, 11);
            if (valor == 0) Escritor.Escribir("Cada victoria es solo una piedra más en el camino hacia mi dominio final.", 38, 11);
            Console.ForegroundColor = ConsoleColor.White;
            return valor;
        }
    }
}

