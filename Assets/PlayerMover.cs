using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour
{
    Rigidbody _rigidbody;

    public float _upForce = 200f;
    public float _horizontalForce = 25f;

    public float _maxYVelocity = 100f;
    public float _maxHVelocity = 100f;

    public Vector3 _velocity;

    void Awake()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>();
    }

    public void Jump()
    {
        _rigidbody.AddForce(new Vector3(0f, 1f, 0f) * _upForce, ForceMode.Acceleration);

        Vector3 newVelocity = _rigidbody.velocity;
        float velSign = Mathf.Sign(newVelocity.x);
        newVelocity.y = velSign * Mathf.Min(Mathf.Abs(_velocity.y), _maxYVelocity);
        _rigidbody.velocity = newVelocity;
    }

    public void Move(float direction)
    {
        _rigidbody.AddForce(new Vector3(direction, 0f, 0f) * _horizontalForce, ForceMode.Acceleration);

        Vector3 newVelocity = _rigidbody.velocity;
        float sign = Mathf.Sign(newVelocity.x);
        newVelocity.x = sign * Mathf.Clamp(Mathf.Abs(newVelocity.x), 0f, _maxHVelocity);
        _rigidbody.velocity = newVelocity;
    }

    public bool IsFalling()
    {
        return _rigidbody.velocity.y < -1e-1f;
    }
}
