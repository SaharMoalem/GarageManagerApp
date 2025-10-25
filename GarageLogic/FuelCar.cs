using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GarageLogic.Fuel;


namespace GarageLogic
{
    public class FuelCar : Car
    {
        internal FuelCar()
        {
            VehicleEnergyType = new Fuel(eFuelType.Octan95, 50f);
        }

        public override string ToString()
        {
            return String.Format(@"Car type: Fuel Car
{0}", base.ToString());
        }
    }
}
