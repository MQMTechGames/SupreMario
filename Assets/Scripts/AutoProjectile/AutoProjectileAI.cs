using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;

public class AutoProjectileAI : MonoBehaviour
{
    BehaviorTree _bt;

    public void Init(AutoProjectile projectile)
    {
        _bt = GetComponent<BehaviorTree>();

        SharedGameObject gameObject = (SharedGameObject) _bt.GetVariable("gameObject");
        gameObject.Value = projectile.gameObject;

        SharedAutoProjectile autoProjectile = (SharedAutoProjectile) _bt.GetVariable("autoProjectile");
        autoProjectile.Value = projectile;

        _bt.enabled = true;
    }

    public void OnDying()
    {
        SharedBool isDying = (SharedBool) _bt.GetVariable("isDying");
        isDying.Value = true;
    }
}
