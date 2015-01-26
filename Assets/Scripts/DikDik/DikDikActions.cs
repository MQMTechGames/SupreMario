using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("DikDik")]
[TaskDescription("Change the sprite")]
public class DikDikSetSpriteAction : Action
{
    public DikDik.SpriteType spriteType;
    public SharedDikDik dikDik;

	public override TaskStatus OnUpdate()
	{
        dikDik.Value.SetSprite(spriteType);

		return TaskStatus.Success;
	}
}
