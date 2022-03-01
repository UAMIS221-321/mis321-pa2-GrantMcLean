using System;
using System.Collections.Generic;
namespace mis321_pa2_GrantMcLean
{
    public class Menus
    {
        static public string playerOneName { get; set; }    // variable for first players name
        static public string playerTwoName { get; set; }    // variable for second players name
        static public List<string> winnerList = Files.ReturnList(); // List that stores winners names
        static public CharacterGen playerOne = new CharacterGen();  // Creates playerOne and generates stats
        static public CharacterGen playerTwo = new CharacterGen();  // Creates playerTwo and generates stats
        static public void MainMenu()
        {
            System.Console.WriteLine("Player one what is your name?");  // Stores first players name
            playerOneName = Console.ReadLine();
            System.Console.WriteLine("Player two what is your name?");  // Stores second players name
            playerTwoName = Console.ReadLine();
            Console.Clear();

            string userInput = "";
            while (userInput != "3") // Loop until user exits
            {
                System.Console.WriteLine("1) Enter the game\n2) Clear leaderboard\n3) Exit\nPlease select one of the following options . . .");
                userInput = Console.ReadLine();
                Console.Clear();
                if (userInput == "1")
                {
                    Selection();   // Enters the character selection method
                }
                if (userInput == "2")
                {
                    ClearLeaderBoard(); // Clears leaderboard
                }
            }
            static void Selection()   // Character selection
            {
                System.Console.WriteLine($"1) Jack Sparrow\n2) Will Turner\n3) Davy Jones\n4) Jack The Monkey\n{playerOneName} please select your character...");
                string user = Console.ReadLine();
                Console.Clear();
                System.Console.Write(playerOneName);
                playerOne = CharacterSelection(user);   // Assigns player ones choice
                Console.ReadKey();
                Console.Clear();

                System.Console.WriteLine($"1) Jack Sparrow\n2) Will Turner\n3) Davy Jones\n4) Jack The Monkey\n{playerTwoName} please select your character...");
                user = Console.ReadLine();
                Console.Clear();
                System.Console.Write(playerTwoName);
                playerTwo = CharacterSelection(user);   // Assings players twos choice
                Console.ReadKey();
                Console.Clear();

                DisplayStats(playerOne, playerOneName); // Displays player ones generated stats
                Console.WriteLine();
                DisplayStats(playerTwo, playerTwoName); // Displays player twos generated stats
                Console.ReadKey();
                Console.Clear();

                System.Console.WriteLine("The Battle commences!");
                Battle.PreBattle(); // Enters into the Battle class passing the two created characters
            }
        }
        static public CharacterGen CharacterSelection(string user)  // returns the users choice
        {
            if (user == "1")
            {
                System.Console.WriteLine(" selected Jack Sparrow!\nPlease enter any key to continue...");
                return new JackSparrow();   // creates and returns JackSparrow
            }
            if (user == "2")
            {
                System.Console.WriteLine(" selected Will Turner!\nPlease enter any key to continue...");
                return new WillTurner();    // creates and returns WillTurner
            }
            if (user == "3")
            {
                System.Console.WriteLine(" selected Davy Jones!\nPlease enter any key to continue...");
                return new DavyJones(); // creates and returns DavyJones
            }
            if (user == "4")
            {
                System.Console.WriteLine(" selected Jack The Monkey!\nPlease enter any key to continue...");
                return new JackTheMonkey();
            }
            else
            {
                return null;
            }
        }
        static public void ClearLeaderBoard()   // Clears the leaderboards history
        {
            winnerList = new List<string> { };    // Reassigns winnerList to a new string list
            Files.SaveToFile("Cleared", winnerList);
            System.Console.WriteLine("The leaderboard has been cleared!\nPlease enter any key to continue...");
            Console.ReadKey();
        }
        // static public void ViewStats()  // Gives an option to view players stats
        // {
        //     Console.Clear();
        //     System.Console.WriteLine("Would you like to view users stats?\n1) Yes\n2) No");
        //     string user = Console.ReadLine();
        //     string userInput = "";

        //     if (user == "1")
        //     {
        //         while (userInput != "3")
        //         {
        //             Console.Clear();
        //             System.Console.WriteLine($"Which characters stats would you like to view?\n1) {playerOneName} stats\n2) {playerTwoName} stats\n3) Exit\nPlease select one of the options.");
        //             userInput = Console.ReadLine();

        //             if (userInput == "1")
        //             {
        //                 DisplayStats(playerOne, playerOneName);
        //             }
        //             if (userInput == "2")
        //             {
        //                 DisplayStats(playerTwo, playerTwoName);
        //             }
        //         }
        //         Console.Clear();
        //     }
        // }
        static public void DisplayStats(CharacterGen player, string playerName) // displays players stats
        {
            System.Console.WriteLine(playerName + "(s) stats\nPower Level: " + player.maxPower + "\nAttack Power: " + player.attackPower + "\nDefense Power: " + player.defensePower + "\nHealth: " + player.health);
        }
    }
}