using UnityEngine;
using System;

public class CapParticleBehaviour : TranslationalMotionParticleBehaviour
{
    
    private float rotation;
    private bool isReduction;
    private float rotationSpeed;
    public static float maxRotationSpeed = 0.6f;
    
    protected override void Start()
    {
        base.Start();
        //рандомизируем параметры вращения кришки
        isReduction = UnityEngine.Random.value > 0.5f ? true : false;
        rotation = isReduction ? -0.5f : 0.5f;
        rotationSpeed = UnityEngine.Random.Range(0, maxRotationSpeed);
    }

    protected override void InteractiveUpdate(float speed)
    {
        column.rotation = Quaternion.Lerp(column.rotation, new Quaternion(0, 0, 0, 1), Time.deltaTime * speed);
    }

    protected override float IdleUpdate(float speed)
    {
        idleCurrentSpeed = base.IdleUpdate(speed); 

        switch (isReduction)
        {
            case true:
                rotation -= Time.deltaTime;
                if (rotation < -1) isReduction = false;
                break;
            case false:
                rotation += Time.deltaTime;
                if (rotation > 1) isReduction = true;
                break;
        }
        column.Rotate(0, rotationSpeed * rotation, 0);

        return idleCurrentSpeed;
    }

}
