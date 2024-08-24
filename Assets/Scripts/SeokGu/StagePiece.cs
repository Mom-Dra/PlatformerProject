using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static StageUI;

public class StagePiece : MonoBehaviour
{
    private Image thisImage;
    private TextMeshProUGUI thisText;

    void Start()
    {
        thisImage = GetComponent<Image>();
        thisText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetData(StageData inStageData)
    {
        thisImage.sprite = inStageData.stageImageSprite;
        thisImage.color = inStageData.imageColor;
        thisImage.preserveAspect = true;
        thisText.text = inStageData.stageName;
    }
}
