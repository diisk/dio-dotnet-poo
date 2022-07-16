using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dio_dotnet_poo.src.Entities
{
    public class WhiteWizard : Hero
    {
        public WhiteWizard(string name, int level) : base(name, level)
        {
            this.HeroClass = HeroClass.WHITE_WIZARD;
        }

        public override int getMaxHP()
        {
            return 100+(int)((100/30*Level)*0.75);
        }

        public override int getMaxMP()
        {
            return 100+(int)((100/30*Level)*0.50);
        }

        protected override string getAttackMsg(int damage, Hero target)
        {
            return getAttackMsg(damage,target,damage>=20?"light beam spell":"staff");
        }

        protected override string getDeathMsg(Hero target)
        {
            return getDeathMsg("iluminated",target);
        }
    }
}