using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using static UIManager;

public class ExitUI : MonoBehaviour
{
    private GameObject TimeUIPrefab;
    private TimeUI timeUI;
    private TextMeshProUGUI thisText;
    private List<Button> buttons = new List<Button>();

    public int buttonCount = 3;
    public GameObject baseButton;
    public ButtonData[] clearData;
    public ButtonData[] failedData;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        TimeUIPrefab = GameObject.Find("TimeUI");
        timeUI = TimeUIPrefab.GetComponent<TimeUI>();
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
        if(isFailed == true)
        {
            for (int i = 0; i < buttonCount; i++)
            {
                if(i < failedData.Length)
                {
                    buttons[i].gameObject.SetActive(true);
                    ButtonUI buttonUI = buttons[i].GetComponent<ButtonUI>();
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
                if (i < clearData.Length)
                {
                    buttons[i].gameObject.SetActive(true);
                    ButtonUI buttonUI = buttons[i].GetComponent<ButtonUI>();
                    buttonUI.SetData(clearData[i]);
                }
                else
                {
                    buttons[i].gameObject.SetActive(false);
                }
            }
        }

        SetTimeText();
        Time.timeScale = 0.0f;
        //SetTimeScale();
    }

    void SetTimeScale()
    {
        MenuUI menuUI = GetComponent<MenuUI>();
        Debug.Log(menuUI);
        if(gameObject.activeSelf == false && menuUI.gameObject.activeSelf == false)
        {
            Time.timeScale = 1.0f;
        }
        else
            Time.timeScale = 0.0f;
    }

    void SetTimeText()
    {
        thisText.text = string.Format("{0:00} : {1:00}", timeUI.minutes, timeUI.seconds);
    }
}

