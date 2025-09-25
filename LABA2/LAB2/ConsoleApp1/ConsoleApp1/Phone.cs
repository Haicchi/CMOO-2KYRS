namespace ConsoleApp1;

public class Phone
{
    private string phoneName;
    private string company;
    private double price;
    private DateTime dateOfRelease;

    public Phone()
    {
        phoneName = "";
        company = "";
        price = 0;
        dateOfRelease = DateTime.Now;
    }

    public Phone(string phoneName, string company, double price, DateTime dateOfRelease)
    {
        this.phoneName = phoneName;
        this.company = company;
        this.price = price;
        this.dateOfRelease = dateOfRelease;
    }
    public string PhoneName { get => phoneName; set => phoneName = value; }
    public string Company { get => company; set => company = value; }
    public double Price { get => price; set => price = value; }
    public DateTime DateOfRelease { get => dateOfRelease; set => dateOfRelease = value; }

    override public string ToString()
    {
        return $"Phone name: {phoneName}|Company: {company}|Price: {price}|Date of Release: {dateOfRelease}";
    }
}