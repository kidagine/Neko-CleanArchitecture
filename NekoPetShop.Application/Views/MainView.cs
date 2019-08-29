using System;
using System.Collections.Generic;
using System.Threading;
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
            petService.InitializeData();
            ShowMenuLayoutASCII();
            ShowPetListLayout();
            ShowPetListData(petService.GetPets());
            Console.ReadLine();
        }

        private void ShowMenuLayoutASCII()
        {
            ASCIIAnimator.Instance.CreateASCIIAnimation(FILEPATHMENULAYOUT, 0, 0);
        }

        private void ShowPetListLayout()
        {
            string listOfVideosText = "LIST OF PETS";
            Console.SetCursorPosition((Console.WindowWidth - listOfVideosText.Length) / 2, 4);
            Console.WriteLine(listOfVideosText);
            string listTabs = "|  #      NAME      ANIMAL      BIRTHDATE      SOLD DATE      COLOR      PREVIOUS OWNER      PRICE";
            Console.SetCursorPosition(18, 9);
            Console.WriteLine(listTabs);
            string spacingTabText = "|----------------------------------------------------------------------------------------------------";
            Console.SetCursorPosition(18, 10);
            Console.WriteLine(spacingTabText);
        }

        private void ShowPetListData(List<Pet> petsList)
        {
            int countTop = 11;
            foreach (Pet p in petsList)
            {
                string videoListing = ($"|  {p.Id} {GetFixedSpacing(p.Id.ToString().Length, 5)} {p.Name} {GetFixedSpacing(p.Name.Length, 8)} {p.Type} {GetFixedSpacing(p.Type.ToString().Length, 10)} {p.Birthdate.ToString("dd/MM/yyyy")} {GetFixedSpacing("dd/MM/yyyy".Length, 13)} {p.SoldDate.ToString("dd/MM/yyyy")} {GetFixedSpacing("dd/MM/yyyy".Length, 13)} {p.Color} {GetFixedSpacing(p.Color.ToString().Length, 9)} {p.PreviousOwner} {GetFixedSpacing(p.PreviousOwner.ToString().Length, 18)} {p.Price}$");
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
            UserMenu();
        }

        private string GetFixedSpacing(int propertyLength, int maxSpacing)
        {
            string fixedSpacing = "";
            int spacingToAdd = maxSpacing - propertyLength;
            for (int i = 0; i < spacingToAdd; i++)
            {
                fixedSpacing += " ";
            }
            return fixedSpacing;
        }

        private void UserMenu()
        {
            bool allowOptionChoosing = true;
            Console.SetCursorPosition(0, 11);
            ConsoleKeyInfo cki;
            do
            {
                while (Console.KeyAvailable == false)
                    Thread.Sleep(250);
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.D0)
                {
                    allowOptionChoosing = false;
                    CreatePet();
                }
                else if (cki.Key == ConsoleKey.D1)
                {
                    allowOptionChoosing = false;
                    DeletePet();
                }
                else if (cki.Key == ConsoleKey.D2)
                {
                    allowOptionChoosing = false;
                    UpdatePet();
                }
                else if (cki.Key == ConsoleKey.D3)
                {
                    allowOptionChoosing = false;
                    SearchPetsByType();
                }
                else if (cki.Key == ConsoleKey.D4)
                {
                    allowOptionChoosing = false;
                    SortPetsByPrice();
                }
                else if (cki.Key == ConsoleKey.D5)
                {
                    allowOptionChoosing = false;
                    GetCheapestPets();
                }
            } while (allowOptionChoosing);
        }

        private void CreatePet()
        {
            DateTime birthdate;
            DateTime soldDate;

            Console.WriteLine("-Add-");
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Birthdate:");
            Console.WriteLine("format(dd/mm/yyyy)");
            while (!DateTime.TryParse(Console.ReadLine(), out birthdate))
            {
                Console.WriteLine("try again bleach");
            }
            Console.WriteLine();
            Console.WriteLine("Sold date:");
            Console.WriteLine("format(dd/mm/yyyy)");
            while (!DateTime.TryParse(Console.ReadLine(), out soldDate))
            {
                Console.WriteLine("try again bleach");
            }
            Console.WriteLine();
            Console.WriteLine("Color:");
            string color = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Previous owner:");
            string previousOwner = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Price:");
            double price = Double.Parse(Console.ReadLine());
            Console.WriteLine();
            petService.CreatePet(name, AnimalType.Goat, birthdate, soldDate, color, previousOwner, price);
            ClearPetList();
            ShowPetListData(petService.GetPets());
        }

        private void DeletePet()
        {
            Console.WriteLine("-Delete-");
            Console.WriteLine("Choose id: ");
            int id = int.Parse(Console.ReadLine());
            petService.DeletePet(id);
            ClearPetList();
            ShowPetListData(petService.GetPets());
        }

        private void UpdatePet()
        {
            Console.WriteLine("-Update-");
            Console.WriteLine("Choose id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Birthdate: ");
            DateTime birthdate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Sold date: ");
            DateTime soldDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Color: ");
            string color = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Previous owner: ");
            string previousOwner = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Price: ");
            double price = Double.Parse(Console.ReadLine());
            Console.WriteLine();
            petService.UpdatePet(id, name, AnimalType.Goat, birthdate, soldDate, color, previousOwner, price);
            ClearPetList();
            ShowPetListData(petService.GetPets());
        }

        private void SearchPetsByType()
        {
            int selection;
            Console.WriteLine("-Search-");
            foreach (AnimalType item in Enum.GetValues(typeof(AnimalType)))
            {
                Console.WriteLine($"{(int)item}: {item}");
            }
            while(!int.TryParse(Console.ReadLine(), out selection))
            {
                Console.WriteLine("try again bleach");
            }
            List<Pet> filteredPetsList = petService.SearchPetsByType((AnimalType)selection);
            ClearPetList();
            ShowPetListData(filteredPetsList);
        }

        private void SortPetsByPrice()
        {
            bool isAscending;
            int selection;
            Console.WriteLine("-Sort-");
            Console.WriteLine("0 From cheap");
            Console.WriteLine("1 From pricey");
            while (!int.TryParse(Console.ReadLine(), out selection))
            {
                Console.WriteLine("try again bleach");
            }
            if (selection == 0)
            {
                isAscending = false;
                List<Pet> filteredPetsList = petService.SortPetsByPrice(isAscending);
                ClearPetList();
                ShowPetListData(filteredPetsList);
            }
            else
            {
                isAscending = true;
                List<Pet> filteredPetsList = petService.SortPetsByPrice(isAscending);
                ClearPetList();
                ShowPetListData(filteredPetsList);
            }
        }

        private void GetCheapestPets()
        {
            Console.WriteLine("-Cheapest-");
            List<Pet> filteredPetsList = petService.GetCheapestPets();
            ClearPetList();
            ShowPetListData(filteredPetsList);
        }

        private void ClearPetList(int lengthToDelete = 24)
        {
            int topCount = 11;
            for (int i = 0; i < lengthToDelete; i++)
            {
                Console.SetCursorPosition(0, topCount);
                Console.Write(new string(' ', 500));
                topCount++;
            }

            topCount = 11;
            int listDefaultLength = 21;
            for (int i = 0; i < listDefaultLength; i++)
            {
                Console.SetCursorPosition(18, topCount);
                Console.Write('|');
                topCount++;
            }
        }
    }
}
