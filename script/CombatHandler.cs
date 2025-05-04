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

	private GDScript BackpackGD;

	private int accumulateDot = 1;
	private int accumulateLine = 1;
	private int accumulateFace = 1;
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
			_player.Player.TurnStartInit();
			GD.Print(_player.Player.CurrentActionPoint);
		}
		if (state == GameState.ENEMYTURN)
		{
			EmitSignal(SignalName.EnemyTurnStart);
			EnemyTurn();
		}
		if (state == GameState.WON)
		{
			WinGame();
			EmitSignal(SignalName.Won);
		}
		if (state == GameState.LOST)
		{
			LoseGame();
			EmitSignal(SignalName.Lost);
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
		var dotAmount = GD.Randi() % accumulateDot;
		var lineAmount = GD.Randi() % accumulateLine;
		var faceAmount = GD.Randi() % accumulateFace;
		int dot = (int)GetNode("/root/Global").Get("dot");
		int line = (int)GetNode("/root/Global").Get("line");
		int face = (int)GetNode("/root/Global").Get("face");
		
		GD.Print("dotAmount");
		GD.Print(dotAmount);
		GD.Print(lineAmount);
		GD.Print(faceAmount);
		
		GetNode("/root/Global").Set("dot",dot + dotAmount);
		GetNode("/root/Global").Set("line",line + lineAmount);
		GetNode("/root/Global").Set("face",face + faceAmount);
		
		await ToSignal(GetTree().CreateTimer(3.0f), SceneTreeTimer.SignalName.Timeout);
		/*TODO: change to WinScene*/
	}

	private async void EnemyTurn()
	{
		Enemy enemy = _enemyGenerator.GetEnemyByIdx(0);
		enemy.DoAttack(_player.Player);
		
		Node inter = GetParent().GetNode("HealthBar"); 
		inter.Call("HealthBarUpdate", _player.Player.CurrentHp, _player.Player.CurrentMaxHp);
		
		await ToSignal(GetTree().CreateTimer(3.0f), SceneTreeTimer.SignalName.Timeout);
		
		GD.Print(_player.Player.CurrentHp);
		
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
		using Node healthBar = GetParent().GetNode("HealthBar"); 
		healthBar.Call("HealthBarUpdate", _player.Player.CurrentHp, _player.Player.CurrentMaxHp);
		
		Enemy enemy = _enemyGenerator.GetEnemyByIdx(0);
		Node enemyHealth = GetParent().GetNode("Enemy_health"); 
		enemyHealth.Call("HealthBarUpdate", enemy.CurrentHp, enemy.CurrentMaxHp);
		enemyHealth.Call("EnemyTextUpdate", enemy.Name);
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
	public void Click_Rest()
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
		GD.Print(_enemyGenerator.GetEnemyByIdx(targetIdx).CurrentHp);
		Enemy _enemy = _enemyGenerator.GetEnemyByIdx(0);
		Node enemyHealth = GetParent().GetNode("Enemy_health"); 
		enemyHealth.Call("HealthBarUpdate", _enemy.CurrentHp, _enemy.CurrentMaxHp);
		enemyHealth.Call("EnemyTextUpdate", _enemy.Name);
		if (targetIdx >= 0)
		{
			Entity target = _enemyGenerator.GetEnemyByIdx(targetIdx);
			if (target.IsDead())
			{
				Enemy enemy = _enemyGenerator.GetEnemyByIdx(0);
				accumulateDot += enemy.Points;
				accumulateLine += enemy.Lines;
				accumulateFace += enemy.Faces;
				SwitchState(GameState.WON);
				return;
			}
		}

		if (_player.Player.CurrentActionPoint <= 0)
		{
			SwitchState(GameState.ENEMYTURN);
		}
	}


	private void SwitchNextTurn()
	{
		while (true)
		{
			Entity target = _enemyGenerator.GetEnemyByIdx(0);
			if (_player.Player.IsSpdGreaterThanTarget(10) || target.IsSpdGreaterThanTarget(10))
			{
				if (_player.Player.GetAccumulateSpd() > target.GetAccumulateSpd())
				{
					SwitchState(GameState.PLAYERTURN);
				}
				if (_player.Player.GetAccumulateSpd() < target.GetAccumulateSpd())
				{
					SwitchState(GameState.ENEMYTURN);
				}
				if (_player.Player.GetAccumulateSpd() == target.GetAccumulateSpd())
				{
					var r = GD.Randi() % 2;
					if (r == 0)
					{
							SwitchState(GameState.ENEMYTURN);
					}
					if (r == 1)
					{
						SwitchState(GameState.PLAYERTURN);
					}
				}
			}
				
		}
	}
	
	public void Click_Boom(int skillIdx, int targetIdx)
	{
		Entity target = _enemyGenerator.GetEnemyByIdx(targetIdx);
		target.DirectDamage(2);
		_player.Player.UseActionPoint(1);
		FinishedPlayerOperate(targetIdx);
	}
	public void Click_Hp_Potion(int targetIdx)
	{
		Entity target = _enemyGenerator.GetEnemyByIdx(targetIdx);
		_player.Player.Heal(2);
		FinishedPlayerOperate(targetIdx);
	}
}
