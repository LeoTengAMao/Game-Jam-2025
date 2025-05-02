using System.Diagnostics;
using Godot;

namespace 新遊戲專案.script;

public partial class Slime : Node
{
	[Export] private int _hp;
	[Export] private int _atk;
	[Export] private int _def;
	[Export] private int _spd;

	public Enemy Enemy { get; private set; }

	public override void _Ready()
	{
		Enemy = new Enemy(_hp, _atk, _def, _spd);
	}

	public override void _Process(double delta)
	{
		if (Enemy.Hp <= 0) QueueFree();
	}
}
