using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic;

namespace ConsoleUI
{
    internal class RunGarage
    {
        private static readonly int sr_MaxOptionToChoose = Enum.GetNames(typeof(eOptions)).Length;
        private static ManagerSystem s_Garage;

        internal static void Run()
        {
            s_Garage = new ManagerSystem();
            bool garageRun = true;
            while (garageRun)
            {
                introMessage();
                int choosenOption = 0;
                ValidInput.ValidInputUI(1, sr_MaxOptionToChoose, out choosenOption);
                bool isEmpty = s_Garage.IsEmpty();
                if (isEmpty && (eOptions)choosenOption != eOptions.InsertNewVehicle && (eOptions)choosenOption != eOptions.Exit)
                {
                    emptyGarageMessage();
                    Console.ReadLine();
                    Console.Clear();
                }

                switch ((eOptions)choosenOption)
                {
                    case eOptions.InsertNewVehicle:
                        InsertNewVehicle.InsertVehicleUI(s_Garage);
                        break;

                    case eOptions.VehicleInfo:
                        if (!isEmpty)
                        {
                            VehicleInfo.ShowVehicleInfo(s_Garage);
                        }

                        break;

                    case eOptions.VehiclesList:
                        if (!isEmpty)
                        {
                            VehiclesList.VehiclesListUI(s_Garage);
                        }

                        break;

                    case eOptions.ChangeStatus:
                        if (!isEmpty)
                        {
                            ChangeStatus.ChangeStatusUI(s_Garage);
                        }

                        break;

                    case eOptions.PumpVehicleWheels:
                        if (!isEmpty)
                        {
                            PumpVehicleWheels.PumpVehicleWheelsUI(s_Garage);
                        }

                        break;

                    case eOptions.VehicleRefuel:
                        if (!isEmpty)
                        {
                            VehicleRefueling.VehicleRefuelingUI(s_Garage);
                        }

                        break;

                    case eOptions.VehicleRecharge:
                        if (!isEmpty)
                        {
                            VehicleRecharge.VehicleRechargeUI(s_Garage);
                        }

                        break;
                    
                    case eOptions.Exit:
                        garageRun = false;
                        break;
                }

                Console.Clear();
            }

            exitMessage();
        }

        private static void introMessage()
        {
            Console.WriteLine(@"Welcome to The Garage! What is your desired action? (press the option number)

1. Insert new vehicle to garage

2. Show vehicle information

3. Show list of all license numbers in the garage

4. Change Vehicle Status

5. Pumping all wheels of vehicle

6. Fuel vehicle

7. Charge vehicle battery

8. Exit
");
        }

        private static void emptyGarageMessage()
        {
            Console.WriteLine(@"The operation could not be performed, since The Garage is empty. Returning to main menu..");
        }

        private static void exitMessage()
        {
            Console.WriteLine(@"Thank you for using The Garage,

see you next time...");
            Console.ReadLine();
        }

        private enum eOptions
        {
            InsertNewVehicle = 1,
            VehicleInfo = 2,
            VehiclesList = 3,
            ChangeStatus = 4,
            PumpVehicleWheels = 5,
            VehicleRefuel = 6,
            VehicleRecharge = 7,
            Exit = 8
        }
    }
}
