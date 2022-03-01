namespace mis321_pa2_GrantMcLean
{
    public class DavyJones : CharacterGen
    {
        public DavyJones()  // Creates Davy Jones Character
        {
            attackBehavior = new Cannonball();
            defenseBehavior = new Normal();
        }
    }
}