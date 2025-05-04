using Godot;
using 新遊戲專案.scenes;

namespace 新遊戲專案.script;

public partial class SkillHandler : Node
{
    [Export] private Godot.Collections.Array<Node> Skills;
    public Skill GetSkill(int id)
    {
        return ((BasicSkill)Skills[id]).Skill;
    }
}