using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MinValue;
        private readonly float r_MaxValue;

        internal ValueOutOfRangeException(float i_LowerBound, float i_UpperBound) : base($"input is not valid, input should be between {i_LowerBound} to {i_UpperBound}")
        {
            this.r_MinValue = i_LowerBound;
            this.r_MaxValue = i_UpperBound;
        }
    }
}
