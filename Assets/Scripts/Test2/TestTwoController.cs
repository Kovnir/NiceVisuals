using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestTwoController : TestController
{
    
    public float sinusHeight = 0.3f;
    public float sinusFrequency = 0.5f;

    private float sinusOffset = 0;
    public float sinusWawesSpeed = 0.1f;

    // Use this for initialization
    protected override void Start()
    {
        resourceName = "TubeParticle";
        TubeParticleBehaviour.center = new Vector2(width / 2, height / 2);
        TubeParticleBehaviour.SinOffset = () => sinusOffset;
        TubeParticleBehaviour.sinusFrequency = sinusFrequency;
        TubeParticleBehaviour.sinusHeight = sinusHeight;
        base.Start();
    }
    

    protected override void OnMouseEnter(int x, int y)
    {
        base.OnMouseEnter(x, y);
        StopAllCoroutines();
    }

    protected override void OnIdleStart()
    {
        StartCoroutine(RefreshSinusOffset());
    }

    public IEnumerator RefreshSinusOffset()
    {
        while (true)
        {
            sinusOffset += sinusWawesSpeed;
            yield return new WaitForSeconds(0.05f);
        }
    }

}
