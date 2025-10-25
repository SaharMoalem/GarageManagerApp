using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class CreateNewVehicle
    {
        public static Vehicle NewVehicle(eVehicleTypes i_VehicleTypeAsInt)
        {
            eVehicleTypes vehicleType = (eVehicleTypes)i_VehicleTypeAsInt;
            Vehicle createdVehicle;

            switch (vehicleType)
            {
                case eVehicleTypes.FuelMotorcycle:
                    createdVehicle = new FuelMotorcycle();
                    break;
                case eVehicleTypes.ElectricMotorcycle:
                    createdVehicle = new ElectricMotorcycle();
                    break;
                case eVehicleTypes.FuelCar:
                    createdVehicle = new FuelCar();
                    break;
                case eVehicleTypes.ElectricCar:
                    createdVehicle = new ElectricCar();
                    break;
                case eVehicleTypes.Truck:
                    createdVehicle = new Truck();
                    break;
                default:
                    throw new ArgumentException("Invalid Vehicle Type");
            }

            return createdVehicle;
        }

        public enum eVehicleTypes
        {
            FuelMotorcycle = 1,
            ElectricMotorcycle = 2,
            FuelCar = 3,
            ElectricCar = 4,
            Truck = 5
        }
    }
}