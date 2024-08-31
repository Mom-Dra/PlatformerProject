using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    private TextMeshProUGUI thisText;
    
    public int maxAmmo = 6;
    [HideInInspector]
    public int currentAmmo = -1;
    
    void Start()
    {
        thisText = GetComponentInChildren<TextMeshProUGUI>();
        currentAmmo = maxAmmo;
        UpdateAmmo();
    }

    public void UpdateAmmo()
    {
        thisText.text = string.Format("{0:00} / {1:00}", currentAmmo, maxAmmo);
    }
}
