using UnityEngine;
using UnityEngine.SceneManagement;
using static UIManager;

public class InGameUI : MonoBehaviour
{
    public GameObject menuUIPrefab;
    public GameObject exitUIPrefab;
    [HideInInspector]
    public OrderList currentOrder;
    [HideInInspector]
    public StageList thisStage;

    //private GameObject piUIPrefab;
    private GameObject optionUIPrefab;
    private PiUI piUI;
    private MenuUI menuUI;
    private ExitUI exitUI;
    private bool bDebug = false;

    void Start()
    {
        Init();
    }

    void Update()
    {
        if (bDebug == true)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (piUI.gameObject.activeSelf == true)
                    piUI.SelectItem();
            }

            if (Input.GetKey(KeyCode.Tab)) ShowPiUI(true);
            else ShowPiUI(false);

            if (Input.GetKeyDown(KeyCode.Escape)) ShowMenuUI(!menuUIPrefab.activeSelf);

            if (Input.GetKeyDown(KeyCode.V))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
            }
        }
    }

    void Init()
    {
        //piUIPrefab = GameObject.Find("PiUI");
        optionUIPrefab = GameObject.Find("OptionUI");
        menuUIPrefab = Instantiate(menuUIPrefab, transform);
        exitUIPrefab = Instantiate(exitUIPrefab, transform);
        menuUIPrefab.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        exitUIPrefab.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);

        piUI = GetComponentInChildren<PiUI>();
        menuUI = menuUIPrefab.GetComponent<MenuUI>();
        exitUI = exitUIPrefab.GetComponent<ExitUI>();

        piUI.gameObject.SetActive(true);
        menuUIPrefab.SetActive(false);
        exitUIPrefab.SetActive(false);
        OptionUI optionUI = optionUIPrefab.GetComponent<OptionUI>();
        optionUI.Init(menuUIPrefab);
    }

    public void ShowPiUI(bool bActive)
    {
        if (menuUIPrefab.activeSelf == true || exitUIPrefab.activeSelf == true) return;

        piUI.gameObject.SetActive(bActive);
    }

    public void ShowMenuUI(bool bActive)
    {
        if (exitUIPrefab.activeSelf == true) return;

        ShowPiUI(false);
        menuUIPrefab.SetActive(bActive);
        menuUI.Show();
        SetTimeScale();
    }

    public void VisibleExitUI(bool isFailed)
    {
        ShowExitUI(!exitUIPrefab.activeSelf, isFailed);
    }

    public void ShowExitUI(bool bActive, bool isFailed)
    {
        if (menuUIPrefab.activeSelf == true) return;

        ShowPiUI(false);
        exitUIPrefab.SetActive(bActive);
        exitUI.Show(isFailed);
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
}
