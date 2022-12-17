using Berzerk.levels;
namespace Berzerk
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            LevelTemplate firstLevel = new FirstLevel();
            Application.Run(firstLevel);
        }
    }
}