using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GarageLogic.Client;

namespace GarageLogic
{
    public class ManagerSystem
    {
        private Dictionary<String, Client> m_GarageClients;

        public ManagerSystem()
        {
            this.m_GarageClients = new Dictionary<string, Client>();
        }

        public Dictionary<String, Client> GarageClients
        {
            get { return m_GarageClients; }

            set { m_GarageClients = value; }
        }

        public void InsertVehicle(string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle)
        {
            if (IsInGarage(i_Vehicle.LicenseNumber))
            {
                Client existClient = m_GarageClients[i_Vehicle.LicenseNumber];
                existClient.VehicleStatus = eVehicleStatus.InRepair;
                throw new ArgumentException("The Vehicle is already in the garage, moved to InRepair status. Returning to main menu..");
            }

            Client newClient = new Client(i_OwnerName, i_OwnerPhone, i_Vehicle);
            m_GarageClients.Add(i_Vehicle.LicenseNumber, newClient);
        }

        public void RemoveVehicle(string i_LicenseNumber)
        {
            if (!IsInGarage(i_LicenseNumber))
            {
                throw new ArgumentException($"License number does not exists in the garage");
            }
            m_GarageClients.Remove(i_LicenseNumber);
        }

        internal bool IsInGarage(string i_LicenseNumber)
        {
            return m_GarageClients.ContainsKey(i_LicenseNumber);
        }

        public StringBuilder ShowVehicleInfo(string i_LicenseNumber)
        {
            if (!IsInGarage(i_LicenseNumber))
            {
                throw new ArgumentException($"License number does not exists in the garage");
            }

            Client client = m_GarageClients[i_LicenseNumber];
            StringBuilder info = new StringBuilder("");
            info.Append($"Vehicle informations:{Environment.NewLine}");
            info.Append(client.Vehicle.ToString());

            return info;
        }

        public List<string> VehicleListInGarage()
        {
            List<string> LicenseNumbersList = new List<string>(m_GarageClients.Keys);

            return LicenseNumbersList;
        }

        public List<string> VehicleListByStatusInGarage(eVehicleStatus i_Status)
        {
            List<string> LicenseNumbersList = new List<string>();

            foreach (Client client in m_GarageClients.Values)
            {
                if (i_Status.Equals(client.VehicleStatus))
                {
                    LicenseNumbersList.Add(client.Vehicle.LicenseNumber);
                }
            }

            return LicenseNumbersList;
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, eVehicleStatus i_Status)
        {
            if (!IsInGarage(i_LicenseNumber))
            {
                throw new ArgumentException($"License number does not exists in the garage");
            }

            Client existClient = m_GarageClients[i_LicenseNumber];
            existClient.VehicleStatus = i_Status;
        }

        public void PumpWheelsToMax(string i_LicenseNumber)
        {
            if (!IsInGarage(i_LicenseNumber))
            {
                throw new ArgumentException($"License number does not exists in the garage");
            }

            Client existClient = m_GarageClients[i_LicenseNumber];
            Vehicle clientVehicle = existClient.Vehicle;
            foreach (Wheel wheel in clientVehicle.Wheels)
            {
                wheel.PumpAirToMax();
            }
        }

        public void RefuelVehicle(string i_LicenseNumber, Fuel.eFuelType i_FuelType, string i_FuelAmount)
        {
            if (!IsInGarage(i_LicenseNumber))
            {
                throw new ArgumentException($"License number does not exists in the garage");
            }

            if (!isFuelVehicle(i_LicenseNumber))
            {
                throw new ArgumentException($"This is not a fuel type vehicle");
            }

            if (!isCorrcetFuelType(i_LicenseNumber, i_FuelType))
            {
                Client client = m_GarageClients[i_LicenseNumber];
                Vehicle vehicle = client.Vehicle;
                Fuel.eFuelType currentFuelType = (vehicle.VehicleEnergyType as Fuel).FuelType;
                throw new ArgumentException($@"Pay attention this is not the correct fuel for your vehicle.
Notice your fuel is: -- {currentFuelType} --");
            }

            int amount = 0;
            ValidInputNumber.IsInt(i_FuelAmount, out amount);
            Client existClient = m_GarageClients[i_LicenseNumber];
            Vehicle clientVehicle = existClient.Vehicle;
            Energy fuelTank = clientVehicle.VehicleEnergyType;
            (fuelTank as Fuel).Refuel(i_FuelAmount);
        }

        private bool isFuelVehicle(string i_LicenseNumber)
        {
            Client client = m_GarageClients[i_LicenseNumber];
            Vehicle clientVehicle = client.Vehicle;
            Energy energy = clientVehicle.VehicleEnergyType;

            return energy.EnergyTypeOfVehicle == Energy.eEnergyTypes.Fuel;
        }

        private bool isCorrcetFuelType(string i_LicenseNumber, Fuel.eFuelType i_FuelType)
        {
            Client client = m_GarageClients[i_LicenseNumber];
            Vehicle clientVehicle = client.Vehicle;
            Fuel.eFuelType currentFuelType = (clientVehicle.VehicleEnergyType as Fuel).FuelType;

            return currentFuelType.Equals(i_FuelType);
        }

        public void ChargeVehicle(string i_LicenseNumber, string i_TimeAmount)
        {
            if (!IsInGarage(i_LicenseNumber))
            {
                throw new ArgumentException($"License number does not exists in the garage");
            }

            if (isFuelVehicle(i_LicenseNumber))
            {
                throw new ArgumentException($"This is not a electric type vehicle");
            }

            Client existClient = m_GarageClients[i_LicenseNumber];
            Vehicle clientVehicle = existClient.Vehicle;
            Energy battery = clientVehicle.VehicleEnergyType;
            (battery as Electric).Recharge(i_TimeAmount);
        }

        public bool IsEmpty()
        {
            return m_GarageClients.Count == 0;
        }
    }
}