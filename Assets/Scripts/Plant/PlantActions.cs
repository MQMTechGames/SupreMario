using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Plant")]
[TaskDescription("Liberate Dik Dik")]
public class LiberateDikDik : Action
{
    public SharedPlant plant;

	public override TaskStatus OnUpdate()
	{
        plant.Value.LiberateDikDik();

		return TaskStatus.Success;
	}
}
