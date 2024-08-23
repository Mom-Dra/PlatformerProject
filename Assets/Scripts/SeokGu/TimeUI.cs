using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    private TextMeshProUGUI thisText;

    private float elapsedTime;
    [HideInInspector]
    public int minutes;
    [HideInInspector]
    public int seconds;

    void Start()
    {
        thisText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        minutes = Mathf.FloorToInt(elapsedTime / 60);
        seconds = Mathf.FloorToInt(elapsedTime % 60);
        thisText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
