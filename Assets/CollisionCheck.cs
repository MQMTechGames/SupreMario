using UnityEngine;
using System.Collections;

public class CollisionCheck : MonoBehaviour
{
    public string _collisionTag = "ground";

    public bool _isTouching;
    public bool IsTouching { get { return _isTouching; } }

    public GameObject Touched;

    public Vector3 CollisionPosition{ get; set; }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_collisionTag))
        {
            _isTouching = true;

            Touched = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(_collisionTag))
        {
            _isTouching = false;
        }
    }
}
