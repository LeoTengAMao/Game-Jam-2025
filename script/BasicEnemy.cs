using Godot;
using 新遊戲專案.script;

namespace 新遊戲專案.scenes;

public partial class BasicEnemy : Node
{
	[Export] protected string EnemyName;
	[Export] protected int Hp;
	[Export] protected int Atk;
	[Export] protected int Def;
	[Export] protected int Spd;
	
	[Export] protected int Points;
	[Export] protected int Lines;
	[Export] protected int Planes;
	
	[Export] protected int AppearChance;
	
	public Enemy Enemy { get; private set; }

	public override void _Ready()
	{
		Enemy = new Enemy(Hp, Atk, Def, Spd, Points, Lines, Planes);
	}

	public override void _Process(double delta)
	{
		if (Enemy.CurrentHp <= 0)
		{
			QueueFree();
		}
	}
}
