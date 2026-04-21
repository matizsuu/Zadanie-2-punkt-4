class Topping:
    def __init__(self, name, price):
        self.name = name
        self.price = price

class Pizza:
    def __init__(self):
        self.base_price = 15.00
        self.toppings = []

    def add_topping(self, topping):
        self.toppings.append(topping)

    def get_price(self):
        total_price = self.base_price
        for topping in self.toppings:
            total_price += topping.price
        return total_price

class Order:
    def __init__(self):
        self.pizzas = []
        
    def add_pizza(self, pizza):
        self.pizzas.append(pizza)

    def get_total_price(self):
        total_sum = 0
        for pizza in self.pizzas:
            total_sum += pizza.get_price()
        return total_sum


menu = [
    Topping("Ser", 3.00),
    Topping("Pepperoni", 3.50),
    Topping("Pieczarki", 2.00),
    Topping("Oliwki", 2.50)
]

print("Witaj w wirtualnej pizzerii! Zaczynamy przygotowywać Twoją pizzę.")
moja_pizza = Pizza()

while True:
    print("\n--- MENU DODATKÓW ---")
    for indeks, dodatek in enumerate(menu):
        print(f"{indeks + 1}. {dodatek.name} ({dodatek.price} zł)")
    print("0. Zakończ dodawanie i podlicz rachunek")
    
    wybor = input("\nWybierz numer opcji: ")
    
    if wybor == '0':
        break 
    elif wybor in ['1', '2', '3', '4']:
        wybrany_indeks = int(wybor) - 1 
        wybrany_dodatek = menu[wybrany_indeks]
        
        moja_pizza.add_topping(wybrany_dodatek)
        print(f"Dodano: {wybrany_dodatek.name}!")
    else:
        print("Nieznana opcja. Spróbuj ponownie.")

moje_zamowienie = Order()
moje_zamowienie.add_pizza(moja_pizza)

print(f"\n Gotowe! Cena całkowita Twojego zamówienia to: {moje_zamowienie.get_total_price()} zł")