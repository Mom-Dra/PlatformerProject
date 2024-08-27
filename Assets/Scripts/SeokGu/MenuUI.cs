using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UIManager;

public class MenuUI : MonoBehaviour
{
    private List<Button> buttons = new List<Button>();

    public int buttonCount = 3;
    public GameObject baseButton;
    public MenuButtonData[] menuData;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        for (int i = 0; i < buttonCount; i++)
        {
            Button button = baseButton.GetComponent<Button>();
            button = Instantiate(button, transform);
            button.transform.SetLocalPositionAndRotation(new Vector3(0, -100 * i, 0), Quaternion.identity);

            Navigation navi = new Navigation();
            navi.mode = Navigation.Mode.None;
            button.navigation = navi;

            RectTransform rectTransform = button.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(400, 70);

            buttons.Add(button);
        }
    }

    public void Show()
    {
        for (int i = 0; i < buttonCount; i++)
        {
            if (i < menuData.Length)
            {
                buttons[i].gameObject.SetActive(true);
                MenuButtonUI buttonUI = buttons[i].GetComponent<MenuButtonUI>();
                buttonUI.SetData(menuData[i]);
            }
            else
            {
                buttons[i].gameObject.SetActive(false);
            }
        }
    }
}
