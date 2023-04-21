using GJN3_Diseño;
using System;
using System.Drawing;
using Utilidades;

namespace GJN3_Diseño
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ventana.AjustarVentana(); // Este método no se puede modificar
            //Escritor.EscribirTitulo("Hello World! - Inicia class Program\n");
            Ventana.DibujarMarco();

            /* El proyecto final arranca con estas dos lineas. 
               ** Pueden descomentarlas, pero luego comentenlas denuevo **
            */ 

            //MaquinaDeEstados mef = new MaquinaDeEstados();
            //mef.Iniciar(); 


            // Para testear cada juego por separado, modifiquen este método de la clase Testing
            Testing.Ejecutar();  



            Escritor.Escribir("Fin del programa. Presione una tecla para continuar...",35,15);
            Console.ReadKey();
        }
    }
}
