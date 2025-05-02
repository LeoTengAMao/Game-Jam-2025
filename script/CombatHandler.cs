using Godot;
using 新遊戲專案.script;

public partial class CombatHandler : Node
{
	[Export] private PlayerHandler _player;
	[Export] private EnemyGenerateHandler _enemyGenerator;
	public override void _Ready()
	{
	}
	public void Click_Attack(int targetIdx)
	{
		_player.UseAttack(_enemyGenerator.GetEnemyByIdx(targetIdx));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
