using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GarageLogic.Fuel;

namespace GarageLogic
{
    public class FuelMotorcycle : Motorcycle
    {
        internal FuelMotorcycle()
        {
            VehicleEnergyType = new Fuel(eFuelType.Octan98, 5.5f);
        }

        public override string ToString()
        {
            return String.Format(@"Motorcycle type: Gas Motorcycle
{0}", base.ToString());
        }
    }
}
