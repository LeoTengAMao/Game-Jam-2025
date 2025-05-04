using Godot;
using 新遊戲專案.script;

public partial class Enemy : Entity
{
	public int CurrentHp => Hp ;
	public int CurrentAtk => Atk ;
	public int CurrentDef => Def ;
	public int CurrentSpd => Spd ;
	
	public int Points;
	public int Lines;
	public int Faces;
	public Enemy(int hp, int atk, int def, int spd, int dots, int lines, int faces) : base(hp, atk, def, spd)
	{
		Points = dots;
		Lines = lines;
		Faces = faces;
	}

	public void DoAttack(Entity target)
	{
		target.TakeDamage(Atk);
	}
}
