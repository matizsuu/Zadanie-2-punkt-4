using System;
using System.Collections.Generic;

public class Topping
{
    public string Name;
    public double Price;

    public Topping(string name, double price)
    {
        this.Name = name;
        this.Price = price;
    }
}

public class Pizza
{
    public double BasePrice;
    public List<Topping> Toppings;

    public Pizza()
    {
        this.BasePrice = 15.00;
        this.Toppings = new List<Topping>();
    }

    public void AddTopping(Topping topping)
    {
        this.Toppings.Add(topping);
    }

    public double GetPrice()
    {
        double totalPrice = this.BasePrice;
        foreach (Topping topping in this.Toppings)
        {
            totalPrice += topping.Price;
        }
        return totalPrice;
    }
}

public class Order
{
    public List<Pizza> Pizzas;

    public Order()
    {
        this.Pizzas = new List<Pizza>();
    }

    public void AddPizza(Pizza pizza)
    {
        this.Pizzas.Add(pizza);
    }

    public double GetTotalPrice()
    {
        double totalSum = 0;
        foreach (Pizza pizza in this.Pizzas)
        {
            totalSum += pizza.GetPrice();
        }
        return totalSum;
    }
}

public class Program
{
    public static void Main()
    {
        List<Topping> menu = new List<Topping>
        {
            new Topping("Ser", 3.00),
            new Topping("Pepperoni", 3.50),
            new Topping("Pieczarki", 2.00),
            new Topping("Oliwki", 2.50)
        };

        Console.WriteLine("Witaj w wirtualnej pizzerii! Zaczynamy przygotowywać Twoją pizzę.");
        Pizza mojaPizza = new Pizza();

        while (true)
        {
            Console.WriteLine("\n--- MENU DODATKÓW ---");
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {menu[i].Name} ({menu[i].Price} zł)");
            }
            Console.WriteLine("0. Zakończ dodawanie i podlicz rachunek");

            Console.Write("\nWybierz numer opcji: ");
            string wybor = Console.ReadLine();

            if (wybor == "0")
            {
                break;
            }
            
            if (int.TryParse(wybor, out int numer) && numer >= 1 && numer <= menu.Count)
            {
                Topping wybranyDodatek = menu[numer - 1];
                mojaPizza.AddTopping(wybranyDodatek);
                Console.WriteLine($"Dodano: {wybranyDodatek.Name}!");
            }
            else
            {
                Console.WriteLine("Nieznana opcja. Spróbuj ponownie.");
            }
        }

        Order mojeZamowienie = new Order();
        mojeZamowienie.AddPizza(mojaPizza);

        Console.WriteLine($"\nGotowe! Cena całkowita Twojego zamówienia to: {mojeZamowienie.GetTotalPrice()} zł");
    }
}