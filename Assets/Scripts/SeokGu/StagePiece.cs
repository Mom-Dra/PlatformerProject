using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class StagePiece : MonoBehaviour
{
    public UIManager.UITransform pieceTransform;
    public UIManager.UITransform stageNameTextTransform;
    public UIManager.UITransform clearTextTransform;

    private Image thisImage;
    private Button thisButton;
    private TextMeshProUGUI stageNameText;
    private TextMeshProUGUI clearText;
    private UIManager.StageList thisStage;

    private RectTransform rtPiece;
    private RectTransform rtStageNameText;
    private RectTransform rtClearText;
    private float stageNameTextFontSize;
    private float clearTextFontSize;

    private void Awake()
    {
        Init();
    }

    public void UpdateUISize(float inWidth, float inHeight)
    {
        rtPiece.sizeDelta = new Vector2(pieceTransform.Width / inWidth, pieceTransform.Height / inHeight);
        rtStageNameText.sizeDelta = new Vector2(stageNameTextTransform.Width / inWidth, stageNameTextTransform.Height / inHeight);
        rtClearText.sizeDelta = new Vector2(clearTextTransform.Width / inWidth, clearTextTransform.Height / inHeight);

        stageNameText.gameObject.transform.position = new Vector3(stageNameTextTransform.Pos.x / inWidth, stageNameTextTransform.Pos.y / inHeight);
        clearText.gameObject.transform.position = new Vector3(clearTextTransform.Pos.x / inWidth, clearTextTransform.Pos.y / inHeight);

        stageNameText.fontSize = stageNameTextFontSize / inWidth;
        clearText.fontSize = clearTextFontSize / inWidth;
    }

    void Init()
    {
        rtPiece = GetComponent<RectTransform>();
        thisImage = GetComponent<Image>();
        thisButton = GetComponent<Button>();
        
        stageNameText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        rtStageNameText = transform.GetChild(0).GetComponent<RectTransform>();

        clearText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        rtClearText = transform.GetChild(1).GetComponent<RectTransform>();

        stageNameTextFontSize = stageNameText.fontSize;
        clearTextFontSize = clearText.fontSize;
        thisButton.onClick.AddListener(OnClicked);
    }

    void OnClicked()
    {
        SceneManager.UnloadSceneAsync(gameObject.scene);
        SceneManager.LoadScene((int)thisStage + 2, LoadSceneMode.Additive);
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
