using System.Collections.Generic;
using Godot;
using 新遊戲專案.scenes;

namespace 新遊戲專案.script;

public partial class EnemyGenerateHandler : Node
{
	private int _enemyNumbers;
	[Export] private Godot.Collections.Array<PackedScene> _enemies = new();
	[Export] private Godot.Collections.Array<Node2D> _positions = new();
	private BasicEnemy[] _targets = new BasicEnemy[1];
	public override void _Ready()
	{
		Init();
	}
	private void Init()
	{
		_enemyNumbers = _positions.Count;
		var randomIndex = GD.Randi() % _enemies.Count;
		var enemyScene = _enemies[(int)randomIndex];
		var enemy = (BasicEnemy)enemyScene.Instantiate();
		_targets[0] = enemy;
		AddChild(enemy);
		enemy.GetNode<Node2D>(null).Position = new Vector2(_positions[(int)randomIndex].Position.X, _positions[(int)randomIndex].Position.Y);
	}

	public Enemy GetEnemyByIdx(int idx)
	{
		return _targets[idx].Enemy;
	}
}
