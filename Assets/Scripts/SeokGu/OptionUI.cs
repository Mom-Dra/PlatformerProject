using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UIManager;

public class OptionUI : MonoBehaviour
{
    private GameObject optionUIPrefab;
    private Image thisImage;
    private Button thisButton;

    public PiData defaultData;

    void Awake()
    {
        optionUIPrefab = GameObject.Find("OptionUI");

        thisImage = optionUIPrefab.GetComponent<Image>();
        thisImage.sprite = defaultData.imageSprite;
        thisImage.color = defaultData.imageColor;

        thisButton = optionUIPrefab.GetComponent<Button>();
        thisButton.onClick.AddListener(OnClicked);

        Navigation navi = new Navigation();
        navi.mode = Navigation.Mode.None;
        thisButton.navigation = navi;
    }

    void OnClicked()
    {
        Debug.Log("OnClicked");
    }
}
