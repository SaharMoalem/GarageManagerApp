using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic;

namespace ConsoleUI
{
    internal class PumpVehicleWheels
    {
        internal static void PumpVehicleWheelsUI(ManagerSystem i_Garage)
        {
            Console.Clear();
            Console.Write("Enter the license number of the vehicle you wish to pump it's wheels: ");
            string licenseNumber = Console.ReadLine();
            try
            {
                i_Garage.PumpWheelsToMax(licenseNumber);
                Client currentClient = i_Garage.GarageClients[licenseNumber];
                float currentAirPressure = currentClient.Vehicle.Wheels[0].CurrentAirPressure;
                Console.WriteLine($@"================================================
Pumping wheels has been done, the air pressure in each wheel is: -- {currentAirPressure} --");
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
