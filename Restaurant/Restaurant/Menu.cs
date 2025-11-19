using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.Json;

namespace Restaurant;

public class Menu
{
    private List<MenuItem> _menuItems = new List<MenuItem>();
    private uint _lastId = 1;

    private void MakeMenu(string typeName)
    {
        string fileName = $"{typeName}Menu.json";
        try
        {
            string jsonString = File.ReadAllText(fileName);
            List<MenuItem> tmpItems = JsonSerializer.Deserialize<List<MenuItem>>(jsonString);
            foreach (MenuItem item in tmpItems)
            {
                item.Id = _lastId++;
                _menuItems.Add(item);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void MakeCurrentMenu()
    {
        MakeMenu("standard");
        MakeMenu("today");
    }

    public void SyncWithDishes(Dishes dishes)
    {
        foreach (MenuItem item in _menuItems)
        {
            item.Dish = dishes.GetDishByName(item.DishName);
        }
    }

    public void ShowMenu()
    {
        uint drinkMenuNum = 1;
        uint alcoholMenuNum = 1;
        uint juiceMenuNum = 1;
        uint waterMenuNum = 1;
        uint soupMenuNum = 1;
        uint foodMenuNum = 1;
        uint dessertMenuNum = 1;
        string menuDrinkString = "";
        string menuAlcoholString = "";
        string menuJuiceString = "";
        string menuWaterString = "";
        string menuSoupString = "";
        string menuFoodString = "";
        string menuDessertString = "";
        foreach (MenuItem item in _menuItems)
        {
            if (item.Dish is null) continue;
            switch (item.Dish.Category)
            {
                case Dishes.DishType.Food:
                    menuFoodString += $"{foodMenuNum++}. {item.Dish.GetMenuInfo()} {item.Amount}{item.AmountName} {item.Price}\n";
                    break;
                case Dishes.DishType.Soup:
                    menuSoupString += $"{soupMenuNum++}. {item.Dish.GetMenuInfo()} {item.Amount}{item.AmountName} {item.Price}\n";
                    break;
                case Dishes.DishType.Dessert:
                    menuDessertString += $"{dessertMenuNum++}. {item.Dish.GetMenuInfo()} {item.Amount}{item.AmountName} {item.Price}\n";
                    break;
                case Dishes.DishType.Drink:
                    menuDrinkString += $"{drinkMenuNum++}. {item.Dish.GetMenuInfo()} {item.Amount}{item.AmountName} {item.Price}\n";
                    break;
                case Dishes.DishType.Juice:
                    menuJuiceString += $"{juiceMenuNum++}. {item.Dish.GetMenuInfo()} {item.Amount}{item.AmountName} {item.Price}\n";
                    break;
                case Dishes.DishType.Water:
                    menuWaterString += $"{waterMenuNum++}. {item.Dish.GetMenuInfo()} {item.Amount}{item.AmountName} {item.Price}\n";
                    break;
                case Dishes.DishType.Alcohol:
                    menuAlcoholString += $"{alcoholMenuNum++}. {item.Dish.GetMenuInfo()} {item.Amount}{item.AmountName} {item.Price}\n";
                    break;
            }
        }

        Program.Printer($"--- МЕНЮ РЕСТОРАНУ {Program.restaurant.RestaurantName} ---");
        PrintSubMenu(Dishes.DishType.Alcohol, menuAlcoholString);
        PrintSubMenu(Dishes.DishType.Food, menuFoodString);
        PrintSubMenu(Dishes.DishType.Soup, menuSoupString);
        PrintSubMenu(Dishes.DishType.Dessert, menuDessertString);
        PrintSubMenu(Dishes.DishType.Juice, menuJuiceString);
        PrintSubMenu(Dishes.DishType.Drink, menuDrinkString);
        PrintSubMenu(Dishes.DishType.Water, menuWaterString);
        Program.Printer($"----------------------------------------------------------");
        Console.ReadKey();
    }

    private void PrintSubMenu(Dishes.DishType dishType, string subMenuStr)
    {
        FieldInfo field = dishType.GetType().GetField(dishType.ToString());
        DisplayAttribute displayAttribute = field.GetCustomAttribute<DisplayAttribute>();
        string subMenuName = displayAttribute.Name;
        Console.WriteLine($"{subMenuName}\n{subMenuStr}");
    }

    public MenuItem GetMenuItemById(uint id)
    {
        foreach (MenuItem item in _menuItems)
        {
            if (item.Id == id)
            {
                return item;
            }
        }

        return null;
    }
}