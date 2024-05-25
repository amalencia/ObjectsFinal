public class Character_ver0
{
    private Health _health;
    private float _baseSpeed;
    private int _armor;

    public virtual void Move()
    {

    }

    public virtual void Attack()
    {

    }

    public virtual void Die()
    {

    }

    /// <summary>
    /// Basic character.
    /// </summary>
    /// <param name="health"></param>
    /// <param name="baseSpeed"></param>
    /// <param name="armor"></param>
    public Character_ver0(int health, float baseSpeed, int armor)
    {
        _health = new Health(health);
        _baseSpeed = baseSpeed;
        _armor = armor;
    }
}
