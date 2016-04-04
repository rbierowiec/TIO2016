using System;
using CRUDClient.CRUDService;
using CRUDClient.CRUDService2;
using System.Collections.Generic;
using System.Linq;

namespace CRUDClient
{
    class Program
    {
        static CRUDServiceClient service1 = new CRUDServiceClient();
        static CRUDService2Client service2 = new CRUDService2Client();

        static void Main(string[] args)
        {
            Console.WriteLine("Proszę podać swoje imie:");
            string userName = Console.ReadLine().ToString();
            Console.WriteLine("Proszę podać swoje nazwisko:");
            string userSurname = Console.ReadLine().ToString();

            Person user = service2.getAuthorByName(userName, userSurname);
            if (user != null)
                Console.WriteLine("Witaj {0} {1}", userName, userSurname);
            else
            {
                zalozKonto(userName, userSurname);
                user = service2.getAuthorByName(userName, userSurname);
            }

            if (service1.GetAllMovies().Count() < 4) utworzFilmy();

            Console.ReadKey();
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                wyswietlMenu();
                key = Console.ReadKey();
                Console.WriteLine();
                string tmpKey = key.KeyChar.ToString();

                switch (tmpKey) {
                    case "1":
                        Console.WriteLine("Wybierz film, dla którego chcesz dodać recenzję wpisując jego numer ID (ENTER - zatwierdź)");
                        wyswietlFilmy();

                        int filmID = Int32.Parse(Console.ReadLine().ToString());
                        Movie wybranyFilm = service1.GetMovie(filmID);

                        if (wybranyFilm == null)
                            Console.WriteLine("Nie istnieje film o podanym numerze ID");
                        else
                        {
                            Console.WriteLine("Wpisz swoją recenzję");
                            string recenzja = Console.ReadLine();
                            Console.WriteLine("Wpisz ocenę w skali 0-100");
                            int ocena = Int32.Parse(Console.ReadLine());
                            if (ocena < 0) ocena = 0;
                            if (ocena > 100) ocena = 100;

                            service2.AddReview(new Review() { Score = ocena, Content = recenzja, Author = user , MovieId = filmID});
                            Console.WriteLine("Pomyślnie dodano recenzję");
                            Console.ReadKey();

                        }
                        break;
                    case "2":
                        Console.WriteLine("Wybierz recenzję do edycji wpisując jej numer ID (ENTER - zatwierdź)");
                        wyswietlRecenzje(user);

                        int reviewID = Int32.Parse(Console.ReadLine().ToString());
                        Review wybranaRecenzja = service2.getReview(reviewID);

                        if (wybranaRecenzja == null || wybranaRecenzja.Author.Id != user.Id)
                        {
                            Console.WriteLine("Podano niepoprawny numer ID recenzji ({0})", reviewID);
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Treść: {0}", wybranaRecenzja.Content);
                            Console.WriteLine("Wpisz nową recenzję");
                            string recenzja = Console.ReadLine();
                            Console.WriteLine("Wpisz nową ocenę w skali 0-100");
                            int ocena = Int32.Parse(Console.ReadLine());
                            if (ocena < 0) ocena = 0;
                            if (ocena > 100) ocena = 100;

                            service2.deleteReview(wybranaRecenzja.Id);
                            service2.AddReview(new Review() { Id = wybranaRecenzja.Id, Score = ocena, Content = recenzja, Author = user, MovieId = wybranaRecenzja.MovieId });
                            Console.WriteLine("Pomyślnie zmieniono recenzję");
                            Console.ReadKey();
                        }

                            break;
                    case "3":
                        Console.WriteLine("Wybierz recenzję do usunięcia wpisując jej numer ID (ENTER - zatwierdź)");
                        wyswietlRecenzje(user);

                        int reviewID2 = Int32.Parse(Console.ReadLine().ToString());
                        Review wybranaRecenzja2 = service2.getReview(reviewID2);

                        if (wybranaRecenzja2 == null || wybranaRecenzja2.Author.Id != user.Id)
                        {
                            Console.WriteLine("Podano niepoprawny numer ID recenzji ({0})", reviewID2);
                            Console.ReadKey();
                        }
                        else
                        {
                            service2.deleteReview(wybranaRecenzja2.Id);
                            Console.WriteLine("Pomyślnie skasowano recenzję");
                            Console.ReadKey();
                        }

                        break;
                    case "4":
                        Console.WriteLine("Wyświetl informacje o recenzji dla filmu o wybranym ID (ENTER - zatwierdź)");
                        wyswietlFilmy();

                        int filmID2 = Int32.Parse(Console.ReadLine().ToString());
                        Movie wybranyFilm2 = service1.GetMovie(filmID2);

                        if (wybranyFilm2 == null)
                            Console.WriteLine("Nie istnieje film o podanym numerze ID");
                        else
                        {
                            Review[] recenzje = service2.GetReviewsByMovieId(wybranyFilm2.Id);
                            if (recenzje.Count() > 0)
                            {
                                Console.WriteLine("Średnia ocena: {0}", wyliczSredniaOcene(wybranyFilm2.Id));
                                Console.WriteLine("Recenzje:");
                                foreach (var recenzja in recenzje)
                                {
                                    Console.WriteLine("{0} {1}: {2}, ocena: {3}", recenzja.Author.Name, recenzja.Author.Surname, recenzja.Content, recenzja.Score);
                                }
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Brak ocen dla filmu");
                                Console.ReadKey();
                            }

                        }
                        break;
                    case "5":
                        Console.WriteLine("Podaj tytuł filmu:");
                        string tytul = Console.ReadLine().ToString();
                        Console.WriteLine("Podaj rok produkcji");
                        int rok = Int32.Parse(Console.ReadLine().ToString());

                        service1.AddMovie(new Movie() { Title = tytul, ReleaseYear = rok });
                        Console.WriteLine("Pomyślnie dodano film");
                        Console.ReadKey();

                        break;
                    default: Console.WriteLine("Wybrano niepoprawną opcję! Wciśnij dowolny klawisz, aby kontynuować"); Console.ReadKey(); break;
                }

            } while (key.Key != ConsoleKey.Escape);
        }

