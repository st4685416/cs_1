namespace SmartHomeSystem;

public class SmartHomeController
{
    private List<ISwitchable> SDevices = new List<ISwitchable>();
    private List<IEnergyConsumer> EDevices = new List<IEnergyConsumer>();

    public void AddDevice(ISwitchable device)
    {
        SDevices.Add(device);
    }

    public void AddEnergyDevice(IEnergyConsumer device)
    {
        EDevices.Add(device);
    }

    public void TurnAllOn()
    {
        foreach (ISwitchable device in SDevices)
        {
            device.TurnOn();
        }
    }

    public void TurnAllOff()
    {
        foreach (ISwitchable device in SDevices)
        {
            device.TurnOff();
        }
    }

    public void ShowEnergyReport(int hours)
    {
        double EUsage,ESumUsage=0;
        Console.WriteLine($"Звіт про споживання енергії за {hours} год:");
        foreach (IEnergyConsumer device in EDevices)
        {
            EUsage = device.GetEnergyUsage(hours);
            Console.WriteLine($"{device.DeviceName}: {EUsage:F2} кВт·год (потужність: {device.PowerConsumption} Вт)");
            ESumUsage += EUsage;
        }
        Console.WriteLine($"Загальне споживання: {ESumUsage:F2} кВт·год\nВартість (~4 грн/кВт·год): {ESumUsage * 4:F2} грн");
    }
}