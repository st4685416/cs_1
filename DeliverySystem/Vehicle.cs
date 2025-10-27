namespace DeliverySystem;

public class Vehicle
{
    protected string brand;
    protected int year;
    protected double mileage;
    protected double maxSpeed;

    public Vehicle(string brand, int year, double mileage, double maxSpeed)
    {
        this.brand = brand;
        this.year = year;
        this.mileage = mileage;
        this.maxSpeed = maxSpeed;
    }

    public virtual string GetInfo()
    {
        return $"{this.brand} ({this.year}), Mileage: {this.mileage} km";
    }

    public virtual double GetMaxSpeed()
    {
        return maxSpeed;
    }

    public virtual void Move(double distance)
    {
        this.mileage+= distance;
        Console.WriteLine($"{this.brand} drove {distance} km.");
    }
}