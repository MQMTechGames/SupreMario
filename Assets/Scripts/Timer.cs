using UnityEngine;
using System.Collections;

public class Timer 
{
    float _endTime;

    public void Wait(float seconds)
    {
        _endTime = Time.timeSinceLevelLoad + seconds;
    }

    public bool IsFinished()
    {
        return Time.timeSinceLevelLoad > _endTime;
    }
}
