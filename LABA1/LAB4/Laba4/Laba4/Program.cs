// See https://aka.ms/new-console-template for more information

using System.Globalization;
using System.Text.Json;
using Laba4;


int mainMenu;
do
{
    Label1:
    Console.WriteLine(
        "Hello, user which operation you want to proceed \n 1-Add new dictionary \n 2-Pick already existing dictionary");
    int o = int.Parse(Console.ReadLine());
    int k;
    switch (o)
    {
        case 1:
        {
            Console.WriteLine(
                "You picked add a new dictionary option , enter name of your dictionary(only english and lower)\nIf you want to return to previous menu press 0");
            string dictionaryName = Console.ReadLine() + ".json";

            string word1;
            string word2;

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

            Console.WriteLine("Do you want to save this words into the file? (1-yes)");
            k = int.Parse(Console.ReadLine());
            if (k == 1)
            {
                using (FileStream ffs = new FileStream(dictionaryName, FileMode.OpenOrCreate))
                {
                    JsonSerializer.SerializeAsync(ffs, newDictionary);
                    Console.WriteLine("Soxraneno");
                }
            }

            break;
        }
        case 2:
        {
            Console.WriteLine("Enter name of your dictionary(If you want to return to previous menu press 0))");
            int p = int.Parse(Console.ReadLine());
            if (p == 0)
            {
                goto Label1;
            }
            
                    Label2:
                    Console.WriteLine("Enter dictionary name");
                    string dictionaryName = Console.ReadLine().ToLower() + ".json";
                    if (!File.Exists(dictionaryName))
                    {
                        Console.WriteLine("Sorry, no such file, please try again");
                        goto Label2;
                        
                    }
                    string jsonString = File.ReadAllText(dictionaryName);
                    Dictionary<string, List<string>> newDictionary = new Dictionary<string, List<string>>();
                    newDictionary = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(jsonString);
                    Console.WriteLine("Do yo want to check your dictionary(1-yes)");
                    k = int.Parse(Console.ReadLine());
                    if (k == 1)
                    {
                        Utility.Show(newDictionary);
                    }

                    int edit;
                    do
                    {
                        Label3:
                        Console.WriteLine("What you want to do with dictionary\n1-Edit translation of words.2-Delete translations of words\n3-Find translation of word\n4-Delete word from dictionary\n5-Add new word");
                        k = int.Parse(Console.ReadLine());
                        switch (k)
                        {
                            case 1: Console.WriteLine("Which word translation you want to edit (if you want to return to previous menu press 0))");
                                var answer = Console.ReadLine();
                                if (answer == "0")
                                {
                                    goto Label3;
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
                                        goto Label3;
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
                                            goto Label3;
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
                                        goto Label3;
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("What translation you want to enter");
                                    string translation = Console.ReadLine();
                                    newDictionary[answer].Add(translation);
                                    Console.WriteLine("New translations added.Current translations");
                                    Utility.Show(newDictionary);
                                    Console.WriteLine("Overwriting file");
                                
                                    jsonString = JsonSerializer.Serialize(newDictionary);
                                    File.WriteAllText(dictionaryName, jsonString);
                                };
                                

                                break;
                            case 2:
                                Console.WriteLine("Which word translation/s you want to delete");
                                answer = Console.ReadLine();
                                if (!newDictionary.ContainsKey(answer))
                                {
                                    Console.WriteLine("Sorry, no such word, please try again");
                                    goto Label3;
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
                                        goto Label3;
                                    }

                                    Console.WriteLine("Deleting");
                                    newDictionary[answer].Remove(possibleTranslation);
                                    Console.WriteLine("Deleted");
                                    Console.WriteLine("Overwriting file");
                                
                                    jsonString = JsonSerializer.Serialize(newDictionary);
                                    File.WriteAllText(dictionaryName, jsonString);
                                }
                                else
                                {
                                    Console.WriteLine("Sorry but this word has only one translation, pick edit func to edit it but not delete");
                                    goto Label3;
                                }

                               
                                break;
                            case 3: Console.WriteLine("Which word translation/s you want to find");
                                answer = Console.ReadLine();
                                if (!newDictionary.ContainsKey(answer))
                                {
                                    Console.WriteLine("There is no such word, please try again");
                                    goto Label3;
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
                                break;
                            case 4: Console.WriteLine("Which word you want to delete");
                                string wordToDelete = Console.ReadLine();
                                if (!newDictionary.ContainsKey(wordToDelete))
                                {
                                    newDictionary.Remove(wordToDelete);
                                    Console.WriteLine("Deleted");
                                    Console.WriteLine("Do yo want to save those changes");
                                    int saveChanges = int.Parse(Console.ReadLine());
                                    if (saveChanges == 1)
                                    {
                                        jsonString = JsonSerializer.Serialize(newDictionary);
                                        File.WriteAllText(dictionaryName, jsonString);
                                        Console.WriteLine("Changes saved");
                                    }
                                }

                                break;
                            case 5: Console.WriteLine("Which word you want to add");
                                string wordToAdd = Console.ReadLine();
                                if (newDictionary.ContainsKey(wordToAdd))
                                {
                                    Console.WriteLine("Sorry but there already exists this word, please try again");
                                    goto Label3;
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
                                Console.WriteLine("Do yo want to save those changes");
                                int saveChanges = int.Parse(Console.ReadLine());
                                if (saveChanges == 1)
                                {
                                    jsonString = JsonSerializer.Serialize(newDictionary);
                                    File.WriteAllText(dictionaryName, jsonString);
                                    Console.WriteLine("Changes saved");
                                }
                                
                                break;
                        }
                        Console.WriteLine("Do you wish to edit something more (1-yes)");
                        edit = int.Parse(Console.ReadLine());
                    }while(edit == 1);

                    break;
                }

            }

            break;
        
        

    

    Console.WriteLine("Do you want to go in main menu of program?(1-yes)");
    mainMenu = int.Parse(Console.ReadLine());
} while (mainMenu == 1);

