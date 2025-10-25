using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic;

namespace ConsoleUI
{
    internal class VehicleInfo
    {
        internal static void ShowVehicleInfo(ManagerSystem i_Garage)
        {
            Console.Clear();
            Console.Write("Enter the license number of the vehicle you wish to view it's status: ");
            string licenseNumber = Console.ReadLine();
            try
            {
                StringBuilder vehicleData = i_Garage.ShowVehicleInfo(licenseNumber);
                Console.WriteLine(vehicleData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press Enter to return to main menu..");
                Console.ReadLine();
            }
        }
    }
}
