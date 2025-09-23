 using Laba4;
 void HandleExistingDictionary()
        {
            string dictionaryName;
            Dictionary<string, List<string>> newDictionary;

            do
            {
                Console.WriteLine("Enter the name of your dictionary (if you want to return to the previous menu, press 0).");
                dictionaryName = Console.ReadLine() + ".json";

                if (dictionaryName == "0.json")
                {
                    return;
                }

                newDictionary = Utility.JsonLoad(dictionaryName);

            } while (newDictionary == null);

            Console.WriteLine("Do you want to check your dictionary? (1-yes)");
            int k = int.Parse(Console.ReadLine());
            if (k == 1)
            {
                Utility.Show(newDictionary);
            }

            int editOption;
            do
            {
                Console.WriteLine("What do you want to do with the dictionary?");
                Console.WriteLine("1 - Edit translation of words");
                Console.WriteLine("2 - Delete translations of words");
                Console.WriteLine("3 - Find translation of word");
                Console.WriteLine("4 - Delete word from dictionary");
                Console.WriteLine("5 - Add new word");
                Console.WriteLine("0 - Return to main menu");

                editOption = int.Parse(Console.ReadLine());

                switch (editOption)
                {
                    case 1:
                        Utility.EditDictionary(dictionaryName, newDictionary);
                        break;
                    case 2:
                        Utility.DeleteTranslation(dictionaryName, newDictionary);
                        break;
                    case 3:
                        Utility.FindWord(newDictionary);
                        break;
                    case 4:
                        Utility.DeleteWord(dictionaryName, newDictionary);
                        break;
                    case 5:
                        Utility.AddWord(dictionaryName, newDictionary);
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Wrong input, please try again.");
                        break;
                }

                Console.WriteLine("Do you wish to do something more? (1-yes, 0-no)");
                editOption = int.Parse(Console.ReadLine());

            } while (editOption == 1);
        }

 int mainMenuOption;

            do
            {
                Console.WriteLine("Hello, user. Which operation do you want to proceed with?");
                Console.WriteLine("1 - Add a new dictionary");
                Console.WriteLine("2 - Pick an already existing dictionary");
                Console.WriteLine("0 - Exit");

                mainMenuOption = int.Parse(Console.ReadLine());

                switch (mainMenuOption)
                {
                    case 1:
                        Utility.CreateNewDictionary();
                        break;

                    case 2:
                        HandleExistingDictionary();
                        break;

                    case 0:
                        Console.WriteLine("Exiting program. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine();

            } while (mainMenuOption != 0);
 
        