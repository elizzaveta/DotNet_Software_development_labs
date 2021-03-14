using System;

namespace dotnet_lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to The Car Salon!\n");
            Console.WriteLine("Choose the complectation of Model1:\n");
            Console.WriteLine("1 - Basic\n2 - Comfort\n3 - Premium\n");

            string complectation_index = Console.ReadLine();
            CarBuilder builder = CarBuilder_OutOfIndex(complectation_index);

            CarDirector director = new CarDirector();
            Car car = director.BuildCar(builder);

            Console.WriteLine("\nYour car complectation:\n");
            car.ShowInfo();
            Console.WriteLine("~~\n");


            Console.ReadKey();

        }
        public static CarBuilder CarBuilder_OutOfIndex(string complectation_index)
        {
            switch (complectation_index)
            {
                case "1":
                    return new CarBuilder_Model1_Basic();
                case "2":
                    return new CarBuilder_Model1_Comfort();
                case "3":
                    return new CarBuilder_Model1_Premium();
                default:
                    return new CarBuilder_Model1_Basic();
            }
        }
        //public static void showCarEquipment(Car car)
        //{
        //    Console.WriteLine("\n~Your car is done:\n");
        //    Console.WriteLine(car.exterior + "\n" + car.interior + "\n" + car.comfort + "\n" + car.sequrity + "\n" + car.multimedia + "\n");
        //}
    }
}
