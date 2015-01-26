using UnityEngine;
using System.Collections;

public class TargetFollower : MonoBehaviour
{
    public Transform _target;
    public float _smoothness = 1f;

    Vector3 _originOffset;

    void Awake()
    {
        _originOffset = transform.position - _target.position;
    }

    void Update()
    {
        Vector3 idealPositon = _target.position + _originOffset;

        Vector3 newPosition = Vector3.Lerp(transform.position, idealPositon, Time.deltaTime * _smoothness);
        transform.position = new Vector3(newPosition.x, transform.position.y, transform.position.z);
    }
}
