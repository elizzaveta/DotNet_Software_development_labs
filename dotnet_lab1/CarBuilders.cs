using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_lab_1
{
    abstract class CarBuilder
    {
        protected Car _car;
        public CarBuilder()
        {
            _car = new Car();
        }
        public abstract void SetEngine();
        public abstract void SetAirBags();
        public abstract void SetCentralLocking();
        public abstract void SetAlarm();
        public abstract void SetClimateControl();
        public abstract void SetParkingSensors();
        public abstract void SetHeatedSeats();
        public abstract void SetLeatherSeats();
        public Car GetCar()
        {
            return _car;
        }
    }

    class CarBuilder_Model1_Basic : CarBuilder
    {
        public override void SetEngine()
        {
            _car.Engine = "Basic engine";
        }
        public override void SetAirBags()
        {
            _car.AirBags = "Basic air bags";
        }
        public override void SetCentralLocking()
        {
            _car.CentralLocking = "Basic central locking";
        }
        public override void SetAlarm()
        {
            _car.Alarm = "Basic alarm";
        }
        public override void SetClimateControl() { }
        public override void SetParkingSensors() { }
        public override void SetHeatedSeats() { }
        public override void SetLeatherSeats() { }
    }
    class CarBuilder_Model1_Comfort : CarBuilder
    {
        public override void SetEngine()
        {
            _car.Engine = "Comfort Engine";
        }
        public override void SetAirBags()
        {
            _car.AirBags = "Comfort air bags";
        }
        public override void SetCentralLocking()
        {
            _car.CentralLocking = "Comfort central locking";
        }
        public override void SetAlarm()
        {
            _car.Alarm = "Comfort alarm";
        }
        public override void SetClimateControl()
        {
            _car.ClimateControl = "Comfort climate control";
        }
        public override void SetParkingSensors()
        {
            _car.ParkingSensors = "Comfort parking sensors";
        }
        public override void SetHeatedSeats() { }
        public override void SetLeatherSeats() { }
    }
    class CarBuilder_Model1_Premium : CarBuilder
    {
        public override void SetEngine()
        {
            _car.Engine = "Premium engine";
        }
        public override void SetAirBags()
        {
            _car.AirBags = "Premium air bags";
        }
        public override void SetCentralLocking()
        {
            _car.CentralLocking = "Premium central locking";
        }
        public override void SetAlarm()
        {
            _car.Alarm = "Premium alarm";
        }
        public override void SetClimateControl()
        {
            _car.ClimateControl = "Premium climate control";
        }
        public override void SetParkingSensors()
        {
            _car.ParkingSensors = "Premium parking sensors";
        }
        public override void SetHeatedSeats()
        {
            _car.HeatedSeats = "Premium heated seats";
        }
        public override void SetLeatherSeats()
        {
            _car.LeatherSeats = "Premium leather seats";
        }
    }
}
