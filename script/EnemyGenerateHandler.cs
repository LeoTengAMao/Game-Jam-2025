using System.Collections.Generic;
using Godot;

namespace 新遊戲專案.script;

public partial class EnemyGenerateHandler : Node
{
    [Export] private int _enemyNumbers;
    [Export] private Godot.Collections.Array<PackedScene> _enemies = new();
    [Export] private Godot.Collections.Array<Node2D> _positions = new();
    private Slime[] targets = new Slime[1];
    public override void _Ready()
    {
        Init();
    }
    private void Init()
    {
        var randomIndex = GD.Randi() % _enemies.Count;
        var enemyScene = _enemies[(int)randomIndex];
        var enemy = (Slime)enemyScene.Instantiate();
        targets[0] = enemy;
        AddChild(enemy);
        enemy.GetNode<Node2D>(null).Position = new Vector2(_positions[(int)randomIndex].Position.X, _positions[(int)randomIndex].Position.Y);
    }

    public Enemy GetEnemyByIdx(int idx)
    {
        return targets[idx].Enemy;
    }
}