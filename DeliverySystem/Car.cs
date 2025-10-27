namespace DeliverySystem;

public class Car : Vehicle
{
    protected int doors;
    protected double fuelLevel;
    

    public Car(string brand, int year, double mileage, int doors) : base(brand, year, mileage, maxSpeed: 180)
    {
        this.doors = doors;
        this.fuelLevel = 50;
    }
    public Car(string brand, int year, double mileage, int doors, double maxSpeed) : base(brand, year, mileage, maxSpeed: maxSpeed)
    {
        this.doors = doors;
        this.fuelLevel = 50;
    }

    public override string GetInfo()
    {
        return $"Car: {this.brand} ({this.year}), Doors: {this.doors}, Fuel: {this.fuelLevel}L";
    }

    public override void Move(double distance)
    {
        base.Move(distance);
        this.fuelLevel -= distance * 0.1;
        if (this.fuelLevel < 0)
        {
            this.fuelLevel = 0;
        }
    }

    public void Refuel(double liters)
    {
        this.fuelLevel += liters;
        if (this.fuelLevel > 50)
        {
            this.fuelLevel = 50;
        }
    }
}