using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UIManager;

public class PiPiece : MonoBehaviour
{
    public GameObject itemPiecePrefab;

    private Image thisImage;
    private GameObject equipUiPrefab;
    private ItemPiece itemPiece;
    private EquipUI equipUI;
    private PiData thisData;

    private float angleRange;
    private bool bSelect = false;
    private bool bData = false;

    void Awake()
    {
        Init();
    }

    public void Init()
    {
        thisImage = GetComponent<Image>();
        equipUiPrefab = GameObject.Find("EquipUI");
        equipUI = equipUiPrefab.GetComponent<EquipUI>();

        itemPiece = itemPiecePrefab.GetComponent<ItemPiece>();
        itemPiece = Instantiate(itemPiece);
        itemPiece.transform.SetParent(transform);
    }

    public void SetData(PiData piData)
    {
        thisData = piData;
        itemPiece.itemIcon.sprite = piData.imageSprite;
        itemPiece.itemIcon.color = piData.imageColor;
        bData = true;
    }

    public void SetImageFillAmount(float Amount)
    {
        thisImage.fillAmount = Amount;
    }

    public void SetUIRotation(Vector3 Rotation)
    {
        Quaternion piRotation = Quaternion.Euler(Rotation);
        transform.SetLocalPositionAndRotation(new Vector3(0,0,0), piRotation);

        Vector3 itemPosition = new Vector3(-13, 31, 0);
        Vector3 itemRotation = new Vector3(0, 0, -Rotation.z);
        Vector3 itemScale = new Vector3(0.2f, 0.2f, 1);
        itemPiece.transform.SetLocalPositionAndRotation(itemPosition, Quaternion.Euler(itemRotation));
        itemPiece.transform.localScale = itemScale;
    }

    public void SetAngleRange(float InAngleRange)
    {
        angleRange = InAngleRange;
    }

    // MousePosition값으로 Angle을 계산하고 그 값과 Piece의 Rotation값과 비교해서 UI크기 조정
    public void MouserPosUpdate()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 temp = mousePos - (Vector2)transform.position;
        float angle = ((Mathf.Atan2(temp.y, temp.x) * Mathf.Rad2Deg) + 270) % 360;
        if (angle >= transform.rotation.eulerAngles.z && angle < transform.rotation.eulerAngles.z + angleRange)
        {
            transform.localScale = new Vector3(2.5f, 2.5f, 1);
            bSelect = true;
        }
        else
        {
            transform.localScale = new Vector3(2, 2, 1);
            bSelect = false;
        }
    }

    public void OnClicked()
    {
        equipUI.ChangeIcon(thisData);
    }

    public bool IsSelected() { return bSelect; }
    public bool IsData() { return bData; }
}
