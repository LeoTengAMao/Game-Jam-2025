using System.Collections.Generic;
using System.Linq;
using Godot;
using 新遊戲專案.script;

public partial class Player: Entity
{
	private int action_point;
	public List<Skill> skills { get; private set;  }
	public void add_skill(Skill skill)
	{
		skills.Add(skill);
	}

	public Player(int _hp, int _atk, int _def, int _spd) : base(_hp, _atk, _def, _spd)
	{
	}
}
