using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UIManager;

public class ButtonUI : MonoBehaviour
{
    private Button button;
    private TextMeshProUGUI thisText;
    private OrderList thisOrder;

    private void Awake()
    {
        button = GetComponent<Button>();
        thisText = GetComponentInChildren<TextMeshProUGUI>();

        button.onClick.AddListener(OnClicked);
    }

    public void SetData(ButtonData buttonData)
    {
        thisText.text = buttonData.text;
        thisOrder = buttonData.order;
    }

    void OnClicked()
    {
        
        UIManager uiManager = transform.parent.parent.GetComponent<UIManager>();
        uiManager.currentOrder = thisOrder;
        Debug.Log(uiManager.currentOrder);
        transform.parent.gameObject.SetActive(false);
    }
}
