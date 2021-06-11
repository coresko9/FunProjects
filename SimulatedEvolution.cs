using System;
using System.Collections.Generic;

namespace NeuralNetworkMaybe
{
    class Village
    {
        public List<Person> People { get; set; }
        public int Generation { get; set; }
    }
    class SocialNorms
    {
        public static int AverageAggression { get; set; }
        public static decimal AverageHealth { get; set; }
        public static int TotalPopulation = 0;
        public static List<byte> RandomGene;
        private static int _probability = 1;
        public static void CreateNewGeneArray()
        {
            RandomGene = new List<byte>();
            Random random = new Random();
            _probability++;
            for (int i = 0; i < 100; i++)
            {
                RandomGene.Add(Convert.ToByte(random.Next(0, _probability)));
            }

        }
        public static void CalcAverage(int Aggression, decimal Health)
        {
            TotalPopulation++;
            if (TotalPopulation < 2)
            {
                AverageAggression = Aggression;
                AverageHealth = Health;
            }
            else
            {
                AverageAggression = (AverageAggression + (Aggression * (TotalPopulation - 1))) / TotalPopulation;
                AverageHealth = (AverageHealth + (Health * (TotalPopulation - 1))) / TotalPopulation;
            }
        }
    }
    class Person
    {
        public int Height { get; set; }
        public int Weight { get; set; }
        public decimal Health { get; set; }
        public int Agression { get; set; }
        public int Selflessness { get; set; }
        public int Selfishness { get; set; }
        public static Random ranAttribute = new Random();
        public static int deviateFromParentsTraits = 1;

        //random created person 
        public Person()
        {

            this.Height = ranAttribute.Next(60, 90);
            this.Weight = ranAttribute.Next(100, 250);
            this.Health = Math.Round(Convert.ToDecimal(Height) / Convert.ToDecimal(Weight), 2);
            this.Agression = Person.ranAttribute.Next(0, 100);
            this.Selfishness = Person.ranAttribute.Next(0, 100);
            this.Selflessness = Person.ranAttribute.Next(0, 100);

        }
        //person created from parent's traits
        public Person(int height, int weight, int agression)
        {
            deviateFromParentsTraits++;
            //shorter and fatter
            if (deviateFromParentsTraits % 3 == 0)
            {
                this.Height = (height * 85) /90 ;
                this.Weight = (weight * 90) / 85;
            }
            //taller and skinnier
            if (deviateFromParentsTraits % 2 == 0)
            {
                this.Height = (height * 90) / 85;
                this.Weight = (weight * 85) / 90;
            }
            else
            {

                this.Height = height;
                this.Weight = weight;
            }
            this.Agression = agression;
            this.Health = Math.Round(Convert.ToDecimal(height) / Convert.ToDecimal(weight), 2);
            this.Selfishness = Person.ranAttribute.Next(0, 100);
            this.Selflessness = Person.ranAttribute.Next(0, 100);


        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool notPeakSociety = true;
            Village village = new Village();
            SocialNorms socialNorms = new SocialNorms();
            village.People = new List<Person>();

            //////////////////////////////////////////

            while (village.People.Count < 50)
            {
                village.People.Add(new Person());

            }

            while (notPeakSociety)
            {
                SocialNorms.CreateNewGeneArray();
                List<Person> NextGeneration = new List<Person>();
                int count = 0;
                Console.WriteLine($"Generation: {++village.Generation}");
                foreach (Person person in village.People)
                {
                    count++;
                    Console.WriteLine($"Person {count} / {village.People.Count}");
                    Console.WriteLine($"Height is {person.Height}");
                    Console.WriteLine($"Weight is {person.Weight}");
                    Console.WriteLine($"Health is {person.Health}");
                    Console.WriteLine($"Agression is {person.Agression}");
                    Console.WriteLine($"Selflessness is {person.Selflessness}");
                    Console.WriteLine($"Selfishness is {person.Selfishness}");
                    Console.WriteLine("---------------------------");

                }
                for (int i = 0; i < village.People.Count - 2; i++)
                {
                    // decide whether candidates are good to reproduce
                    if (village.People[i].Health > 0.5m && village.People[i].Agression > 10 && village.People[i + 1].Health > 0.5m && village.People[i + 1].Agression > 10)
                    {
                        // if reproduce, will stray genes play apart
                        if (SocialNorms.RandomGene[Person.ranAttribute.Next(0, SocialNorms.RandomGene.Count)] == 0)
                        {
                            SocialNorms.CalcAverage(village.People[i].Agression, village.People[i].Health);
                            NextGeneration.Add(new Person());
                            NextGeneration.Add(new Person());

                        }
                        //if not stray gene, reproduce with passed on traits
                        else
                        {
                            SocialNorms.CalcAverage(village.People[i].Agression, village.People[i].Health);
                            NextGeneration.Add(new Person(((village.People[i].Height + village.People[i + 1].Height) / 2), ((village.People[i].Weight + village.People[i + 1].Weight) / 2), SocialNorms.AverageAggression));
                            NextGeneration.Add(new Person(((village.People[i].Height + village.People[i + 1].Height) / 2), ((village.People[i].Weight + village.People[i + 1].Weight) / 2), SocialNorms.AverageAggression));

                        }
                        NextGeneration.Add(new Person(((village.People[i].Height + village.People[i + 1].Height) / 2), ((village.People[i].Weight + village.People[i + 1].Weight) / 2), SocialNorms.AverageAggression));

                    }

                }
                village.People = NextGeneration;
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine($" Average Agression: {SocialNorms.AverageAggression}");
                Console.WriteLine($" Average Heatlh: {Math.Round(SocialNorms.AverageHealth, 2)}");
                Console.ReadLine();

            }
        }
    }
}
