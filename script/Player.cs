using System.Collections.Generic;
using System.Linq;
using Godot;
using 新遊戲專案.script;

public partial class Player : CharacterBody2D
{
	[Export] private int pos_x;
	[Export] private int pos_y;
	private int action_point;
	public List<Skill> skills { get; private set;  }

	public override void _Ready()
	{
		Vector2 pos;
		pos.X = pos_x;
		pos.Y = pos_y;
		
		Position = pos;
	}
	public override void _Process(double delta)
	{
	}
	public void add_skill(Skill skill)
	{
		skills.Add(skill);
	}
}
