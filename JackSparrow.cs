namespace mis321_pa2_GrantMcLean
{
    public class JackSparrow : CharacterGen
    {
        public JackSparrow() // Creates Jack Sparrow Character
        {
            attackBehavior = new Distract();
            defenseBehavior = new Normal();
        }
    }
}