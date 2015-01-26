using UnityEngine;
using System.Collections.Generic;

public class ProjectileSpawner : MonoBehaviour
{
    public AutoProjectile _projectilePrefab;

    void Awake()
    {
        InvokeRepeating("SpawnProjectile", 1f, 2f);
    }

    void SpawnProjectile()
    {
        Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
    }
}
