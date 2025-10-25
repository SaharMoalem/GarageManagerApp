using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic;

namespace ConsoleUI
{
    internal class InsertNewVehicle
    {
        private static readonly int sr_MaxOption = Enum.GetNames(typeof(CreateNewVehicle.eVehicleTypes)).Length;
        private static readonly int sr_MaxLicenseType = Enum.GetNames(typeof(Motorcycle.eMotorcycleLicenseType)).Length;

        internal static void InsertVehicleUI(ManagerSystem i_Garage)
        {
            Console.Clear();
            bool isAlreadyExist = false;
            Console.Write(@"Inserting your vehicle to The Garage-

Enter your Name: ");
            string ownerName = "";
            bool isName = false;

            while (!isName)
            {
                ownerName = Console.ReadLine();
                if (ownerName.Length > 0)
                {
                    isName = true;
                }
                else
                {
                    Console.Write(@"
Invalid name, please try again: ");
                }
            }

            Console.Write(@"=================================
Enter your Phone Number (10 digits): ");
            bool isPhoneNumber = false;
            int countDigitsInPhone = 0;
            string phoneNumber = "";    

            while (!isPhoneNumber)
            {
                phoneNumber = Console.ReadLine();
                for(int i = 0; i < phoneNumber.Length; i++)
                {
                    if (phoneNumber[i] >= '0' && phoneNumber[i] <= '9')
                    {
                        countDigitsInPhone++;
                    }
                }

                if (countDigitsInPhone == 10)
                {
                    isPhoneNumber = true;
                }
                else
                {
                    countDigitsInPhone = 0;
                    Console.Write(@"
Invalid phone number, please try again: ");
                }
            }

            Console.WriteLine(@"=================================
Choose your vehicle type (press the option number):

1. Fuel Motorcycle

2. Electric Motorcycle

3. Fuel Car

4. Electric Car

5. Truck
");
            int vehicleTypeInt = 0;
            ValidInput.ValidInputUI(1, sr_MaxOption, out vehicleTypeInt);
            CreateNewVehicle.eVehicleTypes vehicleType = (CreateNewVehicle.eVehicleTypes)vehicleTypeInt;
            Console.Clear();
            Console.WriteLine($"You choose {vehicleType.ToString()}");
            Vehicle vehicleToInsert = CreateNewVehicle.NewVehicle(vehicleType);
            Console.Write(@"
Enter your license number (7-8 letters): ");
            string licenseNumberStr = "";
            bool isLicenseNumber = false;
            while (!isLicenseNumber)
            {
                licenseNumberStr = Console.ReadLine();
                if (licenseNumberStr.Length == 7 || licenseNumberStr.Length == 8)
                {
                    isLicenseNumber = true;
                }
                else
                {
                    Console.Write(@"
Invalid license number, please try again: ");
                }
            }

            vehicleToInsert.LicenseNumber = licenseNumberStr;
            try
            {
                i_Garage.InsertVehicle(ownerName, phoneNumber, vehicleToInsert);
            }
            catch (Exception exeption)
            {
                Console.WriteLine(exeption.Message);
                isAlreadyExist = true;
            }

            if (!isAlreadyExist)
            {
                Console.Write(@"=================================
Enter your Vehicle Model name: ");
                vehicleToInsert.ModelName = Console.ReadLine();
                Console.Write(@"=================================
Enter your Vehicle Producer Name for the wheels: ");
                vehicleToInsert.Wheels[0].ProducerName = Console.ReadLine();
                if (vehicleToInsert is Car)
                {
                    Console.WriteLine(@"=================================
Type the name of the color for the car (choose one of the four options):

Yellow, White, Black, Blue
");
                    bool isColor = false;
                    while (!isColor)
                    {
                        try
                        {
                            string colorChosen = Console.ReadLine();
                            (vehicleToInsert as Car).SetColor(colorChosen);
                            isColor = true;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    Console.Write(@"=================================
How many door would you like for the car? (choose between 2-5): ");
                    bool isDoorsNumber = false;
                    while (!isDoorsNumber)
                    {
                        try
                        {
                            string numberChosen = Console.ReadLine();
                            (vehicleToInsert as Car).SetDoorsNumber(numberChosen);
                            isDoorsNumber = true;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }

                if (vehicleToInsert is Motorcycle)
                {
                    Console.Write(@"=================================
Write Engine Capacity for the morocycle (in cc): ");
                    bool isEngineCapacity = false;
                    while (!isEngineCapacity)
                    {
                        try
                        {
                            string engineCapacity = Console.ReadLine();
                            int engineCapacityInt;
                            ValidInputNumber.IsInt(engineCapacity, out engineCapacityInt);
                            (vehicleToInsert as Motorcycle).EngineCapacity = engineCapacityInt;
                            isEngineCapacity = true;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    Console.WriteLine(@"=================================
Choose License Type for the Motorcycle (press the option number):

1. A

2. A1

3. A2

4. B
");
                    bool isLicenseType = false;
                    while (!isLicenseType)
                    {
                        try
                        {
                            string licenseTypeStr = Console.ReadLine();
                            int licenseTypeInt = 0;
                            ValidInputNumber.IntValid(licenseTypeStr, 1, sr_MaxLicenseType, out licenseTypeInt);
                            (vehicleToInsert as Motorcycle).LicenseType = (Motorcycle.eMotorcycleLicenseType)licenseTypeInt;
                            isLicenseType = true;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }

                if (vehicleToInsert is Truck)
                {
                    Console.Write(@"=================================
Does the truck carry hazardous materials? (yes or no): ");
                    string input = Console.ReadLine();
                    while (!input.Equals("yes") && !input.Equals("no"))
                    {
                        Console.Write("Invalid input, please try again: ");
                        input = Console.ReadLine();
                    }

                (vehicleToInsert as Truck).HazardousMaterials = input.Equals("yes");
                    Console.Write(@"=================================
Write maximum carring weight for the truck (in kg): ");
                    bool isFloat = false;
                    while (!isFloat)
                    {
                        try
                        {
                            string carringWeightStr = Console.ReadLine();
                            float carringWeightFloat;
                            ValidInputNumber.IsFloat(carringWeightStr, out carringWeightFloat);
                            (vehicleToInsert as Truck).MaximumCarryWeight = carringWeightFloat;
                            isFloat = true;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }

                Console.WriteLine(@"=================================
The vehicle was successfully inserted !");
            }

            Console.ReadLine();
        }
    }
}
