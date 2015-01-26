using UnityEngine;
using System.Collections;

public class HitInfo
{
    public float Damage;
    public GameObject Origin;

    public HitInfo(float damage, GameObject origin)
    {
        Damage = damage;
        Origin = origin;
    }
}
