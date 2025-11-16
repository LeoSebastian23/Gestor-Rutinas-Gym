using Gestor_de_Rutinas___GYM.Views;

namespace Gestor_de_Rutinas___GYM
{
    internal static class Program
    {
        [STAThread]   // PARA SAVEFILEDIALOG, EXCEL y PDF
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MenuPrincipal());
        }
    }
}
