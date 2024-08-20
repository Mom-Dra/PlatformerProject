using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UIManager;

public class OptionUI : MonoBehaviour
{
    private Image thisImage;
    private Button thisButton;
    private GameObject menuUIPrefab;

    public PiData defaultData;

    void Awake()
    {
        thisImage = GetComponent<Image>();
        thisImage.sprite = defaultData.imageSprite;
        thisImage.color = defaultData.imageColor;

        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(OnClicked);

        Navigation navi = new Navigation();
        navi.mode = Navigation.Mode.None;
        thisButton.navigation = navi;
    }

    public void Init(GameObject inGameObject)
    {
        menuUIPrefab = inGameObject;
    }

    void OnClicked()
    {
        menuUIPrefab.SetActive(!menuUIPrefab.activeSelf);
        MenuUI menuUI = menuUIPrefab.GetComponent<MenuUI>();
        menuUI.Show();
    }
}
