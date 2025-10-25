using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private readonly List<Wheel> r_Wheels;
        private Energy m_VehicleEnergyType;

        public Vehicle()
        {
            this.m_ModelName = "";
            this.m_LicenseNumber = "";
            this.r_Wheels = new List<Wheel>();
            this.m_VehicleEnergyType = null;
        }

        public string ModelName
        {
            get { return m_ModelName; }

            set { m_ModelName = value; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }

            set { m_LicenseNumber = value; }
        }

        public List<Wheel> Wheels
        {
            get { return r_Wheels; }
        }

        public Energy VehicleEnergyType
        {
            get { return m_VehicleEnergyType; }

            set { m_VehicleEnergyType = value; }
        }

        public override string ToString()
        {
            return String.Format(@"Model Name: {0},
License Number: {1},
{2},
Wheels Details:
    number of wheels: {3},
    {4} {5}", m_ModelName, m_LicenseNumber,
    m_VehicleEnergyType.ToString(), Wheels.Count, Wheels[0].ToString(), Environment.NewLine);
        }
    }
}