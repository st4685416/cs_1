namespace SmartHomeSystem;

class Program
{
    public SmartHomeController SHC;

    public static void Main()
    {
        SmartHomeController SHC = new SmartHomeController();

        Light devLight = new Light();
        devLight.Name = "Лампа у вітальні";
        SHC.AddDevice(devLight);
        SHC.AddEnergyDevice(devLight);

        AirConditioner devAirConditioner = new AirConditioner();
        devAirConditioner.Name = "Кондиціонер у спальні";
        SHC.AddDevice(devAirConditioner);
        SHC.AddEnergyDevice(devAirConditioner);

        CoffeeMachine devCoffeeMachine = new CoffeeMachine();
        devCoffeeMachine.Name = "Кавомашина на кухні";
        SHC.AddDevice(devCoffeeMachine);
        SHC.AddEnergyDevice(devCoffeeMachine);

        MotionSensor devMotionSensor = new MotionSensor();
        devMotionSensor.Name = "Датчик руху у коридорі";
        SHC.AddDevice(devMotionSensor);

        SHC.TurnAllOn();

        devLight.PrintStatus();
        devAirConditioner.PrintStatus();
        devCoffeeMachine.PrintStatus();
        devMotionSensor.PrintStatus();

        SHC.ShowEnergyReport(5);
        SHC.TurnAllOff();
    }
}