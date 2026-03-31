//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace C__Inheritance_Assignment
//{
//    // Base Class
//    class Vehicle
//    {
//        public string VehicleNumber { get; set; }
//        public string Brand { get; set; }

//        public void StartVehicle()
//        {
//            Console.WriteLine("Vehicle started");
//        }
//    }

//    // Derived Class - Car
//    class Car : Vehicle
//    {
//        public string FuelType { get; set; }
//    }

//    // Sealed Class - ElectricCar
//    public sealed class ElectricCar : Car
//    {
//        public int BatteryCapacity { get; set; }
//    }

//    internal class Assignment_4
//    {
//        static void Main()
//        {
//            ElectricCar ec = new ElectricCar()
//            {
//                VehicleNumber = "AP1234",
//                Brand = "Tata",
//                FuelType = "Electric",
//                BatteryCapacity = 75
//            };

//            ec.StartVehicle();
//            Console.WriteLine($"Brand: {ec.Brand}, Battery: {ec.BatteryCapacity} kWh");
//        }
//    }
//}
