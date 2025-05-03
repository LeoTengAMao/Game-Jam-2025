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
	private AbstractSkill _attackAbstractSkill;
	public AbstractSkill[] Skills{ get; private set; } = new AbstractSkill[5];
	
	public void ReplaceSkill(AbstractSkill abstractSkill, int idx)
	{
		Skills[idx] = abstractSkill;
	}

	public override void TakeDamage(int damage)
	{
		damage -= _effectDef;
		base.TakeDamage(damage);
	}
	
	public Player(int hp, int atk, int def, int spd, int actionPoint) : base(hp, atk, def, spd)
	{
		_maxActionPoint = _actionPoint;
		_actionPoint = actionPoint;
		_attackAbstractSkill = new BasicAttackSkill(0, this);
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
	}
	public void UseAttackSkill(Entity target)
	{
		_attackAbstractSkill.Execute(target);
	}

	public void UseSkill(int idx, Entity target)
	{
		Skills[idx].Execute(target);
	}
}
