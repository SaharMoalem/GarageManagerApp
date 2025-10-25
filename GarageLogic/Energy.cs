using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public abstract class Energy
    {
        private float m_CurrentAmountOfEnergy;
        private readonly float r_MaxEnergyAmount;
        private readonly eEnergyTypes r_EnergyTypeOfVehicle;
        private float m_EnergyPercentageBalance;

        internal Energy(float i_MaxEnergyCapacity, eEnergyTypes i_EnergyTypeOfVehicle)
        {
            this.r_MaxEnergyAmount = i_MaxEnergyCapacity;
            this.r_EnergyTypeOfVehicle = i_EnergyTypeOfVehicle;
        }

        private void setRemainingEnergyPercentage()
        {
            m_EnergyPercentageBalance = (m_CurrentAmountOfEnergy / r_MaxEnergyAmount) * 100;
        }

        public float CurrentAmountOfEnergy
        {
            get { return m_CurrentAmountOfEnergy; }

            set
            {
                if (value <= r_MaxEnergyAmount)
                {
                    m_CurrentAmountOfEnergy = value;
                    setRemainingEnergyPercentage();
                }
            }
        }

        internal eEnergyTypes EnergyTypeOfVehicle
        {
            get { return r_EnergyTypeOfVehicle; }
        }

        public float EnergyPercentageBalance
        {
            get { return m_EnergyPercentageBalance; }
        }

        internal void FillEnergy(string i_AmountOfEnergy)
        {
            float energyAmount;

            if (ValidInputNumber.FloatValid(i_AmountOfEnergy, 0, r_MaxEnergyAmount - m_CurrentAmountOfEnergy, out energyAmount))
            {
                m_CurrentAmountOfEnergy += energyAmount;
                setRemainingEnergyPercentage();
            }
        }

        public override string ToString()
        {
            return String.Format(@"Type of energy: {0}
Current Amount Of Energy: {1} - {2}% of the viable capacity)",
r_EnergyTypeOfVehicle, m_CurrentAmountOfEnergy, m_EnergyPercentageBalance);
        }

        public enum eEnergyTypes
        {
            Fuel,
            Electric
        }
    }
}