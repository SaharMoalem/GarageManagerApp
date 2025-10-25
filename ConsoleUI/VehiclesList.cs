using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic;

namespace ConsoleUI
{
    internal class VehiclesList
    {
        private static readonly int sr_MaxStatusOption = Enum.GetNames(typeof(Client.eVehicleStatus)).Length;

        internal static void VehiclesListUI(ManagerSystem i_Garage)
        {
            Console.Clear();
            Console.WriteLine($@"
Choose one of the options (press the option number):

1. Show all license numbers of vehilce that in In Repair status

2. Show all license numbers of vehilce that in Repaired status

3. Show all license numbers of vehilce that in Paid up status

4. Show all license numbers
");
            int optionInt = 0;
            ValidInput.ValidInputUI(1, sr_MaxStatusOption + 1, out optionInt);
            List<String> LicensesToShow = new List<string>();
            Console.Clear();
            switch (optionInt)
            {
                case 1:
                    LicensesToShow = i_Garage.VehicleListByStatusInGarage(Client.eVehicleStatus.InRepair);
                    break;
                case 2:
                    LicensesToShow = i_Garage.VehicleListByStatusInGarage(Client.eVehicleStatus.Repaired);
                    break;
                case 3:
                    LicensesToShow = i_Garage.VehicleListByStatusInGarage(Client.eVehicleStatus.PaidUp);
                    break;
                case 4:
                    LicensesToShow = i_Garage.VehicleListInGarage();
                    break;
            }

            string title = (optionInt == 4) ? @"==============================
License Numbers List: " : $@"==============================
License Numbers List {(Client.eVehicleStatus)optionInt}:
";
            Console.WriteLine(title);
            foreach (string licenseNumber in LicensesToShow)
            {
                Console.WriteLine(licenseNumber);
            }
            
            Console.WriteLine($@"
Returning to main menu..");
            Console.ReadLine();
        }
    }
}
