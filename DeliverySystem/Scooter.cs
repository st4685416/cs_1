namespace DeliverySystem;

public class Scooter : Vehicle
{
    private int batteryCapacity;
    private double batteryLevel;

    public Scooter(string brand, int year, double mileage, int batteryCapacity) : base(brand, year, mileage,
        maxSpeed: 45)
    {
        this.batteryCapacity = batteryCapacity;
        this.batteryLevel = 100;
    }

    public override string GetInfo()
    {
        return $"Scooter: {this.brand} ({this.year}), Battery: {this.batteryLevel}% of {this.batteryCapacity}Ah";
    }

    public override void Move(double distance)
    {
        base.Move(distance);
        if (this.batteryLevel > 0)
        {
            this.batteryLevel -= distance * 0.5;
        }
        else
        {
            this.batteryLevel = 0;
        }
    }

    public void Charge()
    {
        this.batteryLevel = 100;
        Console.WriteLine($"{this.brand} has been fully charged.");
    }
}