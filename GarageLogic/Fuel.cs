using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Fuel : Energy
    {
        private readonly eFuelType r_FuelType;

        internal Fuel(eFuelType i_FuelType, float i_MaxEnergyCapacity) : base(i_MaxEnergyCapacity, eEnergyTypes.Fuel)
        {
            r_FuelType = i_FuelType;
        }

        internal eFuelType FuelType
        {
            get { return r_FuelType; }
        }

        internal void Refuel(String i_FuelAmount)
        {
            FillEnergy(i_FuelAmount);
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(
               "{0}Fuel Type: {1}",
               Environment.NewLine, r_FuelType);
        }

        public enum eFuelType
        {
            Soler = 1,
            Octan95 = 2,
            Octan96 = 3,
            Octan98 = 4
        }
    }
}
