// See https://aka.ms/new-console-template for more information

using LAB3;

int priority = 3;
Console.WriteLine("Hello, World!");
Client client1 = Creator.RandomClient();
Client client2 = Creator.RandomClient();
Client client3 = Creator.RandomClient();
Console.WriteLine(client1.ToString());
Console.WriteLine(client2.ToString());
Console.WriteLine(client3.ToString());
var ochered = new PriorityQueue<string, int>();
ochered.Enqueue(client1.ClientName, client1.ClientPriority);
ochered.Enqueue(client2.ClientName, client2.ClientPriority);
ochered.Enqueue(client3.ClientName, client3.ClientPriority);

while (ochered.TryDequeue(out string clientName, out int clientPriority))
{
    Console.WriteLine($"Client: {clientName}, Priority: {clientPriority}");
    using(StreamReader sr = new StreamReader(clientName))
}

