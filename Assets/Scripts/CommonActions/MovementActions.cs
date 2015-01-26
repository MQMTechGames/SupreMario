using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Movement")]
[TaskDescription("KeepMoving To Apply Delta Position")]
public class MovementAction : Action
{
    public SharedGameObject targetGameObject;
    public SharedVector3 deltaPosition;
    public SharedFloat speed;

    Transform _transform;
    Vector3 _originalPosition;
    Vector3 _targetPosition;

    public override void OnStart()
    {
        base.OnStart();
        _transform = targetGameObject.Value.transform;
        _targetPosition = _transform.position + deltaPosition.Value;
    }

	public override TaskStatus OnUpdate()
	{
        _transform.position = Vector3.MoveTowards(_transform.position, _targetPosition, Time.deltaTime * speed.Value);

        if (_transform.position == _targetPosition)
        {
            return TaskStatus.Success;
        } else
        {
            return TaskStatus.Running;
        }
	}
}
