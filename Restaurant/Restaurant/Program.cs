namespace Restaurant;

class Program
{
    public static Restaurant restaurant = new Restaurant("РЕСТОРАН1", 6);

    static void Main()
    {
        uint tableNum; //вказати номер столика або 0 щоб зайняти будь який вільний
        Table table;
        restaurant.Menu.ShowMenu();
        //Перший столик та замовлення
        tableNum = 0;
        table = restaurant.Tables.GetTable(tableNum);
        if (table is null)
        {
            if (tableNum > 0)
            {
                Printer($"\n\nСтолик {tableNum} зайнятий.\n");
            }
            else
            {
                Printer($"\n\nВсі столики зайняті.\n");
            }
        }
        else
        {
            table.ShowInfo();


            Order order = restaurant.Orders.CreateOrder(table.Id);
            order.AddOrderItem(3, 2);
            order.AddOrderItem(2, 21);
            order.AddOrderItem(1, 1);
            order.ShowOrder();
            order.EditOrderItem(1, 1);
            order.EditOrderItem(2, -3);
            restaurant.Orders.AddOrder(order);
            order.ShowOrder();
        }
        Console.ReadKey();
        //Другий столик та замовлення
        tableNum = 4;
        table = restaurant.Tables.GetTable(tableNum);
        if (table is null)
        {
            if (tableNum > 0)
            {
                Printer($"\n\nСтолик {tableNum} зайнятий.\n");
            }
            else
            {
                Printer($"\n\nВсі столики зайняті.\n");
            }
        }
        else
        {
            table.ShowInfo();

            Order order = restaurant.Orders.CreateOrder(table.Id);
            order.AddOrderItem(2, 2);
            order.AddOrderItem(1, 5);
            order.AddOrderItem(3, 4);
            order.ShowOrder();
            order.EditOrderItem(1, -2);
            order.RemoveOrderItem(3);
            restaurant.Orders.AddOrder(order);
            order.ShowOrder();
        }
        Console.ReadKey();

        //Третій столик та замовлення
        tableNum = 7;
        table = restaurant.Tables.GetTable(tableNum);
        if (table is null)
        {
            if (tableNum > 0)
            {
                Printer($"\n\nСтолик {tableNum} зайнятий.\n");
            }
            else
            {
                Printer($"\n\nВсі столики зайняті.\n");
            }
        }
        else
        {
            table.ShowInfo();

            Order order = restaurant.Orders.CreateOrder(table.Id);
            order.AddOrderItem(13, 12);
            order.AddOrderItem(5, 1);
            order.AddOrderItem(4, 1);
            order.ShowOrder();
            order.EditOrderItem(4, 1);
            order.RemoveOrderItem(5);
            restaurant.Orders.AddOrder(order);
            order.ShowOrder();
        }
        Console.ReadKey();

        //Четвертий столик та замовлення
        tableNum = 5;
        table = restaurant.Tables.GetTable(tableNum);
        if (table is null)
        {
            if (tableNum > 0)
            {
                Printer($"\n\nСтолик {tableNum} зайнятий.\n");
            }
            else
            {
                Printer($"\n\nВсі столики зайняті.\n");
            }
        }
        else
        {
            table.ShowInfo();
            Order order = restaurant.Orders.CreateOrder(table.Id);
            order.AddOrderItem(7, 12);
            order.AddOrderItem(5, 1);
            order.AddOrderItem(4, 1);
            order.ShowOrder();
            order.EditOrderItem(4, 2);
            restaurant.Orders.AddOrder(order);
            order.ShowOrder();
        }
        Console.ReadKey();

        restaurant.Orders.SetOrderReady(2);
        restaurant.Orders.ShowOrderById(2);
        
        restaurant.Orders.SetOrderReady(3);
        restaurant.Orders.ShowOrderById(3);

        restaurant.Orders.ShowActiveOrders();
        Console.ReadKey();

        restaurant.Orders.SetOrderPaid(2);
        restaurant.Orders.ShowOrderById(2);

        restaurant.Orders.ShowActiveOrders();
    }

    public static void Printer(string msg)
    {
        Console.WriteLine(msg);
    }
}