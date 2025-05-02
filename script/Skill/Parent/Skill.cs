namespace 新遊戲專案.script;

public abstract class Skill
{
    private int _actionPoint;
    public Skill(int actionPoint)
    {
        _actionPoint = actionPoint;
    }
    public abstract void execute(Entity target);
}