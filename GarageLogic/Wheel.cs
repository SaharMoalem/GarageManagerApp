using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Wheel
    {
        private string m_ProducerName;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;

        internal Wheel(float i_MaxAirPressure)
        {
            this.m_ProducerName = "";
            this.m_CurrentAirPressure = 0f;
            this.r_MaxAirPressure = i_MaxAirPressure;
        }

        public Wheel(float i_MaxAirPressure, string i_ProducerName, float i_CurrentAirPressure)
        {
            this.m_ProducerName = i_ProducerName;
            this.m_CurrentAirPressure = i_CurrentAirPressure;
            this.r_MaxAirPressure = i_MaxAirPressure;
        }

        public string ProducerName
        {
            get { return m_ProducerName; }

            set { m_ProducerName = value; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
        }

        public void PumpWheel(float i_AirToAdd)
        {
            if (i_AirToAdd + m_CurrentAirPressure > r_MaxAirPressure || i_AirToAdd < 0)
            {
                throw new ValueOutOfRangeException(0, (int)r_MaxAirPressure);
            }
            else
            {
                this.m_CurrentAirPressure += i_AirToAdd;
            }
        }

        internal void PumpAirToMax()
        {
            this.m_CurrentAirPressure = this.r_MaxAirPressure;
        }

        public override string ToString()
        {
            return String.Format(@"Producer Name: {0},
Current Air Pressure: {1},
Maximum Air Pressure: {2}",
                m_ProducerName, m_CurrentAirPressure, r_MaxAirPressure);
        }
    }
}