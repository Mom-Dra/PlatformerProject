using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject menuUIPrefab;
    public GameObject exitUIPrefab;

    [HideInInspector]
    public OrderList currentOrder;

    private GameObject piUIPrefab;
    private GameObject optionUIPrefab;
    private MenuUI menuUI;
    private ExitUI exitUI;

    void Start()
    {
        piUIPrefab = GameObject.Find("PiUI");
        optionUIPrefab = GameObject.Find("OptionUI");
        menuUIPrefab = Instantiate(menuUIPrefab, transform);
        exitUIPrefab = Instantiate(exitUIPrefab, transform);
        menuUIPrefab.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        exitUIPrefab.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);

        menuUI = menuUIPrefab.GetComponent<MenuUI>();
        exitUI = exitUIPrefab.GetComponent<ExitUI>();

        menuUIPrefab.SetActive(false);
        exitUIPrefab.SetActive(false);
        OptionUI optionUI = optionUIPrefab.GetComponent<OptionUI>();
        optionUI.Init(menuUIPrefab);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ShowMenuUI(!menuUIPrefab.activeSelf);
        if (Input.GetKeyDown(KeyCode.T)) ShowExitUI(!exitUIPrefab.activeSelf);
        if (Input.GetKeyDown(KeyCode.V))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
    }

    public void ShowPiUI(bool bActive)
    {
        piUIPrefab.SetActive(bActive);
    }

    public void ShowMenuUI(bool bActive)
    {
        menuUIPrefab.SetActive(bActive);
        menuUI.Show();
    }

    public void ShowExitUI(bool bActive)
    {
        exitUIPrefab.SetActive(bActive);
        exitUI.Show(false);
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
    public class ButtonData
    {
        public string text;
        public OrderList order;
    }
}
