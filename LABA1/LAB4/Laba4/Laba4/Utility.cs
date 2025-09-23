using System.Globalization;
using System.Text.Json;

namespace Laba4;

public static class Utility
{
    public static void Show(Dictionary<string, List<string>> newDictionary)
    {
        foreach (KeyValuePair<string, List<string>> pair in newDictionary)
        {
            Console.Write(pair.Key + " - ");
            foreach (string value in pair.Value)
            {
                Console.Write(value + "|");
            }

            Console.WriteLine();
        }
    }

    public static Dictionary<string, List<string>> CreateNewDictionary()
    {
        Console.WriteLine(
            "You picked add a new dictionary option , enter name of your dictionary(only english and lower)\nIf you want to return to previous menu press 0");
        string dictionaryName = Console.ReadLine() + ".json";

        string word1;
        string word2;
        int k = 0;
        int wordsAmount;
        Dictionary<string, List<string>> newDictionary = new Dictionary<string, List<string>>();
        do
        {
            Console.WriteLine("How much words you want to add");
            wordsAmount = int.Parse(Console.ReadLine());
            for (int i = 0; i < wordsAmount; i++)
            {
                List<string> translations = new List<string>();

                Console.WriteLine("Word on language number 1");
                word1 = Console.ReadLine();
                Console.WriteLine("Word on language number 2(if there is more than 1 translation enter 0)");
                var check = Console.ReadLine();
                if (check == "0")
                {

                    Console.WriteLine("How much translations you want to add");
                    k = int.Parse(Console.ReadLine());
                    for (int j = 0; j < k; j++)
                    {
                        Console.WriteLine($"Enter translation number {j + 1}");
                        word2 = Console.ReadLine();
                        translations.Add(word2);
                    }
                }
                else
                {

                    translations.Add(check);
                }

                newDictionary.Add(word1, translations);
            }

            Console.WriteLine("Do you want to add more words(1-yes)");

            k = int.Parse(Console.ReadLine());
        } while (k == 1);

        Console.WriteLine("Want to check your dictionary (1-yes)");
        k = int.Parse(Console.ReadLine());
        if (k == 1)
        {
            Utility.Show(newDictionary);
        }
        Utility.JsonSave(dictionaryName,newDictionary);
        return newDictionary;
    }

    public static void JsonSave(string dictionaryName,Dictionary<string, List<string>> newDictionary)
    {
        Console.WriteLine("Do you want to save this words into the file? (1-yes)");
        int k = int.Parse(Console.ReadLine());
        if (k == 1)
        {
            using (FileStream ffs = new FileStream(dictionaryName, FileMode.OpenOrCreate))
            {
                JsonSerializer.SerializeAsync(ffs, newDictionary);
                Console.WriteLine("Soxraneno");
            }
        }
    }

    public static Dictionary<string,List<string>> JsonLoad(string dictionaryName)
    {if (!File.Exists(dictionaryName))
        {
            Console.WriteLine("Sorry, no such file, please try again");
            return null;
                        
        }
        string jsonString = File.ReadAllText(dictionaryName);
       
        return JsonSerializer.Deserialize<Dictionary<string, List<string>>>(jsonString);
        
    }

