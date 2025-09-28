namespace laba3;

public class President:Employer
{
    public President(string name, DateTime birthDate, int yearsOfService, decimal salary, string education)
    {
        Name = name;
        
        BirthDate = birthDate;
        YearsOfService = yearsOfService;
        Salary = salary;
        Education = education;
        Position = "President";
    }
}