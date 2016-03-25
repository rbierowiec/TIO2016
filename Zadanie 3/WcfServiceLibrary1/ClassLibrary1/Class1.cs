using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace ComicAdventureDTO
{
    [DataContract]
    public static class randomGenerator
    {
        [DataMember]
        private static readonly Random rnd = new Random();

        [OperationContract]
        public static int randNumber(int min, int max)
        {
            return rnd.Next(min, max);
        }
    }

    [DataContract]
    public class SpaceSystem
    {
        [DataMember]
        public string Name { get; set; }
        private int MinShipPower { get; set; }
        [DataMember]
        public int BaseDistance { get; set; }
        private int Gold { get; set; }

        [OperationContract]
        public static SpaceSystem generateSystem(string _Name)
        {
            SpaceSystem system = new SpaceSystem() { Name = _Name, MinShipPower = randomGenerator.randNumber(10, 40), BaseDistance = randomGenerator.randNumber(20, 120), Gold = randomGenerator.randNumber(3000, 7000) };

            return system;
        }

        public int getMinShipPower()
        {
            return MinShipPower;
        }

        public int getGold()
        {
            return Gold;
        }
    }

    [DataContract]
    public class Starship
    {
        [DataMember]
        public List<Person> Crew;
        [DataMember]
        public int Gold;
        [DataMember]
        public int ShipPower;
    }

    [DataContract]
    public class Person
    {
        [DataMember]
        public string Name;
        [DataMember]
        public string Nick;
        [DataMember]
        public float Age;
    }
}
