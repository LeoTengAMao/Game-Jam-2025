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

enum Area
{
	HowlingCanyon,
	SharpGrassland,
}

public partial class CombatHandler : Node
{
	[Signal] public delegate void PlayerTurnStartEventHandler();
	[Signal] public delegate void EnemyTurnStartEventHandler();
	[Signal] public delegate void WonEventHandler();
	[Signal] public delegate void LostEventHandler();

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
		if (state == GameState.WON)
		{
			EmitSignal(SignalName.Won);
			WinGame();
		}
		if (state == GameState.LOST)
		{
			EmitSignal(SignalName.Lost);
			LoseGame();
		}
		State = state;
	}

	private async void LoseGame()
	{
		await ToSignal(GetTree().CreateTimer(3.0f), SceneTreeTimer.SignalName.Timeout);
		/*TODO: change to LoseScene*/
	}

	private async void WinGame()
	{
		await ToSignal(GetTree().CreateTimer(3.0f), SceneTreeTimer.SignalName.Timeout);
		/*TODO: change to WinScene*/
	}

	private async void EnemyTurn()
	{
		Enemy enemy = _enemyGenerator.GetEnemyByIdx(0);
		enemy.DoAttack(_player.Player);
		
		Node inter = GetParent().GetNode("Interface"); 
		inter.Call("HealthBarUpdate", _player.Player.CurrentHp, _player.Player.CurrentMaxHp);
		
		await ToSignal(GetTree().CreateTimer(3.0f), SceneTreeTimer.SignalName.Timeout);

		if (_player.Player.IsDead())
		{
			SwitchState(GameState.LOST);
		}
		else
		{
			GD.Print("SwitchState to Player TURN");
			SwitchState(GameState.PLAYERTURN);
		}
	}

	// private async void PlayerTurn()
	// {
	// 	await ToSignal(GetTree().CreateTimer(3.0f), SceneTreeTimer.SignalName.Timeout);
	// 	GD.Print("SwitchState to ENEMY TURN");
	// 	SwitchState(GameState.ENEMYTURN);
	// }

	private void Init()
	{
		_enemyGenerator.Init();
		_enemyGenerator.Generate((int)Area.HowlingCanyon);
		SwitchState(GameState.PLAYERTURN);
	}

	public void Click_Attack(int targetIdx)
	{
		Entity target = _enemyGenerator.GetEnemyByIdx(targetIdx);
		_player.UseAttackSkill(target);
		FinishedPlayerOperate(targetIdx);
	}
	public void Click_Defense()
	{
		_player.UseDefenceSkill();
		FinishedPlayerOperate(-1);
	}
	public void Click_Skill(int skillIdx, int targetIdx)
	{
		Entity target = _enemyGenerator.GetEnemyByIdx(targetIdx);
		_player.UseSkill(skillIdx, target);
		FinishedPlayerOperate(targetIdx);
	}

	private void FinishedPlayerOperate(int targetIdx)
	{
		if (targetIdx >= 0)
		{
			Entity target = _enemyGenerator.GetEnemyByIdx(targetIdx);
			if (target.IsDead())
			{
				SwitchState(GameState.WON);
				return;
			}
		}
		SwitchState(GameState.ENEMYTURN);
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
