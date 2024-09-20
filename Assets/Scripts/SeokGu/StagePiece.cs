using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StagePiece : MonoBehaviour
{
    private Image thisImage;
    private Button thisButton;
    private TextMeshProUGUI stageNameText;
    private TextMeshProUGUI clearText;
    private UIManager.StageList thisStage;

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        thisImage = GetComponent<Image>();
        thisButton = GetComponent<Button>();

        stageNameText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        stageNameText.fontSize = 80.0f;
        stageNameText.fontStyle = FontStyles.Bold;

        clearText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        clearText.fontSize = 80.0f;
        clearText.fontStyle = FontStyles.Bold;

        thisButton.onClick.AddListener(OnClicked);
    }

    void OnClicked()
    {
        //SceneManager.UnloadSceneAsync(gameObject.scene);
        //SceneManager.LoadScene((int)thisStage + 2, LoadSceneMode.Additive);
        SceneManager.LoadScene((int)thisStage + 1);
    }

    public void SetData(UIManager.StageData inStageData)
    {
        thisImage.sprite = inStageData.stageImageSprite;
        thisImage.color = inStageData.imageColor;
        thisImage.preserveAspect = true;

        stageNameText.text = inStageData.stageName;
        thisStage = inStageData.stage;
        thisButton.interactable = inStageData.isActive;
        clearText.gameObject.SetActive(inStageData.isClear);
    }
}
