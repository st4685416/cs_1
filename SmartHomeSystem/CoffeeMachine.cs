namespace SmartHomeSystem;

public class CoffeeMachine : Device, IEnergyConsumer
{
    public string DeviceName
    {
        get { return Name; }
    }

    public int PowerConsumption
    {
        get { return 1000; }
    }

    public override void TurnOn()
    {
        IsOn = true;
        Console.WriteLine($"{Name} почала готувати каву.");
    }

    public override void TurnOff()
    {
        IsOn = false;
        Console.WriteLine($"{Name} завершила роботу.");
    }

    public double GetEnergyUsage(int hours)
    {
        if (IsOn)
        {
            return PowerConsumption * hours / 1000.0;
        }

        return 0;
    }
}