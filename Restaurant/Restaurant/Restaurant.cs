namespace Restaurant;

public class Restaurant
{
    private string _restaurantName;
    private Menu _menu = new Menu();
    private Orders _orders = new Orders();
    private Dishes _dishes = new Dishes();
    private Tables _tables = new Tables();

    public Restaurant(string restaurantName, uint tableCount = 10)
    {
        _restaurantName = restaurantName;
        _tables.AddTables(tableCount);
        _menu.MakeCurrentMenu();
        _menu.SyncWithDishes(_dishes);
    }

    public string RestaurantName
    {
        get { return _restaurantName; }
    }

    public Menu Menu
    {
        get { return _menu; }
    }

    public Tables Tables
    {
        get { return _tables; }
    }

    public Orders Orders
    {
        get { return _orders; }
    }

    
    public void PrintAllDishes()
    {
        _dishes.PrintAllDishes();
    }
}