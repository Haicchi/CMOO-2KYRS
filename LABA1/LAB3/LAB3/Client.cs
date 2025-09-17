namespace LAB3;

public class Client
{
    private string clientName;
    private int clientPriority;
    private DateTime timestamp;

    public Client(string clientName, int clientPriority)
    {
        this.clientName = clientName;
        this.clientPriority = clientPriority;
        
    }

    public Client()
    {
        clientName = "";
        clientPriority = 0;
    }

    public string ClientName
    {
        get { return clientName; }
        set
        {
            if (!String.IsNullOrEmpty(value))
            {
                Console.WriteLine("Client Name is invalid");
            }
            clientName = value;
        }
    }

    public int ClientPriority
    {
        get { return clientPriority; }
        set
        {
            if (!Int32.TryParse(value.ToString(), out clientPriority))
            {
                Console.WriteLine("Client Priority is invalid");
            }
            clientPriority = value;
        }
    }

    public DateTime Timestamp
    {
        get { return timestamp; }
        set { timestamp = value; }
    }

    public override string ToString()
    {
        return $"Client Name: {clientName} | Client Priority: {clientPriority}";
    }
    
}