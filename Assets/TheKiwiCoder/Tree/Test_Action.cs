using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class Test_Action : ActionNode
{
    protected override void OnStart()
    {
        Debug.Log("OnStart");
    }

    protected override void OnStop()
    {
        Debug.Log("OnStop");
    }

    protected override State OnUpdate()
    {
        Debug.Log("Kiaora");

        return State.Success;
    }
}
