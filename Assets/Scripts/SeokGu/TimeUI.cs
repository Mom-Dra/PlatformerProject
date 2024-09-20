using TMPro;
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
        if(minutes < 10)
        {
            if(seconds < 10)
            {
                thisText.text = string.Format("{0:0} : {1:0}", minutes, seconds);
            }
            else
            {
                thisText.text = string.Format("{0:0} : {1:00}", minutes, seconds);
            }
        }
        else
        {
            if (seconds < 10)
            {
                thisText.text = string.Format("{0:00} : {1:0}", minutes, seconds);
            }
            else
            {
                thisText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
            }
        }
        
    }
}
