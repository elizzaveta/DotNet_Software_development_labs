using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_lab_1
{
    class Car
    {
        public string Engine;
        public string AirBags;
        public string CentralLocking;
        public string Alarm;
        public string ClimateControl;
        public string ParkingSensors;
        public string HeatedSeats;
        public string LeatherSeats;

        public void ShowInfo()
        {
            StringBuilder sb = new StringBuilder();

            if (Engine != null)
                sb.Append("Engine:\n    " + Engine + " \n\n");
            if (AirBags != null)
                sb.Append("AirBags:\n    " + AirBags + " \n\n");
            if (CentralLocking != null)
                sb.Append("CentralLocking:\n    " + CentralLocking + " \n\n");
            if (Alarm != null)
                sb.Append("Alarm:\n    " + Alarm + " \n\n");
            if (ClimateControl != null)
                sb.Append("ClimateControl:\n    " + ClimateControl + " \n\n");
            if (ParkingSensors != null)
                sb.Append("ParkingSensors:\n    " + ParkingSensors + " \n\n");
            if (HeatedSeats != null)
                sb.Append("HeatedSeats:\n    " + HeatedSeats + " \n\n");
            if (LeatherSeats != null)
                sb.Append("LeatherSeats:\n    " + LeatherSeats + " \n");


            Console.WriteLine(sb);

        }
    }

}
