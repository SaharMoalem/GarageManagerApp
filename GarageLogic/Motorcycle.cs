using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private eMotorcycleLicenseType m_LicenseType;
        private int m_EngineCapacity;
        private const int k_NumberOfWheels = 2;
        private const int k_WheelPressure = 28;

        public Motorcycle()
        {
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                base.Wheels.Add(new Wheel(k_WheelPressure));
            }
        }

        public eMotorcycleLicenseType LicenseType
        {
            get { return m_LicenseType; }

            set { this.m_LicenseType = value; }
        }

        public int EngineCapacity
        {
            get { return m_EngineCapacity; }

            set { m_EngineCapacity = value; }
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(@"Motorcycle License Type: {0}, 
Engine Capacity: {1}", m_LicenseType, m_EngineCapacity);
        }

        public enum eMotorcycleLicenseType
        {
            A,
            A1,
            A2,
            B
        }
    }
}