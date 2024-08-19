using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPiece : MonoBehaviour
{
    [HideInInspector]
    public Image itemIcon;
    void Awake()
    {
        Init();
    }
    public void Init()
    {
        itemIcon = GetComponent<Image>();
    }
}
