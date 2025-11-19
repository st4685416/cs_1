namespace Restaurant;

public class Drink : Dish
{
    public Drink(string name, string description) : base(name, description)
    {
    }


    public override string GetDishInfo()
    {
        return $"{Id}. {Name}";
    }

    public override string GetMenuInfo()
    {
        return $"{Name}";
    }
}