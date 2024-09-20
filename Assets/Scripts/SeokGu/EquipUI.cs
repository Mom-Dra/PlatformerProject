using UnityEngine;
using static UIManager;

public class EquipUI : MonoBehaviour
{
    private GameObject itemPiecePrefab;
    private ItemPiece itemPiece;
    private AmmoUI ammoUI;

    public PiData defaultData;
    [HideInInspector]
    public ItemList currentItem;

    void Start()
    {
        itemPiecePrefab = GameObject.Find("ItemPiece");
        itemPiece = itemPiecePrefab.GetComponent<ItemPiece>();
        itemPiece.itemIcon.sprite = defaultData.imageSprite;
        itemPiece.itemIcon.color = defaultData.imageColor;

        ammoUI = GetComponentInChildren<AmmoUI>();
        if (currentItem != ItemList.Gun)
            ammoUI.ShowUI(false);
    }

    public void ChangeIcon(PiData piData)
    {
        itemPiece.itemIcon.sprite = piData.imageSprite;
        itemPiece.itemIcon.color = piData.imageColor;
        currentItem = piData.item;

        if (piData.item == ItemList.Gun)
            ammoUI.ShowUI(true);
        else
            ammoUI.ShowUI(false);
    }
}
