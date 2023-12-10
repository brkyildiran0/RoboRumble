public class Collision
{
    public Entity initiator;
    public Entity receiver;
    public Movement lastMovementOfInitatior;

    public Collision(Entity initiator, Entity receiver, Movement lastMovementOfInitatior)
    {
        this.initiator = initiator;
        this.receiver = receiver;
        this.lastMovementOfInitatior = lastMovementOfInitatior;
    }
}