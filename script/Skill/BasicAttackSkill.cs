namespace 新遊戲專案.script;

public class BasicAttackSkill(int actionPoint, Player player) : AbstractSkill(actionPoint)
{
    public override void Execute(Entity target)
    {
        int atk = player.CurrentAtk;
        target.TakeDamage(atk);
    }
}