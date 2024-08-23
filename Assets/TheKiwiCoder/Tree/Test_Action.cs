using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using System.Data;

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

        int a; 



        return State.Success;
    }
}
