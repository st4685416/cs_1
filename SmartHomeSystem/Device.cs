namespace SmartHomeSystem;

public abstract class Device:ISwitchable
{
    private string _Name;
    private bool _IsOn;
    public string Name
    {
        get
        {
            return _Name;
        }
        set
        {
            _Name = value;
        }
    }

    public bool IsOn
    {
        get
        {
            return _IsOn;
        }
        protected set
        {
            _IsOn = value;
        }
    }

    public abstract void TurnOn();
    public abstract void TurnOff();
    
    public void PrintStatus()
    {
        if (IsOn)
        {
            Console.WriteLine($"{Name}: увімкнено");
        }
        else
        {
            Console.WriteLine($"{Name}: вимкнено");
        }
    }
}