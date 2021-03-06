﻿using UnityEngine;
using System.Collections;
using System;

public abstract class ParticleBehaviour : MonoBehaviour
{

    public Vector2 position;

    protected Transform column;

    public float target = 0;
    public float current = 0;
    public static float amplitude = 8;

    public float value;

    protected const float EPS = 0.1f;
    protected const float PHASE_TIME = 0.1f;
    public static float waweSpeed = 4;
    
    public static Action<int, int> mouseEnter;
    public static Action mouseExit;
    public static bool isIdle = false;

    void Awake()
    {
        column = transform.GetChild(0);
    }
    void OnMouseEnter() { mouseEnter((int)position.x, (int)position.y); } //вызывается в момент захода мыши на коллайдер объекта
    void OnMouseExit() { mouseExit(); } //вызывается в момент выхода мыши с коллайдера объекта

    private void Update()
    {
        float speed = waweSpeed;
        if (isIdle)
        {
            speed = IdleUpdate(speed);
        }
        else
        {
            InteractiveUpdate(speed);
        }

        float difference = (Mathf.Lerp(current, target, 0.5f) - current) * Time.deltaTime * speed;
        column.position += new Vector3(0, difference * amplitude, 0);
        current += difference;
    }
    //Необходимо переопределить
    protected virtual float IdleUpdate(float speed)
    {
        throw new NotImplementedException();
    }
    protected virtual void InteractiveUpdate(float speed)
    {
    }
}
