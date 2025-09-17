namespace LAB3;

static class Creator
{
    private static Random random = new Random();
    private static string[] clientNames = {"Alex","Vadim","Sonya","Max"};
    private static int[] clientPriorityes = {1,2,3,4,5};
    private static DateTime[] timestamps = {DateTime.Now, DateTime.UtcNow, DateTime.MaxValue};

    public static string RandomClientName()
    {
        return clientNames[random.Next(0, clientNames.Length)];
    }

    public static int RandomClientPriority()
    {
        return clientPriorityes[random.Next(0, clientPriorityes.Length)];
    }

    public static DateTime RandomTimestamp()
    {
        return timestamps[random.Next(0, timestamps.Length)];
    }

    public static Client RandomClient()
    {
        return new Client(RandomClientName(), RandomClientPriority());
    }
}