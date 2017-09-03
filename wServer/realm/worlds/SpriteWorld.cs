namespace wServer.realm.worlds
{
    public class SpriteWorld : World
    {
        public SpriteWorld()
        {
            Name = "Sprite World";
            ClientWorldName = "Sprite World";
            Background = 0;
            AllowTeleport = false;
            Difficulty = 5;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.spriteworld.jm", MapType.Json);
        }
    }
}