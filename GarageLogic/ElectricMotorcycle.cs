using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        internal ElectricMotorcycle()
        {
            VehicleEnergyType = new Electric(1.6f);
        }

        public override string ToString()
        {
            return String.Format(@"Motorcycle type: Electric Motorcycle
{0}", base.ToString());
        }
    }
}
