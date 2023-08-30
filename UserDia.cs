using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_UML2
{
    public class UserDia
    {
        MenuCatalog _menuCatalog;
        public UserDia(MenuCatalog menuCatalog)
        {
            _menuCatalog = menuCatalog;
        }

        public Pizza GetNewPizza()
        {
            Pizza pizzaItem = new Pizza();
            Console.Clear();
            Console.WriteLine("|  Creating New Pizza  |");
            Console.WriteLine();
            Console.Write("Enter pizza name: ");
            pizzaItem.Name = Console.ReadLine();

            string input = "";
            Console.Write("Enter price for pizza: ");

            try
            {
                input = Console.ReadLine();
                pizzaItem.Price = Int32.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Invalid Input '{input}' - Message: {e.Message}");
                throw;
            }

            input = "";
            Console.Write("Enter pizza number: ");

            try
            {
                input = Console.ReadLine();
                pizzaItem.Number = Int32.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Invalid Input '{input}' - Message: {e.Message}");
                throw;
            }

            return pizzaItem;
        }
        public int MainMenuChoice(List<string> menuItems)
        {
            Console.Clear();
            Console.WriteLine("| Bigmamma Pizza Menu |");
            Console.WriteLine();
            Console.WriteLine("Options:");
            foreach (string choice in menuItems)
            {
                Console.WriteLine(choice);
            }

            Console.Write("Enter your option#: ");
            string input = Console.ReadKey().KeyChar.ToString();

            try
            {
                int result = Int32.Parse(input);
                return result;
            }

            catch (FormatException)
            {
                Console.WriteLine($"Invalid Input '{input}'");
            }
            return -1;
        }
        public void UpdatePizza()
        {
            Console.Clear();
            Console.WriteLine("| Updating Pizza |");
            Console.WriteLine();

            Console.Write("Enter pizza number: ");
            string input = Console.ReadLine();

            int pizzaNumber;

            if (!int.TryParse(input, out pizzaNumber))
            {
                Console.WriteLine($"Invalid Input '{input}', please enter a valid pizza number");
                return;
            }

            Pizza existingPizza = _menuCatalog.FindPizzaByNumber(pizzaNumber);

            if (existingPizza == null)
            {
                Console.WriteLine($"No pizza with number {pizzaNumber} was found");
                return;
            }

            Pizza updatedPizza = GetNewPizza();
            _menuCatalog.Update(pizzaNumber, updatedPizza);

            Console.WriteLine($"Pizza number {pizzaNumber} updated: {updatedPizza}");
        }

        public void DeletePizza()
        {
            Console.Clear();
            Console.WriteLine("| Deleting Pizza |");
            Console.WriteLine();

            Console.Write("Enter pizza number: ");
            string input = Console.ReadLine();

            int pizzaNumber;

            if (!int.TryParse(input, out pizzaNumber))
            {
                Console.WriteLine($"Invalid Input '{input}', please enter a valid pizza number");
                return;
            }

            Pizza existingPizza = _menuCatalog.FindPizzaByNumber(pizzaNumber);
            if (existingPizza == null)
            {
                Console.WriteLine($"No pizza with number {pizzaNumber} was found");
                return;
            }

            _menuCatalog.Delete(pizzaNumber);
            Console.WriteLine($"Pizza number {pizzaNumber} deleted");

        }

        public void Run()
        {
            bool proceed = true;
            List<string> mainMenulist = new List<string>()
            {
                "0. Quit",
                "1. Create new pizza",
                "2. Print menu",
                "3. Update pizza",
                "4. Delete pizza"
            };

            while (proceed)
            {
                int MenuChoice = MainMenuChoice(mainMenulist);
                Console.WriteLine();
                switch (MenuChoice)
                {
                    case 0:
                        proceed = false;

                        Console.WriteLine("Quitting");
                        break;
                    case 1:
                        try
                        {
                            Pizza pizza = GetNewPizza();
                            _menuCatalog.Create(pizza);

                            Console.WriteLine($"You created: {pizza}");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"No pizza created");
                        }
                            Console.Write("Hit any key to continue");

                            Console.ReadKey();
                        break;
                    case 2:
                            _menuCatalog.PrintMenu();

                            Console.Write("Hit any key to continue");
                            
                            Console.ReadKey();
                        break;
                    case 3:
                        try
                        {
                            UpdatePizza();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Unable to update pizza");
                        }
                            Console.Write("Hit any key to continue");

                            Console.ReadKey();
                        break;
                    case 4:
                        try
                        {
                            DeletePizza();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Unable to delete pizza");
                        }
                            Console.Write("Hit any key to continue");

                            Console.ReadKey();
                        break;
                    default:
                            Console.Write("Hit any key to continue");

                            Console.ReadKey();
                        break;
                }
            }

        }
    }
}
/*
 * @Henrik Martin Seindahl
 * 
 * Zipped from https://github.com/jpandersen61/UML2
 */ 