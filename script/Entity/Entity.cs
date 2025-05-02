namespace 新遊戲專案.script;

public abstract class Entity
{
    public int Hp { get; private set; }
    public int Atk { get; private set; }
    public int Def { get; private set; }
    public int Spd { get; private set; }

    protected Entity(int hp, int atk, int def, int spd)
    {
        Hp = hp;
        Atk = atk;
        Def = def;
        Spd = spd;
    }

    public void TakeDamage(int damage)
    {
        int loseHp = damage - Def;
        if (loseHp < 1) loseHp = 1;
        Hp -= loseHp;
    }
}