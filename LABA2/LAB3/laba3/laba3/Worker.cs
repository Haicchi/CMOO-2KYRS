namespace laba3;

public class Worker:Employer
{
    public Worker(string name, DateTime birthDate, int yearsOfService, decimal salary, string education)
    {
        Name = name;
        
        BirthDate = birthDate;
        YearsOfService = yearsOfService;
        Salary = salary;
        Education = education;
        Position = "Worker";
    }
}