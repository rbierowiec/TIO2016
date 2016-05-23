using System;
using System.Linq;

namespace ODataClient_zad9
{
    public class Program
    {
        static void Main(string[] args)
        {
            string serviceUri = "http://localhost:62409/";
            var container = new OData_client.Default.Container(new Uri(serviceUri));

            Console.WriteLine("Lista wszystkich gier:");
            foreach (var game in container.Games)
            {
                Console.WriteLine("{0} : {1}", game.Id, game.Title);
            }
            Console.WriteLine();

            Console.WriteLine("Dodaje grę");
            container.AddToGames(new OData_client.Library.Game() { Title = "Game1", AgeRate = 18, Year = 2016, CreatorCompany = "Creator1" });
            var serviceResponse = container.SaveChanges();

            Console.WriteLine("Lista wszystkich gier po dodaniu nowej:");
            foreach (var game in container.Games)
            {
                Console.WriteLine("{0} : {1}", game.Id, game.Title);
            }
            Console.WriteLine();

            Console.WriteLine("Lista wszystkich koszulek na karty:");
            foreach (var cardshirt in container.GetAvailableCardShirts())
            {
                Console.WriteLine("{0} : {1}", cardshirt.Id, cardshirt.Name);
            }
            Console.WriteLine();

            Console.WriteLine("Lista wszystkich sklepów:");
            foreach (var store in container.Stores)
            {
                Console.WriteLine("{0} : {1}", store.Id, store.Name);
            }
            Console.WriteLine();

            Console.WriteLine("Kasuję pierwszy sklep:");
            container.DeleteObject(container.Stores.FirstOrDefault());
            serviceResponse = container.SaveChanges();

            Console.WriteLine("Lista wszystkich sklepów po skasowaniu pierwszego:");
            foreach (var store in container.Stores)
            {
                Console.WriteLine("{0} : {1}", store.Id, store.Name);
            }
            Console.WriteLine();
            Console.WriteLine("Koniec programu, wciśnij dowolny klawisz aby zakończyć.");
            Console.ReadKey();
        }
    }
}
