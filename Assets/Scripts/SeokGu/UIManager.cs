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
    private PiUI piUI;
    private MenuUI menuUI;
    private ExitUI exitUI;
    private bool bDebug = true;

    void Start()
    {
        piUIPrefab = GameObject.Find("PiUI");
        optionUIPrefab = GameObject.Find("OptionUI");
        menuUIPrefab = Instantiate(menuUIPrefab, transform);
        exitUIPrefab = Instantiate(exitUIPrefab, transform);
        menuUIPrefab.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        exitUIPrefab.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);

        piUI = piUIPrefab.GetComponent<PiUI>();
        menuUI = menuUIPrefab.GetComponent<MenuUI>();
        exitUI = exitUIPrefab.GetComponent<ExitUI>();

        menuUIPrefab.SetActive(false);
        exitUIPrefab.SetActive(false);
        OptionUI optionUI = optionUIPrefab.GetComponent<OptionUI>();
        optionUI.Init(menuUIPrefab);
    }

    void Update()
    {
        if(bDebug == true)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if(piUIPrefab.activeSelf == true)
                    piUI.SelectItem();
            }

            if (Input.GetKey(KeyCode.Tab)) ShowPiUI(true);
            else ShowPiUI(false);

            if (Input.GetKeyDown(KeyCode.Escape)) ShowMenuUI(!menuUIPrefab.activeSelf);
            if (Input.GetKeyDown(KeyCode.T)) ShowExitUI(!exitUIPrefab.activeSelf);
            
            if (Input.GetKeyDown(KeyCode.V))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
            }
        }
    }

    public void ShowPiUI(bool bActive)
    {
        if (menuUIPrefab.activeSelf == true || exitUIPrefab.activeSelf == true) return;

        piUIPrefab.SetActive(bActive);
    }

    public void ShowMenuUI(bool bActive)
    {
        if (exitUIPrefab.activeSelf == true) return;

        ShowPiUI(false);
        menuUIPrefab.SetActive(bActive);
        menuUI.Show();
        SetTimeScale();
    }

    public void ShowExitUI(bool bActive)
    {
        if (menuUIPrefab.activeSelf == true) return;

        ShowPiUI(false);
        exitUIPrefab.SetActive(bActive);
        exitUI.Show(false);
        SetTimeScale();
    }

    void SetTimeScale()
    {
        if (exitUIPrefab.activeSelf == false && menuUIPrefab.activeSelf == false)
        {
            Time.timeScale = 1.0f;
        }
        else
            Time.timeScale = 0.0f;
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
