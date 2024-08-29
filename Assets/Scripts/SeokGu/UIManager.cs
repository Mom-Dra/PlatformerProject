using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [HideInInspector]
    public OrderList currentOrder;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void LoadSceneToOrder(OrderList inOrder)
    {
        currentOrder = inOrder;
        switch (inOrder)
        {
            case OrderList.MainMenu:
                {
                    break;
                }
            case OrderList.Retry:
                {
                    SceneManager.LoadScene(0);
                    break;
                }
            case OrderList.NextStage:
                {
                    // 현재 Stage정보 가져와서 처리
                    break;
                }
            case OrderList.ReturnGame:
                {
                    break;
                }
        }
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
