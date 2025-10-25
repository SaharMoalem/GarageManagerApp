using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Client
    {
        private string m_VehicleOwnerName;
        private string m_VehicleOwnerPhone;
        private eVehicleStatus m_VehicleStatus;
        private Vehicle m_Vehicle;

        internal Client(string i_VehicleOwnerName, string i_VehicleOwnerPhone, Vehicle i_Vehicle)
        {
            this.m_VehicleOwnerName = i_VehicleOwnerName;
            this.m_VehicleOwnerPhone = i_VehicleOwnerPhone;
            this.m_VehicleStatus = eVehicleStatus.InRepair;
            this.m_Vehicle = i_Vehicle;
        }

        public eVehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }

            set { m_VehicleStatus = value; }
        }

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }

            set { m_Vehicle = value; }
        }

        public enum eVehicleStatus
        {
            InRepair = 1,
            Repaired = 2,
            PaidUp = 3
        }
    }
}