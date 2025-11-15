using Gestor_de_Rutinas___GYM.Views;

namespace Gestor_de_Rutinas___GYM
{
    internal static class Program
    {
        static void Main()
        {

            // Inicializa la configuración de la aplicación
            ApplicationConfiguration.Initialize();

            // Abre Menu Principal
            Application.Run(new MenuPrincipal());
        }
    }
}