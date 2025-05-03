namespace 新遊戲專案.script;

public abstract class AbstractSkill
{
    private int _actionPoint;
    public AbstractSkill(int actionPoint)
    {
        _actionPoint = actionPoint;
    }

    public abstract void Execute(Entity target);
}