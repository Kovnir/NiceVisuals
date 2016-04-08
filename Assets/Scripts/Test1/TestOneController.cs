using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestOneController : TranslationalMotionTestController
{
    // Use this for initialization
    protected override void Start()
    {
        resourceName = "SimpleParticle";
        base.Start();
    }
}
