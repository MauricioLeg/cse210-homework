public class Customer
{
    private string _customerName;
    Address _address = new Address();

    public bool IsInUsa()
    {
        return _address.IsInUsa();
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