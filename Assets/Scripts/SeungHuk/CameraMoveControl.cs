using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveControl : MonoBehaviour
{
    public GameObject player;
    public void CameraMove()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2.5f, player.transform.position.z - 15f);
    }
}
