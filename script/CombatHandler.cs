using System.Threading.Tasks;
using Godot;

namespace 新遊戲專案.script;

public enum GameState
{
	START,
	PLAYERTURN,
	ENEMYTURN,
	WON,
	LOST
}

public partial class CombatHandler : Node
{
	[Signal]
	public delegate void PlayerTurnStartEventHandler();
	
	[Signal]
	public delegate void EnemyTurnStartEventHandler();

	private GameState State;
	[Export] private PlayerHandler _player;
	[Export] private EnemyGenerateHandler _enemyGenerator;
	public override void _Ready()
	{
		SwitchState(GameState.START);
		Init();
	}

	private void SwitchState(GameState state)
	{
		if (state == GameState.PLAYERTURN)
		{
			EmitSignal(SignalName.PlayerTurnStart);
		}
		if (state == GameState.ENEMYTURN)
		{
			EmitSignal(SignalName.EnemyTurnStart);
			EnemyTurn();
		}
		State = state;
	}

	private async void EnemyTurn()
	{
		await ToSignal(GetTree().CreateTimer(3.0f), SceneTreeTimer.SignalName.Timeout);
		GD.Print("SwitchState to Player TURN");
		SwitchState(GameState.PLAYERTURN);
	}

	// private async void PlayerTurn()
	// {
	// 	await ToSignal(GetTree().CreateTimer(3.0f), SceneTreeTimer.SignalName.Timeout);
	// 	GD.Print("SwitchState to ENEMY TURN");
	// 	SwitchState(GameState.ENEMYTURN);
	// }

	private void Init()
	{
		SwitchState(GameState.PLAYERTURN);
	}

	public void Click_Attack(int targetIdx)
	{
		_player.UseAttackSkill(_enemyGenerator.GetEnemyByIdx(targetIdx));
		SwitchState(GameState.ENEMYTURN);
	}
	public void Click_Defense()
	{
		_player.UseDefenceSkill();
		SwitchState(GameState.ENEMYTURN);
	}
	public void Click_Skill(int skillIdx, int targetIdx)
	{
		_player.UseSkill(skillIdx, _enemyGenerator.GetEnemyByIdx(targetIdx));
		SwitchState(GameState.ENEMYTURN);
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
