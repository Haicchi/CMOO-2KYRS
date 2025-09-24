// See https://aka.ms/new-console-template for more information

using System.Text.Json;

int restart = 1;
string lineRead = "firstFile.txt";
if (File.Exists(lineRead))
{
    Console.WriteLine("NIce");
}
else
{
    Console.WriteLine(" not Nice");
    return;
}
List<string> files = File.ReadLines(lineRead).ToList();
if(files.Count == 0){
    Console.WriteLine("MMMID");
    return;
}

for (int i = 0; i < files.Count; i++)
{
    Console.WriteLine($"Files that you can analys {i + 1}: {files[i]} ");
}

string fileanalys = "test";
do
{
    Console.WriteLine("Pick file by entering number");
    int pick = int.Parse(Console.ReadLine());
    switch (pick)
    {
        case 1: fileanalys = files[0]; break;
        case 2: fileanalys = files[1]; break;
        case 3: fileanalys = files[2]; break;
        default: Console.WriteLine("Wrong number"); break;
    }

    List<string> fileText = File.ReadAllLines(fileanalys).ToList();
    if (fileText.Count == 0)
    {
        Console.WriteLine("File is empty");
        return;
    }

    fileText.ForEach(Console.WriteLine);
    var analyses = new Dictionary<string, int>();
    using (FileStream fs = new FileStream(fileanalys, FileMode.Open))
    using (StreamReader sr = new StreamReader(fs))
    {

        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine().ToLower();
            string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if (analyses.ContainsKey(word))
                {
                    analyses[word]++;
                }
                else
                {
                    analyses[word] = 1;
                }
            }

        }
    }

    
    foreach (var item in analyses)
    {
        Console.WriteLine($"{item.Key} : {item.Value}");
    }

    Console.WriteLine("Do you wish to record result to file(1-yes,2-no)");
    int result = int.Parse(Console.ReadLine());
    if (result == 1)
    {
        using (FileStream ffs = new FileStream("textsaved.json", FileMode.OpenOrCreate))
        {
            JsonSerializer.SerializeAsync(ffs, analyses);
            Console.WriteLine("Soxraneno");
        }
    }


    

    Console.WriteLine("Do you wish to analyse another file(1-yes)?");
    restart = int.Parse(Console.ReadLine());
} while (restart==1);


