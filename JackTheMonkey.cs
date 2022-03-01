namespace mis321_pa2_GrantMcLean
{
    public class JackTheMonkey : CharacterGen
    {
        public JackTheMonkey() // Creates Jack the Monkey Character
        {
            attackBehavior = new Biting();
            defenseBehavior = new Normal();
        }
    }
}