    public static void EditDictionary(string dictionaryName,Dictionary<string, List<string>> newDictionary)
    {
        Console.WriteLine("Which word translation you want to edit (if you want to return to previous menu press 0))");
                                var answer = Console.ReadLine();
                                if (answer == "0")
                                {
                                    return;
                                }
                                

                                if (newDictionary.ContainsKey(answer))
                                {
                                    Console.WriteLine($"Word {answer} found , translations of word {answer}");
                                    if (newDictionary[answer].Any())
                                    {
                                        foreach (var translation in newDictionary[answer])
                                        {
                                            Console.WriteLine($"\n{translation}");
                                            ;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sorry, no such word, please try again");
                                        return;
                                    }
                                }

                                if (newDictionary[answer].Count > 1)
                                {
                                    Console.WriteLine($"You want to add a new translation or replace already exsisting(1-add 2-replace)." );
                                    int s = int.Parse(Console.ReadLine());
                                    if (s == 1)
                                    {
                                        Console.WriteLine("What translation you want to enter");
                                        string translations = Console.ReadLine();
                                        newDictionary[answer].Add(translations);
                                        Console.WriteLine("New translations added.Current translations");
                                        Utility.Show(newDictionary);
                                    }
                                    else if (s == 2)
                                    {
                                        string possibleTranslation = Console.ReadLine();
                                        if (!newDictionary[answer].Contains(possibleTranslation))
                                        {
                                            Console.WriteLine("Sorry, no such translations, please try again");
                                            return;
                                        }

                                        newDictionary[answer].Remove(possibleTranslation);


                                        Console.WriteLine("What translation you want to enter");
                                        string translation = Console.ReadLine();
                                        newDictionary[answer].Add(translation);
                                        Console.WriteLine("New translations added.Current translations");
                                        Utility.Show(newDictionary);
                                    }
                                    else{
                                        Console.WriteLine("Wrong input, please try again");
                                        return;
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("What translation you want to enter");
                                    string translation = Console.ReadLine();
                                    newDictionary[answer].Add(translation);
                                    Console.WriteLine("New translations added.Current translations");
                                    Utility.Show(newDictionary);
                                    Utility.JsonSave(dictionaryName,newDictionary);
                                };
                                
    }

    public static void DeleteTranslation(string dictionaryName, Dictionary<string, List<string>> newDictionary)
    {
        Console.WriteLine("Which word translation/s you want to delete");
                                string answer = Console.ReadLine();
                                if (!newDictionary.ContainsKey(answer))
                                {
                                    Console.WriteLine("Sorry, no such word, please try again");
                                    return;
                                }
                                Console.WriteLine($"Word {answer} found, translations of word {answer}");
                                if (newDictionary[answer].Any())
                                {
                                    foreach (var translation in newDictionary[answer])
                                    {
                                        Console.WriteLine($"\n{translation}");
                                        ;
                                    }
                                }
                                if (newDictionary[answer].Count > 1)
                                {
                                    Console.WriteLine("Which translation you want to replace");
                                    string possibleTranslation = Console.ReadLine();
                                    if (!newDictionary[answer].Contains(possibleTranslation))
                                    {
                                        Console.WriteLine("No such translations, please try again");
                                        return;
                                    }

                                    Console.WriteLine("Deleting");
                                    newDictionary[answer].Remove(possibleTranslation);
                                    Console.WriteLine("Deleted");
                                    Utility.JsonSave(dictionaryName, newDictionary);
                                }
                                else
                                {
                                    Console.WriteLine("Sorry but this word has only one translation, pick edit func to edit it but not delete");
                                    return;
                                }
    }

    public static void FindWord(Dictionary<string, List<string>> newDictionary)
    {
        Console.WriteLine("Which word translation/s you want to find");
        string answer = Console.ReadLine();
        if (!newDictionary.ContainsKey(answer))
        {
            Console.WriteLine("There is no such word, please try again");
            return;
        }

        Console.WriteLine($"There is translations of word {answer}");
        if (newDictionary[answer].Any())
        {
            foreach (var translation in newDictionary[answer])
            {
                Console.WriteLine($"\n{translation}");
                ;
            }
        }
    }

    public static void DeleteWord(string dictionaryName, Dictionary<string, List<string>> newDictionary)
    {
        Console.WriteLine("Which word you want to delete");
        string wordToDelete = Console.ReadLine();
        if (newDictionary.ContainsKey(wordToDelete))
        {
            newDictionary.Remove(wordToDelete);
            Console.WriteLine("Deleted");
            Utility.JsonSave(dictionaryName, newDictionary);
        }
        else
        {
            Console.WriteLine("There is no such word, please try again");
            return;
        }

    }

    public static void AddWord(string dictionaryName, Dictionary<string, List<string>> newDictionary)
    {
        Console.WriteLine("Which word you want to add");
        string wordToAdd = Console.ReadLine();
        if (newDictionary.ContainsKey(wordToAdd))
        {
            Console.WriteLine("Sorry but there already exists this word, please try again");
            return;
        }
        List<string> words = new List<string>();
 
        Console.WriteLine("How much translation you want to add");
        int translationToAdd = int.Parse(Console.ReadLine());
        for (int i = 0; i < translationToAdd; i++)
        {
            Console.WriteLine($"Word number {i + 1}");
            string translations = Console.ReadLine();
            words.Add(translations);
        }
        newDictionary.Add(wordToAdd, words);
        Console.WriteLine("Added");
        Console.WriteLine("There is your dictionary");
        Utility.Show(newDictionary);
        Utility.JsonSave(dictionaryName, newDictionary);
        
    }
    
    

}