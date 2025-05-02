namespace 新遊戲專案.script;

public abstract class Entity
{
    private int hp;
    private int atk;
    private int def;
    private int spd;

    protected Entity(int _hp, int _atk, int _def, int _spd)
    {
        hp = _hp;
        atk = _atk;
        def = _def;
        spd = _spd;
    }

    public void take_damage(int damage)
    {
        int _damage = damage - def;
        if (_damage < 1) _damage = 1;
        hp -= _damage;
    }
}