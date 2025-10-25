using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic;

namespace ConsoleUI
{
    internal class VehicleRefueling
    {
        private static readonly int sr_MaxFuelOption = Enum.GetNames(typeof(Fuel.eFuelType)).Length;

        internal static void VehicleRefuelingUI(ManagerSystem i_Garage)
        {
            Console.Clear();
            Console.Write("Enter the license number of the vehicle you wish to refuel: ");
            string licenseNumber = Console.ReadLine();
            Console.WriteLine(@"=================================
Please choose your fuel Type (press the option number): 

1. Soler

2. Octan95

3. Octan96

4. Octan98
");
            int fuelChoiceNumber = 0;
            ValidInput.ValidInputUI(1, sr_MaxFuelOption, out fuelChoiceNumber);
            Fuel.eFuelType fuelChoice = (Fuel.eFuelType)fuelChoiceNumber;
            Console.WriteLine(@"How much would you like to refuel?");
            string amountToRefuelStr = "";
            int amountToRefuelInt = 0;
            bool isInt = false;
            while (!isInt)
            {
                try
                {
                    amountToRefuelStr = Console.ReadLine();
                    ValidInputNumber.IsInt(amountToRefuelStr, out amountToRefuelInt);
                    isInt = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            try
            {
                i_Garage.RefuelVehicle(licenseNumber, fuelChoice, amountToRefuelStr);
                Client client = i_Garage.GarageClients[licenseNumber];
                Vehicle vehicle = client.Vehicle;
                Console.WriteLine($@"=================================
The vehicle successfully refueled, the current fuel amount is: {vehicle.VehicleEnergyType.CurrentAmountOfEnergy}
");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Returning to main menu..");
                Console.ReadLine();
            }
        }
    }
}
