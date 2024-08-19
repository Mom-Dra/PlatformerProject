using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using static UIManager;

public class ExitUI : MonoBehaviour
{
    public int buttonCount = 3;
    public GameObject baseButton;
    public GameObject TimeUIPrefab;
    public ButtonData clearData;
    public ButtonData failedData;

    private TimeUI timeUI;
    private TextMeshProUGUI thisText;
    private List<Button> buttons = new List<Button>();

    void Start()
    {
        Init();
    }

    public void Init()
    {
        timeUI = TimeUIPrefab.GetComponent<TimeUI>();
        thisText = GetComponent<TextMeshProUGUI>();

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
        if(isFailed == true)
        {
            for (int i = 0; i < buttonCount; i++)
            {
                if(i < failedData.text.Length)
                {
                    buttons[i].gameObject.SetActive(true);
                    TextMeshProUGUI text = buttons[i].GetComponentInChildren<TextMeshProUGUI>();
                    text.text = failedData.text[i];
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
                if (i < clearData.text.Length)
                {
                    Debug.Log(buttons[i].gameObject);
                    buttons[i].gameObject.SetActive(true);
                    TextMeshProUGUI text = buttons[i].GetComponentInChildren<TextMeshProUGUI>();
                    text.text = clearData.text[i];
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
        TextMeshProUGUI text = timeUI.GetComponent<TextMeshProUGUI>();
        thisText.text = text.text;
    }

    public void SetData()
    {
        thisText.text = timeUI.GetEndTime();
    }
}

