using System.Collections.Generic;
using Godot;
using 新遊戲專案.scenes;

namespace 新遊戲專案.script;

public partial class EnemyGenerateHandler : Node
{
	private int _enemyNumbers;
	[Export] private Godot.Collections.Array<PackedScene> _howlingCanyon;
	[Export] private Godot.Collections.Array<PackedScene> _sharpGrassland;
	[Export] private Godot.Collections.Array<Node2D> _positions;

	private List<Godot.Collections.Array<PackedScene>> _enemies;
	private BasicEnemy[] _targets = new BasicEnemy[1];
	public void Init()
	{
		_enemies = new List<Godot.Collections.Array<PackedScene>> { _howlingCanyon, _sharpGrassland };
	}

	public void Generate(int idx)
	{
		var currentAreaEnemies = _enemies[idx];
		_enemyNumbers = _positions.Count;
		var randomIndex = GD.Randi() % currentAreaEnemies.Count;
		var enemyScene = currentAreaEnemies[(int)randomIndex];
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
