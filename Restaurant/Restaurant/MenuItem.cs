namespace Restaurant;

public class MenuItem
{
    private uint _id;
    private string _dishName;
    private double _price;
    private uint _amount;
    private string _amountName;

    public MenuItem(string dishName, string amountName, double price, uint amount)
    {
        _dishName = dishName;
        _price = price;
        _amountName = amountName;
        _amount = amount;
    }

    public uint Id
    {
        get { return _id; }
        set { _id = value; }
    }

    private Dish _dish;

    public Dish Dish
    {
        get { return _dish; }
        set { _dish = value; }
    }

    public double Price
    {
        get { return _price; }
        set
        {
            if (value >= 0)
            {
                _price = value;
            }
        }
    }

    public uint Amount
    {
        get { return _amount; }
        set
        {
            if (value >= 0)
            {
                _amount = value;
            }
        }
    }

    public string DishName
    {
        get { return _dishName; }
        set { _dishName = value; }
    }

    public string AmountName
    {
        get { return _amountName; }
        set { _amountName = value; }
    }
}