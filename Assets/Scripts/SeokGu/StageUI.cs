using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageUI : MonoBehaviour
{
    private StagePiece stagePiece;
    private Vector3 ScreenSize;

    public ChangeButtonData nextButtonData;
    public ChangeButtonData prevButtonData;
    [HideInInspector]
    public int currentPiece = 0;
    [HideInInspector]
    public int maxPiece = -1;
    [HideInInspector]
    public UIManager uiManager;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();

        ChangeButtonUI[] button = GetComponentsInChildren<ChangeButtonUI>();

        stagePiece = GetComponentInChildren<StagePiece>();
        uiManager.stageDatas[0].isActive = true;
        stagePiece.SetData(uiManager.stageDatas[currentPiece]);
        maxPiece = uiManager.stageDatas.Length;

        button[0].SetData(nextButtonData);
        button[1].SetData(prevButtonData);
    }
    public void UpdateStage()
    {
        stagePiece.SetData(uiManager.stageDatas[currentPiece]);
    }

    [System.Serializable]
    public class ChangeButtonData
    {
        public Sprite imageSprite;
        public Color imageColor = new Color(1, 1, 1, 1);
        public ButtonDirection direction;
    }

    public enum ButtonDirection
    {
        NEXT,
        PREV
    }
}
