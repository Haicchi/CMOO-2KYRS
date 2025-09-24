namespace LAB3;

static class Creator
{
    private static Random random = new Random();
    private static string[] clientNames = {"Alex","Vadim","Sonya","Max"};
    private static int[] clientPriorityes = {1,2,3,4,5};
    

    public static string RandomClientName()
    {
        return clientNames[random.Next(0, clientNames.Length)];
    }

    public static int RandomClientPriority()
    {
        return clientPriorityes[random.Next(0, clientPriorityes.Length)];
    }

    public static DateTime RandomTimeStamp()
    {
        int years = random.Next(1, 21);
        int months = random.Next(1, 13);
        int days = random.Next(1, 29);
        return DateTime.Now.AddYears(-years).AddMonths(-months).AddDays(-days);
    }


    public static Client RandomClient()
    {
        return new Client(RandomClientName(), RandomClientPriority(), RandomTimeStamp());
    }
}