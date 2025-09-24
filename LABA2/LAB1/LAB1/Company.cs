namespace LAB1;

public class Company
{
    private string companyName;
    private DateTime dateOfFoundation;
    private string profile;
    private string directorPIB;
    private int amountOfWorkers;
    private string adress;

    public Company()
    {
        companyName = "";
        dateOfFoundation = DateTime.Now;
        profile = "";
        directorPIB = "";
        amountOfWorkers = 0;
        adress = "";
        
    }

    public Company(string companyName, DateTime dateOfFoundation, string profile, string directorPIB, int amountOfWorkers,string adress)
    {
        this.companyName = companyName;
        this.dateOfFoundation = dateOfFoundation;
        this.profile = profile;
        this.directorPIB = directorPIB;
        this.amountOfWorkers = amountOfWorkers;
        this.adress = adress;
    }

    public string CompanyName
    {
        get { return companyName; }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                Console.WriteLine("Company name cannot be null or empty.");
                return;
            }
            companyName = value;
        }
    }

    public DateTime DateOfFoundation
    {
        get { return dateOfFoundation; }
        set
        {
            if (value == null)
            {
                Console.WriteLine("Date of Foundation cannot be null.");
            }
            dateOfFoundation = value;
        }
    }

    public string Profile
    {
        get { return profile; }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                Console.WriteLine("Profile cannot be null or empty.");
            }
            profile = value;
        }
    }

    public string DirectorPIB
    {
        get { return directorPIB; }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                Console.WriteLine("Director PIB cannot be null or empty.");
            }
            directorPIB = value;
        }
    }

    public int AmountOfWorkers
    {
        get { return amountOfWorkers; }
        set
        {
            if (!(value is int))
            {
                Console.WriteLine("Amount of workers cannot be zero.");
            }
            amountOfWorkers = value;
        }
    }

    public string Adress
    {
        get { return adress; }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                Console.WriteLine("Adress cannot be null or empty.");
            }
            adress = value;
        }
    }

    override public string ToString()
    {
        return $"CompanyName:{companyName}|Date of Foundation:{dateOfFoundation}|Profile:{profile}|Director:{directorPIB}|Amount of workers:{amountOfWorkers}|Adress:{adress}";
    }
}