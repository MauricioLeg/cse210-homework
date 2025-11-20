public class Product
{
    private string _productName;
    private string _productId;
    private double _productPrice;
    private int _productQuantity;

    public void SetProduct(string name, string id, double price, int quantity)
    {
        _productName = name;
        _productId = id;
        _productPrice = price;
        _productQuantity = quantity;
    }
    public double GetProductPrice()
    {
        return _productPrice * _productQuantity;;
    }
    public string GetProductInfo()
    {
        return $"{_productId} - {_productName}: ${_productPrice}";
    }
    public string GetName()
    {
        return _productName;
    }

    public string GetId()
    {
        return _productId;
    }

    public int GetQuantity()
    {
        return _productQuantity;
    }
}