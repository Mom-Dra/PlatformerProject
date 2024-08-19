using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    private GameObject TimeUIPrefab;
    private TextMeshProUGUI thisText;

    private float elapsedTime;
    private string endTimeString;

    void Start()
    {
        TimeUIPrefab = GameObject.Find("TimeUI");
        thisText = TimeUIPrefab.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        thisText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        endTimeString = thisText.text;
    }

    public string GetEndTime() { return endTimeString; }
}
