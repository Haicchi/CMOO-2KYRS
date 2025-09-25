namespace ConsoleApp1;

public class Creator
{
    private static Random random = new Random();
    private static string[] phoneNames = { "IPhone 13", "IPhone 10", "Galaxy S22", "MiMix4", "IPhone15", "Sony Experia 9" };
    private static string[] companyNames = { "Sony", "Apple", "Xiaomi" };
    private static double[] directorPIBs = { 700,500,400,450,50,79 };
    

    
    public static string PhoneName()
    {
        return phoneNames[random.Next(0, phoneNames.Length)];
    }

   
    public static DateTime RandomReleaseDate()
    {
        int years = random.Next(1, 21);
        int months = random.Next(1, 13);
        int days = random.Next(1, 29);
        return DateTime.Now.AddYears(-years).AddMonths(-months).AddDays(-days);
    }

  
    public static string CompanyName()
    {
        return companyNames[random.Next(0, companyNames.Length)];
    }

   
    

   
    public static double Price()
    {
        return random.Next(5, 501);
    }

    

    
    public static Phone RandomPhone()
    {
        return new Phone(
            PhoneName(),
            CompanyName(),
            Price(),
            RandomReleaseDate()
        );
    }
}