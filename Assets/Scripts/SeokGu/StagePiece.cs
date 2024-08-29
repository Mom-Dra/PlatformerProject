using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static StageUI;

public class StagePiece : MonoBehaviour
{
    private Image thisImage;
    private Button thisButton;
    private TextMeshProUGUI thisText;
    private StageList thisStage;

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        thisImage = GetComponent<Image>();
        thisButton = GetComponent<Button>();
        thisText = GetComponentInChildren<TextMeshProUGUI>();

        thisButton.onClick.AddListener(OnClicked);
    }

    void OnClicked()
    {
        //if (SceneManager.GetSceneAt((int)thisStage) != null)
        //    SceneManager.LoadScene((int)thisStage);
    }

    public void SetData(StageData inStageData)
    {
        thisImage.sprite = inStageData.stageImageSprite;
        thisImage.color = inStageData.imageColor;
        thisImage.preserveAspect = true;
        thisText.text = inStageData.stageName;
        thisStage = inStageData.stage;
    }
}
