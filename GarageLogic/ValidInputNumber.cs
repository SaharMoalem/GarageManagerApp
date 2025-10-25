using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class ValidInputNumber
    {
        public static bool IsInt(string i_Input, out int io_ValidInt)
        {
            bool valid = true;

            valid = Int32.TryParse(i_Input, out io_ValidInt);
            if (!valid)
            {
                throw new FormatException("Invalid input! Please change the input to Integer");
            }

            return valid;
        }

        public static bool IsFloat(string i_Input, out float io_ValidFloat)
        {
            bool valid = true;

            valid = Single.TryParse(i_Input, out io_ValidFloat);
            if (!valid)
            {
                throw new FormatException("Invalid input! Please change the input to Float number");
            }

            return valid;
        }

        internal static bool FloatValid(string i_Input, float i_LowerBound, float i_UpperBound, out float io_ValidFloat)
        {
            bool valid = false;

            valid = Single.TryParse(i_Input, out io_ValidFloat);
            if (valid)
            {
                if (!(io_ValidFloat >= i_LowerBound && io_ValidFloat <= i_UpperBound))
                {
                    valid = false;
                    throw new ValueOutOfRangeException(i_LowerBound, i_UpperBound);
                }
            }
            else
            {
                throw new FormatException("Invalid input! please change the input to Float");
            }

            return valid;
        }

        public static bool IntValid(string i_Input, int i_LowBound, int i_UpperBound, out int io_ValidInt)
        {
            bool valid = false;

            valid = Int32.TryParse(i_Input, out io_ValidInt);
            if (valid)
            {
                if (!(io_ValidInt >= i_LowBound && io_ValidInt <= i_UpperBound))
                {
                    valid = false;
                    throw new ValueOutOfRangeException(i_LowBound, i_UpperBound);
                }
            }
            else
            {
                throw new FormatException("Invalid input! please change the input to Integer");
            }

            return valid;
        }
    }
}