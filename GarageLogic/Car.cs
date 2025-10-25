using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Car : Vehicle
    {
        private eColors m_Color;
        private eDoors m_Doors;
        private const int k_NumberOfWheels = 4;
        private const int k_WheelPressure = 30;

        public Car()
        {
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                base.Wheels.Add(new Wheel(k_WheelPressure));
            }
        }

        public void SetColor(string i_ColorStr)
        {
            bool validColor = false;
            int indexColor = 1;

            foreach (string color in Enum.GetNames(typeof(eColors)))
            {
                if (i_ColorStr.Equals(color))
                {
                    m_Color = (eColors)indexColor;
                    validColor = true;
                    break;
                }

                indexColor++;
            }

            if (!validColor)
            {
                throw new FormatException("Invalid color, please choose between Yellow, White, Black or Blue.");
            }
        }

        public void SetDoorsNumber(string i_DoorsNumberStr)
        {
            bool validDoors = false;
            int numberOfDoors;

            if (ValidInputNumber.IsInt(i_DoorsNumberStr, out numberOfDoors))
            {
                foreach (int i in Enum.GetValues(typeof(eDoors)))
                {
                    if (numberOfDoors == i)
                    {
                        m_Doors = (eDoors)numberOfDoors;
                        validDoors = true;
                        break;
                    }
                }

                if (!validDoors)
                {
                    throw new ValueOutOfRangeException(2, 5);
                }
            }
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(@"Car Color: {0}, 
Number of Doors: {1}", m_Color, m_Doors);
        }

        public enum eColors
        {
            Yellow = 1,
            White = 2,
            Black = 3,
            Blue = 4
        }

        public enum eDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }
    }
}
