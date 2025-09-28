namespace laba3;

public class Company
{
    public string Name { get; set; }
    public President President { get; set; }
    public List<Employer> Employers { get; set; }
    public Company(string name, President president)
    {
        Name = name;
        President = president;
        Employers = new List<Employer> { president };
    }
    public void AddEmployee(Employer employee)
    {
        Employers.Add(employee);
    }
    
}