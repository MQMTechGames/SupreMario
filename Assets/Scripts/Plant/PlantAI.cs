using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;

public class PlantAI : MonoBehaviour
{
    BehaviorTree _bt;

    public void Init(Plant plant)
    {
        _bt = GetComponent<BehaviorTree>();

        SharedGameObject gameObject = (SharedGameObject) _bt.GetVariable("gameObject");
        gameObject.Value = plant.gameObject;

        SharedPlant sharedPlant = (SharedPlant) _bt.GetVariable("plant");
        sharedPlant.Value = plant;

        _bt.enabled = true;
    }

    public void OnDying()
    {
        SharedBool isDying = (SharedBool) _bt.GetVariable("isDying");
        isDying.Value = true;
    }
}
