using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Restaurant;

public abstract class Dish
{
    private uint _id;
    private string _name;
    private string _description;
    protected Dishes.DishType _category;


    public Dish(string name, string description = "")
    {
        _name = name;
        _description = description;
    }

    public uint Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    public Dishes.DishType Category
    {
        get { return _category; }
        set { _category = value; }
    }

    public abstract string GetDishInfo();
    public abstract string GetMenuInfo();

    protected string GetDishCategoryName(Dishes.DishType dishType)
    {
        FieldInfo field = dishType.GetType().GetField(dishType.ToString());
        DisplayAttribute displayAttribute = field.GetCustomAttribute<DisplayAttribute>();
        return displayAttribute.Name;
    }
}