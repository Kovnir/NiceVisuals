using UnityEngine;
using System.Collections;

public class TranslationalMotionTestController : TestController
{
    protected override void OnIdleStart()
    {
        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
                ((TranslationalMotionParticleBehaviour)columns[i, j]).Randomize();
    }
}
