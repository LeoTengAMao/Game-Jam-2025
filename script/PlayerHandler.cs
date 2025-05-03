using Godot;

namespace 新遊戲專案.script;

public partial class PlayerHandler : Node
{
	[Export] private int _hp;
	[Export] private int _atk;
	[Export] private int _def;
	[Export] private int _spd;
	[Export] private int _actionPoint;

	public Player Player { get; private set; }

	public override void _Ready()
	{
		Player = new Player(_hp, _atk, _def, _spd, _actionPoint);
	}

	public void UseAttackSkill(Entity target)
	{
		Player.UseAttackSkill(target);
	}
	public void UseDefenceSkill()
	{
		Player.UseDefenceSkill();
	}
	public void UseSkill(int skillIdx, Entity target)
	{
		Player.UseSkill(skillIdx, target);
	}
}
