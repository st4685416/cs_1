namespace Restaurant;

public class Food : Dish
{
    string _ingredients;

    public Food(string name, string description) : base(name, description)
    {
        _ingredients = "";
    }

    public string Ingredients
    {
        get { return _ingredients; }
        set { _ingredients = value; }
    }

    public override string GetDishInfo()
    {
        return $"{Id}. {Name} - {Ingredients}";
    }

    public override string GetMenuInfo()
    {
        return $"{Name} ({Ingredients})";
    }
}