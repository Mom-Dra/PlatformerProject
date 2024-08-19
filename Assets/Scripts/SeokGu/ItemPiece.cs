using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPiece : MonoBehaviour
{
    public Image itemIcon;
    void Awake()
    {
        Init();
    }
    public void Init()
    {
        itemIcon = GetComponentInChildren<Image>();
    }
}
