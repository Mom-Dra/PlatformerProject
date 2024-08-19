using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPiece : MonoBehaviour
{
    private Image thisImage;

    // Start is called before the first frame update
    void Awake()
    {
        Init();
    }

    public void Init()
    {
        thisImage = GetComponent<Image>();
    }

    public void SetImageFillAmount(float Amount)
    {
        thisImage.fillAmount = Amount;
    }

    public void SetUIPosition(Vector3 InPosition)
    {
        this.transform.localPosition = InPosition;
    }
}
