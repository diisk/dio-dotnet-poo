using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dio_dotnet_poo.src.Entities
{
    public class BlackWizard : Hero
    {
        public BlackWizard(string name, int level) : base(name, level)
        {
            this.HeroClass = HeroClass.BLACK_WIZARD;
        }

        public override int getMaxHP()
        {
            return 100+(int)((100/30*Level)*0.25);
        }

        public override int getMaxMP()
        {
            return 100+(100/30*Level);
        }

        protected override string getAttackMsg(int damage, Hero target)
        {
            return getAttackMsg(damage,target,damage>=20?"fireball spell":"staff");
        }

        protected override string getDeathMsg(Hero target)
        {
            return getDeathMsg("burned",target);
        }
    }
}