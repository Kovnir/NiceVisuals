using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class TubeParticleBehaviour : ParticleBehaviour
{    
    public static Vector2 center;
    public static float sinusHeight = 0.3f;
    public static float sinusFrequency = 0.5f;

    public static Func<float> SinOffset;

    public float distance;
    
    // Use this for initialization
    void Start()
    {
        distance = Mathf.Sqrt(Mathf.Pow(position.x - center.x,2) + Mathf.Pow(position.y - center.y, 2));
    }

    protected override float IdleUpdate(float speed)
    {
        if (SinOffset != null)
            target = Mathf.Sin(-distance * sinusFrequency + SinOffset()) * sinusHeight;
        return speed;
    }

}
