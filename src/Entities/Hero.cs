using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dio_dotnet_poo.src.Entities
{
    public abstract class Hero
    {

        public static Random random = new Random();
        public string Name { get; }
        public int Level { get; }

        protected int hp, mp;
        protected HeroClass HeroClass;


        public Hero(string name, int level)
        {
            this.Name = name;
            this.Level = level;
            this.hp = getMaxHP();
            this.mp = getMaxMP();
        }

        private void setHealth(int health)
        {
            if (health < 0)
            {
                health = 0;
            }
            hp = health;
        }

        public void Attack(Hero target)
        {
            int damage = random.Next(10, 20);
            int bonusDamage = random.Next(0, 20);

            if (mp >= bonusDamage*2)
            {
                mp -= bonusDamage*2;

            }else{
                bonusDamage = 0;
            }

            target.setHealth(target.hp - (damage + bonusDamage));

            if (target.IsDead())
            {
                Console.WriteLine(getDeathMsg(target));
                return;
            }

            Console.WriteLine(getAttackMsg(damage + bonusDamage, target));
        }

        public string getNameRepresentation(){
            return Name+" the "+HeroClass.ToString().ToLower();
        }


        protected abstract string getAttackMsg(int damage, Hero target);
        protected abstract string getDeathMsg(Hero target);
        
        protected string getAttackMsg(int damage, Hero target, string attackName)
        {
            return $"{getNameRepresentation()} deal {damage} of damage in {target.getNameRepresentation()} with your {attackName}.";
        }

        protected string getDeathMsg(string deathCause, Hero target)
        {
            return $"{getNameRepresentation()} {deathCause} {target.getNameRepresentation()} until the death.";
        }

        

        public abstract int getMaxHP();
        public abstract int getMaxMP();

        public bool IsDead()
        {
            return hp == 0;
        }

        public override string ToString()
        {
            return $"Name:{Name} Level:{Level} Class:{HeroClass}";
        }
    }
}