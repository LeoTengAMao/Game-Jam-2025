namespace 新遊戲專案.script;

public class BasicAttackSkill : Skill
{
    private Player _player;
    public override void execute(Entity target)
    {
        int atk = _player.Atk;
        target.TakeDamage(atk);
    }

    public BasicAttackSkill(int actionPoint, Player player) : base(actionPoint)
    {
        _player = player;
    }
}