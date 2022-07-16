using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dio_dotnet_poo.src.Entities
{
    public class Knight : Hero
    {
        public Knight(string name, int level) : base(name, level)
        {
            this.HeroClass = HeroClass.KNIGHT;
        }

        public override int getMaxHP()
        {
            return 100+(100/30*Level);
        }

        public override int getMaxMP()
        {
            return 100+(int)((100/30*Level)*0.25);
        }

        protected override string getAttackMsg(int damage, Hero target)
        {
            return getAttackMsg(damage,target,damage>=20?"head crusher skill":"hammer");
        }

        protected override string getDeathMsg(Hero target)
        {
            return getDeathMsg("smashed",target);
        }
    }
}