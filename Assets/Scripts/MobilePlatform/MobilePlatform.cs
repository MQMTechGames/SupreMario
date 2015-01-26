using UnityEngine;
using System.Collections;

public class MobilePlatform : MonoBehaviour
{
    MobilePlatformAI _ai;

    void Awake()
    {
        _ai = GetComponent<MobilePlatformAI>();
        _ai.Init(this);
    }

    public void OnHit(HitInfo hitInfo)
    {
        if (hitInfo.Origin.CompareTag("Player"))
        {
            _ai.OnPlayerHit();
        }
    }
}
