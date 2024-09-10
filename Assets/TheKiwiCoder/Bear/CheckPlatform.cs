using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using UnityEngine.Rendering.Universal;

public class CheckPlatform : ActionNode
{
    public float forwardLength;
    public float downLength;
    protected override void OnStart()
    {

    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        Debug.DrawRay(context.transform.position + Vector3.up * 2f + context.transform.forward * forwardLength, Vector3.down * downLength, Color.red);
        RaycastHit hit;

        if (Physics.Raycast(context.transform.position + Vector3.up * 2f + context.transform.forward * forwardLength, Vector3.down, out hit, downLength, LayerMask.GetMask(LayerEnum.Platform.ToString())))
        {
            Debug.Log($"�ٴ��� ������: {hit.transform.name}"); ;

            return State.Success;
        }

        Debug.Log("�ٴ��� �������� ����");

        return State.Failure;
    }
}
