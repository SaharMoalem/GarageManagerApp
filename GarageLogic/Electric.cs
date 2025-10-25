using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    class Electric : Energy
    {
        internal Electric(float i_MaxEnergyCapacity) : base(i_MaxEnergyCapacity, eEnergyTypes.Electric)
        {
        }

        public void Recharge(String i_TimeAmount)
        {
            FillEnergy(i_TimeAmount);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
