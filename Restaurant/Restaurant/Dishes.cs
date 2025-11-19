using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Restaurant;

public class Dishes
{
    public enum DishType
    {
        [Display(Name = "Основна страва")] Food,
        [Display(Name = "Десерт")] Dessert,
        [Display(Name = "Перша страва")] Soup,
        [Display(Name = "Напій")] Drink,
        [Display(Name = "Вода")] Water,
        [Display(Name = "Сік")] Juice,
        [Display(Name = "Алкоголь")] Alcohol
    }


    private Dictionary<uint, Dish> _Dishes = new Dictionary<uint, Dish>();
    private uint _lastId = 1;

    public void AddDish(Dish dish)
    {
        dish.Id = _lastId;
        _Dishes.Add(_lastId++, dish);
    }

    public void RemoveDish(uint id)
    {
        _Dishes.Remove(id);
    }

    public Dishes()
    {
        LoadDishes();
    }

    public void CreateDrink(string name, string description = "")
    {
        AddDish(new Drink(name, description));
    }

    public void CreateFood(string name, string description = "")
    {
        AddDish(new Food(name, description));
    }

    public void PrintAllDishes()
    {
        foreach (Dish dish in _Dishes.Values)
        {
            Console.WriteLine(dish.GetDishInfo());
        }
    }

    public void LoadDishes()
    {
        foreach (DishType dishType in Enum.GetValues(typeof(DishType)))
        {
            string fileName = $"{dishType.ToString()}.json";
            try
            {
                string jsonString = File.ReadAllText(fileName);
                switch (dishType)
                {
                    case DishType.Food:
                    case DishType.Soup:
                    case DishType.Dessert:
                        List<Food> tmpFood = JsonSerializer.Deserialize<List<Food>>(jsonString);
                        foreach (Food food in tmpFood)
                        {
                            food.Category = dishType;
                            AddDish(food);
                        }

                        break;
                    case DishType.Drink:
                    case DishType.Juice:
                    case DishType.Water:
                        List<Drink> tmpDrink = JsonSerializer.Deserialize<List<Drink>>(jsonString);
                        foreach (Drink drink in tmpDrink)
                        {
                            drink.Category = dishType;
                            AddDish(drink);
                        }

                        break;
                    case DishType.Alcohol:
                        List<AlcoholDrink> tmpAlcohol = JsonSerializer.Deserialize<List<AlcoholDrink>>(jsonString);
                        foreach (AlcoholDrink alcohol in tmpAlcohol)
                        {
                            alcohol.Category = dishType;
                            AddDish(alcohol);
                        }

                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    public Dish GetDishByName(string name)
    {
        foreach (Dish dish in _Dishes.Values)
        {
            if (dish.Name == name)
            {
                return dish;
            }
        }

        return null;
    }
}