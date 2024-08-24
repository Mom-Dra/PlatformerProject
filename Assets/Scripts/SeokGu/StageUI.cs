using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UI;
using static UIManager;

public class StageUI : MonoBehaviour
{
    private int currentPiece = 0;
    private StagePiece stagePiece;
    private GameObject nextButton;
    private GameObject prevButton;

    public StageData[] stageDatas;
    public ChangeButtonData nextButtonData;
    public ChangeButtonData prevButtonData;
    private void Awake()
    {
        
    }

    private void Start()
    {
        Init();
    }

    void Init()
    {
        stagePiece = GetComponentInChildren<StagePiece>();
        nextButton = GameObject.Find("NextBtn");
        prevButton = GameObject.Find("PrevBtn");
        
        stagePiece.SetData(stageDatas[currentPiece]);
        ChangeButtonUI[] button = GetComponents<ChangeButtonUI>();
        
        for(int i =0;i< button.Length;i++)
        {
            button[i].SetData(nextButtonData);
            button[i] = prevButton.GetComponent<ChangeButtonUI>();
            button[i].SetData(prevButtonData);
        }
    }

    void Update()
    {
        
    }

    [System.Serializable]
    public class StageData
    {
        public Sprite stageImageSprite;
        public Color imageColor = new Color(1, 1, 1, 1);
        public string stageName;
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
