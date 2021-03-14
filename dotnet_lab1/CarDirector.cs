using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_lab_1
{
    class CarDirector
    {
        public Car BuildCar( CarBuilder builder)
        {
            builder.SetEngine();
            builder.SetAirBags();
            builder.SetCentralLocking();
            builder.SetAlarm();
            builder.SetClimateControl();
            builder.SetParkingSensors();
            builder.SetHeatedSeats();
            builder.SetLeatherSeats();

            return builder.GetCar();

        }
    }
}