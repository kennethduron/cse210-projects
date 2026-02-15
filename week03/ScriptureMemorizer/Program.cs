using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Creativity: Randomly select from multiple scriptures
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding."
            ),
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son."
            )
        };

        Random random = new Random();
        Scripture selectedScripture = scriptures[random.Next(scriptures.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());

            if (selectedScripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            // Hide 3 random words each time (exceeds core requirement)
            selectedScripture.HideRandomWords(3);
        }

        Console.WriteLine("\nProgram ended. Goodbye!");
    }
}
