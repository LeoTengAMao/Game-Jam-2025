namespace 新遊戲專案.script;

public abstract class AbstractSkill
{
    protected int _actionPoint;
    protected int _atk;
    public AbstractSkill(int actionPoint, int atk)
    {
        _actionPoint = actionPoint;
        _atk = atk;
    }

    protected AbstractSkill(int actionPoint)
    {
        throw new System.NotImplementedException();
    }

    public abstract void Execute(Entity target);
}