public class Customer
{
    private string _customerName;
    Address address = new Address();

    public bool IsInUsa()
    {
        return address.IsInUsa();
    }
    public void SetCustomerName(string name)
    {
        _customerName = name;
    }
    public string GetName()
    {
        return _customerName;
    }
}