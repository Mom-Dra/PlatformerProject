using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    private TextMeshProUGUI thisText;
    private Canvas thisCanvas;

    public int maxAmmo = 6;
    [HideInInspector]
    public int currentAmmo = -1;
    
    void Start()
    {
        thisText = GetComponentInChildren<TextMeshProUGUI>();
        thisCanvas = GetComponent<Canvas>();
        ShowUI(false);

        currentAmmo = maxAmmo;
        UpdateAmmo();
    }

    public void UpdateAmmo()
    {
        thisText.text = string.Format("{0:00} / {1:00}", currentAmmo, maxAmmo);
    }

    public void ShowUI(bool bActive)
    {
        thisCanvas.enabled = bActive;
    }
}
