namespace mis321_pa2_GrantMcLean
{
    public class WillTurner : CharacterGen
    {
        public WillTurner() // Creates Will turner character
        {
            attackBehavior = new Sword();
            defenseBehavior = new Normal();
        }
    }
}