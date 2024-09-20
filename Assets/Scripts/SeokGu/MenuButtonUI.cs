using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UIManager;

public class MenuButtonUI : MonoBehaviour
{
    private UIManager uiManager;
    private Button thisButton;
    private TextMeshProUGUI thisText;
    private OrderList thisOrder;
    private Canvas parentCanvas;

    private void Awake()
    {
        thisButton = GetComponent<Button>();
        thisText = GetComponentInChildren<TextMeshProUGUI>();

        thisButton.onClick.AddListener(OnClicked);
        parentCanvas = transform.parent.GetComponent<Canvas>();
    }

    private void Start()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
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
        uiManager.LoadSceneToOrder(thisOrder, gameObject.scene);
        parentCanvas.enabled = false;
    }
}
