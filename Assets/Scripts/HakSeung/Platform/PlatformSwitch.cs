using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSwitch : Platform
{
    //�÷��̾� ���� �ϸ� �� ���� �� �÷���

    public override IEnumerator GetOnEvent()
    {
        yield return null;
    }

    public override IEnumerator GetOutEvent()
    {
        yield return null;
    }

}
