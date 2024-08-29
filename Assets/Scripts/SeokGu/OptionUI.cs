using UnityEngine;
using UnityEngine.UI;
using static UIManager;

public class OptionUI : MonoBehaviour
{
    private Image thisImage;
    private Button thisButton;
    private GameObject menuUIPrefab;
    private InGameUI inGameUI;

    public PiData defaultData;

    void Awake()
    {
        thisImage = GetComponent<Image>();
        thisImage.sprite = defaultData.imageSprite;
        thisImage.color = defaultData.imageColor;

        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(OnClicked);

        inGameUI = transform.parent.GetComponent<InGameUI>();

        Navigation navi = new Navigation();
        navi.mode = Navigation.Mode.None;
        thisButton.navigation = navi;
    }

    public void Init(GameObject inGameObject)
    {
        menuUIPrefab = inGameObject;
    }

    void OnClicked()
    {
        inGameUI.ShowMenuUI(!menuUIPrefab.activeSelf);
    }
}
