using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");

    // Order 1
    Customer customer1 = new Customer();
    customer1.SetCustomerName("Sarah Johnson");
    Address address1 = new Address();
    address1.SetAddress("123 Maple Street", "Springfield", "IL", "USA");
    
    Order order1 = new Order();
    
    order1.SetCustomer(customer1, address1);
    Product product1 = new Product();
    product1.SetProduct("Laptop Stand", "P1001", 45.99, 2);
    order1.AddProduct(product1);

    Product product2 = new Product();
    product2.SetProduct("Wireless Mouse", "P1002", 25.50, 1);
    order1.AddProduct(product2);
    
    // Display order 1
    Console.WriteLine("===== ORDER 1 =====");
    Console.WriteLine(order1.GetPackingLabel());
    Console.WriteLine(order1.GetShippingLabel());
    Console.WriteLine($"Total Price: ${order1.GetTotalPrice()}");
    Console.WriteLine();

    // Order 2
    Customer customer2 = new Customer();
    customer2.SetCustomerName("Miguel Rodriguez");
    Address address2 = new Address();
    address2.SetAddress("456 Oak Avenue", "Toronto", "ON", "Canada");
    
    Order order2 = new Order();
    
    order2.SetCustomer(customer2, address2);
    Product product3 = new Product();
    product3.SetProduct("USB-C Cable (6ft)", "P2003", 12.99, 3);
    order2.AddProduct(product3);

    Product product4 = new Product();
    product4.SetProduct("Wireless Mouse", "P1002", 25.50, 1);
    order2.AddProduct(product4);

    Product product5 = new Product();
    product5.SetProduct("Screen Protector", "P2005", 8.50, 4);
    order2.AddProduct(product5);
    
    // Display order 2
    Console.WriteLine("===== ORDER 2 =====");
    Console.WriteLine(order2.GetPackingLabel());
    Console.WriteLine(order2.GetShippingLabel());
    Console.WriteLine($"Total Price: ${order2.GetTotalPrice()}");
    Console.WriteLine();
    //

    }
}