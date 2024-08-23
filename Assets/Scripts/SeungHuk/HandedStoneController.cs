using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HandedStoneController : MonoBehaviour
{
    public void ResetStone(bool check)
    {
        if(check)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
