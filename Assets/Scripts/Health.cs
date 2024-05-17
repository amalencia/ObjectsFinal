public class Health
{
    private int _maxHealth;
    private int _currentHealth;

    private void TakeDamage(int damage)
    {
        _currentHealth -= damage;
    }

    private void Repair(int heal)
    {
        if((_currentHealth + heal) > _maxHealth)
        {
            _currentHealth = _maxHealth;
        } else
        {
            _currentHealth += heal;
        }
    }

    public Health(int maxHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
    }
}
