// See https://aka.ms/new-console-template for more information

using laba3;

Console.WriteLine("Hello, World!");
President president = new President("Ayin Quixote", Creator.RandomTimeStamp(),  25,50000, "High");

Company company = new Company("Lobotomy Corporation",president);
for (int i = 0; i < 50; i++)
{
      
            
    var worker = new Worker(
        Creator.RandomName(),
        Creator.RandomTimeStamp(),
        Creator.RandomYearsOfCompany(),
        Creator.RandomSalary(),
        Creator.RandomEducation()
        
    );
    worker.Age = Creator.RandomAge(worker);
    
    
    company.AddEmployee(worker);
}
for (int i = 0; i < 15; i++)
{
    var manager = new Manager(
        Creator.RandomName(),
        Creator.RandomTimeStamp(),
        Creator.RandomYearsOfCompany(),
        Creator.RandomSalary(),
        "Higher"
        
    );
    manager.Age = Creator.RandomAge(manager);
    
    company.AddEmployee(manager);
}

Console.WriteLine("Task 1");
var workersCount = company.Employers.Count(e => e is Worker);
Console.WriteLine(workersCount);
Console.WriteLine("Task 2");
var workersSalary = company.Employers.Where(e=> e is Worker).Sum(e => e.Salary);
Console.WriteLine(workersSalary);
Console.WriteLine("Task 3");
var top10WorkersByService = company.Employers.OfType<Worker>().OrderByDescending(w => w.YearsOfService).Take(10).ToList();
var top10butyoungestwithigg = top10WorkersByService.Where(w=>w.Education == "High").OrderBy(w => w.Age).First();
Console.WriteLine(top10butyoungestwithigg.ToString());
Console.WriteLine("Task 4");;
var youngestmanager = company.Employers.OfType<Manager>().OrderByDescending(w => w.Age).First();
var oldestmanager = company.Employers.OfType<Manager>().OrderBy(w => w.Age).First();
Console.WriteLine(oldestmanager.ToString());
Console.WriteLine("Task 5");
var octoberWorkersByPosition = company.Employers.OfType<Worker>().Where(w => w.BirthDate.Month == 10).GroupBy(w => w.Position).ToDictionary(g => g.Key, g => g.ToList());
foreach (var group in octoberWorkersByPosition)
{
    Console.WriteLine($"Position:{group.Key}|{group.Value.Count} people:");
    foreach (var worker in group.Value)
    {
        Console.WriteLine($"| {worker.Name}, DOB: {worker.BirthDate:dd.MM.yyyy}, Age: {worker.Age}");
    }
}

Console.WriteLine("Task 6");
var volodymyrs = company.Employers.Where(e => e.Name.Contains("Volodymyr ")).OrderBy(e => e.Age).First();
Console.WriteLine($"{volodymyrs.ToString()} We happy to say that you getting a {volodymyrs.Salary/3} premie");
