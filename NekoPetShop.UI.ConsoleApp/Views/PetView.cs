using System;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;
using NekoPetShop.Core.Entity;
using NekoPetShop.Core.ApplicationService;
using NekoPetShop.UI.ConsoleApp.Util;

namespace NekoPetShop.UI.ConsoleApp
{
    class PetView : IView
    {
        private readonly IPetService petService;
        private readonly IOwnerService ownerService;
        private readonly string FILEPATHMENULAYOUT = AppContext.BaseDirectory + "\\TxtFiles\\MainMenuLayoutText.txt";


        public PetView(IPetService petService, IOwnerService ownerService)
        {
            this.petService = petService;
            this.ownerService = ownerService;
        }

        public void Initialize()
        {
            Console.Clear();
            ShowMenuLayoutASCII();
            ShowPetListLayout();
            ShowPetListData(petService.GetPets());
        }

        private void ShowMenuLayoutASCII()
        {
            ASCIIAnimator.Instance.CreateASCIIAnimation(FILEPATHMENULAYOUT, 0, 0);
        }

        private void ShowPetListLayout()
        {
            string listOfPetsText = "      -LIST OF PETS-";
            Console.SetCursorPosition((Console.WindowWidth - listOfPetsText.Length) / 2, 4);
            Console.WriteLine(listOfPetsText);
            string listTabs = "|  #      NAME      ANIMAL      BIRTHDATE      SOLD DATE      COLOR      PREVIOUS OWNER      PRICE";
            Console.SetCursorPosition(18, 10);
            Console.WriteLine(listTabs);
            string spacingTabText = "|----------------------------------------------------------------------------------------------------";
            Console.SetCursorPosition(18, 11);
            Console.WriteLine(spacingTabText);
        }

        private void ShowPetListData(List<Pet> petsList)
        {
            int countTop = 12;
            foreach (Pet p in petsList)
            {
                string petListing = ($"|  {p.Id} {GetFixedSpacing(p.Id.ToString().Length, 5)} {p.Name} {GetFixedSpacing(p.Name.Length, 8)} {p.Type} {GetFixedSpacing(p.Type.ToString().Length, 10)} {p.Birthdate.ToString("dd/MM/yyyy")} {GetFixedSpacing("dd/MM/yyyy".Length, 13)} {p.SoldDate.ToString("dd/MM/yyyy")} {GetFixedSpacing("dd/MM/yyyy".Length, 13)} {p.Color} {GetFixedSpacing(p.Color.ToString().Length, 9)} {p.PreviousOwner.FirstName} {p.PreviousOwner.LastName} {GetFixedSpacing(p.PreviousOwner.FirstName.ToString().Length + p.PreviousOwner.LastName.ToString().Length, 17)} {p.Price.ToString("C")}");
                Console.SetCursorPosition(18, countTop);
                Console.WriteLine(petListing);
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
            Console.SetCursorPosition(0, 12);
            ConsoleKeyInfo cki;
            do
            {
                while (Console.KeyAvailable == false)
                    Thread.Sleep(250);
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.D0)
                {
                    allowOptionChoosing = false;
                    SwitchToOwnerView();
                }
                else if (cki.Key == ConsoleKey.D1)
                {
                    allowOptionChoosing = false;
                    CreatePet();
                }
                else if (cki.Key == ConsoleKey.D2)
                {
                    allowOptionChoosing = false;
                    DeletePet();
                }
                else if (cki.Key == ConsoleKey.D3)
                {
                    allowOptionChoosing = false;
                    UpdatePet();
                }
                else if (cki.Key == ConsoleKey.D4)
                {
                    allowOptionChoosing = false;
                    SearchPetsByType();
                }
                else if (cki.Key == ConsoleKey.D5)
                {
                    allowOptionChoosing = false;
                    SortPetsByPrice();
                }
                else if (cki.Key == ConsoleKey.D6)
                {
                    allowOptionChoosing = false;
                    GetCheapestPets();
                }
            } while (allowOptionChoosing);
        }

        private void SwitchToOwnerView()
        {
            IView ownerView = new OwnerView(petService, ownerService);
            ownerView.Initialize();
        }

        private void CreatePet()
        {
            Console.WriteLine("-Add-");
            Console.WriteLine("Choose animal:");
            AnimalType type = SelectAnimalType();
            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Birthdate:");
            Console.WriteLine("format(dd/mm/yyyy)");
            DateTime birthdate;
            while (!DateTime.TryParseExact(Console.ReadLine(),"d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthdate))
            {
                ConsoleError();
            }
            Console.WriteLine();
            Console.WriteLine("Sold date:");
            Console.WriteLine("format(dd/mm/yyyy)");
            DateTime soldDate;
            while (!DateTime.TryParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out soldDate))
            {
                ConsoleError();
            }
            Console.WriteLine();
            Console.WriteLine("Color:");
            string color = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Previous owner:");
            Owner previousOwner = SelectPreviousOwner();
            Console.WriteLine();
            Console.WriteLine("Price:");
            double price;
            while (!Double.TryParse(Console.ReadLine(), out price))
            {
                ConsoleError();
            }
            Console.WriteLine();
            Pet pet = petService.NewPet(name, type, birthdate, soldDate, color, previousOwner, price);
            petService.CreatePet(pet);
            ClearPetList();
            ShowPetListData(petService.GetPets());
        }

        private void DeletePet()
        {
            Console.WriteLine("-Delete-");
            Console.WriteLine("Choose id:");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                ConsoleError();
            }
            petService.DeletePet(id);
            ClearPetList();
            ShowPetListData(petService.GetPets());
        }

