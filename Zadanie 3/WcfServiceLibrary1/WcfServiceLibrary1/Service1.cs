using System;
using System.Collections.Generic;
using ComicAdventureDTO;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Linq;

namespace WcfServiceLibrary1
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {

        private List<SpaceSystem> _systems { get; set; }

        public void InitializeGame()
        {
            this._systems = new List<SpaceSystem> { SpaceSystem.generateSystem("System 1"), SpaceSystem.generateSystem("System 2"), SpaceSystem.generateSystem("System 3"), SpaceSystem.generateSystem("System 4") };
        }

        public Starship SendStarship(Starship starship, string systemName)
        {
            bool czyNazwaIstnieje = false;

            foreach (var sys in _systems)
            {
                if (sys.Name.Equals(systemName))
                {
                    czyNazwaIstnieje = true;

                    if (starship.ShipPower <= 20)
                    {
                        foreach (var pers in starship.Crew)
                        {
                            pers.Age += (2 * sys.BaseDistance) / 12;
                        }
                    }
                    else if (starship.ShipPower > 20 && starship.ShipPower <= 30)
                    {
                        foreach (var pers in starship.Crew)
                        {
                            pers.Age += (2 * sys.BaseDistance) / 6;
                        }
                    }
                    else if (starship.ShipPower > 30)
                    {
                        foreach (var pers in starship.Crew)
                        {
                            pers.Age += (2 * sys.BaseDistance) / 4;
                        }
                    }

                    for (var i = starship.Crew.Count()-1; i>=0; i--)
                    {
                        var pers = starship.Crew[i];
                        if (pers.Age > 90)
                        {
                            starship.Crew.Remove(pers);
                        }
                    }

                    if (sys.getMinShipPower() <= starship.ShipPower)
                    {
                        starship.Gold += sys.getGold();
                        _systems.Remove(sys);
                        break;
                    }
                }
            }

            if (czyNazwaIstnieje == false)
            {
                foreach (var pers in starship.Crew)
                {
                    starship.Crew.Remove(pers);
                }
            }

            return starship;
        }

        public SpaceSystem GetSystem()
        {
            SpaceSystem system = _systems.FirstOrDefault();

            return system;
        }

        public Starship GetStarship(int money)
        {
            Starship statek = new Starship();

            statek.Crew = new List<Person> { new Person() { Name = "Andrzej", Nick = "Hardy", Age = 20 }, new Person() { Name = "Janusz", Nick = "Good", Age = 20 }, new Person() { Name = "Grażyna", Nick = "Brown", Age = 20 }, new Person() { Name = "Krzysiek", Nick = "Malutki", Age = 20 } };
            statek.Gold = 0;
            if (money > 1000 && money <= 3000) statek.ShipPower = randomGenerator.randNumber(10, 25);
            else if (money > 3001 && money <= 10000) statek.ShipPower = randomGenerator.randNumber(20, 35);
            else if (money > 10000) statek.ShipPower = randomGenerator.randNumber(35, 60);

            return statek;
        }
    }
}
