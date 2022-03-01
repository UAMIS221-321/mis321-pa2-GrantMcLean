using System;
namespace mis321_pa2_GrantMcLean
{
    class Program
    {
        // Extras: Saves winners name to results.txt file, Displays number of games won by players name after each battle, extra character, clean user experience, Added the functionality for users to pick a defense
        static void Main(string[] args)
        {
            Console.Clear();
            Greeting();
            Menus.MainMenu();   // Accesses menus class
            Goodbye();
        }
        static void Greeting()  // Greets new players
        {
            System.Console.WriteLine("Welcome to the fight!");
        }
        static void Goodbye()
        {
            System.Console.WriteLine("Thank you for playing!");
        }
    }
}
