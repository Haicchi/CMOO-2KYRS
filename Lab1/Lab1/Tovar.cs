namespace Lab1;

public class Tovar
{
    private string tovarName;
    private List<Shop> shops;

    public Tovar(string tovarName, List<Shop> shops)
    {
        this.tovarName = tovarName;
        this.shops = shops;
    }

    public Tovar()
    {
        tovarName = "";
        shops = new List<Shop>();
    }

    public List<Shop> Shops
    {
        get { return shops; }
        set { shops = value; }
    }

    public string TovarName
    {
        get { return tovarName; }
        set { tovarName = value; }
    }

    public override string ToString()
    {
        string shoplist = "";
        foreach (Shop shop in shops)
        {
            shoplist += shop.ToString() + " |";
        }

        return $"Tovar: {tovarName} | Shops: {shoplist}";
    }

    public void AddShop(List<Shop> shops)
    {
        
        Console.WriteLine("Enter shop name:");
        string shopName = Console.ReadLine();
        Console.WriteLine("Enter shop price:");
        int shopPrice = int.Parse(Console.ReadLine());
        Shop newshop = new Shop(shopName, shopPrice);
        Console.WriteLine($"Adding shop with name - {newshop.ShopName}");
        shops.Add(newshop);
        
        
        
        
    }

    public Tovar CreateTovar()
    {
        List<Shop> shops = new List<Shop>();
        Console.WriteLine("Enter tovar name:");
        tovarName = Console.ReadLine();
        Console.WriteLine("Enter how many shops do you want to add to this tovar:");
        int shopCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < shopCount; i++)
        {
            AddShop(shops);
            
        }
        return new Tovar(tovarName, shops);
    }

}