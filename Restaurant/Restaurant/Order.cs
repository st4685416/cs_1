using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Restaurant;

public class Order
{
    private uint _id;
    private uint _tableId;

    private Dictionary<uint, int> _orderItems = new Dictionary<uint, int>();

    public enum OrderStatus
    {
        [Display(Name = "Новий")] New,
        [Display(Name = "В обробці")] InProgress,
        [Display(Name = "Готовий")] Ready,
        [Display(Name = "Сплачено")] Paid
    }

    private OrderStatus _status;

    public OrderStatus Status
    {
        get { return _status; }
    }

    public uint Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public uint TableId
    {
        get { return _tableId; }
    }

    public Order(uint table_id)
    {
        _tableId = table_id;
        _status = OrderStatus.New;
    }

    private void PrintStatus()
    {
        Program.Printer($"\n> Cтатус замовлення {_id} змінено: {getOrderStatusName(_status)}");
    }

    public void AddOrderItem(uint menu_id, int count)
    {
        _orderItems.Add(menu_id, count);
        Program.Printer($"\n> У замовлення додано: {Program.restaurant.Menu.GetMenuItemById(menu_id).Dish.Name}.");
    }

    public void EditOrderItem(uint menu_id, int count)
    {
        if (_orderItems.ContainsKey(menu_id))
        {
            _orderItems[menu_id] += count;
            if (_orderItems[menu_id] < 1)
            {
                _orderItems.Remove(menu_id);
            }
            else
            {
                Program.Printer($"\n> У замовленні змінено: {Program.restaurant.Menu.GetMenuItemById(menu_id).Dish.Name}.");
            }
        }
    }

    public void RemoveOrderItem(uint menu_id)
    {
        if (_orderItems.ContainsKey(menu_id))
        {
            _orderItems.Remove(menu_id);
            Program.Printer($"\n> У замовлення видалено: {Program.restaurant.Menu.GetMenuItemById(menu_id).Dish.Name}.");
        }
    }

    public void ProcessOrder()
    {
        _status = OrderStatus.InProgress;
        PrintStatus();
    }

    public void OrderReady()
    {
        _status = OrderStatus.Ready;
        PrintStatus();
    }

    public void OrderPaid()
    {
        _status = OrderStatus.Paid;
        PrintStatus();
        Program.restaurant.Tables.SetTableAvailable(_tableId);
    }

    public void ShowOrder()
    {
        double sum = 0;
        uint i = 1;
        MenuItem menuItem;
        Console.WriteLine($"\nЗамовлення №{_id} стіл №{_tableId}\nСтатус: {getOrderStatusName(_status)}");
        foreach (var item in _orderItems)
        {
            menuItem = Program.restaurant.Menu.GetMenuItemById(item.Key);
            if (menuItem != null)
            {
                sum += item.Value * menuItem.Price;
                Console.WriteLine($"{i++}. {menuItem.Dish.Name,-30}{menuItem.Price,10}{item.Value,6}");
            }
        }

        Console.WriteLine($"------------------\nВсього: {sum.ToString("0.00")}");
    }

    public double GetOrderSum()
    {
        double sum = 0;
        MenuItem menuItem;
        foreach (var item in _orderItems)
        {
            menuItem = Program.restaurant.Menu.GetMenuItemById(item.Key);
            if (menuItem != null)
            {
                sum += item.Value * menuItem.Price;
            }
        }

        return sum;
    }

    public string getCurrentStatusName()
    {
        return getOrderStatusName(_status);
    }

    private string getOrderStatusName(OrderStatus statusType)
    {
        FieldInfo field = statusType.GetType().GetField(statusType.ToString());
        DisplayAttribute displayAttribute = field.GetCustomAttribute<DisplayAttribute>();
        return displayAttribute.Name;
    }
}