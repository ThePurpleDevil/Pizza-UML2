using System;

namespace Pizza_UML2
{
    public class Store
    {
        MenuCatalog menuCatalog;

        public Store()
        {
            menuCatalog = new MenuCatalog();
        }
        public void Test()
        {
            Pizza p = new Pizza() { Number = 1, Name = "Margharita", Price = 59 };
            menuCatalog.Create(p);

            p = new Pizza() { Number = 2, Name = "Hawaii", Price = 69 };
            menuCatalog.Create(p);

            p = new Pizza() { Number = 3, Name = "Salat", Price = 69 };
            menuCatalog.Create(p);

            menuCatalog.PrintMenu();
        }

        public void Run()
        {
            new UserDia(menuCatalog).Run();
        }
    }
}
/*
 * @Henrik Martin Seindahl
 * 
 * Zipped from https://github.com/jpandersen61/UML2
 */ 