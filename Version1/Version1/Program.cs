using System;

namespace VehicleHierarchy
{
    
    class Vehicle
    {
        public int VehicleId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public float FuelEfficiency { get; set; } 

        public Vehicle(int vehicleId, string make, string model, float fuelEfficiency)
        {
            VehicleId = vehicleId;
            Make = make;
            Model = model;
            FuelEfficiency = fuelEfficiency;
        }

        public virtual float CalculateFuelConsumption(float distance)
        {
            return distance / FuelEfficiency;
        }
    }

    
    class Car : Vehicle
    {
        public int NumDoors { get; set; }
        public bool IsAutomatic { get; set; }

        public Car(int vehicleId, string make, string model, float fuelEfficiency, int numDoors, bool isAutomatic)
            : base(vehicleId, make, model, fuelEfficiency)
        {
            NumDoors = numDoors;
            IsAutomatic = isAutomatic;
        }
    }

    
    class Motorcycle : Vehicle
    {
        public int EngineCC { get; set; }
        public bool IsSportBike { get; set; }

        public Motorcycle(int vehicleId, string make, string model, float fuelEfficiency, int engineCC, bool isSportBike)
            : base(vehicleId, make, model, fuelEfficiency)
        {
            EngineCC = engineCC;
            IsSportBike = isSportBike;
        }

        public override float CalculateFuelConsumption(float distance)
        {
            float fuelConsumption = base.CalculateFuelConsumption(distance);
            if (IsSportBike)
            {
                fuelConsumption *= 1.1f; 
            }
            return fuelConsumption;
        }
    }

    
    class Truck : Vehicle
    {
        public float CargoCapacity { get; set; } 
        public bool IsHeavyDuty { get; set; }

        public Truck(int vehicleId, string make, string model, float fuelEfficiency, float cargoCapacity, bool isHeavyDuty)
            : base(vehicleId, make, model, fuelEfficiency)
        {
            CargoCapacity = cargoCapacity;
            IsHeavyDuty = isHeavyDuty;
        }

        public float CalculateFuelConsumption(float distance, float cargoWeight)
        {
            float cargoFactor = cargoWeight / CargoCapacity;
            float heavyDutyFactor = IsHeavyDuty ? 1.2f : 1.0f;
            return base.CalculateFuelConsumption(distance) * cargoFactor * heavyDutyFactor;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
          
            Car car = new Car(1, "Toyota", "Camry", 15.0f, 4, true);
            Motorcycle motorcycle = new Motorcycle(2, "Yamaha", "R1", 20.0f, 1000, true);
            Truck truck = new Truck(3, "Ford", "F-150", 8.0f, 5.0f, true);

            float distance = 150.0f; 

            
            Console.WriteLine("Fuel Consumption Calculations:");
            Console.WriteLine($"Car (ID: {car.VehicleId}, Model: {car.Make} {car.Model}) for {distance} km: {car.CalculateFuelConsumption(distance):0.00} liters");
            Console.WriteLine($"Motorcycle (ID: {motorcycle.VehicleId}, Model: {motorcycle.Make} {motorcycle.Model}) for {distance} km: {motorcycle.CalculateFuelConsumption(distance):0.00} liters");
            Console.WriteLine($"Truck (ID: {truck.VehicleId}, Model: {truck.Make} {truck.Model}) for {distance} km with 3 tons cargo: {truck.CalculateFuelConsumption(distance, 3.0f):0.00} liters");
        }
    }
}