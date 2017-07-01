namespace _07_Speed_Racing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumption, double distanceTraveled)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumption = fuelConsumption;
            DistanceTraveled = distanceTraveled;
        }

        public string Model { get; private set; }

        public double FuelAmount { get; private set; }

        public double FuelConsumption { get; private set; }

        public double DistanceTraveled { get; private set; }

        public bool Travel(double distamce)
        {
            var fuelSpend = distamce * FuelConsumption;

            if (fuelSpend > this.FuelAmount)
            {
                return false;
            }

            this.FuelAmount -= fuelSpend;
            this.DistanceTraveled += distamce;
            return true;
        }
    }
}
