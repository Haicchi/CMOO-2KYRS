namespace Lab1;

public class Shop
{
    private string shopName;
    private int price;

    public Shop()
    {
        shopName = "";
        price = 0;
    }

    public Shop(string shopName, int price)
    {
        this.shopName = shopName;
        this.price = price;
    }

    public string ShopName
    {
        get { return shopName; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Shop name cannot be null or empty");
            }
            shopName = value;
        }
    }

    public int Price
    {
        get { return price; }
        set
        {
            if (!int.TryParse(value.ToString(), out price))
            {
                throw new ArgumentException("Price must be an integer");
            }
            price= value;
        }
    }

    public override string ToString()
    {
        return $"Shop name: {shopName} | Price: {price}";
    }
}