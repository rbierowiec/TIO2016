using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication5.ServiceReference1;
using ConsoleApplication5.ServiceReference2;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Starship> _starships = new List<Starship>();
            bool _anySystem = true;
            int _gold = 1000;
            int _imperiumMoneyAskCount = 4;

            Service1Client serwis1 = new Service1Client();
            Service2Client serwis2 = new Service2Client();
            serwis1.InitializeGame();

            wyswietlMenu(_gold, _imperiumMoneyAskCount);
            var key = Console.ReadKey();
            bool endGame = false;

            while (key.Key != ConsoleKey.Escape && endGame == false)
            {
                Console.Clear();
                string tmpKey = key.KeyChar.ToString();
                switch (tmpKey)
                {
                    case "1":
                        if (_imperiumMoneyAskCount > 0)
                        {
                            Console.WriteLine("Imperium przekazuje Ci trochę złota...");
                            _gold += serwis2.GetMoneyFromImperium();
                            _imperiumMoneyAskCount--;
                        }
                        else
                        {
                            Console.WriteLine("Wykorzystałeś wszystkie prośby o złoto!");
                        };
                        break;
                    case "2":
                        Console.WriteLine("Za jaką kwotę chcesz kupić statek?");
                        var inputValue = Console.ReadLine();
                        int kwota;

                        if (Int32.TryParse(inputValue, out kwota))
                        {
                            if (kwota <= 1000)
                            {
                                Console.WriteLine("Wybrano za małą kwotę!");
                            }
                            else if (kwota > _gold)
                            {
                                Console.WriteLine("Nie posiadasz takiej kwoty!");
                            }
                            else {
                                _starships.Add(serwis1.GetStarship(kwota));
                                _gold -= kwota;
                                Console.WriteLine("Pomyślnie zakupiono statek!");
                            }
                        }
                        else {
                            Console.WriteLine("Wprowadzona wartość musi być liczbą!");
                        }
                        break;
                    case "3":
                        SpaceSystem sys = serwis1.GetSystem();
                        if (sys != null)
                        {
                            Console.WriteLine("System {0}, odległość {1}", sys.Name, sys.BaseDistance);

                            if (_starships.Count() > 0)
                            {
                                Console.WriteLine("Statków gotowych do podróży: {0}", _starships.Count());
                                Console.WriteLine("Wybierz statek wpisując jego numer lub wciśnij Esc, aby wyjść");

                                int index = 1;
                                foreach (var statek in _starships)
                                {
                                    Console.Write("{0}. {1}, ", index, statek.ShipPower);

                                    int index2 = 1;
                                    foreach (var pers in statek.Crew)
                                    {
                                        Console.Write("{0} {1} {2}", pers.Name, pers.Nick, pers.Age);
                                        if (index2 < statek.Crew.Count()) Console.Write(",");
                                        else Console.WriteLine();
                                        index2++;
                                    }
                                    index++;
                                };


                                var inputValue2 = Console.ReadKey();
                                int statekKey;

                                if (Int32.TryParse(inputValue2.KeyChar.ToString(), out statekKey))
                                {
                                    if (statekKey > 0 && statekKey <= _starships.Count())
                                    {
                                        Starship statek = _starships.ElementAt(statekKey - 1);
                                        _starships.RemoveAt(statekKey - 1);

                                        Starship statek2 = serwis1.SendStarship(statek, sys.Name);
                                        _gold += statek2.Gold;
                                        statek2.Gold = 0;

                                        if (statek2.Crew.Count() > 0) _starships.Add(statek2);
                                    }
                                    else {
                                        Console.WriteLine("Podano niepoprawny numer statku!");
                                    }
                                }
                                else {
                                    Console.WriteLine("Wprowadzona wartość musi być liczbą!");
                                }
                            }
                            else {
                                Console.WriteLine("Brak dostępnych statków!");
                            }

                        }
                        else {
                            _anySystem = false;
                            Console.WriteLine("Brak systemów!");
                        }
                        break;
                    case "4":
                        if (_anySystem == true)
                        {
                            Console.WriteLine("Przegrałeś :(");
                        }
                        else {
                            Console.WriteLine("Gratulacje, wygrałeś!");
                        }
                        break;
                }

                if (tmpKey != "4")
                {
                    Console.WriteLine("Wciśnij dowolny klawisz aby kontynuować");
                    Console.ReadKey();
                    Console.Clear();
                    wyswietlMenu(_gold, _imperiumMoneyAskCount);
                    key = Console.ReadKey();
                }
                else {
                    endGame = true;
                    Console.WriteLine("Wciśnij dowolny klawisz, aby zakończyć");
                    Console.ReadKey();
                }
            }
        }

        public static void wyswietlMenu(int _gold, int _askCount)
        {
            Console.WriteLine("Aktualny stan złota: {0} (pozostałe prośby o złoto: {1})", _gold, _askCount);
            Console.WriteLine("Jaką czynność chcesz wykonać?");
            Console.WriteLine("1. Poproś imperium o złoto");
            Console.WriteLine("2. Kup statek za złoto");
            Console.WriteLine("3. Wyślij statek do systemu");
            Console.WriteLine("4. Zakończ grę");
            Console.WriteLine("Esc - Koniec programu");
        }
    }
}
