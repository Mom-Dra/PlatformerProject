using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public StageData[] stageDatas;

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadSceneToOrder(OrderList inOrder, Scene currentScene)
    {
        int sceneNum = currentScene.buildIndex;

        switch (inOrder)
        {
            case OrderList.MainMenu:
                {
                    SceneManager.LoadScene(0);
                    break;
                }
            case OrderList.Retry:
                {
                    SceneManager.LoadScene(sceneNum);
                    break;
                }
            case OrderList.NextStage:
                {
                    if (currentScene.buildIndex - 1 < stageDatas.Length)
                    {
                        SceneManager.LoadScene(sceneNum + 1);
                    }
                    break;
                }
            case OrderList.ReturnGame:
                {
                    break;
                }
        }
        Time.timeScale = 1.0f;
    }

    public enum ItemList
    {
        None,
        Stone,
        Gun
    }

    public enum OrderList
    {
        MainMenu,
        Retry,
        NextStage,
        ReturnGame
    }
    
    public enum StageList
    {
        Stage1,
        Stage2,
        Stage3
    }

    [System.Serializable]
    public class UITransform
    {
        public float Width;
        public float Height;
        public Vector3 Pos;
    }

    [System.Serializable]
    public class StageData
    {
        public Sprite stageImageSprite;
        public Color imageColor = new Color(1, 1, 1, 1);
        public string stageName;
        public StageList stage;
        public bool isActive = false;
        public bool isClear = false;
    }

    [System.Serializable]
    public class PiData
    {
        public Sprite imageSprite;
        public Color imageColor = new Color(1, 1, 1, 1);
        public ItemList item;
    }

    [System.Serializable]
    public class MenuButtonData
    {
        public string text;
        public OrderList order;
    }
}
