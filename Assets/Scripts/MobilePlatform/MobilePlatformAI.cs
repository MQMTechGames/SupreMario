using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;

public class MobilePlatformAI : MonoBehaviour
{
    BehaviorTree _bt;

    public void Init(MobilePlatform platform)
    {
        _bt = GetComponent<BehaviorTree>();

        SharedGameObject gameObject = (SharedGameObject) _bt.GetVariable("gameObject");
        gameObject.Value = platform.gameObject;

        _bt.enabled = true;
    }

    public void OnPlayerHit()
    {
        SharedBool playerOver = (SharedBool) _bt.GetVariable("playerOver");
        playerOver.Value = true;
    }
}
