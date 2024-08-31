using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSwitch : Platform
{
    //플레이어 점프 하면 온 오프 될 플랫폼

    public override IEnumerator GetOnEvent()
    {
        yield return null;
    }

    public override IEnumerator GetOutEvent()
    {
        yield return null;
    }

}
