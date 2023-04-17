using System;
using System.Collections.Generic;
using System.Text;
using Utilidades;

namespace Minijuegos
{
    public class Minijuego1 : IMiniJuego
    {
        public Minijuego1()
        {
            Escritor.EscribirIzq("Minijuego Uno - Objeto creado");
        }
        public void Iniciar()
        {
            Escritor.Escribir("MiniJuego Uno - ejecutándose", 0, 0);
        }

        public void Actualizar()
        {

        }

        public void Finalizar()
        {
        }
    }
}
