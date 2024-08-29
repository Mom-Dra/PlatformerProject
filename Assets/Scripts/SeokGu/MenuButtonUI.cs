using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UIManager;

public class MenuButtonUI : MonoBehaviour
{
    private Button button;
    private TextMeshProUGUI thisText;
    private OrderList thisOrder;
    private Transform thisParent;

    private void Awake()
    {
        button = GetComponent<Button>();
        thisText = GetComponentInChildren<TextMeshProUGUI>();

        button.onClick.AddListener(OnClicked);
        thisParent = transform.parent;
    }

    public void SetData(MenuButtonData buttonData)
    {
        thisText.text = buttonData.text;
        thisOrder = buttonData.order;
    }

    void OnClicked()
    {
        UIManager uiManager = thisParent.parent.GetComponent<UIManager>();
        uiManager.LoadSceneToOrder(thisOrder);
        thisParent.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
