using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dio_dotnet_poo.src.Entities;

namespace dio_dotnet_poo.src
{
    public class BattleRoyale
    {
        public static Random random = new Random();
        private List<Hero> Heroes = new List<Hero>();

        public void addToBattle(Hero hero)
        {
            foreach (Hero battleHero in Heroes)
            {
                if (battleHero.Name.ToLower() == hero.Name.ToLower())
                {
                    throw new Exception("Already have one hero with this name in this battle.");
                }
            }
            Heroes.Add(hero);
        }

        public void start()
        {
            if (Heroes.Count < 2)
            {
                throw new Exception("We need at least 2 heroes to start the battle.");
            }

            Console.WriteLine("Participants list:");
            foreach (Hero hero in Heroes)
            {
                Console.WriteLine($"{hero} HP:{hero.getMaxHP()} MP:{hero.getMaxMP()}");
            }

            shuffleHeroes();
            Console.WriteLine("Let the battle begin!");

            while (getAliveHeroes().Count > 1)
            {
                foreach (Hero hero in Heroes)
                {
                    if (hero.IsDead())
                    {
                        continue;
                    }

                    Hero target = getRandomAliveTarget(hero);
                    if (target == null)
                    {
                        break;
                    }

                    hero.Attack(target);
                }
            }

            List<Hero> aliveHeroes = getAliveHeroes();
            if (aliveHeroes.Count == 1)
            {
                Console.WriteLine(aliveHeroes[0].getNameRepresentation()+" won the battle royale!");
                return;
            }

            throw new Exception("Unexpected error "+aliveHeroes.Count+" heroes alive at the end.");
        }

        private Hero getRandomAliveTarget(Hero selectedHero)
        {
            List<Hero> aliveHeroes = getAliveHeroes(selectedHero);
            if (aliveHeroes.Count == 0)
            {
                return null;
            }
            return aliveHeroes[random.Next(aliveHeroes.Count)];
        }

        private List<Hero> getAliveHeroes(Hero ignoreHero = null)
        {
            List<Hero> alives = new List<Hero>();
            foreach (Hero hero in Heroes)
            {
                if (!hero.IsDead())
                {
                    if (ignoreHero != null && hero.Name.ToLower() == ignoreHero.Name.ToLower())
                    {
                        continue;
                    }
                    alives.Add(hero);
                }
            }
            return alives;
        }

        private void shuffleHeroes()
        {
            int count = Heroes.Count;
            while (count > 1)
            {
                count--;
                int newPos = random.Next(count + 1);
                Hero temp = Heroes[newPos];
                Heroes[newPos] = Heroes[count];
                Heroes[count] = temp;
            }
        }
    }
}