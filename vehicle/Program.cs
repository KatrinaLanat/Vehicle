using System;

namespace DemoEncapsulation
{
    class Vehicle
    {
        private int _vehicleId;
        private string _make;
        private string _model;
        private float _fuelEfficiency;

        public int VehicleId
        {
            get => _vehicleId;
            set
            {
                if (value > 0)
                    _vehicleId = value;
                else
                    throw new ArgumentException("Vehicle ID must be positive.");
            }
        }

        public string Make
        {
            get => _make;
            set => _make = value ?? throw new ArgumentException("Make cannot be null.");
        }

        public string Model
        {
            get => _model;
            set => _model = value ?? throw new ArgumentException("Model cannot be null.");
        }

        public float FuelEfficiency
        {
            get => _fuelEfficiency;
            set
            {
                if (value > 0)
                    _fuelEfficiency = value;
                else
                    throw new ArgumentException("Fuel efficiency must be positive.");
            }
        }

        public Vehicle(int vehicleId, string make, string model, float fuelEfficiency)
        {
            VehicleId = vehicleId;
            Make = make;
            Model = model;
            FuelEfficiency = fuelEfficiency;
        }
    }

    class Car : Vehicle
    {
        private int _numDoors;
        private bool _isAutomatic;

        public int NumDoors
        {
            get => _numDoors;
            set
            {
                if (value > 0)
                    _numDoors = value;
                else
                    throw new ArgumentException("Number of doors must be positive.");
            }
        }

        public bool IsAutomatic
        {
            get => _isAutomatic;
            set => _isAutomatic = value;
        }

        public Car(int vehicleId, string make, string model, float fuelEfficiency, int numDoors, bool isAutomatic)
            : base(vehicleId, make, model, fuelEfficiency)
        {
            NumDoors = numDoors;
            IsAutomatic = isAutomatic;
        }

        public float CalculateFuelConsumption(float distance)
        {
            return distance / FuelEfficiency;
        }
    }

    class Motorcycle : Vehicle
    {
        private int _engineCC;
        private bool _isSportBike;

        public int EngineCC
        {
            get => _engineCC;
            set
            {
                if (value > 0)
                    _engineCC = value;
                else
                    throw new ArgumentException("Engine CC must be positive.");
            }
        }

        public bool IsSportBike
        {
            get => _isSportBike;
            set => _isSportBike = value;
        }

        public Motorcycle(int vehicleId, string make, string model, float fuelEfficiency, int engineCC, bool isSportBike)
            : base(vehicleId, make, model, fuelEfficiency)
        {
            EngineCC = engineCC;
            IsSportBike = isSportBike;
        }

        public float CalculateFuelConsumption(float distance)
        {
            float consumption = distance / FuelEfficiency;
            return IsSportBike ? consumption * 1.1f : consumption;
        }
    }

    class Truck : Vehicle
    {
        private float _cargoCapacity;
        private bool _isHeavyDuty;

        public float CargoCapacity
        {
            get => _cargoCapacity;
            set
            {
                if (value > 0)
                    _cargoCapacity = value;
                else
                    throw new ArgumentException("Cargo capacity must be positive.");
            }
        }

        public bool IsHeavyDuty
        {
            get => _isHeavyDuty;
            set => _isHeavyDuty = value;
        }

        public Truck(int vehicleId, string make, string model, float fuelEfficiency, float cargoCapacity, bool isHeavyDuty)
            : base(vehicleId, make, model, fuelEfficiency)
        {
            CargoCapacity = cargoCapacity;
            IsHeavyDuty = isHeavyDuty;
        }

        public float CalculateFuelConsumption(float distance, float cargoWeight)
        {
            float basicConsumption = distance / FuelEfficiency;
            float cargoFactor = cargoWeight / CargoCapacity;
            float heavyDutyFactor = IsHeavyDuty ? 1.2f : 1.0f;
            return basicConsumption * cargoFactor * heavyDutyFactor;
        }
    }

    class Program
    {
        static void Main()
        {
            float distance = 150.0f;

            Car car = new Car(1, "Toyota", "Camry", 15.0f, 4, true);
            Motorcycle motorcycle = new Motorcycle(2, "Yamaha", "R1", 20.0f, 1000, true);
            Truck truck = new Truck(3, "Ford", "F-150", 8.0f, 5.0f, true);

            Console.WriteLine("Fuel Consumption Calculations:");
            Console.WriteLine($"Car (ID: {car.VehicleId}, Model: {car.Make} {car.Model}) for {distance} km: {car.CalculateFuelConsumption(distance):0.00} liters");
            Console.WriteLine($"Motorcycle (ID: {motorcycle.VehicleId}, Model: {motorcycle.Make} {motorcycle.Model}) for {distance} km: {motorcycle.CalculateFuelConsumption(distance):0.00} liters");

            float cargoWeight = 3.0f;
            Console.WriteLine($"Truck (ID: {truck.VehicleId}, Model: {truck.Make} {truck.Model}) for {distance} km with {cargoWeight} tons cargo: {truck.CalculateFuelConsumption(distance, cargoWeight):0.00} liters");

            Console.ReadKey();
        }
    }
}