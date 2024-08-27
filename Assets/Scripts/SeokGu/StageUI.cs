using UnityEngine;

public class StageUI : MonoBehaviour
{
    private StagePiece stagePiece;

    public StageData[] stageDatas;
    public ChangeButtonData nextButtonData;
    public ChangeButtonData prevButtonData;

    [HideInInspector]
    public int currentPiece = 0;
    
    private void Awake()
    {
        Init();
    }

    void Init()
    {
        stagePiece = GetComponentInChildren<StagePiece>();
        
        stagePiece.SetData(stageDatas[currentPiece]);

        ChangeButtonUI[] button = GetComponentsInChildren<ChangeButtonUI>();

        button[0].SetData(nextButtonData);
        button[1].SetData(prevButtonData);
    }

    public void UpdateStage()
    {
        stagePiece.SetData(stageDatas[currentPiece]);
    }

    [System.Serializable]
    public class StageData
    {
        public Sprite stageImageSprite;
        public Color imageColor = new Color(1, 1, 1, 1);
        public string stageName;
        public StageList stage;
    }

    [System.Serializable]
    public class ChangeButtonData
    {
        public Sprite imageSprite;
        public Color imageColor = new Color(1, 1, 1, 1);
        public ButtonDirection direction;
    }

    public enum StageList
    {
        Stage1,
        Stage2,
        Stage3
    }

    public enum ButtonDirection
    {
        NEXT,
        PREV
    }
}
