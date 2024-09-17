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
    private Transform thisParent;

    private void Awake()
    {
        thisButton = GetComponent<Button>();
        thisText = GetComponentInChildren<TextMeshProUGUI>();

        thisButton.onClick.AddListener(OnClicked);
        thisParent = transform.parent;
    }

    private void Start()
    {
        GameObject[] gameObjects = SceneManager.GetSceneByBuildIndex(0).GetRootGameObjects();
        for (int i = 0; i< gameObjects.Length;i++)
        {
            uiManager = gameObjects[i].GetComponent<UIManager>();
        }
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
        Debug.Log(uiManager);
        uiManager.LoadSceneToOrder(thisOrder, gameObject.scene);
        thisParent.gameObject.SetActive(false);
    }
}
