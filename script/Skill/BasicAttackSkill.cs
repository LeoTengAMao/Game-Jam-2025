namespace 新遊戲專案.script;

public class BasicAttackSkill(int actionPoint, int atk) : AbstractSkill(actionPoint, atk)
{
    public int ActionPoint => _actionPoint;
    public int Atk => _atk;
    public override void Execute(Entity target)
    {
        target.TakeDamage(atk);
    }
}