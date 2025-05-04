using Godot;
using 新遊戲專案.script;

public partial class Enemy : Entity
{
	public string Name;
	public int CurrentMaxHp => MaxHp;
	public int CurrentHp => Hp ;
	public int CurrentAtk => Atk ;
	public int CurrentDef => Def ;
	public int CurrentSpd => Spd ;
	
	public readonly int Points;
	public readonly int Lines;
	public readonly int Faces;
	public Enemy(int hp, int atk, int def, int spd, int dots, int lines, int faces, string name) : base(hp, atk, def, spd)
	{
		Name = name;
		Points = dots;
		Lines = lines;
		Faces = faces;
	}

	public void DoAttack(Entity target)
	{
		target.TakeDamage(Atk);
	}
}
