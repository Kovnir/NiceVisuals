using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestThreeController : TranslationalMotionTestController
{
    // Use this for initialization
    protected override void Start()
    {
        resourceName = "CapParticle";
        base.Start();
    }
}
