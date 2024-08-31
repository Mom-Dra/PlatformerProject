using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UIManager;

public class MenuButtonUI : MonoBehaviour
{
    private Button thisButton;
    private TextMeshProUGUI thisText;
    private OrderList thisOrder;
    private Transform thisParent;

    private void Awake()
    {
        thisButton = GetComponent<Button>();
        thisText = GetComponentInChildren<TextMeshProUGUI>();

        thisButton.onClick.AddListener(OnClicked);
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
        uiManager.LoadSceneToOrder(thisOrder, gameObject.scene);
        thisParent.gameObject.SetActive(false);
        
    }
}
