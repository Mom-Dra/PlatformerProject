using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UIManager;

public class ExitUI : MonoBehaviour
{
    private TimeUI timeUI;
    private InGameUI inGameUI;
    private TextMeshProUGUI thisText;
    private List<Button> buttons = new List<Button>();

    public int buttonCount = 3;
    public GameObject baseButton;
    public MenuButtonData[] clearData;
    public MenuButtonData[] failedData;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        timeUI = transform.parent.GetComponentInChildren<TimeUI>();
        inGameUI = transform.parent.GetComponent<InGameUI>();
        thisText = GetComponentInChildren<TextMeshProUGUI>();

        for (int i = 0; i < buttonCount; i++)
        {
            Button button = baseButton.GetComponent<Button>();
            button = Instantiate(button, transform);
            button.transform.SetLocalPositionAndRotation(new Vector3(0, -100 * i, 0), Quaternion.identity);

            Navigation navi = new Navigation();
            navi.mode = Navigation.Mode.None;
            button.navigation = navi;

            RectTransform rectTransform = button.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(400, 70);

            buttons.Add(button);
        }
    }

    public void Show(bool isFailed)
    {
        if (isFailed == true)
        {
            for (int i = 0; i < buttonCount; i++)
            {
                if(i < failedData.Length)
                {
                    buttons[i].gameObject.SetActive(true);
                    MenuButtonUI buttonUI = buttons[i].GetComponent<MenuButtonUI>();
                    buttonUI.SetData(failedData[i]);
                }
                else
                {
                    buttons[i].gameObject.SetActive(false);
                }
            }
        }
        else
        {
            for (int i = 0; i < buttonCount; i++)
            {
                int index = gameObject.scene.buildIndex - 1;
                inGameUI.uiManager.stageDatas[index].isClear = true;
                if (index + 1 < inGameUI.uiManager.stageDatas.Length)
                    inGameUI.uiManager.stageDatas[index + 1].isActive = true;

                if (i < clearData.Length)
                {
                    buttons[i].gameObject.SetActive(true);
                    MenuButtonUI buttonUI = buttons[i].GetComponent<MenuButtonUI>();
                    buttonUI.SetData(clearData[i]);
                }
                else
                {
                    buttons[i].gameObject.SetActive(false);
                }
            }
        }

        SetTimeText();
    }

    

    void SetTimeText()
    {
        thisText.text = string.Format("{0:00} : {1:00}", timeUI.minutes, timeUI.seconds);
    }
}

