using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using static StageUI;
using static UIManager;

public class ChangeButtonUI : MonoBehaviour
{
    private Button thisButton;
    private Image thisImage;
    private StageUI stageUI;
    private ButtonDirection buttonDir;

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        stageUI = GetComponentInParent<StageUI>();
        thisButton = GetComponent<Button>();
        thisImage = GetComponent<Image>();

        Navigation navi = new Navigation();
        navi.mode = Navigation.Mode.None;
        thisButton.navigation = navi;

        thisButton.onClick.AddListener(OnClicked);
    }

    void OnClicked()
    {
        switch (buttonDir)
        {
            case ButtonDirection.NEXT:
                {
                    if (stageUI.currentPiece > stageUI.maxPiece - 2) break;

                    stageUI.currentPiece++;
                    stageUI.UpdateStage();
                    break;
                }
            case ButtonDirection.PREV:
                {
                    if (stageUI.currentPiece < 1) break;

                    stageUI.currentPiece--;
                    stageUI.UpdateStage();
                    break;
                }
            default: break;
        }
    }

    public void SetData(ChangeButtonData inData)
    {
        thisImage.sprite = inData.imageSprite;
        thisImage.color = inData.imageColor;
        buttonDir = inData.direction;
    }

    void Update()
    {

    }

    
}
