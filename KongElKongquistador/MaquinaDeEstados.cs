using Minijuegos;
using System;
using Utilidades;

namespace GJN3_Diseño
{
    enum EstadoDeJuego {terminado,Minijuego1,Minijuego2,Minijuego3 }

    // Maquina de Estados Finitos,

    internal class MaquinaDeEstados
    {
        private EstadoDeJuego estado;

        private readonly IMiniJuego miniJuego1;
        private readonly IMiniJuego miniJuego2;
        private readonly IMiniJuego KongJuego;

        private int vicAcumuladas = 0;

        public MaquinaDeEstados()
        {
            Escritor.EscribirIzq("Máquina creada");

            miniJuego1 = new Minijuego1();
            miniJuego2 = new Minijuego2();
            KongJuego = new KongGame();

            estado = EstadoDeJuego.Minijuego1;
        }

        public void Iniciar()
        {
            // Mientras el estado no sea terminado (luego de los 3 minijuegos), se ejecuta uno y se asigna
            // una referencia al siguiente hasta terminar.
            while (estado != EstadoDeJuego.terminado)
            {
                switch (estado)
                {
                    case EstadoDeJuego.Minijuego1:
                        miniJuego1.Iniciar();
                        miniJuego1.Actualizar();
                        vicAcumuladas += miniJuego1.Finalizar();

                        estado = EstadoDeJuego.Minijuego2;
                        Console.ReadKey();
                        break;

                    case EstadoDeJuego.Minijuego2:
                        miniJuego2.Iniciar();
                        vicAcumuladas += miniJuego2.Finalizar();
                        estado = EstadoDeJuego.Minijuego3;
                        Console.ReadKey();
                        break;

                    case EstadoDeJuego.Minijuego3:
                        KongJuego.Iniciar();
                        vicAcumuladas += KongJuego.Finalizar();
                        estado = EstadoDeJuego.terminado;
                        Console.ReadKey();
                        break;
                }

                Final();
            }
        }
        private void Final()
        {
            EstadoDeJuego estadoAnt;
            if (estado != 0)
                estadoAnt = estado - 1;
            else estadoAnt = estado;
            Escritor.EscribirDer("Juego: " + estadoAnt +" - Finalizado.");
        }
    }
}
