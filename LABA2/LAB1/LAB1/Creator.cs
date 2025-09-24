namespace LAB1;
public static class Creator{
private static Random random = new Random();

    // Масиви з даними для випадкової генерації
    private static string[] companyNames = { "FoodSolutions", "GlobalDynamics", "WhiteCore", "BlackMesa", "WhiteCredit", "FoodMarketing" };
    private static string[] businessProfiles = { "IT", "Marketing", "Finance", "Logistics", "Manufacturing", "Healthcare" };
    private static string[] directorPIBs = { "White Winston Salken", "Black Jhon Doe", "Black Valeria Simens", "White Jessica Doe" };
    private static string[] adresses = { "10 Downing Street, London", "221B Baker Street, London", "123 High Street, Birmingham", "45 Oak Avenue, Manchester", "789 Elm Road, Dublin"};

    
    public static string RandomCompanyName()
    {
        return companyNames[random.Next(0, companyNames.Length)];
    }

   
    public static DateTime RandomFoundationDate()
    {
        int years = random.Next(1, 21);
        int months = random.Next(1, 13);
        int days = random.Next(1, 29);
        return DateTime.Now.AddYears(-years).AddMonths(-months).AddDays(-days);
    }

  
    public static string RandomBusinessProfile()
    {
        return businessProfiles[random.Next(0, businessProfiles.Length)];
    }

   
    public static string RandomDirectorPIB()
    {
        return directorPIBs[random.Next(0, directorPIBs.Length)];
    }

   
    public static int RandomAmountOfWorkers()
    {
        return random.Next(5, 501);
    }

    
    public static string RandomAdress()
    {
        return adresses[random.Next(0, adresses.Length)];
    }

    
    public static Company RandomCompany()
    {
        return new Company(
            RandomCompanyName(),
            RandomFoundationDate(),
            RandomBusinessProfile(),
            RandomDirectorPIB(),
            RandomAmountOfWorkers(),
            RandomAdress()
        );
    }
}