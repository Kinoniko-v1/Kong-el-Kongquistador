using System;
using System.Collections.Generic;
using System.Text;

namespace Utilidades
{
    public interface IMiniJuego
    {
        // Interfaz para poder llamar al Presentaor o GameManager de cada juego desde la Máquina de Estados
        public void Iniciar();
        public void Actualizar();
        public void Finalizar();
    }
}
