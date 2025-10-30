namespace SmartHomeSystem;

public class Light : Device, IEnergyConsumer
{
    public string DeviceName
    {
        get { return Name; }
    }

    public int PowerConsumption
    {
        get { return 60; }
    }

    public override void TurnOn()
    {
        IsOn = true;
        Console.WriteLine($"{Name} засвітилася.");
    }

    public override void TurnOff()
    {
        IsOn = false;
        Console.WriteLine($"{Name} вимкнена.");
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