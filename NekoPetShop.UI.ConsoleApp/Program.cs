using System;
using NekoPetShop.UI.ConsoleApp;

namespace NekoPetShop.UI.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Console.Title = "NEKO-PetShop";
            StartUpView startUpView = new StartUpView();
            startUpView.Initialize();
        }
    }
}
