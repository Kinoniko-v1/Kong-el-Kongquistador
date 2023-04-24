using Minijuegos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utilidades
{
    public static class Testing
    {
        // Modificar esta clase lo que haga falta, no es necesario subirla a GitHub pero no genera ningún inconveniente
        static public void Ejecutar() // Usarlo como método Main()
        {
            IMiniJuego KongJuego = new KongGame();
            KongJuego.Iniciar();
        }
    }
}
