using System;
using 新遊戲專案.script;

public partial class Player: Entity
{
	private int _effectHp = 0;
	private int _effectAtk = 0;
	private int _effectDef = 0;
	private int _effectSpd = 0;
	private int _effectActionPoint = 0;

	public int CurrentMaxHp => MaxHp;
	public int CurrentHp => Hp + _effectHp;
	public int CurrentAtk => Atk + _effectAtk;
	public int CurrentDef => Def + _effectDef;
	public int CurrentSpd => Spd + _effectSpd;
	public int CurrentActionPoint => _actionPoint + _effectActionPoint;
	
	private int _maxActionPoint;
	private int _actionPoint;
	private AbstractSkill _attackSkill;
	public Skill[] Skills{ get; private set; } = new Skill[5];
	
	public void ReplaceSkill(Skill skill, int idx)
	{
		Skills[idx] = skill;
	}

	public override void TakeDamage(int damage)
	{
		damage -= _effectDef;
		base.TakeDamage(damage);
	}
	
	public Player(int hp, int atk, int def, int spd, int actionPoint) : base(hp, atk, def, spd)
	{
		_maxActionPoint = actionPoint;
		_actionPoint = actionPoint;
		_attackSkill = new BasicAttackSkill(0, this.Atk);
		Skills[0] = new Skill(2, 2);
		Skills[1] = new Skill(3, 3);
		Skills[2] = new Skill(4, 4);
		Skills[3] = new Skill(3, 5);
		Skills[4] = new Skill(2, 3);
		Skills = Skills;
	}

	public void TurnStartInit()
	{
		_effectHp = 0;
		_effectAtk = 0;
		_effectDef = 0;
		_effectSpd = 0;
		_effectActionPoint = 0;
		_actionPoint = _maxActionPoint;
	}

	public void UseDefenceSkill()
	{
		_effectDef += 3;
		_actionPoint -= 999;
	}
	public void UseAttackSkill(Entity target)
	{
		_attackSkill.Execute(target);
		_actionPoint -= 1;
	}

	public void UseSkill(int idx, Entity target)
	{
		Skills[idx].Execute(target);
		_actionPoint -= Skills[idx].ActionPoint;
		if (idx == 4)
		{
			Heal(Skills[idx].Atk);
		}
		else
		{
			target.TakeDamage(Skills[idx].Atk);
		}
	}

	public void AddSpd()
	{
		AccumulateSpd += CurrentSpd;
	}
	public bool IsSpdGreaterThanTarget(int target)
	{
		return AccumulateSpd >= target;
	}
	public void UseActionPoint(int value)
	{
		_actionPoint -= value;
	}

	public void AtkEffect(int value)
	{
		_effectAtk += value;
	}
	public void DefEffect(int value)
	{
		_effectDef += value;
	}
	public void SpdEffect(int value)
	{
		_effectSpd += value;
	}
}
