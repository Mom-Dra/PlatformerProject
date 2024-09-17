using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private Scene gameManager;

    public StageData[] stageDatas;

    private void Awake()
    {
        gameManager = SceneManager.GetSceneByBuildIndex(0);
    }

    private void Start()
    {
        Init();
    }

    void Init()
    {
        GameObject[] managers = gameManager.GetRootGameObjects();
        for (int i = 0; i < managers.Length; i++)
        {
            UIManager uiManager = managers[i].GetComponent<UIManager>();
            if (uiManager != null)
            {
                stageDatas = uiManager.stageDatas;
            }
        }
    }

    public void LoadSceneToOrder(OrderList inOrder, Scene currentScene)
    {
        int sceneNum = currentScene.buildIndex;
        Debug.Log(inOrder);
        Debug.Log(currentScene);
        Debug.Log(sceneNum);

        switch (inOrder)
        {
            case OrderList.MainMenu:
                {
                    SceneManager.UnloadSceneAsync(currentScene);
                    SceneManager.LoadScene(1, LoadSceneMode.Additive);
                    break;
                }
            case OrderList.Retry:
                {
                    SceneManager.UnloadSceneAsync(currentScene);
                    SceneManager.LoadScene(sceneNum, LoadSceneMode.Additive);
                    break;
                }
            case OrderList.NextStage:
                {
                    if(currentScene.buildIndex - 2 < stageDatas.Length)
                    {
                        SceneManager.UnloadSceneAsync(currentScene);
                        SceneManager.LoadScene(sceneNum + 1, LoadSceneMode.Additive);
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