        private static void wyswietlFilmy()
        {
            Movie[] filmy = service1.GetAllMovies();

            foreach (var film in filmy)
            {
                Console.WriteLine("{0}. {1}, {2}", film.Id, film.Title, film.ReleaseYear);
            }
        }

        private static void wyswietlRecenzje(Person author) {
            Review[] recenzje = service2.GetReviewsByAuthor(author);

            if (recenzje.Count() > 0)
            {
                foreach (var recenzja in recenzje)
                {
                    Movie film = service1.GetMovie(recenzja.MovieId);
                    if (film != null)
                        Console.WriteLine("{0}. {1}, Ocena: {2}", recenzja.Id, film.Title, recenzja.Score);
                }
            }
            else
            {
                Console.WriteLine("Brak recenzji");
                Console.ReadKey();
            }
        }

        private static bool zalozKonto(String _Name, String _Surname)
        {
            Console.WriteLine("Pomyślnie dodano użytkownika {0} {1}", _Name, _Surname);
            return service2.AddAuthor(new Person() { Name = _Name, Surname = _Surname }) > 0;
        }

        private static float wyliczSredniaOcene(int movieID)
        {
            Review[] recenzje = service2.GetReviewsByMovieId(movieID);
            int sumaOcen = 0;
            int iloscOcen = recenzje.Count();

            foreach (var recenzja in recenzje)
            {
                sumaOcen += recenzja.Score;
            }

            return sumaOcen / iloscOcen;
        }

        private static void utworzFilmy()
        {
            service1.AddMovie(new Movie() { Title = "Rambo", ReleaseYear = 1982 });
            service1.AddMovie(new Movie() { Title = "Avatar", ReleaseYear = 2009 });
            service1.AddMovie(new Movie() { Title = "Poradnik pozytywnego myślenia", ReleaseYear = 2012 });
            service1.AddMovie(new Movie() { Title = "Dzień świra", ReleaseYear = 2002 });
        }

        private static void wyswietlMenu()
        {
            Console.WriteLine("Jaką czynność chcesz wykonać?");
            Console.WriteLine("1. Dodaj recenzję.");
            Console.WriteLine("2. Edytuj swoje recenzje.");
            Console.WriteLine("3. Usuń recenzję.");
            Console.WriteLine("4. Zobacz recenzję dla filmów.");
            Console.WriteLine("5. Dodaj film");
            Console.WriteLine("Esc - Koniec");
        }
    }
}
