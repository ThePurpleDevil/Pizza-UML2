using System;
using System.Collections.Generic;
namespace Pizza_UML2
{
    public class MenuCatalog
    {
        List<Pizza> _pizzas;

        public MenuCatalog()
        {
            _pizzas = new List<Pizza>();
        }

        public void Create(Pizza p)
        {
            _pizzas.Add(p);
        }

        public void PrintMenu()
        {
            foreach (Pizza p in _pizzas)
            {
                Console.WriteLine(p);
            }

        }
        public Pizza FindPizzaByNumber(int number)
        {
            Pizza pizza = _pizzas.Find(p => p.Number == number);

            if (pizza == null)
            {
                Console.WriteLine($"Pizza number {number} was not found");
            }
            return pizza;
        }
        public void Update(int number, Pizza newPizza)
        {
            Pizza pizzaToUpdate = _pizzas.Find(p => p.Number == number);

            if (pizzaToUpdate != null)
            {
                pizzaToUpdate.Name = newPizza.Name;
                pizzaToUpdate.Price = newPizza.Price;
            }
            else
            {
                Console.WriteLine($"Pizza number {number} was not found");
            }
        }

        public void Delete(int number)
        {
            Pizza pizzaToDelete = _pizzas.Find(p => p.Number == number);

            if (pizzaToDelete != null)
            {
                _pizzas.Remove(pizzaToDelete);
            }
            else
            {
                Console.WriteLine($"Pizza number {number} was not found");
            }
        }

    }
}
/*
 * @Henrik Martin Seindahl
 * 
 * Zipped from https://github.com/jpandersen61/UML2
 */ 