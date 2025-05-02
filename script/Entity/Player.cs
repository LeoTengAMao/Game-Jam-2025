using 新遊戲專案.script;

public partial class Player: Entity
{
	private int _actionPoint;
	private Skill _attackSkill;
	public Skill[] Skills{ get; private set; } = new Skill[5];
	public void replace_skill(Skill skill, int idx)
	{
		Skills[idx] = skill;
	}

	public void UseAttackSkill(Entity target)
	{
		_attackSkill.execute(target);
	}

	public Player(int hp, int atk, int def, int spd, int actionPoint) : base(hp, atk, def, spd)
	{
		_actionPoint = actionPoint;
		_attackSkill = new BasicAttackSkill(0, this);
		Skills = Skills;
	}
}
