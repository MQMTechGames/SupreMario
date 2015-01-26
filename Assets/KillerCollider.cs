using UnityEngine;
using System.Collections;

public class KillerCollider : MonoBehaviour
{
    public PlayerController _playerController;

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player") && _playerController.IsFalling())
        {
            other.gameObject.SendMessage("OnHit", new HitInfo(999f, _playerController.gameObject), SendMessageOptions.DontRequireReceiver);
        }
    }
}
