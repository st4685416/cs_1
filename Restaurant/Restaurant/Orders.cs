using System.Runtime.InteropServices;

namespace Restaurant;

public class Orders
{
    private uint _lastId = 1;
    private Dictionary<uint, Order> _orders = new Dictionary<uint, Order>();

    public void AddOrder(Order order)
    {
        order.Id = _lastId;
        _orders.Add(_lastId++, order);
        order.ProcessOrder();
    }

    public Order GetOrder(uint id)
    {
        if (_orders.ContainsKey(id))
        {
            return _orders[id];
        }

        return null;
    }

    public void RemoveOrder(uint id)
    {
        if (_orders.ContainsKey(id))
        {
            _orders.Remove(id);
        }
    }

    public Order CreateOrder(uint table_id)
    {
        return new Order(table_id);
    }

    public void SetOrderReady(uint id)
    {
        if (_orders.ContainsKey(id))
        {
            _orders[id].OrderReady();
        }
    }

    public void SetOrderPaid(uint id)
    {
        if (_orders.ContainsKey(id))
        {
            _orders[id].OrderPaid();
        }
    }

    public void ShowOrderById(uint id)
    {
        if (_orders.ContainsKey(id))
        {
            _orders[id].ShowOrder();
        }
    }

    public void ShowActiveOrders()
    {
        Program.Printer($"\n--- Усі активні замовлення ---");
        foreach (var item in _orders)
        {
            if (item.Value.Status != Order.OrderStatus.Paid)
            {
                Program.Printer($"id: {item.Value.Id} | Стіл: {item.Value.TableId} | Статус: {item.Value.getCurrentStatusName()} | Сума: {item.Value.GetOrderSum().ToString("0.00")}");
            }
        }

        Program.Printer($"-------------------------------");
    }
}