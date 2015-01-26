using UnityEngine;
using System.Collections;

public class Plant : MonoBehaviour
{
    public DikDik _enslavedDikDik;

    PlantAI _ai;

    void Awake()
    {
        _ai = GetComponent<PlantAI>();
        _ai.Init(this);
    }

    public void LiberateDikDik()
    {
        _enslavedDikDik.OnBeingLiberated();
    }

    public void OnHit(HitInfo hitInfo)
    {
        if (hitInfo.Origin.CompareTag("Player"))
        {
            _ai.OnDying();
        }
    }
}
