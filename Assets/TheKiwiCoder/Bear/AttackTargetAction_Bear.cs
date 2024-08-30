using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTargetAction_Bear : AttackTargetAction
{
    protected override void Attack()
    {
        int randomNum = Random.Range(1, 4);
        context.animator.SetTrigger($"Attack{randomNum}");
    }
}
