using UnityEngine;
using System;

/// <summary>
/// Частицы, обладающие по умолчанию поступательным движением
/// </summary>
public abstract class TranslationalMotionParticleBehaviour : ParticleBehaviour
{
    protected float idleSpeedFactor = 0;
    protected float idleCurrentSpeed = 0;

    private const float TRANSLATION_MOTION_MAX = 0.5f;

    protected virtual void Start()
    {
        if (column == null)
        {
            Debug.Log("Cant find column");
            return;
        }
        Randomize();
    }

    public void Randomize()
    {
        target = UnityEngine.Random.Range(0, TRANSLATION_MOTION_MAX);
        idleSpeedFactor = UnityEngine.Random.Range(0, 20);
    }

    protected override float IdleUpdate(float speed)
    {
        if (Math.Abs(target - current) < EPS)
        {
            if (target < TRANSLATION_MOTION_MAX / 2)
            {
                target = TRANSLATION_MOTION_MAX;
            }
            else
                target = 0;
            idleCurrentSpeed = 0;
        }
        idleCurrentSpeed += idleSpeedFactor * Time.deltaTime;
        return idleCurrentSpeed;
    }
}