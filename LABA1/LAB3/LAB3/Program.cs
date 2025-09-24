// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using LAB3;

string filepath = "Test.txt";
List<Client> clients = new List<Client>();
File.WriteAllText(filepath, string.Empty);
Console.WriteLine("Hello, World!");
Client client1 = Creator.RandomClient();
Client client2 = Creator.RandomClient();
Client client3 = Creator.RandomClient();
Console.WriteLine(client1.ToString());
Console.WriteLine(client2.ToString());
Console.WriteLine(client3.ToString());
var ochered = new PriorityQueue<Client, int>();
ochered.Enqueue(client1, client1.ClientPriority);
ochered.Enqueue(client2, client2.ClientPriority);
ochered.Enqueue(client3, client3.ClientPriority);
Console.WriteLine("Do you want to save the file? 1-y/2-n");
int decion = Int32.Parse(Console.ReadLine());
if (decion == 1)
{
    if (!File.Exists(filepath))
    {
        Console.WriteLine("File not found");
        return;
    }
}
else
{
    Console.WriteLine("thanks for using this program");
    return;
}
List<string> jsonSave = new List<string>();
while (ochered.TryDequeue(out Client client, out int clientPriority))
{
    string linetosave = client.ClientName +" "+client.Timestamp+" "+clientPriority+" ";
    Console.WriteLine($"Client: {client.ClientName +" "+ client.Timestamp}, Priority: {clientPriority}");
    jsonSave.Add(linetosave);
    
    clients.Add(client);
}
clients.ForEach(client => Console.WriteLine(client.ToString()));
Console.WriteLine("Do you want to save this words into the file? (1-yes)");
int k = int.Parse(Console.ReadLine());
if (k == 1)
{
    using (FileStream ffs = new FileStream("Data.json", FileMode.OpenOrCreate))
    {
        JsonSerializer.SerializeAsync(ffs, jsonSave);
        Console.WriteLine("Soxraneno");
    }
}
Console.WriteLine("Save complete");
