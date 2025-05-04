namespace 新遊戲專案.script;

public abstract class Entity
{
	protected int MaxHp { get; private set; }
	protected int Hp { get; private set; }
	protected int Atk { get; private set; }
	protected int Def { get; private set; }
	protected int Spd { get; private set; }
	
	protected int AccumulateSpd = 0;

	protected Entity(int hp, int atk, int def, int spd)
	{
		MaxHp = hp;
		Hp = hp;
		Atk = atk;
		Def = def;
		Spd = spd;
	}

	public virtual void TakeDamage(int damage)
	{
		int loseHp = damage - Def;
		if (loseHp < 1) loseHp = 1;
		Hp -= loseHp;
	}

	public bool IsDead()
	{
		return Hp <= 0;
	}

	public bool IsSpdGreaterThanTarget(int target)
	{
		return AccumulateSpd > target;
	}

	public int GetAccumulateSpd()
	{
		return AccumulateSpd;
	}
}
