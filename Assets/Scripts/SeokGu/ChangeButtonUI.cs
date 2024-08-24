using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;
using static StageUI;

public class ChangeButtonUI : MonoBehaviour
{
    private Button thisButton;
    private Image thisImage;
    private ButtonDirection buttonDir;

    void Start()
    {
        
        Init();
    }

    void Init()
    {
        thisButton = GetComponent<Button>();
        thisImage = GetComponent<Image>();

        Navigation navi = new Navigation();
        navi.mode = Navigation.Mode.None;
        thisButton.navigation = navi;

        thisButton.onClick.AddListener(OnClicked);
    }

    void OnClicked()
    {
        Debug.Log(buttonDir);
    }

    public void SetData(ChangeButtonData inData)
    {
        thisImage.sprite = inData.imageSprite;
        thisImage.color = inData.imageColor;
        buttonDir = inData.direction;
    }

    void Update()
    {

    }

    
}