        private void UpdatePet()
        {
            Console.WriteLine("-Update-");
            Console.WriteLine("Choose id:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Choose animal:");
            AnimalType type = SelectAnimalType();
            Console.WriteLine();
            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Birthdate:");
            Console.WriteLine("format(dd/mm/yyyy)");
            DateTime birthdate;
            while (!DateTime.TryParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthdate))
            {
                ConsoleError();
            }
            Console.WriteLine();
            Console.WriteLine("Sold date:");
            Console.WriteLine("format(dd/mm/yyyy)");
            DateTime soldDate;
            while (!DateTime.TryParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out soldDate))
            {
                ConsoleError();
            }
            Console.WriteLine();
            Console.WriteLine("Color:");
            string color = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Previous owner:");
            Owner previousOwner = SelectPreviousOwner();
            Console.WriteLine();
            Console.WriteLine("Price:");
            double price;
            while (!Double.TryParse(Console.ReadLine(), out price))
            {
                ConsoleError();
            }
            Console.WriteLine();
            Pet pet = petService.NewPet(name, type, birthdate, soldDate, color, previousOwner, price);
            petService.UpdatePet(id, pet);
            ClearPetList();
            ShowPetListData(petService.GetPets());
        }

        private void SearchPetsByType()
        {
            Console.WriteLine("-Search-");
            List<Pet> filteredPetsList = petService.SearchPetsByType(SelectAnimalType());
            ClearPetList();
            ShowPetListData(filteredPetsList);
        }

        private void SortPetsByPrice()
        {
            int selection;
            Console.WriteLine("-Sort-");
            Console.WriteLine("0 from cheap");
            Console.WriteLine("1 from pricey");
            while (!int.TryParse(Console.ReadLine(), out selection))
            {
                ConsoleError();
            }
            if (selection == 0)
            {
                SortType type = SortType.Ascending;
                List<Pet> filteredPetsList = petService.SortPetsByPrice(type);
                ClearPetList();
                ShowPetListData(filteredPetsList);
            }
            else
            {
                SortType type = SortType.Descending;
                List<Pet> filteredPetsList = petService.SortPetsByPrice(type);
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

        private Owner SelectPreviousOwner()
        {
            int selection;
            int max = 0;
            foreach (Owner o in ownerService.GetOwners())
            {
                Console.WriteLine($"{o.Id}: {o.FirstName}");
                max++;
            }
            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 0 || selection >= max)
            {
                Console.WriteLine(GetRandomizedInsult());
            }
            Owner owner = ownerService.FindOwnerById(selection);
            return owner;
        }

        private AnimalType SelectAnimalType()
        {
            int selection;
            int max = 0;
            foreach (AnimalType item in Enum.GetValues(typeof(AnimalType)))
            {
                Console.WriteLine($"{(int)item}: {item}");
                max++;
            }
            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 0 || selection >= max)
            {
                Console.WriteLine(GetRandomizedInsult());
            }
            AnimalType typeToReturn = (AnimalType)selection;
            return typeToReturn;
        }

        private void ClearPetList()
        {
            int topCount = 12;
            for (int i = 0; i < Console.LargestWindowHeight; i++)
            {
                Console.SetCursorPosition(0, topCount);
                Console.Write(new string(' ', Console.WindowWidth));
                topCount++;
            }

            topCount = 12;
            int listDefaultLength = 21;
            for (int i = 0; i < listDefaultLength; i++)
            {
                Console.SetCursorPosition(18, topCount);
                Console.Write('|');
                topCount++;
            }
        }

        private void ConsoleError()
        {
            Console.WriteLine(GetRandomizedInsult());
            Console.ReadLine();
            int lengthToDelete = 3;
            int topCount = Console.CursorTop - 3;
            for (int i = 0; i < lengthToDelete; i++)
            {
                Console.SetCursorPosition(0, topCount);
                Console.Write(new string(' ', 18));
                topCount++;
            }
            Console.SetCursorPosition(0, Console.CursorTop - 2);
        }

        private string GetRandomizedInsult()
        {
            string insultToReturn = "";
            Random random = new Random();
            int insultNumber = random.Next(1, 10);
            switch (insultNumber)
            {
                case 1:
                    insultToReturn = "wat is this dumville";
                    break;
                case 2:
                    insultToReturn = "nuh uh man";
                    break;
                case 3:
                    insultToReturn = "sucks.";
                    break;
                case 4:
                    insultToReturn = "i dun even man";
                    break;
                case 5:
                    insultToReturn = "is ur head typing";
                    break;
                case 6:
                    insultToReturn = "ur mom";
                    break;
                case 7:
                    insultToReturn = "thats just stoopid";
                    break;
                case 8:
                    insultToReturn = "try again u dum";
                    break;
                case 9:
                    insultToReturn = "u dun deserve a pet";
                    break;
                case 10:
                    insultToReturn = ":/";
                    break;
            }
            return insultToReturn;
        }
    }
}
