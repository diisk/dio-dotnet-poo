using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dio_dotnet_poo.src.Entities
{
    public class Ninja : Hero
    {
        public Ninja(string name, int level) : base(name, level)
        {
            this.HeroClass = HeroClass.NINJA;
        }

        public override int getMaxHP()
        {
            return 100+(int)((100/30*Level)*0.50);
        }

        public override int getMaxMP()
        {
            return 100+(int)((100/30*Level)*0.75);
        }

        protected override string getAttackMsg(int damage, Hero target)
        {
            return getAttackMsg(damage,target,damage>=20?"quiet blade skill":"sword");
        }

        protected override string getDeathMsg(Hero target)
        {
            return getDeathMsg("slashed",target);
        }
    }
}