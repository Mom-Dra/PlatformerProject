using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UIManager;

public class EquipUI : MonoBehaviour
{
    private GameObject itemPiecePrefab;
    private ItemPiece itemPiece;

    public PiData defaultData;
    public ItemList currentItem;

    void Start()
    {
        itemPiecePrefab = GameObject.Find("ItemPiece");
        itemPiece = itemPiecePrefab.GetComponent<ItemPiece>();
        itemPiece.itemIcon.sprite = defaultData.imageSprite;
        itemPiece.itemIcon.color = defaultData.imageColor;
    }

    public void ChangeIcon(PiData piData)
    {
        itemPiece.itemIcon.sprite = piData.imageSprite;
        itemPiece.itemIcon.color = piData.imageColor;
        currentItem = piData.item;
    }
}
