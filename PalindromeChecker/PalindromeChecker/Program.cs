using System;

namespace PalindromeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Palindrome Checker");
            Console.WriteLine();

            bool UserChoice = true;

            while (UserChoice)
            {
                Console.Write("Enter the input string: ");
                string InputString = Console.ReadLine();

                Console.Write("Enter the trash symbols string: ");
                string TrashSymbolsString = Console.ReadLine();

                bool isPalindrome = IsPalindromeWithTrashSymbols(InputString, TrashSymbolsString);

                Console.WriteLine($"Result: {isPalindrome}");

                // Add space before asking to continue
                Console.WriteLine();

                Console.Write("Do you want to continue (yes/no)? ");
                string continueInput = Console.ReadLine().ToLower();

                UserChoice = (continueInput == "yes");
                Console.WriteLine();
            }
        }

        static bool IsPalindromeWithTrashSymbols(string inputString, string trashSymbolsString)
        {
            // Convert trashSymbolsString to lowercase for case insensitivity
            trashSymbolsString = trashSymbolsString.ToLower();

            int left = 0;
            int right = inputString.Length - 1;

            while (left < right)
            {
                // Skip trash symbols from the left end
                while (left < right && trashSymbolsString.Contains(inputString[left].ToString().ToLower()))
                {
                    left++;
                }

                // Skip trash symbols from the right end
                while (left < right && trashSymbolsString.Contains(inputString[right].ToString().ToLower()))
                {
                    right--;
                }

                // Compare characters, ignoring case
                if (char.ToLower(inputString[left]) != char.ToLower(inputString[right]))
                {
                    return false;
                }

                // Move the pointers inward
                left++;
                right--;
            }

            // If the loop completes without returning false, it's a palindrome
            return true;
        }
    }
}
