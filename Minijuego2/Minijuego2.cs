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
            Escritor.EscribirIzq("Minijuego Dos - Objeto creado");
        }
        public void Iniciar()
        {
            Escritor.Escribir("MiniJuego Dos - ejecutándose", 0, 0);
            valor = new Vista().MostrarMenu();
        }

        public void Actualizar()
        {

        }

        public int Finalizar()
        {
            return valor;
        }
    }
}

