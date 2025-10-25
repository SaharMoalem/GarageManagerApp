using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic;

namespace ConsoleUI
{
    internal class VehicleRecharge
    {
        internal static void VehicleRechargeUI(ManagerSystem i_Garage)
        {
            Console.Clear();
            Console.Write("Enter the license number of the vehicle you wish to recharge: ");
            string licenseNumber = Console.ReadLine();
            Console.WriteLine(@"For How long will you want to charge the vehicle? (in hours)");
            string timeAmountStr = "";
            float timeAmountFloat = 0f;
            bool isFloat = false;
            while (!isFloat)
            {
                try
                {
                    timeAmountStr = Console.ReadLine();
                    ValidInputNumber.IsFloat(timeAmountStr, out timeAmountFloat);
                    isFloat = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            try
            {
                i_Garage.ChargeVehicle(licenseNumber, timeAmountStr);
                Client client = i_Garage.GarageClients[licenseNumber];
                Vehicle vehicle = client.Vehicle;
                Console.WriteLine($@"=================================
The vehicle successfully charged, the current battery percentage is: {vehicle.VehicleEnergyType.EnergyPercentageBalance} %
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
