namespace laba3;

public static class Creator
{
    private static Random random = new Random();
    private static string[] names = {"Volodymyr Smith","Volodymyr Smirnov","Sasha Koen","Bogdan Kozak","Dima Bobuh","Nazar KurbanMuhamedov"};
    private static int[] ages = {35,38,32,29,28,42};
    private static string[] educations = {"High","Mid"};
    private static int[] yearsInCompany = { 5, 10, 7, 8, 4, 3 };
    private static decimal[] salary = {15000,20000,20500,24000,22500};
    public static DateTime RandomTimeStamp()
    {
        int years = random.Next(1, 60);
        int months = random.Next(1, 13);
        int days = random.Next(1, 29);
        return DateTime.Now.AddYears(-years).AddMonths(-months).AddDays(-days);
    }

    public static string RandomName()
    {
        return names[random.Next(0, names.Length)];
    }

    public static string RandomEducation()
    {
        return educations[random.Next(0, educations.Length)];
    }

    public static int RandomYearsOfCompany()
    {
        return yearsInCompany[random.Next(0, yearsInCompany.Length)];
    }

    public static decimal RandomSalary()
    {
        return salary[random.Next(0, salary.Length)];
    }

    public static int RandomAge(Employer e)
    {
        var today = DateTime.Today;
        var age = today.Year-e.BirthDate.Year;
        return age;
    }
}