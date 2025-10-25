using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class ElectricCar : Car
    {
        internal ElectricCar()
        {
            VehicleEnergyType = new Electric(2.8f);
        }

        public override string ToString()
        {
            return String.Format(@"Car type: Electric Car 
{0}", base.ToString());
        }
    }
}
