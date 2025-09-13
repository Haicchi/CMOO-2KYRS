// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using System.Xml.Serialization;

namespace Lab1;
class Program{
static async Task Main(string[] args)
    {
        Tovar tovar1 = Creator.RandomTovar();
        Tovar tovar2 = Creator.RandomTovar();
        Tovar tovar3 = Creator.RandomTovar();
        List<Tovar> tovars = new List<Tovar>(){tovar1, tovar2, tovar3};
        Console.WriteLine("Enter max price for your budget");
        int max = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < tovars.Count; i++)
        {
            for (int j = 0; j < tovars[i].Shops.Count; j++)
            {
                if (tovars[i].Shops[j].Price <= max)
                {
                    Console.WriteLine($"You can by {tovars[i].TovarName} in {tovars[i].Shops[j].ShopName}, for {tovars[i].Shops[j].Price}.");
                }
            }
        }
        
        Console.WriteLine(tovar1.ToString());
        Console.WriteLine("JSON SERIALIZATION:");
        string json = JsonSerializer.Serialize(tovars);
        Console.WriteLine(json);
        List<Tovar>? tovars2 = JsonSerializer.Deserialize<List<Tovar>>(json);
        Console.WriteLine("JSON DESERIALIZATION:");
        for (int i = 0; i < tovars2.Count; i++)
        {
            Console.WriteLine(tovars2[i].ToString());
        }
        using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
        {
            await JsonSerializer.SerializeAsync<List<Tovar>>(fs, tovars);
            Console.WriteLine("Data has been saved to file");
        }
        using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
        {
            Tovar[]? tovars3 = await JsonSerializer.DeserializeAsync<Tovar[]>(fs);
            for (int i = 0; i < tovars3.Length; i++)
            {
                Console.WriteLine(tovars3[i].ToString());
            }
            
        }
        /*XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Tovar>));
        using (FileStream fs = new FileStream("tovars.xml", FileMode.OpenOrCreate))
        {
            xmlSerializer.Serialize(fs, tovars);
            Console.WriteLine("Tovars xml has been saved.");
        }

        using (FileStream fs = new FileStream("tovars.xml", FileMode.OpenOrCreate))
        {
            if (xmlSerializer.Deserialize(fs) is List<Tovar> newTovars)
            {
                foreach (Tovar tovar in newTovars)
                {
                    Console.WriteLine(tovar.ToString());
                }
            }
        }*/

        Console.WriteLine("Adding new tovar");
        Tovar tovar4 = Creator.RandomTovar();
        Tovar tovar5 = Creator.RandomTovar();
        tovars.Add(tovar4);
        tovars.ForEach(Console.WriteLine);
        Console.WriteLine("Removing tovar");
        tovars.Remove(tovar4);
        tovars.ForEach(Console.WriteLine);
        Console.WriteLine("INserting tovar in position 2");
        tovars.Insert(1, tovar5);
        tovars.ForEach(Console.WriteLine);
        Tovar tovar6 = new Tovar();
        tovar6.CreateTovar();
        Console.WriteLine(tovar6.ToString());
        foreach (var shop in tovar6.Shops)
        {
            Console.WriteLine(shop.ShopName, shop.Price);
        }
    }
}
