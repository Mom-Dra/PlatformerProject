using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    private int maxAmmo = 99;
    private int currentAmmo = 15;
    private TextMeshProUGUI thisText;
    void Start()
    {
        thisText = GetComponentInChildren<TextMeshProUGUI>();
        UpdateAmmo(currentAmmo);
    }

    public void UpdateAmmo(int inCurrentAmmo)
    {
        currentAmmo = inCurrentAmmo;
        Mathf.Clamp(currentAmmo, 0, maxAmmo);

        thisText.text = string.Format("{0:00} / {1:00}", currentAmmo, maxAmmo);
    }
}
