using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;

public class DikDikAI : MonoBehaviour
{
    BehaviorTree _bt;

    public void Init(DikDik dikDik)
    {
        _bt = GetComponent<BehaviorTree>();

        SharedBool isEnslaved = (SharedBool) _bt.GetVariable("isEnslaved");
        isEnslaved.Value = true;

        SharedGameObject gameObject = (SharedGameObject) _bt.GetVariable("gameObject");
        gameObject.Value = dikDik.gameObject;

        SharedDikDik sharedDikDik = (SharedDikDik) _bt.GetVariable("dikdik");
        sharedDikDik.Value = dikDik;

        _bt.enabled = true;
    }

    public void OnBeingLiberated()
    {
        SharedBool isEnslaved = (SharedBool) _bt.GetVariable("isEnslaved");
        isEnslaved.Value = false;
    }
}
