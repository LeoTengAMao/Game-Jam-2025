namespace 新遊戲專案.script;

public class Skill : AbstractSkill
{
	public int ActionPoint => _actionPoint;
	public int Atk => _atk;
	public Skill(int actionPoint, int atk) : base(actionPoint, atk)
	{
	}

	public override void Execute(Entity target)
	{
		;
	}
}
