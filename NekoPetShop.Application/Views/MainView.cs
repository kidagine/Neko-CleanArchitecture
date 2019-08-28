using System;
using System.Collections.Generic;
using NekoPetShop.Application.Util;
using NekoPetShop.Core.ApplicationService;
using NekoPetShop.Core.Entity;

namespace NekoPetShop.Application.Views
{
    class MainView : IView
    {
        private readonly IPetService petService;
        private readonly string FILEPATHMENULAYOUT = AppContext.BaseDirectory + "\\TxtFiles\\MainMenuLayoutText.txt";


        public MainView(IPetService petService)
        {
            this.petService = petService;
        }

        public void Initialize()
        {
            Console.Clear();
            ShowMenuLayoutASCII();
            ShowPetList();
            Console.ReadLine();
        }

        private void ShowMenuLayoutASCII()
        {
            ASCIIAnimator.Instance.CreateASCIIAnimation(FILEPATHMENULAYOUT, 0, 0);
        }

        private void ShowPetList()
        {
            ShowPetListLayout();
            ShowPetListData(petService.GetPets());
            //ClearUserConsole();
        }

        private void ShowPetListLayout()
        {
            string listOfVideosText = "LIST OF PETS";
            Console.SetCursorPosition((Console.WindowWidth - listOfVideosText.Length) / 2, 4);
            Console.WriteLine(listOfVideosText);
            string listTabs = "|  #        NAME    ANIMAL    BIRTHDATE    SOLD DATE    COLOR    PREVIOUS OWNER    PRICE";
            Console.SetCursorPosition(18, 7);
            Console.WriteLine(listTabs);
            string spacingTabText = "|----------------------------------------------------------------------------------------------------";
            Console.SetCursorPosition(18, 8);
            Console.WriteLine(spacingTabText);
        }

        private void ShowPetListData(List<Pet> petsList)
        {
            int countTop = 9;
            foreach (Pet p in petsList)
            {
                string videoListing = ($"|{p.Id} {p.Name} {p.Type} {p.Birthdate} {p.SoldDate} {p.Color} {p.PreviousOwner} {p.Price}");
                Console.SetCursorPosition(18, countTop);
                Console.WriteLine(videoListing);
                countTop++;

                string spacingText = "|----------------------------------------------------------------------------------------------------";
                Console.SetCursorPosition(18, countTop);
                Console.WriteLine(spacingText);
                countTop++;
            }
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("");
        }
    }
}
