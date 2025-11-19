namespace Restaurant;

public class AlcoholDrink : Drink
{
    private double _alcohol;

    public AlcoholDrink(string name, string description, double alcohol) : base(name, description)
    {
        _alcohol = alcohol;
    }

    public double Alcohol
    {
        get { return _alcohol; }
        set { _alcohol = value; }
    }

    public override string GetDishInfo()
    {
        return $"{Id}. {Name} - Міцність: {Alcohol}%";
    }

    public override string GetMenuInfo()
    {
        return $"{Name} ({Alcohol}%)";
    }
}