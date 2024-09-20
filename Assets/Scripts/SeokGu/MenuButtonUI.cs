using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UIManager;

public class MenuButtonUI : MonoBehaviour
{
    private InGameUI inGameUI;
    private Button thisButton;
    private TextMeshProUGUI thisText;
    private OrderList thisOrder;
    private Canvas parentCanvas;

    private void Awake()
    {
        thisButton = GetComponent<Button>();
        thisText = GetComponentInChildren<TextMeshProUGUI>();
        inGameUI = transform.parent.parent.GetComponent<InGameUI>();

        thisButton.onClick.AddListener(OnClicked);
        parentCanvas = transform.parent.GetComponent<Canvas>();
    }

    public void SetData(MenuButtonData buttonData)
    {
        thisText.text = buttonData.text;
        thisText.fontStyle = FontStyles.Bold;
        thisText.fontSize = 36.0f;
        thisOrder = buttonData.order;
    }

    void OnClicked()
    {
        inGameUI.uiManager.LoadSceneToOrder(thisOrder, gameObject.scene);
        parentCanvas.enabled = false;
    }
}
