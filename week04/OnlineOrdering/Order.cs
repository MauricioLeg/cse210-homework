public class Order
{
    private List<Product> _products = new List<Product>();
    private int _usaShip = 5;
    private int _extShip = 35;
    private Customer _customer = new Customer();
    private Address _address;

    public void SetCustomer(Customer customer, Address address)
    {
        _customer = customer;
        _address = address;
    }
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
    public double GetTotalPrice()
    {;
        double firstPrice = 0;
        foreach (Product product in _products)
        {
            firstPrice += product.GetProductPrice();
        }

        bool inCountry = _address.IsInUsa();
        double totalPrice = 0;
        if (inCountry == true)
        {
            totalPrice = firstPrice + _usaShip;
        }
        if (inCountry == false)
        {
            totalPrice = firstPrice + _extShip;
        }
        return totalPrice;
    }
    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product product in _products)
        {
            label += $"-{product.GetName()} ({product.GetId()}) x{product.GetQuantity()}\n";
        }
        return label;
    }
    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_address.GetAddress()}";
    }
}