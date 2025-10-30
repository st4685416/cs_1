namespace SmartHomeSystem;

public class MotionSensor : Device
{
    public string DeviceName
    {
        get { return Name; }
    }

    public override void TurnOn()
    {
        IsOn = true;
        Console.WriteLine($"{Name} активовано.");
    }

    public override void TurnOff()
    {
        IsOn = false;
        Console.WriteLine($"{Name} деактивовано.");
    }
}