using UnityEngine;
using System.Collections;

public class AnimalAI : MonoBehaviour
{
	[SerializeField]
	Vector3 _startOffset = new Vector3(-2, 0, 0);

	[SerializeField]
    Vector3 _endOffset = new Vector3(2, 0, 0);

    [SerializeField]
    GameObject _model;

	[SerializeField]
	float _moveSpeed = 3f;

	Vector3 _originalPosition;

	Vector3 _targetPosition;

	enum States
	{
		Idle,
		Moving
	}

	States _state;

	void Awake()
	{
		_originalPosition = transform.position;
	}

	void Update()
	{
		switch (_state)
		{
		case States.Idle:
			IdleState();
			break;

		case States.Moving:
			MovingState();
			break;
		}
	}

	void IdleState()
	{
        Vector3 startPosition = _originalPosition + _startOffset;
        Vector3 endPosition = _originalPosition + _endOffset;

		if ((_targetPosition - startPosition).sqrMagnitude < 1e-1f)
        {
            _targetPosition = endPosition;
		} 
		else 
		{
			_targetPosition = startPosition;
		}

        float deltaX = _targetPosition.x - transform.position.x;
        Vector3 localScale = _model.transform.localScale;
        localScale.x = Mathf.Sign(deltaX);
        _model.transform.localScale = localScale;

		_state = States.Moving;
	}

	void MovingState()
	{
		transform.position = Vector3.MoveTowards (transform.position, _targetPosition, Time.deltaTime * _moveSpeed);

		if (transform.position == _targetPosition) 
        {
			_state = States.Idle;
		}
	}
}
