namespace laba3;

public abstract class Employer
{
    
    public string Name { get; set; }
    
    public int Age { get; set; }
    public DateTime BirthDate { get; set; }
    public int YearsOfService { get; set; }
    public decimal Salary { get; set; } 
    public string Education { get; set; } 
    public string Position { get; set; }
    

    

    public override string ToString()
    {
        return $"{Name} | ({Position}) | Time on work: {YearsOfService} р. | Salary: {Salary} | Education: {Education}";
    }
}