using UnityEngine;
using System.Collections;

public class AutoProjectile : MonoBehaviour
{
    AutoProjectileAI _ai;

    bool _dying;

    void Awake()
    {
        _ai = GetComponent<AutoProjectileAI>();
        _ai.Init(this);
    }

    public void OnHit(HitInfo hitInfo)
    {
        if (hitInfo.Origin.CompareTag("Player"))
        {
            _ai.OnDying();
            _dying = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!_dying)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("PlayerDamage"))
            {
                Debug.Log("Stampled with PlayerDamage");
                PlayerController player = other.gameObject.GetComponentInParent<PlayerController>();

                player.OnHit();
            }
        }
    }
}
