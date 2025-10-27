namespace DeliverySystem;

public class Van : Car
{
    private double loadCapacity;
    private double currentLoad;

    public Van(string brand, int year, double mileage, int doors, double loadCapacity) : base(brand, year, mileage,
        doors, maxSpeed:140)
    {
        this.loadCapacity = loadCapacity;
        this.currentLoad = 0;
    }

    public override string GetInfo()
    {
        return $"Van: {this.brand} ({this.year}), Doors: {this.doors}, Load: {this.currentLoad}/{this.loadCapacity}kg, Fuel: {this.fuelLevel}L";
    }

    public void LoadCargo(double weight)
    {
        if (this.currentLoad + weight <= this.loadCapacity)
        {
            this.currentLoad += weight;
            Console.WriteLine($"{weight} kg loaded into the van.");
        }
        else
        {
            Console.WriteLine("Too heavy! Cannot load more cargo.");
        }
    }

    public void UnloadCargo()
    {
        currentLoad = 0;
        Console.WriteLine("Van unloaded.");
    }
}