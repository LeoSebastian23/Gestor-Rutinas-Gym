using Gestor_de_Rutinas___GYM.Views;

namespace Gestor_de_Rutinas___GYM
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // Inicializa la configuración de la aplicación
            ApplicationConfiguration.Initialize();

            // Abre el formulario de clientes(FormClientes)
            //Application.Run(new FormClientes());

            // Abre el formulario de Ejercicios Base
            //Application.Run(new FormEjercicioBase());

            // Abre el formulario de Rutina
            //Application.Run(new FormRutina());

            // Abre Menu Principal
            Application.Run(new MenuPrincipal());
        }
    }
}