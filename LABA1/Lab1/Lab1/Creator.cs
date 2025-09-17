namespace Lab1;

public  static class Creator
{
    private static string[] shopName = {"Rozetka","Brain","Allo","ItBox"};
    private static int[] price = {15000,21200,30000,40000,10000};
    private static string[] tovarName = {"Laptop","SmartPhone","Tablet"};
    private static Random random = new Random();

    public static string RandomShopName()
    {
        return shopName[random.Next(0, shopName.Length)];
    }

    public static int RandomPrice()
    {
        return price[random.Next(0, price.Length)];
    }

    public static string RandomTovarName()
    {
        return tovarName[random.Next(0, tovarName.Length)];
    }

    public static Shop RandomShop()
    {
        return new Shop(RandomShopName(), RandomPrice());
    }

    public static Tovar RandomTovar()
    {
        return new Tovar(RandomTovarName(),new List<Shop>(){RandomShop()});
    }
    
}