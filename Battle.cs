using System;
namespace mis321_pa2_GrantMcLean
{
    public class Battle : Menus
    {
        static public void PreBattle()  // Determines who attacks first
        {
            var rnd = new Random();
            int start = rnd.Next(1, 3);
            if (start == 1)
            {
                System.Console.WriteLine($"{playerOneName} strikes first"); // If player one attacks first
                Battling(playerOne, playerTwo, start);
            }
            if (start == 2)
            {
                System.Console.WriteLine($"{playerTwoName} strikes first"); // If player two attacks first
                Battling(playerTwo, playerOne, start);

            }
        }
        static public void Battling(CharacterGen firstAttacker, CharacterGen secondAttacker, int start) // Battle occurs here
        {
            Console.ReadKey();
            Console.Clear();
            if (start == 1)
            {
                while (firstAttacker.health > 0.0 && secondAttacker.health > 0.0)   // Loop while both characters have above 0 health
                {
                    System.Console.WriteLine($"{playerTwoName} defends:");
                    SetDefenseBehavior(secondAttacker);
                    System.Console.WriteLine($"{playerOneName} attacks:");
                    DamageCalculator(firstAttacker, secondAttacker);    // Player one attacking
                    Console.ReadKey();
                    Console.Clear();
                    if (secondAttacker.health > 0.0)
                    {
                        System.Console.WriteLine($"{playerOneName} defends:");
                        SetDefenseBehavior(firstAttacker);
                        System.Console.WriteLine($"{playerTwoName} attacks:");
                        DamageCalculator(secondAttacker, firstAttacker);    // Player two attacking
                        Console.ReadKey();
                        Console.Clear();
                    }

                }
            }
            if (start == 2)
            {
                while (firstAttacker.health > 0.0 && secondAttacker.health > 0.0)   // Loop while both characters have above 0 health
                {
                    System.Console.WriteLine($"{playerOneName} defends:");
                    SetDefenseBehavior(secondAttacker);
                    System.Console.WriteLine($"{playerTwoName} attacks:");
                    DamageCalculator(firstAttacker, secondAttacker);    // Player two attacking
                    Console.ReadKey();
                    Console.Clear();

                    if (secondAttacker.health > 0.0)
                    {
                        System.Console.WriteLine($"{playerTwoName} defends:");
                        SetDefenseBehavior(firstAttacker);
                        System.Console.WriteLine($"{playerOneName} attacks:");
                        DamageCalculator(secondAttacker, firstAttacker);    // Player one attacking
                        Console.ReadKey();
                        Console.Clear();
                    }

                }
            }
            if (start == 1 && firstAttacker.health < 0.1)   // If player two wins
            {
                Files.SaveToFile(playerTwoName, winnerList);    // saves to file
                System.Console.WriteLine($"{playerTwoName} claims victory!\nTheir total wins is now: {Files.NumOfWins(playerTwoName)}");    // Displays winner and win count
            }
            else if (start == 1 && secondAttacker.health < 0.1) // If player one wins
            {
                Files.SaveToFile(playerOneName, winnerList); // saves to file
                System.Console.WriteLine($"{playerOneName} claims victory!\nTheir total wins is now: {Files.NumOfWins(playerOneName)}");    // Displays winner and win count
            }
            if (start == 2 && firstAttacker.health < 0.1)   // If player one wins
            {
                Files.SaveToFile(playerOneName, winnerList);    // saves to file
                System.Console.WriteLine($"{playerOneName} claims victory!\nTheir total wins is now: {Files.NumOfWins(playerOneName)}");    // Displays winner and win count
            }
            else if (start == 2 && secondAttacker.health < 0.1) // If player two wins
            {
                Files.SaveToFile(playerTwoName, winnerList); // saves to file
                System.Console.WriteLine($"{playerTwoName} claims victory!\nTheir total wins is now: {Files.NumOfWins(playerTwoName)}");    // Displays winner and win count
            }
        }

