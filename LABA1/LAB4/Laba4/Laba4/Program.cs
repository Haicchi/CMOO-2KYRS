 using Laba4;
 

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
                        Utility.WorkWithExistingDictionary();
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
 
        