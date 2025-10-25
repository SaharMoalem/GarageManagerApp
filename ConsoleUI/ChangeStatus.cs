using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic;

namespace ConsoleUI
{
    internal class ChangeStatus
    {
        private static readonly int sr_MaxStatusOption = Enum.GetNames(typeof(Client.eVehicleStatus)).Length;

        internal static void ChangeStatusUI(ManagerSystem i_Garage)
        {
            Console.Clear();
            Console.Write("Enter the license number of the vehicle you wish to change it's status: ");
            string licenseNumber = Console.ReadLine();
            try
            {
                Client currentClient = i_Garage.GarageClients[licenseNumber];
                Client.eVehicleStatus oldStatus = currentClient.VehicleStatus;
                Console.WriteLine($@"================================================
Choose the new status of the vehicle (press the option number):

1. IN REPAIR

2. REPAIRED

3. PAID UP
");

                int userChoice = 0;
                ValidInput.ValidInputUI(1, sr_MaxStatusOption, out userChoice);
                Client.eVehicleStatus status = (Client.eVehicleStatus)userChoice;
                i_Garage.ChangeVehicleStatus(licenseNumber, status);
                Console.WriteLine($"The vehicle moved from status {oldStatus} to {status}");

                if(status == Client.eVehicleStatus.PaidUp)
                {
                    Console.WriteLine("Thank you for using the Garage!");
                }
            }
            catch
            {
                Console.WriteLine("License number does not exists in the garage");
            }
            finally
            {
                Console.WriteLine("Returning to main menu..");
                Console.ReadLine();
            }
        }
    }
}
