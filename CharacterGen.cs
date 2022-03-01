using mis321_pa2_GrantMcLean.Interfaces;
using System;
namespace mis321_pa2_GrantMcLean
{
    public class CharacterGen
    {
        public double health { get; set; }
        public int maxPower { get; set; }
        public double attackPower { get; set; }
        public double defensePower { get; set; }
        public IAttackBehavior attackBehavior { get; set; }
        public IDefendBehavior defenseBehavior { get; set; }
        public CharacterGen()   // Generates the stats for each character
        {
            maxPower = MaxPowerGen();
            attackPower = AttackGen();
            defensePower = DefenseGen();
            health = HealthGen();
        }
        public int MaxPowerGen()    // Generates max power
        {
            var rand = new Random();
            int temp = rand.Next(1, 101);
            return temp;
        }
        public double AttackGen()   // Generates Attack power
        {
            var rand = new Random();
            double temp = Convert.ToDouble(rand.Next(1, (maxPower + 1)));
            return temp;
        }
        public double DefenseGen()  // Generates Defense power
        {
            var rand = new Random();
            double temp = Convert.ToDouble(rand.Next(1, (maxPower + 1)));
            return temp;
        }
        public double HealthGen()   // Generates Health
        {
            double temp = 100.0;
            return temp;
        }
    }
}