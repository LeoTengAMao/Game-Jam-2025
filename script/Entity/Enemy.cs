using 新遊戲專案.script;

public partial class Enemy : Entity
{
	public int CurrentHp => Hp ;
	public int CurrentAtk => Atk ;
	public int CurrentDef => Def ;
	public int CurrentSpd => Spd ;
	public Enemy(int hp, int atk, int def, int spd) : base(hp, atk, def, spd)
	{
		
	}
}
