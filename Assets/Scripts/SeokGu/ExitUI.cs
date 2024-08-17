using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ExitUI : MonoBehaviour
{
    public int buttonCount = 3;
    public GameObject baseButton;

    private GameObject ExitUIPrefab;
    private GameObject TimeUIPrefab;
    private TimeUI timeUI;
    private TextMeshProUGUI timeText;
    private List<Button> buttons = new List<Button>();

    void Start()
    {
        ExitUIPrefab = GameObject.Find("ExitUI");
        TimeUIPrefab = GameObject.Find("TimeUI");
        timeUI = TimeUIPrefab.GetComponent<TimeUI>();
        timeText.GetComponent<TextMeshProUGUI>();

        for (int i = 0; i < buttonCount; i++)
        {
            Button button = baseButton.GetComponent<Button>();
            button = Instantiate<Button>(button);
            button.transform.SetParent(transform);
        }
    }

    public void SetData()
    {
        timeText.text = timeUI.GetEndTime();
    }
}