        static public void DamageCalculator(CharacterGen attacker, CharacterGen defender)   // Calculates the damage done to the defender
        {
            double damageDealt = 0.0;
            // Accesses if one of the special attacker defender combos occur
            if (attacker.attackBehavior.Attack() == "Distract" && defender.attackBehavior.Attack() == "Sword" || attacker.attackBehavior.Attack() == "Sword" && defender.attackBehavior.Attack() == "Cannonball" || attacker.attackBehavior.Attack() == "Cannonball" && defender.attackBehavior.Attack() == "Distract")
            {
                if (defender.defenseBehavior.Defend() == "Dodge")   // Accesses if defenders defense is set to Dodge
                {
                    double temp = attacker.attackPower;
                    var rnd = new Random();
                    int randNum = rnd.Next(1, 11);
                    if (randNum > 6)    // 40 % of successfully dodging
                    {

                        System.Console.WriteLine("Defender successfully ducked! Decreasing damage taken");
                        attacker.attackPower = attacker.attackPower * .5;
                        damageDealt = (attacker.attackPower - defender.defensePower) * (1.2);
                        attacker.attackPower = temp;
                    }
                    if (randNum < 7)    // 60 % of failing to dodge
                    {
                        System.Console.WriteLine("Defender failed to duck! Increasing damage taken");
                        attacker.attackPower = attacker.attackPower * 1.5;
                        damageDealt = (attacker.attackPower - defender.defensePower) * (1.2);
                        attacker.attackPower = temp;
                    }
                } else  // Accesses if defenders defense is set to normal
                {
                    damageDealt = (attacker.attackPower - defender.defensePower) * (1.2);
                }
                
                if (damageDealt < .1)   // Accesses if damage done is 0 or less
                {
                    damageDealt = ((attacker.attackPower / defender.defensePower) * attacker.attackPower) * 1.2;
                }

                damageDealt = Math.Round(damageDealt, 2);
                defender.health = defender.health - damageDealt;
                defender.health = Math.Round(defender.health, 2);

                if (defender.health < 0.1)  // Accesses if defenders health drops to 0 or below
                {
                    defender.health = 0.0;
                }
                System.Console.WriteLine($"Attacker: Power Level = {attacker.maxPower}\nDamage Dealt = {damageDealt}\nAttack Power = {attacker.attackPower}\n(It was super effective!)\n");
                System.Console.WriteLine($"Defender: Power Level = {defender.maxPower}\nHealth = {defender.health}\nDefense Power = {defender.defensePower}");
            }
            else    // all other attacker defender combos
            {
                if (defender.defenseBehavior.Defend() == "Dodge")   // Accesses if defenders defense is Dodge
                {
                    double temp = attacker.attackPower;
                    var rnd = new Random();
                    int randNum = rnd.Next(1, 11);
                    if (randNum > 6)    // 40 % of successfully dodging
                    {
                        System.Console.WriteLine("Defender successfully dodged the attack! Decreasing damage taken");
                        attacker.attackPower = attacker.attackPower * .5;
                        damageDealt = (attacker.attackPower - defender.defensePower);
                        attacker.attackPower = temp;
                    }
                    if (randNum < 7)    // 60 % of failing to dodge
                    {
                        System.Console.WriteLine("Defender failed to dodge the attack! Increasing damage taken");
                        attacker.attackPower = attacker.attackPower * 1.5;
                        damageDealt = (attacker.attackPower - defender.defensePower);
                        attacker.attackPower = temp;
                    }
                } else  // If defenders defense is set to normal
                {
                    damageDealt = (attacker.attackPower - defender.defensePower);
                }
                if (damageDealt < .1)   // if damage dealt is 0 or below
                {
                    damageDealt = ((attacker.attackPower / defender.defensePower) * attacker.attackPower);
                }

                damageDealt = Math.Round(damageDealt, 2);
                defender.health = defender.health - damageDealt;
                defender.health = Math.Round(defender.health, 2);

                if (defender.health < 0.1)  // if defenders health is 0 or below
                {
                    defender.health = 0.0;
                }
                System.Console.WriteLine($"Attacker: Power Level = {attacker.maxPower}\nDamage Dealt = {damageDealt}\nAttack Power = {attacker.attackPower}\n");
                System.Console.WriteLine($"Defender: Power Level = {defender.maxPower}\nHealth = {defender.health}\nDefense Power = {defender.defensePower}");
            }
        }
        static public void SetDefenseBehavior(CharacterGen player)  // Assigns defenders chosen method of defense
        {
            System.Console.WriteLine("1) Normal Defense\n2) Dodge the attack (40% chance of success)\nWhich Defense would you like to use?");
            string user = Console.ReadLine();

            if (user == "1" && player.defenseBehavior.Defend() != "Normal")
            {
                player.defenseBehavior = new Normal();
            }
            if (user == "2" && player.defenseBehavior.Defend() != "Dodge")
            {
                player.defenseBehavior = new Dodge();
            }
            Console.Clear();
        }
    }
}