using UnityEngine;
using System.Collections;

public class MarioCameraFollower : MonoBehaviour
{
	[SerializeField]
	Transform _target;

	[SerializeField]
	float _yPositionCameraHight = 6f;

	[SerializeField]
	float _cameraHightYDelta = -4f;

	[SerializeField]
	float _smoothFactor = 1f;

	Vector3 _targetDelta;
	Vector3 _targetDeltaHight;

	void Awake()
	{
		_targetDelta = transform.position - _target.transform.position;
		_targetDeltaHight = _targetDelta;
		_targetDeltaHight.y += _cameraHightYDelta;
	}

	void Update()
	{
		Vector3 idealPos = _target.position + _targetDelta;
		if (_target.position.y > _yPositionCameraHight)
		{
			idealPos = _target.position + _targetDeltaHight;
		}

		transform.position = Vector3.Lerp (transform.position, idealPos, Time.deltaTime * _smoothFactor);
	}
}
