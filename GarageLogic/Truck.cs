using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GarageLogic.Fuel;

namespace GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_HazardousMaterials;
        private float m_MaximumCarryWeight;
        private const int k_NumberOfWheels = 16;
        private const int k_WheelPressure = 26;

        internal Truck()
        {
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                base.Wheels.Add(new Wheel(k_WheelPressure));
            }

            VehicleEnergyType = new Fuel(eFuelType.Soler, 110f);
        }

        public bool HazardousMaterials
        {
            get { return m_HazardousMaterials; }

            set { m_HazardousMaterials = value; }
        }

        public float MaximumCarryWeight
        {
            get { return m_MaximumCarryWeight; }

            set { m_MaximumCarryWeight = value; }
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(@"
Hazardous materials on truck ? {0}, 
Maximum carring weight: {1}", m_HazardousMaterials, m_MaximumCarryWeight);
        }
    }
}
