using System;
using System.Collections.Generic;
using System.Text;
using Utilidades;

namespace Minijuegos
{
    public class Minijuego2 : IMiniJuego
    {
        public Minijuego2()
        {
            Escritor.EscribirIzq("Minijuego Dos - Objeto creado");
        }
        public void Iniciar()
        {
            Escritor.Escribir("MiniJuego Dos - ejecutándose", 0, 0);
        }

        public void Actualizar()
        {

        }

        public void Finalizar()
        {
        }
    }
}

