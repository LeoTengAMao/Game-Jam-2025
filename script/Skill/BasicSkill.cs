using Godot;

namespace 新遊戲專案.script;

public partial class BasicSkill : Node
{
	[Export] protected string SkillName;
	[Export] protected int ActionPoint;
	[Export] protected int Atk;
	
	public Skill Skill { get; private set; }
	
	public override void _Ready()
	{
		Skill = new Skill(ActionPoint, Atk);
	}
}
