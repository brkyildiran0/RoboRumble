public class Movement
{
    public Tile startTile;
    public Tile endTile;
    public Entity entity;

    public Movement(Tile start = null, Tile end = null, Entity entityCreate = null)
    {
        startTile = start;
        endTile = end;
        entity = entityCreate;
    }
}