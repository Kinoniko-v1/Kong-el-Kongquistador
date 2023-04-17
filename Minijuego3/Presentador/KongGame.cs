using System;
using System.Collections.Generic;
using System.Text;
using Utilidades;

namespace Minijuegos
{
    public class KongGame : IMiniJuego
    {
        public KongGame()
        {
            Escritor.EscribirIzq("Minijuego Kong - Objeto creado");
        }
        public void Iniciar()
        {
            Escritor.Escribir("MiniJuego Kong - ejecutándose", 0, 0);
        }

        public void Actualizar()
        {

        }

        public void Finalizar()
        {

        }
    }
}
