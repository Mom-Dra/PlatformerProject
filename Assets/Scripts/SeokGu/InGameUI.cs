using UnityEngine;
using static UIManager;

public class InGameUI : MonoBehaviour
{
    [HideInInspector]
    public OrderList currentOrder;
    [HideInInspector]
    public StageList thisStage;
    [HideInInspector]
    public UIManager uiManager;
    
    private PiUI piUI;
    private MenuUI menuUI;
    private ExitUI exitUI;
    private EquipUI equipUI;
    private OptionUI optionUI;
    private Canvas piCanvas;
    private Canvas menuCanvas;
    private Canvas exitCanvas;
    private bool bDebug = true;

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
                if (piCanvas.enabled == true)
                    piUI.SelectItem();
            }

            if (Input.GetKey(KeyCode.Tab)) ShowPiUI(true);
            else ShowPiUI(false);

            if (Input.GetKeyDown(KeyCode.Escape)) ShowMenuUI(!menuCanvas.enabled);

            if (Input.GetKeyDown(KeyCode.Z)) ShowExitUI(!exitCanvas.enabled, false);
            if (Input.GetKeyDown(KeyCode.X)) SetUnarmed();
        }
    }

    void Init()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();

        piUI = GetComponentInChildren<PiUI>();
        menuUI = GetComponentInChildren<MenuUI>();
        exitUI = GetComponentInChildren<ExitUI>();
        equipUI = GetComponentInChildren<EquipUI>();
        optionUI = GetComponentInChildren<OptionUI>();

        piCanvas = piUI.gameObject.GetComponent<Canvas>();
        menuCanvas = menuUI.gameObject.GetComponent<Canvas>();
        exitCanvas = exitUI.gameObject.GetComponent<Canvas>();

        piCanvas.enabled = false;
        menuCanvas.enabled = false;
        exitCanvas.enabled = false;
        optionUI.Init(menuCanvas);
    }

    public void ShowPiUI(bool bActive)
    {
        if (menuCanvas.enabled == true || exitCanvas.enabled == true) return;

        piCanvas.enabled = bActive;
    }

    public void ShowMenuUI(bool bActive)
    {
        if (exitCanvas.enabled == true) return;

        ShowPiUI(false);
        menuCanvas.enabled = bActive;
        menuUI.Show();
        SetTimeScale();
    }

    public void VisibleExitUI(bool isFailed)
    {
        ShowExitUI(!exitCanvas.enabled, isFailed);
    }

    public void ShowExitUI(bool bActive, bool isFailed)
    {
        if (menuCanvas.enabled == true) return;

        ShowPiUI(false);
        exitCanvas.enabled = bActive;
        exitUI.Show(isFailed);
        SetTimeScale();
    }

    void SetTimeScale()
    {
        if (menuCanvas.enabled == false && exitCanvas.enabled == false)
        {
            Time.timeScale = 1.0f;
        }
        else
            Time.timeScale = 0.0f;
    }

    public void SetUnarmed()
    {
        equipUI.ChangeIcon(piUI.defaultData);
    }
}
